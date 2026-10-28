
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
            btnUrunKontrol = new Button();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            richTextBox1 = new RichTextBox();
            nudMaximumStock = new NumericUpDown();
            label8 = new Label();
            nudMinimumStock = new NumericUpDown();
            label7 = new Label();
            cmbUnit = new ComboBox();
            label6 = new Label();
            cmbCategory = new ComboBox();
            labelkat = new Label();
            txtPrice = new NumericUpDown();
            txtDescription = new NumericUpDown();
            txtBarcode = new TextBox();
            txtProductCode = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            dgvProducts = new DataGridView();
            btnListProduct = new Button();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // btnUrunKontrol
            // 
            btnUrunKontrol.Location = new Point(157, 140);
            btnUrunKontrol.Name = "btnUrunKontrol";
            btnUrunKontrol.Size = new Size(75, 23);
            btnUrunKontrol.TabIndex = 0;
            btnUrunKontrol.Text = "Ürün Ekle";
            btnUrunKontrol.UseVisualStyleBackColor = true;
            btnUrunKontrol.Click += btnUrunKontrol_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(132, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 38);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 91);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 5;
            label2.Text = "Ürün Satış Fiyatı";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(btnUrunKontrol);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 438);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Ekle";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(374, 730);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 25;
            label9.Text = "Açıklama";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(489, 727);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(144, 23);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = "";
            // 
            // nudMaximumStock
            // 
            nudMaximumStock.DecimalPlaces = 2;
            nudMaximumStock.Location = new Point(489, 675);
            nudMaximumStock.Name = "nudMaximumStock";
            nudMaximumStock.Size = new Size(121, 23);
            nudMaximumStock.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(374, 677);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 22;
            label8.Text = "Maksimum Stok";
            // 
            // nudMinimumStock
            // 
            nudMinimumStock.DecimalPlaces = 2;
            nudMinimumStock.Location = new Point(489, 622);
            nudMinimumStock.Name = "nudMinimumStock";
            nudMinimumStock.Size = new Size(121, 23);
            nudMinimumStock.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(374, 624);
            label7.Name = "label7";
            label7.Size = new Size(86, 15);
            label7.TabIndex = 20;
            label7.Text = "Minimum Stok";
            // 
            // cmbUnit
            // 
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Location = new Point(165, 725);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(121, 23);
            cmbUnit.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(54, 728);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 18;
            label6.Text = "Ölçü Birimi";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(165, 672);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 17;
            // 
            // labelkat
            // 
            labelkat.AutoSize = true;
            labelkat.Location = new Point(54, 675);
            labelkat.Name = "labelkat";
            labelkat.Size = new Size(51, 15);
            labelkat.TabIndex = 16;
            labelkat.Text = "Kategori";
            // 
            // txtPrice
            // 
            txtPrice.DecimalPlaces = 2;
            txtPrice.Location = new Point(133, 89);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(120, 23);
            txtPrice.TabIndex = 15;
            // 
            // txtDescription
            // 
            txtDescription.DecimalPlaces = 2;
            txtDescription.Location = new Point(165, 576);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(120, 23);
            txtDescription.TabIndex = 14;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(166, 619);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(100, 23);
            txtBarcode.TabIndex = 13;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(165, 522);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.ReadOnly = true;
            txtProductCode.Size = new Size(100, 23);
            txtProductCode.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 525);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 11;
            label5.Text = "Ürün Kodu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 622);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 10;
            label4.Text = "Barkod";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 578);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 9;
            label3.Text = "Ürün Alış Fiyatı";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(157, 198);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(157, 169);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(948, 72);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(526, 349);
            dgvProducts.TabIndex = 8;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // btnListProduct
            // 
            btnListProduct.Location = new Point(948, 427);
            btnListProduct.Name = "btnListProduct";
            btnListProduct.Size = new Size(526, 23);
            btnListProduct.TabIndex = 7;
            btnListProduct.Text = "Ürün Listele";
            btnListProduct.UseVisualStyleBackColor = true;
            btnListProduct.Click += btnListProduct_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(948, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(526, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 810);
            Controls.Add(label9);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(btnListProduct);
            Controls.Add(nudMaximumStock);
            Controls.Add(dgvProducts);
            Controls.Add(label8);
            Controls.Add(groupBox1);
            Controls.Add(nudMinimumStock);
            Controls.Add(label7);
            Controls.Add(txtProductCode);
            Controls.Add(label3);
            Controls.Add(cmbUnit);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbCategory);
            Controls.Add(txtBarcode);
            Controls.Add(labelkat);
            Controls.Add(txtDescription);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaximumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinimumStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnUrunKontrol;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private DataGridView dgvProducts;
        private Button btnListProduct;
        private TextBox textBox1;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtProductCode;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cmbUnit;
        private Label label6;
        private ComboBox cmbCategory;
        private Label labelkat;
        private NumericUpDown txtPrice;
        private NumericUpDown txtDescription;
        private TextBox txtBarcode;
        private Label label9;
        private RichTextBox richTextBox1;
        private NumericUpDown nudMaximumStock;
        private Label label8;
        private NumericUpDown nudMinimumStock;
        private Label label7;
    }
}
