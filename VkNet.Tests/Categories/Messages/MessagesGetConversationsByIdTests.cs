using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesGetConversationsByIdTests : MessagesBaseTests
	{
		[Test]
		public void GetConversationsById()
		{
			Url = "https://api.vk.com/method/messages.getConversationsById";
			ReadCategoryJsonPath(nameof(GetConversationsById));

			var result = Api.Messages.GetConversationsById(new long[] { 123 }, null);

			Assert.That(1, Is.EqualTo(result.Count));
		}
	}
}