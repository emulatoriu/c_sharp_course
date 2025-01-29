using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CF_StudentCourse
{
    internal class Student
    {
        public Student()
        {
            kurse = new HashSet<Kurs>();
        }
        public int StudentID { get; set; } // Id Mandatory
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string matrNr { get; set; }
        public int alter { get; set; }

        public virtual ICollection<Kurs> kurse { get; set; } // virtual aktiviert Lazy Loading feature aber nur bis EF 6!- Daten werden automatisch aus db geladen, wenn man darauf zugreift
        public object Students { get; internal set; }
    }
}
