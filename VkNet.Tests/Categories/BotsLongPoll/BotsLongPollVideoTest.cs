using System.Linq;
using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollVideoTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_VideoNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoNewTest));

		var groupId = new GroupId(1234);
		const int id = 4444;
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

		update.Video.OwnerId.Should()
			.Be(unGroupId);

		update.Video.Id.Should()
			.Be(id);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const int videoId = 4444;
		const int unGroupId = -1234;
		const string text = "test";

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.VideoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.VideoComment.Text.Should()
			.Be(text);

		update.VideoComment.VideoOwnerId.Should()
			.Be(unGroupId);

		update.VideoComment.VideoId.Should()
			.Be(videoId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentEditTest));

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

		update.VideoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.VideoComment.Text.Should()
			.Be(text);

		update.VideoComment.VideoOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentRestoreTest));

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

		update.VideoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.VideoComment.Text.Should()
			.Be(text);

		update.VideoComment.VideoOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentDeleteTest));

		var groupId = new GroupId(1234);
		const int deleterId = 12345;
		const int videoId = 123456;
		const int id = 4;
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.VideoCommentDelete.DeleterId.Should()
			.Be(deleterId);

		update.GroupId.Should()
			.Be(groupId);

		update.VideoCommentDelete.OwnerId.Should()
			.Be(unGroupId);

		update.VideoCommentDelete.VideoId.Should()
			.Be(videoId);

		update.VideoCommentDelete.Id.Should()
			.Be(id);
	}
}