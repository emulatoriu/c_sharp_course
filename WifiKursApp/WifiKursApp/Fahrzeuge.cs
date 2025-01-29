using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiKursApp
{
    public class Fahrzeuge
    {
        private int iAnzahlReifen;
        private string sMarke;
        private int iPs;
        private string sGetriebeart;
        private string sFarbe;

        //unsichtbarer KONSTRUKTOR
        /*
         * public Fahrzeuge()
         * {
         * }
         */

        public Fahrzeuge()
        {

        }

        protected void nurInDieserKlasse()
        {
            Console.WriteLine("Nur in dieser Klasse");
        }

        public Fahrzeuge(int iAnzahl, string sMarke, int iPs, string sGetribeart, string sFarbe)
        {
            iAnzahlReifen = iAnzahl;
            this.sMarke = sMarke;
            this.iPs = iPs;
            this.sGetriebeart = sGetribeart;
            this.sFarbe = sFarbe;
        }

        public void setiAnzahlReifen(int iAnzahlReifen)
        {
            this.iAnzahlReifen = iAnzahlReifen;
        }

        public int getiAnzahlReifen()
        {
            return iAnzahlReifen;
        }

        public void setsMarke(string sMarke)
        {
            this.sMarke = sMarke;
        }

        public string getsMarke()
        {
            return sMarke;
        }

        public void setiPs(int iPs)
        {
            this.iPs = iPs;
        }

        public int getiPs()
        {
            return iPs;
        }

        public void setsGetriebeart(string sGetriebeart)
        {
            this.sGetriebeart = sGetriebeart;
        }

        public string getsGetriebeart()
        {
            return sGetriebeart;
        }

        public void setsFarbe(string sFarbe)
        {
            this.sFarbe = sFarbe;
        }

        public string getsFarbe()
        {
            return sFarbe;
        }

        public void printFahrzeugDetails()
        {
            Console.WriteLine("Marke = " + sMarke); // oder statt sMarke getsMarke()
            Console.WriteLine("Getriebe = " + sGetriebeart);
            Console.WriteLine("Ps = " + iPs);
            Console.WriteLine("Anzahl der Reifen = " + iAnzahlReifen);
            Console.WriteLine("Farbe = " + sFarbe);
        }


    }
}
