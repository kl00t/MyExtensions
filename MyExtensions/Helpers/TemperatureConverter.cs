using System;

namespace MyExtensions.Helpers
{
    public static class TemperatureConverter
    {
        public static double ConvertCelciusToFahrenheit(double celcius)
        {
            var value = ((9.0 / 5.0) * celcius) + 32;
            return Math.Round(value, 2);
        }

        public static double ConvertFahrenheitToCelcius(double fahrenheit)
        {
            var value = (5.0 / 9.0) * (fahrenheit - 32);
            return Math.Round(value, 2);
        }
    }
}
