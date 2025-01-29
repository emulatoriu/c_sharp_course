using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface ISchueler : IPerson
    {
        public string NameDerSchule { get; set; }
        public string Klasse { get; set; }
        public float NotendurchSchnitt { get; set; }

    }
}
