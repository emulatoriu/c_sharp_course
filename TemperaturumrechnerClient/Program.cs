using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturumrechnerClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //client.insertKunde(new ServiceReference1.Kunden() { Email = "e.e@e.at", Vorname = "Emad", Nachname = "Easa", Password = "123456" });
            ServiceReference1.AuthenticationToken auth = new ServiceReference1.AuthenticationToken();
            //Todo: catch System.TimeoutException
            bool loginWorked;
            loginWorked = client.login("e.e@e.at", "123456", ref auth);
            
            if(loginWorked)
            {
                Console.WriteLine("Yeahhhhhhh");

                double result;
                bool funcWorked = client.CelsiusToFahrenheit(50, auth, out result);
                if(funcWorked)
                {
                    Console.WriteLine("Celsius to Fahrenheit = " + result);
                }
                else
                {
                    Console.WriteLine("Function did not work");
                }
                
            }
            

            int myRefVal = 0;
            //client.GetData(5);
            //Console.WriteLine("MeinRef = " + myRefVal);
            Console.ReadLine();


        }
    }
}
