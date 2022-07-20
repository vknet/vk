using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{
	public class MessagesSearchConversationsTests : MessagesBaseTests
	{
		[Fact]
		public void SearchConversations()
		{
			Url = "https://api.vk.com/method/messages.searchConversations";
			ReadCategoryJsonPath(nameof(SearchConversations));

			var result = Api.Messages.SearchConversations("query",
				new[]
				{
					"fields"
				});

			result.Count.Should().Be(20);
		}
	}
}