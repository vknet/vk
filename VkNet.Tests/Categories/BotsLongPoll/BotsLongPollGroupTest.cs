using System;
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case GroupChangePhoto:
					{
						var a = x.Instance is GroupChangePhoto b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.Photo.OwnerId.Should()
							.Be(unGroupId);

						a.Photo.Id.Should()
							.Be(id);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case GroupJoin:
					{
						var a = x.Instance is GroupJoin b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.JoinType.Should()
							.Be(joinType);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case GroupLeave:
					{
						var a = x.Instance is GroupLeave b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.IsSelf.Should()
							.BeFalse();

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case GroupLeave:
					{
						var a = x.Instance is GroupLeave b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.IsSelf.Should()
							.BeTrue();

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case GroupOfficersEdit:
					{
						var a = x.Instance is GroupOfficersEdit b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.LevelOld.Should()
							.Be(oldLevel);

						a.LevelNew.Should()
							.Be(newLevel);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case UserBlock:
					{
						var a = x.Instance is UserBlock b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.AdminId.Should()
							.Be(adminId);

						a.Comment.Should()
							.Be(comment);

						a.Reason.Should()
							.Be(reason);

						a.UnblockDate.Should().Be(DateTime.Parse("1970-01-01"));

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case UserBlock:
					{
						var a = x.Instance is UserBlock b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.AdminId.Should()
							.Be(adminId);

						a.Comment.Should()
							.Be(comment);

						a.Reason.Should()
							.Be(reason);

						a.UnblockDate.Should()
							.Be(unblockDate);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case UserUnblock:
					{
						var a = x.Instance is UserUnblock b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.AdminId.Should()
							.Be(adminId);

						a.ByEndDate.Should()
							.BeFalse();

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case UserUnblock:
					{
						var a = x.Instance is UserUnblock b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.AdminId.Should()
							.Be(adminId);

						a.ByEndDate.Should()
							.BeTrue();

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case PollVoteNew:
					{
						var a = x.Instance is PollVoteNew b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.OptionId.Should()
							.Be(optionId);

						a.PollId.Should()
							.Be(pollId);

						break;
					}
				}
			});
	}
}