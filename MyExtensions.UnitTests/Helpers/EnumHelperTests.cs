using MyExtensions.Enum;
using MyExtensions.Helpers;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Helpers
{
    [TestFixture]
    public class EnumHelperTests
    {
        [Test]
        [TestCase(Day.Mon, "Monday")]
        [TestCase(Day.Tue, "Tuesday")]
        [TestCase(Day.Wed, "Wednesday")]
        [TestCase(Day.Thu, "Thursday")]
        [TestCase(Day.Fri, "Friday")]
        [TestCase(Day.Sat, "Saturday")]
        [TestCase(Day.Sun, "Sunday")]
        public void GetEnumDescription_ReturnsCorrectDecription(Day day, string expected)
        {
            Assert.AreEqual(expected, EnumHelper<Day>.GetEnumDescription(day.ToString()));
        }

        [Test]
        public void GetEnumDescription_ReturnsEmptyStringWithNullProvided()
        {
            Assert.AreEqual(string.Empty, EnumHelper<Day>.GetEnumDescription(null));
        }
    }
}