using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetConversationsByIdTests : MessagesBaseTests
{
	[Fact(DisplayName = "Get conversations by id")]
	public void GetConversationsById()
	{
		Url = "https://api.vk.ru/method/messages.getConversationsById";
		ReadCategoryJsonPath(nameof(GetConversationsById));

		var result = Api.Messages.GetConversationsById([123]);

		result.Count.Should()
			.Be(1);
	}
}