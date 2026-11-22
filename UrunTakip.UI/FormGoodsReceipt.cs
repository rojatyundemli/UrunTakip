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
    public partial class FormGoodsReceipt : Form
    {
        public FormGoodsReceipt()
        {
            InitializeComponent();
        }

        private void FormGoodsReceipt_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
            dgv_ReadyOrderDetails.DataSource=null;
        }
        


        public void LoadPurchaseOrders()
        {
            try
            {
                PurchaseOrderService service = new PurchaseOrderService();

                var orders = service.GetAllPurchaseOrders().Where(x => x.Status == "Pending" || x.Status == "PartiallyReceived").Select(x => new { x.Id, DisplayText = $"Sipariş No: {x.Id} - {x.OrderDate:dd.MM.yyyy}" }).ToList();

                cmb_PurchaseOrders.DataSource = null;

                cmb_PurchaseOrders.DisplayMember = "DisplayText";
                cmb_PurchaseOrders.ValueMember = "Id";
                cmb_PurchaseOrders.DataSource = orders;

                cmb_PurchaseOrders.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Siparişler yüklenirken bir hata oluştu: " + ex.Message);
            } 
        }
        public void LoadPurchaseOrderDetails(int purchaseOrderId)
        {
            try
            {
                GoodsRecieptService service = new GoodsRecieptService();
                var details = service.GetPurchaseOrderDetails(purchaseOrderId);
                dgv_orderDetails.DataSource = null;
                dgv_orderDetails.DataSource = details;
                dgv_orderDetails.Columns["Id"].Visible = false;
                dgv_orderDetails.Columns["PurchaseOrderId"].Visible = false;
                dgv_orderDetails.Columns["ProductId"].Visible = false;
                dgv_orderDetails.Columns["ProductName"].HeaderText = "Ürün Adı";
                dgv_orderDetails.Columns["Quantity"].HeaderText = "Miktar";
                dgv_orderDetails.Columns["ReceivedQuantity"].HeaderText = "Alınan Miktar";
                dgv_orderDetails.Columns["RemainingQuantity"].HeaderText = "Kalan Miktar";
                dgv_orderDetails.Columns["UnitPrice"].HeaderText = "Birim Fiyat";
                dgv_orderDetails.Columns["CurrentlyReceivedQuantity"].HeaderText = "Mevcut Alım";
                dgv_orderDetails.Columns["LineTotal"].HeaderText = "Toplam Fiyat";




            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sipariş detayları yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void cmb_PurchaseOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_PurchaseOrders.SelectedIndex == -1)
            {
                dgv_orderDetails.DataSource = null;
                return;
            }
            int selectedOrderId = (int)cmb_PurchaseOrders.SelectedValue;
            String selectedOrderInfo = (String)cmb_PurchaseOrders.Text;
           
            String[] parts = selectedOrderInfo.Split('-');
            if (parts.Length > 1)
            {
                lbl_Supplier.Text = parts[0].Trim();
                lbl_orderDate.Text = parts[1].Trim();
            }

            dgv_ReadyOrderDetails.DataSource = null;
            LoadPurchaseOrderDetails(selectedOrderId);
        }



        private void dgv_orderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            PurchaseOrderDetail selectedDetail = dgv_orderDetails.Rows[e.RowIndex].DataBoundItem as PurchaseOrderDetail;

            if (selectedDetail == null)
                return;
          
            lbl_ProductName.Text = selectedDetail.ProductName;

            // Önce mevcut değeri sıfırla
            nmrc_ReceivedQuantity.Value = 0;

            // Kalan miktarı maksimum değer yap
            nmrc_ReceivedQuantity.Maximum =
                Math.Max(0, selectedDetail.RemainingQuantity);

            // Son olarak değeri ata
            nmrc_ReceivedQuantity.Value =
                nmrc_ReceivedQuantity.Maximum;

            check_ReceviedAll.Checked = false;
            nmrc_ReceivedQuantity.ReadOnly = false;
           
            dgv_ReadyOrderDetails.DataSource = null;
        }

        private void dgv_orderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }




        BindingList<PurchaseOrderDetail> selectedProducts = new BindingList<PurchaseOrderDetail>();
        private void btn_ApplyQuantity_Click(object sender, EventArgs e)
        {

            if (dgv_orderDetails.CurrentRow == null)
            {
                MessageBox.Show("Lütfen önce bir ürün seçin.");
                return;
            }

            PurchaseOrderDetail selectedDetail = dgv_orderDetails.CurrentRow.DataBoundItem as PurchaseOrderDetail;

            if (selectedDetail == null)
                return;

            int receivedQuantity = (int)nmrc_ReceivedQuantity.Value;

            if (receivedQuantity <= 0)
            {
                MessageBox.Show("Teslim alınacak miktar sıfırdan büyük olmalıdır.");
                return;
            }

            if (receivedQuantity > selectedDetail.RemainingQuantity)
            {
                MessageBox.Show("Teslim alınacak miktar kalan miktardan fazla olamaz.");
                return;
            }

            // Seçilen ürünün bu mal kabuldeki miktarını kaydet
            selectedDetail.CurrentlyReceivedQuantity = receivedQuantity;

            // DataGridView'i yeniden çiz
            dgv_orderDetails.Refresh();

            MessageBox.Show(
                selectedDetail.ProductName +
                " için " + receivedQuantity +
                " adet teslimat miktarı uygulandı.");


          
            dgv_ReadyOrderDetails.DataSource = selectedProducts;

            if (dgv_orderDetails.CurrentRow != null)
            {
               

                if (selectedDetail != null)
                {
                    // Listeye eklediğiniz an gridde otomatik görünür
                    selectedProducts.Add(selectedDetail);
                }
            }


        }

        private void check_ReceviedAll_CheckedChanged(object sender, EventArgs e)
        {
          nmrc_ReceivedQuantity.ReadOnly = check_ReceviedAll.Checked;
            if (check_ReceviedAll.Checked)
            {
                if (dgv_orderDetails.CurrentRow != null)
                {
                    PurchaseOrderDetail selectedDetail = dgv_orderDetails.CurrentRow.DataBoundItem as PurchaseOrderDetail;
                    if (selectedDetail != null)
                    {
                        nmrc_ReceivedQuantity.Value = selectedDetail.RemainingQuantity;
                    }
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Sipariş seçilmiş mi?
                if (cmb_PurchaseOrders.SelectedValue is not int purchaseOrderId)
                {
                    MessageBox.Show("Lütfen bir sipariş seçin.");
                    return;
                }

                // 2. Mal kabul nesnesini oluştur
                GoodsReceipt goodsReceipt = new GoodsReceipt
                {
                    PurchaseOrderId = purchaseOrderId,
                    ReceiptDate = dtp_ReceiptDate.Value,
                    Description = txt_Description.Text
                    
                };
              
                MessageBox.Show(goodsReceipt.PurchaseOrderId.ToString() , "Purchase Order ID");
                MessageBox.Show(goodsReceipt.ReceiptDate.ToString() , "Receipt Date");
                MessageBox.Show(goodsReceipt.Description , "Description");

                // 3. DataGridView'deki satırları dolaş
                foreach (DataGridViewRow row in dgv_orderDetails.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    PurchaseOrderDetail detail =
                        row.DataBoundItem as PurchaseOrderDetail;

                    if (detail == null)
                        continue;

                    // Sadece teslim alınacak miktarı girilmiş ürünleri ekle
                    if (detail.CurrentlyReceivedQuantity <= 0)
                        continue;

                    GoodsReceiptDetail receiptDetail =new GoodsReceiptDetail
                    {
                        PurchaseOrderDetailId = detail.Id,
                        QuantityReceived = detail.CurrentlyReceivedQuantity
                    };



                    goodsReceipt.Details.Add(receiptDetail);
                   
                }

                




                // 4. Hiç ürün teslim alınmamışsa kaydetme
                if (goodsReceipt.Details.Count == 0)
                {
                    MessageBox.Show(
                        "Mal kabul için en az bir ürünün miktarını uygulamalısınız.");
                    return;
                }

                // 5. Business katmanına gönder
                GoodsRecieptService service = new GoodsRecieptService();

                bool result = service.AddGoodsReciept(goodsReceipt);
                MessageBox.Show(result.ToString());
                if (result)
                {
                    MessageBox.Show("Mal kabul başarıyla kaydedildi.");
                    dgv_ReadyOrderDetails.DataSource = null;
                    // Ekranı yenile
                    LoadPurchaseOrders();
                    dgv_orderDetails.DataSource = null;

                    lbl_ProductName.Text = "";
                    nmrc_ReceivedQuantity.Value = 0;
                    txt_Description.Clear();
                    check_ReceviedAll.Checked = false;
                }
                else { MessageBox.Show("Mal kabul Kaydedilirken bir hata oluştu."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Mal kabul kaydedilirken hata oluştu: " + ex.Message);
            }
        }
    }
}
