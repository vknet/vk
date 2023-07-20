using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class MoneyRequestTests : BaseTest
{
	[Fact]
	public void ShouldDeserializeFromVkResponseToAttachment()
	{
		ReadJsonFile("Models", "money_request");

		Url = "https://api.vk.com/method/wall.get";

		var attachment = Api.Wall.Get(new()).WallPosts[0].Attachments[0];

		attachment.Instance.Should()
			.BeOfType<MoneyRequest>();
	}
}