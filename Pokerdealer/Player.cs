using System;


namespace Pokerdealer
{
	class Player
	{
		private bool status = true;
		private List<Cards> PlayerCardsHidden = new List<Cards>();
		private List<Cards> PlayerCardsVisible = new List<Cards>();
		private int Money = 0;
		public Player(int Money)
		{
			this.Money = Money;
		}

		public void AddCardHidden(Cards Card)
		{
			PlayerCardsHidden.Add(Card);
		}

		public List<Cards> getCardHidden()
        {
			return PlayerCardsHidden;
        }

		public void AddCardVisible(Cards Card)
        {
			PlayerCardsVisible.Add(Card);
        }

		public List<Cards> getCardVisible()
        {
			return PlayerCardsVisible;
        }

		public int getPlayerMoney()
        {
			return Money;
        }

		public string getPlayerCards()
        {
			string sRetVal = "";
			foreach(Cards c in PlayerCardsHidden)
            {
				sRetVal += c.ToString() + ",";

			}
			foreach (Cards c in PlayerCardsVisible)
			{
				sRetVal += c.ToString() + ",";

			}

			// remove last ','
			sRetVal = sRetVal.Substring(0, sRetVal.Length - 1);

			return sRetVal;
        }

		//public void AddPlayerMoney(int AmountToGet)
  //      {
		//	Money += AmountToGet; // Todo:Überlegen wegen Trinkgeld und Return Wert vom Trinkgeld
  //      }

		//public bool ReducePlayerMoney(int AmountToTake, Pot p)
		//{
		//	if (Money >= AmountToTake)
		//	{
		//		Money -= AmountToTake;
		//		p.increasePot(AmountToTake);
		//		return status;
		//	}
		//	else if(Money>0)
		//	{
		//		p.increasePot(Money);
		//		Money = 0;
		//		status = false;
		//		return status;
		//	}
		//	//else player is Allin
		//}


		public void fold()
        {		
			PlayerCardsHidden.Clear();
			PlayerCardsVisible.Clear();
		}
	}
}
