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
			const string json = @"{
  'type': 'photo_new',
  'object': {
    'id': 123456,
    'album_id': 1234,
    'owner_id': -1234,
    'user_id': 100,
    'sizes': [
      {
        'type': 's',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a000/lUOsa955-jY.jpg',
        'width': 75,
        'height': 75
      },
      {
        'type': 'm',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a001/iuKZIHc3wZQ.jpg',
        'width': 130,
        'height': 130
      },
      {
        'type': 'x',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a002/d6OlNoaopNU.jpg',
        'width': 604,
        'height': 604
      },
      {
        'type': 'y',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a003/_iE5hSNLl9U.jpg',
        'width': 807,
        'height': 807
      },
      {
        'type': 'z',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a004/33LbnCgpeIc.jpg',
        'width': 1024,
        'height': 1024
      },
      {
        'type': 'o',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a005/5IQIvtzM6VA.jpg',
        'width': 130,
        'height': 130
      },
      {
        'type': 'p',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a006/V6YM6vKahbw.jpg',
        'width': 200,
        'height': 200
      },
      {
        'type': 'q',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a007/ijJML7x7aKo.jpg',
        'width': 320,
        'height': 320
      },
      {
        'type': 'r',
        'url': 'https://pp.userapi.com/c840134/v840134869/5a008/rqmyhuQ57ic.jpg',
        'width': 510,
        'height': 510
      }
    ],
    'text': '',
    'date': 1533399738
  },
  'group_id': 1234
}";

			const int groupId = 1234;
			const int photoId = 123456;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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
			const string json = @"{
  'type': 'photo_comment_new',
  'object': {
    'id': 4,
    'from_id': 123,
    'date': 1533399764,
    'text': 'test',
    'photo_owner_id': -1234,
    'photo_id': 123456
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";
			const int photoId = 123456;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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
			const string json = @"{
  'type': 'photo_comment_edit',
  'object': {
    'id': 4,
    'from_id': 123,
    'date': 1533399764,
    'text': 'test1',
    'photo_owner_id': -1234,
    'photo_id': 456239020
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

			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentRestoreTest()
		{
			var json =
				@"{
  'type': 'photo_comment_restore',
  'object': {
    'id': 4,
    'from_id': 123,
    'date': 1533399764,
    'text': 'test1',
    'photo_owner_id': -1234,
    'photo_id': 456239020
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

			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void GetBotsLongPollHistory_PhotoCommentDeleteTest()
		{
			const string json = @"{
  'type': 'photo_comment_delete',
  'object': {
    'owner_id': -1234,
    'id': 4,
    'deleter_id': 12345,
    'photo_id': 123456,
    'user_id': 123
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int deleterId = 12345;
			const int groupId = 1234;
			const int photoId = 123456;
			const int id = 4;

			var groupCategory = GetMockedGroupCategory("https://vk.com", GetFullResponse(json));

			var botsLongPollHistory = groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
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