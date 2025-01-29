using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Model1())
            {
                //var players = db.Spieler.Where(pl=>pl.Vorname.StartsWith("F") || pl.Vorname.StartsWith("f"));
                var players = from pl in db.Spieler
                              where pl.Vorname.StartsWith("F")
                              select pl;

                foreach (var pl in players)
                {
                    Console.WriteLine(pl.Vorname);
                }
                Console.ReadLine();
            }

        }
    }
}
