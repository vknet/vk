using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class MessageTemplateTests : BaseTest
{
	[Fact]
	public void Template_Carousel()
	{
		ReadJsonFile("Models", "Template_Carousel");

		var result = new MessageTemplate();

		result.Should()
			.NotBeNull();
	}
}