using System.Linq;
using FluentAssertions;
using VkNet.Model.RequestParams;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll
{

	public class BotsLongPollBoardTest : BotsLongPollBaseTest
	{
		[Fact]
		public void GetBotsLongPollHistory_BoardPostNew()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNew));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.GroupId.Should().Be(groupId);
			update.BoardPost.FromId.Should().Be(userId);
			update.BoardPost.Text.Should().Be(text);
			update.BoardPost.TopicOwnerId.Should().Be(-groupId);
		}

		[Fact]
		public void GetBotsLongPollHistory_BoardPostNewFirst()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostNewFirst));

			const int groupId = 1234;
			const string text = "test";
			const int topicId = 6;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.BoardPost.FromId.Should().Be(-groupId);
			update.GroupId.Should().Be(groupId);
			update.BoardPost.Text.Should().Be(text);
			update.BoardPost.TopicOwnerId.Should().Be(-groupId);
			update.BoardPost.TopicId.Should().Be(topicId);
		}

		[Fact]
		public void GetBotsLongPollHistory_BoardPostEditTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostEditTest));

			const int groupId = 1234;
			const string text = "test1";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.BoardPost.FromId.Should().Be(-groupId);
			update.GroupId.Should().Be(groupId);
			update.BoardPost.Text.Should().Be(text);
			update.BoardPost.TopicOwnerId.Should().Be(-groupId);
		}

		[Fact]
		public void GetBotsLongPollHistory_BoardPostRestoreTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostRestoreTest));

			const int userId = 123;
			const int groupId = 1234;
			const string text = "test";

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.BoardPost.FromId.Should().Be(userId);
			update.GroupId.Should().Be(groupId);
			update.BoardPost.Text.Should().Be(text);
			update.BoardPost.TopicOwnerId.Should().Be(-groupId);
		}

		[Fact]
		public void GetBotsLongPollHistory_BoardPostDeleteTest()
		{
			ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_BoardPostDeleteTest));

			const int groupId = 1234;
			const int topicId = 6;
			const int id = 3;

			var botsLongPollHistory = Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			});

			var update = botsLongPollHistory.Updates.First();

			update.GroupId.Should().Be(groupId);
			update.BoardPostDelete.TopicOwnerId.Should().Be(-groupId);
			update.BoardPostDelete.TopicId.Should().Be(topicId);
			update.BoardPostDelete.Id.Should().Be(id);
		}
	}
}