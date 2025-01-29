class FindPrimMain
{
    private static List<int> meinePrimZahlen = new List<int>();

    static bool isNumberAPrime(int geheBis, ref int whichDivider)
    {        
        int currentNumb = 2;
        bool isDividable = false;

        meinePrimZahlen.Add(currentNumb);
        while (meinePrimZahlen.Count < geheBis)
        {
            currentNumb++;
            int i = 0;
            for (; i < meinePrimZahlen.Count; i++)
            {
                if (currentNumb % meinePrimZahlen[i] == 0)
                {
                    isDividable = true;
                    whichDivider = meinePrimZahlen[i];
                    break;
                }
            }

            if (!isDividable)
            {
                meinePrimZahlen.Add(currentNumb);
            }

            isDividable = false;
        }
        if (meinePrimZahlen.Contains(geheBis))
        {
            return true;
        }

        return false;
    }

    public static void Main(string[] args)
    {
        int geheBis = 1333;
        int whichDivider = 0;        

        if (isNumberAPrime(geheBis, ref whichDivider))
        {
            Console.WriteLine($"{geheBis} ist eine Primzahl");
        }
        else
        {
            string meinString = $"{geheBis} ist keine Primzahl und durch {whichDivider} teilbar";

            Console.WriteLine(meinString);
            
        }
        //foreach (int number in meinePrimZahlen)
        //{
        //    Console.WriteLine(number);
        //}


    }


}