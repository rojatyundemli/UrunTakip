using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrunTakip.Business;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class FormUnitConversions : Form
    {

        private int? _selectedConversionId = null;

        private bool _isLoading = false;

        public FormUnitConversions()
        {
            InitializeComponent();
            FillUnitComboBox();
            GetConversions();
            ClearForm();
        }

        private void FormUnitConversions_Load(object sender, EventArgs e)
        {
            FillUnitComboBox();
        }

        public void FillUnitComboBox()
        {

            UnitConversionsService service = new UnitConversionsService();

            var units = service.GetUnitOfMeasures();

            cmb_unit.DataSource = null;
            cmb_unit.DisplayMember = "UnitName";
            cmb_unit.ValueMember = "Id";
            cmb_unit.DataSource = units;

            cmb_unit.SelectedIndex = -1;
        }

        private void cmb_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnitOfMeasure selectedUnit = cmb_unit.SelectedItem as UnitOfMeasure;

            if (selectedUnit == null)
            {
                txt_unitCode.Clear();
                txt_dimensionsName.Clear();
                txt_baseUnitName.Clear();
                return;
            }

            txt_unitCode.Text = selectedUnit.UnitCode;
            txt_dimensionsName.Text = selectedUnit.DimensionName;
            txt_baseUnitName.Text = selectedUnit.BaseUnitName;
        }

        public void AddConversion()
        {
            if (cmb_unit.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ölçü birimi seçin.");
                return;
            }

            int unitId = Convert.ToInt32(cmb_unit.SelectedValue);

            if (unitId <= 0)
            {
                MessageBox.Show("Geçerli bir ölçü birimi seçin.");
                return;
            }

            UnitConversions conversion = new UnitConversions()
            {
                UnitId = unitId,
                Numerator = nmr_Numarator.Value,
                Denominator = nmr_Denominator.Value
            };

            UnitConversionsService service = new UnitConversionsService();

            string result = service.AddDimensAddConversionsions(conversion);

            MessageBox.Show(result);


            GetConversions();
            ClearForm();
        }
        public void UpdateConversion()
        {
            if (_selectedConversionId == null)
            {
                MessageBox.Show("Önce güncellenecek bir dönüşüm seçin.");
                return;
            }

            if (cmb_unit.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ölçü birimi seçin.");
                return;
            }

            UnitConversions conversion = new UnitConversions()
            {
                Id = _selectedConversionId.Value,
                UnitId = Convert.ToInt32(cmb_unit.SelectedValue),
                Numerator = nmr_Numarator.Value,
                Denominator = nmr_Denominator.Value
            };

            UnitConversionsService service = new UnitConversionsService();

            string result = service.UpdateConversion(conversion);

            MessageBox.Show(result);

            GetConversions();
            ClearForm();
        }

        private void UpdateInfo()
        {
            if (cmb_unit.SelectedItem == null)
            {
                lbl_result.Text = "";
                return;
            }

            if (nmr_Numarator.Value <= 0 || nmr_Denominator.Value <= 0)
            {
                lbl_result.Text = "Geçerli bir dönüşüm oranı girin.";
                return;
            }

            decimal numerator = nmr_Numarator.Value;
            decimal denominator = nmr_Denominator.Value;

            decimal conversionFactor = numerator / denominator;

            lbl_result.Text = $"1 {txt_unitCode.Text} = {conversionFactor:0.########} {txt_baseUnitName.Text}";
        }

        public void GetConversions()
        {
            UnitConversionsService service = new UnitConversionsService();

            _isLoading = true;

            try
            {
                kryptonDataGridView1.DataSource = service.GetUnitConverion();

                kryptonDataGridView1.Columns["Id"].Visible = false;
                kryptonDataGridView1.Columns["UnitId"].Visible = false;

                kryptonDataGridView1.Columns["UnitName"].HeaderText = "Birim Adı";
                kryptonDataGridView1.Columns["DimensionName"].HeaderText = "Ölçü Türü";
                kryptonDataGridView1.Columns["BaseUnitName"].HeaderText = "Temel Birim";
                kryptonDataGridView1.Columns["Numerator"].HeaderText = "Dönüşüm Payı";
                kryptonDataGridView1.Columns["Denominator"].HeaderText = "Dönüşüm Paydası";

                kryptonDataGridView1.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                kryptonDataGridView1.Columns["UpdatedAt"].HeaderText = "Güncellenme Tarihi";
            }
            finally
            {
                _isLoading = false;
            }
        }
        public void ClearForm()
        {
            _isLoading = true;

            try
            {
                _selectedConversionId = null;

                kryptonDataGridView1.ClearSelection();

                cmb_unit.SelectedIndex = -1;

                txt_unitCode.Clear();
                txt_dimensionsName.Clear();
                txt_baseUnitName.Clear();

                nmr_Numarator.Value = 0;
                nmr_Denominator.Value = 0;

                lbl_result.Text = "";

                btn_save.Enabled = true;
                btn_update.Enabled = false;
                btn_clear.Enabled = false;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void nmr_Numarator_ValueChanged(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void nmr_Denominator_ValueChanged(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AddConversion();
        }

        private void kryptonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (kryptonDataGridView1.CurrentRow == null ||
                kryptonDataGridView1.CurrentRow.IsNewRow)
                return;

            UnitConversions conversion =
                kryptonDataGridView1.CurrentRow.DataBoundItem as UnitConversions;

            if (conversion == null) return;

            _selectedConversionId = conversion.Id;

            cmb_unit.SelectedValue = conversion.UnitId;

            txt_unitCode.Text = cmb_unit.SelectedItem is UnitOfMeasure selectedUnit
                ? selectedUnit.UnitCode
                : "";

            txt_dimensionsName.Text = conversion.DimensionName ?? "";
            txt_baseUnitName.Text = conversion.BaseUnitName ?? "";

            nmr_Numarator.Value = conversion.Numerator;
            nmr_Denominator.Value = conversion.Denominator;

            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_clear.Enabled = true;

            UpdateInfo();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UpdateConversion();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
