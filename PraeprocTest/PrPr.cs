#undef DEBUG
#define DEBUG1
#define DEBUG2



class PrPr
{    
    public static void Main(string[] args)
    {
#if DEBUG
        Console.WriteLine("We are in Debug Mode!");
#elif DEBUG1
        Console.WriteLine("We are in Debug Mode!");
#elif DEBUG2
        Console.WriteLine("We are in Debug Mode!");
#else
        Console.WriteLine("We are not in Debug Mode!");
#endif

    }
}