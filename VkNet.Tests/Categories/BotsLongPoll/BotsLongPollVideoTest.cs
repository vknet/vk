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
			const string json = @"{
  'type': 'video_new',
  'object': {
    'id': 4444,
    'owner_id': -1234,
    'title': 'Test',
    'duration': 14,
    'description': '',
    'date': 1533402376,
    'comments': 0,
    'views': 1,
    'width': 680,
    'height': 720,
    'photo_130': 'https://pp.userapi.com/c849028/v849028892/43296/cQDGL421aic.jpg',
    'photo_320': 'https://pp.userapi.com/c849028/v849028892/43294/uhE7yWEUJ6Y.jpg',
    'photo_800': 'https://pp.userapi.com/c849028/v849028892/43293/dEXbARrZQuE.jpg',
    'repeat': 1,
    'first_frame_800': 'https://pp.userapi.com/c846320/v846320892/b3572/wVgFPd4YBsc.jpg',
    'first_frame_320': 'https://pp.userapi.com/c846320/v846320892/b3573/803qAiFud4o.jpg',
    'first_frame_160': 'https://pp.userapi.com/c846320/v846320892/b3574/cnHZIE4htwc.jpg',
    'first_frame_130': 'https://pp.userapi.com/c846320/v846320892/b3575/Vuo9kROpA5o.jpg',
    'can_edit': 1,
    'can_add': 1
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const int id = 4444;

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
			Assert.AreEqual(-groupId, update.Video.OwnerId);
			Assert.AreEqual(id, update.Video.Id);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentNewTest()
		{
			const string json = @"{
  'type': 'video_comment_new',
  'object': {
    'id': 1,
    'from_id': 123,
    'date': 1533402417,
    'text': 'test',
    'video_owner_id': -1234,
    'video_id': 4444
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const int videoId = 4444;
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

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
			Assert.AreEqual(videoId, update.VideoComment.VideoId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentEditTest()
		{
			const string json = @"{
  'type': 'video_comment_edit',
  'object': {
    'id': 1,
    'from_id': 123,
    'date': 1533402417,
    'text': 'test1',
    'video_owner_id': -1234,
    'video_id': 4444
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

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentRestoreTest()
		{
			const string json =
				"{\r\n  \"type\": \"video_comment_restore\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533402417,\r\n    \"text\": \"test1\",\r\n    \"video_owner_id\": -1234,\r\n    \"video_id\": 4444\r\n  },\r\n  \"group_id\": 1234\r\n}";

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

			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_VideoCommentDeleteTest()
		{
			var json =
				@"{
  'type': 'video_comment_delete',
  'object': {
    'owner_id': -1234,
    'id': 4,
    'deleter_id': 12345,
    'video_id': 123456
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const int deleterId = 12345;
			const int videoId = 123456;
			const int id = 4;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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