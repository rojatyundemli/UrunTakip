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
            btn_salesOrder = new Button();
            btn_Customer = new Button();
            btn_GoofReciept = new Button();
            btn_PurchaseOrders = new Button();
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
            pnlSidebar.Controls.Add(btn_salesOrder);
            pnlSidebar.Controls.Add(btn_Customer);
            pnlSidebar.Controls.Add(btn_GoofReciept);
            pnlSidebar.Controls.Add(btn_PurchaseOrders);
            pnlSidebar.Controls.Add(btnSupplier);
            pnlSidebar.Controls.Add(btnStockMovements);
            pnlSidebar.Controls.Add(btnProductTracking);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(150, 450);
            pnlSidebar.TabIndex = 0;
            // 
            // btn_salesOrder
            // 
            btn_salesOrder.Dock = DockStyle.Top;
            btn_salesOrder.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btn_salesOrder.Location = new Point(0, 210);
            btn_salesOrder.Name = "btn_salesOrder";
            btn_salesOrder.Size = new Size(150, 35);
            btn_salesOrder.TabIndex = 7;
            btn_salesOrder.Text = "Satış Yönetimi";
            btn_salesOrder.UseVisualStyleBackColor = true;
            btn_salesOrder.Click += btn_salesOrder_Click;
            // 
            // btn_Customer
            // 
            btn_Customer.Dock = DockStyle.Top;
            btn_Customer.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btn_Customer.Location = new Point(0, 175);
            btn_Customer.Name = "btn_Customer";
            btn_Customer.Size = new Size(150, 35);
            btn_Customer.TabIndex = 6;
            btn_Customer.Text = "Müşteri Yönetimi";
            btn_Customer.UseVisualStyleBackColor = true;
            btn_Customer.Click += btn_Customer_Click;
            // 
            // btn_GoofReciept
            // 
            btn_GoofReciept.Dock = DockStyle.Top;
            btn_GoofReciept.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btn_GoofReciept.Location = new Point(0, 140);
            btn_GoofReciept.Name = "btn_GoofReciept";
            btn_GoofReciept.Size = new Size(150, 35);
            btn_GoofReciept.TabIndex = 5;
            btn_GoofReciept.Text = "Mal Kabul";
            btn_GoofReciept.UseVisualStyleBackColor = true;
            btn_GoofReciept.Click += btn_GoofReciept_Click;
            // 
            // btn_PurchaseOrders
            // 
            btn_PurchaseOrders.Dock = DockStyle.Top;
            btn_PurchaseOrders.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btn_PurchaseOrders.Location = new Point(0, 105);
            btn_PurchaseOrders.Name = "btn_PurchaseOrders";
            btn_PurchaseOrders.Size = new Size(150, 35);
            btn_PurchaseOrders.TabIndex = 4;
            btn_PurchaseOrders.Text = "Sipariş Yönetimi";
            btn_PurchaseOrders.UseVisualStyleBackColor = true;
            btn_PurchaseOrders.Click += btn_PurchaseOrders_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Dock = DockStyle.Top;
            btnSupplier.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
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
            btnStockMovements.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
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
            btnProductTracking.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
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
            tabModules.SelectedIndexChanged += tabModules_SelectedIndexChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMain";
            WindowState = FormWindowState.Maximized;
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
        private Button btn_PurchaseOrders;
        private Button btn_GoofReciept;
        private Button btn_Customer;
        private Button btn_salesOrder;
    }
}