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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case Model.Attachments.Video:
					{
						var a = x.Instance is Model.Attachments.Video b
							? b
							: null;

						a.OwnerId.Should()
							.Be(unGroupId);

						a.Id.Should()
							.Be(id);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case VideoComment:
					{
						var a = x.Instance is VideoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.VideoOwnerId.Should()
							.Be(unGroupId);

						a.VideoId.Should()
							.Be(videoId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case VideoComment:
					{
						var a = x.Instance is VideoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.VideoOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case VideoComment:
					{
						var a = x.Instance is VideoComment b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.VideoOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case VideoCommentDelete:
					{
						var a = x.Instance is VideoCommentDelete b
							? b
							: null;

						a.DeleterId.Should()
							.Be(deleterId);

						a.OwnerId.Should()
							.Be(unGroupId);

						a.VideoId.Should()
							.Be(videoId);

						a.Id.Should()
							.Be(id);

						break;
					}
				}
			});
	}
}