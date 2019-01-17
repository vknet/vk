using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollWallTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_WallPostNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallPostNewTest));

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

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.WallPost.FromId);
			Assert.AreEqual(-groupId, update.WallPost.OwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyNewTest));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";
			const int postId = 6;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyEditTest));

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

			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyRestoreTest));

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

			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_WallReplyDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyDeleteTest));

			const int groupId = 1234;
			const int deleterId = 12345;
			const int postId = 6;
			const int id = 9;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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