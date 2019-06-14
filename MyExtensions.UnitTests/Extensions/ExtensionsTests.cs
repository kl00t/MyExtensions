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
        public void Round_ReturnsDefaultResultWhenNull()
        {
            double? input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = input.Round();

            Assert.IsNull(actual);
        }

        [Test]
        [TestCase(9.9999, 2, 10.0)]
        public void Round_ReturnsCorrectResult(double input, int round, double expected)
        {
            var actual = input.Round(round);

            Assert.IsInstanceOf<double>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(9.9999, 2, 10.0)]
        public void RoundUp_ReturnsCorrectResult(double input, int round, double expected)
        {
            var actual = input.Round(round);

            Assert.IsInstanceOf<double>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToArray_ReturnsIntegerArray()
        {
            var myIntegerList = new List<int?> {null, -1, 0, 1};

            var actual = myIntegerList.ToArray();

            Assert.IsInstanceOf<int?[]>(actual);
            Assert.AreEqual(4, actual.Length);
        }

        [Test]
        public void StringArray_ReturnsDelimitedList()
        {
            const string expected = "2,4,8,16,32,64";
            var array = new[] { "2", "4", "8", "16", "32", "64" };

            var actual = array.ToDelimitedList();

            Assert.IsInstanceOf<string>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IntegerArray_ReturnsDelimitedList()
        {
            const string expected = "1,2,4,8,16,32";
            var array = new[] {1, 2, 4, 8, 16, 32};

            var actual = array.ToDelimitedList();

            Assert.IsInstanceOf<string>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("99", 99)]
        [TestCase("0", 0)]
        public void TryParse_ReturnsResultWhenParsedSuccessfully(string myString, int expected)
        {
            var actual = myString.TryParse(5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", 0)]
        [TestCase("9.9", 0)]
        public void TryParse_ReturnsDefaultResultWhenNotParsedSuccessfully(string myString, int expected)
        {
            var actual = myString.TryParse(0);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void ToGuid_ReturnsValidGuidResult()
        {
            const string myGuidString = "F7A1DDA9-176A-4DB5-A5D3-4203BAE71DCE";
            var actual = myGuidString.ToGuid();
            Assert.IsInstanceOf<Guid>(actual);
            Assert.AreEqual(myGuidString.ToLowerInvariant(), actual.ToString());
        }

        [Test]
        [TestCase("")]
        [TestCase("INVALID GUID STRING")]
        public void ToGuid_ReturnsInvalidGuidResult(string myGuidString)
        {
            var actual = myGuidString.ToGuid();
            Assert.IsInstanceOf<Guid>(actual);
            Assert.AreEqual(Guid.Empty, actual);
        }

        [Test]
        public void ToArray_TakesIEnumerableList_ReturnsArray()
        {
            var myList = new List<int?> { 0, 1, 2, 4, 8, 16, 32, 64 };
            var actual = myList.ToArray();
            Assert.IsInstanceOf<int?[]>(actual);
            Assert.AreEqual(8, actual.Length);
        }

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
