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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentNewTest));

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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentEditTest));

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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentRestoreTest));

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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_MarketCommentDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentDeleteTest));

			const int deleterId = 123;
			const int groupId = 1234;
			const int itemId = 4444;
			const int id = 1;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
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