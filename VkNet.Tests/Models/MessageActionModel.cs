using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class MessageActionModel : BaseTest
{
	[Fact(DisplayName = "Should have field chat create")]
	public void ShouldHaveField_ChatCreate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatCreate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatCreate);
	}

	[Fact(DisplayName = "Should have field chat invite user")]
	public void ShouldHaveField_ChatInviteUser()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUser));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatInviteUser);
	}

	[Fact(DisplayName = "Should have field chat invite user by link")]
	public void ShouldHaveField_ChatInviteUserByLink()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUserByLink));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatInviteUserByLink);
	}

	[Fact(DisplayName = "Should have field chat kick user")]
	public void ShouldHaveField_ChatKickUser()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatKickUser));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatKickUser);
	}

	[Fact(DisplayName = "Should have field chat photo remove")]
	public void ShouldHaveField_ChatPhotoRemove()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoRemove));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPhotoRemove);
	}

	[Fact(DisplayName = "Should have field chat photo update")]
	public void ShouldHaveField_ChatPhotoUpdate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoUpdate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPhotoUpdate);
	}

	[Fact(DisplayName = "Should have field chat pin message")]
	public void ShouldHaveField_ChatPinMessage()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPinMessage));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPinMessage);
	}

	[Fact(DisplayName = "Should have field chat title update")]
	public void ShouldHaveField_ChatTitleUpdate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatTitleUpdate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatTitleUpdate);
	}

	[Fact(DisplayName = "Should have field chat unpin message")]
	public void ShouldHaveField_ChatUnpinMessage()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatUnpinMessage));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatUnpinMessage);
	}
}