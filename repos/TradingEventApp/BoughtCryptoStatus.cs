public class BoughtCryptoStatus
{
    public Crypto BoughtCrypto { get; set; }
    public int Amount { get; set; }
    public float BoughtPrice { get; init; }
    public BoughtCryptoStatus(Crypto boughtCrypto, int amount, float boughtPrice)
    {
        BoughtCrypto = boughtCrypto;
        Amount = amount;
        BoughtPrice = boughtPrice;
    }


}