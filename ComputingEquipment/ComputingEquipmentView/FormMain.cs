using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly EquipmentLogic equipmentLogic;

        public FormMain(EquipmentLogic equipmentLogic)
        {
            InitializeComponent();
            this.equipmentLogic = equipmentLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = equipmentLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[8].Visible = false;
                    dataGridView.Columns[9].Visible = false;
                    dataGridView.Columns[10].Visible = false;
                    dataGridView.Columns[2].Width = 500;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemEmployees_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEmployees>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemSuppliers_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSuppliers>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemTypes_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypes>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemSoft_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSoftware>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemSoftEq_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEquipmentSoftware>();
            form.ShowDialog();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            FormEquipment form = Container.Resolve<FormEquipment>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                FormEquipment form = Container.Resolve<FormEquipment>();
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
                        equipmentLogic.Delete(new EquipmentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonEqByDates_Click(object sender, EventArgs e)
        {
            FormEquipmentByDates form = Container.Resolve<FormEquipmentByDates>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}