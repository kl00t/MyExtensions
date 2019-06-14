using System.Collections.Generic;
using MyExtensions.Extensions;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Extensions
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        [TestCase("  123,  456,  789  ")]
        [TestCase(" 123, 456, 789 ")]
        [TestCase("123, 456, 789")]
        [TestCase("123,456,789")]
        public void SplitStringToListInts_ReturnsListOfIds(string inputString)
        {
            var expected = new List<int> { 123, 456, 789};

            var actual = inputString.SplitStringToListInts(',');

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitStringToListInts_Returns_Empty_List_When_Exception_Caught()
        {
            var myString = "throw an exception";

            var actual = myString.SplitStringToListInts(',');

            Assert.That(actual, Is.InstanceOf<IEnumerable<int>>());
        }

        [Test]
        [TestCase("The quick brown fox jumps over the lazy dog", "fox", "The quick brown ")]
        [TestCase("The quick brown fox jumps over the lazy dog", "dog", "The quick brown fox jumps over the lazy ")]
        [TestCase("The quick brown fox jumps over the lazy dog", "", "The quick brown fox jumps over the lazy dog")]
        [TestCase("", "jdksdjdsj", "")]
        public void TrimStringIncludingAndAfterPhrase_ReturnsExpected(string inputString, string trimString, string expected)
        {
            Assert.AreEqual(expected, inputString.TrimStringIncludingAndAfterPhrase(trimString));
        }

        [Test]
        [TestCase("", 0)]
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        public void TryParse_ReturnsCorrectResult(string input, int output)
        {
            Assert.AreEqual(output, input.TryParse(0));
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
