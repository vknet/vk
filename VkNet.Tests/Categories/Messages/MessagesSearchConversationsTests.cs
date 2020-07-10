using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesSearchConversationsTests : MessagesBaseTests
	{
		[Test]
		public void SearchConversations()
		{
			Url = "https://api.vk.com/method/messages.searchConversations";
			ReadCategoryJsonPath(nameof(SearchConversations));

			var result = Api.Messages.SearchConversations("query", new[] { "fields" });

			Assert.That(20, Is.EqualTo(result.Count));
		}
	}
}