using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseFirstWIFI
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Kurse> Kurse { get; set; }
        public virtual DbSet<Studenten> Studenten { get; set; }
        public virtual DbSet<StudUndKurse> StudUndKurse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurse>()
                .Property(e => e.Kursbezeichnung)
                .IsFixedLength();

            modelBuilder.Entity<Kurse>()
                .HasMany(e => e.Studenten)
                .WithMany(e => e.Kurse)
                .Map(m => m.ToTable("KursStudent").MapLeftKey("KursID").MapRightKey("StudentID"));

            modelBuilder.Entity<Studenten>()
                .Property(e => e.Vorname)
                .IsFixedLength();

            modelBuilder.Entity<Studenten>()
                .Property(e => e.Nachname)
                .IsFixedLength();

            modelBuilder.Entity<Studenten>()
                .Property(e => e.Matrikelnummer)
                .IsFixedLength();
        }
    }
}
