using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class MessageActionModel : BaseTest
	{
		[Test]
		public void ShouldHaveField_ChatCreate()
		{
			Json = "{'action':'chat_create'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatCreate));
		}

		[Test]
		public void ShouldHaveField_ChatInviteUser()
		{
			Json = "{'action':'chat_invite_user'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatInviteUser));
		}

		[Test]
		public void ShouldHaveField_ChatInviteUserByLink()
		{
			Json = "{'action':'chat_invite_user_by_link'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatInviteUserByLink));
		}

		[Test]
		public void ShouldHaveField_ChatKickUser()
		{
			Json = "{'action':'chat_kick_user'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatKickUser));
		}

		[Test]
		public void ShouldHaveField_ChatPhotoRemove()
		{
			Json = "{'action':'chat_photo_remove'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatPhotoRemove));
		}

		[Test]
		public void ShouldHaveField_ChatPhotoUpdate()
		{
			Json = "{'action':'chat_photo_update'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatPhotoUpdate));
		}

		[Test]
		public void ShouldHaveField_ChatPinMessage()
		{
			Json = "{'action':'chat_pin_message'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatPinMessage));
		}

		[Test]
		public void ShouldHaveField_ChatTitleUpdate()
		{
			Json = "{'action':'chat_title_update'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatTitleUpdate));
		}

		[Test]
		public void ShouldHaveField_ChatUnpinMessage()
		{
			Json = "{'action':'chat_unpin_message'}";
			var response = GetResponse();
			var action = MessageAction.FromJsonString(response: response[key: "action"]);
			Assert.That(actual: action, expression: Is.EqualTo(expected: MessageAction.ChatUnpinMessage));
		}
	}
}