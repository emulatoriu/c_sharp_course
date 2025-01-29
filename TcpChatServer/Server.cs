using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer
{
    internal class Server
    {
        const string MESSAGE_END = "WIFI_END_STRING";

        private static String readIncomingMessageString(NetworkStream myNetworkStream)
        {

            if (myNetworkStream.CanRead)
            {
                byte[] myReadBuffer = new byte[1024];
                
                String myCompleteMessage = "";
                int numberOfBytesRead = 0;

                String sMessage = "**** Begin reading reply from Client";
                Console.WriteLine(DateTime.Now.ToString() + " " + sMessage);                

                // Incoming message may be larger than the buffer size.
                do
                {
                    numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    myCompleteMessage += Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead);
                  
                }
                while (!myCompleteMessage.EndsWith(MESSAGE_END));

               

                return myCompleteMessage;
            }
            else
            {
                return "";
            }
        }
        public static void HandleChatCommunication(TcpClient tcpClient)
        {
            
            NetworkStream netStr = tcpClient.GetStream();
            string sReply = "";
            string sendMsg = "";
            byte[] sendMsgInBytes;
            while (!sReply.Contains("exitAndGoodbye"))
            {
                try
                {
                    sendMsg = Console.ReadLine();
                    sendMsgInBytes = Encoding.ASCII.GetBytes(sendMsg + " " + MESSAGE_END);
                    if (netStr.CanWrite)
                    {
                        netStr.Write(sendMsgInBytes, 0, sendMsgInBytes.Length);

                        netStr.ReadTimeout = 100000;
                        sReply = readIncomingMessageString(netStr);
                        Console.WriteLine("Client: " + sReply.Split(new string[] { MESSAGE_END }, System.StringSplitOptions.None)[0]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " The Programm will be closed.");
                    break;
                }
            }
            netStr.Close();
            tcpClient.Close();
        }

        public static void Main(string[] args)
        {
            //IPAddress localAddr = IPAddress.Parse("192.168.10.10");
            //IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 42000);
            tcpListener.Start();

            while (true)
            {
                try
                {
                    
                    
                    // Connect tcp client
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    // start communication thread with connected client in a seperate thread
                    Thread netWorkHandlThread1 = new Thread(() => HandleChatCommunication(tcpClient));
                    netWorkHandlThread1.Start();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

        }
    }
}
