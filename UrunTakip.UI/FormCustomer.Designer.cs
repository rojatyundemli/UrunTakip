namespace UrunTakip.UI
{
    partial class FormCustomer
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
            check_isActive = new Krypton.Toolkit.KryptonCheckBox();
            txt_District = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            txt_City = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            btn_update = new Krypton.Toolkit.KryptonButton();
            btn_save = new Krypton.Toolkit.KryptonButton();
            txt_adres = new Krypton.Toolkit.KryptonRichTextBox();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            txt_taxNumber = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            txt_taxOffice = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            txt_tel = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            txt_eposta = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            txt_ContactName = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            txt_CustomerName = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            dgv_ListCustomer = new Krypton.Toolkit.KryptonDataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ListCustomer).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(check_isActive);
            groupBox1.Controls.Add(txt_District);
            groupBox1.Controls.Add(kryptonLabel10);
            groupBox1.Controls.Add(txt_City);
            groupBox1.Controls.Add(kryptonLabel9);
            groupBox1.Controls.Add(btn_update);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(txt_adres);
            groupBox1.Controls.Add(kryptonLabel7);
            groupBox1.Controls.Add(txt_taxNumber);
            groupBox1.Controls.Add(kryptonLabel6);
            groupBox1.Controls.Add(txt_taxOffice);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(txt_tel);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(txt_eposta);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(txt_ContactName);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(txt_CustomerName);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(277, 370);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tedarikçi Yönetimi";
            // 
            // check_isActive
            // 
            check_isActive.Location = new Point(110, 302);
            check_isActive.Name = "check_isActive";
            check_isActive.Size = new Size(49, 20);
            check_isActive.TabIndex = 22;
            check_isActive.Values.Text = "Aktif";
            // 
            // txt_District
            // 
            txt_District.Location = new Point(110, 222);
            txt_District.Name = "txt_District";
            txt_District.Size = new Size(151, 23);
            txt_District.TabIndex = 21;
            // 
            // kryptonLabel10
            // 
            kryptonLabel10.Location = new Point(6, 225);
            kryptonLabel10.Name = "kryptonLabel10";
            kryptonLabel10.Size = new Size(35, 20);
            kryptonLabel10.TabIndex = 20;
            kryptonLabel10.Values.Text = "İlçe : ";
            // 
            // txt_City
            // 
            txt_City.Location = new Point(110, 193);
            txt_City.Name = "txt_City";
            txt_City.Size = new Size(151, 23);
            txt_City.TabIndex = 19;
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(6, 196);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(44, 20);
            kryptonLabel9.TabIndex = 18;
            kryptonLabel9.Values.Text = "Şehir : ";
            // 
            // btn_update
            // 
            btn_update.Location = new Point(187, 328);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(76, 25);
            btn_update.TabIndex = 16;
            btn_update.Values.DropDownArrowColor = Color.Empty;
            btn_update.Values.Text = "Güncelle";
            btn_update.Click += btn_update_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(110, 328);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(71, 25);
            btn_save.TabIndex = 3;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // txt_adres
            // 
            txt_adres.Location = new Point(110, 251);
            txt_adres.Name = "txt_adres";
            txt_adres.Size = new Size(151, 46);
            txt_adres.TabIndex = 14;
            txt_adres.Text = "";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(6, 251);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(48, 20);
            kryptonLabel7.TabIndex = 12;
            kryptonLabel7.Values.Text = "Adres :";
            // 
            // txt_taxNumber
            // 
            txt_taxNumber.Location = new Point(110, 164);
            txt_taxNumber.Name = "txt_taxNumber";
            txt_taxNumber.Size = new Size(151, 23);
            txt_taxNumber.TabIndex = 11;
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(6, 167);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(101, 20);
            kryptonLabel6.TabIndex = 10;
            kryptonLabel6.Values.Text = "Vergi Numarası :";
            // 
            // txt_taxOffice
            // 
            txt_taxOffice.Location = new Point(110, 135);
            txt_taxOffice.Name = "txt_taxOffice";
            txt_taxOffice.Size = new Size(151, 23);
            txt_taxOffice.TabIndex = 9;
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(6, 138);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(86, 20);
            kryptonLabel5.TabIndex = 8;
            kryptonLabel5.Values.Text = "Vergi Daiersi :";
            // 
            // txt_tel
            // 
            txt_tel.Location = new Point(110, 77);
            txt_tel.Name = "txt_tel";
            txt_tel.Size = new Size(151, 23);
            txt_tel.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(6, 80);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(57, 20);
            kryptonLabel4.TabIndex = 6;
            kryptonLabel4.Values.Text = "Telefon :";
            // 
            // txt_eposta
            // 
            txt_eposta.Location = new Point(110, 106);
            txt_eposta.Name = "txt_eposta";
            txt_eposta.Size = new Size(151, 23);
            txt_eposta.TabIndex = 5;
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(6, 109);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(52, 20);
            kryptonLabel3.TabIndex = 4;
            kryptonLabel3.Values.Text = "E-Posta";
            // 
            // txt_ContactName
            // 
            txt_ContactName.Location = new Point(110, 48);
            txt_ContactName.Name = "txt_ContactName";
            txt_ContactName.Size = new Size(151, 23);
            txt_ContactName.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(6, 51);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(71, 20);
            kryptonLabel2.TabIndex = 2;
            kryptonLabel2.Values.Text = "Yetkili Kişi :";
            // 
            // txt_CustomerName
            // 
            txt_CustomerName.Location = new Point(110, 19);
            txt_CustomerName.Name = "txt_CustomerName";
            txt_CustomerName.Size = new Size(151, 23);
            txt_CustomerName.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(6, 22);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(68, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Firma Adı :";
            // 
            // dgv_ListCustomer
            // 
            dgv_ListCustomer.BorderStyle = BorderStyle.None;
            dgv_ListCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListCustomer.Location = new Point(307, 20);
            dgv_ListCustomer.Name = "dgv_ListCustomer";
            dgv_ListCustomer.Size = new Size(481, 362);
            dgv_ListCustomer.TabIndex = 3;
            dgv_ListCustomer.CellContentClick += dgv_ListCustomer_CellContentClick;
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(dgv_ListCustomer);
            Controls.Add(groupBox1);
            Name = "FormCustomer";
            Text = "FormCustomer";
            Load += FormCustomer_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ListCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonButton btn_update;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonRichTextBox txt_adres;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonTextBox txt_taxNumber;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonTextBox txt_taxOffice;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox txt_tel;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txt_eposta;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox txt_ContactName;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txt_CustomerName;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonCheckBox check_isActive;
        private Krypton.Toolkit.KryptonTextBox txt_District;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonTextBox txt_City;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonDataGridView dgv_ListCustomer;
    }
}