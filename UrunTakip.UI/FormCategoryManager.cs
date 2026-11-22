using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrunTakip.Business;
using UrunTakip.Entities;

namespace UrunTakip.UI
{
    public partial class FormCategoryManager : Form
    {
        public FormCategoryManager()
        {
            InitializeComponent();
        }

        private void FormCategoryManager_Load(object sender, EventArgs e)
        {
            FillcomboboxUpCategory();
            GetCategory();
            clear();
        }

        public void AddCategory()
        {
            CategoryService servise = new CategoryService();
            int selectedUpCategoryidId = Convert.ToInt32(cmb_UpCategory.SelectedValue);
            string categoryName = servise.GetUpCategoryName(selectedUpCategoryidId);

            Category category = new Category()
            {
                Name = txt_categoryName.Text.ToString().Trim(),
                Description = txt_description.Text.ToString().Trim(),
                UpCategoryId = selectedUpCategoryidId,
                UpCategoryName = categoryName,
                isActive = Convert.ToBoolean(check_isActiv.Checked),
                CategoryCode = txt_categoryCode.Text.ToString().Trim(),



            };


            String result = servise.AddCategory(category);
            MessageBox.Show(result);
            GetCategory();
            FillcomboboxUpCategory();
        }
        public void GetCategory()
        {
            CategoryService service = new CategoryService();

            dgv_categoryList.DataSource = null;
            dgv_categoryList.DataSource = service.GetCategories();


            dgv_categoryList.Columns["Id"].HeaderText = "Ürün No";
            dgv_categoryList.Columns["Name"].HeaderText = "Kategori Adı";
            dgv_categoryList.Columns["UpCategoryName"].HeaderText = "Üst Kategori Adı";

            dgv_categoryList.Columns["UpCategoryId"].Visible = false;
            dgv_categoryList.Columns["Description"].HeaderText = "Açıklama";
            dgv_categoryList.Columns["isActive"].HeaderText = "Durum";
            dgv_categoryList.Columns["CategoryCode"].HeaderText = "Kategori Kodu";
            dgv_categoryList.Columns["CategoryLevel"].HeaderText = "Kategori Seviyesi";



        }
        public void FillcomboboxUpCategory()
        {
            CategoryService service = new CategoryService();
            var categories = service.GetCategories();

            // En başa eklenecek varsayılan seçenek
            var defaultCategory = new Category
            {
                Id = 0,
                Name = "-- YOK --"
            };

            // Listemizin en başına ekliyoruz 
            categories.Insert(0, defaultCategory);

            cmb_UpCategory.DataSource = null;
            cmb_UpCategory.DataSource = categories;

            cmb_UpCategory.DisplayMember = "Name";
            cmb_UpCategory.ValueMember = "Id";


            cmb_UpCategory.SelectedIndex = 0;




        }
        public void UpdateCategory()
        {
            Category category = new Category();
            CategoryService servise = new CategoryService();
            int selectedUpCategoryId = Convert.ToInt32(cmb_UpCategory.SelectedValue);

            string upCategoryName = selectedUpCategoryId == 0 ? null: servise.GetUpCategoryName(selectedUpCategoryId);

            if (dgv_categoryList.CurrentCell != null && dgv_categoryList.CurrentRow.Cells[0].Value != null)
            {
                int id = Convert.ToInt32(dgv_categoryList.CurrentRow.Cells["Id"].Value);
               


                category.Id = id;
                category.UpCategoryId = selectedUpCategoryId == 0 ? (int?)null : selectedUpCategoryId;
                 category.UpCategoryName = upCategoryName;
                category.Name = txt_categoryName.Text.ToString().Trim();
                category.Description = txt_description.Text.ToString();
                category.CategoryCode = txt_categoryCode.Text.ToString().ToUpper().Trim();
                category.isActive = check_isActiv.Checked;
               

               
                String result = servise.UpdateCategory(category);
               
                MessageBox.Show(result);
                GetCategory();
                clear();
            }
            else { MessageBox.Show("Önce Bir kategori Seçin"); }


        }
        public void clear()
        {
            dgv_categoryList.ClearSelection();
            txt_categoryCode.Clear();
            txt_categoryName.Clear();
            txt_description.Clear();
            cmb_UpCategory.SelectedIndex = 0;
            check_isActiv.Checked = false;

            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_clear.Enabled = false;

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            AddCategory();
            clear();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_clear.Enabled = false;

        }

        private void dgv_categoryList_SelectionChanged(object sender, EventArgs e)
        {

            // Tablo yüklenirken hata oluşmasını engelle
            if (dgv_categoryList.DataSource == null || dgv_categoryList.CurrentRow == null || dgv_categoryList.CurrentRow.IsNewRow) return;

            // Sütunlar henüz oluşmamışsa işlemi durdur
            if (!dgv_categoryList.Columns.Contains("Id") || !dgv_categoryList.Columns.Contains("Name") || !dgv_categoryList.Columns.Contains("UpCategoryId") || !dgv_categoryList.Columns.Contains("Description") || !dgv_categoryList.Columns.Contains("CategoryCode") || !dgv_categoryList.Columns.Contains("isActive"))
                return;

            DataGridViewRow row = dgv_categoryList.CurrentRow;

            if (row.Cells["Id"].Value == null)
                return;

            // Üst kategori boş olabilir
            object upCategory = row.Cells["UpCategoryId"].Value;

            if (upCategory == null || upCategory == DBNull.Value)
            {
                cmb_UpCategory.SelectedIndex = 0;
            }
            else
            {
                cmb_UpCategory.SelectedValue = Convert.ToInt32(upCategory);
            }

            // Kategori bilgilerini doldur
            txt_categoryName.Text = Convert.ToString(row.Cells["Name"].Value);
            txt_description.Text = Convert.ToString(row.Cells["Description"].Value);
            txt_categoryCode.Text = Convert.ToString(row.Cells["CategoryCode"].Value);

            check_isActiv.Checked = Convert.ToBoolean(row.Cells["isActive"].Value);

            // Butonları ayarla
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_clear.Enabled = true;
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {


            UpdateCategory();

        }
    }
}
