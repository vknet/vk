using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetConversationMembersTests : MessagesBaseTests
	{
		[Test]
		public void GetConversationMembers()
		{
			Url = "https://api.vk.com/method/messages.getConversationMembers";
			ReadCategoryJsonPath(nameof(GetConversationMembers));

			var result = Api.Messages.GetConversationMembers(123, new[] { "" });

			Assert.That(2, Is.EqualTo(result.Count));
		}
	}
}