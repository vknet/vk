using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollBoardTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_BoardPostNew()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNew));

		const int expectedUserId = 123;
		const int expectedGroupId = 1234;
		const string expectedText = "test";

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
				x.GroupId.Should()
					.Be(expectedGroupId);

				x.BoardPost.FromId.Should()
					.Be(expectedUserId);

				x.BoardPost.Text.Should()
					.Be(expectedText);
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostNewFirst()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNewFirst));

		const int expectedGroupId = 1234;
		const string expectedText = "test";
		const int expectedTopicId = 6;

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
				x.BoardPost.FromId.Should()
					.Be(-expectedGroupId);

				x.GroupId.Should()
					.Be(expectedGroupId);

				x.BoardPost.Text.Should()
					.Be(expectedText);

				x.BoardPost.TopicOwnerId.Should()
					.Be(-expectedGroupId);

				x.BoardPost.TopicId.Should()
					.Be(expectedTopicId);
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostEditTest));

		const int expectedGroupId = 1234;
		const string expectedText = "test1";

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
				x.BoardPost.FromId.Should()
					.Be(-expectedGroupId);

				x.GroupId.Should()
					.Be(expectedGroupId);

				x.BoardPost.Text.Should()
					.Be(expectedText);

				x.BoardPost.TopicOwnerId.Should()
					.Be(-expectedGroupId);
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostRestoreTest));

		const int expectedUserId = 123;
		const int expectedGroupId = 1234;
		const string expectedText = "test";

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
				x.BoardPost.FromId.Should()
					.Be(expectedUserId);

				x.GroupId.Should()
					.Be(expectedGroupId);

				x.BoardPost.Text.Should()
					.Be(expectedText);

				x.BoardPost.TopicOwnerId.Should()
					.Be(-expectedGroupId);
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostDeleteTest));

		const int expectedGroupId = 1234;
		const int expectedTopicId = 6;
		const int expectedId = 3;

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
				x.GroupId.Should()
					.Be(expectedGroupId);

				x.BoardPostDelete.TopicOwnerId.Should()
					.Be(-expectedGroupId);

				x.BoardPostDelete.TopicId.Should()
					.Be(expectedTopicId);

				x.BoardPostDelete.Id.Should()
					.Be(expectedId);
			});
	}
}