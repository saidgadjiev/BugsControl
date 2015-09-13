namespace Bugs_control
{
    partial class BaseForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.priorityBox = new System.Windows.Forms.ComboBox();
            this.reasonAppealBox = new System.Windows.Forms.ComboBox();
            this.typeAppealBox = new System.Windows.Forms.ComboBox();
            this.sectionFormsBox = new System.Windows.Forms.ComboBox();
            this.formsBox = new System.Windows.Forms.ComboBox();
            this.subsystemBox = new System.Windows.Forms.ComboBox();
            this.systemBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // priorityBox
            // 
            this.priorityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priorityBox.FormattingEnabled = true;
            this.priorityBox.Location = new System.Drawing.Point(91, 233);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(182, 21);
            this.priorityBox.TabIndex = 51;
            this.priorityBox.SelectedIndexChanged += new System.EventHandler(this.priorityBox_SelectedIndexChanged);
            // 
            // reasonAppealBox
            // 
            this.reasonAppealBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reasonAppealBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reasonAppealBox.FormattingEnabled = true;
            this.reasonAppealBox.Location = new System.Drawing.Point(91, 189);
            this.reasonAppealBox.Name = "reasonAppealBox";
            this.reasonAppealBox.Size = new System.Drawing.Size(182, 21);
            this.reasonAppealBox.TabIndex = 49;
            this.reasonAppealBox.SelectionChangeCommitted += new System.EventHandler(this.reasonAppealBox_SelectionChangeCommitted);
            // 
            // typeAppealBox
            // 
            this.typeAppealBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeAppealBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeAppealBox.FormattingEnabled = true;
            this.typeAppealBox.Location = new System.Drawing.Point(91, 167);
            this.typeAppealBox.Name = "typeAppealBox";
            this.typeAppealBox.Size = new System.Drawing.Size(182, 21);
            this.typeAppealBox.TabIndex = 48;
            this.typeAppealBox.SelectionChangeCommitted += new System.EventHandler(this.typeAppealBox_SelectionChangeCommitted);
            // 
            // sectionFormsBox
            // 
            this.sectionFormsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionFormsBox.Enabled = false;
            this.sectionFormsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sectionFormsBox.FormattingEnabled = true;
            this.sectionFormsBox.Location = new System.Drawing.Point(91, 129);
            this.sectionFormsBox.Name = "sectionFormsBox";
            this.sectionFormsBox.Size = new System.Drawing.Size(182, 21);
            this.sectionFormsBox.TabIndex = 47;
            this.sectionFormsBox.SelectionChangeCommitted += new System.EventHandler(this.sectionFormsBox_SelectionChangeCommitted);
            // 
            // formsBox
            // 
            this.formsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formsBox.Enabled = false;
            this.formsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formsBox.FormattingEnabled = true;
            this.formsBox.Location = new System.Drawing.Point(91, 107);
            this.formsBox.Name = "formsBox";
            this.formsBox.Size = new System.Drawing.Size(182, 21);
            this.formsBox.TabIndex = 46;
            this.formsBox.SelectionChangeCommitted += new System.EventHandler(this.formsBox_SelectionChangeCommitted);
            // 
            // subsystemBox
            // 
            this.subsystemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subsystemBox.Enabled = false;
            this.subsystemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subsystemBox.FormattingEnabled = true;
            this.subsystemBox.Location = new System.Drawing.Point(91, 85);
            this.subsystemBox.Name = "subsystemBox";
            this.subsystemBox.Size = new System.Drawing.Size(182, 21);
            this.subsystemBox.TabIndex = 45;
            this.subsystemBox.SelectionChangeCommitted += new System.EventHandler(this.subsystemBox_SelectionChangeCommitted);
            // 
            // systemBox
            // 
            this.systemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.systemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.systemBox.FormattingEnabled = true;
            this.systemBox.Location = new System.Drawing.Point(91, 63);
            this.systemBox.Name = "systemBox";
            this.systemBox.Size = new System.Drawing.Size(182, 21);
            this.systemBox.TabIndex = 44;
            this.systemBox.SelectionChangeCommitted += new System.EventHandler(this.systemBox_SelectionChangeCommitted);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 383);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.reasonAppealBox);
            this.Controls.Add(this.typeAppealBox);
            this.Controls.Add(this.sectionFormsBox);
            this.Controls.Add(this.formsBox);
            this.Controls.Add(this.subsystemBox);
            this.Controls.Add(this.systemBox);
            this.Name = "BaseForm";
            this.ShowIcon = false;
            this.Text = "Базовая форма";
            this.Controls.SetChildIndex(this.systemBox, 0);
            this.Controls.SetChildIndex(this.subsystemBox, 0);
            this.Controls.SetChildIndex(this.formsBox, 0);
            this.Controls.SetChildIndex(this.sectionFormsBox, 0);
            this.Controls.SetChildIndex(this.typeAppealBox, 0);
            this.Controls.SetChildIndex(this.reasonAppealBox, 0);
            this.Controls.SetChildIndex(this.priorityBox, 0);
            this.Controls.SetChildIndex(this.statusComboBox, 0);
            this.Controls.SetChildIndex(this.typeErrorBox, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ComboBox priorityBox;
        protected System.Windows.Forms.ComboBox reasonAppealBox;
        protected System.Windows.Forms.ComboBox typeAppealBox;
        protected System.Windows.Forms.ComboBox sectionFormsBox;
        protected System.Windows.Forms.ComboBox formsBox;
        protected System.Windows.Forms.ComboBox subsystemBox;
        protected System.Windows.Forms.ComboBox systemBox;
    }
}

