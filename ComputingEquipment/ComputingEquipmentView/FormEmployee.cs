﻿using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputingEquipmentView
{
    public partial class FormEmployee : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;
        public int Id { set { id = value; } }

        private readonly EmployeeLogic employeeLogic;

        public FormEmployee(EmployeeLogic employeeLogic)
        {
            InitializeComponent();
            this.employeeLogic = employeeLogic;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EmployeeViewModel view = employeeLogic.Read(new EmployeeBindingModel { Id = id.Value })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
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
                MessageBox.Show("Заполните поле \"ФИО\" ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                employeeLogic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text
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