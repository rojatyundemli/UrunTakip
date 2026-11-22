namespace UrunTakip.UI
{
    partial class FormProductUnit
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
            groupBox1 = new GroupBox();
            cmb_alternativeUnit = new Krypton.Toolkit.KryptonComboBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            cmb_product = new Krypton.Toolkit.KryptonComboBox();
            txt_baseUnit = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            groupBox2 = new GroupBox();
            nmr_payda = new Krypton.Toolkit.KryptonNumericUpDown();
            nmr_pay = new Krypton.Toolkit.KryptonNumericUpDown();
            check_IsActive = new Krypton.Toolkit.KryptonCheckBox();
            check_IsSalesUnit = new Krypton.Toolkit.KryptonCheckBox();
            check_IsPurchaseUnit = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgv_ProductUnitsList = new Krypton.Toolkit.KryptonDataGridView();
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            btn_Update = new Krypton.Toolkit.KryptonButton();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            btn_Save = new Krypton.Toolkit.KryptonButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_alternativeUnit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmb_product).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitsList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(cmb_alternativeUnit);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(cmb_product);
            groupBox1.Controls.Add(txt_baseUnit);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Location = new Point(9, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(376, 166);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürüne Birim tanımlama";
            // 
            // cmb_alternativeUnit
            // 
            cmb_alternativeUnit.Location = new Point(110, 77);
            cmb_alternativeUnit.Name = "cmb_alternativeUnit";
            cmb_alternativeUnit.Size = new Size(131, 22);
            cmb_alternativeUnit.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_alternativeUnit.TabIndex = 5;
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(0, 79);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(98, 20);
            kryptonLabel3.TabIndex = 4;
            kryptonLabel3.Values.Text = "Alternatif Birim :";
            // 
            // cmb_product
            // 
            cmb_product.Location = new Point(110, 20);
            cmb_product.Name = "cmb_product";
            cmb_product.Size = new Size(131, 22);
            cmb_product.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_product.TabIndex = 3;
            cmb_product.SelectedIndexChanged += cmb_product_SelectedIndexChanged;
            // 
            // txt_baseUnit
            // 
            txt_baseUnit.Location = new Point(110, 48);
            txt_baseUnit.Name = "txt_baseUnit";
            txt_baseUnit.ReadOnly = true;
            txt_baseUnit.Size = new Size(131, 23);
            txt_baseUnit.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(0, 51);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(69, 20);
            kryptonLabel2.TabIndex = 1;
            kryptonLabel2.Values.Text = "Ana Birim :";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(0, 22);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(43, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Ürün :";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.InactiveCaption;
            groupBox2.Controls.Add(nmr_payda);
            groupBox2.Controls.Add(nmr_pay);
            groupBox2.Controls.Add(check_IsActive);
            groupBox2.Controls.Add(check_IsSalesUnit);
            groupBox2.Controls.Add(check_IsPurchaseUnit);
            groupBox2.Controls.Add(kryptonLabel8);
            groupBox2.Controls.Add(kryptonLabel7);
            groupBox2.Controls.Add(kryptonLabel4);
            groupBox2.Controls.Add(kryptonLabel5);
            groupBox2.Controls.Add(kryptonLabel6);
            groupBox2.Location = new Point(391, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(376, 166);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dönüşüm Oranı";
            // 
            // nmr_payda
            // 
            nmr_payda.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_payda.Location = new Point(217, 48);
            nmr_payda.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            nmr_payda.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_payda.Name = "nmr_payda";
            nmr_payda.Size = new Size(120, 22);
            nmr_payda.TabIndex = 10;
            nmr_payda.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nmr_pay
            // 
            nmr_pay.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_pay.Location = new Point(217, 20);
            nmr_pay.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            nmr_pay.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_pay.Name = "nmr_pay";
            nmr_pay.Size = new Size(120, 22);
            nmr_pay.TabIndex = 9;
            nmr_pay.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // check_IsActive
            // 
            check_IsActive.Location = new Point(217, 131);
            check_IsActive.Name = "check_IsActive";
            check_IsActive.Size = new Size(49, 20);
            check_IsActive.TabIndex = 8;
            check_IsActive.Values.Text = "Aktif";
            // 
            // check_IsSalesUnit
            // 
            check_IsSalesUnit.Location = new Point(217, 105);
            check_IsSalesUnit.Name = "check_IsSalesUnit";
            check_IsSalesUnit.Size = new Size(46, 20);
            check_IsSalesUnit.TabIndex = 8;
            check_IsSalesUnit.Values.Text = "Evet";
            // 
            // check_IsPurchaseUnit
            // 
            check_IsPurchaseUnit.Location = new Point(217, 77);
            check_IsPurchaseUnit.Name = "check_IsPurchaseUnit";
            check_IsPurchaseUnit.Size = new Size(46, 20);
            check_IsPurchaseUnit.TabIndex = 7;
            check_IsPurchaseUnit.Values.Text = "Evet";
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(6, 131);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(54, 20);
            kryptonLabel8.TabIndex = 6;
            kryptonLabel8.Values.Text = "Durum :";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(6, 105);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(121, 20);
            kryptonLabel7.TabIndex = 5;
            kryptonLabel7.Values.Text = "Satışta kullanılabilir :";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(6, 79);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(155, 20);
            kryptonLabel4.TabIndex = 4;
            kryptonLabel4.Values.Text = "Satın almada kullanılabilir :";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(6, 51);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(114, 20);
            kryptonLabel5.TabIndex = 1;
            kryptonLabel5.Values.Text = "Dönüşüm Paydası :";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(6, 22);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(95, 20);
            kryptonLabel6.TabIndex = 0;
            kryptonLabel6.Values.Text = "Dönüşüm Payı :";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgv_ProductUnitsList
            // 
            dgv_ProductUnitsList.BorderStyle = BorderStyle.None;
            dgv_ProductUnitsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductUnitsList.Location = new Point(12, 239);
            dgv_ProductUnitsList.Name = "dgv_ProductUnitsList";
            dgv_ProductUnitsList.Size = new Size(778, 179);
            dgv_ProductUnitsList.TabIndex = 7;
            dgv_ProductUnitsList.SelectionChanged += dgv_ProductUnitsList_SelectionChanged;
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(btn_Update);
            kryptonPanel1.Controls.Add(btn_clear);
            kryptonPanel1.Controls.Add(btn_Save);
            kryptonPanel1.Controls.Add(groupBox1);
            kryptonPanel1.Controls.Add(groupBox2);
            kryptonPanel1.Location = new Point(12, 12);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(778, 221);
            kryptonPanel1.TabIndex = 8;
            // 
            // btn_Update
            // 
            btn_Update.Location = new Point(105, 185);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(90, 25);
            btn_Update.TabIndex = 9;
            btn_Update.Values.DropDownArrowColor = Color.Empty;
            btn_Update.Values.Text = "Güncelle ";
            btn_Update.Click += btn_Update_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(201, 185);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(90, 25);
            btn_clear.TabIndex = 8;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Temizle";
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(9, 185);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(90, 25);
            btn_Save.TabIndex = 7;
            btn_Save.Values.DropDownArrowColor = Color.Empty;
            btn_Save.Values.Text = "Kaydet";
            btn_Save.Click += btn_Save_Click;
            // 
            // FormProductUnit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 430);
            Controls.Add(kryptonPanel1);
            Controls.Add(dgv_ProductUnitsList);
            Name = "FormProductUnit";
            Text = "FormProductUnit";
            Load += FormProductUnit_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_alternativeUnit).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmb_product).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitsList).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox txt_baseUnit;
        private Krypton.Toolkit.KryptonComboBox cmb_alternativeUnit;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonComboBox cmb_product;
        private GroupBox groupBox2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonCheckBox check_IsActive;
        private Krypton.Toolkit.KryptonCheckBox check_IsSalesUnit;
        private Krypton.Toolkit.KryptonCheckBox check_IsPurchaseUnit;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Krypton.Toolkit.KryptonDataGridView dgv_ProductUnitsList;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton btn_Update;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_Save;
        private Krypton.Toolkit.KryptonNumericUpDown nmr_payda;
        private Krypton.Toolkit.KryptonNumericUpDown nmr_pay;
    }
}