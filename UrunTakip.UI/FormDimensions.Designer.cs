namespace UrunTakip.UI
{
    partial class FormDimensions
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
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            txt_dimensionsCode = new Krypton.Toolkit.KryptonTextBox();
            txt_dimensionsName = new Krypton.Toolkit.KryptonTextBox();
            cmb_BaseUnitId = new Krypton.Toolkit.KryptonComboBox();
            txt_description = new Krypton.Toolkit.KryptonRichTextBox();
            check_IsActive = new Krypton.Toolkit.KryptonCheckBox();
            btn_save = new Krypton.Toolkit.KryptonButton();
            btn_update = new Krypton.Toolkit.KryptonButton();
            dgv_dimansionsList = new Krypton.Toolkit.KryptonDataGridView();
            groupBox1 = new GroupBox();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)cmb_BaseUnitId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_dimansionsList).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(4, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(102, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Ölçü Türü Kodu :";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(4, 38);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(91, 20);
            kryptonLabel2.TabIndex = 1;
            kryptonLabel2.Values.Text = "Ölçü Türü Adı :";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(4, 64);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(100, 20);
            kryptonLabel3.TabIndex = 2;
            kryptonLabel3.Values.Text = "Esas ölçü birimi :";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(4, 90);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(66, 20);
            kryptonLabel4.TabIndex = 3;
            kryptonLabel4.Values.Text = "Açıklama :";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(4, 116);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(54, 20);
            kryptonLabel5.TabIndex = 4;
            kryptonLabel5.Values.Text = "Durum :";
            // 
            // txt_dimensionsCode
            // 
            txt_dimensionsCode.Location = new Point(112, 9);
            txt_dimensionsCode.Name = "txt_dimensionsCode";
            txt_dimensionsCode.Size = new Size(151, 23);
            txt_dimensionsCode.TabIndex = 5;
            // 
            // txt_dimensionsName
            // 
            txt_dimensionsName.Location = new Point(112, 35);
            txt_dimensionsName.Name = "txt_dimensionsName";
            txt_dimensionsName.Size = new Size(151, 23);
            txt_dimensionsName.TabIndex = 6;
            // 
            // cmb_BaseUnitId
            // 
            cmb_BaseUnitId.Location = new Point(112, 62);
            cmb_BaseUnitId.Name = "cmb_BaseUnitId";
            cmb_BaseUnitId.Size = new Size(151, 22);
            cmb_BaseUnitId.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_BaseUnitId.TabIndex = 7;
            // 
            // txt_description
            // 
            txt_description.Location = new Point(112, 90);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(151, 20);
            txt_description.TabIndex = 8;
            txt_description.Text = "";
            // 
            // check_IsActive
            // 
            check_IsActive.Location = new Point(112, 116);
            check_IsActive.Name = "check_IsActive";
            check_IsActive.Size = new Size(49, 20);
            check_IsActive.TabIndex = 9;
            check_IsActive.Values.Text = "Aktif";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(5, 142);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(90, 25);
            btn_save.TabIndex = 10;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(101, 142);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(90, 25);
            btn_update.TabIndex = 11;
            btn_update.Values.DropDownArrowColor = Color.Empty;
            btn_update.Values.Text = "Güncelle";
            btn_update.Click += btn_update_Click;
            // 
            // dgv_dimansionsList
            // 
            dgv_dimansionsList.BorderStyle = BorderStyle.None;
            dgv_dimansionsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_dimansionsList.Location = new Point(290, 12);
            dgv_dimansionsList.Name = "dgv_dimansionsList";
            dgv_dimansionsList.Size = new Size(410, 192);
            dgv_dimansionsList.TabIndex = 12;
            dgv_dimansionsList.SelectionChanged += dgv_dimansionsList_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(btn_clear);
            groupBox1.Controls.Add(btn_update);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(check_IsActive);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(txt_description);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(cmb_BaseUnitId);
            groupBox1.Controls.Add(txt_dimensionsCode);
            groupBox1.Controls.Add(txt_dimensionsName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(272, 192);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(197, 142);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(69, 25);
            btn_clear.TabIndex = 12;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Temizle";
            btn_clear.Click += btn_clear_Click;
            // 
            // FormDimensions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 225);
            Controls.Add(groupBox1);
            Controls.Add(dgv_dimansionsList);
            Name = "FormDimensions";
            Text = "Dimensions";
            Load += FormDimensions_Load;
            ((System.ComponentModel.ISupportInitialize)cmb_BaseUnitId).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_dimansionsList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox txt_dimensionsCode;
        private Krypton.Toolkit.KryptonTextBox txt_dimensionsName;
        private Krypton.Toolkit.KryptonComboBox cmb_BaseUnitId;
        private Krypton.Toolkit.KryptonRichTextBox txt_description;
        private Krypton.Toolkit.KryptonCheckBox check_IsActive;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonButton btn_update;
        private Krypton.Toolkit.KryptonDataGridView dgv_dimansionsList;
        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonButton btn_clear;
    }
}