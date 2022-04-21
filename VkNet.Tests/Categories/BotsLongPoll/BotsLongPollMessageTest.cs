using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollMessageTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_MessageNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageNewTest));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var messageNew = update.MessageNew;

			var message = messageNew?.Message;

			var clientInfo = messageNew?.ClientInfo;

			messageNew.Should().NotBeNull();
			message.Should().NotBeNull();
			clientInfo.Should().NotBeNull();

			Assert.IsNotEmpty(clientInfo.ButtonActions);
			clientInfo.Keyboard.Should().BeTrue();
			clientInfo.InlineKeyboard.Should().BeFalse();
			clientInfo.LangId.Should().Be(Language.Ru);

			message.FromId.Should().Be(123456789);
			update.GroupId.Should().Be(123456789);
			message.Text.Should().Be("f");
		}

		[Test]
		public void GetBotsLongPollHistory_MessageEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageEditTest));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test1";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.Message.FromId.Should().Be(userId);
			update.GroupId.Should().Be(groupId);
			update.Message.Text.Should().Be(text);
		}

		[Test]
		public void GetBotsLongPollHistory_MessageReplyTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageReplyTest));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.Message.FromId.Should().Be(userId);
			update.GroupId.Should().Be(groupId);
			update.Message.Text.Should().Be(text);
		}

		[Test]
		public void GetBotsLongPollHistory_MessageAllowTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageAllowTest));

			const int userId = 123;
			const int groupId = 1234;
			const string key = "123456";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.MessageAllow.UserId.Should().Be(userId);
			update.MessageAllow.Key.Should().Be(key);
			update.GroupId.Should().Be(groupId);
		}

		[Test]
		public void GetBotsLongPollHistory_MessageDenyTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageDenyTest));

			const int userId = 123;
			const int groupId = 1234;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.MessageDeny.UserId.Should().Be(userId);
			update.GroupId.Should().Be(groupId);
		}

		[Test]
		public void GetBotsLongPollHistory_MessageEventTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageEventTest));

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			var messageEvent = update.MessageEvent;

			messageEvent.Should().NotBeNull();
			messageEvent.EventId.Should().Be("feleyinek");
			messageEvent.UserId.Should().Be(123456789);
			messageEvent.PeerId.Should().Be(123456789);
			messageEvent.ConversationMessageId.Should().Be(1234);
			messageEvent.Payload.Should().Be("{}");
			update.GroupId.Should().Be(1234);
		}
	}
}