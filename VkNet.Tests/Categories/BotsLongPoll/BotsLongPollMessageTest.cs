using System.Linq;
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

			Assert.NotNull(messageNew);
			Assert.NotNull(message);	
			Assert.NotNull(clientInfo);

			Assert.IsNotEmpty(clientInfo.ButtonActions);
			Assert.True(clientInfo.Keyboard);
			Assert.False(clientInfo.InlineKeyboard);
			Assert.AreEqual(Language.Ru, clientInfo.LangId);

			Assert.AreEqual(123456789, message.FromId);
			Assert.AreEqual(123456789, update.GroupId);
			Assert.AreEqual("f", message.Text);
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

			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
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

			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
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

			Assert.AreEqual(userId, update.MessageAllow.UserId);
			Assert.AreEqual(key, update.MessageAllow.Key);
			Assert.AreEqual(groupId, update.GroupId);
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

			Assert.AreEqual(userId, update.MessageDeny.UserId);
			Assert.AreEqual(groupId, update.GroupId);
		}
	}
}