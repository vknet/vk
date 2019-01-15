using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesDeleteConversationTests : MessagesBaseTests
	{
		[Test]
		public void DeleteConversation()
		{
			Url = "https://api.vk.com/method/messages.deleteConversation";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.DeleteConversation(123);

			Assert.IsTrue(result);
		}
	}
}