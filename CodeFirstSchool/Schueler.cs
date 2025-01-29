using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSchool
{
    internal class Schueler
    {

        public Schueler()
        {
            allTeacher = new HashSet<Lehrer>();
        }
            
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }

        public ICollection<Lehrer> allTeacher { get; set; }

    }
}
