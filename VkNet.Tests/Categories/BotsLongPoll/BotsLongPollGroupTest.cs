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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupChangePhotoTest));

			const int userId = 123;
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
			Assert.AreEqual(userId, update.GroupChangePhoto.UserId);
			Assert.AreEqual(-groupId, update.GroupChangePhoto.Photo.OwnerId);
			Assert.AreEqual(id, update.GroupChangePhoto.Photo.Id);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupJoinTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupJoinTest));

			const int userId = 321;
			const int groupId = 1234;
			const GroupJoinType joinType = GroupJoinType.Request;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupLeaveTest));

			const int userId = 321;
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
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsFalse(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupLeaveSelfTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupLeaveSelfTest));

			const int userId = 321;
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
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsTrue(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GetBotsLongPollHistory_GroupOfficersEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupOfficersEditTest));

			const int userId = 321;
			const int groupId = 1234;
			const GroupOfficerLevel oldLevel = GroupOfficerLevel.Admin;
			const GroupOfficerLevel newLevel = GroupOfficerLevel.Editor;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserBlockTest));

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;
			const string comment = "test";
			const GroupUserBlockReason reason = GroupUserBlockReason.Other;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserBlockTemporaryTest));

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;
			const string comment = "test";
			const GroupUserBlockReason reason = GroupUserBlockReason.MessagesOffTopic;

			var unblockDate = new DateTime(2018,
				8,
				6,
				21,
				0,
				0);

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserUnblockTest));

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserUnblockByEndDateTest));

			const int userId = 321;
			const int groupId = 1234;
			const int adminId = 123;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PollVoteNewTest));

			const int userId = 123;
			const int groupId = 1234;
			const int optionId = 3333;
			const int pollId = 4444;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
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