using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetByConversationMessageIdTests : MessagesBaseTests
	{
		[Test]
		public void GetByConversationMessageId()
		{
			Url = "https://api.vk.com/method/messages.getByConversationMessageId";
			ReadCategoryJsonPath(nameof(GetByConversationMessageId));

			var result = Api.Messages.GetByConversationMessageId(123, new ulong[] { 123 }, new[] { "" });

			Assert.That(1, Is.EqualTo(result.Count));
		}
	}
}