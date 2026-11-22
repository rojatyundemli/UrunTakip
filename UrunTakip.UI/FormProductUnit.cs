
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UrunTakip.Business;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class FormProductUnit : Form
    {
        private bool _isLoading = false;
        private int? _selectedProductUnitId = null;

        public FormProductUnit()
        {
            InitializeComponent();
            cmb_product.SelectedIndexChanged -= cmb_product_SelectedIndexChanged;
            cmb_product.SelectedIndexChanged += cmb_product_SelectedIndexChanged;
        }

        // FORM LOAD
        private void FormProductUnit_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            try
            {
                FillProductComboBox();
                FillAlternativeUnitComboBox(null);

                ResetInputFields();

                LoadProductUnits(null);

                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_clear.Enabled = false;
            }
            finally
            {
                _isLoading = false;
            }
        }

        // ÜRÜN COMBOBOX DOLDURMA
        public void FillProductComboBox()
        {
            ProductUnitsService service = new ProductUnitsService();

            var products = service.GetProductsWithMainUnit();

            cmb_product.DataSource = null;
            cmb_product.DisplayMember = "Name";
            cmb_product.ValueMember = "Id";
            cmb_product.DataSource = products;

            cmb_product.SelectedIndex = -1;
        }

        // ALTERNATİF BİRİM COMBOBOX DOLDURMA
        public void FillAlternativeUnitComboBox(
            int? productId,
            int? currentProductUnitId = null)
        {
            List<UnitOfMeasure> units = new List<UnitOfMeasure>();

            if (productId.HasValue)
            {
                ProductUnitsService service = new ProductUnitsService();

                units = service.GetAlternativeUnits(
                    productId.Value,
                    currentProductUnitId);
            }

            cmb_alternativeUnit.DataSource = null;
            cmb_alternativeUnit.DisplayMember = "UnitName";
            cmb_alternativeUnit.ValueMember = "Id";
            cmb_alternativeUnit.DataSource = units;

            cmb_alternativeUnit.SelectedIndex = -1;
        }

        // ÜRÜN SEÇİLDİĞİNDE
        private void cmb_product_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            Product selectedProduct = cmb_product.SelectedItem as Product;

            if (selectedProduct == null)
            {
                _isLoading = true;

                try
                {
                    _selectedProductUnitId = null;

                    txt_baseUnit.Clear();

                    FillAlternativeUnitComboBox(null);

                    ResetInputFields();

                    btn_Save.Enabled = true;
                    btn_Update.Enabled = false;
                    btn_clear.Enabled = false;
                }
                finally
                {
                    _isLoading = false;
                }

                LoadProductUnits(null);
                return;
            }

            _isLoading = true;

            try
            {
                _selectedProductUnitId = null;

                txt_baseUnit.Text = selectedProduct.MainUnitName ?? "";

                ResetInputFields(false);

                FillAlternativeUnitComboBox(selectedProduct.Id);

                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_clear.Enabled = true;
            }
            finally
            {
                _isLoading = false;
            }

            LoadProductUnits(selectedProduct.Id);
        }

        // DATAGRIDVIEW LİSTELEME
        public void LoadProductUnits(int? productId)
        {
            ProductUnitsService service = new ProductUnitsService();

            bool previousState = _isLoading;

            _isLoading = true;

            try
            {
                dgv_ProductUnitsList.DataSource =
                    service.GetProductUnits(productId);

                if (dgv_ProductUnitsList.Columns.Contains("Id"))
                    dgv_ProductUnitsList.Columns["Id"].Visible = false;

                if (dgv_ProductUnitsList.Columns.Contains("ProductId"))
                    dgv_ProductUnitsList.Columns["ProductId"].Visible = false;

                if (dgv_ProductUnitsList.Columns.Contains("UnitId"))
                    dgv_ProductUnitsList.Columns["UnitId"].Visible = false;

                dgv_ProductUnitsList.Columns["ProductName"].HeaderText = "Ürün";
                dgv_ProductUnitsList.Columns["MainUnitName"].HeaderText = "Ana Birim";
                dgv_ProductUnitsList.Columns["AlternativeUnitName"].HeaderText = "Alternatif Birim";
                dgv_ProductUnitsList.Columns["Numerator"].HeaderText = "Dönüşüm Payı";
                dgv_ProductUnitsList.Columns["Denominator"].HeaderText = "Dönüşüm Paydası";
                dgv_ProductUnitsList.Columns["IsPurchaseUnit"].HeaderText = "Satın Alma";
                dgv_ProductUnitsList.Columns["IsSalesUnit"].HeaderText = "Satış";
                dgv_ProductUnitsList.Columns["IsActive"].HeaderText = "Durum";
                dgv_ProductUnitsList.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                dgv_ProductUnitsList.Columns["UpdatedAt"].HeaderText = "Güncellenme Tarihi";

                dgv_ProductUnitsList.ClearSelection();
            }
            finally
            {
                _isLoading = previousState;
            }
        }

        // KAYIT İŞLEMİ
        public void AddProductUnit()
        {
            Product selectedProduct = cmb_product.SelectedItem as Product;

            UnitOfMeasure selectedUnit =
                cmb_alternativeUnit.SelectedItem as UnitOfMeasure;

            if (selectedProduct == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                return;
            }

            if (selectedUnit == null)
            {
                MessageBox.Show("Lütfen alternatif birim seçin.");
                return;
            }

            ProductUnits productUnit = new ProductUnits()
            {
                ProductId = selectedProduct.Id,
                UnitId = selectedUnit.Id,

                Numerator = nmr_pay.Value,
                Denominator = nmr_payda.Value,

                IsPurchaseUnit = check_IsPurchaseUnit.Checked,
                IsSalesUnit = check_IsSalesUnit.Checked,
                IsActive = check_IsActive.Checked
            };

            ProductUnitsService service = new ProductUnitsService();

            string result = service.AddProductUnit(productUnit);

            MessageBox.Show(result);

            if (result == "Ürün alternatifi başarıyla kaydedildi.")
            {
                RefreshCurrentProduct(selectedProduct.Id);
            }
        }

        // GÜNCELLEME İŞLEMİ
        public void UpdateProductUnit()
        {
            if (!_selectedProductUnitId.HasValue)
            {
                MessageBox.Show("Önce güncellenecek bir kayıt seçin.");
                return;
            }

            Product selectedProduct = cmb_product.SelectedItem as Product;

            UnitOfMeasure selectedUnit =
                cmb_alternativeUnit.SelectedItem as UnitOfMeasure;

            if (selectedProduct == null || selectedUnit == null)
            {
                MessageBox.Show("Ürün ve alternatif birim seçilmelidir.");
                return;
            }

            ProductUnits productUnit = new ProductUnits()
            {
                Id = _selectedProductUnitId.Value,

                ProductId = selectedProduct.Id,
                UnitId = selectedUnit.Id,

                Numerator = nmr_pay.Value,
                Denominator = nmr_payda.Value,

                IsPurchaseUnit = check_IsPurchaseUnit.Checked,
                IsSalesUnit = check_IsSalesUnit.Checked,
                IsActive = check_IsActive.Checked
            };

            ProductUnitsService service = new ProductUnitsService();

            string result = service.UpdateProductUnit(productUnit);

            MessageBox.Show(result);

            if (result == "Ürün alternatifi başarıyla güncellendi.")
            {
                RefreshCurrentProduct(selectedProduct.Id);
            }
        }

        // KAYIT VE GÜNCELLEME SONRASI YENİLEME
        public void RefreshCurrentProduct(int productId)
        {
            _isLoading = true;

            try
            {
                _selectedProductUnitId = null;

                FillAlternativeUnitComboBox(productId);

                ResetInputFields(false);

                Product selectedProduct =
                    cmb_product.SelectedItem as Product;

                txt_baseUnit.Text = selectedProduct?.MainUnitName ?? "";

                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_clear.Enabled = true;
            }
            finally
            {
                _isLoading = false;
            }

            LoadProductUnits(productId);
        }

        // GİRİŞ ALANLARINI TEMİZLE
        public void ResetInputFields(bool clearBaseUnit = true)
        {
            _selectedProductUnitId = null;

            if (clearBaseUnit)
                txt_baseUnit.Clear();

            cmb_alternativeUnit.SelectedIndex = -1;

            nmr_pay.Value = nmr_pay.Minimum;
            nmr_payda.Value = nmr_payda.Minimum;

            check_IsPurchaseUnit.Checked = false;
            check_IsSalesUnit.Checked = false;
            check_IsActive.Checked = true;
        }

        // TÜM FORMU TEMİZLE
        public void ClearForm()
        {
            _isLoading = true;

            try
            {
                _selectedProductUnitId = null;

                cmb_product.SelectedIndex = -1;

                FillAlternativeUnitComboBox(null);

                ResetInputFields();

                dgv_ProductUnitsList.ClearSelection();

                btn_Save.Enabled = true;
                btn_Update.Enabled = false;
                btn_clear.Enabled = false;
            }
            finally
            {
                _isLoading = false;
            }

            LoadProductUnits(null);
        }

        // NUMERICUPDOWN DEĞERİNİ SINIRLA
        private void SetNumericValue(Krypton.Toolkit.KryptonNumericUpDown control, decimal value)
        {
            if (value < control.Minimum)
                value = control.Minimum;

            if (value > control.Maximum)
                value = control.Maximum;

            control.Value = value;
        }

        // DATAGRIDVIEW SATIR SEÇİMİ
        private void dgv_ProductUnitsList_SelectionChanged(
            object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            if (dgv_ProductUnitsList.CurrentRow == null)
                return;

            ProductUnits productUnit = dgv_ProductUnitsList.CurrentRow.DataBoundItem as ProductUnits;

            if (productUnit == null)
                return;

            _isLoading = true;

            try
            {
                _selectedProductUnitId = productUnit.Id;

                cmb_product.SelectedValue = productUnit.ProductId;

                txt_baseUnit.Text = productUnit.MainUnitName ?? "";

                FillAlternativeUnitComboBox(
                    productUnit.ProductId,
                    productUnit.Id);

                cmb_alternativeUnit.SelectedValue = productUnit.UnitId;

                SetNumericValue(nmr_pay, productUnit.Numerator);
                SetNumericValue(nmr_payda, productUnit.Denominator);

                check_IsPurchaseUnit.Checked = productUnit.IsPurchaseUnit;
                check_IsSalesUnit.Checked = productUnit.IsSalesUnit;
                check_IsActive.Checked = productUnit.IsActive;

                btn_Save.Enabled = false;
                btn_Update.Enabled = true;
                btn_clear.Enabled = true;
            }
            finally
            {
                _isLoading = false;
            }
        }

        // BUTON OLAYLARI
        private void btn_Save_Click(object sender, EventArgs e)
        {
            AddProductUnit();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateProductUnit();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
