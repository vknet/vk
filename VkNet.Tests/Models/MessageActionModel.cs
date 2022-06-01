using FluentAssertions;
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
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatCreate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatCreate);
		}

		[Test]
		public void ShouldHaveField_ChatInviteUser()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUser));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatInviteUser);
		}

		[Test]
		public void ShouldHaveField_ChatInviteUserByLink()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUserByLink));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatInviteUserByLink);
		}

		[Test]
		public void ShouldHaveField_ChatKickUser()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatKickUser));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatKickUser);
		}

		[Test]
		public void ShouldHaveField_ChatPhotoRemove()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoRemove));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatPhotoRemove);
		}

		[Test]
		public void ShouldHaveField_ChatPhotoUpdate()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoUpdate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatPhotoUpdate);
		}

		[Test]
		public void ShouldHaveField_ChatPinMessage()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatPinMessage));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatPinMessage);
		}

		[Test]
		public void ShouldHaveField_ChatTitleUpdate()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatTitleUpdate));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatTitleUpdate);
		}

		[Test]
		public void ShouldHaveField_ChatUnpinMessage()
		{
			ReadJsonFile("Models", nameof(ShouldHaveField_ChatUnpinMessage));

			var response = GetResponse();
			var action = MessageAction.FromJsonString(response["action"]);

			action.Should().Be(MessageAction.ChatUnpinMessage);
		}
	}
}