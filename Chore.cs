using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyFormsApp
{
    internal class Chore
    {
        public DateTime ChoreDate { get; set; }
        public string ChoreName { get; set; }
        public string ChoreDesc { get; set; }
        public bool ChoreCompleted { get; set; }
    }
}
