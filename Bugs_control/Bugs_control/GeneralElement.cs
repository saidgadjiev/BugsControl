using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bugs_control
{
    public partial class GeneralElement : MainForm
    {
        public GeneralElement()
        {
            InitializeComponent();
        }
        public List<CStatus> statusItems = new List<CStatus>();
        public List<CTypeError> typeErrorItems = new List<CTypeError>();
        public int[] taskIdElements = new int[7];
        public string[] taskStringItems = new string[10];

        public void statusDataLoad()
        {

            DataSet loadData = new DataSet();

            if (srv.getStatusList(out loadData))
            {
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["status_id"].ToString());
                    string name = item["status_name"].ToString();
                    CStatus statusItem = new CStatus(id, name);
                    statusItems.Add(statusItem);

                    statusComboBox.Items.Add(statusItem);
                }
            }
        }

        public void typeErrorDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getTypeErrorList(out loadData))
            {
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["type_error_id"].ToString());
                    string name = item["type_error_name"].ToString();
                    CTypeError typeErrItem = new CTypeError(id, name);
                    typeErrorItems.Add(typeErrItem);

                    typeErrorBox.Items.Add(typeErrItem);
                }
            }
        }

        private void typeErrorBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[4] = typeErrorItems.Find(error => error.typeErrorName.Contains(typeErrorBox.Text)).typeErrorId; 
        }

        private void statusComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[6] = statusItems.Find(status => status.statusName.Contains(statusComboBox.Text)).statusId;
        }
    }
}
