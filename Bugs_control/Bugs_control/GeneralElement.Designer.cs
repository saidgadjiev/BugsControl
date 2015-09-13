namespace Bugs_control
{
    partial class GeneralElement
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
            this.typeErrorBox = new System.Windows.Forms.ComboBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // typeErrorBox
            // 
            this.typeErrorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeErrorBox.FormattingEnabled = true;
            this.typeErrorBox.Location = new System.Drawing.Point(76, 192);
            this.typeErrorBox.Name = "typeErrorBox";
            this.typeErrorBox.Size = new System.Drawing.Size(182, 21);
            this.typeErrorBox.TabIndex = 24;
            this.typeErrorBox.SelectionChangeCommitted += new System.EventHandler(this.typeErrorBox_SelectionChangeCommitted);
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(179, 242);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(104, 21);
            this.statusComboBox.TabIndex = 23;
            this.statusComboBox.SelectionChangeCommitted += new System.EventHandler(this.statusComboBox_SelectionChangeCommitted);
            // 
            // GeneralElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.typeErrorBox);
            this.Controls.Add(this.statusComboBox);
            this.Name = "GeneralElement";
            this.Text = "GeneralElement";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ComboBox typeErrorBox;
        protected System.Windows.Forms.ComboBox statusComboBox;



    }
}