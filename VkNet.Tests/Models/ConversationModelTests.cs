using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class ConversationModelTests : BaseTest
	{
		[Test]
		public void ConversationModel()
		{
			ReadJsonFile("Models", nameof(ConversationModel));
			Url = "https://api.vk.com/method/friends.getRequests";
			var conversation = Api.Call<Conversation>("friends.getRequests", VkParameters.Empty);

			conversation.Should().NotBeNull();
			conversation.Peer.Should().NotBeNull();
			conversation.Peer.Id.Should().Be(2000000038);
			conversation.Peer.Type.Should().Be(ConversationPeerType.Chat);
			conversation.Peer.LocalId.Should().Be(38);
			conversation.LastMessageId.Should().Be(1210504);
			conversation.InRead.Should().Be(115082);
			conversation.OutRead.Should().Be(1210504);
			conversation.UnreadCount.Should().Be(7);
			conversation.CanWrite.Should().NotBeNull();
			Assert.IsTrue(conversation.CanWrite.Allowed);
			Assert.IsTrue(conversation.CanReceiveMoney);
			conversation.ChatSettings.Should().NotBeNull();
			conversation.ChatSettings.OwnerId.Should().Be(321779994);
			conversation.ChatSettings.Title.Should().Be("bug");
			conversation.ChatSettings.State.Should().Be(ConversationChatSettingsState.In);
			conversation.ChatSettings.Acl.Should().NotBeNull();
			Assert.IsTrue(conversation.ChatSettings.Acl.CanChangeInfo);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanChangeInviteLink);
			Assert.IsTrue(conversation.ChatSettings.Acl.CanChangePin);
			Assert.IsTrue(conversation.ChatSettings.Acl.CanInvite);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanPromoteUsers);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanSeeInviteLink);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanModerate);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanCopyChat);
			conversation.ChatSettings.MembersCount.Should().Be(13);
			Assert.IsNotEmpty(conversation.ChatSettings.ActiveIds);
		}
	}
}