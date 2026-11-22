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
    public partial class FormUnitsOfMeasure : Form
    {
        public FormUnitsOfMeasure()
        {
            InitializeComponent();
        }
        private void FormUnitsOfMeasure_Load(object sender, EventArgs e)
        {
            FillcomboboxDimension();
            GetMeasure();
            clear();
        }
        public void FillcomboboxDimension()
        {
            UnitOfMeasureService service = new UnitOfMeasureService();
            var measures = service.GetActiveDimension();


            // En başa eklenecek varsayılan seçenek
            var defaultDimension = new Dimensions
            {
                Id = 0,
                DimensionName = "Bir Ölçü Türü Seçin"
            };

            // Listemizin en başına ekliyoruz 
            measures.Insert(0, defaultDimension);


            cmb_Dimensions.DisplayMember = "DimensionName";
            cmb_Dimensions.ValueMember = "Id";

            cmb_Dimensions.DataSource = null;
            cmb_Dimensions.DataSource = measures;

            cmb_Dimensions.SelectedIndex = 0;







        }

        public void SaveMeasure()
        {
            if (cmb_Dimensions.SelectedValue == null ||Convert.ToInt32(cmb_Dimensions.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir ölçü türü seçin.");
                return;
            }

            UnitOfMeasure unitOfMeasure = new UnitOfMeasure()
            {
                UnitName = txt_unitName.Text.Trim(),
                UnitCode = txt_unitCode.Text.Trim(),
                DecimalPlaces = Convert.ToInt32(nmrc_Deciminal.Value),
                DimensionId = Convert.ToInt32(cmb_Dimensions.SelectedValue),
                IsActive = check_IsActive.Checked,


            };

            UnitOfMeasureService service = new UnitOfMeasureService();

            String result = service.AddUnitOfMeasure(unitOfMeasure);
            MessageBox.Show(result);

            clear();
            GetMeasure();
        }
        public void UpdateMasure()
        {

            UnitOfMeasure measure = new UnitOfMeasure();
            UnitOfMeasureService measureService = new UnitOfMeasureService();
            int dimensionId = Convert.ToInt32(cmb_Dimensions.SelectedValue);
            string? dimensionName = cmb_Dimensions.SelectedIndex == 0 ? null : cmb_Dimensions.Text.Trim();

            if (dgv_UnitList.CurrentCell != null && dgv_UnitList.CurrentRow.Cells[0].Value != null)
            {
                int id = Convert.ToInt32(dgv_UnitList.CurrentRow.Cells["Id"].Value);

                measure.Id = id;
                measure.DimensionId = dimensionId;
                measure.DimensionName = dimensionName;
                measure.UnitName = txt_unitName.Text.Trim();
                measure.UnitCode = txt_unitName.Text.Trim();
                measure.DecimalPlaces = Convert.ToInt32(nmrc_Deciminal.Value);
                measure.IsActive = (check_IsActive.Checked);

                String result = measureService.UpdateUnitOfMeasure(measure);



                MessageBox.Show(result);

                GetMeasure();
                clear();


            }



        }
        public void GetMeasure()
        {
            UnitOfMeasureService service = new UnitOfMeasureService();
            dgv_UnitList.DataSource = null;
            dgv_UnitList.DataSource = service.GetUnitOfMeasure();

            dgv_UnitList.Columns["Id"].HeaderText = "Birim No";
            dgv_UnitList.Columns["UnitCode"].HeaderText = "Birim Kodu";
            dgv_UnitList.Columns["UnitName"].HeaderText = "Birim Adı";
            dgv_UnitList.Columns["DimensionId"].Visible = false;
            dgv_UnitList.Columns["DimensionName"].HeaderText = "Tür Adı";
            dgv_UnitList.Columns["DecimalPlaces"].HeaderText = "Ondalık Hassasiyeti";
            dgv_UnitList.Columns["IsActive"].HeaderText = "Durum";
            dgv_UnitList.Columns["CreatedAt"].HeaderText = "Oluşturulma Zamanı";
            dgv_UnitList.Columns["UpdatedAt"].HeaderText = "Güncelleme Zamanı";


        }

        public void clear()
        {
            dgv_UnitList.ClearSelection();
            txt_unitCode.Clear();
            txt_unitName.Clear();

            cmb_Dimensions.SelectedIndex = 0;
            check_IsActive.Checked = false;

            btn_Save.Enabled = true;
            btn_Update.Enabled = false;
            btn_clear.Enabled = false;

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveMeasure();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateMasure();

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dgv_UnitList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_UnitList.DataSource == null || dgv_UnitList.CurrentRow == null || dgv_UnitList.CurrentRow.IsNewRow) return;

            // Sütunlar henüz oluşmamışsa işlemi durdur
            if (!dgv_UnitList.Columns.Contains("Id") || !dgv_UnitList.Columns.Contains("UnitCode") || !dgv_UnitList.Columns.Contains("UnitName") || !dgv_UnitList.Columns.Contains("DimensionId") || !dgv_UnitList.Columns.Contains("DimensionName") || !dgv_UnitList.Columns.Contains("DecimalPlaces") || !dgv_UnitList.Columns.Contains("IsActive") || !dgv_UnitList.Columns.Contains("CreatedAt") || !dgv_UnitList.Columns.Contains("UpdatedAt"))
                return;

            DataGridViewRow row = dgv_UnitList.CurrentRow;

            if (row.Cells["Id"].Value == null)
                return;

            
            object dimensionsId = row.Cells["DimensionId"].Value;

            txt_unitName.Text = Convert.ToString(row.Cells["UnitName"].Value);
            txt_unitCode.Text = Convert.ToString(row.Cells["UnitCode"].Value);
            cmb_Dimensions.SelectedValue = Convert.ToInt32(dimensionsId);
            nmrc_Deciminal.Value = Convert.ToDecimal(row.Cells["DecimalPlaces"].Value);
            check_IsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);


            btn_Save.Enabled = false;
            btn_Update.Enabled = true;
            btn_clear.Enabled = true;
            

        }
    }
}
