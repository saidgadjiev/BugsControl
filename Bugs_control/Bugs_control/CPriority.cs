using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CPriorityAppeal
    {
        public int priorityId { get; set; }
        public string priorityName;
        public CPriorityAppeal() { }
        public CPriorityAppeal(int id, string name)
        {
            priorityId = id;
            priorityName = name;
        }
        public override string ToString()
        {
            return priorityName;
        }
    }
}
