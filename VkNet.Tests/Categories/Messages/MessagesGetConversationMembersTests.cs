using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetConversationMembersTests : MessagesBaseTests
{
	[Fact]
	public void GetConversationMembers()
	{
		Url = "https://api.vk.ru/method/messages.getConversationMembers";
		ReadCategoryJsonPath(nameof(GetConversationMembers));

		var result = Api.Messages.GetConversationMembers(123,
			new[]
			{
				""
			});

		result.Count.Should()
			.Be(2);
	}
}