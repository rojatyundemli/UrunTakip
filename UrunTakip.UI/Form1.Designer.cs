
namespace UrunTakip.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btn_Updatee = new Krypton.Toolkit.KryptonButton();
            cmb_unitname = new ComboBox();
            btn_cleare = new Krypton.Toolkit.KryptonButton();
            kryptonLabel14 = new Krypton.Toolkit.KryptonLabel();
            btn_Savee = new Krypton.Toolkit.KryptonButton();
            kryptonLabel11 = new Krypton.Toolkit.KryptonLabel();
            check_Active = new Krypton.Toolkit.KryptonCheckBox();
            txt_Descrabtion = new Krypton.Toolkit.KryptonRichTextBox();
            cmb_category = new ComboBox();
            nmrc_maxStock = new Krypton.Toolkit.KryptonNumericUpDown();
            nmrc_PurchasePrice = new Krypton.Toolkit.KryptonNumericUpDown();
            nmrc_Stock = new Krypton.Toolkit.KryptonNumericUpDown();
            nmrc_minStock = new Krypton.Toolkit.KryptonNumericUpDown();
            txt_Barcode = new Krypton.Toolkit.KryptonTextBox();
            txt_productCode = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            nmr_Price = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            txtName = new Krypton.Toolkit.KryptonTextBox();
            dgvProducts = new DataGridView();
            textBox1 = new TextBox();
            kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel13 = new Krypton.Toolkit.KryptonLabel();
            menuStrip = new MenuStrip();
            ilgiliSayfalarToolStripMenuItem = new ToolStripMenuItem();
            kategoriYönetimiToolStripMenuItem = new ToolStripMenuItem();
            birimYönetimiToolStripMenuItem = new ToolStripMenuItem();
            ölçüTürleriToolStripMenuItem = new ToolStripMenuItem();
            ölçüBirimleriToolStripMenuItem = new ToolStripMenuItem();
            birimDönüşümleriToolStripMenuItem = new ToolStripMenuItem();
            ürünBirimleriToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(btn_Updatee);
            groupBox1.Controls.Add(cmb_unitname);
            groupBox1.Controls.Add(btn_cleare);
            groupBox1.Controls.Add(kryptonLabel14);
            groupBox1.Controls.Add(btn_Savee);
            groupBox1.Controls.Add(kryptonLabel11);
            groupBox1.Controls.Add(check_Active);
            groupBox1.Controls.Add(txt_Descrabtion);
            groupBox1.Controls.Add(cmb_category);
            groupBox1.Controls.Add(nmrc_maxStock);
            groupBox1.Controls.Add(nmrc_PurchasePrice);
            groupBox1.Controls.Add(nmrc_Stock);
            groupBox1.Controls.Add(nmrc_minStock);
            groupBox1.Controls.Add(txt_Barcode);
            groupBox1.Controls.Add(txt_productCode);
            groupBox1.Controls.Add(kryptonLabel10);
            groupBox1.Controls.Add(kryptonLabel9);
            groupBox1.Controls.Add(kryptonLabel8);
            groupBox1.Controls.Add(kryptonLabel7);
            groupBox1.Controls.Add(kryptonLabel6);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(nmr_Price);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Controls.Add(txtName);
            groupBox1.Location = new Point(12, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(365, 531);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Ekle";
            // 
            // btn_Updatee
            // 
            btn_Updatee.Location = new Point(102, 500);
            btn_Updatee.Name = "btn_Updatee";
            btn_Updatee.Size = new Size(90, 25);
            btn_Updatee.TabIndex = 41;
            btn_Updatee.Values.DropDownArrowColor = Color.Empty;
            btn_Updatee.Values.Text = "Güncelle ";
            btn_Updatee.Click += btn_Update_Click;
            // 
            // cmb_unitname
            // 
            cmb_unitname.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_unitname.FormattingEnabled = true;
            cmb_unitname.Location = new Point(125, 275);
            cmb_unitname.Name = "cmb_unitname";
            cmb_unitname.Size = new Size(148, 23);
            cmb_unitname.TabIndex = 37;
            cmb_unitname.DropDown += cmb_unitname_DropDown;
            // 
            // btn_cleare
            // 
            btn_cleare.Location = new Point(198, 500);
            btn_cleare.Name = "btn_cleare";
            btn_cleare.Size = new Size(90, 25);
            btn_cleare.TabIndex = 40;
            btn_cleare.Values.DropDownArrowColor = Color.Empty;
            btn_cleare.Values.Text = "Temizle";
            btn_cleare.Click += btn_clear_Click;
            // 
            // kryptonLabel14
            // 
            kryptonLabel14.Location = new Point(6, 278);
            kryptonLabel14.Name = "kryptonLabel14";
            kryptonLabel14.Size = new Size(45, 20);
            kryptonLabel14.TabIndex = 36;
            kryptonLabel14.Values.Text = "Birim :";
            // 
            // btn_Savee
            // 
            btn_Savee.Location = new Point(6, 500);
            btn_Savee.Name = "btn_Savee";
            btn_Savee.Size = new Size(90, 25);
            btn_Savee.TabIndex = 39;
            btn_Savee.Values.DropDownArrowColor = Color.Empty;
            btn_Savee.Values.Text = "Kaydet";
            btn_Savee.Click += btn_Save_Click_1;
            // 
            // kryptonLabel11
            // 
            kryptonLabel11.Location = new Point(6, 466);
            kryptonLabel11.Name = "kryptonLabel11";
            kryptonLabel11.Size = new Size(54, 20);
            kryptonLabel11.TabIndex = 35;
            kryptonLabel11.Values.Text = "Durum :";
            // 
            // check_Active
            // 
            check_Active.Location = new Point(125, 466);
            check_Active.Name = "check_Active";
            check_Active.Size = new Size(49, 20);
            check_Active.TabIndex = 34;
            check_Active.Values.Text = "Aktif";
            // 
            // txt_Descrabtion
            // 
            txt_Descrabtion.Location = new Point(125, 384);
            txt_Descrabtion.Name = "txt_Descrabtion";
            txt_Descrabtion.Size = new Size(208, 66);
            txt_Descrabtion.TabIndex = 33;
            txt_Descrabtion.Text = "";
            // 
            // cmb_category
            // 
            cmb_category.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_category.FormattingEnabled = true;
            cmb_category.Location = new Point(125, 246);
            cmb_category.Name = "cmb_category";
            cmb_category.Size = new Size(148, 23);
            cmb_category.TabIndex = 32;
            cmb_category.DropDown += cmb_category_DropDown;
            // 
            // nmrc_maxStock
            // 
            nmrc_maxStock.AllowDecimals = true;
            nmrc_maxStock.DecimalPlaces = 2;
            nmrc_maxStock.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_maxStock.Location = new Point(125, 212);
            nmrc_maxStock.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_maxStock.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_maxStock.Name = "nmrc_maxStock";
            nmrc_maxStock.Size = new Size(148, 22);
            nmrc_maxStock.TabIndex = 31;
            nmrc_maxStock.ThousandsSeparator = true;
            nmrc_maxStock.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nmrc_PurchasePrice
            // 
            nmrc_PurchasePrice.AllowDecimals = true;
            nmrc_PurchasePrice.DecimalPlaces = 2;
            nmrc_PurchasePrice.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_PurchasePrice.Location = new Point(125, 98);
            nmrc_PurchasePrice.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_PurchasePrice.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_PurchasePrice.Name = "nmrc_PurchasePrice";
            nmrc_PurchasePrice.Size = new Size(148, 22);
            nmrc_PurchasePrice.TabIndex = 30;
            nmrc_PurchasePrice.ThousandsSeparator = true;
            nmrc_PurchasePrice.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nmrc_Stock
            // 
            nmrc_Stock.AllowDecimals = true;
            nmrc_Stock.DecimalPlaces = 2;
            nmrc_Stock.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_Stock.Location = new Point(125, 143);
            nmrc_Stock.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_Stock.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_Stock.Name = "nmrc_Stock";
            nmrc_Stock.Size = new Size(148, 22);
            nmrc_Stock.TabIndex = 29;
            nmrc_Stock.ThousandsSeparator = true;
            nmrc_Stock.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nmrc_minStock
            // 
            nmrc_minStock.AllowDecimals = true;
            nmrc_minStock.DecimalPlaces = 2;
            nmrc_minStock.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmrc_minStock.Location = new Point(125, 175);
            nmrc_minStock.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmrc_minStock.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_minStock.Name = "nmrc_minStock";
            nmrc_minStock.Size = new Size(148, 22);
            nmrc_minStock.TabIndex = 28;
            nmrc_minStock.ThousandsSeparator = true;
            nmrc_minStock.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // txt_Barcode
            // 
            txt_Barcode.Location = new Point(125, 341);
            txt_Barcode.Name = "txt_Barcode";
            txt_Barcode.Size = new Size(208, 23);
            txt_Barcode.TabIndex = 27;
            // 
            // txt_productCode
            // 
            txt_productCode.Location = new Point(125, 304);
            txt_productCode.Name = "txt_productCode";
            txt_productCode.Size = new Size(208, 23);
            txt_productCode.TabIndex = 26;
            // 
            // kryptonLabel10
            // 
            kryptonLabel10.Location = new Point(6, 384);
            kryptonLabel10.Name = "kryptonLabel10";
            kryptonLabel10.Size = new Size(66, 20);
            kryptonLabel10.TabIndex = 20;
            kryptonLabel10.Values.Text = "Açıklama :";
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(6, 214);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(104, 20);
            kryptonLabel9.TabIndex = 25;
            kryptonLabel9.Values.Text = "Maksimum Stok :";
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(6, 177);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(96, 20);
            kryptonLabel8.TabIndex = 19;
            kryptonLabel8.Values.Text = "Minimum Stok :";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(6, 341);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(55, 20);
            kryptonLabel7.TabIndex = 19;
            kryptonLabel7.Values.Text = "Barkod :";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(6, 249);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(62, 20);
            kryptonLabel6.TabIndex = 19;
            kryptonLabel6.Values.Text = "Kategori :";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(6, 100);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(57, 20);
            kryptonLabel5.TabIndex = 19;
            kryptonLabel5.Values.Text = "Maliyet :";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(6, 307);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(75, 20);
            kryptonLabel4.TabIndex = 24;
            kryptonLabel4.Values.Text = "Ürün Kodu :";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(6, 143);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(41, 20);
            kryptonLabel3.TabIndex = 23;
            kryptonLabel3.Values.Text = "Stok :";
            // 
            // nmr_Price
            // 
            nmr_Price.AllowDecimals = true;
            nmr_Price.DecimalPlaces = 2;
            nmr_Price.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nmr_Price.Location = new Point(125, 60);
            nmr_Price.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            nmr_Price.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_Price.Name = "nmr_Price";
            nmr_Price.Size = new Size(148, 22);
            nmr_Price.TabIndex = 19;
            nmr_Price.ThousandsSeparator = true;
            nmr_Price.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(6, 66);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(104, 20);
            kryptonLabel2.TabIndex = 18;
            kryptonLabel2.Values.Text = "Ürün Satış Fiyatı :";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(6, 29);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(65, 20);
            kryptonLabel1.TabIndex = 17;
            kryptonLabel1.Values.Text = "Ürün Adı :";
            // 
            // txtName
            // 
            txtName.Location = new Point(125, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(208, 23);
            txtName.TabIndex = 16;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(424, 68);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(526, 349);
            dgvProducts.TabIndex = 8;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(424, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(526, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // kryptonLabel12
            // 
            kryptonLabel12.Location = new Point(663, 485);
            kryptonLabel12.Name = "kryptonLabel12";
            kryptonLabel12.Size = new Size(421, 20);
            kryptonLabel12.TabIndex = 36;
            kryptonLabel12.Values.Text = "Aktiflik pasiflik , Kategori ekleme silme (Yarı mamül hammadde , ürün dahil)";
            // 
            // kryptonLabel13
            // 
            kryptonLabel13.Location = new Point(672, 459);
            kryptonLabel13.Name = "kryptonLabel13";
            kryptonLabel13.Size = new Size(133, 20);
            kryptonLabel13.TabIndex = 37;
            kryptonLabel13.Values.Text = "Ekleme silme listeleme ";
            // 
            // menuStrip
            // 
            menuStrip.BackColor = SystemColors.InactiveCaption;
            menuStrip.Font = new Font("Segoe UI", 9F);
            menuStrip.Items.AddRange(new ToolStripItem[] { ilgiliSayfalarToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1486, 24);
            menuStrip.TabIndex = 38;
            menuStrip.Text = "menuStrip1";
            // 
            // ilgiliSayfalarToolStripMenuItem
            // 
            ilgiliSayfalarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kategoriYönetimiToolStripMenuItem, birimYönetimiToolStripMenuItem });
            ilgiliSayfalarToolStripMenuItem.Name = "ilgiliSayfalarToolStripMenuItem";
            ilgiliSayfalarToolStripMenuItem.Size = new Size(85, 20);
            ilgiliSayfalarToolStripMenuItem.Text = "İlgili Sayfalar";
            // 
            // kategoriYönetimiToolStripMenuItem
            // 
            kategoriYönetimiToolStripMenuItem.Name = "kategoriYönetimiToolStripMenuItem";
            kategoriYönetimiToolStripMenuItem.Size = new Size(183, 22);
            kategoriYönetimiToolStripMenuItem.Text = "Kategori Yönetimi";
            kategoriYönetimiToolStripMenuItem.Click += kategoriYönetimiToolStripMenuItem_Click;
            // 
            // birimYönetimiToolStripMenuItem
            // 
            birimYönetimiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ölçüTürleriToolStripMenuItem, ölçüBirimleriToolStripMenuItem, birimDönüşümleriToolStripMenuItem, ürünBirimleriToolStripMenuItem });
            birimYönetimiToolStripMenuItem.Name = "birimYönetimiToolStripMenuItem";
            birimYönetimiToolStripMenuItem.Size = new Size(183, 22);
            birimYönetimiToolStripMenuItem.Text = "Ölçü Birimi Yönetimi";
            // 
            // ölçüTürleriToolStripMenuItem
            // 
            ölçüTürleriToolStripMenuItem.Name = "ölçüTürleriToolStripMenuItem";
            ölçüTürleriToolStripMenuItem.Size = new Size(173, 22);
            ölçüTürleriToolStripMenuItem.Text = "Ölçü Türleri";
            ölçüTürleriToolStripMenuItem.Click += ölçüTürleriToolStripMenuItem_Click;
            // 
            // ölçüBirimleriToolStripMenuItem
            // 
            ölçüBirimleriToolStripMenuItem.Name = "ölçüBirimleriToolStripMenuItem";
            ölçüBirimleriToolStripMenuItem.Size = new Size(173, 22);
            ölçüBirimleriToolStripMenuItem.Text = "Ölçü Birimleri";
            ölçüBirimleriToolStripMenuItem.Click += ölçüBirimleriToolStripMenuItem_Click;
            // 
            // birimDönüşümleriToolStripMenuItem
            // 
            birimDönüşümleriToolStripMenuItem.Name = "birimDönüşümleriToolStripMenuItem";
            birimDönüşümleriToolStripMenuItem.Size = new Size(173, 22);
            birimDönüşümleriToolStripMenuItem.Text = "Birim Dönüşümleri";
            birimDönüşümleriToolStripMenuItem.Click += birimDönüşümleriToolStripMenuItem_Click;
            // 
            // ürünBirimleriToolStripMenuItem
            // 
            ürünBirimleriToolStripMenuItem.Name = "ürünBirimleriToolStripMenuItem";
            ürünBirimleriToolStripMenuItem.Size = new Size(173, 22);
            ürünBirimleriToolStripMenuItem.Text = "Ürün Birimleri";
            ürünBirimleriToolStripMenuItem.Click += ürünBirimleriToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 810);
            Controls.Add(kryptonLabel13);
            Controls.Add(kryptonLabel12);
            Controls.Add(textBox1);
            Controls.Add(dgvProducts);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox txtName1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private DataGridView dgvProducts;
        private TextBox textBox1;
        private Krypton.Toolkit.KryptonTextBox txtName;
        private Krypton.Toolkit.KryptonNumericUpDown nmr_Price;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton btnDelete;
        private Krypton.Toolkit.KryptonButton btnUpdate;
        private Krypton.Toolkit.KryptonButton btnUrunKontrol;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txt_Barcode;
        private Krypton.Toolkit.KryptonTextBox txt_productCode;
        private Krypton.Toolkit.KryptonRichTextBox txt_Descrabtion;
        private ComboBox cmb_category;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_maxStock;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_PurchasePrice;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_Stock;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_minStock;
        private Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private Krypton.Toolkit.KryptonCheckBox check_Active;
        private Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private MenuStrip menuStrip;
        private ToolStripMenuItem ilgiliSayfalarToolStripMenuItem;
        private ToolStripMenuItem kategoriYönetimiToolStripMenuItem;
        private ToolStripMenuItem birimYönetimiToolStripMenuItem;
        private ToolStripMenuItem ölçüTürleriToolStripMenuItem;
        private ToolStripMenuItem ölçüBirimleriToolStripMenuItem;
        private ToolStripMenuItem birimDönüşümleriToolStripMenuItem;
        private ToolStripMenuItem ürünBirimleriToolStripMenuItem;
        private ComboBox cmb_unitname;
        private Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private Krypton.Toolkit.KryptonButton btn_Updatee;
        private Krypton.Toolkit.KryptonButton btn_cleare;
        private Krypton.Toolkit.KryptonButton btn_Savee;
    }
}
