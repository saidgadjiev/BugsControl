using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CSystem
    {
        public int systemId { get; set; }
        public string systemName;
        public CSystem() { }
        public CSystem(int id, string name)
        {
            systemId = id;
            systemName = name;
        }
        public override string ToString()
        {
            return systemName;
        }
    }
}
