using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirstSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                Id = 1,
                Nachname = "Mustermann",
                Vorname =  "Max",
                Alter = 20,
                Matrikelnummer = "12345"
            
            };

            Kurs kurse1 = new Kurs()
            {
                Id = 1,
                Name = "Mathematik"                
            };

            student.Kurs.Add(kurse1);
            kurse1.Student.Add(student);

            using(var db = new StudentenContext())
            {
                db.StudentSet.Add(student);

                db.KursSet.Add(kurse1);

                db.SaveChanges();
            }
        }
    }
}
