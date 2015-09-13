using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bugs_control
{
    public partial class TaskForm : Bugs_control.BaseForm
    {
        public TaskForm()
        {
            InitializeComponent();
            List<Control> baseControl = new List<Control>(new Control[] {systemBox, subsystemBox, formsBox, sectionFormsBox,
                                                                typeAppealBox, reasonAppealBox, typeErrorBox, priorityBox, statusComboBox});
            Point location = new Point(191, 232);
            int shift = 22;
            for (int i = 0; i < 8; i++)
            {
                baseControl[i].Location = location;
                if (i != 3)
                    location.Y += shift;
                else
                    location.Y += shift + 16;
            }
            location.X = 815;
            location.Y = 358;
            baseControl[8].Location = location;
            newTaskPage.Controls.AddRange(baseControl.ToArray());

            string[] info = new string[] {"ФИО", "Телефон", "Логин", "Пароль","Филиал","Региональная дирекция","структурное подразделение",
                                "Форма","Раздел формы","Тип обращения","Причина обращения" };
            foreach (string item in info)
            {
                int i = informationUser.Rows.Add();
                informationUser.Rows[i].Cells[0].Value = item;
            }
        }

        public List<CBranch> branchItems = new List<CBranch>();
        public List<CFile> fileItems = new List<CFile>();
        DataSet dataForTable = new DataSet();

        private void TaskForm_Load(object sender, EventArgs e)
        {
            branchDataLoad();
            systemDataLoad();
            typeAppealDataLoad();
            reasonAppealDataLoad();
            typeErrorDataLoad();
            priorityDataLoad();
            statusDataLoad();
        }

        public bool checkFile(string fileName)
        {
            return fileNameListBox.Items.Contains(fileName);
        }

        public byte[] getFile(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] file = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return file;
        }

        private void selectionFileButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Text files (*.txt, *.doc, *.docx)|*.txt;*.doc;*.docx|Image files (*.png, *.bmp, *.jpg)|*.png;*.bmp;*.jpg";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string fileName = Path.GetFileName(openFileDialog.FileName);
                            if (!checkFile(fileName))
                            {
                                CFile file = new CFile();
                                file.fileName = fileName;
                                file.filePath = openFileDialog.FileName;
                                file.fileByte = getFile(file.filePath);
                                file.dataAdd = dateTimePicker.Text;
                                fileItems.Add(file);
                                fileNameListBox.Items.Add(fileName);
                                deleteFileNameListBox.Items.Add("X");
                            }
                            else
                            {
                                MessageBox.Show("Этот файл уже выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void deleteFileNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = deleteFileNameListBox.SelectedIndex;
            if (!index.Equals(-1))
            {
                fileItems.RemoveAt(index);
                fileNameListBox.Items.RemoveAt(index);
                deleteFileNameListBox.Items.Remove(deleteFileNameListBox.SelectedItem);
                if (!index.Equals(0))
                {
                    deleteFileNameListBox.SetSelected(index - 1, false);
                }
            }
        }

        public void branchDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getBranchList(out loadData))
            {
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["branch_id"].ToString());
                    string name = item["branch_name"].ToString();
                    CBranch branch = new CBranch(id, name);
                    branchItems.Add(branch);

                    branchBox.Items.Add(branch);
                }
            }
        }

        private void branchBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[0] = branchItems.Find(branch => branch.branchName.Contains(branchBox.Text)).branchId;
        }

        public void dataCollection()
        {
            if (!phoneTextBox.Text.Contains("(   )    -"))
                taskStringItems[0] = phoneTextBox.Text;
            if (!string.IsNullOrEmpty(regDirectTextBox.Text))
                taskStringItems[1] = regDirectTextBox.Text;
            taskStringItems[2] = structSubdivionTextBox.Text;
            if (!string.IsNullOrEmpty(loginTextBox.Text))
                taskStringItems[3] = loginTextBox.Text;
            if (!string.IsNullOrEmpty(passwordTextBox.Text))
                taskStringItems[4] = passwordTextBox.Text;
            taskStringItems[5] = latterRichTextBox.Text;
            taskStringItems[6] = descriptAppealRichTextBox.Text;
            taskStringItems[7] = completeActionRichTextBox.Text;
            taskStringItems[8] = dateTimePicker.Text;
            taskStringItems[9] = FIOtextBox.Text;
            if (statusComboBox.SelectedIndex.Equals(-1))
                taskIdElements[6] = 1;
        }

        public bool checkError()
        {
            string[] inputItems = { FIOtextBox.Text, branchBox.Text, structSubdivionTextBox.Text, 
                systemBox.Text, subsystemBox.Text, formsBox.Text, sectionFormsBox.Text, typeAppealBox.Text,
                reasonAppealBox.Text, typeErrorBox.Text, priorityBox.Text, latterRichTextBox.Text,
                descriptAppealRichTextBox.Text, completeActionRichTextBox.Text };

            if (!dateTimePicker.Text.Length.Equals(19))
            {
                MessageBox.Show("Неправильно введена дата или время", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!phoneTextBox.Text.Contains("(   )    -"))
            {
                if (!phoneTextBox.Text.Length.Equals(14))
                {
                    MessageBox.Show("Неправильно введен номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            foreach (string item in inputItems)
            {
                if (item.Equals(string.Empty))
                {
                    MessageBox.Show("Заполните все поля помеченные *", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        public bool saveFiles()
        {
            if (fileNameListBox.Items.Count > 0)
            {
                for (int i = 0; i < fileItems.Count; i++)
                {
                    if (!srv.createNewAtachments(fileItems[i].fileName, fileItems[i].fileByte, fileItems[i].dataAdd))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool createTask()
        {
            dataCollection();
            if (srv.createNewTask(taskIdElements, taskStringItems))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void clearForm()
        {
            FIOtextBox.Clear();
            phoneTextBox.Clear();
            branchBox.SelectedIndex = -1;
            regDirectTextBox.Clear();
            structSubdivionTextBox.Clear();
            systemBox.SelectedIndex = -1;
            subsystemBox.Items.Clear();
            subsystemBox.Enabled = false;
            formsBox.Items.Clear();
            formsBox.Enabled = false;
            sectionFormsBox.Items.Clear();
            sectionFormsBox.Enabled = false;
            typeAppealBox.SelectedIndex = -1;
            reasonAppealBox.SelectedIndex = -1;
            typeErrorBox.SelectedIndex = -1;
            priorityBox.SelectedIndex = -1;
            loginTextBox.Clear();
            passwordTextBox.Clear();
            fileNameListBox.Items.Clear();
            deleteFileNameListBox.Items.Clear();
            latterRichTextBox.Clear();
            descriptAppealRichTextBox.Clear();
            completeActionRichTextBox.Clear();
            statusComboBox.SelectedIndex = -1;
            dateTimePicker.ResetText();
            List<string> items = new List<string>(taskStringItems);
            items.Clear();
            taskStringItems = items.ToArray();
            taskIdElements = new int[7];
            taskStringItems = new string[10];
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!checkError())
            {
                if (createTask())
                {
                    MessageBox.Show("Данные сохранены успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveFiles();
                    clearForm();
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(taskIdElements[1].ToString());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm src = new SearchForm();
            src.ShowDialog();
            if (src.DialogResult == DialogResult.OK)
            {
                dataForTable = src.getDataSearchForm();
                uploadDataInDataGridView(dataForTable);
                countLabel.Text = dataForTable.Tables[0].Rows.Count.ToString();
            }
        }

        private void addActionButton_Click(object sender, EventArgs e)
        {
            AddActionForm src = new AddActionForm();
            src.setTaskid(getSelectedTaskId());
            src.ShowDialog();
            if (src.DialogResult == DialogResult.OK)
            {
                updateEndAction();
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void updateEndAction()
        {
            DataSet loadData = new DataSet();

            if (srv.getEndAction(getSelectedTaskId(), out loadData))
            {
                foreach (DataRow row in loadData.Tables[0].Rows)
                {
                    int statusId = Convert.ToInt32(row["status_id"].ToString());
                    int errorId = Convert.ToInt32(row["type_error_id"].ToString());
                    dataBox.Text = row["date_added"].ToString();
                    statusTextBox.Text = statusItems.Find(item => item.statusId.Equals(statusId)).statusName;
                    errorTextBox.Text = typeErrorItems.Find(item => item.typeErrorId.Equals(errorId)).typeErrorName;
                    actionRichTextBox.Text = row["descript_action"].ToString();
                }
            }

        }

        public void uploadDataInDataGridView(DataSet dataForTable)
        {
            dataGridView1.Rows.Clear();
            int number = 1;
            foreach (DataRow row in dataForTable.Tables[0].Rows)
            {
                int i = dataGridView1.Rows.Add();
                int priorityId = Convert.ToInt32(row["priority_appeal_id"].ToString());
                int statusId = Convert.ToInt32(row["status_id"].ToString());
                int typeErrorId = Convert.ToInt32(row["type_error_id"].ToString());
                int branchId = Convert.ToInt32(row["branch_id"].ToString());
                int typeAppId = Convert.ToInt32(row["type_appeal_id"].ToString());
                int reasAppId = Convert.ToInt32(row["reason_appeal_id"].ToString());
                dataGridView1.Rows[i].Cells[0].Value = number++;
                dataGridView1.Rows[i].Cells[1].Value = statusItems.Find(item => item.statusId.Equals(statusId)).statusName;
                dataGridView1.Rows[i].Cells[2].Value = priorityAppealItems.Find(item => item.priorityId.Equals(priorityId)).priorityName;
                dataGridView1.Rows[i].Cells[3].Value = row["datetime_app"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = typeErrorItems.Find(item => item.typeErrorId.Equals(typeErrorId)).typeErrorName;
                dataGridView1.Rows[i].Cells[9].Value = row["system_name"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = row["subsystem_name"].ToString();
                dataGridView1.Rows[i].Cells["descApp"].Value = row["desc_app"].ToString();
                dataGridView1.Rows[i].Cells["FIO"].Value = row["FIO"].ToString();
                dataGridView1.Rows[i].Cells["Phone"].Value = row["phone_number"].ToString();
                dataGridView1.Rows[i].Cells["Login"].Value = row["login_user"].ToString();
                dataGridView1.Rows[i].Cells["Password"].Value = row["password_user"].ToString();
                dataGridView1.Rows[i].Cells["Branch"].Value = branchItems.Find(item => item.branchId.Equals(branchId)).branchName;
                dataGridView1.Rows[i].Cells["RegDirect"].Value = row["reg_direct"].ToString();
                dataGridView1.Rows[i].Cells["StructSubDiv"].Value = row["struct_subdiv"].ToString();
                dataGridView1.Rows[i].Cells["SectionForm"].Value = row["section_forms_name"].ToString();
                dataGridView1.Rows[i].Cells["TypeAppeal"].Value = typeAppealItems.Find(item => item.typeAppealId.Equals(typeAppId)).typeAppealName;
                dataGridView1.Rows[i].Cells["ReasonApp"].Value = reasonAppealItems.Find(item => item.reasonAppealId.Equals(reasAppId)).reasonAppealName;
                dataGridView1.Rows[i].Cells["Form"].Value = row["forms_name"];
                dataGridView1.Rows[i].Cells["data"].Value = row["datetime_app"].ToString();
                dataGridView1.Rows[i].Cells["taskId"].Value = row["id"].ToString();
                dataGridView1.Rows[i].Cells["letter"].Value = row["letter"].ToString();
                dataGridView1.Rows[i].Selected = false;
            }
        }

        public void loadHistoryPage(int id)
        {
            historyRichtextBox.Text = dataGridView1.Rows[id].Cells["letter"].Value.ToString();
            uploadHistoryDataView();
        }

        public void loadAppealPage(int id)
        {
            descAppealBox.Text = dataGridView1.Rows[id].Cells["descApp"].Value.ToString();
            uploadInfoUser(id);
            updateEndAction();
        }

        public void uploadHistoryDataView()
        {
            DataSet loadData = new DataSet();
            if (srv.getActionList(getSelectedTaskId(), out loadData))
            {
                foreach (DataRow row in loadData.Tables[0].Rows)
                {
                    int i = historyActionView.Rows.Add();
                    int statusId = Convert.ToInt32(row["status_id"].ToString());
                    int errorId = Convert.ToInt32(row["type_error_id"].ToString());
                    historyActionView.Rows[i].Cells["date"].Value = row["date_added"].ToString();
                    historyActionView.Rows[i].Cells["StatusHistory"].Value = statusItems.Find(item => item.statusId.Equals(statusId)).statusName;
                    historyActionView.Rows[i].Cells["TypeErrorHistory"].Value = typeErrorItems.Find(item => item.typeErrorId.Equals(errorId)).typeErrorName;
                    historyActionView.Rows[i].Cells["CompleteAction"].Value = row["descript_action"].ToString();
                }
            }
        }

        public void uploadInfoUser(int id)
        {
            for (int i = 0, j = 13; i < 11; i++, j++)
            {
                informationUser.Rows[i].Cells["element"].Value = dataGridView1.Rows[id].Cells[j].Value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex;

            addActionButton.Enabled = true;
            openAtachmentsButton.Enabled = true;
            loadAppealPage(id);
            loadHistoryPage(id);
        }

        public int getSelectedTaskId()
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["taskId"].Value.ToString());
            return id;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           MessageBox.Show(getSelectedTaskId().ToString());
        }

        private void openAtachmentsButton_Click(object sender, EventArgs e)
        {
            AtachmentsForm src = new AtachmentsForm();
            src.setId(getSelectedTaskId());
            src.Show();
        }

    }
}
