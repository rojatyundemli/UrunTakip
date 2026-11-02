namespace UrunTakip.UI
{
    partial class FormStockMovement
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
            dg_productMovementList = new DataGridView();
            cmbProductName = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            nmrcQuantity = new NumericUpDown();
            txtDesc = new RichTextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btn_getProductMovement = new Button();
            label5 = new Label();
            txt_movementId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dg_productMovementList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmrcQuantity).BeginInit();
            SuspendLayout();
            // 
            // dg_productMovementList
            // 
            dg_productMovementList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_productMovementList.Location = new Point(376, 40);
            dg_productMovementList.Name = "dg_productMovementList";
            dg_productMovementList.Size = new Size(468, 372);
            dg_productMovementList.TabIndex = 0;
            dg_productMovementList.CellContentClick += dg_productMovementList_CellContentClick;
            // 
            // cmbProductName
            // 
            cmbProductName.FormattingEnabled = true;
            cmbProductName.Location = new Point(175, 74);
            cmbProductName.Name = "cmbProductName";
            cmbProductName.Size = new Size(177, 23);
            cmbProductName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 74);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 103);
            label2.Name = "label2";
            label2.Size = new Size(74, 30);
            label2.TabIndex = 4;
            label2.Text = "Stok Hareket\r\nTürü\r\n";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "IN", "OUT" });
            cmbType.Location = new Point(175, 103);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(177, 23);
            cmbType.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 150);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Stok Miktarı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 184);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 6;
            label4.Text = "Açıklama ";
            // 
            // nmrcQuantity
            // 
            nmrcQuantity.Location = new Point(175, 148);
            nmrcQuantity.Name = "nmrcQuantity";
            nmrcQuantity.Size = new Size(177, 23);
            nmrcQuantity.TabIndex = 7;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(175, 181);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(177, 96);
            txtDesc.TabIndex = 8;
            txtDesc.Text = "";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(18, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(117, 300);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(219, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btn_getProductMovement
            // 
            btn_getProductMovement.Location = new Point(376, 418);
            btn_getProductMovement.Name = "btn_getProductMovement";
            btn_getProductMovement.Size = new Size(75, 23);
            btn_getProductMovement.TabIndex = 12;
            btn_getProductMovement.Text = "Yenile";
            btn_getProductMovement.UseVisualStyleBackColor = true;
            btn_getProductMovement.Click += btn_getProductMovement_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 43);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 14;
            label5.Text = "Stok Hareket ID";
            // 
            // txt_movementId
            // 
            txt_movementId.Location = new Point(175, 40);
            txt_movementId.Name = "txt_movementId";
            txt_movementId.ReadOnly = true;
            txt_movementId.Size = new Size(177, 23);
            txt_movementId.TabIndex = 15;
            // 
            // FormStockMovement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 468);
            Controls.Add(txt_movementId);
            Controls.Add(label5);
            Controls.Add(btn_getProductMovement);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtDesc);
            Controls.Add(nmrcQuantity);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbType);
            Controls.Add(label1);
            Controls.Add(cmbProductName);
            Controls.Add(dg_productMovementList);
            Name = "FormStockMovement";
            Text = "FormStockMovement";
            Load += FormStockMovement_Load;
            ((System.ComponentModel.ISupportInitialize)dg_productMovementList).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmrcQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dg_productMovementList;
        private ComboBox cmbProductName;
        private Label label1;
        private Label label2;
        private ComboBox cmbType;
        private Label label3;
        private Label label4;
        private NumericUpDown nmrcQuantity;
        private RichTextBox txtDesc;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btn_getProductMovement;
        private Label label5;
        private TextBox txt_movementId;
    }
}