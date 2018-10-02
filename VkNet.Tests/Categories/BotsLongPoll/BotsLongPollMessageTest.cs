using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollMessageTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_MessageNewTest()
		{
			const string json = @"{
	'type': 'message_new',
	'object': {
		'date': 1533397795,
		'from_id': 123,
		'id': 829,
		'out': 0,
		'peer_id': 123,
		'text': 'test',
		'conversation_message_id': 791,
		'fwd_messages': [],
		'important': false,
		'random_id': 0,
		'attachments': [],
		'is_hidden': false
	},
	'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void GetBotsLongPollHistory_MesageEditTest()
		{
			const string json = @"{
  'type': 'message_edit',
  'object': {
    'date': 1533397838,
    'from_id': 123,
    'id': 791,
    'out': 1,
    'peer_id': 123,
    'text': 'test1',
    'conversation_message_id': 791,
    'fwd_messages': [],
    'update_time': 1533397838,
    'important': false,
    'random_id': 0,
    'attachments': [],
    'is_hidden': false
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test1";

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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
			const string json = @"{
  'type': 'message_reply',
  'object': {
    'date': 1533397818,
    'from_id': 123,
    'id': 830,
    'out': 1,
    'peer_id': 123,
    'text': 'test',
    'conversation_message_id': 792,
    'fwd_messages': [],
    'important': false,
    'random_id': 0,
    'attachments': [],
    'admin_author_id': 123,
    'is_hidden': false
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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
			const string json = @"{
  'type': 'message_allow',
  'object': {
    'user_id': 123,
    'key': '123456'
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string key = "123456";

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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
			const string json = @"{
  'type': 'message_deny',
  'object': {
    'user_id': 123
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.MessageDeny.UserId);
			Assert.AreEqual(groupId, update.GroupId);
		}
	}
}