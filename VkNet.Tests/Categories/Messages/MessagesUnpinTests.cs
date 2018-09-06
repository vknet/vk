using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesUnpinTests: BaseTest
	{
		[Test]
		public void Unpin()
		{
			Url = "https://api.vk.com/method/messages.unpin";

			Json = @"{
				'response': 1
			}";

			var result = Api.Messages.Unpin(123, 345);

			Assert.True(result);
		}
	}
}