using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAndVirtual
{
    abstract class Tiere //: ITest
    {
        public string Tierart { get; init; }
        public virtual string Lebensraum{ get; set; }
        public abstract string MachDeinenLaut { get; init; }

        
    }
}
