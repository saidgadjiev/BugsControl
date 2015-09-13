namespace Bugs_control
{
    partial class AddActionForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.descripActionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.typeErrorLabel = new System.Windows.Forms.Label();
            this.executorBox = new System.Windows.Forms.ComboBox();
            this.executorLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeErrorBox
            // 
            this.typeErrorBox.Location = new System.Drawing.Point(110, 108);
            // 
            // statusComboBox
            // 
            this.statusComboBox.Location = new System.Drawing.Point(110, 44);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(459, 362);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(18, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Описание выполненных действий *";
            // 
            // descripActionRichTextBox
            // 
            this.descripActionRichTextBox.Location = new System.Drawing.Point(21, 168);
            this.descripActionRichTextBox.Name = "descripActionRichTextBox";
            this.descripActionRichTextBox.Size = new System.Drawing.Size(364, 195);
            this.descripActionRichTextBox.TabIndex = 23;
            this.descripActionRichTextBox.Text = "";
            // 
            // typeErrorLabel
            // 
            this.typeErrorLabel.AutoSize = true;
            this.typeErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeErrorLabel.Location = new System.Drawing.Point(18, 111);
            this.typeErrorLabel.Name = "typeErrorLabel";
            this.typeErrorLabel.Size = new System.Drawing.Size(86, 13);
            this.typeErrorLabel.TabIndex = 21;
            this.typeErrorLabel.Text = "Тип ошибки *";
            // 
            // executorBox
            // 
            this.executorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.executorBox.FormattingEnabled = true;
            this.executorBox.Location = new System.Drawing.Point(110, 71);
            this.executorBox.Name = "executorBox";
            this.executorBox.Size = new System.Drawing.Size(156, 21);
            this.executorBox.TabIndex = 20;
            // 
            // executorLabel
            // 
            this.executorLabel.AutoSize = true;
            this.executorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executorLabel.Location = new System.Drawing.Point(10, 74);
            this.executorLabel.Name = "executorLabel";
            this.executorLabel.Size = new System.Drawing.Size(94, 13);
            this.executorLabel.TabIndex = 19;
            this.executorLabel.Text = "Исполнитель *";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(48, 47);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(56, 13);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Статус *";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(110, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.Location = new System.Drawing.Point(58, 24);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 13);
            this.dateLabel.TabIndex = 15;
            this.dateLabel.Text = "Дата *";
            // 
            // AddActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(546, 399);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.descripActionRichTextBox);
            this.Controls.Add(this.typeErrorLabel);
            this.Controls.Add(this.executorBox);
            this.Controls.Add(this.executorLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddActionForm";
            this.ShowIcon = false;
            this.Text = "AddActionForm";
            this.Load += new System.EventHandler(this.AddActionForm_Load);
            this.Controls.SetChildIndex(this.statusComboBox, 0);
            this.Controls.SetChildIndex(this.typeErrorBox, 0);
            this.Controls.SetChildIndex(this.dateLabel, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.executorLabel, 0);
            this.Controls.SetChildIndex(this.executorBox, 0);
            this.Controls.SetChildIndex(this.typeErrorLabel, 0);
            this.Controls.SetChildIndex(this.descripActionRichTextBox, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox descripActionRichTextBox;
        private System.Windows.Forms.Label typeErrorLabel;
        private System.Windows.Forms.ComboBox executorBox;
        private System.Windows.Forms.Label executorLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label dateLabel;
    }
}