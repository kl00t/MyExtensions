using System;
using MyExtensions.Extensions;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        [TestCase(2018, 8, 2, 22, DayOfWeek.Sunday)]
        [TestCase(2018, 8, 3, 23, DayOfWeek.Monday)]
        [TestCase(2018, 8, 4, 24, DayOfWeek.Tuesday)]
        [TestCase(2018, 8, 5, 25, DayOfWeek.Wednesday)]
        [TestCase(2018, 8, 6, 26, DayOfWeek.Thursday)]
        [TestCase(2018, 8, 7, 27, DayOfWeek.Friday)]
        [TestCase(2018, 8, 8, 28, DayOfWeek.Saturday)]
        public void StartOfFullWeek_ReturnsCorrectDate(int year, int month, int day, int expected, DayOfWeek dayOfWeek)
        {
            var datetime = new DateTime(year, month, day);
            var result = datetime.StartOfFullWeek(dayOfWeek);
            Assert.AreEqual(expected, result.Day);
        }

        [Test]
        [TestCase(2018, 7, 25, 22, DayOfWeek.Sunday)]
        [TestCase(2018, 7, 25, 23, DayOfWeek.Monday)]
        [TestCase(2018, 7, 25, 24, DayOfWeek.Tuesday)]
        [TestCase(2018, 7, 25, 25, DayOfWeek.Wednesday)]
        [TestCase(2018, 7, 25, 19, DayOfWeek.Thursday)]
        [TestCase(2018, 7, 25, 20, DayOfWeek.Friday)]
        [TestCase(2018, 7, 25, 21, DayOfWeek.Saturday)]
        public void StartOfWeek_ReturnsCorrectDate(int year, int month, int day, int expected, DayOfWeek dayOfWeek)
        {
            var datetime = new DateTime(year, month, day);
            var result = datetime.StartOfWeek(dayOfWeek);
            Assert.AreEqual(expected, result.Day);
        }

        [Test]
        [TestCase(2018, 7, 18, 21, DayOfWeek.Sunday)]
        [TestCase(2018, 7, 18, 22, DayOfWeek.Monday)]
        [TestCase(2018, 7, 18, 23, DayOfWeek.Tuesday)]
        [TestCase(2018, 7, 18, 24, DayOfWeek.Wednesday)]
        [TestCase(2018, 7, 18, 18, DayOfWeek.Thursday)]
        [TestCase(2018, 7, 18, 19, DayOfWeek.Friday)]
        [TestCase(2018, 7, 18, 20, DayOfWeek.Saturday)]
        public void EndOfWeek_ReturnsCorrectDate(int year, int month, int day, int expected, DayOfWeek dayOfWeek)
        {
            var datetime = new DateTime(year, month, day);
            var result = datetime.EndOfWeek(dayOfWeek);
            Assert.AreEqual(expected, result.Day);
        }
    }
}