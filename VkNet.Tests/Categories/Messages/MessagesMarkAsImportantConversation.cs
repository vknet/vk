using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesMarkAsImportantConversation : MessagesBaseTests
	{
		[Test]
		public void MarkAsImportantConversation()
		{
			Url = "https://api.vk.com/method/messages.markAsImportantConversation";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.MarkAsImportantConversation(123);

			Assert.IsTrue(result);
		}
	}
}