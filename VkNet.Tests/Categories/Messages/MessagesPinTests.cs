using AwesomeAssertions;

namespace VkNet.Tests.Categories.Messages;

public class MessagesPinTests : MessagesBaseTests
{
	[Test]
	[DisplayName("Pin")]
	public void Pin()
	{
		Url = "https://api.vk.ru/method/messages.pin";
		ReadCategoryJsonPath(nameof(Pin));

		var result = Api.Messages.Pin(123, 345);

		result.Should()
			.NotBeNull();
	}
}