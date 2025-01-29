using System.Timers;

class Tiex
{

    private static String logs = "";

    private static int timerCounterOneSecond = 0;
    private static int timerCounterTwoSecond = 0;
    private static void myEventThatOccursWhenTimerElapsed(String s)
    {        
        print(s);
    }

    private static void myEventThatOccursWhenTimerElapsed(Object source, ElapsedEventArgs e)
    {
        DateTime endTime = e.SignalTime;
        print($"The elapsed event was raised at {endTime:hh:mm:ss.fff}");                          
    }

    static void TickTimer(object state)
    {
        timerCounterOneSecond++;
        print("One second timer: " + timerCounterOneSecond);
        if(timerCounterOneSecond % 2 == 0)
        {
            timerCounterTwoSecond++;
        }
        print("Two seconds timer: " + timerCounterTwoSecond);
    }

    private static void print(String s)
    {
        Console.WriteLine(s);
        logs += s + "\n";
    }

    private static void print(String s, Object? arg)
    {
        Console.WriteLine(s, arg);
        logs += s + "\n";
    }

    public static void Main(string[] args)
    {

        Console.CancelKeyPress += delegate {
            Console.WriteLine("***********************************************");
            Console.WriteLine("***********************************************");
            Console.WriteLine(logs);
            Console.WriteLine("***********************************************");
            Console.WriteLine("***********************************************");
        };

        print("\nPress the Enter key to exit the application...\n");
        DateTime dt = DateTime.Now;
        print($"The application started at {dt:HH:mm:ss.fff}");
        Thread.Sleep(2000);
        //begin C# Version of a timer compatible with .NET standard 1.6 and below
        System.Threading.Timer OneSecondTimer;
        OneSecondTimer = new System.Threading.Timer( new TimerCallback(TickTimer), null, 0, 1000);
        //end C# Version of a timer compatible with .NET standard 1.6 and below

        // Create a timer with a two second interval.
        System.Timers.Timer TwoSecondTimer;
        TwoSecondTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        TwoSecondTimer.Elapsed += myEventThatOccursWhenTimerElapsed;
        //TwoSecondTimer.Elapsed += (Object source, ElapsedEventArgs e) => myEventThatOccursWhenTimerElapsed("Hallo");
        TwoSecondTimer.AutoReset = true;
        TwoSecondTimer.Enabled = false;
        TwoSecondTimer.Start();
        Console.ReadLine();
        // stop the Threading Timer
        //OneSecondTimer.Change(Timeout.Infinite, Timeout.Infinite);

        // stop timers timer
        TwoSecondTimer.Stop();        
        TwoSecondTimer.Dispose();

        

    }
}