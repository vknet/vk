using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesDeleteConversationTests : MessagesBaseTests
{
	[Fact(DisplayName = "Delete conversation")]
	public void DeleteConversation()
	{
		Url = "https://api.vk.ru/method/messages.deleteConversation";
		ReadCategoryJsonPath(nameof(DeleteConversation));

		var result = Api.Messages.DeleteConversation(123, 123, 123);

		result.Should()
			.Be(12312423);
	}
}