
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
            txtPrice = new TextBox();
            txtStock = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnUpdate = new Button();
            dgvProducts = new DataGridView();
            btnListProduct = new Button();
            textBox1 = new TextBox();
            btnDelete = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // btnUrunKontrol
            // 
            btnUrunKontrol.Location = new Point(6, 130);
            btnUrunKontrol.Name = "btnUrunKontrol";
            btnUrunKontrol.Size = new Size(75, 23);
            btnUrunKontrol.TabIndex = 0;
            btnUrunKontrol.Text = "Ürün Ekle";
            btnUrunKontrol.UseVisualStyleBackColor = true;
            btnUrunKontrol.Click += btnUrunKontrol_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(82, 60);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 2;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(82, 98);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 5;
            label2.Text = "Ürün Fiyatı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 101);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Stok Miktarı";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnUrunKontrol);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 209);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Ekle";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(87, 130);
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
            dgvProducts.Location = new Point(262, 54);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(526, 349);
            dgvProducts.TabIndex = 8;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // btnListProduct
            // 
            btnListProduct.Location = new Point(262, 415);
            btnListProduct.Name = "btnListProduct";
            btnListProduct.Size = new Size(526, 23);
            btnListProduct.TabIndex = 7;
            btnListProduct.Text = "Ürün Listele";
            btnListProduct.UseVisualStyleBackColor = true;
            btnListProduct.Click += btnListProduct_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(262, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(526, 23);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(169, 130);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(btnListProduct);
            Controls.Add(dgvProducts);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnUrunKontrol;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private DataGridView dgvProducts;
        private Button btnListProduct;
        private TextBox textBox1;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
