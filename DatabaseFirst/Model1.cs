using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseFirst
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<FahrzeugeSet> FahrzeugeSet { get; set; }
        public virtual DbSet<KursSet> KursSet { get; set; }
        public virtual DbSet<KursStudent> KursStudent { get; set; }
        public virtual DbSet<MarkeSet> MarkeSet { get; set; }
        public virtual DbSet<Postalcode> Postalcode { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<StudentSet> StudentSet { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarkeSet>()
                .HasMany(e => e.FahrzeugeSet)
                .WithRequired(e => e.MarkeSet)
                .HasForeignKey(e => e.Marke1_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Postalcode>()
                .Property(e => e.City)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.PersonFirst)
                .IsFixedLength();

            modelBuilder.Entity<Reservation>()
                .Property(e => e.PersonLast)
                .IsFixedLength();

            modelBuilder.Entity<Reservation>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.CompanyName)
                .IsFixedLength();

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.RestName)
                .IsFixedLength();

            modelBuilder.Entity<Restaurants>()
                .Property(e => e.Reststreet)
                .IsFixedLength();

            modelBuilder.Entity<Restaurants>()
                .HasMany(e => e.Tables)
                .WithRequired(e => e.Restaurants)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentSet>()
                .HasMany(e => e.KursStudent)
                .WithRequired(e => e.StudentSet)
                .HasForeignKey(e => e.Student_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tables>()
                .Property(e => e.TableName)
                .IsFixedLength();
        }
    }
}
