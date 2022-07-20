using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{
	public class MessagesGetByConversationMessageIdTests : MessagesBaseTests
	{
		[Fact]
		public void GetByConversationMessageId()
		{
			Url = "https://api.vk.com/method/messages.getByConversationMessageId";
			ReadCategoryJsonPath(nameof(GetByConversationMessageId));

			var result = Api.Messages.GetByConversationMessageId(123,
				new ulong[]
				{
					123
				},
				new[]
				{
					""
				});

			result.Count.Should().Be(1);
		}
	}
}