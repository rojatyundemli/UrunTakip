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

namespace UrunTakip.UI
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            check_isActive.Checked = true;
            loadCustomerList();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                CustomerName = txt_CustomerName.Text,
                ContactName = txt_ContactName.Text,
                Phone = txt_tel.Text,
                Email = txt_eposta.Text,
                TaxOffice = txt_taxOffice.Text,
                TaxNumber = txt_taxNumber.Text,
                City = txt_City.Text,
                District = txt_District.Text,
                Address = txt_adres.Text,
                IsActive = check_isActive.Checked,
                CreatedAt = DateTime.Now
            };

            CustomerService Service = new CustomerService();
            String result = Service.AddCustommer(customer);

            if (result == "Müşteri başarıyla eklendi.")
            {
                txt_CustomerName.Clear();
                txt_ContactName.Clear();
                txt_eposta.Clear();
                txt_tel.Clear();
                txt_City.Clear();
                txt_District.Clear();
                txt_taxNumber.Clear();
                txt_taxOffice.Clear();
                txt_adres.Clear();
                check_isActive.Checked = true;

                loadCustomerList();
            }

            MessageBox.Show(result);
        }

        private void loadCustomerList()
        {
            try
            {
                CustomerService service = new CustomerService();
                dgv_ListCustomer.DataSource = null;
                dgv_ListCustomer.DataSource = service.GetAllCustomers();
                dgv_ListCustomer.Columns["Id"].ReadOnly = true; dgv_ListCustomer.Columns["Id"].HeaderText = "Müşteri ID";
                dgv_ListCustomer.Columns["CustomerName"].ReadOnly = true; dgv_ListCustomer.Columns["CustomerName"].HeaderText = "Müşteri Adı";
                dgv_ListCustomer.Columns["ContactName"].ReadOnly = true; dgv_ListCustomer.Columns["ContactName"].HeaderText = "İletişim Adı";
                dgv_ListCustomer.Columns["Phone"].ReadOnly = true; dgv_ListCustomer.Columns["Phone"].HeaderText = "Telefon";
                dgv_ListCustomer.Columns["Email"].ReadOnly = true; dgv_ListCustomer.Columns["Email"].HeaderText = "E-posta";
                dgv_ListCustomer.Columns["TaxOffice"].ReadOnly = true; dgv_ListCustomer.Columns["TaxOffice"].HeaderText = "Vergi Dairesi";
                dgv_ListCustomer.Columns["TaxNumber"].ReadOnly = true; dgv_ListCustomer.Columns["TaxNumber"].HeaderText = "Vergi Numarası";
                dgv_ListCustomer.Columns["City"].ReadOnly = true; dgv_ListCustomer.Columns["City"].HeaderText = "Şehir";
                dgv_ListCustomer.Columns["District"].ReadOnly = true; dgv_ListCustomer.Columns["District"].HeaderText = "İlçe";
                dgv_ListCustomer.Columns["Address"].ReadOnly = true; dgv_ListCustomer.Columns["Address"].HeaderText = "Adres";
                dgv_ListCustomer.Columns["IsActive"].ReadOnly = true; dgv_ListCustomer.Columns["IsActive"].HeaderText = "Aktif Mi?";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dgv_ListCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ListCustomer.CurrentCell != null && dgv_ListCustomer.CurrentRow.Cells[0].Value != null)
            {

                String CustomerName = dgv_ListCustomer.CurrentRow.Cells[1].Value.ToString();
                String ContactName = dgv_ListCustomer.CurrentRow.Cells[2].Value.ToString();
                String Phone = dgv_ListCustomer.CurrentRow.Cells[3].Value.ToString();
                String Email = dgv_ListCustomer.CurrentRow.Cells[4].Value.ToString();
                String TaxOffice = dgv_ListCustomer.CurrentRow.Cells[5].Value.ToString();
                String TaxNumber = dgv_ListCustomer.CurrentRow.Cells[6].Value.ToString();
                String City = dgv_ListCustomer.CurrentRow.Cells[7].Value.ToString();
                String District = dgv_ListCustomer.CurrentRow.Cells[8].Value.ToString();
                String Address = dgv_ListCustomer.CurrentRow.Cells[9].Value.ToString();
                bool IsActive = Convert.ToBoolean(dgv_ListCustomer.CurrentRow.Cells[10].Value);
                txt_CustomerName.Text = CustomerName;
                txt_ContactName.Text = ContactName;
                txt_tel.Text = Phone;
                txt_eposta.Text = Email;
                txt_taxOffice.Text = TaxOffice;
                txt_taxNumber.Text = TaxNumber;
                txt_City.Text = City;
                txt_District.Text = District;
                txt_adres.Text = Address;
                check_isActive.Checked = IsActive;
            }
            else
            {
                txt_CustomerName.Clear();
                txt_ContactName.Clear();
                txt_tel.Clear();
                txt_eposta.Clear();
                txt_taxOffice.Clear();
                txt_taxNumber.Clear();
                txt_City.Clear();
                txt_District.Clear();
                txt_adres.Clear();
                check_isActive.Checked = true;

            }






        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try 
            {
                if (dgv_ListCustomer.CurrentCell != null && dgv_ListCustomer.CurrentRow.Cells[0].Value != null) 
                {
                    Customer customer = new Customer()
                    {
                        Id = Convert.ToInt32(dgv_ListCustomer.CurrentRow.Cells[0].Value),
                        CustomerName = txt_CustomerName.Text,
                        ContactName = txt_ContactName.Text,
                        Phone = txt_tel.Text,
                        Email = txt_eposta.Text,
                        TaxOffice = txt_taxOffice.Text,
                        TaxNumber = txt_taxNumber.Text,
                        City = txt_City.Text,
                        District = txt_District.Text,
                        Address = txt_adres.Text,
                        IsActive = check_isActive.Checked



                    }; 
                  CustomerService service = new CustomerService();
                    String result = service.updateCustomer(customer);

                    if (result == "Müşteri başarıyla güncellendi.")
                    {
                        MessageBox.Show(result);
                        loadCustomerList();
                    }
                    MessageBox.Show(result);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncellenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
