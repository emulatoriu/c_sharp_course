using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface ILehrling : IPerson
    {
        public string Lehreinrichtung { get; set; }
        public string Lehrberuf { get; set; }
        public int LehrJahr { get; set; }
    }

}
