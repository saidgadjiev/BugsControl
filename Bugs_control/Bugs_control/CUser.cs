using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs_control
{
    public class CUser
    {
        public int userId { get; set; }
        public string username;
        public CUser() { }
        public CUser(int id, string name)
        {
            userId = id;
            username = name;
        }
        public override string ToString()
        {
            return username;
        }
    }
}
