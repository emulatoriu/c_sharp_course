using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationCodeFirst
{
    internal class Bla : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Kurs> Kurse { get; set; }

        public delegate bool filterStudent(Student stud);

        public IEnumerable<Student> getStudents(Func<Student, bool> fs)
        {
            //Func<Student, bool> func = s => s.nachname == "";
            //return from stud in Students where fs(stud) select stud;
            //return from stud in Students where fs(stud) select stud;
            return Students.Where(s=>fs(s));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                        .HasMany<Kurs>(s => s.kurse) // HasMany und WithMany kreieren hier die n:M Beziehung
                        .WithMany(c => c.Students)
                        .Map(cs => // indem wir der .Map Funktion ein delegate mitgeben kann man der automatisch kreierten Tabelle für die Beziehung zwischen den beiden neue Namen für Attribute und die Tabelle vergeben
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });

        }
    }
}
