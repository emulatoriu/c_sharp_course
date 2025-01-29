using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface IStudent : IPerson
    {        
        public string UniName { get; set; }
        public string Studienrichtung {get; set; }
        public DateTime StudiertSeit { get; set; }

        public int Semester { get; set; }
    }
}
