using System;
using System.Linq;
using FluentAssertions;
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

			update.GroupId.Should().Be(groupId);
			update.GroupChangePhoto.UserId.Should().Be(userId);
			update.GroupChangePhoto.Photo.OwnerId.Should().Be(-groupId);
			update.GroupChangePhoto.Photo.Id.Should().Be(id);
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

			update.GroupId.Should().Be(groupId);
			update.GroupJoin.UserId.Should().Be(userId);
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

			update.GroupId.Should().Be(groupId);
			update.GroupLeave.UserId.Should().Be(userId);
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

			update.GroupId.Should().Be(groupId);
			update.GroupLeave.UserId.Should().Be(userId);
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

			update.GroupId.Should().Be(groupId);
			update.GroupOfficersEdit.UserId.Should().Be(userId);
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
			const BanReason reason = BanReason.Other;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.GroupId.Should().Be(groupId);
			update.UserBlock.UserId.Should().Be(userId);
			update.UserBlock.AdminId.Should().Be(adminId);
			update.UserBlock.Comment.Should().Be(comment);
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
			const BanReason reason = BanReason.IrrelevantMessages;

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

			update.GroupId.Should().Be(groupId);
			update.UserBlock.UserId.Should().Be(userId);
			update.UserBlock.AdminId.Should().Be(adminId);
			update.UserBlock.Comment.Should().Be(comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			update.UserBlock.UnblockDate.Should().Be(unblockDate);
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

			update.GroupId.Should().Be(groupId);
			update.UserUnblock.UserId.Should().Be(userId);
			update.UserUnblock.AdminId.Should().Be(adminId);
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

			update.GroupId.Should().Be(groupId);
			update.UserUnblock.UserId.Should().Be(userId);
			update.UserUnblock.AdminId.Should().Be(adminId);
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

			update.GroupId.Should().Be(groupId);
			update.PollVoteNew.UserId.Should().Be(userId);
			update.PollVoteNew.OptionId.Should().Be(optionId);
			update.PollVoteNew.PollId.Should().Be(pollId);
		}
	}
}