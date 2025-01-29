interface IPaymentProvider
{
    void printWithWhatYouArePayingHere();
}

public class payWithCash : IPaymentProvider
{
    void IPaymentProvider.printWithWhatYouArePayingHere()
    {
        Console.WriteLine("Here you are paying cash!");
    }
}

public class payWithCredit : IPaymentProvider
{
    void IPaymentProvider.printWithWhatYouArePayingHere()
    {
        Console.WriteLine("Here you are paying with credit card!");
    }
}

public class payWithPayPal : IPaymentProvider
{
    void IPaymentProvider.printWithWhatYouArePayingHere()
    {
        Console.WriteLine("Here you are paying with PayPal!");
    }
}

public class payWithBitCoin : IPaymentProvider
{
    void IPaymentProvider.printWithWhatYouArePayingHere()
    {
        Console.WriteLine("Here you are paying with Bitcoins!");
    }
}

public class Pay
{
    public static void Main(string[] args)
    {
        IPaymentProvider ippCash = new payWithCash();
        IPaymentProvider ippCard = new payWithCredit();
        IPaymentProvider ippPP = new payWithPayPal();
        IPaymentProvider ippBC = new payWithBitCoin();

        ippCash.printWithWhatYouArePayingHere();
        ippCard.printWithWhatYouArePayingHere();
        ippPP.printWithWhatYouArePayingHere();
        ippBC.printWithWhatYouArePayingHere();

    }
}