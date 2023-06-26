using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class EventModel : BaseTest
{
	[Fact]
	public void EventModel_ImplicitEvent()
	{
		ReadJsonFile("Models", nameof(EventModel_ImplicitEvent));

		Url = "https://api.vk.com/method/wall.get";

		var attachment = Api.Wall.Get(new()).WallPosts[0].Attachments[0];

		attachment.Instance.Should()
			.BeOfType<Event>();
	}
}