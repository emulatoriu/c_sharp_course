class Throw
{
    
    private static double divi(double divident, double divisor)
    {
        return (divisor>0) ? divident/divisor : throw new DivideByZeroException("Division durch 0 ist nicht erlaubt!");
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Bitte gib einen Dividenten an: ");
        string divident = Console.ReadLine();
        Console.WriteLine("Bitte gib einen Divisor an: ");
        string divisor = Console.ReadLine();

        double dDivident;
        double dDivisor;

        bool bDivident = Double.TryParse(divident, out dDivident);
        bool bDivisor = Double.TryParse(divisor, out dDivisor);

        if (bDivident && bDivisor)
        {
            double dQuotient = divi(dDivident, dDivisor);
            Console.WriteLine("Das Ergebnis der Division lautet {0}", dQuotient);
        }
        else
        {
            throw new FormatException("Sowohl Divident als auch Divisor müssen Zahlen sein!");
        }
    }
}