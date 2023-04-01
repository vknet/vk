using System;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollGroupTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_GroupChangePhotoTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupChangePhotoTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		var unGroupId = -1234;
		const int id = 4444;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.GroupChangePhoto.UserId.Should()
			.Be(userId);

		update.GroupChangePhoto.Photo.OwnerId.Should()
			.Be(unGroupId);

		update.GroupChangePhoto.Photo.Id.Should()
			.Be(id);
	}

	[Fact]
	public void GetBotsLongPollHistory_GroupJoinTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupJoinTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const GroupJoinType joinType = GroupJoinType.Request;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.GroupJoin.UserId.Should()
			.Be(userId);

		update.GroupJoin.JoinType.Should()
			.Be(joinType);
	}

	[Fact]
	public void GetBotsLongPollHistory_GroupLeaveTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupLeaveTest));

		const int userId = 321;
		var groupId = new GroupId(1234);

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.GroupLeave.UserId.Should()
			.Be(userId);

		update.GroupLeave.IsSelf.Should()
			.BeFalse();
	}

	[Fact]
	public void GetBotsLongPollHistory_GroupLeaveSelfTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupLeaveSelfTest));

		const int userId = 321;
		var groupId = new GroupId(1234);

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.GroupLeave.UserId.Should()
			.Be(userId);

		update.GroupLeave.IsSelf.Should()
			.BeTrue();
	}

	[Fact]
	public void GetBotsLongPollHistory_GroupOfficersEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_GroupOfficersEditTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const GroupOfficerLevel oldLevel = GroupOfficerLevel.Admin;
		const GroupOfficerLevel newLevel = GroupOfficerLevel.Editor;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.GroupOfficersEdit.UserId.Should()
			.Be(userId);

		update.GroupOfficersEdit.LevelOld.Should()
			.Be(oldLevel);

		update.GroupOfficersEdit.LevelNew.Should()
			.Be(newLevel);
	}

	[Fact]
	public void GetBotsLongPollHistory_UserBlockTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserBlockTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const int adminId = 123;
		const string comment = "test";
		const BanReason reason = BanReason.Other;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.UserBlock.UserId.Should()
			.Be(userId);

		update.UserBlock.AdminId.Should()
			.Be(adminId);

		update.UserBlock.Comment.Should()
			.Be(comment);

		update.UserBlock.Reason.Should()
			.Be(reason);

		update.UserBlock.UnblockDate.Should().Be(DateTime.Parse("1970-01-01"));
	}

	[Fact]
	public void GetBotsLongPollHistory_UserBlockTemporaryTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserBlockTemporaryTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const int adminId = 123;
		const string comment = "test";
		const BanReason reason = BanReason.IrrelevantMessages;

		var unblockDate = new DateTime(2018,
			8,
			6,
			21,
			0,
			0);

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.UserBlock.UserId.Should()
			.Be(userId);

		update.UserBlock.AdminId.Should()
			.Be(adminId);

		update.UserBlock.Comment.Should()
			.Be(comment);

		update.UserBlock.Reason.Should()
			.Be(reason);

		update.UserBlock.UnblockDate.Should()
			.Be(unblockDate);
	}

	[Fact]
	public void GetBotsLongPollHistory_UserUnblockTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserUnblockTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const int adminId = 123;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.UserUnblock.UserId.Should()
			.Be(userId);

		update.UserUnblock.AdminId.Should()
			.Be(adminId);

		update.UserUnblock.ByEndDate.Should()
			.BeFalse();
	}

	[Fact]
	public void GetBotsLongPollHistory_UserUnblockByEndDateTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_UserUnblockByEndDateTest));

		const int userId = 321;
		var groupId = new GroupId(1234);
		const int adminId = 123;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.UserUnblock.UserId.Should()
			.Be(userId);

		update.UserUnblock.AdminId.Should()
			.Be(adminId);

		update.UserUnblock.ByEndDate.Should()
			.BeTrue();
	}

	[Fact]
	public void GetBotsLongPollHistory_PollVoteNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PollVoteNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const int optionId = 3333;
		const int pollId = 4444;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.PollVoteNew.UserId.Should()
			.Be(userId);

		update.PollVoteNew.OptionId.Should()
			.Be(optionId);

		update.PollVoteNew.PollId.Should()
			.Be(pollId);
	}
}