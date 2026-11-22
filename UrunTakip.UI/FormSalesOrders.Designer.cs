namespace UrunTakip.UI
{
    partial class FormSalesOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv_purchaseOrderList = new Krypton.Toolkit.KryptonDataGridView();
            groupBox5 = new GroupBox();
            dgv_purchaseOrderDetailList = new Krypton.Toolkit.KryptonDataGridView();
            txt_description = new Krypton.Toolkit.KryptonRichTextBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            dtp_OrderDate = new Krypton.Toolkit.KryptonDateTimePicker();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            cmb_Customer = new Krypton.Toolkit.KryptonComboBox();
            groupBox2 = new GroupBox();
            nmrc_UnitPurchasePrice = new Krypton.Toolkit.KryptonNumericUpDown();
            nmrc_Quantity = new Krypton.Toolkit.KryptonNumericUpDown();
            cmb_Product = new Krypton.Toolkit.KryptonComboBox();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            colLineTotal = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            btn_clearbox = new Krypton.Toolkit.KryptonButton();
            btn_updatePurchaseOrder = new Krypton.Toolkit.KryptonButton();
            btn_SavePurchase = new Krypton.Toolkit.KryptonButton();
            txt_GrandTotal = new Krypton.Toolkit.KryptonTextBox();
            txt_totalProductCount = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            groupBox3 = new GroupBox();
            btn_deleteProduct = new Krypton.Toolkit.KryptonButton();
            btn_AddProduct = new Krypton.Toolkit.KryptonButton();
            dgv_PurchaseProductList = new Krypton.Toolkit.KryptonDataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            groupBox6 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgv_purchaseOrderList).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_purchaseOrderDetailList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Customer).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_Product).BeginInit();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_PurchaseProductList).BeginInit();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_purchaseOrderList
            // 
            dgv_purchaseOrderList.BorderStyle = BorderStyle.None;
            dgv_purchaseOrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_purchaseOrderList.Location = new Point(6, 22);
            dgv_purchaseOrderList.Name = "dgv_purchaseOrderList";
            dgv_purchaseOrderList.Size = new Size(582, 387);
            dgv_purchaseOrderList.TabIndex = 4;
            dgv_purchaseOrderList.CellContentClick += dgv_purchaseOrderList_CellContentClick;
            dgv_purchaseOrderList.SelectionChanged += dgv_PurchaseOrderList_SelectionChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dgv_purchaseOrderDetailList);
            groupBox5.Location = new Point(362, 517);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(594, 232);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "Sipariş Detayları";
            // 
            // dgv_purchaseOrderDetailList
            // 
            dgv_purchaseOrderDetailList.BorderStyle = BorderStyle.None;
            dgv_purchaseOrderDetailList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_purchaseOrderDetailList.Location = new Point(6, 22);
            dgv_purchaseOrderDetailList.Name = "dgv_purchaseOrderDetailList";
            dgv_purchaseOrderDetailList.Size = new Size(582, 204);
            dgv_purchaseOrderDetailList.TabIndex = 4;
            // 
            // txt_description
            // 
            txt_description.Location = new Point(107, 108);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(164, 72);
            txt_description.TabIndex = 7;
            txt_description.Text = "";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(6, 108);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(66, 20);
            kryptonLabel3.TabIndex = 6;
            kryptonLabel3.Values.Text = "Açıklama :";
            // 
            // dtp_OrderDate
            // 
            dtp_OrderDate.Location = new Point(107, 65);
            dtp_OrderDate.Name = "dtp_OrderDate";
            dtp_OrderDate.Size = new Size(164, 21);
            dtp_OrderDate.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(6, 66);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(83, 20);
            kryptonLabel2.TabIndex = 5;
            kryptonLabel2.Values.Text = "Sipariş tarihi :";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(6, 24);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(58, 20);
            kryptonLabel1.TabIndex = 4;
            kryptonLabel1.Values.Text = "Müşteri :";
            // 
            // cmb_Customer
            // 
            cmb_Customer.Location = new Point(107, 22);
            cmb_Customer.Name = "cmb_Customer";
            cmb_Customer.Size = new Size(164, 22);
            cmb_Customer.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_Customer.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientActiveCaption;
            groupBox2.Controls.Add(txt_description);
            groupBox2.Controls.Add(kryptonLabel3);
            groupBox2.Controls.Add(dtp_OrderDate);
            groupBox2.Controls.Add(kryptonLabel2);
            groupBox2.Controls.Add(kryptonLabel1);
            groupBox2.Controls.Add(cmb_Customer);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 186);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sipariş Bilgileri";
            // 
            // nmrc_UnitPurchasePrice
            // 
            nmrc_UnitPurchasePrice.AllowDecimals = true;
            nmrc_UnitPurchasePrice.DecimalPlaces = 2;
            nmrc_UnitPurchasePrice.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_UnitPurchasePrice.Location = new Point(106, 89);
            nmrc_UnitPurchasePrice.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_UnitPurchasePrice.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_UnitPurchasePrice.Name = "nmrc_UnitPurchasePrice";
            nmrc_UnitPurchasePrice.Size = new Size(165, 22);
            nmrc_UnitPurchasePrice.TabIndex = 6;
            nmrc_UnitPurchasePrice.ThousandsSeparator = true;
            nmrc_UnitPurchasePrice.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nmrc_Quantity
            // 
            nmrc_Quantity.AllowDecimals = true;
            nmrc_Quantity.DecimalPlaces = 2;
            nmrc_Quantity.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_Quantity.Location = new Point(107, 56);
            nmrc_Quantity.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_Quantity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_Quantity.Name = "nmrc_Quantity";
            nmrc_Quantity.Size = new Size(164, 22);
            nmrc_Quantity.TabIndex = 5;
            nmrc_Quantity.ThousandsSeparator = true;
            nmrc_Quantity.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // cmb_Product
            // 
            cmb_Product.Location = new Point(107, 30);
            cmb_Product.Name = "cmb_Product";
            cmb_Product.Size = new Size(164, 22);
            cmb_Product.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_Product.TabIndex = 4;
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(1, 91);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(99, 20);
            kryptonLabel6.TabIndex = 2;
            kryptonLabel6.Values.Text = "Birim Alış Fiyatı :";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(1, 58);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(52, 20);
            kryptonLabel5.TabIndex = 1;
            kryptonLabel5.Values.Text = "Miktar :";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(1, 32);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(43, 20);
            kryptonLabel4.TabIndex = 0;
            kryptonLabel4.Values.Text = "Ürün :";
            // 
            // colLineTotal
            // 
            colLineTotal.HeaderText = "Satır Toplamı";
            colLineTotal.Name = "colLineTotal";
            colLineTotal.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(6, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(337, 742);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.GradientActiveCaption;
            groupBox4.Controls.Add(btn_clearbox);
            groupBox4.Controls.Add(btn_updatePurchaseOrder);
            groupBox4.Controls.Add(btn_SavePurchase);
            groupBox4.Controls.Add(txt_GrandTotal);
            groupBox4.Controls.Add(txt_totalProductCount);
            groupBox4.Controls.Add(kryptonLabel9);
            groupBox4.Controls.Add(kryptonLabel8);
            groupBox4.Location = new Point(6, 498);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(325, 236);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Sipariş Özeti";
            // 
            // btn_clearbox
            // 
            btn_clearbox.Location = new Point(6, 195);
            btn_clearbox.Name = "btn_clearbox";
            btn_clearbox.Size = new Size(313, 37);
            btn_clearbox.TabIndex = 6;
            btn_clearbox.Values.DropDownArrowColor = Color.Empty;
            btn_clearbox.Values.Text = "Seçimi Temizle";
            btn_clearbox.Click += btn_clearbox_Click;
            // 
            // btn_updatePurchaseOrder
            // 
            btn_updatePurchaseOrder.Location = new Point(6, 152);
            btn_updatePurchaseOrder.Name = "btn_updatePurchaseOrder";
            btn_updatePurchaseOrder.Size = new Size(313, 37);
            btn_updatePurchaseOrder.TabIndex = 5;
            btn_updatePurchaseOrder.Values.DropDownArrowColor = Color.Empty;
            btn_updatePurchaseOrder.Values.Text = "Siparişi Güncelle";
            // 
            // btn_SavePurchase
            // 
            btn_SavePurchase.Location = new Point(6, 109);
            btn_SavePurchase.Name = "btn_SavePurchase";
            btn_SavePurchase.Size = new Size(313, 37);
            btn_SavePurchase.TabIndex = 4;
            btn_SavePurchase.Values.DropDownArrowColor = Color.Empty;
            btn_SavePurchase.Values.Text = "Siparişi Kaydet";
            btn_SavePurchase.Click += btn_SavePurchase_Click;
            // 
            // txt_GrandTotal
            // 
            txt_GrandTotal.Location = new Point(219, 67);
            txt_GrandTotal.Name = "txt_GrandTotal";
            txt_GrandTotal.ReadOnly = true;
            txt_GrandTotal.Size = new Size(100, 23);
            txt_GrandTotal.TabIndex = 3;
            // 
            // txt_totalProductCount
            // 
            txt_totalProductCount.Location = new Point(219, 41);
            txt_totalProductCount.Name = "txt_totalProductCount";
            txt_totalProductCount.ReadOnly = true;
            txt_totalProductCount.Size = new Size(100, 23);
            txt_totalProductCount.TabIndex = 2;
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(12, 70);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(92, 20);
            kryptonLabel9.TabIndex = 1;
            kryptonLabel9.Values.Text = "Genel Toplam :";
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(12, 44);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(123, 20);
            kryptonLabel8.TabIndex = 0;
            kryptonLabel8.Values.Text = "Toplam Ürün Adedi :";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.GradientActiveCaption;
            groupBox3.Controls.Add(btn_deleteProduct);
            groupBox3.Controls.Add(btn_AddProduct);
            groupBox3.Controls.Add(dgv_PurchaseProductList);
            groupBox3.Controls.Add(nmrc_UnitPurchasePrice);
            groupBox3.Controls.Add(nmrc_Quantity);
            groupBox3.Controls.Add(cmb_Product);
            groupBox3.Controls.Add(kryptonLabel6);
            groupBox3.Controls.Add(kryptonLabel5);
            groupBox3.Controls.Add(kryptonLabel4);
            groupBox3.Location = new Point(6, 197);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(325, 295);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sipariş Ürünleri";
            // 
            // btn_deleteProduct
            // 
            btn_deleteProduct.Location = new Point(202, 265);
            btn_deleteProduct.Name = "btn_deleteProduct";
            btn_deleteProduct.Size = new Size(117, 25);
            btn_deleteProduct.TabIndex = 10;
            btn_deleteProduct.Values.DropDownArrowColor = Color.Empty;
            btn_deleteProduct.Values.Text = "- Seçili Ürünü Kaldır";
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.Location = new Point(1, 265);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(90, 25);
            btn_AddProduct.TabIndex = 9;
            btn_AddProduct.Values.DropDownArrowColor = Color.Empty;
            btn_AddProduct.Values.Text = "+ Ürün Ekle";
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // dgv_PurchaseProductList
            // 
            dgv_PurchaseProductList.AllowUserToOrderColumns = true;
            dgv_PurchaseProductList.BorderStyle = BorderStyle.None;
            dgv_PurchaseProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_PurchaseProductList.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colQuantity, colUnitPrice, colLineTotal });
            dgv_PurchaseProductList.Location = new Point(1, 117);
            dgv_PurchaseProductList.Name = "dgv_PurchaseProductList";
            dgv_PurchaseProductList.Size = new Size(318, 142);
            dgv_PurchaseProductList.TabIndex = 8;
            // 
            // colProductId
            // 
            colProductId.HeaderText = "Ürün ID";
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Ürün Adı";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Miktar";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            colUnitPrice.HeaderText = "Birim Fiyatı";
            colUnitPrice.Name = "colUnitPrice";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgv_purchaseOrderList);
            groupBox6.Location = new Point(362, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(594, 418);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "Satın Alma Siparişleri";
            // 
            // FormSalesOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 786);
            Controls.Add(groupBox5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox6);
            Name = "FormSalesOrders";
            Text = "FormSalesOrders";
            Load += FormSalesOrders_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_purchaseOrderList).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_purchaseOrderDetailList).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_Customer).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_Product).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_PurchaseProductList).EndInit();
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView dgv_purchaseOrderList;
        private GroupBox groupBox5;
        private Krypton.Toolkit.KryptonDataGridView dgv_purchaseOrderDetailList;
        private Krypton.Toolkit.KryptonRichTextBox txt_description;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonDateTimePicker dtp_OrderDate;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonComboBox cmb_Customer;
        private GroupBox groupBox2;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_UnitPurchasePrice;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_Quantity;
        private Krypton.Toolkit.KryptonComboBox cmb_Product;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private DataGridViewTextBoxColumn colLineTotal;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private Krypton.Toolkit.KryptonButton btn_updatePurchaseOrder;
        private Krypton.Toolkit.KryptonButton btn_SavePurchase;
        private Krypton.Toolkit.KryptonTextBox txt_GrandTotal;
        private Krypton.Toolkit.KryptonTextBox txt_totalProductCount;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private GroupBox groupBox3;
        private Krypton.Toolkit.KryptonButton btn_deleteProduct;
        private Krypton.Toolkit.KryptonButton btn_AddProduct;
        private Krypton.Toolkit.KryptonDataGridView dgv_PurchaseProductList;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private GroupBox groupBox6;
        private Krypton.Toolkit.KryptonButton btn_clearbox;
    }
}