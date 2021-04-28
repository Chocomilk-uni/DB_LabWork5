using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormSoftwareCreateUpd : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly SoftwareLogic softwareLogic;

        public FormSoftwareCreateUpd(SoftwareLogic softwareLogic)
        {
            InitializeComponent();
            this.softwareLogic = softwareLogic;
        }

        private void FormSoftwareCreateUpd_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SoftwareViewModel view = softwareLogic.Read(new SoftwareBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxLicense.Text = view.License_type;
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле \"Название\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxLicense.Text))
            {
                MessageBox.Show("Заполните поле \"Тип лицензии\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                softwareLogic.CreateOrUpdate(new SoftwareBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    License_type = textBoxLicense.Text
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