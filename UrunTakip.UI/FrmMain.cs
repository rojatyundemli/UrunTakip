using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakip.UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }



        private void OpenModule(string moduleKey, string tabTitle, Func<Form> createForm)
        {
            // 1. Modül zaten açık mı diye kontrol et.
            foreach (TabPage page in tabModules.TabPages)
            {
                if (page.Tag?.ToString() == moduleKey)
                {
                    // Açık sekmeyi tekrar seç.
                    tabModules.SelectedTab = page;
                    return;
                }
            }

            // 2. Açık değilse formu oluştur.
            Form moduleForm = createForm();

            // 3. Formu sekme içinde göstermek için ayarla.
            moduleForm.TopLevel = false;
            moduleForm.FormBorderStyle = FormBorderStyle.None;
            moduleForm.Dock = DockStyle.Fill;

            // 4. Yeni sekme oluştur.
            TabPage newPage = new TabPage(tabTitle);
            newPage.Tag = moduleKey;

            // 5. Formu sekmenin içine yerleştir.
            newPage.Controls.Add(moduleForm);

            // 6. Sekmeyi ekle ve seç.
            tabModules.TabPages.Add(newPage);
            tabModules.SelectedTab = newPage;

            // 7. Formu göster.
            moduleForm.Show();
        }

        private void btnProductTracking_Click(object sender, EventArgs e)
        {
            OpenModule("Product_Tracking", "Ürün Takibi", () => new Form1());
        }

        private void btnStockMovements_Click(object sender, EventArgs e)
        {
            OpenModule("Stock_Movements", "Stok Hareketleri", () => new FormStockMovement());
        }



        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenModule("Supplier", "Tedarikçi Yönetimi", () => new FormSupplier());
        }
    }



}
