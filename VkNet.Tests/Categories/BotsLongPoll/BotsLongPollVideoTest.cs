using System.Linq;
using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollVideoTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_VideoNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoNewTest));

		const int groupId = 1234;
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

		update.Video.OwnerId.Should()
			.Be(-groupId);

		update.Video.Id.Should()
			.Be(id);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentNewTest));

		const int userId = 123;
		const int groupId = 1234;
		const int videoId = 4444;
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
			.Be(-groupId);

		update.VideoComment.VideoId.Should()
			.Be(videoId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentEditTest));

		const int userId = 123;
		const int groupId = 1234;
		const string text = "test1";

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
			.Be(-groupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentRestoreTest));

		const int userId = 123;
		const int groupId = 1234;
		const string text = "test1";

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
			.Be(-groupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_VideoCommentDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_VideoCommentDeleteTest));

		const int groupId = 1234;
		const int deleterId = 12345;
		const int videoId = 123456;
		const int id = 4;

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
			.Be(-groupId);

		update.VideoCommentDelete.VideoId.Should()
			.Be(videoId);

		update.VideoCommentDelete.Id.Should()
			.Be(id);
	}
}