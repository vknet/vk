using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetImportantMessagesTests : MessagesBaseTests
	{
		[Test]
		public void GetImportantMessagesResult()
		{
			Url = "https://api.vk.com/method/messages.getImportantMessages";
			ReadCategoryJsonPath(nameof(GetImportantMessagesResult));

			var result = Api.Messages.GetImportantMessages(new GetImportantMessagesParams());

			result.Should().NotBeNull();
			result.Messages.Should().NotBeEmpty();
			result.Profiles.Should().NotBeEmpty();
			result.Conversations.Should().NotBeEmpty();
		}
	}
}