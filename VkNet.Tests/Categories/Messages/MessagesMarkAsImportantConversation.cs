using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{


	public class MessagesMarkAsImportantConversation : MessagesBaseTests
	{
		[Fact]
		public void MarkAsImportantConversation()
		{
			Url = "https://api.vk.com/method/messages.markAsImportantConversation";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.MarkAsImportantConversation(123);

			result.Should().BeTrue();
		}
	}
}