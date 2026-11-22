namespace UrunTakip.UI
{
    partial class FormUnitConversions
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
            groupBox2 = new GroupBox();
            txt_unitCode = new Krypton.Toolkit.KryptonTextBox();
            label2 = new Krypton.Toolkit.KryptonLabel();
            lbl_result = new Krypton.Toolkit.KryptonLabel();
            txt_baseUnitName = new Krypton.Toolkit.KryptonTextBox();
            txt_dimensionsName = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            nmr_Denominator = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            nmr_Numarator = new Krypton.Toolkit.KryptonNumericUpDown();
            btn_clear = new Krypton.Toolkit.KryptonButton();
            btn_update = new Krypton.Toolkit.KryptonButton();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            btn_save = new Krypton.Toolkit.KryptonButton();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            cmb_unit = new Krypton.Toolkit.KryptonComboBox();
            kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_unit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kryptonDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.InactiveCaption;
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(nmr_Denominator);
            groupBox1.Controls.Add(kryptonLabel6);
            groupBox1.Controls.Add(nmr_Numarator);
            groupBox1.Controls.Add(btn_clear);
            groupBox1.Controls.Add(btn_update);
            groupBox1.Controls.Add(kryptonLabel1);
            groupBox1.Controls.Add(btn_save);
            groupBox1.Controls.Add(kryptonLabel4);
            groupBox1.Controls.Add(cmb_unit);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(652, 180);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientActiveCaption;
            groupBox2.Controls.Add(txt_unitCode);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lbl_result);
            groupBox2.Controls.Add(txt_baseUnitName);
            groupBox2.Controls.Add(txt_dimensionsName);
            groupBox2.Controls.Add(kryptonLabel3);
            groupBox2.Controls.Add(kryptonLabel2);
            groupBox2.Location = new Point(431, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(221, 173);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dönüşüm Önizlemesi";
            // 
            // txt_unitCode
            // 
            txt_unitCode.Location = new Point(93, 80);
            txt_unitCode.Name = "txt_unitCode";
            txt_unitCode.ReadOnly = true;
            txt_unitCode.Size = new Size(111, 23);
            txt_unitCode.TabIndex = 9;
            // 
            // label2
            // 
            label2.Location = new Point(6, 80);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 8;
            label2.Values.Text = "Birim Kodu :";
            // 
            // lbl_result
            // 
            lbl_result.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            lbl_result.Location = new Point(6, 122);
            lbl_result.Name = "lbl_result";
            lbl_result.Size = new Size(6, 2);
            lbl_result.TabIndex = 7;
            lbl_result.Values.Text = "";
            // 
            // txt_baseUnitName
            // 
            txt_baseUnitName.Location = new Point(93, 51);
            txt_baseUnitName.Name = "txt_baseUnitName";
            txt_baseUnitName.ReadOnly = true;
            txt_baseUnitName.Size = new Size(111, 23);
            txt_baseUnitName.TabIndex = 5;
            // 
            // txt_dimensionsName
            // 
            txt_dimensionsName.Location = new Point(93, 22);
            txt_dimensionsName.Name = "txt_dimensionsName";
            txt_dimensionsName.ReadOnly = true;
            txt_dimensionsName.Size = new Size(111, 23);
            txt_dimensionsName.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(6, 54);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(81, 20);
            kryptonLabel3.TabIndex = 2;
            kryptonLabel3.Values.Text = "Temel Birim :";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(17, 24);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(70, 20);
            kryptonLabel2.TabIndex = 1;
            kryptonLabel2.Values.Text = "Ölçü Türü :";
            // 
            // nmr_Denominator
            // 
            nmr_Denominator.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Denominator.Location = new Point(143, 65);
            nmr_Denominator.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            nmr_Denominator.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_Denominator.Name = "nmr_Denominator";
            nmr_Denominator.Size = new Size(151, 22);
            nmr_Denominator.TabIndex = 15;
            nmr_Denominator.Value = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_Denominator.ValueChanged += nmr_Denominator_ValueChanged;
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(6, 65);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(114, 20);
            kryptonLabel6.TabIndex = 14;
            kryptonLabel6.Values.Text = "Dönüşüm Paydası :";
            // 
            // nmr_Numarator
            // 
            nmr_Numarator.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Numarator.Location = new Point(143, 39);
            nmr_Numarator.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            nmr_Numarator.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_Numarator.Name = "nmr_Numarator";
            nmr_Numarator.Size = new Size(151, 22);
            nmr_Numarator.TabIndex = 13;
            nmr_Numarator.Value = new decimal(new int[] { 0, 0, 0, 0 });
            nmr_Numarator.ValueChanged += nmr_Numarator_ValueChanged;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(193, 155);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(69, 25);
            btn_clear.TabIndex = 12;
            btn_clear.Values.DropDownArrowColor = Color.Empty;
            btn_clear.Values.Text = "Temizle";
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(97, 155);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(90, 25);
            btn_update.TabIndex = 11;
            btn_update.Values.DropDownArrowColor = Color.Empty;
            btn_update.Values.Text = "Güncelle";
            btn_update.Click += btn_update_Click;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(4, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(133, 20);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Dönüştürülecek Birim :";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(1, 155);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(90, 25);
            btn_save.TabIndex = 10;
            btn_save.Values.DropDownArrowColor = Color.Empty;
            btn_save.Values.Text = "Kaydet";
            btn_save.Click += btn_save_Click;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(6, 39);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(95, 20);
            kryptonLabel4.TabIndex = 3;
            kryptonLabel4.Values.Text = "Dönüşüm Payı :";
            // 
            // cmb_unit
            // 
            cmb_unit.Location = new Point(143, 10);
            cmb_unit.Name = "cmb_unit";
            cmb_unit.Size = new Size(151, 22);
            cmb_unit.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cmb_unit.TabIndex = 7;
            cmb_unit.SelectedIndexChanged += cmb_unit_SelectedIndexChanged;
            // 
            // kryptonDataGridView1
            // 
            kryptonDataGridView1.BorderStyle = BorderStyle.None;
            kryptonDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            kryptonDataGridView1.Location = new Point(12, 198);
            kryptonDataGridView1.Name = "kryptonDataGridView1";
            kryptonDataGridView1.Size = new Size(652, 175);
            kryptonDataGridView1.TabIndex = 16;
            kryptonDataGridView1.SelectionChanged += kryptonDataGridView1_SelectionChanged;
            // 
            // FormUnitConversions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 385);
            Controls.Add(kryptonDataGridView1);
            Controls.Add(groupBox1);
            Name = "FormUnitConversions";
            Text = "FormUnitConversions";
            Load += FormUnitConversions_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmb_unit).EndInit();
            ((System.ComponentModel.ISupportInitialize)kryptonDataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_update;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonCheckBox check_IsActive;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonRichTextBox txt_description;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonComboBox cmb_unit;
        private Krypton.Toolkit.KryptonTextBox txt_baseUnitName;
        private Krypton.Toolkit.KryptonTextBox txt_dimensionsName;
        private GroupBox groupBox2;
        private Krypton.Toolkit.KryptonLabel lbl_result;
        private Krypton.Toolkit.KryptonNumericUpDown nmr_Denominator;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonNumericUpDown nmr_Numarator;
        private Krypton.Toolkit.KryptonTextBox txt_unitCode;
        private Krypton.Toolkit.KryptonLabel label2;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
    }
}