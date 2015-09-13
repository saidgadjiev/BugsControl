using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CSectionForm
    {
        public int sectionFormId { get; set; }
        public int formId { get; set; }
        public string sectionFormName;
        public CSectionForm() { }
        public CSectionForm(int id, int fId, string name)
        {
            sectionFormId = id;
            formId = fId;
            sectionFormName = name;
        }
        public override string ToString()
        {
            return sectionFormName;
        }
    }
}
