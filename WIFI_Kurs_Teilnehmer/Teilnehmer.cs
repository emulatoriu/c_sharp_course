using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI_Kurs_Teilnehmer
{
    internal class Teilnehmer
    {
        public int ID { get; set; }
        public string VorName { get; set; }
        public string NachName { get; set; }
        public DateOnly dO { get; set; }
    }
}
