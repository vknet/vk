using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{


	public class MessagesPinTests : MessagesBaseTests
	{
		[Fact]
		public void Pin()
		{
			Url = "https://api.vk.com/method/messages.pin";
			ReadCategoryJsonPath(nameof(Pin));

			var result = Api.Messages.Pin(123, 345);

			result.Should().NotBeNull();
		}
	}
}