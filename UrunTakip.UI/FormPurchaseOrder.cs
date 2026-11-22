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
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class FormPurchaseOrder : Form
    {

        private bool _isLoadingPurchaseOrders = false;

        public FormPurchaseOrder()
        {
            InitializeComponent();
        }

        private void FormPurchaseOrder_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
            LoadProductData();
            ListPurchaseOrders();
            
        }

        public void LoadSupplierData()
        {
            try
            {
                SupplierService service = new SupplierService();

                cmb_supplierlist.DataSource = null;
                cmb_supplierlist.DataSource = service.GetAllSuppliers();

                cmb_supplierlist.DisplayMember = "SupplierName";
                cmb_supplierlist.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tedarikçiler yüklenirken hata oluştu: " + ex.Message);
            }
        }
        public void LoadProductData()
        {
            try
            {
                ProductService service = new ProductService();

                cmb_Product.DataSource = null;
                cmb_Product.DataSource = service.GetAllProducts();

                cmb_Product.DisplayMember = "Name";
                cmb_Product.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tedarikçiler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btn_SavePurchase_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_PurchaseProductList.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
                {
                    MessageBox.Show("Lütfen önce siparişe ürün ekleyin.");
                    return;
                }
                PurchaseOrder purchaseOrder = new PurchaseOrder();

                purchaseOrder.SupplierId = (int)cmb_supplierlist.SelectedValue;
                purchaseOrder.OrderDate = dtp_OrderDate.Value;
                purchaseOrder.Description = txt_description.Text;


                foreach (DataGridViewRow row in dgv_PurchaseProductList.Rows)
                {
                    // DataGridView'in boş olan yeni satırını atla
                    if (row.IsNewRow)
                        continue;

                    PurchaseOrderDetail detail = new PurchaseOrderDetail
                    {
                        ProductId = Convert.ToInt32(row.Cells["colProductId"].Value),
                        Quantity = Convert.ToInt32(row.Cells["colQuantity"].Value),
                        UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value)
                    };

                    purchaseOrder.Details.Add(detail);
                }

                PurchaseOrderService service = new PurchaseOrderService();
                string result = service.AddPurchaseOrder(purchaseOrder);
                MessageBox.Show(result);

                dgv_PurchaseProductList.Rows.Clear();
                txt_description.Clear();
                txt_GrandTotal.Clear();
                txt_totalProductCount.Clear();
                nmrc_Quantity.Value = 0;
                nmrc_UnitPurchasePrice.Value = 0;

                ListPurchaseOrders();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş kaydedilirken hata oluştu: " + ex.Message);
            }
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            if (cmb_Product.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                return;
            }

            int productId = Convert.ToInt32(cmb_Product.SelectedValue);
            string productName = cmb_Product.Text;

            int quantity = (int)nmrc_Quantity.Value;
            decimal unitPrice = nmrc_UnitPurchasePrice.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Miktar sıfırdan büyük olmalıdır.");
                return;
            }

            if (unitPrice < 0)
            {
                MessageBox.Show("Birim fiyat negatif olamaz.");
                return;
            }

            decimal lineTotal = quantity * unitPrice;

            dgv_PurchaseProductList.Rows.Add(
                productId,
                productName,
                quantity,
                unitPrice,
                lineTotal
            );
            CalculatePurchaseTotals();
           



            nmrc_Quantity.Value = 0;
            nmrc_UnitPurchasePrice.Value = 0;
        }

        private void btn_deleteProduct_Click(object sender, EventArgs e)
        {
            // Seçili bir satır var mı kontrol ediyoruz
            if (dgv_PurchaseProductList.SelectedRows.Count > 0)
            {
                // Seçili olan ilk satırı siler
                dgv_PurchaseProductList.Rows.Remove(dgv_PurchaseProductList.SelectedRows[0]);
                CalculatePurchaseTotals();
                
            }
            else
            {
                MessageBox.Show("Lütfen silmek için önce bir satır seçin");
            }
        }


        public void ListPurchaseOrders()
        {
            try
            {
                PurchaseOrderService service =
                    new PurchaseOrderService();

                _isLoadingPurchaseOrders = true;

                dgv_purchaseOrderList.DataSource = null;

                dgv_purchaseOrderList.DataSource =
                    service.GetAllPurchaseOrders();

                // Sütun başlıkları
                if (dgv_purchaseOrderList.Columns.Contains("Id"))
                    dgv_purchaseOrderList.Columns["Id"].HeaderText = "Sipariş No";

                if (dgv_purchaseOrderList.Columns.Contains("SupplierId"))
                    dgv_purchaseOrderList.Columns["SupplierId"].HeaderText = "Tedarikçi No";

                if (dgv_purchaseOrderList.Columns.Contains("OrderDate"))
                    dgv_purchaseOrderList.Columns["OrderDate"].HeaderText = "Sipariş Tarihi";

                if (dgv_purchaseOrderList.Columns.Contains("Status"))
                    dgv_purchaseOrderList.Columns["Status"].HeaderText = "Durum";

                if (dgv_purchaseOrderList.Columns.Contains("Description"))
                    dgv_purchaseOrderList.Columns["Description"].HeaderText = "Açıklama";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Siparişler listelenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                _isLoadingPurchaseOrders = false;
            }

            // İlk siparişi seç ve bilgilerini forma yükle
            if (dgv_purchaseOrderList.Rows.Count > 0 &&
                dgv_purchaseOrderList.Columns.Count > 0)
            {
                dgv_purchaseOrderList.CurrentCell =
                    dgv_purchaseOrderList.Rows[0].Cells[0];

                dgv_purchaseOrderList.Rows[0].Selected = true;

                dgv_purchaseOrderList_SelectionChanged(
                    dgv_purchaseOrderList, EventArgs.Empty);
            }
        }

        public void ListPurchaseOrderDetails(int purchaseOrderId)
        {
            try
            {
                PurchaseOrderService service = new PurchaseOrderService();
                dgv_purchaseOrderDetailList.DataSource = null;
                dgv_purchaseOrderDetailList.DataSource = service.GetPurchaseOrderDetails(purchaseOrderId);
                // Sütun başlıklarını Türkçeleştir
                dgv_purchaseOrderDetailList.Columns["ProductId"].HeaderText = "Ürün No";
               
                dgv_purchaseOrderDetailList.Columns["ReceivedQuantity"].HeaderText = "Teslim Alınan Miktar";
                dgv_purchaseOrderDetailList.Columns["CurrentlyReceivedQuantity"].HeaderText = "Teslim Alınacak Miktar";

                dgv_purchaseOrderDetailList.Columns["Quantity"].HeaderText = "Miktar";
                dgv_purchaseOrderDetailList.Columns["UnitPrice"].HeaderText = "Birim Fiyat";


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sipariş detayları listelenirken hata oluştu: " + ex.Message);
            }
        }





        private void CalculatePurchaseTotals()
        {
            decimal grandTotal = 0;
            int totalProductCount = 0;

            foreach (DataGridViewRow row in dgv_PurchaseProductList.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colQuantity"].Value == null ||
                    row.Cells["colLineTotal"].Value == null)
                    continue;

                int quantity = Convert.ToInt32(
                    row.Cells["colQuantity"].Value);

                decimal lineTotal = Convert.ToDecimal(
                    row.Cells["colLineTotal"].Value);

                grandTotal += lineTotal;
                totalProductCount += quantity;
            }

            txt_GrandTotal.Text = grandTotal.ToString("N2");
            txt_GrandTotal.Text = grandTotal.ToString("N2");
            txt_totalProductCount.Text = totalProductCount.ToString();
        }

        private void dgv_purchaseOrderList_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadingPurchaseOrders)
                return;

            try
            {
                if (dgv_purchaseOrderList.CurrentRow == null)
                    return;

                // Seçilen satırın bağlı olduğu PurchaseOrder nesnesini al
                PurchaseOrder selectedOrder = dgv_purchaseOrderList.CurrentRow.DataBoundItem as PurchaseOrder;

                if (selectedOrder == null)
                    return;

                // Tedarikçi
                cmb_supplierlist.SelectedValue =selectedOrder.SupplierId;

                // Sipariş tarihi
                dtp_OrderDate.Value = selectedOrder.OrderDate;

                // Açıklama
                txt_description.Text = selectedOrder.Description ?? "";

                // Ürünleri sol taraftaki tabloya yükle
                LoadProductsToPurchaseGrid(selectedOrder.Id);

                // Sağ alttaki detay tablosunu yükle
                ListPurchaseOrderDetails(selectedOrder.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sipariş bilgileri yüklenemedi: " + ex.Message);
            }
        }

        private void dgv_purchaseOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_purchaseOrderList.CurrentCell != null && dgv_purchaseOrderList.CurrentRow.Cells[0].Value != null)
            {
                int purchaseOrderId = Convert.ToInt32(dgv_purchaseOrderList.CurrentRow.Cells[0].Value);
                ListPurchaseOrderDetails(purchaseOrderId);
            }
        }

        private void btn_updatePurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Önce seçili sipariş var mı kontrol et
                if (dgv_purchaseOrderList.CurrentRow == null ||
                    dgv_purchaseOrderList.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Lütfen güncellemek için bir sipariş seçin.");
                    return;
                }

                // 2. Tedarikçi kontrolü
                if (cmb_supplierlist.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir tedarikçi seçin.");
                    return;
                }

                // 3. Seçilen siparişin ID değerini al
                int purchaseOrderId = Convert.ToInt32(
                    dgv_purchaseOrderList.CurrentRow.Cells["Id"].Value
                );

                // 4. Sipariş nesnesini oluştur
                PurchaseOrder purchaseOrder = new PurchaseOrder
                {
                    Id = purchaseOrderId,
                    SupplierId = Convert.ToInt32(cmb_supplierlist.SelectedValue),
                    OrderDate = dtp_OrderDate.Value,
                    Description = txt_description.Text
                };

                // 5. DataGridView içerisindeki ürünleri al
                var rows = dgv_PurchaseProductList.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => !row.IsNewRow)
                    .ToList();

                if (rows.Count == 0)
                {
                    MessageBox.Show("Siparişte en az bir ürün bulunmalıdır.");
                    return;
                }

                foreach (DataGridViewRow row in rows)
                {
                    if (row.Cells["colProductId"].Value == null ||
                        row.Cells["colQuantity"].Value == null ||
                        row.Cells["colUnitPrice"].Value == null)
                    {
                        MessageBox.Show("Ürün bilgilerinde eksik alan var.");
                        return;
                    }

                    PurchaseOrderDetail detail = new PurchaseOrderDetail
                    {
                        ProductId = Convert.ToInt32(
                            row.Cells["colProductId"].Value),

                        Quantity = Convert.ToInt32(
                            row.Cells["colQuantity"].Value),

                        UnitPrice = Convert.ToDecimal(
                            row.Cells["colUnitPrice"].Value)
                    };

                    purchaseOrder.Details.Add(detail);
                }

                // 6. Business katmanına gönder
                PurchaseOrderService service = new PurchaseOrderService();

                bool result = service.UpdatePurchaseOrder(purchaseOrder);

                if (result)
                {
                    MessageBox.Show("Sipariş başarıyla güncellendi.");

                    // Sipariş listesini yenile
                    ListPurchaseOrders();

                    // Güncellenen siparişin detaylarını yeniden getir
                    ListPurchaseOrderDetails(purchaseOrderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sipariş güncellenirken hata oluştu: " + ex.Message
                );
            }
        }

        private void LoadProductsToPurchaseGrid(int purchaseOrderId)
        {
            PurchaseOrderService orderService = new PurchaseOrderService();
            ProductService productService = new ProductService();

            var details = orderService.GetPurchaseOrderDetails(purchaseOrderId);
            var products = productService.GetAllProducts();

            dgv_PurchaseProductList.Rows.Clear();

            foreach (var detail in details)
            {
                var product = products.FirstOrDefault(
                    x => x.Id == detail.ProductId);

                if (product == null)
                    continue;

                decimal lineTotal = detail.Quantity * detail.UnitPrice;

                dgv_PurchaseProductList.Rows.Add(
                    detail.ProductId,
                    product.Name,
                    detail.Quantity,
                    detail.UnitPrice,
                    lineTotal
                );
            }

            CalculatePurchaseTotals();
        }
    }
}
