using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TradingEventApp.ChangePriceFunc;

namespace TradingEventApp
{
    internal class TradingSubscriber
    {

        public event EventHandler PriceChanged;

        public List<Crypto> cryptos { get; init; }

        public List<ChangePrice> PriceChanger { get; init; }
        
        public TradingSubscriber(List<Crypto> cryptos, List<ChangePrice> priceChanger)
        {
            this.cryptos = cryptos;
            this.PriceChanger = priceChanger;
        }

        public void addCryptos(params Crypto[] cryptos)
        {
            this.cryptos.AddRange(cryptos);
        }

        public void modifyPrice()
        {
            Crypto chosen = cryptos[new Random().Next(0, cryptos.Count())];
            chosen.CurrentPrice = PriceChanger[new Random().Next(0, PriceChanger.Count())].changePrice(chosen.CurrentPrice);
            NotifyPriceChanged();
        }

        private void NotifyPriceChanged()
        {
            if(PriceChanged != null)
            {
                PriceChanged(this, EventArgs.Empty);
            }
        }

        public void whenTimerElapsed(Object source, ElapsedEventArgs e)
        {
            modifyPrice();
        }
    }
}
