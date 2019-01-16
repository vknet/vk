using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessageActionModel : BaseTest
	{
		[Test]
		public void ShouldHaveField_ChatCreate()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatCreate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatCreate));
		}

		[Test]
		public void ShouldHaveField_ChatInviteUser()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUser));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatInviteUser));
		}

		[Test]
		public void ShouldHaveField_ChatInviteUserByLink()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUserByLink));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatInviteUserByLink));
		}

		[Test]
		public void ShouldHaveField_ChatKickUser()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatKickUser));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatKickUser));
		}

		[Test]
		public void ShouldHaveField_ChatPhotoRemove()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoRemove));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatPhotoRemove));
		}

		[Test]
		public void ShouldHaveField_ChatPhotoUpdate()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoUpdate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatPhotoUpdate));
		}

		[Test]
		public void ShouldHaveField_ChatPinMessage()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPinMessage));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatPinMessage));
		}

		[Test]
		public void ShouldHaveField_ChatTitleUpdate()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatTitleUpdate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatTitleUpdate));
		}

		[Test]
		public void ShouldHaveField_ChatUnpinMessage()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatUnpinMessage));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			Assert.That(action, Is.EqualTo(MessageAction.ChatUnpinMessage));
		}
	}
}