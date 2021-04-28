
namespace ComputingEquipmentView
{
    partial class FormEquipmentSoftwareCreateUpd
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSoft = new System.Windows.Forms.Label();
            this.comboBoxSoft = new System.Windows.Forms.ComboBox();
            this.labelEquipment = new System.Windows.Forms.Label();
            this.comboBoxEquipment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(272, 157);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(165, 42);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(64, 157);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(165, 42);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelSoft
            // 
            this.labelSoft.AutoSize = true;
            this.labelSoft.Location = new System.Drawing.Point(37, 90);
            this.labelSoft.Name = "labelSoft";
            this.labelSoft.Size = new System.Drawing.Size(34, 20);
            this.labelSoft.TabIndex = 19;
            this.labelSoft.Text = "ПО:";
            // 
            // comboBoxSoft
            // 
            this.comboBoxSoft.FormattingEnabled = true;
            this.comboBoxSoft.Location = new System.Drawing.Point(37, 113);
            this.comboBoxSoft.Name = "comboBoxSoft";
            this.comboBoxSoft.Size = new System.Drawing.Size(439, 28);
            this.comboBoxSoft.TabIndex = 18;
            // 
            // labelEquipment
            // 
            this.labelEquipment.AutoSize = true;
            this.labelEquipment.Location = new System.Drawing.Point(36, 26);
            this.labelEquipment.Name = "labelEquipment";
            this.labelEquipment.Size = new System.Drawing.Size(68, 20);
            this.labelEquipment.TabIndex = 17;
            this.labelEquipment.Text = "Техника:";
            // 
            // comboBoxEquipment
            // 
            this.comboBoxEquipment.FormattingEnabled = true;
            this.comboBoxEquipment.Location = new System.Drawing.Point(36, 49);
            this.comboBoxEquipment.Name = "comboBoxEquipment";
            this.comboBoxEquipment.Size = new System.Drawing.Size(439, 28);
            this.comboBoxEquipment.TabIndex = 16;
            this.comboBoxEquipment.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // FormEquipmentSoftwareCreateUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 220);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelSoft);
            this.Controls.Add(this.comboBoxSoft);
            this.Controls.Add(this.labelEquipment);
            this.Controls.Add(this.comboBoxEquipment);
            this.Name = "FormEquipmentSoftwareCreateUpd";
            this.Text = "Установка ПО";
            this.Load += new System.EventHandler(this.FormEquipmentSoftwareCreateUpd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSoft;
        private System.Windows.Forms.ComboBox comboBoxSoft;
        private System.Windows.Forms.Label labelEquipment;
        private System.Windows.Forms.ComboBox comboBoxEquipment;
    }
}