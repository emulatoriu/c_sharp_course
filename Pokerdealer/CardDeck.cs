using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokerdealer
{
    internal class CardDeck
    {
        private List<Cards> cardDeck = new List<Cards>();
        
        private string[] cardSuitArr = { "Herz", "Karo", "Pic", "Treff" };

        public CardDeck()
        {
            foreach (string cardSuit in cardSuitArr)
            {
                for (int i = 0; i < 13; i++)
                {
                    cardDeck.Add(new Cards(i + 2, cardSuit));
                }
            }

        }

        public List<Cards> shuffleMyDeck()
        {
            var rnd = new Random();
            return cardDeck.OrderBy(item => rnd.Next()).ToList<Cards>();
        }
    }
}
