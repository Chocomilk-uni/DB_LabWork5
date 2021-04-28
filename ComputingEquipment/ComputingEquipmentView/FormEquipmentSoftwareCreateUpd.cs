using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormEquipmentSoftwareCreateUpd : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly EquipmentLogic equipmentLogic;
        private readonly SoftwareLogic softwareLogic;
        private readonly EquipmentSoftwareLogic eqSoftLogic;

        public FormEquipmentSoftwareCreateUpd(EquipmentLogic equipmentLogic, SoftwareLogic softwareLogic, EquipmentSoftwareLogic eqSoftLogic)
        {
            InitializeComponent();
            this.equipmentLogic = equipmentLogic;
            this.softwareLogic = softwareLogic;
            this.eqSoftLogic = eqSoftLogic;
        }

        private void FormEquipmentSoftwareCreateUpd_Load(object sender, EventArgs e)
        {
            try
            {
                List<EquipmentViewModel> listEquipment = equipmentLogic.Read(null);
                List<SoftwareViewModel> listSoftware = softwareLogic.Read(null);

                if (listEquipment != null)
                {
                    comboBoxEquipment.DisplayMember = "Name";
                    comboBoxEquipment.ValueMember = "Id";
                    comboBoxEquipment.DataSource = listEquipment;
                    comboBoxEquipment.SelectedItem = null;
                }

                if (listSoftware != null)
                {
                    comboBoxSoft.DisplayMember = "Name";
                    comboBoxSoft.ValueMember = "Id";
                    comboBoxSoft.DataSource = listSoftware;
                    comboBoxSoft.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    try
                    {
                        EquipmentSoftwareViewModel view = eqSoftLogic.Read(new EquipmentSoftwareBindingModel { Id = id.Value })?[0];       

                        if (view != null)
                        {
                            comboBoxEquipment.SelectedValue = view.EquipmentId;
                            comboBoxSoft.SelectedValue = view.SoftwareId;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxEquipment.SelectedValue == null)
            {
                MessageBox.Show("Выберите образец вычислительной техники", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSoft.SelectedValue == null)
            {
                MessageBox.Show("Выберите ПО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                eqSoftLogic.CreateOrUpdate(new EquipmentSoftwareBindingModel
                {
                    Id = id,
                    EquipmentId = Convert.ToInt32(comboBoxEquipment.SelectedValue),
                    SoftwareId = Convert.ToInt32(comboBoxSoft.SelectedValue)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string type = ((EquipmentViewModel)e.ListItem).TypeName;
            string name = ((EquipmentViewModel)e.ListItem).Name;
            e.Value = type + " " + name;
        }
    }
}