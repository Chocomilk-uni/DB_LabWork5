using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormEquipmentSoftware : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly EquipmentSoftwareLogic eqSoftLogic;

        public FormEquipmentSoftware(EquipmentSoftwareLogic eqSoftLogic)
        {
            InitializeComponent();
            this.eqSoftLogic = eqSoftLogic;
        }

        private void FormEquipmentSoftware_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var eqSoftList = eqSoftLogic.Read(null);

                if (eqSoftList != null)
                {
                    dataGridView.DataSource = eqSoftList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Width = 170;
                    dataGridView.Columns[4].Width = 170;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            FormEquipmentSoftwareCreateUpd form = Container.Resolve<FormEquipmentSoftwareCreateUpd>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormEquipmentSoftwareCreateUpd form = Container.Resolve<FormEquipmentSoftwareCreateUpd>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        eqSoftLogic.Delete(new EquipmentSoftwareBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonFindByName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле \"Наименование техники\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var list = eqSoftLogic.Read(new EquipmentSoftwareBindingModel
                {
                    EquipmentName = textBoxName.Text
                });
                dataGridView.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}