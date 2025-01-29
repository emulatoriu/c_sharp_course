class Program
{

    private static bool divide(int iDivident, int iDivisor, out double dErg)
    {
        dErg = -1;
        try
        {
            dErg = iDivident / iDivisor;
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    public static void Main(string[] args)
    {
        int a = 5;
        int b = 0;

        double dResult;

        bool bDivisionWorked = divide(a, b, out dResult);

        //int myOut;
        //bool bla = int.TryParse("5", out myOut);

        if(bDivisionWorked)
        {
            Console.WriteLine("Ergebnis = " + dResult);
        }
        else
        {
            Console.WriteLine("Division hat leider nicht funktioniert: " + dResult);
        }


    }

}