using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollBoardTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_BoardPostNew()
		{
			const string json = @"{
  'type': 'board_post_new',
  'object': {
    'id': 3,
    'from_id': 123,
    'date': 1533404752,
    'text': 'test',
    'topic_owner_id': -1234,
    'topic_id': 38446232
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
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostNewFirst()
		{
			const string json = @"{
  'type': 'board_post_new',
  'object': {
    'id': 2,
    'from_id': -1234,
    'date': 1533404708,
    'text': 'test',
    'topic_owner_id': -1234,
    'topic_id': 6
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const string text = "test";
			const int topicId = 6;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
			Assert.AreEqual(topicId, update.BoardPost.TopicId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostEditTest()
		{
			const string json = @"{
  'type': 'board_post_edit',
  'object': {
    'id': 2,
    'from_id': -1234,
    'date': 1533404708,
    'text': 'test1',
    'topic_owner_id': -1234,
    'topic_id': 38446232
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const string text = "test1";

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostRestoreTest()
		{
			const string json = @"{
  'type': 'board_post_restore',
  'object': {
    'id': 3,
    'from_id': 123,
    'date': 1533404752,
    'text': 'test',
    'topic_owner_id': -1234,
    'topic_id': 38446232
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
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostDeleteTest()
		{
			const string json = @"{
  'type': 'board_post_delete',
  'object': {
    'topic_owner_id': -1234,
    'id': 3,
    'topic_id': 6
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const int topicId = 6;
			const int id = 3;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.BoardPostDelete.TopicOwnerId);
			Assert.AreEqual(topicId, update.BoardPostDelete.TopicId);
			Assert.AreEqual(id, update.BoardPostDelete.Id);
		}
	}
}