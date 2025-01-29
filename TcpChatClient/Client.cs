using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TcpChatClient
{
    internal class Client
    {
        static TcpClient tcpClient;
        static NetworkStream myNetworkStream;

        const string MESSAGE_END = "WIFI_END_STRING";
        static void Main(string[] args)
        {
            byte[] myReadBuffer = new byte[1];
            String myCompleteMessage = "";
            int numberOfBytesRead = 0;
            byte[] sendMsgInBytes;

            //string ipAddr = "176.66.79.79"; // 127.0.0.1 = "localhost"
            //string ipAddr = "127.0.0.1";
            string ipAddr = @"4.tcp.ngrok.io";
        


            try
            {
                //bool ipMatch = Regex.Match(ipAddr, @"\d +\.\d +\.\d +\.\d +").Success;
                IPAddress newIP;
                IPAddress.TryParse(ipAddr, out newIP);

                //if (!ipMatch)
                //{
                //    IPHostEntry hostEntry;

                //    hostEntry = Dns.GetHostEntry(ipAddr);
                //    if (hostEntry.AddressList.Length > 0)
                //    {
                //        ipAddr = hostEntry.AddressList[0].ToString();
                //    }
                //}


                //tcpClient = new TcpClient(newIP.ToString(), 42000); // connect to the server
                tcpClient = new TcpClient("4.tcp.ngrok.io", 17522); // connect to the server
                string sReply = "";
                myNetworkStream = tcpClient.GetStream();
                myNetworkStream.ReadTimeout = 100000;

                while (!myCompleteMessage.Contains("exitAndGoodbye"))
                {
                    myCompleteMessage = "";
                    if (myNetworkStream.CanRead)
                    {
                        // Since tcp reading is async we need to define by our own, when reading stops
                        // we defined our protocol so that a message ends with WIFI_END_STRING
                        // so we read as long we do not find this keyword

                        do
                        {
                            // read one byte of what came on
                            numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, 1);
                            myCompleteMessage += Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead);

                        }
                        while (!myCompleteMessage.EndsWith(MESSAGE_END)); // since the command has to end with character G and each charackter has the size of one byte and the message is sent bytewise, it is ensured that not more then till this end is read and not less
                        Console.WriteLine("Server: " + myCompleteMessage.Split(new string[] { MESSAGE_END }, System.StringSplitOptions.None)[0]);
                        
                        sReply = Console.ReadLine();
                        
                        sendMsgInBytes = Encoding.ASCII.GetBytes(sReply + " " + MESSAGE_END);
                        if (myNetworkStream.CanWrite)
                        {
                            myNetworkStream.Write(sendMsgInBytes, 0, sendMsgInBytes.Length);                                                        
                        }

                    }
                    else
                    {                        
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                myNetworkStream.Close();
                tcpClient.Close();
            }
        }
    }
}
