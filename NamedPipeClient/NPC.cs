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
            pipeClient =
               new NamedPipeClientStream("127.0.0.1", "WifiPipe",
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
        while (!input.ToLower().Equals("exit") && !readVal.ToLower().Equals("exit"))
        {
            readVal = srPipeReader.ReadLine();
            Console.WriteLine("Received from Server:" + readVal);
            input = Console.ReadLine();
            swPipeWriter.WriteLine(input);
            swPipeWriter.Flush();            
        }

        swPipeWriter.Close();
        srPipeReader.Close();
        pipeClient.Close();

    }
}