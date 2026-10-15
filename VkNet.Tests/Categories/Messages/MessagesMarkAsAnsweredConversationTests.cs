using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages;

public class MessagesMarkAsAnsweredConversationTests : MessagesBaseTests
{
	[Test]
	[DisplayName("Mark as answered conversation")]
	public void MarkAsAnsweredConversation()
	{
		Url = "https://api.vk.ru/method/messages.markAsAnsweredConversation";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsAnsweredConversation(123);

		result.Should()
			.BeTrue();
	}
}