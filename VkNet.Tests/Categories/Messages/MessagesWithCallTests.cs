using System;
using FluentAssertions;
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

			call.Should().NotBeNull();

			Assert.IsTrue(call.Video);

			call.State.Should().Be("reached");
			call.InitiatorId.Should().Be(12345678);
			call.ReceiverId.Should().Be(2012345678);
			Assert.IsTrue(call.Duration.HasValue);
			call.Duration.Value.Should().Be(30);

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