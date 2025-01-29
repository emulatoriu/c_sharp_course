using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    class Angestellter : IAngestellter
    {
        // begin interface impl IPerson
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }
        public Utilities.Gender Geschlecht { get; set; }
        public string Sozialversicherungsnummer { get; set; }

        // end interface impl IPerson
        // begin interface impl IAngestellter
        public string Arbeitgeber { get; set; }
        public string AngestelltAls { get; set; }
        public double JahresEinkommen { get; set; }
        // end interface impl IAngestellter

        public Angestellter(string Name, string Vorname, int Alter, Utilities.Gender Geschlecht,
            string svn, string Arbeitgeber, string AngestelltAls, double JahresEinkommen) 
        { 
            this.Name = Name;
            this.Vorname = Vorname;
            this.Alter = Alter;
            this.Geschlecht = Geschlecht;
            Sozialversicherungsnummer = svn;
            this.Arbeitgeber = Arbeitgeber;
            this.AngestelltAls = AngestelltAls;
            this.JahresEinkommen = JahresEinkommen;
        }

        public Angestellter(IPerson person, string Arbeitgeber, string AngestelltAls, double JahresEinkommen)
        {
            Name = person.Name;
            this.Vorname = person.Vorname;
            this.Alter = person.Alter;
            this.Geschlecht = person.Geschlecht;
            Sozialversicherungsnummer = person.Sozialversicherungsnummer;
            this.Arbeitgeber = Arbeitgeber;
            this.AngestelltAls = AngestelltAls;
            this.JahresEinkommen = JahresEinkommen;
        }
    }
}
