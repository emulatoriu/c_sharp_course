using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstFahrzeuge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Marke m = new Marke() { FMarke = "BMW"};

            using (var db = new FahrzeugModelContainer())
            {
                db.MarkeSet.Add(m);
                db.SaveChanges();
            }
        }
    }
}
