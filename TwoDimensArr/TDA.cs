class TDA
{
    public static void Main(string[] args)
    {
        int[,] einmalEins = new int[11, 11];
        for (int i = 0; i < einmalEins.GetLength(0); i++)
        {
            for (int j = 0; j < einmalEins.GetLength(1); j++)
            {
                einmalEins[i, j] = i * j;
            }
        }

        int dimensionCount = einmalEins.Rank;
        for (int i = 0; i < dimensionCount; i++)
        {
            Console.WriteLine("Das array " + nameof(einmalEins) + " hat in der Dimension " + i + " " + einmalEins.GetLength(i) + " Werte");
        }

        Object[] meinArr = new Object[3];

        meinArr[0] = einmalEins;
        meinArr[1] = 1;
        meinArr[2] = "hallo";

        int[,] meinZweiDimenstionales = new int[11, 11];// = ((int[,])meinArr[0]);

        //int[][] meinZweiDimenstionales = new int[11][];
        //meinZweiDimenstionales[0] = new int[]{0,1,2};
        //meinZweiDimenstionales[1] = new int[] { 3,4 };
        //meinZweiDimenstionales[2] = new int[] { 5, 6, 7, 8 };


        for (int i = 0; i < ((int[,])meinArr[0]).GetLength(0); i++)
        {
            for (int j = 0; j < ((int[,])meinArr[0]).GetLength(1); j++)
            {
                meinZweiDimenstionales[i, j] = ((int[,])meinArr[0])[i, j];
            }
        }


        meinZweiDimenstionales[0,0] = 1234;

        List<List<Object>> tada = new List<List<Object>>();

        //einmalEins[5, 5] = 111111;        

        Console.Write("  |");
        for (int i = 0; i < einmalEins.GetLength(0); i++)
        {
            Console.Write(i + "  ");
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");

        for (int i=0; i < einmalEins.GetLength(0); i++)
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
}