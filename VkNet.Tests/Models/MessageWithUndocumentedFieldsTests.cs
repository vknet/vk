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

			Assert.IsNotNull(message.Action);
			Assert.AreEqual(MessageAction.ChatUnpinMessage, message.Action.Type);
			Assert.IsNotNull(message.Action.MemberId);
			Assert.AreEqual(12345678, message.Action.MemberId!);
		}

		[Test]
		public void Message_With_Action_ChatUnpinMessage_ConversationMessageId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_unpin_action");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotNull(message.Action);
			Assert.AreEqual(MessageAction.ChatUnpinMessage, message.Action.Type);
			Assert.IsNotNull(message.Action.ConversationMessageId);
			Assert.AreEqual(3, message.Action.ConversationMessageId!);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_MemberId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotNull(message.Action);
			Assert.AreEqual(MessageAction.ChatPinMessage, message.Action.Type);
			Assert.IsNotNull(message.Action.MemberId);
			Assert.AreEqual(12345678, message.Action.MemberId!);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_ConversationMessageId_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotNull(message.Action);
			Assert.AreEqual(MessageAction.ChatPinMessage, message.Action.Type);
			Assert.IsNotNull(message.Action.ConversationMessageId);
			Assert.AreEqual(3, message.Action.ConversationMessageId!);
		}

		[Test]
		public void Message_With_Action_ChatPinMessage_Message_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_pin_action");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotNull(message.Action);
			Assert.AreEqual(MessageAction.ChatPinMessage, message.Action.Type);
			Assert.AreEqual("test", message.Action.Message);
		}

		[Test]
		public void Message_With_Self_Destruct_IsExpired_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_self_destruct_with_is_expired");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotNull(message.IsExpired);
			Assert.IsTrue(message.IsExpired);
		}

		[Test]
		public void Message_With_Self_Destruct_ExpireTtl_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_self_destruct_with_expire_ttl");

			var message = Message.FromJson(GetResponse());

			Assert.AreEqual(60, message.ExpireTtl);
		}

		[Test]
		public void Message_With_IsSilent_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_is_silent");

			var message = Message.FromJson(GetResponse());

			Assert.IsTrue(message.IsSilent);
		}

		[Test]
		public void Message_With_WasListened_IsPresentAndEquals()
		{
			ReadJsonFile("Models", "message_with_was_listened");

			var message = Message.FromJson(GetResponse());

			Assert.IsNotEmpty(message.Attachments);

			var attachment = message.Attachments[0];

			Assert.AreEqual(attachment.Type, typeof(AudioMessage));

			var audioMessage = attachment.Instance as AudioMessage;

			Assert.IsNotNull(audioMessage);

			Assert.IsTrue(message.WasListened);
		}
	}
}