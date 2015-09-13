using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bugs_control
{
    public partial class BaseForm : GeneralElement
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public List<CSystem> systemItems = new List<CSystem>();
        public List<CSubsystem> subsystemItems = new List<CSubsystem>();
        public List<CForms> formsItems = new List<CForms>();
        public List<CSectionForm> sectionFormItems = new List<CSectionForm>();
        public List<CTypeAppeal> typeAppealItems = new List<CTypeAppeal>();
        public List<CReasonAppeal> reasonAppealItems = new List<CReasonAppeal>();
        public List<CPriorityAppeal> priorityAppealItems = new List<CPriorityAppeal>();

        public void clearSerialBox()
        {
            subsystemBox.Items.Clear();
            sectionFormsBox.Items.Clear();
            sectionFormItems.Clear();
            formsBox.Items.Clear();
            subsystemBox.Enabled = false;
            formsBox.Enabled = false;
            sectionFormsBox.Enabled = false;
        }

        private void systemBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clearSerialBox();
            subSystemDataLoad();
        }

        private void subsystemBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formsBox.Items.Clear();
            sectionFormsBox.Items.Clear();
            formsBox.Enabled = false;
            sectionFormsBox.Enabled = false;
            formsDataLoad();
        }

        private void formsBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sectionFormsBox.Items.Clear();
            sectionFormsBox.Enabled = false;
            sectionFormsDataLoad();
        }

        private void sectionFormsBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[1] = sectionFormItems.Find(section => section.sectionFormName.Contains(sectionFormsBox.Text)).sectionFormId;
            
        }

        private void typeAppealBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[2] = typeAppealItems.Find(type => type.typeAppealName.Contains(typeAppealBox.Text)).typeAppealId;
        }

        private void reasonAppealBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            taskIdElements[3] = reasonAppealItems.Find(reason => reason.reasonAppealName.Contains(reasonAppealBox.Text)).reasonAppealId;
        }

        private void priorityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskIdElements[5] = priorityAppealItems.Find(priority => priority.priorityName.Contains(priorityBox.Text)).priorityId;
        }

        public void systemDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getSystemList(out loadData))
            {

                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["system_id"].ToString());
                    string name = item["system_name"].ToString();
                    CSystem systemItem = new CSystem(id, name);
                    systemItems.Add(systemItem);

                    systemBox.Items.Add(systemItem);
                }
            }
        }

        public void subSystemDataLoad()
        {
            DataSet loadData = new DataSet();
            string tmp = systemBox.Text;

            if (srv.getSubSystemList(tmp, out loadData))
            {
                subsystemBox.Enabled = true;
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["subsystem_id"].ToString());
                    int sysId = Convert.ToInt16(item["system_id"].ToString());
                    string name = item["subsystem_name"].ToString();
                    CSubsystem subsystemItem = new CSubsystem(id, sysId, name);
                    subsystemItems.Add(subsystemItem);

                    subsystemBox.Items.Add(subsystemItem);
                }
            }
            else
            {
                MessageBox.Show("Нет подсистемы соответствующей данной системе", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void formsDataLoad()
        {
            DataSet loadData = new DataSet();
            string tmp = subsystemBox.Text;

            if (srv.getFormsList(tmp, out loadData))
            {
                formsBox.Enabled = true;
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["forms_id"].ToString());
                    int subid = Convert.ToInt16(item["subsystem_id"].ToString());
                    string name = item["forms_name"].ToString();
                    CForms formsItem = new CForms(id, subid, name);
                    formsItems.Add(formsItem);

                    formsBox.Items.Add(formsItem);
                }
            }
            else
            {
                MessageBox.Show("Нет формы соответствующей данной подсистеме", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void sectionFormsDataLoad()
        {
            DataSet loadData = new DataSet();
            string tmp = formsBox.Text;

            if (srv.getSectionFormsList(tmp, out loadData))
            {
                sectionFormsBox.Enabled = true;
                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["section_forms_id"].ToString());
                    int fid = Convert.ToInt16(item["forms_id"].ToString());
                    string name = item["section_forms_name"].ToString();
                    CSectionForm sectionItem = new CSectionForm(id, fid, name);
                    sectionFormItems.Add(sectionItem);

                    sectionFormsBox.Items.Add(sectionItem);
                }
            }
            else
            {
                MessageBox.Show("Нет раздела формы соответствующей данной форме", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void typeAppealDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getTypeAppealList(out loadData))
            {

                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["type_appeal_id"].ToString());
                    string name = item["type_appeal_name"].ToString();
                    CTypeAppeal typeAppItem = new CTypeAppeal(id, name);
                    typeAppealItems.Add(typeAppItem);

                    typeAppealBox.Items.Add(typeAppItem);
                }
            }
        }

        public void reasonAppealDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getReasonAppealList(out loadData))
            {

                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["reason_appeal_id"].ToString());
                    string name = item["reason_appeal_name"].ToString();
                    CReasonAppeal reasonAppItem = new CReasonAppeal(id, name);
                    reasonAppealItems.Add(reasonAppItem);

                    reasonAppealBox.Items.Add(reasonAppItem);
                }
            }
        }

        public void priorityDataLoad()
        {
            DataSet loadData = new DataSet();

            if (srv.getPriorityList(out loadData))
            {

                foreach (DataRow item in loadData.Tables[0].Rows)
                {
                    int id = Convert.ToInt16(item["priority_appeal_id"].ToString());
                    string name = item["priority_appeal_name"].ToString();
                    CPriorityAppeal priorityAppItem = new CPriorityAppeal(id, name);
                    priorityAppealItems.Add(priorityAppItem);

                    priorityBox.Items.Add(priorityAppItem);
                }
            }
        }


    }
}
