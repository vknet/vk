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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNew));

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
			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostNewFirst()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNewFirst));

			const int groupId = 1234;
			const string text = "test";
			const int topicId = 6;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostEditTest));

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

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostRestoreTest));

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

			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_BoardPostDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostDeleteTest));

			const int groupId = 1234;
			const int topicId = 6;
			const int id = 3;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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