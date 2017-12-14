using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Tests
{
    [TestFixture]
    public class BrowserTests: BaseTest
    {
        /// <summary>
        /// todo: поправить тест
        /// </summary>
        [Test, Ignore("TODO: временно")]
        public void Authorize()
        {
            var browser = new Browser(null);

            var result = browser.Authorize(123, "qwe@qwe.ru", "pass", Settings.All);
            
            Assert.NotNull(result);
        }
    }
}