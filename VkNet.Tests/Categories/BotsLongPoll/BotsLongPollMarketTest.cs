using FluentAssertions;
using VkNet.Model.GroupUpdate;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollMarketTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_MarketCommentNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentNewTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const string text = "test";
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

					case MarketComment:
					{
						var a = x.Instance is MarketComment b
							? b
							: null;
						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.MarketOwnerId.Should()
							.Be(unGroupId);
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MarketCommentEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentEditTest));

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

					case MarketComment:
					{
						var a = x.Instance is MarketComment b
							? b
							: null;
						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.MarketOwnerId.Should()
							.Be(unGroupId);
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MarketCommentRestoreTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentRestoreTest));

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

					case MarketComment:
					{
						var a = x.Instance is MarketComment b
							? b
							: null;
						a.FromId.Should()
							.Be(userId);

						a.Text.Should()
							.Be(text);

						a.MarketOwnerId.Should()
							.Be(unGroupId);
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MarketCommentDeleteTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MarketCommentDeleteTest));

		const int deleterId = 123;
		var groupId = new GroupId(1234);
		const int itemId = 4444;
		const int unGroupId = -1234;
		const int id = 1;

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

					case MarketCommentDelete:
					{
						var a = x.Instance is MarketCommentDelete b
							? b
							: null;
						a.OwnerId.Should()
							.Be(unGroupId);

						a.DeleterId.Should()
							.Be(deleterId);

						a.ItemId.Should()
							.Be(itemId);

						a.Id.Should()
							.Be(id);
						break;
					}
				}
			});

	}
}