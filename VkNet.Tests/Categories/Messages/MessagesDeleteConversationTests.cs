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
			ReadCategoryJsonPath(nameof(DeleteConversation));

			var result = Api.Messages.DeleteConversation(123, 123, 123);

			Assert.That(result, Is.EqualTo(12312423));
		}
	}
}