using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseFirst2023
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Spieler> Spieler { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spieler>()
                .Property(e => e.Vorname)
                .IsFixedLength();

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Vorname)
                .IsFixedLength();

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Nachname)
                .IsFixedLength();
        }
    }
}
