namespace UrunTakip.UI
{
    partial class FormUnitsOfMeasure
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
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            check_IsActive = new Krypton.Toolkit.KryptonCheckBox();
            txt_unitCode = new Krypton.Toolkit.KryptonTextBox();
            txt_unitName = new Krypton.Toolkit.KryptonTextBox();
            nmrc_Deciminal = new Krypton.Toolkit.KryptonNumericUpDown();
            dgv_UnitList = new Krypton.Toolkit.KryptonDataGridView();
            btn_Save = new Krypton.Toolkit.KryptonButton();
            btn_Update = new Krypton.Toolkit.KryptonButton();
            groupBox1 = new GroupBox();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            cmb_Dimensions = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_UnitList).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_Dimensions).BeginInit();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(11, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(77, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Birim Kodu :";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(12, 66);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(38, 20);
            kryptonLabel2.TabIndex = 1;
            kryptonLabel2.Values.Text = "Tür  :";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(11, 38);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(66, 20);
            kryptonLabel3.TabIndex = 1;
            kryptonLabel3.Values.Text = "Birim Adı :";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(12, 92);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(119, 20);
            kryptonLabel6.TabIndex = 4;
            kryptonLabel6.Values.Text = "Ondalık Hassasiyet :";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(12, 118);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(54, 20);
            kryptonLabel5.TabIndex = 5;
            kryptonLabel5.Values.Text = "Durum :";
            // 
            // check_IsActive
            // 
            check_IsActive.Location = new Point(137, 118);
            check_IsActive.Name = "check_IsActive";
            check_IsActive.Size = new Size(49, 20);
            check_IsActive.TabIndex = 6;
            check_IsActive.Values.Text = "Aktif";
            // 
            // txt_unitCode
            // 
            txt_unitCode.Location = new Point(135, 9);
            txt_unitCode.Name = "txt_unitCode";
            txt_unitCode.Size = new Size(148, 23);
            txt_unitCode.TabIndex = 7;
            // 
            // txt_unitName
            // 
            txt_unitName.Location = new Point(135, 35);
            txt_unitName.Name = "txt_unitName";
            txt_unitName.Size = new Size(148, 23);
            txt_unitName.TabIndex = 8;
            // 
            // nmrc_Deciminal
            // 
            nmrc_Deciminal.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nmrc_Deciminal.Location = new Point(137, 90);
            nmrc_Deciminal.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nmrc_Deciminal.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmrc_Deciminal.Name = "nmrc_Deciminal";
            nmrc_Deciminal.Size = new Size(120, 22);
            nmrc_Deciminal.TabIndex = 10;
            nmrc_Deciminal.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // dgv_UnitList
            // 
            dgv_UnitList.BorderStyle = BorderStyle.None;
            dgv_UnitList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_UnitList.Location = new Point(318, 9);
            dgv_UnitList.Name = "dgv_UnitList";
            dgv_UnitList.Size = new Size(387, 195);
            dgv_UnitList.TabIndex = 11;
            dgv_UnitList.SelectionChanged += dgv_UnitList_SelectionChanged;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(12, 159);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(90, 25);
            btn_Save.TabIndex = 12;
            btn_Save.Values.DropDownArrowColor = Color.Empty;
            btn_Save.Values.Text = "Kaydet";
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Update
            // 
            btn_Update.Location = new Point(108, 159);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(90, 25);
            btn_Update.TabIndex = 13;
            btn_Update.Values.DropDownArrowColor = Color.Empty;
            btn_Update.Values.Text = "Güncelle";
            btn_Update.Click += btn_Update_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(cmb_Dimensions);
            groupBox1.Controls.Add(btn_clear);
            groupBox1.Controls.Add(txt_unitCode);
            groupBox1.Controls.Add(btn_Update);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Controls.Add(btn_Save);
            groupBox1.Controls.Add(kryptonLabel2);
            groupBox1.Controls.Add(kryptonLabel3);
            groupBox1.Controls.Add(nmrc_Deciminal);
            groupBox1.Controls.Add(kryptonLabel6);
            groupBox1.Controls.Add(kryptonLabel5);
            groupBox1.Controls.Add(txt_unitName);
            groupBox1.Controls.Add(check_IsActive);
            groupBox1.Location = new Point(1, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 195);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(204, 159);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(90, 25);
            btn_clear.TabIndex = 14;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Seçimi Temizle";
            btn_clear.Click += btn_clear_Click;
            // 
            // cmb_Dimensions
            // 
            cmb_Dimensions.Location = new Point(137, 62);
            cmb_Dimensions.Name = "cmb_Dimensions";
            cmb_Dimensions.Size = new Size(146, 22);
            cmb_Dimensions.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_Dimensions.TabIndex = 15;
            // 
            // FormUnitsOfMeasure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 233);
            Controls.Add(groupBox1);
            Controls.Add(dgv_UnitList);
            Name = "FormUnitsOfMeasure";
            Text = "UnitsOfMeasure";
            Load += FormUnitsOfMeasure_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_UnitList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_Dimensions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonCheckBox check_IsActive;
        private Krypton.Toolkit.KryptonTextBox txt_unitCode;
        private Krypton.Toolkit.KryptonTextBox txt_unitName;
        private Krypton.Toolkit.KryptonNumericUpDown nmrc_Deciminal;
        private Krypton.Toolkit.KryptonDataGridView dgv_UnitList;
        private Krypton.Toolkit.KryptonButton btn_Save;
        private Krypton.Toolkit.KryptonButton btn_Update;
        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonComboBox cmb_Dimensions;
    }
}