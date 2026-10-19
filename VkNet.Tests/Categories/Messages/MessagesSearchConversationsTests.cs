using AwesomeAssertions;

namespace VkNet.Tests.Categories.Messages;

public class MessagesSearchConversationsTests : MessagesBaseTests
{
	[Test]
	[DisplayName("Search conversations")]
	public void SearchConversations()
	{
		Url = "https://api.vk.ru/method/messages.searchConversations";
		ReadCategoryJsonPath(nameof(SearchConversations));

		var result = Api.Messages.SearchConversations("query",
			["fields"]);

		result.Count.Should()
			.Be(20);
	}
}