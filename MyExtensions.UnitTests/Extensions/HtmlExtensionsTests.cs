using MyExtensions.Extensions;
using NUnit.Framework;

namespace MyExtensions.UnitTests.Extensions
{
    [TestFixture]
    public class HtmlExtensionsTests
    {
        [Test]
        public void UnitTest_StringToLink_ReturnsCorrectValue()
        {
            const string expected = @"<a href=""http://www.bbc.co.uk"">Click here to go to the BBC website</a>";

            const string url = "http://www.bbc.co.uk";

            var actual = url.ToLink("Click here to go to the BBC website");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnitTest_StringToLink_OpenInNewWindow_ReturnsCorrectValue()
        {
            const string expected = @"<a href=""http://www.bbc.co.uk"" target=""_blank"">Click here to go to the BBC website</a>";

            const string url = "http://www.bbc.co.uk";

            var actual = url.ToLink("Click here to go to the BBC website", true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToHtml_Returns_String_To_Html()
        {
            var expected = "<p>\r\nThis is my string\r\n</p>\r\n";

            var myString = "This is my string";

            var result = myString.ToHtml();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}