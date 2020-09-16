using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetConversationsTests : MessagesBaseTests
	{
		[Test]
		public void GetConversations()
		{
			Url = "https://api.vk.com/method/messages.getConversations";
			ReadCategoryJsonPath(nameof(GetConversations));

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(1, Is.EqualTo(result.Count));
		}

		[Test]
		public void GetConversations_Attachment_wall()
		{
			Url = "https://api.vk.com/method/messages.getConversations";
			ReadCategoryJsonPath(nameof(GetConversations_Attachment_wall));

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(253, Is.EqualTo(result.Count));
		}
	}
}