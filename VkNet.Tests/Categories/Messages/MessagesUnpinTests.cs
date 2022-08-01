using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesUnpinTests : MessagesBaseTests
{
	[Fact]
	public void Unpin()
	{
		Url = "https://api.vk.com/method/messages.unpin";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.Unpin(123, 345);

		result.Should()
			.BeTrue();
	}
}