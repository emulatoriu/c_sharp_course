using System.Diagnostics;
using System.Timers;

class Sandwatch
{
    //private static Thread t = new Thread(new ThreadStart(IamTheDelegateThreadFunction));
    private static Task thread1;
    //private static Thread thread1;
    private static System.Timers.Timer thSecondTimer, oneSecondTimer;
    static CancellationTokenSource ts = new CancellationTokenSource();

    static int timeElapsed = 20;

    private static void TimeElapsedEvent(Object source, ElapsedEventArgs e)
    {
        ts.Cancel();
        thSecondTimer.Stop();
        thSecondTimer.Dispose();
    }

    private static void killHourglass()
    {
        foreach (var process in Process.GetProcessesByName("Hourglass"))
        {
            process.Kill();
        }
    }

    public static void IamTheDelegateThreadFunction()
    {
        try
        {
            Console.WriteLine("Type exit - you have 30 seconds time");
            string Eingabe;
            do
            {
                Eingabe = Console.ReadLine();
            }
            while (!Eingabe.ToLower().Equals("exit"));            

            thSecondTimer.Stop();
            thSecondTimer.Dispose();
            ts.Cancel();
        }
        catch(ThreadAbortException thabex)
        {
            Console.WriteLine($"Sorry, but 20 seconds elapsed and now your time is over - uhahahahahah");
        }
        
    }

    public static void Main(string[] args)
    {        
        thSecondTimer = new System.Timers.Timer(30000);
        // Hook up the Elapsed event for the timer. 
        thSecondTimer.Elapsed += TimeElapsedEvent;
        thSecondTimer.AutoReset = false;
        thSecondTimer.Enabled = true;
        thread1 = Task.Factory.StartNew(() => IamTheDelegateThreadFunction());

        // Begin: This code part does not belong to tasks, but is a nice addon
        ProcessStartInfo p_info = new ProcessStartInfo();
        p_info.UseShellExecute = true;
        p_info.CreateNoWindow = false;        
        p_info.FileName = "cmd.exe";        
        p_info.Arguments = $@"/c start Hourglass\Hourglass.exe";
        Process.Start(p_info);
        // End
        
        try
        {
            Console.WriteLine("About to wait for the task to complete...");
            thread1.Wait(ts.Token);
            thread1.Dispose(); // only dispose if thread finished successfully - otherwise above line will throw an exception
        }
        catch (OperationCanceledException e)
        {
            //Console.WriteLine("{0}: The wait has been canceled. Task status: {1:G}",
            //                  e.GetType().Name, thread1.Status);
            //Thread.Sleep(6000);
            //Console.WriteLine("After sleeping, the task status:  {0:G}", thread1.Status);
        }
        
        ts.Dispose();
        killHourglass();
    }
}