namespace UrunTakip.UI
{
    partial class FrmMain
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
            pnlSidebar = new Panel();
            btnSupplier = new Button();
            btnStockMovements = new Button();
            btnProductTracking = new Button();
            pnlContent = new Panel();
            tabModules = new TabControl();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.DarkGray;
            pnlSidebar.Controls.Add(btnSupplier);
            pnlSidebar.Controls.Add(btnStockMovements);
            pnlSidebar.Controls.Add(btnProductTracking);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(150, 450);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSupplier
            // 
            btnSupplier.Dock = DockStyle.Top;
            btnSupplier.Location = new Point(0, 70);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(150, 35);
            btnSupplier.TabIndex = 2;
            btnSupplier.Text = "Tedarikçi Yönetim";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnStockMovements
            // 
            btnStockMovements.Dock = DockStyle.Top;
            btnStockMovements.Location = new Point(0, 35);
            btnStockMovements.Name = "btnStockMovements";
            btnStockMovements.Size = new Size(150, 35);
            btnStockMovements.TabIndex = 1;
            btnStockMovements.Text = "Stok Hareketleri";
            btnStockMovements.UseVisualStyleBackColor = true;
            btnStockMovements.Click += btnStockMovements_Click;
            // 
            // btnProductTracking
            // 
            btnProductTracking.Dock = DockStyle.Top;
            btnProductTracking.Location = new Point(0, 0);
            btnProductTracking.Name = "btnProductTracking";
            btnProductTracking.Size = new Size(150, 35);
            btnProductTracking.TabIndex = 0;
            btnProductTracking.Text = "Ürün Takip";
            btnProductTracking.UseVisualStyleBackColor = true;
            btnProductTracking.Click += btnProductTracking_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(tabModules);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(150, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(650, 450);
            pnlContent.TabIndex = 1;
            // 
            // tabModules
            // 
            tabModules.Dock = DockStyle.Fill;
            tabModules.Location = new Point(0, 0);
            tabModules.Name = "tabModules";
            tabModules.SelectedIndex = 0;
            tabModules.Size = new Size(650, 450);
            tabModules.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "FrmMain";
            Text = "FrmMain";
            Load += FrmMain_Load;
            pnlSidebar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlContent;
        private TabControl tabModules;
        private Button btnProductTracking;
        private Button btnStockMovements;
        private Button btnSupplier;
    }
}