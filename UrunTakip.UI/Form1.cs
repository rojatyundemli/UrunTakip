
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
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void btnUrunKontrol_Click(object sender, EventArgs e)
        {

            string productName = txtName.Text.Trim();

            // Fiyatý string türünden decimal türüne çevir.
            if (!decimal.TryParse(
                    txtPrice.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal productPrice))
            {
                MessageBox.Show("Geçerli bir fiyat gir. Örnek: 750,50");
                txtPrice.Focus();
                return;
            }

            // Stoku string türünden int türüne çevir.
            if (!int.TryParse(
                    txtStock.Text.Trim(),
                    out int productStock))
            {
                MessageBox.Show("Stok miktarý tam sayý olmalýdýr.");
                txtStock.Focus();
                return;
            }

            // Product nesnesini oluþtur.
            Product product = new Product();

            product.Name = productName;
            product.Price = productPrice;
            product.Stock = productStock;

            // Business katmanýna gönder.
            ProductService service = new ProductService();

            string result = service.AddProduct(product);

            MessageBox.Show(result);

        }

        private void btnListProduct_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProductService service = new ProductService();
                String text = textBox1.Text.Trim();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = service.SearchProducts(text);

                // Sütun baþlýklarýný Türkçeleþtir
                dgvProducts.Columns["Id"].HeaderText = "Ürün No";
                dgvProducts.Columns["Name"].HeaderText = "Ürün Adý";
                dgvProducts.Columns["Price"].HeaderText = "Fiyat";
                dgvProducts.Columns["Stock"].HeaderText = "Stok";

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
            if (dgvProducts.CurrentCell != null && dgvProducts.CurrentRow.Cells[0].Value != null)

            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;




                String Name = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                decimal Price = Convert.ToDecimal(dgvProducts.CurrentRow.Cells[2].Value);
                int Stock = Convert.ToInt32(dgvProducts.CurrentRow.Cells[3].Value);

                txtName.Text = Name;
                txtPrice.Text = Price.ToString("0.00"); // Fiyatý 10.50 gibi düzgün formatta gösterir
                txtStock.Text = Stock.ToString();


            }
            else {
                txtName.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";


                btnUpdate.Visible = false;
                btnDelete.Visible = false;


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvProducts.CurrentCell != null && dgvProducts.CurrentRow.Cells[0].Value != null)
            {



                int Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                String Name = txtName.Text.Trim();
                decimal Price = Convert.ToDecimal(txtPrice.Text.Trim());
                int Stock = Convert.ToInt32(txtStock.Text.Trim());


                Product product = new Product();
                product.Id = Id;
                product.Name = Name;
                product.Price = Price;
                product.Stock = Stock;

                ProductService service = new ProductService();
                String resultMessage = service.UpdateProductServise(product);

                MessageBox.Show(resultMessage);


                txtName.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";


                btnUpdate.Visible = false;
                btnDelete.Visible = false;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvProducts.CurrentCell != null && dgvProducts.CurrentRow.Cells[0].Value != null)
            {


                int Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                

          
                ProductService service = new ProductService();
                String resultMessage = service.DeleteProductService(Id);

                MessageBox.Show(resultMessage);
                btnUpdate.Visible = false;

                txtName.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";

                btnDelete.Visible = false;
                btnUpdate.Visible = false;

            }


        }
    }
}
