using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEventApp.ChangePriceFunc
{
    internal class DecreasePrice : ChangePrice
    {
        public float changePrice(float price)
        {
            float newPrice = price - (price * new Random().Next(1, 31) / 100);
            return newPrice < 0 ? 0.1f : newPrice;
        }
    }
}
