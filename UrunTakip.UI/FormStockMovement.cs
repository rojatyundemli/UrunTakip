using System;
using System.Windows.Forms;
using System.Xml.Linq;
using UrunTakip.Business;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class FormStockMovement : Form
    {
        public FormStockMovement()
        {
            InitializeComponent();
        }

        private void FormStockMovement_Load(object sender, EventArgs e)
        {

            cmbType.DisplayMember = "Key";
            cmbType.ValueMember = "Value";

            cmbType.DataSource = new[]
            {
            new KeyValuePair<string, string>("Stok Girişi", "IN"),
             new KeyValuePair<string, string>("Stok Çıkışı", "OUT")
            };

            cmbProductName.Text = "";
            cmbType.Text = "";
            txtDesc.Text = "";
            nmrcQuantity.Value = 0;

            btnDelete.Visible = false;
            btnUpdate.Visible = false;

            Fill_cmbProductName();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProductName.SelectedValue == null ||
                cmbType.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ürün ve hareket türü seçin.");
                return;
            }

            if (nmrcQuantity.Value <= 0)
            {
                MessageBox.Show("Miktar sıfırdan büyük olmalıdır.");
                return;
            }

            try
            {
                StockMovement movement = new StockMovement();

                // Seçilen ürünün gerçek ID değerini al
                movement.ProductId =
                    Convert.ToInt32(cmbProductName.SelectedValue);

                // IN veya OUT değerini al
                movement.MovementType =
                    cmbType.SelectedValue.ToString();

                movement.Description = txtDesc.Text.Trim();
                movement.Quantity = (int)nmrcQuantity.Value;
                movement.CreatedAt = DateTime.Now;

                StockMovementService service = new StockMovementService();

                // Service metodunun döndürdüğü mesajı göster
                string result = service.AddStockMovement(movement);

                MessageBox.Show(result, "Stok Hareketi");

                // Yalnızca başarılı kayıt sonrasında alanları temizle
                if (result == "Stok hareketi başarıyla eklendi.")
                {
                    txtDesc.Clear();
                    nmrcQuantity.Value = 0;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Stok hareketi kaydedilirken hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }




        private void Fill_cmbProductName()
        {
            try
            {
                ProductService service = new ProductService();

                cmbProductName.DataSource = null;
                cmbProductName.DataSource = service.GetAllProducts();

                cmbProductName.DisplayMember = "Name";
                cmbProductName.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message);
            }

        }

        private void btn_getProductMovement_Click(object sender, EventArgs e)
        {
            try
            {
                StockMovementService service = new StockMovementService();
                dg_productMovementList.DataSource = null;
                dg_productMovementList.DataSource = service.GetAllStockMovements();


                dg_productMovementList.Columns["ProductId"].HeaderText = "Ürün Adı";
                dg_productMovementList.Columns["MovementType"].HeaderText = "Hareket Tipi";
                dg_productMovementList.Columns["Description"].HeaderText = "Açıklama";
                dg_productMovementList.Columns["Quantity"].HeaderText = "Miktar";
                dg_productMovementList.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                dg_productMovementList.Columns["Id"].HeaderText = "Hareket ID";



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);

            }
        }

        private void dg_productMovementList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dg_productMovementList.Rows[e.RowIndex];

                if (row.DataBoundItem is not StockMovement movement)
                    return;

                // Ürün ComboBox'ının veri kaynağını hazırla
                if (cmbProductName.DataSource == null)
                    Fill_cmbProductName();

                btnDelete.Visible = true;
                btnUpdate.Visible = true;

                txt_movementId.Text = movement.Id.ToString();
                txtDesc.Text = movement.Description ?? "";

                // Önce ProductId değerinin ComboBox'ta bulunduğunu kontrol et
                bool productExists = false;

                foreach (var item in cmbProductName.Items)
                {
                    if (item is Product product &&
                        product.Id == movement.ProductId)
                    {
                        productExists = true;
                        break;
                    }
                }

                if (productExists)
                {
                    cmbProductName.SelectedValue = movement.ProductId;
                }
                else
                {
                    MessageBox.Show(
                        "Bu stok hareketine ait ürün ComboBox listesinde bulunamadı.");
                }

                // Hareket türünü seç
                cmbType.SelectedValue = movement.MovementType;

                nmrcQuantity.Value = Math.Max(
                    nmrcQuantity.Minimum,
                    Math.Min(nmrcQuantity.Maximum, movement.Quantity));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hareket bilgileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_movementId.Text, out int movementId))
            {
                MessageBox.Show("Lütfen güncellenecek hareketi listeden seçin.");
                return;
            }

            if (cmbProductName.SelectedValue == null ||
                cmbType.SelectedValue == null)
            {
                MessageBox.Show("Ürün ve hareket türü seçilmelidir.");
                return;
            }

            if (nmrcQuantity.Value <= 0)
            {
                MessageBox.Show("Miktar sıfırdan büyük olmalıdır.");
                return;
            }

            try
            {
                StockMovement movement = new StockMovement
                {
                    Id = movementId,

                    // Seçili ürünün ID'sini gönder
                    ProductId = Convert.ToInt32(cmbProductName.SelectedValue),

                    // ComboBox'ın ValueMember değeri IN veya OUT
                    MovementType = cmbType.SelectedValue.ToString(),

                    Quantity = (int)nmrcQuantity.Value,
                    Description = txtDesc.Text.Trim()
                };

                StockMovementService service = new StockMovementService();

                // Servisin sonucunu mutlaka al
                string result = service.UpdateStockMovement(movement);

                MessageBox.Show(result,"Stok Hareketi",MessageBoxButtons.OK,result == "Stok hareketi başarıyla güncellendi."? MessageBoxIcon.Information: MessageBoxIcon.Warning);

                // Başarılıysa listeyi yenile
                if (result == "Stok hareketi başarıyla güncellendi.")
                {
                    btn_getProductMovement_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hareket güncellenirken hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_movementId.Text, out int movementId)
                || movementId <= 0)
            {
                MessageBox.Show("Lütfen silinecek hareketi listeden seçin.");
                return;
            }

            DialogResult confirmation = MessageBox.Show("Seçilen stok hareketini silmek istediğine emin misin?", "Silme Onayı", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            try
            {
                StockMovementService service = new StockMovementService();
                StockMovement movement = new StockMovement();

                movement.Id =Convert.ToInt32(txt_movementId.Text);
                movement.ProductId = Convert.ToInt32(cmbProductName.SelectedValue);
                movement.MovementType = cmbType.SelectedValue.ToString();
                movement.Quantity = Convert.ToInt32(nmrcQuantity.Value);

              

               String result = service.DeleteStockMovement(movement);

                MessageBox.Show(result, "Stok Hareketi", MessageBoxButtons.OK, result == "Stok hareketi başarıyla Silindi." ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if(result == "Stok hareketi başarıyla Silindi.") 
                {
                    btn_getProductMovement_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hareket silinirken hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}