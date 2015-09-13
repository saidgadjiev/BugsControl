using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{

    public class CBranch
    {
        public int branchId { get; set; }
        public string branchName;
        public CBranch() { }
        public CBranch(int id, string name)
        {
            branchId = id;
            branchName = name;
        }
        public override string ToString()
        {
            return branchName;
        }
    }
}
