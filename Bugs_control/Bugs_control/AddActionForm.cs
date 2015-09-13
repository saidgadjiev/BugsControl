using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bugs_control
{
    public partial class AddActionForm : GeneralElement
    {
        public AddActionForm()
        {
            InitializeComponent();
        }

        public List<CUser> userItems = new List<CUser>();
        public int[] intElements = new int[4];
        public string[] stringElements = new string[2];

        private void AddActionForm_Load(object sender, EventArgs e)
        {
            statusDataLoad();
            typeErrorDataLoad();
            executorDataLoad();
        }

        public void executorDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getUserList(out loadData))
            {
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["user_id"].ToString());
                    string name = item["username"].ToString();
                    CUser user = new CUser(id, name);
                    userItems.Add(user);

                    executorBox.Items.Add(user);
                }
            }
        }

        public bool checkError()
        {
            string[] items = new string[] { statusComboBox.Text, executorBox.Text, typeErrorBox.Text, descripActionRichTextBox.Text };
            foreach (string item in items)
            {
                if (item.Equals(string.Empty))
                {
                    MessageBox.Show("Заполните все поля помеченные *", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        public void dataCollection()
        {
            TaskForm tmp = new TaskForm();
            stringElements[0] = dateTimePicker1.Text;
            stringElements[1] = descripActionRichTextBox.Text;
            intElements[0] = statusItems.Find(item => item.statusName.Contains(statusComboBox.Text)).statusId;

            intElements[1] = userItems.Find(item => item.username.Contains(executorBox.Text)).userId;

            intElements[2] = typeErrorItems.Find(item => item.typeErrorName.Contains(typeErrorBox.Text)).typeErrorId;

        }

        public void clearForm()
        {
            dateTimePicker1.ResetText();
            statusComboBox.SelectedIndex = -1;
            typeErrorBox.SelectedIndex = -1;
            executorBox.SelectedIndex = -1;
        }

        public bool createAction()
        {
            dataCollection();

            if (srv.createAction(stringElements, intElements))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!checkError())
            {
                if (createAction())
                {
                    MessageBox.Show("Данные сохранены успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearForm();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void setTaskid(int id)
        {
            intElements[3] = id;
        }
    }
}
