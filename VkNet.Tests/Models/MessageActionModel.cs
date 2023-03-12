using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class MessageActionModel : BaseTest
{
	[Fact]
	public void ShouldHaveField_ChatCreate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatCreate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatCreate);
	}

	[Fact]
	public void ShouldHaveField_ChatInviteUser()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUser));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatInviteUser);
	}

	[Fact]
	public void ShouldHaveField_ChatInviteUserByLink()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatInviteUserByLink));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatInviteUserByLink);
	}

	[Fact]
	public void ShouldHaveField_ChatKickUser()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatKickUser));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatKickUser);
	}

	[Fact]
	public void ShouldHaveField_ChatPhotoRemove()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoRemove));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPhotoRemove);
	}

	[Fact]
	public void ShouldHaveField_ChatPhotoUpdate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPhotoUpdate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPhotoUpdate);
	}

	[Fact]
	public void ShouldHaveField_ChatPinMessage()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatPinMessage));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatPinMessage);
	}

	[Fact]
	public void ShouldHaveField_ChatTitleUpdate()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatTitleUpdate));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatTitleUpdate);
	}

	[Fact]
	public void ShouldHaveField_ChatUnpinMessage()
	{
		ReadJsonFile("Models", nameof(ShouldHaveField_ChatUnpinMessage));

		var response = GetResponse();
		var action = Utilities.Deserialize<MessageAction>(response["action"]);

		action.Should()
			.Be(MessageAction.ChatUnpinMessage);
	}
}