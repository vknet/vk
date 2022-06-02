using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetHistoryTest : MessagesBaseTests
	{
		[Test]
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