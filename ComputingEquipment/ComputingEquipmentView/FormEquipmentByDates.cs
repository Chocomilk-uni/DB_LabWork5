using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormEquipmentByDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly EquipmentLogic equipmentLogic;

        public FormEquipmentByDates(EquipmentLogic equipmentLogic)
        {
            InitializeComponent();
            this.equipmentLogic = equipmentLogic;
        }

        private void ButtonForm_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView.Rows.Clear();

            try
            {
                var listEquipment = equipmentLogic.Read(new EquipmentBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                dataGridView.DataSource = listEquipment;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[2].Width = 500;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}