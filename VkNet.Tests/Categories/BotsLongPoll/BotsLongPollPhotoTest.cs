using System.Linq;
using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollPhotoTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_PhotoNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoNewTest));

		var groupId = new GroupId(1234);
		const int photoId = 123456;
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.Photo.OwnerId.Should()
			.Be(unGroupId);

		update.GroupId.Should()
			.Be(groupId);

		update.Photo.Id.Should()
			.Be(photoId);
	}

	[Fact]
	public void GetBotsLongPollHistory_PhotoCommentNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const string text = "test";
		const int photoId = 123456;
		const int unGroupId = -1234;

		var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new()
		{
			Key = "test",
			Server = "https://vk.com",
			Ts = "0",
			Wait = 10
		});

		var update = botsLongPollHistory.Updates.First();

		update.PhotoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.PhotoComment.Text.Should()
			.Be(text);

		update.PhotoComment.PhotoOwnerId.Should()
			.Be(unGroupId);

		update.PhotoComment.PhotoId.Should()
			.Be(photoId);
	}

	[Fact]
	public void GetBotsLongPollHistory_PhotoCommentEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentEditTest));

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

		update.PhotoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.PhotoComment.Text.Should()
			.Be(text);

		update.PhotoComment.PhotoOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_PhotoCommentRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentRestoreTest));

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

		update.PhotoComment.FromId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.PhotoComment.Text.Should()
			.Be(text);

		update.PhotoComment.PhotoOwnerId.Should()
			.Be(unGroupId);
	}

	[Fact]
	public void GetBotsLongPollHistory_PhotoCommentDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_PhotoCommentDeleteTest));

		const int userId = 123;
		const int deleterId = 12345;
		var groupId = new GroupId(1234);
		const int photoId = 123456;
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

		update.PhotoCommentDelete.DeleterId.Should()
			.Be(deleterId);

		update.PhotoCommentDelete.UserId.Should()
			.Be(userId);

		update.GroupId.Should()
			.Be(groupId);

		update.PhotoCommentDelete.OwnerId.Should()
			.Be(unGroupId);

		update.PhotoCommentDelete.PhotoId.Should()
			.Be(photoId);

		update.PhotoCommentDelete.Id.Should()
			.Be(id);
	}
}