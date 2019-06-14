using System;
using MyExtensions.Helpers;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Helpers
{
    [TestFixture]
    public class CalculationHelperTests
    {
        [Test]
        [TestCase(10, 10, 0)]
        [TestCase(9, 10, 1)]
        [TestCase(8, 10, 2)]
        [TestCase(7, 10, 3)]
        [TestCase(6, 10, 4)]
        [TestCase(5, 10, 5)]
        public void Difference_ReturnsCorrectResult(double originalNumber, double newNumber, double expected)
        {
            var actual = CalculationHelper.Difference(originalNumber, newNumber);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(80, 100, -0.2)]
        [TestCase(100, 80, 0.25)]
        [TestCase(null, null, null)]
        [TestCase(0, 0, 0)]
        public void Variance_ReturnsCorrectResult(int? thisPeriod, int? comparisonPeriod, double? expected)
        {
            var actual = CalculationHelper.Variance(thisPeriod, comparisonPeriod);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(10, 11, 0.10)]
        [TestCase(10, 15, 0.5)]
        [TestCase(10, 20, 1.0)]
        [TestCase(10, 5, -0.5)]
        [TestCase(10, 1, -0.9)]
        [TestCase(10, 0, -1.0)]
        [TestCase(null, null, null)]
        [TestCase(0, 0, 0)]
        public void PercentCalculateChange_ReturnsCorrectResult(int? originalNumber, int? newNumber, double? expected)
        {
            var actual = CalculationHelper.PercentCalculateChange(originalNumber, newNumber);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(10.0d, 11.0d, 0.10d)]
        [TestCase(10.0d, 15.0d, 0.5d)]
        [TestCase(10.0d, 20.0d, 1.0d)]
        [TestCase(10.0d, 5.0d, -0.5d)]
        [TestCase(10.0d, 1.0d, -0.9d)]
        [TestCase(10.0d, 0.0d, -1.0d)]
        [TestCase(null, null, null)]
        [TestCase(0, 0, 0.0)]
        public void PercentCalculateChange_ReturnsCorrectResult(double? originalNumber, double? newNumber, double? expected)
        {
            var actual = CalculationHelper.PercentCalculateChange(originalNumber, newNumber);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 10, 0.1)]
        [TestCase(25, 100, 0.25)]
        [TestCase(50, 50, 1.0)]
        [TestCase(10, 10, 1.0)]
        [TestCase(100, 10, 10.0)]
        [TestCase(null, null, null)]
        [TestCase(0, 0, 0.0)]
        public void CaptureRate_Calculation_ReturnsCorrectResult(int? entranceCount, int? flowCount, double? expected)
        {
            var actual = CalculationHelper.CaptureRate(entranceCount, flowCount);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 10, 0.1)]
        [TestCase(1, 10, 0.1)]
        [TestCase(25, 100, 0.25)]
        [TestCase(50, 50, 1.0)]
        [TestCase(10, 10, 1.0)]
        [TestCase(100, 10, 10.0)]
        [TestCase(null, null, null)]
        [TestCase(0, 0, 0.0)]
        public void AverageConversion_Calculation_ReturnsCorrectResult(int? salesQuantity, int? entranceCount, double? expected)
        {
            var actual = CalculationHelper.ConversionRate(salesQuantity, entranceCount);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NumberOfDaysBetweenTwoDates_ReturnsCorrectResults()
        {
            const int expected = 7;
            var startDate = new DateTime(2018, 7, 10);
            var endDate = new DateTime(2018, 7, 17);
            var actualResult = CalculationHelper.DaysBetweenDates(startDate, endDate);
            Assert.AreEqual(expected, actualResult);
        }
    }
}
