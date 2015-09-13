using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormApplication1
{
    public class CSectionForm
    {
        public int sectionFormId { get; set; }
        public string sectionFromName;
        public CSectionForm() { }
        public CSectionForm(int id, string name)
        {
            sectionFormId = id;
            sectionFromName = name;
        }
        public override string ToString()
        {
            return sectionFromName;
        }
    }
}
