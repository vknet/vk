using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Models;

public class FriendsGetRequestsResultModel : CategoryBaseTest
{
	protected override string Folder => "Friends";

	[Fact(DisplayName = "Should have field message")]
	public void ShouldHaveField_Message()
	{
		ReadCategoryJsonPath(nameof(ShouldHaveField_Message));

		Url = "https://api.vk.ru/method/friends.getRequests";

		var result = Api.Friends.GetRequestsExtended(new());

		result[0]
			.Message.Should()
			.Be("text");
	}

	[Fact(DisplayName = "Should have field mutual")]
	public void ShouldHaveField_Mutual()
	{
		ReadCategoryJsonPath(nameof(ShouldHaveField_Mutual));

		Url = "https://api.vk.ru/method/friends.getRequests";

		var result = Api.Friends.GetRequestsExtended(new());

		result[0]
			.Mutual.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Should have field user id")]
	public void ShouldHaveField_UserId()
	{
		ReadCategoryJsonPath(nameof(ShouldHaveField_UserId));

		Url = "https://api.vk.ru/method/friends.getRequests";

		var result = Api.Friends.GetRequestsExtended(new());

		result[0]
			.UserId.Should()
			.Be(221634238L);
	}
}