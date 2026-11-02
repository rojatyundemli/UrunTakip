namespace UrunTakip.UI
{
    partial class FormSupplier
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
            groupBox1 = new GroupBox();
            btn_deActive = new Krypton.Toolkit.KryptonButton();
            btn_update = new Krypton.Toolkit.KryptonButton();
            btn_save = new Krypton.Toolkit.KryptonButton();
            txt_descraption = new Krypton.Toolkit.KryptonRichTextBox();
            txt_adres = new Krypton.Toolkit.KryptonRichTextBox();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            txt_taxNumber = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            txt_taxOffice = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            txt_tel = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            txt_eposta = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            txt_officalPerson = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            txt_SupplierName = new Krypton.Toolkit.KryptonTextBox();
            dgvSupplierList = new Krypton.Toolkit.KryptonDataGridView();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierList).BeginInit();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(6, 22);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(87, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Tedarikçi Adı :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_deActive);
            groupBox1.Controls.Add(btn_update);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(txt_descraption);
            groupBox1.Controls.Add(txt_adres);
            groupBox1.Controls.Add(kryptonLabel8);
            groupBox1.Controls.Add(kryptonLabel7);
            groupBox1.Controls.Add(txt_taxNumber);
            groupBox1.Controls.Add(kryptonLabel6);
            groupBox1.Controls.Add(txt_taxOffice);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(txt_tel);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(txt_eposta);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(txt_officalPerson);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(txt_SupplierName);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(277, 408);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tedarikçi Yönetimi";
            // 
            // btn_deActive
            // 
            btn_deActive.Location = new Point(165, 377);
            btn_deActive.Name = "btn_deActive";
            btn_deActive.Size = new Size(63, 25);
            btn_deActive.TabIndex = 17;
            btn_deActive.Values.DropDownArrowColor = Color.Empty;
            btn_deActive.Values.Text = "Pasif Yap";
            btn_deActive.Click += btn_deActive_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(83, 377);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(76, 25);
            btn_update.TabIndex = 16;
            btn_update.Values.DropDownArrowColor = Color.Empty;
            btn_update.Values.Text = "Güncelle";
            btn_update.Click += btn_update_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(6, 377);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(71, 25);
            btn_save.TabIndex = 3;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // txt_descraption
            // 
            txt_descraption.Location = new Point(110, 245);
            txt_descraption.Name = "txt_descraption";
            txt_descraption.Size = new Size(151, 45);
            txt_descraption.TabIndex = 15;
            txt_descraption.Text = "";
            // 
            // txt_adres
            // 
            txt_adres.Location = new Point(110, 193);
            txt_adres.Name = "txt_adres";
            txt_adres.Size = new Size(151, 46);
            txt_adres.TabIndex = 14;
            txt_adres.Text = "";
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(6, 245);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(66, 20);
            kryptonLabel8.TabIndex = 13;
            kryptonLabel8.Values.Text = "Açıklama :";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(6, 193);
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
            // txt_officalPerson
            // 
            txt_officalPerson.Location = new Point(110, 48);
            txt_officalPerson.Name = "txt_officalPerson";
            txt_officalPerson.Size = new Size(151, 23);
            txt_officalPerson.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(6, 51);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(71, 20);
            kryptonLabel2.TabIndex = 2;
            kryptonLabel2.Values.Text = "Yetkili Kişi :";
            // 
            // txt_SupplierName
            // 
            txt_SupplierName.Location = new Point(110, 19);
            txt_SupplierName.Name = "txt_SupplierName";
            txt_SupplierName.Size = new Size(151, 23);
            txt_SupplierName.TabIndex = 1;
            // 
            // dgvSupplierList
            // 
            dgvSupplierList.AllowUserToOrderColumns = true;
            dgvSupplierList.BorderStyle = BorderStyle.None;
            dgvSupplierList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplierList.Location = new Point(339, 49);
            dgvSupplierList.Name = "dgvSupplierList";
            dgvSupplierList.Size = new Size(439, 365);
            dgvSupplierList.TabIndex = 2;
            dgvSupplierList.CellContentClick += dgvSupplierList_CellContentClick;
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(339, 23);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(109, 20);
            kryptonLabel9.TabIndex = 18;
            kryptonLabel9.Values.Text = "Tedarikçi Adı Ara :";
            // 
            // kryptonTextBox1
            // 
            kryptonTextBox1.Location = new Point(454, 20);
            kryptonTextBox1.Name = "kryptonTextBox1";
            kryptonTextBox1.Size = new Size(324, 23);
            kryptonTextBox1.TabIndex = 19;
            kryptonTextBox1.TextChanged += kryptonTextBox1_TextChanged;
            // 
            // FormSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 450);
            Controls.Add(kryptonTextBox1);
            Controls.Add(kryptonLabel9);
            Controls.Add(dgvSupplierList);
            Controls.Add(groupBox1);
            Name = "FormSupplier";
            Text = "FormSupplier";
            Load += FormSupplier_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSupplierList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonTextBox txt_taxOffice;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox txt_tel;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txt_eposta;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox txt_officalPerson;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txt_SupplierName;
        private Krypton.Toolkit.KryptonTextBox txt_taxNumber;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonRichTextBox txt_adres;
        private Krypton.Toolkit.KryptonButton btn_deActive;
        private Krypton.Toolkit.KryptonButton btn_update;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonRichTextBox txt_descraption;
        private Krypton.Toolkit.KryptonDataGridView dgvSupplierList;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
    }
}