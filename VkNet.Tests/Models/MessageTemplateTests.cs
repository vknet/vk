using AwesomeAssertions;
using VkNet.Model;

namespace VkNet.Tests.Models;

public class MessageTemplateTests : BaseTest
{
	[Test]
	[DisplayName("Template carousel")]
	public void Template_Carousel()
	{
		ReadJsonFile("Models", "Template_Carousel");

		var result = new MessageTemplate();

		result.Should()
			.NotBeNull();
	}
}