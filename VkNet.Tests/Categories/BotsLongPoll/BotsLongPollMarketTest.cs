using System.Linq;
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

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.MarketComment.FromId.Should()
			.Be(userId);

		update.MarketComment.Text.Should()
			.Be(text);

		update.MarketComment.MarketOwnerId.Should()
			.Be(unGroupId);
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

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.MarketComment.FromId.Should()
			.Be(userId);

		update.MarketComment.Text.Should()
			.Be(text);

		update.MarketComment.MarketOwnerId.Should()
			.Be(unGroupId);
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

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.MarketComment.FromId.Should()
			.Be(userId);

		update.MarketComment.Text.Should()
			.Be(text);

		update.MarketComment.MarketOwnerId.Should()
			.Be(unGroupId);
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

		var update = botsLongPollHistory.Updates.First();

		update.GroupId.Should()
			.Be(groupId);

		update.MarketCommentDelete.OwnerId.Should()
			.Be(unGroupId);

		update.MarketCommentDelete.DeleterId.Should()
			.Be(deleterId);

		update.MarketCommentDelete.ItemId.Should()
			.Be(itemId);

		update.MarketCommentDelete.Id.Should()
			.Be(id);
	}
}