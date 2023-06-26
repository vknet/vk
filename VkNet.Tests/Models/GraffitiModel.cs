using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class GraffitiModel : BaseTest
{
	[Fact]
	public void ShouldDeserializeFromVkResponseToAttachment()
	{
		ReadJsonFile("Models", "graffiti_attachment");
		Url = "https://api.vk.com/method/wall.get";

		var result = Api.Wall.Get(new());

		result.WallPosts[0].Attachments[0].Instance.Should()
			.BeOfType<Graffiti>();
	}

	[Fact]
	public void ShouldDeserializeOldApiResponseToAttachment()
	{
		ReadJsonFile("Models", "graffiti_attachment_for_960");

		Url = "https://api.vk.com/method/wall.get";

		var result = Api.Wall.Get(new());

		result.WallPosts[0].Attachments[0].Instance.Should()
			.BeOfType<Graffiti>();
	}
}