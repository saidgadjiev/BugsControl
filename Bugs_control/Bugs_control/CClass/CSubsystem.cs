using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CSubsystem
    {
        public int subsystemId { get; set; }
        public string subsystemName;
        public CSubsystem() { }
        public CSubsystem(int id, string name)
        {
            subsystemId = id;
            subsystemName = name;
        }
        public override string ToString()
        {
            return subsystemName;
        }
    }
}
