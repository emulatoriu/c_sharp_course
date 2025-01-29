class TDA
{
    private static void printModuloMatrix(int modulo)
    {
        int[,] einmalEins = new int[11, 11];
        for (int i = 0; i < einmalEins.GetLength(0); i++)
        {
            for (int j = 0; j < einmalEins.GetLength(1); j++)
            {
                einmalEins[i, j] = (i * j) % modulo;
            }
        }

        Console.Write("* |");
        for (int i = 0; i < einmalEins.GetLength(0); i++)
        {
            Console.Write(i + "  ");
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");

        for (int i = 0; i < einmalEins.GetLength(0); i++)
        {
            if (i < 10)
            {
                Console.Write(i + " |");
            }
            else
            {
                Console.Write(i + "|");
            }
            for (int j = 0; j < einmalEins.GetLength(1); j++)
            {
                Console.Write(einmalEins[i, j] + "  ");
            }
            Console.WriteLine();
        }        

    }

    private static string tellMeIfNumberEven(int i)
    {
        return i % 2 == 0 ? "yes" : "no";
        /*
         * if(i%2 == 0)
         * {
         *   return "yes";
         * }
         * else  
         * {  
         *   return "no"; 
         * }
         */
    }

    public static void Main(string[] args)
    {
        int modulo = 2;
        Console.WriteLine("Matrix modulo " + modulo);
        Console.WriteLine();
        printModuloMatrix(modulo);
        modulo = 3;        
        Console.WriteLine();
        Console.WriteLine("Matrix modulo " + modulo);
        Console.WriteLine();
        printModuloMatrix(modulo);
        modulo = 4;
        Console.WriteLine();
        Console.WriteLine("Matrix modulo " + modulo);
        Console.WriteLine();
        printModuloMatrix(modulo);

        for(int i=0; i<1000; i++)
        {
            Console.WriteLine("Is " + i + " even? " + tellMeIfNumberEven(i));
        }
    }
}