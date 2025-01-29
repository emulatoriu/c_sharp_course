public class MainClass
{

    public static int tribunacci(int which)
    {
        List<int> list = new List<int>() {1, 1, 1};
        for(int i=0; i<which-3; i++)
        {
            list.Add(list[i] + list[i + 1] + list[i + 2]);
        }

        return list[list.Count-1];

    }

    public static void Main(String[] args)
    {
        Console.WriteLine(tribunacci(6));
    }
}