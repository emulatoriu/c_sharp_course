using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface IAngestellter : IPerson
    {        
        public string Arbeitgeber { get; set; }
        public string AngestelltAls { get; set; }
        public double JahresEinkommen {get; set; }       

    }
}
