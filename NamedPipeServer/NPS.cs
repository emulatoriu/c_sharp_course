using System.IO.Pipes;
using System.Security.Principal;

class NPS
{
    static NamedPipeServerStream pipeServer;
    
    static StreamReader srPipeReader;
    static StreamWriter swPipeWriter;
    public static void Main(string[] args)
    {
        initServerPipe();
        Console.WriteLine("Waiting for a pipe client to connect...\n");        
        pipeServer.WaitForConnection();
        Console.WriteLine("Connected to client!\n");

        using (swPipeWriter = new StreamWriter(pipeServer))
        using (srPipeReader = new StreamReader(pipeServer))        
        {

            string input = "";
            string readVal = "";
            while (!input.ToLower().Equals("exit") && !readVal.ToLower().Equals("exit"))
            {
                input = Console.ReadLine();
                swPipeWriter.WriteLine(input);
                swPipeWriter.Flush();
                readVal = srPipeReader.ReadLine();
                Console.WriteLine("Received from client: " + readVal);
            }
        }

        //swPipeWriter.Close();
        //srPipeReader.Close();
        pipeServer.Close();
    }

    static void initServerPipe()
    {        
        pipeServer = new
        NamedPipeServerStream("WifiPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
    }
}