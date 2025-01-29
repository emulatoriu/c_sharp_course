using System;

namespace Monopoly
{
    class AccountOwner
    {        
        protected int iBalance = 200;

        private int userPayedCount = 0; // wie oft hat ein Spieler bezahlt
        private int userPayedSum = 0; // wieviel hat der Spieler bereits bezahlt
        private int userGetCount = 0;

        public AccountOwner(int iBalance)
        {            
            this.iBalance = iBalance;
        }

        public int getBalance()
        {
            return iBalance;
        }       

        private void addToBalance(int amount)
        {
            iBalance += amount;
            userGetCount++;
        }

        public void payToAccount(AccountOwner accountOwnerToPay, int amount)
        {
            accountOwnerToPay.addToBalance(amount);
            iBalance -= amount;
            userPayedCount ++;
            userPayedSum += amount;
        }

        public bool isBalanceEnough(int amount)
        {
            /*
             * if(iBalance >= amount == true)
             * {
             *   return true;
             * }
             * else
             * {
             *   return false;
             * }
             * 
             */
            return iBalance >= amount;
        }

        public void showAccountOwnerStatistics()
        {
            Console.WriteLine("Anz. Erhalten: " + userGetCount);
            //4. Wieviel habe ich bezahlt
            Console.WriteLine("Bezahlt: " + userPayedSum);
            //5. Wie oft habe ich bezahlt
            Console.WriteLine("Anz. Mietzahlungen: " + userPayedCount);            
        }
        


    }
}
