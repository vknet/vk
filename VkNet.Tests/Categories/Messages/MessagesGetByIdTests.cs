using System.Linq;
using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetByIdTests : MessagesBaseTests
{
	[Fact(DisplayName = "Admin author id")]
	public void AdminAuthorId()
	{
		Url = "https://api.vk.ru/method/messages.getById";
		ReadCategoryJsonPath(nameof(AdminAuthorId));

		var result = Api.Messages.GetById([123],
			["123"]);

		var message = result.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.AdminAuthorId.Should()
			.Be(45);
	}
}