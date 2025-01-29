using System.IO.Pipes;
using System.Security.Principal;

class NPS
{
    static NamedPipeServerStream pipeServer;

    static StreamReader srPipeReader;
    static StreamWriter swPipeWriter;
    public static void Main(string[] args)
    {
        System.Timers.Timer timer;
        timer = new System.Timers.Timer(10000);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true;
        timer.Enabled = false;

        initServerPipe();
        Console.WriteLine("Waiting for a pipe client to connect...\n");
        pipeServer.WaitForConnection();
        Console.WriteLine("Connected to client!\n");

        swPipeWriter = new StreamWriter(pipeServer);
        srPipeReader = new StreamReader(pipeServer);

        string input = "";
        string readVal = "";
        while (!input.ToLower().Equals("exit") && !readVal.ToLower().Equals("exit"))
        {
            if (!readVal.Equals("Bin gerade abwesend."))
            {
                timer.Start();
                input = Console.ReadLine();
                timer.Stop();

                swPipeWriter.WriteLine(input);
                swPipeWriter.Flush();
            }
            readVal = srPipeReader.ReadLine();
            Console.WriteLine("Received from client: " + readVal);
        }

        swPipeWriter.Close();
        srPipeReader.Close();
        pipeServer.Close();
    }

    private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        swPipeWriter.WriteLine("Bin gerade abwesend");
        swPipeWriter.Flush();
    }

    static void initServerPipe()
    {
        pipeServer = new
        NamedPipeServerStream("WifiPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
    }
}