using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bugs_control; 

namespace Bugs_control
{
    public partial class SearchForm : Bugs_control.BaseForm
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        public DataSet loadData = new DataSet();
        public int[] intItems = new int[9];

        private void SearchForm_Load(object sender, EventArgs e)
        {
            statusDataLoad();
            priorityDataLoad();
            systemDataLoad();
            typeAppealDataLoad();
            reasonAppealDataLoad();
            typeErrorDataLoad();
        }

        public void dataCollection()
        {
            if (statusComboBox.SelectedIndex.Equals(-1))
                intItems[0] = -1;
            else
                intItems[0] = statusItems.Find(status => status.statusName.Contains(statusComboBox.Text)).statusId;
            if (priorityBox.SelectedIndex.Equals(-1))
                intItems[1] = -1;
            else
                intItems[1] = priorityAppealItems.Find(priority => priority.priorityName.Contains(priorityBox.Text)).priorityId;
            if (systemBox.SelectedIndex.Equals(-1))
                intItems[2] = -1;
            else
                intItems[2] = systemItems.Find(name => name.systemName.Contains(systemBox.Text)).systemId;
            if (subsystemBox.SelectedIndex.Equals(-1))
                intItems[3] = -1;
            else
                intItems[3] = subsystemItems.Find(subsystem => subsystem.subsystemName.Contains(subsystemBox.Text)).subsystemId;
            if (formsBox.SelectedIndex.Equals(-1))
                intItems[4] = -1;
            else
                intItems[4] = formsItems.Find(form => form.formsName.Contains(formsBox.Text)).formsId;
            if (sectionFormsBox.SelectedIndex.Equals(-1))
                intItems[5] = -1;
            else
                intItems[5] = sectionFormItems.Find(section => section.sectionFormName.Contains(sectionFormsBox.Text)).sectionFormId;
            if (typeAppealBox.SelectedIndex.Equals(-1))
                intItems[6] = -1;
            else
                intItems[6] = typeAppealItems.Find(type => type.typeAppealName.Contains(typeAppealBox.Text)).typeAppealId;
            if (reasonAppealBox.SelectedIndex.Equals(-1))
                intItems[7] = -1;
            else
                intItems[7] = reasonAppealItems.Find(reason => reason.reasonAppealName.Contains(reasonAppealBox.Text)).reasonAppealId;
             if (typeErrorBox.SelectedIndex.Equals(-1))
                intItems[8] = -1;
            else
                intItems[8] = typeErrorItems.Find(error => error.typeErrorName.Contains(typeErrorBox.Text)).typeErrorId;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataCollection();
            if (srv.searchData(dateTimePicker1.Text, dateTimePicker2.Text, intItems, out loadData))
            {
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("По данному запросу нет данных выберите другие параметры");
            }
        }

        public DataSet getDataSearchForm()
        {
            return loadData;
        }

    }
}
