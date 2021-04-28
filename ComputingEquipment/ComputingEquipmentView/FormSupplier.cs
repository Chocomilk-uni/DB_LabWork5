using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormSupplier : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly SupplierLogic supplierLogic;

        public FormSupplier(SupplierLogic supplierLogic)
        {
            InitializeComponent();
            this.supplierLogic = supplierLogic;
        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SupplierViewModel view = supplierLogic.Read(new SupplierBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxOrgName.Text = view.OrganizationName;
                        textBoxEmpName.Text = view.EmployeeName;
                        textBoxAddress.Text = view.Address;
                        textBoxPhone.Text = view.PhoneNumber;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOrgName.Text))
            {
                MessageBox.Show("Заполните поле \"Название организации\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmpName.Text))
            {
                MessageBox.Show("Заполните поле \"ФИО работника\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("Заполните поле \"Адрес\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                MessageBox.Show("Заполните поле \"Номер телефона\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                supplierLogic.CreateOrUpdate(new SupplierBindingModel
                {
                    Id = id,
                    OrganizationName = textBoxOrgName.Text,
                    EmployeeName = textBoxEmpName.Text,
                    PhoneNumber = textBoxPhone.Text
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