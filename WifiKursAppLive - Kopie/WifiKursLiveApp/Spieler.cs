using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Spieler : AccountOwner
    {

        private int id = 0;
        private string user = "";                
        //private int currentMoney = 200;
        // TODO: Spielablauf Klasse - auch wieder =0 setzen wenn man raus ist
        //private int howManyFieldsDoIHave = 0;
        private int losCounter = 0;
        private int howManyFieldsDidIGo = 0;
        private int howOftenDidIRollTheDice = 0;

        private int erhaltenesGeld = 0;
        
        //private int field = 1; // TODO

        Feld currentFeld = null;

        //private int userPayedCount = 0; // wie oft hat ein Spieler bezahlt
        //private int userPayedSum = 0; // wieviel hat der Spieler bereits bezahlt
        //private int userGetCount = 0;
        private bool isActive = true;

        Spieler nextSpieler;

        public void setNextSpieler(Spieler next)
        {
            nextSpieler = next;
        }

        public Spieler getNextSpieler()
            { return nextSpieler; }

        public Spieler(ref int id, int iStartBalance) : base(iStartBalance)
        {            
            this.id = id++;
        }

        public Spieler(ref int id, string user, int iStartBalance) : base(iStartBalance)
        {
            this.id = id++;            
            this.user = user;
        }

        public void setPlayerActive(bool active)
        { this.isActive = active; }
        

        //public void setCurrentMoney(int currentMoney)
        //{
        //    this.currentMoney = currentMoney;

        //    if (this.currentMoney < 0)
        //    {
        //        this.isActive = false;
        //        //Console.WriteLine("Spieler " + id + " mit dem Namen " + user + " ist leider raus!");
        //    }

        //}

        //public void increaseMoney(int amount)
        //{
        //    currentMoney = currentMoney + amount;
        //}


        // TODO: Spielleitung als Klasse oder Bank, die darauf schaut,
        // wie das Spiel abläuft und dass einem Spieler evt. "von außen"
        // kein Geld abgezogen werden kann (private)
        //public void modifyMoney(int amount)
        //{
        //    currentMoney += amount;
        //}

        //public void kaufeGrundstück(int Preis)
        //{
        //    currentMoney -= Preis;
        //}

        // TODO: Bankklasse + Konten(Vererbung davon: Userkonto und Bankkonto)
        // + Transaktionsklasse (von wem an wen)
        // TODO Menüpunkt Kontoauszug
        //public void getAndMakePayment(int amount)
        //{
        //    currentMoney += amount;

        //    if (amount > 0)
        //    {                
        //        erhaltenesGeld += amount;
        //        userGetCount++;
        //    }
        //    else
        //    {
        //        userPayedSum -= amount;
        //        userPayedCount++;
        //    }
        //}



        //public bool tryPay(Spieler personToBePaid, int price, out int paidMoney)
        //{            
        //    if(currentMoney >= price) // currentMoney = 20; mietpreis = 50;
        //    {
        //        //this.modifyMoney(-price); // -30 wäre der eigentliche Kontostand
        //        //personToBePaid.modifyMoney(price);
        //        this.getAndMakePayment(-price);
        //        personToBePaid.getAndMakePayment(price);
        //        paidMoney = price;
        //        return true;
        //    }
        //    else
        //    {
        //        personToBePaid.getAndMakePayment(currentMoney);
        //        getAndMakePayment(-currentMoney);
        //        isActive = false; // player is out
        //        paidMoney = currentMoney;
        //        return false;
        //    }

        //}

        public bool amIRicher(Spieler playerToCompare)
        {
            //if(currentMoney>playerToCompare.getCurrentMoney())
            if (getBalance() > playerToCompare.getBalance())
            {
                return true;
            }
            return false;

        }


        //public int getCurrentMoney()
        //    { return currentMoney; }

        //public void setUserPayedCount(int userPayedCount)
        //{
        //    this.userPayedCount = userPayedCount;
        //}

        //public int getUserPayedCount()
        //{ return userPayedCount; }

        //public int getUserGetCount()
        //{
        //    return userGetCount;
        //}
        //public void setUserPayedSum(int userPayedSum)
        //{
        //    this.userPayedSum = userPayedSum;
        //}

        //public int getUserPayedSum()
        //{ return userPayedSum; }

        public int getId()
        { return id; }

        public bool getIsActive()
            { return isActive; }

        public string getName()
        { return user; }

        public void setSpielerFeld(Feld currentFeld)
        {
            this.currentFeld = currentFeld;
        }

        public Feld getCurrentFeld()
        { return currentFeld; }

        public int getErhaltenesGeld()
        { return erhaltenesGeld; }

        public int getHowManyFieldsDoIHave()
        {
            Feld startFeld = getCurrentFeld();
            int howManyFieldsDoIHave = 0;
            do
            {
                if (startFeld.getBesitzer() != null && startFeld.getBesitzer().getId() == this.getId())
                {
                    howManyFieldsDoIHave++;
                }
                startFeld = startFeld.getNext();
            }
            while (startFeld.getFeldNummer() != getCurrentFeld().getFeldNummer());

            return howManyFieldsDoIHave;
        }

        public void increaseLosCounter()
        {
            losCounter++;
        }

        public int getLosCounter()
        {
            return losCounter;
        }

        public void addFeldCount(int iFeldCount)
        {
            howManyFieldsDidIGo += iFeldCount;
        }

        public int getHowManyFieldsDidIGo()
        {
            return howManyFieldsDidIGo;
        }

        public void showSpielerStatistik()
        {
            Console.WriteLine(getName() + ":");
            //3. Wieviel habe ich verdient
            Console.WriteLine("Verdient: " + getErhaltenesGeld()); // TODO: zu account owner
            showAccountOwnerStatistics();
            //Console.WriteLine("Anz. Erhalten: " + getUserGetCount());
            ////4. Wieviel habe ich bezahlt
            //Console.WriteLine("Bezahlt: " + getUserPayedSum());
            ////5. Wie oft habe ich bezahlt
            //Console.WriteLine("Anz. Mietzahlungen: " + getUserPayedCount());            
            //6. Wieviele Felder besitze ich - vom CurrentField
            Console.WriteLine("Anz. meiner Felder: " + getHowManyFieldsDoIHave());
            //7. Wie oft bin ich über los gegangen
            Console.WriteLine("Los Hits: " + getLosCounter());
            //8. Wieviele Felder bin ich gegangen
            Console.WriteLine("Gegangen: " + getHowManyFieldsDidIGo());

        }





    }
}
