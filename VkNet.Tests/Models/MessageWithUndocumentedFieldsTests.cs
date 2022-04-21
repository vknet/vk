using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class MessageWithUndocumentedFieldsTests : BaseTest
	{
		[Test]
		public void Message_With_Action_ChatUnpinMessage_MemberId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_unpin_action");

			var message = Message.FromJson(GetResponse());

			message.Action.Should().NotBeNull();
			message.Action.Type.Should().Be(MessageAction.ChatUnpinMessage);
			message.Action.MemberId.Should().NotBeNull();
			message.Action.MemberId!.Should().Be(12345678);
		}

		[Test]
		public void Message_With_Action_ChatUnpinMessage_ConversationMessageId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_unpin_action");

			var message = Message.FromJson(GetResponse());

			message.Action.Should().NotBeNull();
			message.Action.Type.Should().Be(MessageAction.ChatUnpinMessage);
			message.Action.ConversationMessageId.Should().NotBeNull();
			message.Action.ConversationMessageId!.Should().Be(3);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_MemberId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			message.Action.Should().NotBeNull();
			message.Action.Type.Should().Be(MessageAction.ChatPinMessage);
			message.Action.MemberId.Should().NotBeNull();
			message.Action.MemberId!.Should().Be(12345678);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_ConversationMessageId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			message.Action.Should().NotBeNull();
			message.Action.Type.Should().Be(MessageAction.ChatPinMessage);
			message.Action.ConversationMessageId.Should().NotBeNull();
			message.Action.ConversationMessageId!.Should().Be(3);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_Message_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			message.Action.Should().NotBeNull();
			message.Action.Type.Should().Be(MessageAction.ChatPinMessage);
			message.Action.Message.Should().Be("test");
		}

		[Test]
		public void Message_With_Self_Destruct_IsExpired_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_self_destruct_with_is_expired");

			var message = Message.FromJson(GetResponse());

			message.IsExpired.Should().NotBeNull();
			message.IsExpired.Should().BeTrue();
		}

		[Test]
		public void Message_With_Self_Destruct_ExpireTtl_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_self_destruct_with_expire_ttl");

			var message = Message.FromJson(GetResponse());

			message.ExpireTtl.Should().Be(60);
		}

		[Test]
		public void Message_With_IsSilent_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_is_silent");

			var message = Message.FromJson(GetResponse());

			message.IsSilent.Should().BeTrue();
		}

		[Test]
		public void Message_With_WasListened_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_was_listened");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotEmpty(message.Attachments);

			var attachment = message.Attachments[0];

			attachment.Type.Should().BeOfType<AudioMessage>();

			var audioMessage = attachment.Instance as AudioMessage;

			audioMessage.Should().NotBeNull();

			message.WasListened.Should().BeTrue();
		}
	}
}