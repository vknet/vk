using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{


	public class MessagesDeleteConversationTests : MessagesBaseTests
	{
		[Fact]
		public void DeleteConversation()
		{
			Url = "https://api.vk.com/method/messages.deleteConversation";
			ReadCategoryJsonPath(nameof(DeleteConversation));

			var result = Api.Messages.DeleteConversation(123, 123, 123);

			result.Should().Be(12312423);
		}
	}
}