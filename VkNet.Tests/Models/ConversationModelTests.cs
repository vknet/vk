using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class ConversationModelTests : BaseTest
{
	[Fact]
	public void ConversationModel()
	{
		ReadJsonFile("Models", nameof(ConversationModel));
		Url = "https://api.vk.com/method/friends.getRequests";
		var conversation = Api.Call<Conversation>("friends.getRequests", VkParameters.Empty);

		conversation.Should()
			.NotBeNull();

		conversation.Peer.Should()
			.NotBeNull();

		conversation.Peer.Id.Should()
			.Be(2000000038);

		conversation.Peer.Type.Should()
			.Be(ConversationPeerType.Chat);

		conversation.Peer.LocalId.Should()
			.Be(38);

		conversation.LastMessageId.Should()
			.Be(1210504);

		conversation.InRead.Should()
			.Be(115082);

		conversation.OutRead.Should()
			.Be(1210504);

		conversation.UnreadCount.Should()
			.Be(7);

		conversation.CanWrite.Should()
			.NotBeNull();

		conversation.CanWrite.Allowed.Should()
			.BeTrue();

		conversation.CanReceiveMoney.Should()
			.BeTrue();

		conversation.ChatSettings.Should()
			.NotBeNull();

		conversation.ChatSettings.OwnerId.Should()
			.Be(321779994);

		conversation.ChatSettings.Title.Should()
			.Be("bug");

		conversation.ChatSettings.State.Should()
			.Be(ConversationChatSettingsState.In);

		conversation.ChatSettings.Acl.Should()
			.NotBeNull();

		conversation.ChatSettings.Acl.CanChangeInfo.Should()
			.BeTrue();

		conversation.ChatSettings.Acl.CanChangeInviteLink.Should()
			.BeFalse();

		conversation.ChatSettings.Acl.CanChangePin.Should()
			.BeTrue();

		conversation.ChatSettings.Acl.CanInvite.Should()
			.BeTrue();

		conversation.ChatSettings.Acl.CanPromoteUsers.Should()
			.BeFalse();

		conversation.ChatSettings.Acl.CanSeeInviteLink.Should()
			.BeFalse();

		conversation.ChatSettings.Acl.CanModerate.Should()
			.BeFalse();

		conversation.ChatSettings.Acl.CanCopyChat.Should()
			.BeFalse();

		conversation.ChatSettings.MembersCount.Should()
			.Be(13);

		conversation.ChatSettings.ActiveIds.Should()
			.NotBeEmpty();
	}
}