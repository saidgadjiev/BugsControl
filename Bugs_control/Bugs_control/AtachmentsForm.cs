using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bugs_control
{
    public partial class AtachmentsForm : MainForm
    {
        public AtachmentsForm()
        {
            InitializeComponent();
        }

        public int id = 0;
        public List<CFile> fileItems = new List<CFile>();

        public void setId(int taskId)
        {
            id = taskId;
        }

        private void AtachmentsForm_Load(object sender, EventArgs e)
        {
            DataSet loadData = new DataSet();

            if (srv.getAtachmentsList(id, out loadData))
            {
                foreach (DataRow row in loadData.Tables[0].Rows)
                {
                    int i = AtachmentsGrid.Rows.Add();
                    AtachmentsGrid.Rows[i].Cells[1].Value = row["Дата"].ToString();
                    AtachmentsGrid.Rows[i].Cells[3].Value = row["Имя файла"].ToString();
                }
                AtachmentsGrid.Sort(AtachmentsGrid.Columns["Date"], ListSortDirection.Descending);
            }
            else
            {
                MessageBox.Show("У выбранной задачи нет вложений", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtachmentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {

                srv.deleteAtachment(id, AtachmentsGrid.Rows[e.RowIndex].Cells["FileName"].Value.ToString());
                AtachmentsGrid.Rows.RemoveAt(e.RowIndex);
            }
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

        private void addAtachment_Click(object sender, EventArgs e)
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
                            CFile file = new CFile();
                            file.fileName = fileName;
                            file.filePath = openFileDialog.FileName;
                            file.fileByte = getFile(file.filePath);
                            file.dataAdd = DateTime.Today.ToString();
                            srv.createNewAtachments(file.fileName, file.fileByte, file.dataAdd);
                            int i = AtachmentsGrid.Rows.Add();
                            AtachmentsGrid.Rows[i].Cells[1].Value = file.dataAdd;
                            AtachmentsGrid.Rows[i].Cells[3].Value = file.fileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


    }
}
