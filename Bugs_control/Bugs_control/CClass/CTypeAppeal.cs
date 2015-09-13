using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTypeAppeal
    {
        public int typeAppealId { get; set; }
        public string typeAppealName;
        public CTypeAppeal() { }
        public CTypeAppeal(int id, string name)
        {
            typeAppealId = id;
            typeAppealName = name;
        }
        public override string ToString()
        {
            return typeAppealName;
        }
    }
}
