namespace UrunTakip.UI
{
    partial class FormCategoryManager
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
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            txt_categoryName = new Krypton.Toolkit.KryptonTextBox();
            cmb_UpCategory = new Krypton.Toolkit.KryptonComboBox();
            txt_description = new Krypton.Toolkit.KryptonRichTextBox();
            check_isActiv = new Krypton.Toolkit.KryptonCheckBox();
            groupBox1 = new GroupBox();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            txt_categoryCode = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            btn_update = new Krypton.Toolkit.KryptonButton();
            btn_save = new Krypton.Toolkit.KryptonButton();
            dgv_categoryList = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)cmb_UpCategory).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_categoryList).BeginInit();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(6, 22);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(84, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Kategori Adı :";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(6, 81);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(84, 20);
            kryptonLabel3.TabIndex = 2;
            kryptonLabel3.Values.Text = "Üst Kategori :";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(6, 107);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(66, 20);
            kryptonLabel4.TabIndex = 3;
            kryptonLabel4.Values.Text = "Açıklama :";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(6, 159);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(54, 20);
            kryptonLabel2.TabIndex = 4;
            kryptonLabel2.Values.Text = "Durum :";
            // 
            // txt_categoryName
            // 
            txt_categoryName.Location = new Point(96, 19);
            txt_categoryName.Name = "txt_categoryName";
            txt_categoryName.Size = new Size(139, 23);
            txt_categoryName.TabIndex = 5;
            // 
            // cmb_UpCategory
            // 
            cmb_UpCategory.Location = new Point(96, 79);
            cmb_UpCategory.Name = "cmb_UpCategory";
            cmb_UpCategory.Size = new Size(139, 22);
            cmb_UpCategory.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_UpCategory.TabIndex = 6;
            // 
            // txt_description
            // 
            txt_description.Location = new Point(96, 107);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(139, 46);
            txt_description.TabIndex = 7;
            txt_description.Text = "";
            // 
            // check_isActiv
            // 
            check_isActiv.Location = new Point(96, 159);
            check_isActiv.Name = "check_isActiv";
            check_isActiv.Size = new Size(49, 20);
            check_isActiv.TabIndex = 8;
            check_isActiv.Values.Text = "Aktif";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(btn_clear);
            groupBox1.Controls.Add(txt_categoryCode);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(btn_update);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Controls.Add(check_isActiv);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(txt_description);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(cmb_UpCategory);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(txt_categoryName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 258);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(134, 227);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(110, 25);
            btn_clear.TabIndex = 13;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Seçimi Temizle";
            btn_clear.Click += btn_clear_Click;
            // 
            // txt_categoryCode
            // 
            txt_categoryCode.Location = new Point(96, 48);
            txt_categoryCode.Name = "txt_categoryCode";
            txt_categoryCode.Size = new Size(139, 23);
            txt_categoryCode.TabIndex = 12;
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(6, 51);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(95, 20);
            kryptonLabel5.TabIndex = 11;
            kryptonLabel5.Values.Text = "Kategori Kodu :";
            // 
            // btn_update
            // 
            btn_update.Location = new Point(6, 227);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(110, 25);
            btn_update.TabIndex = 10;
            btn_update.Values.DropDownArrowColor = Color.Empty;
            btn_update.Values.Text = "Güncelle";
            btn_update.Click += btn_update_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(6, 196);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(238, 25);
            btn_save.TabIndex = 9;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // dgv_categoryList
            // 
            dgv_categoryList.BorderStyle = BorderStyle.None;
            dgv_categoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_categoryList.Location = new Point(268, 14);
            dgv_categoryList.Name = "dgv_categoryList";
            dgv_categoryList.Size = new Size(304, 256);
            dgv_categoryList.TabIndex = 10;
            dgv_categoryList.SelectionChanged += dgv_categoryList_SelectionChanged;
            // 
            // FormCategoryManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(dgv_categoryList);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormCategoryManager";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kategori Yöneticisi";
            TopMost = true;
            Load += FormCategoryManager_Load;
            ((System.ComponentModel.ISupportInitialize)cmb_UpCategory).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_categoryList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txt_categoryName;
        private Krypton.Toolkit.KryptonComboBox cmb_UpCategory;
        private Krypton.Toolkit.KryptonRichTextBox txt_description;
        private Krypton.Toolkit.KryptonCheckBox check_isActiv;
        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonDataGridView dgv_categoryList;
        private Krypton.Toolkit.KryptonButton btn_update;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox txt_categoryCode;
        private Krypton.Toolkit.KryptonButton btn_clear;
    }
}