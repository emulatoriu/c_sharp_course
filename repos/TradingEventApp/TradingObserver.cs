internal class TradingObserver
{
    public String Name { get; set; }
    List<Crypto> interestingCoins { get; init; } = new List<Crypto>();

    public int PriceBuyWhenFallPercentage { get; init; }
    public int PriceSellWhenRaisePercentage { get; init; }

    public float Budget { get; set; }

    //public List<BoughtCryptoStatus> boughtCryptoStatuses { get; init; }
    public List<Crypto> boughtCrypto{ get; init; } = new List<Crypto>();


    public TradingObserver(float Budget, int fallPercent, int raisePercent, String name, params Crypto[] coins)
    {
        this.Budget = Budget;
        PriceBuyWhenFallPercentage = fallPercent;
        PriceSellWhenRaisePercentage = raisePercent;
        Name = name;
        interestingCoins.AddRange(coins);
    }

    public void getNotifiedCryptoChanged(object sender, EventArgs e)
    {
        Console.WriteLine($"{Name} here");
        Console.WriteLine($"Current Budget: {Budget}");
        interestingCoins.ForEach(coin =>
        {
            if(coin.CurrentPrice <= coin.InitialPrice - (coin.InitialPrice * PriceBuyWhenFallPercentage/100))
            {
                int amountBought = 0;
                while(Budget - coin.CurrentPrice > 0)
                {
                    boughtCrypto.Add(coin);
                    Budget -= coin.CurrentPrice;                    
                    amountBought++;
                }
                if(amountBought > 0)
                {
                    Console.WriteLine($"Bought {amountBought} {coin.Name} for each " +
                        $"{coin.CurrentPrice} in total {amountBought*coin.CurrentPrice}");
                }

            }
            else if(boughtCrypto.Contains(coin) && 
                    coin.CurrentPrice >= coin.InitialPrice + (coin.InitialPrice * PriceSellWhenRaisePercentage / 100))
            {
                int amountOfCoins = boughtCrypto.Where(current => current.Equals(coin)).Count();
                float soldPrice = coin.CurrentPrice * amountOfCoins;
                Budget += soldPrice;
                boughtCrypto.RemoveAll(current => current.Equals(coin));
                Console.WriteLine($"Sold {amountOfCoins} {coin.Name}, each for {coin.CurrentPrice}, in total {soldPrice}");                
            }
        });
        Console.WriteLine($"NewBudget: {Budget}");
    }

    public void test()
    {
        interestingCoins.ForEach(coin => Console.WriteLine(coin.Name + ": " + coin.CurrentPrice));
    }
}