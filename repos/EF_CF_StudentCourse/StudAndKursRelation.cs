using System.Data.Entity;

namespace EF_CF_StudentCourse
{
    internal class StudAndKursRelation : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Kurs> Kurse { get; set; }
        //public DbSet<StudAndKurs> listOfStudKurs { get; set; }

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
