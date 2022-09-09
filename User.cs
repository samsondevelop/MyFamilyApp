using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyFormsApp
{
    internal class User
    {
        public string accname { get; set; }
        public User(string name)
        {
            accname = name;
        }
    }
}
