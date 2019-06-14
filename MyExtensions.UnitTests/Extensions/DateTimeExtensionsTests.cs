using System;
using System.Collections.Generic;
using MyExtensions.Extensions;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        

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

        
        [Test]
        public void DateExtension_Returns_True_WhenDateIsAfterStartDate()
        {
            var dateToCheck = new DateTime(2018, 3, 20);
            var startDate = new DateTime(2018, 3, 10);

            Assert.That(dateToCheck.IsAfter(startDate), Is.True);
        }

        [Test]
        public void DateExtension_Returns_False_WhenDateIsBeforeStartDate()
        {
            var dateToCheck = new DateTime(2018, 3, 1);
            var startDate = new DateTime(2018, 3, 10);

            Assert.That(dateToCheck.IsAfter(startDate), Is.False);
        }

        [Test]
        public void DateExtension_Returns_True_WhenDateIsBeforeEndDate()
        {
            var dateToCheck = new DateTime(2018, 3, 1);
            var endDate = new DateTime(2018, 3, 10);

            Assert.That(dateToCheck.IsBefore(endDate), Is.True);
        }

        [Test]
        public void DateExtension_Returns_False_WhenDateIsAfterEndDate()
        {
            var dateToCheck = new DateTime(2018, 3, 20);
            var endDate = new DateTime(2018, 3, 10);

            Assert.That(dateToCheck.IsBefore(endDate), Is.False);
        }

        [Test]
        public void DateExtension_Returns_True_WhenDateIsWithinValidRange()
        {
            var dateToCheck = new DateTime(2018, 3, 26);
            var startDate = new DateTime(2018, 3, 25);
            var endDate = new DateTime(2018, 3, 27);

            var result = dateToCheck.IsInRange(startDate, endDate);

            Assert.IsTrue(result);
        }

        [Test]
        public void DateExtension_Returns_False_WhenDateIsNotWithinValidRange()
        {
            var dateToCheck = new DateTime(2018, 3, 26);
            var startDate = new DateTime(2018, 3, 27);
            var endDate = new DateTime(2018, 3, 28);

            var result = dateToCheck.IsInRange(startDate, endDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void DateExtension_Returns_False_WhenDateIsAfterDateRange()
        {
            var dateToCheck = new DateTime(2018, 3, 26);
            var startDate = new DateTime(2018, 3, 24);
            var endDate = new DateTime(2018, 3, 25);

            var result = dateToCheck.IsInRange(startDate, endDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void DateExtension_Returns_False_WhenDateIsAfterStartDate()
        {
            var dateToCheck = new DateTime(2018, 3, 25);
            var startDate = new DateTime(2018, 3, 28);
            var endDate = new DateTime(2018, 3, 29);

            var result = dateToCheck.IsInRange(startDate, endDate);

            Assert.IsFalse(result);
        }

        [Test]
        public void DateExtension_Returns_Correct_Response_using_TestDataSource([ValueSource(nameof(_testData))]TestData testData)
        {
            var result = testData.DateToCheck.IsInRange(testData.StartDate, testData.EndDate);
            Assert.AreEqual(testData.ExpectedResult, result);
        }

        public class TestData
        {
            public DateTime DateToCheck { get; set; }
            public DateTime StartDate{ get; set; }
            public DateTime EndDate { get; set; }
            public bool ExpectedResult{ get; set; }

            public override string ToString()
            {
                return
                    $"{nameof(TestData)} = DateToCheck : {DateToCheck}; StartDate : {StartDate}; EndDate : {EndDate}; ExpectedResult : {ExpectedResult}";
            }
        }

        private static readonly TestData[] _testData = {
            new TestData
            {
                DateToCheck = new DateTime(2018,3,25),
                StartDate = new DateTime(2018,3,25),
                EndDate = new DateTime(2018,3,30),
                ExpectedResult= true
            },
            new TestData
            {
                DateToCheck = new DateTime(2018,3,25),
                StartDate = new DateTime(2018,3,24),
                EndDate = new DateTime(2018,3,25),
                ExpectedResult= true
            },
            new TestData
            {
                DateToCheck = new DateTime(2018,3,25),
                StartDate = new DateTime(2018,3,25),
                EndDate = new DateTime(2018,3,30),
                ExpectedResult= true
            },
            new TestData
            {
                DateToCheck = new DateTime(2018,3,25),
                StartDate = new DateTime(2018,3,26),
                EndDate = new DateTime(2018,3,30),
                ExpectedResult= false
            }
        };
    }
}