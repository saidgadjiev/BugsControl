using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CSubsystem
    {
        public int subsystemId { get; set; }
        public int systemId { get; set; } 
        public string subsystemName;
        public CSubsystem() { }
        public CSubsystem(int id, int sysId, string name)
        {
            subsystemId = id;
            systemId = sysId;
            subsystemName = name;
        }
        public override string ToString()
        {
            return subsystemName;
        }
    }
}
