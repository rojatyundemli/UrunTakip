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
    public partial class FormDimensions : Form
    {
        public FormDimensions()
        {
            InitializeComponent();
        }

        private void FormDimensions_Load(object sender, EventArgs e)
        {
            getDimensions();
            FillcomboboxDimension();
            clear();
        }


        public void getDimensions()
        {
            DimensionsService dimensionsService = new DimensionsService();

            dgv_dimansionsList.DataSource = null;
            dgv_dimansionsList.DataSource = dimensionsService.GetDimensions();



            dgv_dimansionsList.Columns["Id"].HeaderText = "Tür No";
            dgv_dimansionsList.Columns["DimensionCode"].HeaderText = "Tür Kodu ";
            dgv_dimansionsList.Columns["DimensionName"].HeaderText = "Tür Adı";
            dgv_dimansionsList.Columns["BaseUnitName"].HeaderText = "Esas Birim";
            dgv_dimansionsList.Columns["BaseUnitId"].Visible = false;
            dgv_dimansionsList.Columns["Description"].HeaderText = "Açıklama";
            dgv_dimansionsList.Columns["IsActive"].HeaderText = "Durum";
            dgv_dimansionsList.Columns["CreatedAt"].HeaderText = "Oluşturulma Zamanı";
            dgv_dimansionsList.Columns["CreatedBy"].HeaderText = "Oluşturan Kişi";



        }
        public void fillBox()
        {
            if (dgv_dimansionsList.CurrentCell != null && dgv_dimansionsList.CurrentRow.Cells[0].Value != null)
            {
                int Id = Convert.ToInt32(dgv_dimansionsList.CurrentRow.Cells["Id"].Value.ToString());
                int? BaseUnitId = dgv_dimansionsList.CurrentRow.Cells["BaseUnitId"].Value == DBNull.Value || dgv_dimansionsList.CurrentRow.Cells["BaseUnitId"].Value == null ? null : Convert.ToInt32(dgv_dimansionsList.CurrentRow.Cells["BaseUnitId"].Value);
                String DimensionName = Convert.ToString(dgv_dimansionsList.CurrentRow.Cells["DimensionName"].Value.ToString());
                String DimensionCode = Convert.ToString(dgv_dimansionsList.CurrentRow.Cells["DimensionCode"].Value.ToString());
                String Description = Convert.ToString(dgv_dimansionsList.CurrentRow.Cells["Description"].Value.ToString());
                Boolean IsActive = Convert.ToBoolean(dgv_dimansionsList.CurrentRow.Cells["IsActive"].Value.ToString());

                txt_description.Text = Description;
                txt_dimensionsCode.Text = DimensionCode;
                txt_dimensionsName.Text = DimensionName;

                check_IsActive.Checked = IsActive;

                if (BaseUnitId.HasValue && cmb_BaseUnitId.Items.Count > 0)
                {
                    cmb_BaseUnitId.SelectedValue = BaseUnitId.Value;
                }
                else if (cmb_BaseUnitId.Items.Count > 0)
                {
                    cmb_BaseUnitId.SelectedIndex = 0;
                }
                else
                {
                    cmb_BaseUnitId.SelectedIndex = -1;
                }

            }


        }
        public void FillcomboboxDimension()
        {

            DimensionsService service = new DimensionsService();

            var measures = service.GetActiveUnitOfMeasure();

            if (measures == null)
                measures = new List<UnitOfMeasure>();

            measures.Insert(0, new UnitOfMeasure
            {
                Id = 0,
                UnitName = "Bir Ölçü Birimi Seçin"
            });

            cmb_BaseUnitId.DataSource = null;

            cmb_BaseUnitId.DisplayMember = "UnitName";
            cmb_BaseUnitId.ValueMember = "Id";

            cmb_BaseUnitId.DataSource = measures;

            if (cmb_BaseUnitId.Items.Count > 0)
                cmb_BaseUnitId.SelectedIndex = 0;
        }


        public void clear()
        {
            dgv_dimansionsList.ClearSelection();
            txt_description.Clear();
            txt_dimensionsCode.Clear();
            txt_dimensionsName.Clear();


            if (cmb_BaseUnitId.Items.Count > 0)
                cmb_BaseUnitId.SelectedIndex = 0;
            else
                cmb_BaseUnitId.SelectedIndex = -1;


            check_IsActive.Checked = false;

            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_clear.Enabled = false;

        }




        public void AddDimensions()
        {

           

            Dimensions dimensions = new Dimensions()
            {
                DimensionName = txt_dimensionsName.Text,
                DimensionCode = txt_dimensionsCode.Text,
                BaseUnitId = cmb_BaseUnitId.SelectedValue == null ? null : Convert.ToInt32(cmb_BaseUnitId.SelectedValue),

                Description = txt_description.Text.Trim(),
                IsActive = check_IsActive.Checked
            };

            DimensionsService service = new DimensionsService();
            String result = service.AddDimensions(dimensions);

            MessageBox.Show(result);
            getDimensions();

            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_clear.Enabled = false;

        }

        public void UpdateDimension()
        {
            int id = Convert.ToInt32(dgv_dimansionsList.CurrentRow.Cells["Id"].Value);
            int selectedId = Convert.ToInt32(cmb_BaseUnitId.SelectedValue);

            int? baseUnitId = selectedId == 0 ? null : selectedId;
            
            Dimensions dimensions = new Dimensions();
            dimensions.Id = id;
            dimensions.DimensionCode = txt_dimensionsCode.Text;
            dimensions.DimensionName = txt_dimensionsName.Text;
            dimensions.BaseUnitId = baseUnitId;
            dimensions.Description = txt_description.Text;
            dimensions.IsActive = check_IsActive.Checked;

            DimensionsService service = new DimensionsService();
            String result = service.UpdateDimensions(dimensions);
            MessageBox.Show(result);

            getDimensions();
            clear();

        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            AddDimensions();
        }

        private void dgv_dimansionsList_SelectionChanged(object sender, EventArgs e)
        {
            // Tablo yüklenirken veya boşken işlem yapma
            if (dgv_dimansionsList.DataSource == null ||
                dgv_dimansionsList.CurrentRow == null ||
                dgv_dimansionsList.CurrentRow.IsNewRow)
                return;

            // Sütunlar henüz oluşmamışsa işlem yapma
            if (!dgv_dimansionsList.Columns.Contains("Id") ||
                !dgv_dimansionsList.Columns.Contains("DimensionCode") ||
                !dgv_dimansionsList.Columns.Contains("DimensionName") ||
                !dgv_dimansionsList.Columns.Contains("BaseUnitId") ||
                !dgv_dimansionsList.Columns.Contains("Description") ||
                !dgv_dimansionsList.Columns.Contains("IsActive"))
                return;


            fillBox();

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
            UpdateDimension();
        }
    }
}
