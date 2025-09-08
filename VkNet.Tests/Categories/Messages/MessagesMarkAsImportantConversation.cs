using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesMarkAsImportantConversation : MessagesBaseTests
{
	[Fact(DisplayName = "Mark as important conversation")]
	public void MarkAsImportantConversation()
	{
		Url = "https://api.vk.ru/method/messages.markAsImportantConversation";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsImportantConversation(123);

		result.Should()
			.BeTrue();
	}
}