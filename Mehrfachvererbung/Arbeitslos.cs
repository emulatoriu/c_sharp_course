using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    class Arbeitslos : IArbeitslos
    {
        // begin interface impl IPerson
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }
        public Utilities.Gender Geschlecht { get; set; }
        public string Sozialversicherungsnummer { get; set; }
        // end interface impl IPerson
        // begin interface impl IArbeitslos
        public double amsBezug { get; set; }
        public DateTime arbeitslosSeit { get; set; }
        // end interface impl IArbeitslos

        public Arbeitslos(string Name, string Vorname, int Alter, Utilities.Gender Geschlecht,
            string svn, double ams, DateTime arbeitslosSeit)
        {
                this.Name = Name;
                this.Vorname = Vorname;
                this.Alter = Alter;
                this.Geschlecht = Geschlecht;
                Sozialversicherungsnummer = svn;
                this.amsBezug = ams;
                this.arbeitslosSeit = arbeitslosSeit;

        }
      }
}
