using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages;

public class MessagesUnpinTests : MessagesBaseTests
{
	[Test]
	[DisplayName("Unpin")]
	public void Unpin()
	{
		Url = "https://api.vk.ru/method/messages.unpin";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.Unpin(123, 345);

		result.Should()
			.BeTrue();
	}
}