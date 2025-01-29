using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client Client = new ServiceReference1.Service1Client();

            Console.WriteLine(Client.GetData(7));
            Console.ReadLine();
        }
    }
}
