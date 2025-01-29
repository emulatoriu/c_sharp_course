namespace ConsoleApp1
{
    class Program
    {
        private static void printMenu(List<string> menuList)
        {
            menuList.ForEach(menu => Console.WriteLine(menu)); 
        }

        private static void clearTheConsole()
        {
            Thread.Sleep(4000);
            Console.Clear();
        }

        
        /// <summary>
        /// This is a function which returns the chosen menu point
        /// </summary>
        /// <param name="minNumber">The minimum number which needs to be chosen</param>
        /// <param name="menuPoints">The list which includes the menu</param>
        /// <returns>The chosen menu point</returns>
        private static int chooseMenu(int minNumber, List<string> menuPoints)
        {

            int maxNumber = menuPoints.Count;

            while (true)
            {
                Console.WriteLine("Please choose a convertion method from {0}-{1}", minNumber, maxNumber);

                printMenu(menuPoints);

                string chosenMenu = Console.ReadLine();

                try
                {
                    int chosenMenuConverted = int.Parse(chosenMenu);
                    if(chosenMenuConverted >= minNumber && chosenMenuConverted < maxNumber)
                    {
                        return chosenMenuConverted;
                    }
                    Console.WriteLine("Please choose only numbers from {0}-{1}", minNumber, maxNumber);
                    clearTheConsole();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please choose only numbers from {0}-{1}. {2}", minNumber, maxNumber, ex.Message);
                    clearTheConsole();
                }
            }
        }
        
        public static void Main(string[] org)
        {

            List<string> menuPoints = new List<string>();            

            menuPoints.Add("(1) Umrechnung von Celsius nach Kelvin");
            menuPoints.Add("(2) Umrechnung von Celsius nach Fahrenheit");
            menuPoints.Add("(3) Umrechnung von Kelvin nach Celsius");
            menuPoints.Add("(4) Umrechnung von Kelvin nach Fahrenheit");
            menuPoints.Add("(5) Umrechnung von Fahrenheit nach Celsius");
            menuPoints.Add("(6) Umrechnung von Fahrenheit nach Kelvin");


            int chosenMenu = chooseMenu(1, menuPoints);

            double value = 0;
            while(true)
            {
                Console.WriteLine("Please input a value");
                if(!double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Please only input numbers!");
                    continue;
                }
                break;

            }


            switch(chosenMenu)
            {
                case 1:
                    Console.WriteLine("{0} Celsius are {1} Kelvin", value, TemperaturUmrechner.celsiusToKelvin(value));
                    break;

                case 2:
                    Console.WriteLine("{0} Celsius are {1} Fahrenheit", value, TemperaturUmrechner.celsiusToFahrenheit(value));
                    break;

                case 3:
                    Console.WriteLine("{0} Kelvin are {1} Celisus", value, TemperaturUmrechner.kelvinToCelsius(value));
                    break;

                case 4:
                    Console.WriteLine("{0} Kelvin are {1} Fahrenheit", value, TemperaturUmrechner.kelvinToFahrenheit(value));
                    break;

                case 5:
                    Console.WriteLine("{0} Fahrenheit are {1} Celsius", value, TemperaturUmrechner.fahrenheitToCelsius(value));
                    break;

                case 6:
                    Console.WriteLine("{0} Fahrenheit are {1} Kelvin", value, TemperaturUmrechner.fahrenheitToKelvin(value));
                    break;

                default:
                    break;
            }



        }
    }
}