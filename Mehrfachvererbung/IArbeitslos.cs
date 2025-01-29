using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface IArbeitslos : IPerson
    {          
        public double amsBezug { get; set; }
        public DateTime arbeitslosSeit { get; set; }
        
    }
}
