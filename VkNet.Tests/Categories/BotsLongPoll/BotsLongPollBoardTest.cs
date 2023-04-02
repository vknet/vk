using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollBoardTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_BoardPostNew()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNew));

		var expectedGroupId = new GroupId(1234);
		const int expectedUserId = 123;
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
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(expectedGroupId);
						break;

					case BoardPost:
					{
						var a = x.Instance is BoardPost b
							? b
							: null;
						a.FromId.Should()
							.Be(expectedUserId);

						a.Text.Should()
							.Be(expectedText);
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostNewFirst()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNewFirst));

		var expectedGroupId = new GroupId(1234);
		const int unExpectedGroupId = -1234;
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
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(expectedGroupId);
						break;

					case BoardPost:
					{
						var a = x.Instance is BoardPost b
							? b
							: null;
						a.FromId.Should()
							.Be(unExpectedGroupId);

						a.Text.Should()
							.Be(expectedText);

						a.TopicOwnerId.Should()
							.Be(unExpectedGroupId);

						a.TopicId.Should()
							.Be(expectedTopicId);
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostEditTest));

		var expectedGroupId = new GroupId(1234);
		const int unExpectedGroupId = -1234;
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
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(expectedGroupId);
						break;

					case BoardPost:
					{
						var a = x.Instance is BoardPost b
							? b
							: null;
						a.FromId.Should()
							.Be(unExpectedGroupId);

						a.Text.Should()
							.Be(expectedText);

						a.TopicOwnerId.Should()
							.Be(unExpectedGroupId);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostRestoreTest));

		var expectedGroupId = new GroupId(1234);
		const int unExpectedGroupId = -1234;
		const int expectedUserId = 123;
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
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(expectedGroupId);
						break;

					case BoardPost:
					{
						var a = x.Instance is BoardPost b
							? b
							: null;

						a.Text.Should()
							.Be(expectedText);

						a.TopicOwnerId.Should()
							.Be(unExpectedGroupId);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_BoardPostDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostDeleteTest));

		var expectedGroupId = new GroupId(1234);
		const int unExpectedGroupId = -1234;
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
				switch (x.Instance)
				{
					case GroupId:
						x.Instance.Should()
							.Be(expectedGroupId);
						break;

					case BoardPostDelete:
					{
						var a = x.Instance is BoardPostDelete b
							? b
							: null;

						a.TopicId.Should()
							.Be(expectedTopicId);

						a.TopicOwnerId.Should()
							.Be(unExpectedGroupId);

						a.Id.Should()
							.Be(expectedId);

						break;
					}
				}
			});
	}
}