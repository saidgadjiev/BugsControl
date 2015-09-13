using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CForms
    {
        public int formsId { get; set; }
        public string formsName;
        public CForms() { }
        public CForms(int id, string name)
        {
            formsId = id;
            formsName = name;
        }
        public override string ToString()
        {
            return formsName;
        }
    }
}
