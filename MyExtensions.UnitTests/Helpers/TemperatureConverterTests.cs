using MyExtensions.Helpers;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Helpers
{
    [TestFixture]
    public class TemperatureConverterTests
    {
        [Test]
        [TestCase(-100, -148)]
        [TestCase(-10.1, 13.82)]
        [TestCase(-10, 14)]
        [TestCase(-1, 30.2)]
        [TestCase(0, 32)]
        [TestCase(1, 33.8)]
        [TestCase(1.1, 33.98)]
        [TestCase(10, 50)]
        [TestCase(10.1, 50.18)]
        [TestCase(100, 212)]
        public void ConvertCelciusToFahrenheit(double celcius, double expected)
        {
            var actual = TemperatureConverter.ConvertCelciusToFahrenheit(celcius);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(-100, -73.33)]
        [TestCase(-10.1, -23.39)]
        [TestCase(-10, -23.33)]
        [TestCase(-1, -18.33)]
        [TestCase(0, -17.78)]
        [TestCase(1, -17.22)]
        [TestCase(1.1, -17.17)]
        [TestCase(10, -12.22)]
        [TestCase(10.1, -12.17)]
        [TestCase(100, 37.78)]
        public void ConvertFahrenheitToCelcius(double fahrenheit, double expected)
        {
            var actual = TemperatureConverter.ConvertFahrenheitToCelcius(fahrenheit);
            Assert.AreEqual(expected, actual);
        }
    }
}
