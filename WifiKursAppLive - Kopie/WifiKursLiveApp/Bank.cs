using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Bank : AccountOwner
    {
        private const int iLosMoney = 50;
        public const int genauAufLosMultiplikator = 2;

        //static Bank instance;

        public Bank(int iStartBalance = 1000) : base(iStartBalance)
        { }

        //TODO: Evt. Singleton object of bank
        //public static Bank getBank()
        //{ 
        //    if(instance == null)
        //    {
        //        instance = new Bank();
        //    }

        //}        

        public int payLosMoney(Spieler spieler, bool bIsExactlyOnLos)
        {
            int losMoneyPaid = 0;
            if(bIsExactlyOnLos == true)
            {
                losMoneyPaid = iLosMoney * genauAufLosMultiplikator;
                payToAccount(spieler, losMoneyPaid);
            }
            else
            {
                losMoneyPaid = iLosMoney;
                payToAccount(spieler, losMoneyPaid);
            }
            return losMoneyPaid;
        }
        public bool mortgageField(Feld fieldOfPlayer)
        {            
            int iMortgage = (int)Math.Round(fieldOfPlayer.getPreis() * 0.6f);
            if (isBalanceEnough(iMortgage))
            {
                fieldOfPlayer.setMortgaged(true);
                payToAccount(fieldOfPlayer.getBesitzer(), iMortgage);
                return true;
            }

            return false;
        }

        public void showStatistics()
        {
            Console.WriteLine("Bank:");
            Console.WriteLine("Current balance is " + iBalance);
            showAccountOwnerStatistics();
        }
    }
}
