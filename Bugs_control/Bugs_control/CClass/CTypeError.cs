using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTypeError
    {
        public int typeErrorId { get; set; }
        public string typeErrorName;
        public CTypeError() { }
        public CTypeError(int id, string name)
        {
            typeErrorId = id;
            typeErrorName = name;
        }
        public override string ToString()
        {
            return typeErrorName;
        }
    }
}
