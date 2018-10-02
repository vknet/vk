using NUnit.Framework;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]
	public class DisableOnlineTests: BaseTest
	{
		[Test]
		public void DisableOnline()
		{
			Url = "https://api.vk.com/method/groups.disableOnline";

			Json = @"{
				'response': 1
			}";

			var result = Api.Groups.DisableOnline(3);

			Assert.IsTrue(result);
		}
	}
}