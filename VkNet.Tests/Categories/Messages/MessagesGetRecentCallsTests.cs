using FluentAssertions;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetRecentCallsTests : MessagesBaseTests
	{
		[Test]
		public void GetRecentCalls()
		{
			Url = "https://api.vk.com/method/messages.getRecentCalls";
			ReadCategoryJsonPath(nameof(GetRecentCalls));

			var result = Api.Messages.GetRecentCalls(new[] { "filter" }, 1);

			result.Should().NotBeNull();
			Assert.IsNotEmpty(result.Messages);
			Assert.IsNotEmpty(result.Profiles);
		}
	}
}