using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UrunTakip.Business;
using UrunTakip.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UrunTakip.UI
{
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                SupplierName = txt_SupplierName.Text,
                ContactPerson = txt_officalPerson.Text,
                Phone = txt_tel.Text,
                Email = txt_eposta.Text,
                TaxOffice = txt_taxOffice.Text,
                TaxNumber = txt_taxNumber.Text,
                Address = txt_adres.Text,
                Description = txt_descraption.Text
            };

            SupplierService supplierService = new SupplierService();
            string result = supplierService.AddSupplier(supplier);

            LoadSupplierList();

            MessageBox.Show(result);



        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                Id = Convert.ToInt32(dgvSupplierList.CurrentRow.Cells[0].Value),
                SupplierName = txt_SupplierName.Text,
                ContactPerson = txt_officalPerson.Text,
                Phone = txt_tel.Text,
                Email = txt_eposta.Text,
                TaxOffice = txt_taxOffice.Text,
                TaxNumber = txt_taxNumber.Text,
                Address = txt_adres.Text,
                Description = txt_descraption.Text
            };

            SupplierService supplierService = new SupplierService();
            string result = supplierService.UpdateSupplier(supplier);
            MessageBox.Show(result);

            btn_deActive.Visible = false;
            btn_update.Visible = false;

            txt_adres.Clear();
            txt_descraption.Clear();
            txt_eposta.Clear();
            txt_officalPerson.Clear();
            txt_SupplierName.Clear();
            txt_taxNumber.Clear();
            txt_tel.Clear();
            txt_taxOffice.Clear();

            LoadSupplierList();


        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            btn_deActive.Visible = false;
            btn_update.Visible = false;

            LoadSupplierList();
        }

        private void btn_deActive_Click(object sender, EventArgs e)
        {
            if (dgvSupplierList.CurrentCell != null && dgvSupplierList.CurrentRow.Cells[0].Value != null)
            {
                int Id = Convert.ToInt32(dgvSupplierList.CurrentRow.Cells[0].Value);

                SupplierService supplierService = new SupplierService();
                string result = supplierService.DeleteSupplier(Id);
                LoadSupplierList();
                MessageBox.Show(result);

            }
        }






        public void LoadSupplierList()
        {

            try
            {
                SupplierService service = new SupplierService();

                dgvSupplierList.DataSource = null;
                dgvSupplierList.DataSource = service.GetAllSuppliers();



                // Sütun başlıklarını Türkçeleştir
                dgvSupplierList.Columns["Id"].HeaderText = "Tedarikçi No";
                dgvSupplierList.Columns["SupplierName"].HeaderText = "Tedarikçi Adı";
                dgvSupplierList.Columns["ContactPerson"].HeaderText = "Yetkili Kişi";
                dgvSupplierList.Columns["Phone"].HeaderText = "Telefon";
                dgvSupplierList.Columns["Email"].HeaderText = "E-posta";
                dgvSupplierList.Columns["TaxOffice"].HeaderText = "Vergi Dairesi";
                dgvSupplierList.Columns["TaxNumber"].HeaderText = "Vergi Numarası";
                dgvSupplierList.Columns["Address"].HeaderText = "Adres";
                dgvSupplierList.Columns["Description"].HeaderText = "Açıklama";


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Tedarikçiler listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void dgvSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSupplierList.CurrentCell != null && dgvSupplierList.CurrentRow.Cells[0].Value != null)

            {
                btn_deActive.Visible = true;
                btn_update.Visible = true;





                txt_SupplierName.Text = dgvSupplierList.CurrentRow.Cells[1].Value.ToString();
                txt_officalPerson.Text = dgvSupplierList.CurrentRow.Cells[2].Value.ToString();
                txt_tel.Text = dgvSupplierList.CurrentRow.Cells[3].Value.ToString();
                txt_eposta.Text = dgvSupplierList.CurrentRow.Cells[4].Value.ToString();
                txt_taxOffice.Text = dgvSupplierList.CurrentRow.Cells[5].Value.ToString();
                txt_taxNumber.Text = dgvSupplierList.CurrentRow.Cells[6].Value.ToString();
                txt_adres.Text = dgvSupplierList.CurrentRow.Cells[7].Value.ToString();
                txt_descraption.Text = dgvSupplierList.CurrentRow.Cells[8].Value.ToString();

            }
            else
            {
                txt_SupplierName.Text = "";
                txt_officalPerson.Text = "";
                txt_tel.Text = "";
                txt_eposta.Text = "";
                txt_taxOffice.Text = "";
                txt_taxNumber.Text = "";
                txt_adres.Text = "";
                txt_descraption.Text = "";



                btn_deActive.Visible = false;
                btn_update.Visible = false;



            }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SupplierService service = new SupplierService();
                String text = kryptonTextBox1.Text.Trim();
                dgvSupplierList.DataSource = null;
                dgvSupplierList.DataSource = service.GetWithSearch(text);

                // Sütun başlıklarını Türkçeleştir
                dgvSupplierList.Columns["Id"].HeaderText = "Tedarikçi No";
                dgvSupplierList.Columns["SupplierName"].HeaderText = "Tedarikçi Adı";
                dgvSupplierList.Columns["ContactPerson"].HeaderText = "Yetkili Kişi";
                dgvSupplierList.Columns["Phone"].HeaderText = "Telefon";
                dgvSupplierList.Columns["Email"].HeaderText = "E-posta";
                dgvSupplierList.Columns["TaxOffice"].HeaderText = "Vergi Dairesi";
                dgvSupplierList.Columns["TaxNumber"].HeaderText = "Vergi Numarası";
                dgvSupplierList.Columns["Address"].HeaderText = "Adres";
                dgvSupplierList.Columns["Description"].HeaderText = "Açıklama";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Tedarikçiler listelenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
