﻿using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]

	public class MessagesMarkAsAnsweredConversationTests : MessagesBaseTests
	{
		[Test]
		public void MarkAsAnsweredConversation()
		{
			Url = "https://api.vk.com/method/messages.markAsAnsweredConversation";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.MarkAsAnsweredConversation(123);

			Assert.IsTrue(result);
		}
	}
}