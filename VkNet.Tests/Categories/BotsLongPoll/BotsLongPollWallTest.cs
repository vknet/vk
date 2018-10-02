using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollWallTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_WallPostNewTest()
		{
			const string json = @"{
  'type': 'wall_post_new',
  'object': {
    'id': 6,
    'from_id': 123,
    'owner_id': -1234,
    'date': 1533403316,
    'marked_as_ads': 0,
    'post_type': 'post',
    'text': 'test',
    'can_edit': 1,
    'created_by': 123,
    'can_delete': 1,
    'comments': {
      'count': 0
    }
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
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.WallPost.FromId);
			Assert.AreEqual(-groupId, update.WallPost.OwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyNewTest()
		{
			const string json = @"{
  'type': 'wall_reply_new',
  'object': {
    'id': 9,
    'from_id': 123,
    'date': 1533403427,
    'text': 'test',
    'post_owner_id': -1234,
    'post_id': 6
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";
			const int postId = 6;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
			Assert.AreEqual(postId, update.WallReply.PostId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyEditTest()
		{
			const string json = @"{
  'type': 'wall_reply_edit',
  'object': {
    'id': 9,
    'from_id': 123,
    'date': 1533403427,
    'text': 'test1',
    'post_owner_id': -1234,
    'post_id': 6
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
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyRestoreTest()
		{
			const string json = @"{
  'type': 'wall_reply_restore',
  'object': {
    'id': 9,
    'from_id': 123,
    'date': 1533403427,
    'text': 'test1',
    'post_owner_id': -1234,
    'post_id': 6
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
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyDeleteTest()
		{
			const string json = @"{
  'type': 'wall_reply_delete',
  'object': {
    'owner_id': -1234,
    'id': 9,
    'deleter_id': 12345,
    'post_id': 6
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const int deleterId = 12345;
			const int postId = 6;
			const int id = 9;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(deleterId, update.WallReplyDelete.DeleterId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.WallReplyDelete.OwnerId);
			Assert.AreEqual(postId, update.WallReplyDelete.PostId);
			Assert.AreEqual(id, update.WallReplyDelete.Id);
		}
	}
}