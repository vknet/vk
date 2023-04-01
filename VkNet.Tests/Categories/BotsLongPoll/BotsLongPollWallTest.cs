using System.Linq;
using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollWallTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_WallPostNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallPostNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const int unGroupId = -1234;

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

		update.WallPost.FromId.Should()
			.Be(userId);

		update.WallPost.OwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_WallReplyNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const string text = "test";
		const int postId = 6;
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.WallReply.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.WallReply.Text.Should()
			.Be(text);

		update.WallReply.PostOwnerId.Should()
			.Be(unGroupId);

		update.WallReply.PostId.Should()
			.Be(postId);
	}

	[Fact]
	public void GetBotsLongPollHistory_WallReplyEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyEditTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const string text = "test1";
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.WallReply.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.WallReply.Text.Should()
			.Be(text);

		update.WallReply.PostOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_WallReplyRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyRestoreTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const int unGroupId = -1234;
		const string text = "test1";

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.WallReply.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.WallReply.Text.Should()
			.Be(text);

		update.WallReply.PostOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_WallReplyDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_WallReplyDeleteTest));

		var groupId = new GroupId(1234);
		const int deleterId = 12345;
		const int postId = 6;
		const int id = 9;
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.WallReplyDelete.DeleterId.Should()
			.Be(deleterId);

		update.GroupId.Should()
			.Be(groupId);

		update.WallReplyDelete.OwnerId.Should()
			.Be(unGroupId);

		update.WallReplyDelete.PostId.Should()
			.Be(postId);

		update.WallReplyDelete.Id.Should()
			.Be(id);
	}
}