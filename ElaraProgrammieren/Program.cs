public class Program
{

    static void test(int? testvar)
    {
        if(testvar.HasValue)
        {

        }
    }
    static void Main()
    {
        int ElarasErgebnis = 6 + 2;
        string ElarasNachricht = "Hallo Elara, dein Ergebnis lautet " + ElarasErgebnis;
        Console.WriteLine(ElarasNachricht);


        int? bla = 0;
        int a = bla ?? -1;
        Console.WriteLine(a);
        test(a);
    }
}