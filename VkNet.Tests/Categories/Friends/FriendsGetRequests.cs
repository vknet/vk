using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Friends;

public class FriendsGetRequests : CategoryBaseTest
{
	protected override string Folder => "Friends";

	[Test]
	[DisplayName("Default params")]
	public void DefaultParams()
	{
		Url = "https://api.vk.ru/method/friends.getRequests";

		ReadCategoryJsonPath(nameof(Api.Friends.GetRequests));

		var result = Api.Friends.GetRequests(new());

		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);
	}

	[Test]
	[DisplayName("Extended")]
	public void Extended()
	{
		Url = "https://api.vk.ru/method/friends.getRequests";

		ReadCategoryJsonPath(nameof(Api.Friends.GetRequestsExtended));

		var result = Api.Friends.GetRequestsExtended(new()
		{
			Extended = true
		});

		result.Should()
			.NotBeNull();

		result.Should()
			.ContainSingle();
	}
}