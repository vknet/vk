using FluentAssertions;
using VkNet.Model.RequestParams;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetImportantMessagesTests : MessagesBaseTests
{
	[Fact]
	public void GetImportantMessagesResult()
	{
		Url = "https://api.vk.com/method/messages.getImportantMessages";
		ReadCategoryJsonPath(nameof(GetImportantMessagesResult));

		var result = Api.Messages.GetImportantMessages(new());

		result.Should()
			.NotBeNull();

		result.Messages.Should()
			.NotBeEmpty();

		result.Profiles.Should()
			.NotBeEmpty();

		result.Conversations.Should()
			.NotBeEmpty();
	}
}