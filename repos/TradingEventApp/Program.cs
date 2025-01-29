
using TradingEventApp;
using TradingEventApp.ChangePriceFunc;

class MainClass
{
    static void Main(string[] args)
    {
        Crypto crazyCoin = new Crypto("crazy", 100);
        Crypto superCoin = new Crypto("super", 22000);
        Crypto mamaCoin = new Crypto("mama", 3000000);
        Crypto coinCoin = new Crypto("coin", 1);
        Crypto powerCoin = new Crypto("power", 45);
        Crypto lazyCoin = new Crypto("lazy", 7);

        List<ChangePrice> priceChanger = new List<ChangePrice>() { new IncreasePrice(), new DecreasePrice()};

        TradingSubscriber tradingSubscriber = new TradingSubscriber(new List<Crypto>(), priceChanger);
        tradingSubscriber.addCryptos(crazyCoin, superCoin, mamaCoin, coinCoin, powerCoin, lazyCoin);


        TradingObserver tradingObserver1 = new TradingObserver(1_000, 15, 15, "observer1", crazyCoin, superCoin, mamaCoin);
        TradingObserver tradingObserver2 = new TradingObserver(5_000, 15, 15, "observer2", coinCoin, powerCoin, lazyCoin);

        //tradingObserver1.test();
        //Console.WriteLine("");
        //Console.WriteLine("");
        //Console.WriteLine("");
        tradingSubscriber.PriceChanged += tradingObserver1.getNotifiedCryptoChanged;
        tradingSubscriber.PriceChanged += tradingObserver2.getNotifiedCryptoChanged;

        Statistics statistics1 = new Statistics("Observer1");
        Statistics statistics2 = new Statistics("Observer2");
        for (int i=0; i<1000; i++)
        {
            tradingSubscriber.modifyPrice();
            statistics1.addBudget(tradingObserver1.Budget);
            statistics2.addBudget(tradingObserver2.Budget);
        }

        statistics1.generateStatisticsFile();
        statistics2.generateStatisticsFile();



        //System.Timers.Timer timer;
        //timer = new System.Timers.Timer(5000);
        //// Hook up the Elapsed event for the timer. 
        //timer.Elapsed += tradingSubscriber.whenTimerElapsed;
        ////TwoSecondTimer.Elapsed += (Object source, ElapsedEventArgs e) => myEventThatOccursWhenTimerElapsed("Hallo");
        //timer.AutoReset = true;
        //timer.Enabled = false;
        //timer.Start();        

        //tradingObserver1.test();

    }
}