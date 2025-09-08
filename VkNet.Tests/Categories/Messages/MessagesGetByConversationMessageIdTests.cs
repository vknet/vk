using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetByConversationMessageIdTests : MessagesBaseTests
{
	[Fact(DisplayName = "Get by conversation message id")]
	public void GetByConversationMessageId()
	{
		Url = "https://api.vk.ru/method/messages.getByConversationMessageId";
		ReadCategoryJsonPath(nameof(GetByConversationMessageId));

		var result = Api.Messages.GetByConversationMessageId(123,
			[123],
			[""]);

		result.Count.Should()
			.Be(1);
	}
}