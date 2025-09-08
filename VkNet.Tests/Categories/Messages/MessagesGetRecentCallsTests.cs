using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetRecentCallsTests : MessagesBaseTests
{
	[Fact(DisplayName = "Get recent calls")]
	public void GetRecentCalls()
	{
		Url = "https://api.vk.ru/method/messages.getRecentCalls";
		ReadCategoryJsonPath(nameof(GetRecentCalls));

		var result = Api.Messages.GetRecentCalls(["filter"], 1);

		result.Should()
			.NotBeNull();

		result.Messages.Should()
			.NotBeEmpty();

		result.Profiles.Should()
			.NotBeEmpty();
	}
}