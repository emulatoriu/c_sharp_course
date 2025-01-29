using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CF_StudentCourse
{
    internal class Kurs
    {
        public Kurs()
        {
            Students = new List<Student>();
        }
        public int KursId { get; set; }
        public string Name { get; set; }
        public int ETCS_Points { get; set; }

        public int TeacherID { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
