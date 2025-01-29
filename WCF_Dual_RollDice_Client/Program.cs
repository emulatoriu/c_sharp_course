using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCF_Dual_RollDice_Client.ServiceReference1;

namespace WCF_Dual_RollDice_Client
{
    internal class Program
    {
        static ServiceReference2.Service1Client client2;
        static string sPlayerName = "eMu";
        static void Main(string[] args)
        {
            //// Construct InstanceContext to handle messages on callback interface
            //InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            //// Create a client
            //CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);
            
            client2 = new ServiceReference2.Service1Client(new CallbackHandler2());

            //client.AddTo(5);
            ////Console.ReadLine();
            //client.AddTo(15);
            //Console.ReadLine();
            sPlayerName = sPlayerName+DateTime.Now.ToString();
            Console.WriteLine("Your Player Name is: " + sPlayerName);
            client2.RegUser(sPlayerName);
            //rollTheDice();
            //client2.tellMeReply();

            Console.ReadLine();
            //int i = 0;


        }

        

        [CallbackBehavior(ConcurrencyMode= ConcurrencyMode.Reentrant)] // verhindert, dass in GameStarted ein Deadlock entsthet, da wir dort eine Funktion vom Server aufrufen bevor unsere Callback beendet wurde
        private class CallbackHandler2 : ServiceReference2.IService1Callback
        {
            public CallbackHandler2()
            {

            }

            public void GiveInfo(string text)
            {
                Console.WriteLine(text);
            }

            public void GameStarted()
            {
                Console.WriteLine("Das Spiel beginnt");

                //Console.ReadLine();
                //rollTheDice();
                int gew = client2.Roll(sPlayerName);
                //Task<int> gew = rollTheDice();
                Console.WriteLine($"Du hast {gew} gewürfelt");                
            }

            //static async Task<int> rollTheDice()
            //{
            //    return await client2.RollAsync(sPlayerName);
            //}
        }
        private class CallbackHandler : ICalculatorDuplexCallback
        {
            public void Equals(double result)
            {
                throw new NotImplementedException();
            }

            public void Equation(string eqn)
            {
                throw new NotImplementedException();
            }
        }
    }
}
