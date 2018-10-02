using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollMarketTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_MarketCommentNewTest()
		{
			const string json = @"{
  'type': 'market_comment_new',
  'object': {
    'id': 1,
    'from_id': 123,
    'date': 1533405772,
    'text': 'test',
    'market_owner_id': -1234,
    'item_id': 1686058
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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentEditTest()
		{
			const string json = @"{
  'type': 'market_comment_edit',
  'object': {
    'id': 1,
    'from_id': 123,
    'date': 1533405772,
    'text': 'test1',
    'market_owner_id': -1234,
    'item_id': 1686058
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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentRestoreTest()
		{
			const string json = @"{
  'type': 'market_comment_restore',
  'object': {
    'id': 1,
    'from_id': 123,
    'date': 1533405772,
    'text': 'test1',
    'market_owner_id': -1234,
    'item_id': 1686058
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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentDeleteTest()
		{
			const string json = @"{
  'type': 'market_comment_delete',
  'object': {
    'owner_id': -1234,
    'id': 1,
    'deleter_id': 123,
    'item_id': 4444
  },
  'group_id': 1234
}";

			const int deleterId = 123;
			const int groupId = 1234;
			const int itemId = 4444;
			const int id = 1;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.MarketCommentDelete.OwnerId);
			Assert.AreEqual(deleterId, update.MarketCommentDelete.DeleterId);
			Assert.AreEqual(itemId, update.MarketCommentDelete.ItemId);
			Assert.AreEqual(id, update.MarketCommentDelete.Id);
		}
	}
}