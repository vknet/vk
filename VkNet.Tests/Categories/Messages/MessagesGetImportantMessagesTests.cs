using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesGetImportantMessagesTests: CategoryBaseTest
	{
		protected override string Folder => "Messages";

		[Test]
		public void GetImportantMessagesResult()
		{
			Url = "https://api.vk.com/method/messages.getImportantMessages";
			ReadCategoryJsonPath(nameof(GetImportantMessagesResult));
			var result = Api.Messages.GetImportantMessages(new GetImportantMessagesParams());
			Assert.NotNull(result);
			Assert.IsNotEmpty(result.Messages);
			Assert.IsNotEmpty(result.Profiles);
			Assert.IsNotEmpty(result.Conversations);
		}
	}
}