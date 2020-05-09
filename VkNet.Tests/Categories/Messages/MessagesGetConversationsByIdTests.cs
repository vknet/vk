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
			Url = "https://api.vk.me/method/messages.getConversationsById";
			ReadCategoryJsonPath(nameof(GetConversationsById));

			var result = Api.Messages.GetConversationsById(new long[] { 123 });

			Assert.That(1, Is.EqualTo(result.Count));
		}
	}
}