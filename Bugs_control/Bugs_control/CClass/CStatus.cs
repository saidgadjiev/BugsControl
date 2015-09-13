using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CStatus
    {
        public int statusId { get; set; }
        public string statusName;
        public CStatus() { }
        public CStatus(int id, string name)
        {
            statusId = id;
            statusName = name;
        }
        public override string ToString()
        {
            return statusName;
        }
    }
}
