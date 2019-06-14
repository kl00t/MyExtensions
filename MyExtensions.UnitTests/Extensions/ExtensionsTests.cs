using System;
using System.Collections.Generic;
using MyExtensions.Extensions;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Extensions
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        [TestCase("", 0)]
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        public void TryParse_ReturnsCorrectResult(string input, int output)
        {
            Assert.AreEqual(output, input.TryParse(0));
        }

        [Test]
        public void GetLatestNullableDate_DateReturnsCorrectResult_Null()
        {
            var myDates = new List<DateTime?>
            {
                null,
                null,
                null
            };

            Assert.IsNull(myDates.GetLatestNullableDate());
        }

        [Test]
        public void GetLatestNullableDate_DateReturnsCorrectResult()
        {
            var myDates = new List<DateTime?>
            {
                null,
                new DateTime(1979, 4, 21),
                null,
                new DateTime(2010, 4, 21)
            };

            Assert.AreEqual(new DateTime(2010, 4, 21), myDates.GetLatestNullableDate());
        }

        [Test]
        public void NullableSum_Int_ReturnsCorrectResult_Null()
        {
            var myNumbers = new List<int?>
            {
                null,null,null
            };

            Assert.IsNull(myNumbers.NullableSum());
        }

        [Test]
        public void NullableSum_Double_ReturnsCorrectResult_Null()
        {
            var myNumbers = new List<double?>
            {
                null,null,null
            };

            Assert.IsNull(myNumbers.NullableSum());
        }

        [Test]
        public void NullableSum_Int_ReturnsCorrectResult()
        {
            var myNumbers = new List<int?>
            {
                null,1,null
            };

            Assert.AreEqual(1, myNumbers.NullableSum());
        }

        [Test]
        public void NullableSum_Double_ReturnsCorrectResult()
        {
            var myNumbers = new List<double?>
            {
                null,1,null
            };

            Assert.AreEqual(1, myNumbers.NullableSum());
        }

        [Test]
        public void IntegerArray_ReturnsCorrectResult()
        {
            int[] myArray = { 1, 2, 3, 4 };

            const string expected = "('1','2','3','4')";

            var actual = myArray.ToSqlArray();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StringArray_ReturnsCorrectResult()
        {
            string[] myArray = { "4", "3", "2", "1" };

            const string expected = "('4','3','2','1')";

            var actual = myArray.ToSqlArray();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Array_ReturnsCorrectResultWithNullSeparator()
        {
            string[] myArray = { "10", "20", "30", "40" };

            const string expected = "('10','20','30','40')";

            var actual = myArray.ToSqlArray();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Array_ReturnsCorrectSingleResult()
        {
            string[] myArray = { "10" };

            const string expected = "('10')";

            var actual = myArray.ToSqlArray();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateToString_ReturnsCorrectResultInStringFormat()
        {
            const string expected = "2018-4-21";

            var myDateTime = new DateTime(2018, 4, 21);

            Assert.AreEqual(expected, myDateTime.DateToString());
        }

        [Test]
        [TestCase("1", "Sun")]
        [TestCase("2", "Mon")]
        [TestCase("3", "Tue")]
        [TestCase("4", "Wed")]
        [TestCase("5", "Thu")]
        [TestCase("6", "Fri")]
        [TestCase("7", "Sat")]
        [TestCase("", "")]
        public void ToDayExtension_ReturnsCorrectDayResult(string period, string expected)
        {
            Assert.AreEqual(expected, period.ToDay());
        }

        [Test]
        [TestCase("1", "Jan")]
        [TestCase("2", "Feb")]
        [TestCase("3", "Mar")]
        [TestCase("4", "Apr")]
        [TestCase("5", "May")]
        [TestCase("6", "Jun")]
        [TestCase("7", "Jul")]
        [TestCase("8", "Aug")]
        [TestCase("9", "Sep")]
        [TestCase("10", "Oct")]
        [TestCase("11", "Nov")]
        [TestCase("12", "Dec")]
        [TestCase("", "")]
        public void ToMonthExtension_ReturnsCorrectMonthResult(string period, string expected)
        {
            Assert.AreEqual(expected, period.ToMonth());
        }

        [Test]
        [TestCase("1", "Q1")]
        [TestCase("", "")]
        public void ToQuarterExtension_ReturnsCorrectQuarterResult(string period, string expected)
        {
            Assert.AreEqual(expected, period.ToQuarter());
        }

        [Test]
        [TestCase("20180228", "28 Feb 2018")]
        [TestCase("20180401", "01 Apr 2018")]
        [TestCase("20180104", "04 Jan 2018")]
        [TestCase("20180101", "01 Jan 2018")]
        [TestCase("20180911", "11 Sep 2018")]
        [TestCase("20181109", "09 Nov 2018")]
        [TestCase("", "")]
        public void ToDateExtension_ReturnsCorrectDateResult(string period, string expected)
        {
            Assert.AreEqual(expected, period.ToDateString());
        }

        [Test]
        [TestCase(0.0001, 0.0, 1)]
        [TestCase(0.001, 0.1, 1)]
        [TestCase(0.01, 1.0, 1)]
        [TestCase(0.1, 10.0, 1)]
        [TestCase(1.0, 100.0, 1)]
        [TestCase(null, 0.0, 1)]
        public void RoundUpExtension_ReturnsCorrectResult(double? value, double expected, int decimalPlaces)
        {
            Assert.AreEqual(expected, value.RoundUp(decimalPlaces));
        }
    }
}
