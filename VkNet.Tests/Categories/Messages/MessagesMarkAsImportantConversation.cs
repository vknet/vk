using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages;

public class MessagesMarkAsImportantConversation : MessagesBaseTests
{
	[Test]
	[DisplayName("Mark as important conversation")]
	public void MarkAsImportantConversation()
	{
		Url = "https://api.vk.ru/method/messages.markAsImportantConversation";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsImportantConversation(123);

		result.Should()
			.BeTrue();
	}
}