using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEventApp.ChangePriceFunc
{
    internal class IncreasePrice : ChangePrice
    {
        public float changePrice(float price)
        {
            return price + (price * new Random().Next(1, 31) / 100);
        }
    }
}
