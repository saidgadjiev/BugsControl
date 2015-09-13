namespace Bugs_control
{
    partial class AtachmentsForm
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
            this.addAtachmentButton = new System.Windows.Forms.Button();
            this.AtachmentsGrid = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtachId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.AtachmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // addAtachmentButton
            // 
            this.addAtachmentButton.Location = new System.Drawing.Point(488, 227);
            this.addAtachmentButton.Name = "addAtachmentButton";
            this.addAtachmentButton.Size = new System.Drawing.Size(75, 23);
            this.addAtachmentButton.TabIndex = 1;
            this.addAtachmentButton.Text = "Добавить";
            this.addAtachmentButton.UseVisualStyleBackColor = true;
            this.addAtachmentButton.Click += new System.EventHandler(this.addAtachment_Click);
            // 
            // AtachmentsGrid
            // 
            this.AtachmentsGrid.AllowUserToAddRows = false;
            this.AtachmentsGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AtachmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AtachmentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.Date,
            this.User,
            this.FileName,
            this.AtachId});
            this.AtachmentsGrid.Location = new System.Drawing.Point(29, 54);
            this.AtachmentsGrid.Name = "AtachmentsGrid";
            this.AtachmentsGrid.ReadOnly = true;
            this.AtachmentsGrid.RowHeadersVisible = false;
            this.AtachmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AtachmentsGrid.Size = new System.Drawing.Size(534, 149);
            this.AtachmentsGrid.TabIndex = 2;
            this.AtachmentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AtachmentsGrid_CellContentClick);
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::Bugs_control.Properties.Resources.edit_delete;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 20;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 170;
            // 
            // User
            // 
            this.User.HeaderText = "Пользователь";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 170;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Имя файла";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 170;
            // 
            // AtachId
            // 
            this.AtachId.HeaderText = "AtachId";
            this.AtachId.Name = "AtachId";
            this.AtachId.ReadOnly = true;
            this.AtachId.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Bugs_control.Properties.Resources.edit_delete;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 20;
            // 
            // AtachmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 262);
            this.Controls.Add(this.AtachmentsGrid);
            this.Controls.Add(this.addAtachmentButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtachmentsForm";
            this.ShowIcon = false;
            this.Text = "Вложения";
            this.Load += new System.EventHandler(this.AtachmentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AtachmentsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addAtachmentButton;
        private System.Windows.Forms.DataGridView AtachmentsGrid;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AtachId;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}