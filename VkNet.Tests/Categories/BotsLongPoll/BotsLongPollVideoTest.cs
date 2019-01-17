using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollVideoTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_VideoNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoNewTest));

			const int groupId = 1234;
			const int id = 4444;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.Video.OwnerId);
			Assert.AreEqual(id, update.Video.Id);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentNewTest));

			const int userId = 123;
			const int groupId = 1234;
			const int videoId = 4444;
			const string text = "test";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
			Assert.AreEqual(videoId, update.VideoComment.VideoId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentEditTest));

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

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentRestoreTest));

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

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentDeleteTest));

			const int groupId = 1234;
			const int deleterId = 12345;
			const int videoId = 123456;
			const int id = 4;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(deleterId, update.VideoCommentDelete.DeleterId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.VideoCommentDelete.OwnerId);
			Assert.AreEqual(videoId, update.VideoCommentDelete.VideoId);
			Assert.AreEqual(id, update.VideoCommentDelete.Id);
		}
	}
}