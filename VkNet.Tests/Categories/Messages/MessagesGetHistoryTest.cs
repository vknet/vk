using FluentAssertions;
using VkNet.Model.RequestParams;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetHistoryTest : MessagesBaseTests
	{
		[Fact]
		public void GetHistoryTest()
		{
			Url = "https://api.vk.com/method/messages.getHistory";

			ReadCategoryJsonPath(nameof(Api.Messages.GetHistory));

			var result = Api.Messages.GetHistory(new MessagesGetHistoryParams
			{
				Count = 1,
				PeerId = -123456789,
				Extended = true
			});

			result.TotalCount.Should().Be(226);
			result.Messages.Should().NotBeEmpty();
			result.Conversations.Should().NotBeEmpty();
			result.Groups.Should().NotBeEmpty();
			result.Users.Should().NotBeEmpty();
		}
	}
}