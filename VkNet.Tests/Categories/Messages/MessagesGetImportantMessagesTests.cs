using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetImportantMessagesTests : MessagesBaseTests
{
	[Fact(DisplayName = "Get important messages result")]
	public void GetImportantMessagesResult()
	{
		Url = "https://api.vk.ru/method/messages.getImportantMessages";
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