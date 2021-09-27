using System;
using FluentAssertions.Extensions;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	public class MessagesWithCallTests : MessagesBaseTests
	{
		[Test]
		public void Message_WithCallAttachment_AllFieldsArePresent()
		{
			ReadJsonFile("Models", "message_with_call");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotEmpty(message.Attachments);

			var call = message.Attachments[0].Instance as Call;

			Assert.IsNotNull(call);

			Assert.IsTrue(call.Video);

			Assert.AreEqual("reached", call.State);
			Assert.AreEqual(12345678, call.InitiatorId);
			Assert.AreEqual(2012345678, call.ReceiverId);
			Assert.IsTrue(call.Duration.HasValue);
			Assert.AreEqual(30, call.Duration.Value);

			Assert.AreEqual(new DateTime(2021,
					9,
					27,
					19,
					21,
					21,
					DateTimeKind.Utc),
				call.Time.AsUtc());
		}
	}
}