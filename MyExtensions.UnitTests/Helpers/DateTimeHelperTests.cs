using System;
using MyExtensions.Helpers;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Helpers
{
    [TestFixture]
    public class DateTimeHelperTests
    {
        private DateTimeHelper _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new DateTimeHelper();
        }

        [Test]
        public void GetDateTimeNow_ReturnsCurrentDateTest()
        {
            Assert.AreEqual(DateTime.Today, _sut.GetDateTimeNow().Date);
        }

        [Test]
        public void GetDateTimeToday_ReturnCurrentDateTest()
        {
            var expected = DateTime.Today.Date;

            var actual = _sut.GetDateToday();

            Assert.AreEqual(expected, actual);
        }
    }
}
