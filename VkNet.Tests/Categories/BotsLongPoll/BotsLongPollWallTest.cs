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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case WallPost:
					{
						var a = x.Instance is WallPost b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.OwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case WallReply:
					{
						var a = x.Instance is WallReply b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PostOwnerId.Should()
							.Be(unGroupId);

						a.PostId.Should()
							.Be(postId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case WallReply:
					{
						var a = x.Instance is WallReply b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PostOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case WallReply:
					{
						var a = x.Instance is WallReply b
							? b
							: null;

						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.PostOwnerId.Should()
							.Be(unGroupId);

						break;
					}
				}
			});
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

		botsLongPollHistory.Updates.Should()
			.SatisfyRespectively(x =>
			{
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(groupId);
						break;

					case WallReplyDelete:
					{
						var a = x.Instance is WallReplyDelete b
							? b
							: null;

						a.DeleterId.Should()
							.Be(deleterId);

						a.OwnerId.Should()
							.Be(unGroupId);

						a.PostId.Should()
							.Be(postId);

						a.Id.Should()
							.Be(id);

						break;
					}
				}
			});
	}
}