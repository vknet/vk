using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesMarkAsAnsweredConversationTests : MessagesBaseTests
{
	[Fact]
	public void MarkAsAnsweredConversation()
	{
		Url = "https://api.vk.com/method/messages.markAsAnsweredConversation";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.MarkAsAnsweredConversation(123);

		result.Should()
			.BeTrue();
	}
}