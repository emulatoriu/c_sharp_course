using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudKurseMitSQLManagment
{
    internal class Student
    {
        public int Id { get; set; }
        public string VorName { get; set; }
        public string NachName { get; set; }
        public string MatrNr { get; set; }
        public DateOnly birthDate { get; set; }

    }
}
