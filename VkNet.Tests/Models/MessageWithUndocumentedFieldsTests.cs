using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class MessageWithUndocumentedFieldsTests : BaseTest
{
	[Fact(DisplayName = "Message with action chat unpin message member id is present and equals")]
	public void Message_With_Action_ChatUnpinMessage_MemberId_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_unpin_action");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Action.Should()
			.NotBeNull();

		message.Action.Type.Should()
			.Be(MessageAction.ChatUnpinMessage);

		message.Action.MemberId.Should()
			.NotBeNull();

		message.Action.MemberId!.Should()
			.Be(12345678);
	}

	[Fact(DisplayName = "Message with action chat unpin message conversation message id is present and equals")]
	public void Message_With_Action_ChatUnpinMessage_ConversationMessageId_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_unpin_action");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Action.Should()
			.NotBeNull();

		message.Action.Type.Should()
			.Be(MessageAction.ChatUnpinMessage);

		message.Action.ConversationMessageId.Should()
			.NotBeNull();

		message.Action.ConversationMessageId!.Should()
			.Be(3);
	}

	[Fact(DisplayName = "Message with action chat pin message member id is present and equals")]
	public void Message_With_Action_ChatPinMessage_MemberId_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_pin_action");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Action.Should()
			.NotBeNull();

		message.Action.Type.Should()
			.Be(MessageAction.ChatPinMessage);

		message.Action.MemberId.Should()
			.NotBeNull();

		message.Action.MemberId!.Should()
			.Be(12345678);
	}

	[Fact(DisplayName = "Message with action chat pin message conversation message id is present and equals")]
	public void Message_With_Action_ChatPinMessage_ConversationMessageId_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_pin_action");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Action.Should()
			.NotBeNull();

		message.Action.Type.Should()
			.Be(MessageAction.ChatPinMessage);

		message.Action.ConversationMessageId.Should()
			.NotBeNull();

		message.Action.ConversationMessageId!.Should()
			.Be(3);
	}

	[Fact(DisplayName = "Message with action chat pin message message is present and equals")]
	public void Message_With_Action_ChatPinMessage_Message_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_pin_action");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Action.Should()
			.NotBeNull();

		message.Action.Type.Should()
			.Be(MessageAction.ChatPinMessage);

		message.Action.Message.Should()
			.Be("test");
	}

	[Fact(DisplayName = "Message with self destruct is expired is present and equals")]
	public void Message_With_Self_Destruct_IsExpired_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_self_destruct_with_is_expired");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.IsExpired.Should()
			.NotBeNull();

		message.IsExpired.Should()
			.BeTrue();
	}

	[Fact(DisplayName = "Message with self destruct expire ttl is present and equals")]
	public void Message_With_Self_Destruct_ExpireTtl_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_self_destruct_with_expire_ttl");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.ExpireTtl.Should()
			.Be(60);
	}

	[Fact(DisplayName = "Message with is silent is present and equals")]
	public void Message_With_IsSilent_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_is_silent");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.IsSilent.Should()
			.BeTrue();
	}

	[Fact(DisplayName = "Message with was listened is present and equals")]
	public void Message_With_WasListened_IsPresentAndEquals()
	{
		ReadJsonFile("Models", "message_with_was_listened");

		Url = "https://api.vk.ru/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);

		message.Attachments.Should()
			.NotBeEmpty();

		var attachment = message.Attachments[0];

		attachment.Type.Should()
			.BeAssignableTo<AudioMessage>();

		var audioMessage = attachment.Instance as AudioMessage;

		audioMessage.Should()
			.NotBeNull();

		message.WasListened.Should()
			.BeTrue();
	}
}