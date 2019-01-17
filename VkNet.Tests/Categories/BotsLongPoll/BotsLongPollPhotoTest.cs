using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollPhotoTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_PhotoNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoNewTest));

			const int groupId = 1234;
			const int photoId = 123456;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(-groupId, update.Photo.OwnerId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(photoId, update.Photo.Id);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentNewTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentNewTest));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";
			const int photoId = 123456;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
			Assert.AreEqual(photoId, update.PhotoComment.PhotoId);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentEditTest));

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

			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentRestoreTest));

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

			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentDeleteTest));

			const int userId = 123;
			const int deleterId = 12345;
			const int groupId = 1234;
			const int photoId = 123456;
			const int id = 4;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			Assert.AreEqual(deleterId, update.PhotoCommentDelete.DeleterId);
			Assert.AreEqual(userId, update.PhotoCommentDelete.UserId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.PhotoCommentDelete.OwnerId);
			Assert.AreEqual(photoId, update.PhotoCommentDelete.PhotoId);
			Assert.AreEqual(id, update.PhotoCommentDelete.Id);
		}
	}
}