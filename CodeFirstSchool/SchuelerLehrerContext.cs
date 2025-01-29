using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSchool
{
    internal class SchuelerLehrerContext : DbContext
    {
        public DbSet<Lehrer> Lehrers { get; set; }
        public DbSet<Schueler> Schuelers { get; set; }
    }
}
