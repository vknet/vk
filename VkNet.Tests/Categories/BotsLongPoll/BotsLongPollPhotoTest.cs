using FluentAssertions;
using VkNet.Model.Attachments;
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case Photo:
					{
						var a = x.Instance is Photo b
							? b
							: null;

						a.OwnerId.Should()
							.Be(unGroupId);

						a.Id.Should()
							.Be(photoId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case PhotoComment:
					{
						var a = x.Instance is PhotoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PhotoOwnerId.Should()
							.Be(unGroupId);

						a.PhotoId.Should()
							.Be(photoId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case PhotoComment:
					{
						var a = x.Instance is PhotoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PhotoOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case PhotoComment:
					{
						var a = x.Instance is PhotoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PhotoOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case PhotoCommentDelete:
					{
						var a = x.Instance is PhotoCommentDelete b
							? b
							: null;

						a.DeleterId.Should()
							.Be(deleterId);

						a.UserId.Should()
							.Be(userId);

						a.OwnerId.Should()
							.Be(unGroupId);

						a.PhotoId.Should()
							.Be(photoId);

						a.Id.Should()
							.Be(id);

						break;
					}
				}
			});
	}
}