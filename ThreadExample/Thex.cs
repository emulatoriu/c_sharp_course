class Thex
{

    public static void IamTheDelegateThreadFunction()
    {        
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"IamTheDelegateThreadFunction: {i}");
            Thread.Sleep(1);
        }        
    }

    public static void Main(string[]args)
    {
        Thread t = new Thread(new ThreadStart(IamTheDelegateThreadFunction));
        // or
        // Thread mythread = new Thread(() =>ThreadWork.MyThreadFunc(par1, par2));
        // mythread.Start();

        t.Start();

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine($"I am the main thread: {i}");            
        }

    }
}