using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugeWifi
{
    class Fahrzeug
    {
        string sMarke;

        private double drivenKM;
        private double drivenMiles;

        /*
         * Erstellt ein Programm, dass Personen mit bestimmten Attributen in einer Liste speichert und diese dann ausgibt.
            Folgende Attribute: Vorname, Nachname, Alter, Geschlecht, Lieblingsfarbe, Lieblingsessen
         */

        //"hier ist dein String " + geschlecht.Equals("M") ? "sein" : "ihr" + " und hier geht es weiter";

        public Fahrzeug()
        {
            
        }

        public void setKm(double waInKm)
        {
            this.drivenKM = waInKm;
            this.drivenMiles = drivenKM/1.6d;
        }

        public void setMiles(double miles)
        {
            drivenMiles = miles;
            drivenKM = drivenMiles * 1.6d;
        }

        public Fahrzeug(string sMarke)
        {
            this.sMarke = sMarke;
        }

        public void setMarke(string neueMarke)
        {
            sMarke = neueMarke;
        }

        public string getMarke()
        {
            return sMarke;
        }
    }
}
