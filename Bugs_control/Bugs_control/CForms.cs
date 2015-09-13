using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CForms
    {
        public int formsId { get; set; }
        public int subsystemId;
        public string formsName;
        public CForms() { }
        public CForms(int id, int subId, string name)
        {
            formsId = id;
            subsystemId = subId;
            formsName = name;
        }
        public override string ToString()
        {
            return formsName;
        }
    }
}
