using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractAndVirtual
{
    class Katze : Tiere
    {
        sealed public override string MachDeinenLaut { get; init; } = "miau";        
    }
}
