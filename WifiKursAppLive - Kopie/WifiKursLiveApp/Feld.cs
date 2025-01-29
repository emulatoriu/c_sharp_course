using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Feld
    {
        int feldNummer;
        int preis;
        int mietPreis;

        bool kaufenMoeglich = true;

        Spieler besitzer = null;
        Feld nextFeld = null;

        String feldKategorie;

        string sColor = "";

        /* begin mortage vars */
        //int iMortage = 0; // das Geld, dass ein Spieler bei der Belehnung des Grundstückes bekommt
        //int iBuyBackField = 0;
        bool bMortgaged = false;
        /* end mortage vars */

        public Feld(int preis, int mietPreis, ref int idCounter, string sColor = "white")
        {
            this.feldNummer = idCounter;
            this.preis = preis;
            this.mietPreis = mietPreis;
            this.sColor = sColor;
            idCounter = idCounter +1;

            //iMortage = (int)Math.Round(preis * 0.6f);
            //iBuyBackField = (int)Math.Round(iMortage * 1.1f);
        }


        public void unMortgageField(Bank bank)
        {
            besitzer.payToAccount(bank, getMortagePayBackAmount());
            setMortgaged(false);
        }

        public void setMortgaged(bool bMortgaged)
        {
            this.bMortgaged = bMortgaged;
        }

        public bool getMortgaged()
        {
            return bMortgaged;
        }        

        public string getColorField()
        {
            return sColor;
        }

        public void setKaufenMoeglich(bool kaufenMoeglich)
        {
            this.kaufenMoeglich = kaufenMoeglich;
        }

        public bool getKaufenMoeglich()
        {
            return kaufenMoeglich;
        }

        public bool darfIchDasFeldKaufen()
        {
            /*if(getKaufenMoeglich() && getBesitzer() == null)
            { 
              return true;
            }
            else
            {
              return false;
            }*/
            return getKaufenMoeglich() && getBesitzer() == null;
        }

        //public Feld(int feldNummer, int preis, int mietPreis, Feld nextFeld) : this(feldNummer, preis, mietPreis)
        //{            
        //    this.nextFeld = nextFeld;
        //}
        //ist das gleiche wie folgendes:
        //public Feld(int feldNummer, int preis, int mietPreis, Feld nextFeld)
        //{
        //    this.feldNummer = feldNummer;
        //    this.preis = preis;
        //    this.mietPreis = mietPreis;
        //    this.nextFeld = nextFeld;
        //}

        public void setFeldKategorie(string feldKategorie)
        {
            this.feldKategorie = feldKategorie;
        }

        public string getFeldKategorie()
        {
            return this.feldKategorie;
        }

        public void setNextFeld(Feld nextFeld)
        {
            this.nextFeld = nextFeld;
        }

        public Feld getNext()
        {
            return this.nextFeld;
        }

        public int getFeldNummer()
        { return this.feldNummer; }

        public Spieler getBesitzer()
        { return this.besitzer; }

        public void setBesitzer(Spieler besitzer)
        {
            this.besitzer = besitzer;
        }

        public int getPreis()
        { return this.preis; }

        public int getMietPreis()
        { return this.mietPreis; }

        public void printFeldInfo(bool printWholeInfo = true)
        {
            Console.WriteLine("Das Feld hat die id "+ feldNummer);
            
            if (getKaufenMoeglich())
            {
                Console.WriteLine("Das Feld kostet " + preis + " Euro.");
                if (besitzer == null)
                {
                    Console.WriteLine("Das Feld hat noch keinen Besitzer.");
                }
                else
                {
                    Console.WriteLine("Das Feld gehört " + besitzer.getName());
                }
                Console.WriteLine("Die Miete des Feldes beträgt " + mietPreis + " Euro.");
                Console.WriteLine("Das Feld hat ein mögliches Hypothekardarlehen von " + getMortageAmount()); // TODO: formular in function
                Console.WriteLine("Das Feld hat eine Rückzahlungshöhe von " + getMortagePayBackAmount());// TODO: formular in function
            }                       
        }

        public int getMortageAmount()
        {
            return (int)Math.Round(preis * 0.6f);
        }
        public int getMortagePayBackAmount()
        {
            return (int)Math.Round(preis * 0.6f * 1.1f);
        }

    }
}
