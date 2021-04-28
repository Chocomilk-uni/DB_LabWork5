using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormEquipment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly EquipmentLogic equipmentLogic;
        private readonly TypeLogic typeLogic;
        private readonly EmployeeLogic employeeLogic;
        private readonly SupplierLogic supplierLogic;

        public FormEquipment(TypeLogic typeLogic, EmployeeLogic employeeLogic, SupplierLogic supplierLogic, EquipmentLogic equipmentLogic)
        {
            InitializeComponent();
            this.typeLogic = typeLogic;
            this.employeeLogic = employeeLogic;
            this.supplierLogic = supplierLogic;
            this.equipmentLogic = equipmentLogic;
        }

        private void FormEquipment_Load(object sender, EventArgs e)
        {
            try
            {
                List<EmployeeViewModel> listEmployees = employeeLogic.Read(null);
                List<TypeViewModel> listTypes = typeLogic.Read(null);
                List<SupplierViewModel> listSuppliers = supplierLogic.Read(null);

                if (listEmployees != null)
                {
                    comboBoxEmployee.DisplayMember = "Name";
                    comboBoxEmployee.ValueMember = "Id";
                    comboBoxEmployee.DataSource = listEmployees;
                    comboBoxEmployee.SelectedItem = null;
                }

                if (listTypes != null)
                {
                    comboBoxType.DisplayMember = "Name";
                    comboBoxType.ValueMember = "Id";
                    comboBoxType.DataSource = listTypes;
                    comboBoxType.SelectedItem = null;
                }

                if (listSuppliers != null)
                {
                    comboBoxSupplier.DisplayMember = "OrganizationName";
                    comboBoxSupplier.ValueMember = "Id";
                    comboBoxSupplier.DataSource = listSuppliers;
                    comboBoxSupplier.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    try
                    {
                        EquipmentViewModel view = equipmentLogic.Read(new EquipmentBindingModel { Id = id.Value })?[0];

                        if (view != null)
                        {
                            textBoxName.Text = view.Name;
                            textBoxSpecif.Text = view.Specifications;
                            textBoxState.Text = view.State;
                            dateTimePicker.Value = view.ReceiptDate;
                            comboBoxType.SelectedValue = view.TypeId;
                            comboBoxEmployee.SelectedValue = view.EmployeeId;
                            comboBoxSupplier.SelectedValue = view.SupplierId;
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле \"Наименование\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSpecif.Text))
            {
                MessageBox.Show("Заполните поле \"Характеристики\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxState.Text))
            {
                MessageBox.Show("Заполните поле \"Состояние\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxType.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип вычислительной техники", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSupplier.SelectedValue == null)
            {
                MessageBox.Show("Выберите поставщика вычислительной техники", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите работника, отвественного за данный экземпляр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                equipmentLogic.CreateOrUpdate(new EquipmentBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Specifications = textBoxSpecif.Text,
                    State = textBoxState.Text,
                    ReceiptDate = dateTimePicker.Value,
                    EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue),
                    SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                    TypeId = Convert.ToInt32(comboBoxType.SelectedValue)
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
    }
}