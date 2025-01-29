#undef DEBUG

class MainClass
{
    public static void Main(String[] args)
    {
#if DEBUG == true
        Console.WriteLine("This is a test debug");
#else
#endif
    }
}