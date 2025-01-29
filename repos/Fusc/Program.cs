class MainClass
{

    private static int fusc(int number)
    {
        if (number == 0 || number == 1)
        {
            return number;
        }
        else if (number % 2 == 0)
        {
            return fusc(number / 2);
        }
        else
        {
            int newNumber = (number - 1) / 2;
            return fusc(newNumber) + fusc(newNumber + 1);
        }

        //return number <=1 ? number : 
        //    number % 2 == 0 ? fusc(number/2) : 
        //    fusc((number - 1) / 2) + fusc(((number - 1) / 2) + 1);
    }


    public static void Main(String[] args)
    {
        Console.WriteLine(fusc(10));
    }
}