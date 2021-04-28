
namespace ComputingEquipmentView
{
    partial class FormEquipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxSpecif = new System.Windows.Forms.TextBox();
            this.labelSpecif = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.labelState = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(25, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(119, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Наименование:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(25, 45);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(439, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(25, 296);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(439, 28);
            this.comboBoxType.TabIndex = 2;
            // 
            // textBoxSpecif
            // 
            this.textBoxSpecif.Location = new System.Drawing.Point(25, 108);
            this.textBoxSpecif.Name = "textBoxSpecif";
            this.textBoxSpecif.Size = new System.Drawing.Size(439, 27);
            this.textBoxSpecif.TabIndex = 4;
            // 
            // labelSpecif
            // 
            this.labelSpecif.AutoSize = true;
            this.labelSpecif.Location = new System.Drawing.Point(25, 85);
            this.labelSpecif.Name = "labelSpecif";
            this.labelSpecif.Size = new System.Drawing.Size(123, 20);
            this.labelSpecif.TabIndex = 3;
            this.labelSpecif.Text = "Характеристики:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(25, 148);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(123, 20);
            this.labelDate.TabIndex = 5;
            this.labelDate.Text = "Дата получения:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(25, 172);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(439, 27);
            this.dateTimePicker.TabIndex = 6;
            // 
            // textBoxState
            // 
            this.textBoxState.Location = new System.Drawing.Point(25, 233);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(439, 27);
            this.textBoxState.TabIndex = 8;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(25, 212);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(86, 20);
            this.labelState.TabIndex = 7;
            this.labelState.Text = "Состояние:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(25, 273);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(38, 20);
            this.labelType.TabIndex = 9;
            this.labelType.Text = "Тип:";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Location = new System.Drawing.Point(25, 336);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(85, 20);
            this.labelEmployee.TabIndex = 11;
            this.labelEmployee.Text = "Сотрудник:";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(25, 359);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(439, 28);
            this.comboBoxEmployee.TabIndex = 10;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Location = new System.Drawing.Point(26, 400);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(89, 20);
            this.labelSupplier.TabIndex = 13;
            this.labelSupplier.Text = "Поставщик:";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(26, 423);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(439, 28);
            this.comboBoxSupplier.TabIndex = 12;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(53, 467);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(165, 42);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(261, 467);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(165, 42);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 520);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.textBoxSpecif);
            this.Controls.Add(this.labelSpecif);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "FormEquipment";
            this.Text = "Экземпляр вычисительной техники";
            this.Load += new System.EventHandler(this.FormEquipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxSpecif;
        private System.Windows.Forms.Label labelSpecif;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}