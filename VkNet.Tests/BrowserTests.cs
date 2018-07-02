using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests
{
	[TestFixture]
	public class BrowserTests : BaseTest
	{
		/// <summary>
		/// todo: поправить тест
		/// </summary>
		[Test]
		[Ignore(reason: "TODO: временно")]
		public void Authorize()
		{
			var browser = new Browser(logger: null);

			browser.SetAuthParams(new ApiAuthParams
			{
				ApplicationId = 123,
				Login = "qwe@qwe.ru",
				Password = "pass",
				Settings = Settings.All
			});

			var result = browser.Authorize();

			Assert.NotNull(anObject: result);
		}
	}
}