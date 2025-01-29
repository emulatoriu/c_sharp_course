using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Binding_EF
{
    public class MainViewModel
    {
        public List<Spieler> allSpieler { get; set; }

        public MainViewModel()
        {
            allSpieler = new List<Spieler>();
            //Spieler s = new Spieler();
            //s.Id = 1;
            //s.Vorname = "Banana";
            //s.TrainerID = 1;
            //allSpieler.Add(s);
            //Spieler s = new Spieler();
            //s.Id = 1;
            //s.Vorname = "Banana";
            //s.TrainerID = 1;
            using (var db = new Model1())
            {
                //db.Spieler.Add(s);
                //db.SaveChanges();


                allSpieler = db.Spieler.ToList();

            }
        }
    }
}
