using FluentAssertions;
using VkNet.Model.Template;
using Xunit;

namespace VkNet.Tests.Models;

public class MessageTemplateTests : BaseTest
{
	[Fact]
	public void Template_Carousel()
	{
		ReadJsonFile("Models", "Template_Carousel");

		var response = GetResponse();

		var result = MessageTemplate.FromJson(response);

		result.Should()
			.NotBeNull();
	}
}