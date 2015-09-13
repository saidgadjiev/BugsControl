using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CFile
    {
        public string fileName;
        public string filePath;
        public byte[] fileByte;
        public override string ToString()
        {
            return fileName;
        }
    }
}
