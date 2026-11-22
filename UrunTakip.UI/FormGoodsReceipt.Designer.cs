namespace UrunTakip.UI
{
    partial class FormGoodsReceipt
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
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            groupBox2 = new GroupBox();
            check_ReceviedAll = new Krypton.Toolkit.KryptonCheckBox();
            lbl_ProductName = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            btn_ApplyQuantity = new Krypton.Toolkit.KryptonButton();
            nmrc_ReceivedQuantity = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            grpBox_OrderDetails = new GroupBox();
            dgv_orderDetails = new DataGridView();
            cmb_PurchaseOrders = new Krypton.Toolkit.KryptonComboBox();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            btn_save = new Krypton.Toolkit.KryptonButton();
            groupBox3 = new GroupBox();
            dgv_ReadyOrderDetails = new Krypton.Toolkit.KryptonDataGridView();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            txt_Description = new Krypton.Toolkit.KryptonRichTextBox();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            dtp_ReceiptDate = new DateTimePicker();
            groupBox1 = new GroupBox();
            lbl_orderDate = new Krypton.Toolkit.KryptonLabel();
            lbl_Supplier = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            grpBox_OrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_PurchaseOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel2).BeginInit();
            kryptonPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ReadyOrderDetails).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(groupBox2);
            kryptonPanel1.Controls.Add(grpBox_OrderDetails);
            kryptonPanel1.Controls.Add(cmb_PurchaseOrders);
            kryptonPanel1.Controls.Add(kryptonLabel1);
            kryptonPanel1.Location = new Point(12, 12);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(305, 426);
            kryptonPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.InactiveCaption;
            groupBox2.Controls.Add(check_ReceviedAll);
            groupBox2.Controls.Add(lbl_ProductName);
            groupBox2.Controls.Add(kryptonLabel5);
            groupBox2.Controls.Add(btn_ApplyQuantity);
            groupBox2.Controls.Add(nmrc_ReceivedQuantity);
            groupBox2.Controls.Add(kryptonLabel4);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(0, 249);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(302, 144);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Teslim Alma";
            // 
            // check_ReceviedAll
            // 
            check_ReceviedAll.Location = new Point(9, 73);
            check_ReceviedAll.Name = "check_ReceviedAll";
            check_ReceviedAll.Size = new Size(168, 20);
            check_ReceviedAll.TabIndex = 3;
            check_ReceviedAll.Values.Text = "Seçilen Ürünün  Hepsini Al";
            check_ReceviedAll.CheckedChanged += check_ReceviedAll_CheckedChanged;
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            lbl_ProductName.Location = new Point(138, 22);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(6, 2);
            lbl_ProductName.TabIndex = 8;
            lbl_ProductName.Values.Text = "";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(9, 22);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(85, 20);
            kryptonLabel5.TabIndex = 7;
            kryptonLabel5.Values.Text = "Seçilen Ürün :";
            // 
            // btn_ApplyQuantity
            // 
            btn_ApplyQuantity.Location = new Point(6, 113);
            btn_ApplyQuantity.Name = "btn_ApplyQuantity";
            btn_ApplyQuantity.Size = new Size(290, 25);
            btn_ApplyQuantity.TabIndex = 6;
            btn_ApplyQuantity.Values.DropDownArrowColor = Color.Empty;
            btn_ApplyQuantity.Values.Text = "Miktarı Uygula";
            btn_ApplyQuantity.Click += btn_ApplyQuantity_Click;
            // 
            // nmrc_ReceivedQuantity
            // 
            nmrc_ReceivedQuantity.AllowDecimals = true;
            nmrc_ReceivedQuantity.DecimalPlaces = 2;
            nmrc_ReceivedQuantity.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_ReceivedQuantity.Location = new Point(138, 41);
            nmrc_ReceivedQuantity.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_ReceivedQuantity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_ReceivedQuantity.Name = "nmrc_ReceivedQuantity";
            nmrc_ReceivedQuantity.Size = new Size(158, 22);
            nmrc_ReceivedQuantity.TabIndex = 5;
            nmrc_ReceivedQuantity.ThousandsSeparator = true;
            nmrc_ReceivedQuantity.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(3, 43);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(139, 20);
            kryptonLabel4.TabIndex = 4;
            kryptonLabel4.Values.Text = "Teslim Alınacak Miktar :";
            // 
            // grpBox_OrderDetails
            // 
            grpBox_OrderDetails.BackColor = SystemColors.InactiveCaption;
            grpBox_OrderDetails.Controls.Add(dgv_orderDetails);
            grpBox_OrderDetails.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpBox_OrderDetails.Location = new Point(3, 48);
            grpBox_OrderDetails.Name = "grpBox_OrderDetails";
            grpBox_OrderDetails.Size = new Size(299, 182);
            grpBox_OrderDetails.TabIndex = 3;
            grpBox_OrderDetails.TabStop = false;
            grpBox_OrderDetails.Text = "Sipariş İçeriği";
            // 
            // dgv_orderDetails
            // 
            dgv_orderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_orderDetails.Location = new Point(6, 22);
            dgv_orderDetails.Name = "dgv_orderDetails";
            dgv_orderDetails.Size = new Size(287, 150);
            dgv_orderDetails.TabIndex = 0;
            dgv_orderDetails.CellContentClick += dgv_orderDetails_CellClick;
            // 
            // cmb_PurchaseOrders
            // 
            cmb_PurchaseOrders.Location = new Point(116, 12);
            cmb_PurchaseOrders.Name = "cmb_PurchaseOrders";
            cmb_PurchaseOrders.Size = new Size(186, 22);
            cmb_PurchaseOrders.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_PurchaseOrders.TabIndex = 1;
            cmb_PurchaseOrders.SelectedIndexChanged += cmb_PurchaseOrders_SelectedIndexChanged;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            kryptonLabel1.Location = new Point(0, 14);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(126, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Satın Alma Siparişi :";
            // 
            // kryptonPanel2
            // 
            kryptonPanel2.Controls.Add(btn_clear);
            kryptonPanel2.Controls.Add(btn_save);
            kryptonPanel2.Controls.Add(groupBox3);
            kryptonPanel2.Controls.Add(groupBox1);
            kryptonPanel2.Location = new Point(483, 12);
            kryptonPanel2.Name = "kryptonPanel2";
            kryptonPanel2.Size = new Size(305, 426);
            kryptonPanel2.TabIndex = 2;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(3, 387);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(299, 36);
            btn_clear.TabIndex = 8;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Temizle";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(3, 351);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(299, 36);
            btn_save.TabIndex = 7;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.InactiveCaption;
            groupBox3.Controls.Add(dgv_ReadyOrderDetails);
            groupBox3.Controls.Add(kryptonLabel9);
            groupBox3.Controls.Add(txt_Description);
            groupBox3.Controls.Add(kryptonLabel7);
            groupBox3.Controls.Add(dtp_ReceiptDate);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(0, 51);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(305, 301);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Mal Kabul Bilgileri";
            // 
            // dgv_ReadyOrderDetails
            // 
            dgv_ReadyOrderDetails.BorderStyle = BorderStyle.None;
            dgv_ReadyOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ReadyOrderDetails.Location = new Point(6, 19);
            dgv_ReadyOrderDetails.Name = "dgv_ReadyOrderDetails";
            dgv_ReadyOrderDetails.Size = new Size(293, 195);
            dgv_ReadyOrderDetails.TabIndex = 11;
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(11, 258);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(66, 20);
            kryptonLabel9.TabIndex = 10;
            kryptonLabel9.Values.Text = "Açıklama :";
            // 
            // txt_Description
            // 
            txt_Description.Location = new Point(99, 249);
            txt_Description.Name = "txt_Description";
            txt_Description.Size = new Size(200, 38);
            txt_Description.TabIndex = 9;
            txt_Description.Text = "";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(11, 223);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(81, 20);
            kryptonLabel7.TabIndex = 6;
            kryptonLabel7.Values.Text = "Kabul Tarihi :";
            // 
            // dtp_ReceiptDate
            // 
            dtp_ReceiptDate.Location = new Point(99, 220);
            dtp_ReceiptDate.Name = "dtp_ReceiptDate";
            dtp_ReceiptDate.Size = new Size(200, 23);
            dtp_ReceiptDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(lbl_orderDate);
            groupBox1.Controls.Add(lbl_Supplier);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 51);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sipariş Bilgileri";
            // 
            // lbl_orderDate
            // 
            lbl_orderDate.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            lbl_orderDate.Location = new Point(225, 22);
            lbl_orderDate.Name = "lbl_orderDate";
            lbl_orderDate.Size = new Size(74, 20);
            lbl_orderDate.TabIndex = 4;
            lbl_orderDate.Values.Text = "21.05.2005";
            // 
            // lbl_Supplier
            // 
            lbl_Supplier.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            lbl_Supplier.Location = new Point(6, 22);
            lbl_Supplier.Name = "lbl_Supplier";
            lbl_Supplier.Size = new Size(151, 20);
            lbl_Supplier.TabIndex = 0;
            lbl_Supplier.Values.Text = "PO-0012 — ABC Tedarik";
            // 
            // FormGoodsReceipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(kryptonPanel2);
            Controls.Add(kryptonPanel1);
            Name = "FormGoodsReceipt";
            Text = "FormGoodsReceipt";
            Load += FormGoodsReceipt_Load;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            grpBox_OrderDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_orderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_PurchaseOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel2).EndInit();
            kryptonPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ReadyOrderDetails).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonComboBox cmb_PurchaseOrders;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonLabel lbl_Supplier;
        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonLabel lbl_orderDate;
        private GroupBox grpBox_OrderDetails;
        private DataGridView dgv_orderDetails;
        private GroupBox groupBox2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonButton btn_ApplyQuantity;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_ReceivedQuantity;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private DateTimePicker dtp_ReceiptDate;
        private Krypton.Toolkit.KryptonLabel lbl_ProductName;
        private GroupBox groupBox3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonRichTextBox txt_Description;
        private Krypton.Toolkit.KryptonCheckBox check_ReceviedAll;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonDataGridView dgv_ReadyOrderDetails;
    }
}