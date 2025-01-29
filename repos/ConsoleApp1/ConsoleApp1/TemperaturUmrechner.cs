using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TemperaturUmrechner
    {
        const double KELVIN_OFFSET = 273.15;
        const int FAHRENHEIT_OFFSET = 32;

        public static double celsiusToKelvin(double celsius)
        {
            return celsius + KELVIN_OFFSET;
        }

        public static double celsiusToFahrenheit(double celsius)
        {            
            return ((celsius * 9) / 5) + FAHRENHEIT_OFFSET;
        }
        public static double kelvinToCelsius(double kelvin)
        {
            return kelvin - KELVIN_OFFSET;
        }

        public static double kelvinToFahrenheit(double kelvin)
        {
            return celsiusToFahrenheit(kelvinToCelsius(kelvin));
        }

        public static double fahrenheitToCelsius(double fahrenheit)
        {
            return ((fahrenheit - FAHRENHEIT_OFFSET) * 5) / 9;
        }
        public static double fahrenheitToKelvin(double fahrenheit)
        {
            return celsiusToKelvin(fahrenheitToCelsius(fahrenheit));
        }
    }
}
