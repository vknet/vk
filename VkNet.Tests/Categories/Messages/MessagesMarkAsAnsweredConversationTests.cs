using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesMarkAsAnsweredConversationTests : BaseTest
	{
		[Test]
		public void MarkAsAnsweredConversation()
		{
			Url = "https://api.vk.com/method/messages.markAsAnsweredConversation";

			Json = @"{
                    'response': 1
                  }";

			var result = Api.Messages.MarkAsAnsweredConversation(123);

			Assert.IsTrue(result);
		}
	}
}