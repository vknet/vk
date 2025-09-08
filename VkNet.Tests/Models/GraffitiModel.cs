using AwesomeAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class GraffitiModel : BaseTest
{
	[Fact(DisplayName = "Should deserialize from vk response to attachment")]
	public void ShouldDeserializeFromVkResponseToAttachment()
	{
		ReadJsonFile("Models", "graffiti_attachment");
		Url = "https://api.vk.ru/method/wall.get";

		var result = Api.Wall.Get(new());

		result.WallPosts[0]
			.Attachments[0]
			.Instance.Should()
			.BeOfType<Graffiti>();
	}

	[Fact(DisplayName = "Should deserialize old api response to attachment")]
	public void ShouldDeserializeOldApiResponseToAttachment()
	{
		ReadJsonFile("Models", "graffiti_attachment_for_960");

		Url = "https://api.vk.ru/method/wall.get";

		var result = Api.Wall.Get(new());

		result.WallPosts[0]
			.Attachments[0]
			.Instance.Should()
			.BeOfType<Graffiti>();
	}
}