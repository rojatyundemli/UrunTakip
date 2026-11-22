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
    public partial class FormSalesOrders : Form
    {
        public FormSalesOrders()
        {
            InitializeComponent();
            ClearBox();
            loadCustomers();
            loadProducts();
            LoadSalesOrders();


            btn_clearbox.Enabled = false;
            btn_SavePurchase.Enabled = true;
            btn_updatePurchaseOrder.Enabled =false ;
        }

        private void FormSalesOrders_Load(object sender, EventArgs e)
        {
            loadCustomers();
        }
        public void loadCustomers()
        {
            try
            {
                CustomerService service = new CustomerService();

                cmb_Customer.DataSource = null;


                cmb_Customer.DisplayMember = "CustomerName";
                cmb_Customer.ValueMember = "Id";

                cmb_Customer.DataSource = service.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler yüklenirken hata oluştu: " + ex.Message);
            }
        }


        public void LoadSalesOrders()

        {
            try
            {
                SalesOrderService service = new SalesOrderService();
                dgv_purchaseOrderList.DataSource = null;
                dgv_purchaseOrderList.DataSource = service.GetAllSalesOrders();

                dgv_purchaseOrderList.Columns["CustomerId"].Visible = false;


                dgv_purchaseOrderList.Columns["CustomerName"].HeaderText = "Müşteri Adı";
                dgv_purchaseOrderList.Columns["OrderDate"].HeaderText = "Sipariş Tarihi";
                dgv_purchaseOrderList.Columns["Status"].HeaderText = "Durum";
                dgv_purchaseOrderList.Columns["Description"].HeaderText = "Açıklama";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış siparişleri yüklenirken hata oluştu: " + ex.Message);
            }
        }
        public void LoadSalesOrderDetails(int salesOrderId)
        {
            try
            {
                SalesOrderService service = new SalesOrderService();
                dgv_purchaseOrderDetailList.DataSource = null;
                dgv_purchaseOrderDetailList.DataSource = service.GetSalesOrderDetailsByOrderId(salesOrderId);


                dgv_purchaseOrderDetailList.Columns["ProductId"].Visible = false;
                dgv_purchaseOrderDetailList.Columns["SalesOrderId"].Visible = false;

                dgv_purchaseOrderDetailList.Columns["ProductName"].HeaderText = "Ürün Adı";
                dgv_purchaseOrderDetailList.Columns["ShippedQuantity"].HeaderText = "Gönderilen Miktar";
                dgv_purchaseOrderDetailList.Columns["UnitPrice"].HeaderText = "Tane Fiyatı";
                dgv_purchaseOrderDetailList.Columns["Quantity"].HeaderText = "Miktar";
                dgv_purchaseOrderDetailList.Columns["LineTotal"].HeaderText = "Satır Toplamı";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış siparişi detayları yüklenirken hata oluştu: " + ex.Message);
            }
        }
        public void fillbox()
        {
            if (dgv_purchaseOrderList.CurrentRow == null) return;

            SalesOrder salesOrder = dgv_purchaseOrderList.CurrentRow.DataBoundItem as SalesOrder;

            if (salesOrder == null) return;

            cmb_Customer.SelectedValue = salesOrder.CustomerId;
            txt_description.Text = salesOrder.Description;
            dtp_OrderDate.Value = salesOrder.OrderDate;


            dgv_PurchaseProductList.Rows.Clear();

            foreach (DataGridViewRow row in dgv_purchaseOrderDetailList.Rows)
            {
                if (row.IsNewRow)
                    continue;

                SalesOrderDetail detail = row.DataBoundItem as SalesOrderDetail;

                if (detail == null)
                    continue;

                dgv_PurchaseProductList.Rows.Add(
                    detail.ProductId,
                    detail.ProductName,
                    detail.Quantity,
                    detail.UnitPrice,
                    detail.LineTotal
                );
            }


        }
        public void loadProducts()
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
                MessageBox.Show("Müşteriler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        public void AddProductToGrid()
        {
            if (cmb_Product.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                return;
            }
            if (nmrc_Quantity.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }


            int ProductId = Convert.ToInt32(cmb_Product.SelectedValue);
            String ProductName = cmb_Product.Text;
            int Quantity = Convert.ToInt32(nmrc_Quantity.Value);
            decimal UnitPrice = Convert.ToDecimal(nmrc_UnitPurchasePrice.Value);
            decimal LineTotal = Quantity * UnitPrice;

            dgv_PurchaseProductList.Rows.Add(ProductId, ProductName, Quantity, UnitPrice, LineTotal);
            nmrc_UnitPurchasePrice.Value = 0;
            nmrc_Quantity.Value = 0;
        }
        public void ClearBox() 
        {
            dgv_purchaseOrderDetailList.ClearSelection();
            dgv_purchaseOrderList.ClearSelection();
            cmb_Customer.SelectedIndex = -1;
            cmb_Product.SelectedIndex = -1;
            txt_GrandTotal.Clear();
            txt_totalProductCount.Clear();
            txt_description.Clear();
            nmrc_Quantity.Value = 0;
            nmrc_UnitPurchasePrice.Value = 0;
            dgv_PurchaseProductList.Rows.Clear();

            btn_clearbox.Enabled = false;
            btn_SavePurchase.Enabled = true;
            btn_updatePurchaseOrder.Enabled = false;
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            AddProductToGrid();
            CalculatePurchaseTotals();
        }

        private void btn_SavePurchase_Click(object sender, EventArgs e)
        {



            if (cmb_Customer.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir müşteri seçin.");
                return;
            }

            if (dgv_PurchaseProductList.Rows.Count == 0)
            {
                MessageBox.Show("Sipariş Kaydına Eklenecek Ürün Bulunamadı. Lütfen ürün seçin");
                return;
            }

            SalesOrder salesOrder = new SalesOrder();

            salesOrder.CustomerId = Convert.ToInt32(cmb_Customer.SelectedValue);
            salesOrder.OrderDate = dtp_OrderDate.Value;
            salesOrder.Description = txt_description.Text;



            foreach (DataGridViewRow row in dgv_PurchaseProductList.Rows)
            {

                SalesOrderDetail salesOrderDetail = new SalesOrderDetail();
                if (row.IsNewRow)
                {
                    continue;

                }

                salesOrderDetail.ProductId = Convert.ToInt32(row.Cells["ColProductId"].Value);
                salesOrderDetail.Quantity = Convert.ToInt32(row.Cells["ColQuantity"].Value);
                salesOrderDetail.UnitPrice = Convert.ToDecimal(row.Cells["ColUnitPrice"].Value);


                salesOrder.Details.Add(salesOrderDetail);

            }


            SalesOrderService service = new SalesOrderService();
            String result = service.AddSalesOrder(salesOrder);
            MessageBox.Show(result);

            LoadSalesOrders();

            ClearBox();



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

        private void dgv_purchaseOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_PurchaseOrderList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_purchaseOrderList.CurrentRow == null)
                    return;

                // Seçilen satırın bağlı olduğu PurchaseOrder nesnesini al
                SalesOrder selectedOrder = dgv_purchaseOrderList.CurrentRow.DataBoundItem as SalesOrder;

                if (selectedOrder == null)
                    return;

                int salesOrderId = selectedOrder.Id;

                LoadSalesOrderDetails(salesOrderId);
                fillbox();

                btn_clearbox.Enabled = true;
                btn_SavePurchase.Enabled = false;
                btn_updatePurchaseOrder.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış siparişi detayları yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btn_clearbox_Click(object sender, EventArgs e)
        {
           ClearBox();

        }
    }
}
