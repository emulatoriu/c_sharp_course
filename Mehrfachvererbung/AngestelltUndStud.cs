using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachvererbung
{
    class AngestelltUndStud : IAngestellter,IStudent
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
        // begin interface impl IStudent
        public string UniName { get; set; }
        public string Studienrichtung { get; set; }
        public DateTime StudiertSeit { get; set; }
        public int Semester { get; set; }
        // end interface impl IStudent

        public AngestelltUndStud(string Name, string Vorname, int Alter, Utilities.Gender Geschlecht,
            string svn, string UniName, string Studienrichtung, DateTime StudiertSeit, int Semester)
        {
            this.Name = Name;
            this.Vorname = Vorname;
            this.Alter = Alter;
            this.Geschlecht = Geschlecht;
            Sozialversicherungsnummer = svn;
            this.UniName = UniName;
            this.Studienrichtung = Studienrichtung;
            this.StudiertSeit = StudiertSeit;
            this.Semester = Semester;
        }



    }
}
