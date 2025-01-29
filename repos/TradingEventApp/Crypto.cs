public class Crypto
{
    public string Name { get; set; }
    public float InitialPrice { get; init; }
    public float CurrentPrice { get; set; }

    public Crypto(string name, float price)
    {
        this.Name = name;
        this.InitialPrice = price;
        this.CurrentPrice = price;
    }
}