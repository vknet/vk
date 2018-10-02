using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollGroupTest : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_GroupChangePhotoTest()
		{
			const string json = @"{
  'type': 'group_change_photo',
  'object': {
    'user_id': 123,
    'photo': {
      'id': 4444,
      'album_id': -6,
      'owner_id': -1234,
      'user_id': 100,
      'sizes': [
        {
          'type': 's',
          'url': 'https://sun1-2.userapi.com/c830609/v830609207/15e4db/SSBTALZRXxo.jpg',
          'width': 75,
          'height': 75
        },
        {
          'type': 'm',
          'url': 'https://sun1-15.userapi.com/c830609/v830609207/15e4dc/7bcKr5iiVis.jpg',
          'width': 130,
          'height': 130
        },
        {
          'type': 'x',
          'url': 'https://sun1-3.userapi.com/c830609/v830609207/15e4dd/WnLOfTavZ_Q.jpg',
          'width': 604,
          'height': 604
        },
        {
          'type': 'y',
          'url': 'https://sun1-3.userapi.com/c830609/v830609207/15e4de/JC1mkuarBog.jpg',
          'width': 807,
          'height': 807
        },
        {
          'type': 'z',
          'url': 'https://sun1-16.userapi.com/c830609/v830609207/15e4df/PnfylXt-aRs.jpg',
          'width': 1080,
          'height': 1080
        },
        {
          'type': 'w',
          'url': 'https://sun1-16.userapi.com/c830609/v830609207/15e4e0/TBkOlLB4R5g.jpg',
          'width': 1254,
          'height': 1254
        },
        {
          'type': 'o',
          'url': 'https://sun1-20.userapi.com/c830609/v830609207/15e4e1/8-OfmMzEIGU.jpg',
          'width': 130,
          'height': 130
        },
        {
          'type': 'p',
          'url': 'https://sun1-4.userapi.com/c830609/v830609207/15e4e2/j7V4wbUan7U.jpg',
          'width': 200,
          'height': 200
        },
        {
          'type': 'q',
          'url': 'https://sun1-12.userapi.com/c830609/v830609207/15e4e3/u7z-FuP33jg.jpg',
          'width': 320,
          'height': 320
        },
        {
          'type': 'r',
          'url': 'https://sun1-13.userapi.com/c830609/v830609207/15e4e4/RIvHkxHK9eo.jpg',
          'width': 510,
          'height': 510
        }
      ],
      'text': '',
      'date': 1533589819,
      'post_id': 12
    }
  },
  'group_id': 1234
}";

			const int userId = 123;
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
			Assert.AreEqual(userId, update.GroupChangePhoto.UserId);
			Assert.AreEqual(-groupId, update.GroupChangePhoto.Photo.OwnerId);
			Assert.AreEqual(id, update.GroupChangePhoto.Photo.Id);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupJoinTest()
		{
			const string json = @"{
  'type': 'group_join',
  'object': {
    'user_id': 321,
    'join_type': 'request'
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int groupId = 1234;
			const GroupJoinType joinType = GroupJoinType.Request;

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
			Assert.AreEqual(userId, update.GroupJoin.UserId);
			Assert.AreEqual(joinType, update.GroupJoin.JoinType);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupLeaveTest()
		{
			const string json = @"{
  'type': 'group_leave',
  'object': {
    'user_id': 321,
    'self': 0
  },
  'group_id': 1234
}";

			const int userId = 321;
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
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsFalse(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupLeaveSelfTest()
		{
			const string json = @"{
  'type': 'group_leave',
  'object': {
    'user_id': 321,
    'self': 1
  },
  'group_id': 1234
}";

			const int userId = 321;
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
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsTrue(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupOfficersEditTest()
		{
			const string json = @"{
  'type': 'group_officers_edit',
  'object': {
    'admin_id': 123,
    'user_id': 321,
    'level_old': 3,
    'level_new': 2
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int adminId = 123;
			const int groupId = 1234;
			const GroupOfficerLevel oldLevel = GroupOfficerLevel.Admin;
			const GroupOfficerLevel newLevel = GroupOfficerLevel.Editor;

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
			Assert.AreEqual(userId, update.GroupOfficersEdit.UserId);
			Assert.AreEqual(oldLevel, update.GroupOfficersEdit.LevelOld);
			Assert.AreEqual(newLevel, update.GroupOfficersEdit.LevelNew);
		}

		[Test]
		public void GetBotsLongPollHistory_UserBlockTest()
		{
			const string json = @"{
  'type': 'user_block',
  'object': {
    'admin_id': 123,
    'user_id': 321,
    'unblock_date': 0,
    'reason': 0,
    'comment': 'test'
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;
			const string comment = "test";
			const GroupUserBlockReason reason = GroupUserBlockReason.Other;

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
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId, update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.IsNull(update.UserBlock.UnblockDate);
		}

		[Test]
		public void GetBotsLongPollHistory_UserBlockTemporaryTest()
		{
			const string json = @"{
  'type': 'user_block',
  'object': {
    'admin_id': 123,
    'user_id': 321,
    'unblock_date': 1533589200,
    'reason': 4,
    'comment': 'test'
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;
			const string comment = "test";
			const GroupUserBlockReason reason = GroupUserBlockReason.MessagesOffTopic;
			var unblockDate = new DateTime(2018, 8, 6, 21, 0, 0);

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
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId, update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.AreEqual(unblockDate, update.UserBlock.UnblockDate);
		}

		[Test]
		public void GetBotsLongPollHistory_UserUnblockTest()
		{
			const string json = @"{
  'type': 'user_unblock',
  'object': {
    'admin_id': 123,
    'user_id': 321,
    'by_end_date': 0
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;

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
			Assert.AreEqual(userId, update.UserUnblock.UserId);
			Assert.AreEqual(adminId, update.UserUnblock.AdminId);
			Assert.IsFalse(update.UserUnblock.ByEndDate);
		}

		[Test]
		public void GetBotsLongPollHistory_UserUnblockByEndDateTest()
		{
			const string json = @"{
  'type': 'user_unblock',
  'object': {
    'admin_id': 123,
    'user_id': 321,
    'by_end_date': 1
  },
  'group_id': 1234
}";

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;

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
			Assert.AreEqual(userId, update.UserUnblock.UserId);
			Assert.AreEqual(adminId, update.UserUnblock.AdminId);
			Assert.IsTrue(update.UserUnblock.ByEndDate);
		}

		[Test]
		public void GetBotsLongPollHistory_PollVoteNewTest()
		{
			const string json = @"{
  'type': 'poll_vote_new',
  'object': {
    'owner_id': -1234,
    'poll_id': 4444,
    'option_id': 3333,
    'user_id': 123
  },
  'group_id': 1234
}";

			const int userId = 123;
			const int groupId = 1234;
			const int optionId = 3333;
			const int pollId = 4444;

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
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}
	}
}