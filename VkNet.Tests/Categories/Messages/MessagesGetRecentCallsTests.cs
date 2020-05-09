using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetRecentCallsTests : MessagesBaseTests
	{
		[Test]
		public void GetRecentCalls()
		{
			Url = "https://api.vk.me/method/messages.getRecentCalls";
			ReadCategoryJsonPath(nameof(GetRecentCalls));

			var result = Api.Messages.GetRecentCalls(new[] { "filter" }, 1);

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.Messages);
			Assert.IsNotEmpty(result.Profiles);
		}
	}
}