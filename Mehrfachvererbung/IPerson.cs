using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    interface IPerson
    {
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }
        public Utilities.Gender Geschlecht { get; set; }
        public string Sozialversicherungsnummer { get; set; }
    }
}
