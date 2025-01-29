using System.IO.Pipes;

class NPC
{
    static NamedPipeClientStream pipeClient;

    static StreamReader srPipeReader;
    static StreamWriter swPipeWriter;

    static void initPipe()
    {
        try
        {
            pipeClient = new NamedPipeClientStream("127.0.0.1", "WifiPipe",
                   PipeDirection.InOut);
            pipeClient.Connect();
            Console.WriteLine("Connected to Server");
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem when initializing the pipe: " + e.Message);
        }
    }
    public static void Main(string[] args)
    {
        initPipe();

        swPipeWriter = new StreamWriter(pipeClient);
        srPipeReader = new StreamReader(pipeClient);

        string input = "";
        string readVal = "";
        System.Timers.Timer timerClient;
        timerClient = new System.Timers.Timer(10000);
        timerClient.Elapsed += TimerClient_Elapsed;
        timerClient.AutoReset = false;

        while (!input.ToLower().Equals("exit") && !readVal.ToLower().Equals("exit"))
        {
            readVal = srPipeReader.ReadLine();
            Console.WriteLine("Received from Server:" + readVal);
            if (!readVal.Equals("Bin gerade abwesend"))
            {

                timerClient.Start();
                input = Console.ReadLine();
                timerClient.Stop();
                swPipeWriter.WriteLine(input);
                swPipeWriter.Flush();
            }
        }

        swPipeWriter.Close();
        srPipeReader.Close();
        pipeClient.Close();

    }

    private static void TimerClient_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        swPipeWriter.WriteLine("Bin gerade abwesend.");
        swPipeWriter.Flush();
    }
}
