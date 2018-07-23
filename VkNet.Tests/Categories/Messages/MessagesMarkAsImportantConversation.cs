using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesMarkAsImportantConversation : BaseTest
	{
		[Test]
		public void MarkAsImportantConversation()
		{
			Url = "https://api.vk.com/method/messages.markAsImportantConversation";

			Json = @"{
                    'response': 1
                  }";

			var result = Api.Messages.MarkAsImportantConversation(123, true);

			Assert.IsTrue(result);
		}
	}
}