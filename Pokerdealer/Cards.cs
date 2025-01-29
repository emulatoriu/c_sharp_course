using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokerdealer
{
    class Cards
    {
        private string cardSuit = "";
        //Ass = 1 und 14, Bube = 11, Dame = 12, König = 13
        private int cardValue = 0;

        public Cards(int cardValue, string cardSuit)
        {
            this.cardValue = cardValue;
            this.cardSuit = cardSuit;
        }

        public int getCardValue()
        {
            return cardValue;
        }

        public override string ToString() => cardSuit + cardValue;
    }
}
//Hands