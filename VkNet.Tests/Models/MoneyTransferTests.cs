using AwesomeAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class MoneyTransferTests : BaseTest
{
	[Fact(DisplayName = "Should deserialize from vk response to attachment")]
	public void ShouldDeserializeFromVkResponseToAttachment()
	{
		ReadJsonFile("Models", "money_transfer");

		Url = "https://api.vk.ru/method/wall.get";

		var attachment = Api.Wall.Get(new())
			.WallPosts[0]
			.Attachments[0];

		attachment.Instance.Should()
			.BeOfType<MoneyTransfer>();
	}
}