using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CReasonAppeal
    {
        public int reasonAppealId { get; set; }
        public string reasonAppealName;
        public CReasonAppeal() { }
        public CReasonAppeal(int id, string name)
        {
            reasonAppealId = id;
            reasonAppealName = name;
        }
        public override string ToString()
        {
            return reasonAppealName;
        }
    }
}
