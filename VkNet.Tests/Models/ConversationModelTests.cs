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

			Assert.NotNull(conversation);
			Assert.NotNull(conversation.Peer);
			Assert.AreEqual(2000000038, conversation.Peer.Id);
			Assert.AreEqual(ConversationPeerType.Chat, conversation.Peer.Type);
			Assert.AreEqual(38, conversation.Peer.LocalId);
			Assert.AreEqual(1210504, conversation.LastMessageId);
			Assert.AreEqual(115082, conversation.InRead);
			Assert.AreEqual(1210504, conversation.OutRead);
			Assert.AreEqual(7, conversation.UnreadCount);
			Assert.NotNull(conversation.CanWrite);
			Assert.IsTrue(conversation.CanWrite.Allowed);
			Assert.IsTrue(conversation.CanReceiveMoney);
			Assert.NotNull(conversation.ChatSettings);
			Assert.AreEqual(321779994, conversation.ChatSettings.OwnerId);
			Assert.AreEqual("bug", conversation.ChatSettings.Title);
			Assert.AreEqual(ConversationChatSettingsState.In, conversation.ChatSettings.State);
			Assert.NotNull(conversation.ChatSettings.Acl);
			Assert.IsTrue(conversation.ChatSettings.Acl.CanChangeInfo);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanChangeInviteLink);
			Assert.IsTrue(conversation.ChatSettings.Acl.CanChangePin);
			Assert.IsTrue(conversation.ChatSettings.Acl.CanInvite);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanPromoteUsers);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanSeeInviteLink);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanModerate);
			Assert.IsFalse(conversation.ChatSettings.Acl.CanCopyChat);
			Assert.AreEqual(13, conversation.ChatSettings.MembersCount);
			Assert.IsNotEmpty(conversation.ChatSettings.ActiveIds);
		}
	}
}