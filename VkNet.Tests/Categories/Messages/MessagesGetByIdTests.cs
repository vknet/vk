using System.Linq;
using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetByIdTests : MessagesBaseTests
{
	[Fact]
	public void AdminAuthorId()
	{
		Url = "https://api.vk.com/method/messages.getById";
		ReadCategoryJsonPath(nameof(AdminAuthorId));

		var result = Api.Messages.GetById(new ulong[]
			{
				123
			},
			new[]
			{
				"123"
			});

		var message = result.FirstOrDefault();

		message.Should()
			.NotBeNull();

		message.AdminAuthorId.Should()
			.Be(45);
	}
}