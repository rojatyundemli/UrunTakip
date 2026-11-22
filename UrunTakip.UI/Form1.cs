
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using UrunTakip.Business;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FillcomboboxUpCategory();
            FillComboboxUnitName();
            ListProducts();
            Clear();
        }


        public void ListProducts()
        {
            try
            {
                ProductService service = new ProductService();

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = service.GetAllProducts();

                // Sütun baþlýklarýný Türkçeleþtir
                dgvProducts.Columns["Id"].HeaderText = "Ürün No";
                dgvProducts.Columns["Name"].HeaderText = "Ürün Adý";
                dgvProducts.Columns["Price"].HeaderText = "Fiyat";
                dgvProducts.Columns["Stock"].HeaderText = "Stok";
                dgvProducts.Columns["ProductCode"].HeaderText = "Ürün Kodu";
                dgvProducts.Columns["PurchasePrice"].HeaderText = "Maliyet Fiyatý";
                dgvProducts.Columns["Category"].HeaderText = "Kategori";
                dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                dgvProducts.Columns["MinStock"].HeaderText = "Minimum Stok";
                dgvProducts.Columns["MaxStock"].HeaderText = "Maksimum Stok";
                dgvProducts.Columns["Descraption"].HeaderText = "Açýklama";

                // Fiyatý iki ondalýk basamakla göster
                dgvProducts.Columns["Price"]
                    .DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ürünler listelenirken hata oluþtu: " + ex.Message);
            }

        }
        public void FillComboboxUnitName()
        {
            UnitOfMeasureService service = new UnitOfMeasureService();

            var units = service.GetActiveBaseUnits();

            units.Insert(0, new UnitOfMeasure
            {
                Id = 0,
                UnitName = "Bir Ölçü Birimi Seçin",
                UnitCode = ""
            });

            cmb_unitname.DataSource = null;

            cmb_unitname.DisplayMember = "UnitName";
            cmb_unitname.ValueMember = "Id";

            cmb_unitname.DataSource = units;

            cmb_unitname.SelectedIndex = 0;
        }

        public void FillcomboboxUpCategory()
        {
            CategoryService service = new CategoryService();
            var categories = service.GetCategories();

            // En baþa eklenecek varsayýlan seçenek
            var defaultCategory = new Category
            {
                Id = 0,
                Name = "-- YOK --"
            };

            // Listemizin en baþýna ekliyoruz 
            categories.Insert(0, defaultCategory);

            cmb_category.DataSource = null;
            cmb_category.DataSource = categories;

            cmb_category.DisplayMember = "Name";
            cmb_category.ValueMember = "Id";


            cmb_category.SelectedIndex = 0;




        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProductService service = new ProductService();
                String text = textBox1.Text.Trim();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = service.SearchProducts(text);

                // Sütun baþlýklarýný Türkçeleþtir
                // Sütun baþlýklarýný Türkçeleþtir
                dgvProducts.Columns["Id"].HeaderText = "Ürün No";
                dgvProducts.Columns["Name"].HeaderText = "Ürün Adý";
                dgvProducts.Columns["Price"].HeaderText = "Fiyat";
                dgvProducts.Columns["Stock"].HeaderText = "Stok";
                dgvProducts.Columns["ProductCode"].HeaderText = "Ürün Kodu";
                dgvProducts.Columns["PurchasePrice"].HeaderText = "Maliyet Fiyatý";
                dgvProducts.Columns["Category"].HeaderText = "Kategori";
                dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                dgvProducts.Columns["MinStock"].HeaderText = "Minimum Stok";
                dgvProducts.Columns["MaxStock"].HeaderText = "Maksimum Stok";
                dgvProducts.Columns["Descraption"].HeaderText = "Açýklama";

                // Fiyatý iki ondalýk basamakla göster
                dgvProducts.Columns["Price"]
                    .DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ürünler listelenirken hata oluþtu: " + ex.Message);
            }

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }



        public void Save()
        {
            string productName = txtName.Text.Trim();
            UnitOfMeasure selectedUnit = cmb_unitname.SelectedItem as UnitOfMeasure;

            // Fiyatý string türünden decimal türüne çevir.
            if (!decimal.TryParse(nmr_Price.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal productPrice))
            {
                MessageBox.Show("Geçerli bir fiyat gir. Örnek: 750,50");
                nmr_Price.Focus();
                return;
                FillcomboboxUpCategory();
            }

            if (selectedUnit == null || selectedUnit.Id == 0)
            {
                MessageBox.Show("Lütfen ana birim seçin.");
                return;
            }

            int mainUnitId = selectedUnit.Id;

            string mainUnitName = selectedUnit.UnitName;

            Category selectedCategory = cmb_category.SelectedItem as Category;

            string? categoryName = selectedCategory == null || selectedCategory.Id == 0 ? null : selectedCategory.Name;

            // Product nesnesini oluþtur.
            Product product = new Product();

            product.Name = productName;
            product.Price = productPrice;
            product.Stock = nmrc_Stock.Value;
            product.MinStock = nmrc_minStock.Value;
            product.MaxStock = nmrc_maxStock.Value;
            product.ProductCode = txt_productCode.Text;
            product.PurchasePrice = nmrc_PurchasePrice.Value;
            product.MainUnitName = mainUnitName;
            product.MainUnitId = mainUnitId;
            product.Category = categoryName;
            product.Barcode = txt_Barcode.Text;
            product.Descraption = txt_Descrabtion.Text;




            // Business katmanýna gönder.
            ProductService service = new ProductService();

            string result = service.AddProduct(product);

            MessageBox.Show(result);

            FillcomboboxUpCategory();

            ListProducts();
           
            Clear();
        }
        public void Update()
        {
            // Seçili ürünü bul
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek ürünü seçin.");
                return;
            }

            Product selectedProduct =
                dgvProducts.CurrentRow.DataBoundItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Ürün bilgisi alýnamadý.");
                return;
            }

            // Ölçü birimi kontrolü
            UnitOfMeasure selectedUnit =
                cmb_unitname.SelectedItem as UnitOfMeasure;

            if (selectedUnit == null || selectedUnit.Id == 0)
            {
                MessageBox.Show("Lütfen ana birim seçin.");
                return;
            }

            // Kategori kontrolü
            Category selectedCategory =
                cmb_category.SelectedItem as Category;

            string? categoryName =
                selectedCategory == null || selectedCategory.Id == 0
                ? null
                : selectedCategory.Name;

            // Product nesnesini oluþtur
            Product product = new Product();

            product.Id = selectedProduct.Id;

            product.Name = txtName.Text.Trim();
            product.Price = nmr_Price.Value;
            product.Stock = nmrc_Stock.Value;
            product.PurchasePrice = nmrc_PurchasePrice.Value;

            product.MinStock = nmrc_minStock.Value;
            product.MaxStock = nmrc_maxStock.Value;

            product.ProductCode = txt_productCode.Text.Trim();

            product.MainUnitId = selectedUnit.Id;
            product.MainUnitName = selectedUnit.UnitName;

            product.Category = categoryName;

            product.Barcode = txt_Barcode.Text.Trim();
            product.Descraption = txt_Descrabtion.Text.Trim();

            // Business katmanýna gönder
            ProductService service = new ProductService();

            string resultMessage =
                service.UpdateProductServise(product);

            MessageBox.Show(resultMessage);

            // Listeyi yenile
            ListProducts();

            // Formu temizle
            Clear();
        }

        public void Clear()
        {
            isClearing = true;

            try
            {
                // TEXTBOX
                txtName.Clear();
                txt_Barcode.Clear();
                txt_Descrabtion.Clear();
                txt_productCode.Clear();

                // NUMERICUPDOWN
                nmr_Price.Value = 0;
                nmrc_Stock.Value = 0;
                nmrc_PurchasePrice.Value = 0;
                nmrc_minStock.Value = 0;
                nmrc_maxStock.Value = 0;

                // COMBOBOX
                if (cmb_category.Items.Count > 0)
                    cmb_category.SelectedIndex = 0;

                if (cmb_unitname.Items.Count > 0)
                    cmb_unitname.SelectedIndex = 0;

                // DATAGRIDVIEW SEÇÝMÝNÝ KALDIR
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    row.Selected = false;
                }

                dgvProducts.ClearSelection();
                dgvProducts.CurrentCell = null;

                // BUTONLAR
                btn_Updatee.Enabled = false;
                btn_cleare.Enabled = false;
                btn_Savee.Enabled = true;
            }
            finally
            {
                isClearing = false;
            }
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoryManager formCategory = new FormCategoryManager();


            formCategory.Show(this);
        }

        private void ölçüTürleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDimensions formDimensions = new FormDimensions();
            formDimensions.Show(this);
        }

        private void ölçüBirimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnitsOfMeasure formUnitsOfMeasure = new FormUnitsOfMeasure();
            formUnitsOfMeasure.Show(this);

        }

        private void birimDönüþümleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnitConversions formUnitConversions = new FormUnitConversions();
            formUnitConversions.Show(this);
        }

        private void ürünBirimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductUnit formProductUnit = new FormProductUnit();
            formProductUnit.Show(this);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            Save();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
          
        }

        private void cmb_category_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cmb_unitname_DropDown(object sender, EventArgs e)
        {
        }


        private bool isClearing = false;

        private decimal SetNumericValue(
     Krypton.Toolkit.KryptonNumericUpDown control,
     decimal value)
        {
            return Math.Max(control.Minimum,
                   Math.Min(control.Maximum, value));
        }
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (isClearing)
                return;

            if (dgvProducts.CurrentRow == null ||
                dgvProducts.CurrentRow.IsNewRow)
                return;

            Product product = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (product == null)
                return;

            // TEXTBOX
            txtName.Text = product.Name ?? "";
            txt_productCode.Text = product.ProductCode ?? "";
            txt_Barcode.Text = product.Barcode ?? "";
            txt_Descrabtion.Text = product.Descraption ?? "";

            // NUMERICUPDOWN
            nmr_Price.Value = SetNumericValue(nmr_Price, product.Price);

            nmrc_Stock.Value = SetNumericValue(nmrc_Stock, product.Stock);

            nmrc_PurchasePrice.Value =
                SetNumericValue(nmrc_PurchasePrice, product.PurchasePrice);

            nmrc_minStock.Value =
                SetNumericValue(nmrc_minStock, product.MinStock);

            nmrc_maxStock.Value =
                SetNumericValue(nmrc_maxStock, product.MaxStock);

            // KATEGORÝ
            string productCategory = (product.Category ?? "").Trim();

            cmb_category.SelectedIndex = 0;

            for (int i = 0; i < cmb_category.Items.Count; i++)
            {
                Category category = cmb_category.Items[i] as Category;

                if (category != null &&
                    category.Id != 0 &&
                    string.Equals(
                        category.Name?.Trim(),
                        productCategory,
                        StringComparison.OrdinalIgnoreCase))
                {
                    cmb_category.SelectedIndex = i;
                    break;
                }
            }

            // KATEGORÝ
            foreach (Category category in cmb_category.Items)
            {
                if (category.Id != 0 &&
                    category.Name == product.Category)
                {
                    cmb_category.SelectedItem = category;
                    break;
                }
            }

            // BUTONLAR
            btn_Updatee.Enabled = true;
            btn_cleare.Enabled = true;
            btn_Savee.Enabled = false;

            // DEBUG: Ürün nesnesindeki gerçek deðerleri kontrol et
            Debug.WriteLine(
                $"Ürün: {product.Name} | " +
                $"Maliyet: {product.PurchasePrice} | " +
                $"Min: {product.MinStock} | " +
                $"Max: {product.MaxStock} | " +
                $"Kategori: {product.Category} | " +
                $"Birim ID: {product.MainUnitId}"
            );
        }
    }
}
