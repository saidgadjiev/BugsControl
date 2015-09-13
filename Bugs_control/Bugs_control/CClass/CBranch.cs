using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
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
