using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetRecentCallsTests : MessagesBaseTests
	{
		[Fact]
		public void GetRecentCalls()
		{
			Url = "https://api.vk.com/method/messages.getRecentCalls";
			ReadCategoryJsonPath(nameof(GetRecentCalls));

			var result = Api.Messages.GetRecentCalls(new[] { "filter" }, 1);

			result.Should().NotBeNull();
			result.Messages.Should().NotBeEmpty();
			result.Profiles.Should().NotBeEmpty();
		}
	}
}