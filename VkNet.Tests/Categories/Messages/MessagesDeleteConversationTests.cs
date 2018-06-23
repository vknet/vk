using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesDeleteConversationTests: BaseTest
	{
		[Test]
		public void DeleteConversation()
		{
			Url = "https://api.vk.com/method/messages.deleteConversation";

			Json = @"{
                    'response': 1
                  }";

			var result = Api.Messages.DeleteConversation(123);

			Assert.IsTrue(result);
		}
	}
}