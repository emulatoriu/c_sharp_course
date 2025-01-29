class Breakfast
{
    static void storyTeller(string thingToTell, int waitTime)
    {
        for(int i=0; i<thingToTell.Length;i++)
        {
            Console.Write(thingToTell.ElementAt(i));
            Thread.Sleep(waitTime);
        }
        Console.WriteLine();
    }

    static async Task makeCoffee()
    {
        Console.WriteLine("Making Coffee....");
        await doSomethingLoop("Make Coffee");
    }
    static async Task makeEggs()
    {
        Console.WriteLine("Making Eggs....");
        await doSomethingLoop("Make Eggs");
    }

    static async Task fryBacon()
    {
        Console.WriteLine("Frying bacon....");
        await doSomethingLoop("Fry");
    }
    static async Task toastBread()
    {
        Console.WriteLine("Toasting bread....");
        await doSomethingLoop("Toast");        
    }

    static async Task doSomethingLoop(string caller)
    {        
        await Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(caller + " doing....");
                Task.Delay(100).Wait();
            }
        });        
    }

    static async Task<int> asyncWithRetVal()
    {
        return 777;
    }
    static async Task Main(string[] args)
    {
        storyTeller("Let´s make some breakfast - starting time is " + DateTime.Now, 30);
        storyTeller("Let´s start with coffee", 30);
        makeCoffee();
        Console.WriteLine("coffee is ready");

        storyTeller("Ok, let´s make some eggs", 30);
        makeEggs();
        Console.WriteLine("eggs are ready");

        storyTeller("Ok, let´s fry some bacon", 30);
        fryBacon();
        Console.WriteLine("bacon are ready");

        storyTeller("Ok, let´s toast some bread", 30);
        toastBread();        
        Console.WriteLine("toast is ready");

        storyTeller("Breakfast is done at " + DateTime.Now, 30);

        //Get the datatype value of an async task
        //Task<int> asyncWRetVal = asyncWithRetVal();
        //int finalRes = await asyncWRetVal;
        int finalRes = await asyncWithRetVal();
        Console.WriteLine("Final = " + finalRes);
    }
}