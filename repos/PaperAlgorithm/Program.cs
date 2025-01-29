class MainClass
{

    private static String invert(string sequence)
    {
        String result = "";
        for(int i= sequence.Length-1; i>=0; i--)
        {
            char[] arr = sequence.ToCharArray();
            if (arr[i].Equals('1'))
            {
                result += "0";
            }
            else
            {
                result += "1";
            }
        }
        return result;
    }

    public static void Main(String[] args)
    {
        String lastSequence = "1";

        for(int i=0; i<9; i++)
        {
            Console.WriteLine(lastSequence);
            lastSequence = lastSequence + "1" + invert(lastSequence);
        }
    }
}