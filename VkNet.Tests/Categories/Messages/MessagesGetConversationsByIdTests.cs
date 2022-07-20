using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetConversationsByIdTests : MessagesBaseTests
	{
		[Fact]
		public void GetConversationsById()
		{
			Url = "https://api.vk.com/method/messages.getConversationsById";
			ReadCategoryJsonPath(nameof(GetConversationsById));

			var result = Api.Messages.GetConversationsById(new long[]
			{
				123
			});

			result.Count.Should().Be(1);
		}
	}
}