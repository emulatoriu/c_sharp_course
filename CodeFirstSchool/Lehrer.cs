
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSchool
{
    internal class Lehrer
    {

        public Lehrer()
        {
            alleStudents = new HashSet<Schueler>();
        }
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        public ICollection<Schueler> alleStudents { get; set; }

    }
}
