using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollMessageTest : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_MessageNewTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageNewTest));

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
							.Be(new GroupId(123456789));
						break;

					case MessageNew:
					{
						var a = x.Instance is MessageNew b
							? b
							: null;

						a.ClientInfo.ButtonActions.Should()
							.NotBeEmpty();

						a.ClientInfo.Keyboard.Should()
							.BeTrue();

						a.ClientInfo.InlineKeyboard.Should()
							.BeFalse();

						a.ClientInfo.LangId.Should()
							.Be(Language.Ru);

						a.Message.FromId.Should()
							.Be(123456789);


						a.Message.Text.Should()
							.Be("f");

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageNewTemplateTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageNewTemplateTest));

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
							.Be(new GroupId(123456789));
						break;

					case MessageNew:
					{
						var a = x.Instance is MessageNew b
							? b
							: null;

						a.ClientInfo.ButtonActions.Should()
							.NotBeEmpty();

						a.ClientInfo.Keyboard.Should()
							.BeTrue();

						a.ClientInfo.InlineKeyboard.Should()
							.BeFalse();

						a.ClientInfo.LangId.Should()
							.Be(Language.Ru);

						a.Message.FromId.Should()
							.Be(123456789);


						a.Message.Text.Should()
							.Be("f");

						a.Message.Template.Type.Should()
							.Be(TemplateType.Carousel);

						a.Message.Template.Elements.FirstOrDefault()
							.Photo
							.HasTags.Should()
							.BeFalse();
						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageEditTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageEditTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
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

					case MessageNew:
					{
						var a = x.Instance is MessageNew b
							? b
							: null;

						a.Message.FromId.Should()
							.Be(userId);

						a.Message.Text.Should()
							.Be(text);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageReplyTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageReplyTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
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

					case MessageNew:
					{
						var a = x.Instance is MessageNew b
							? b
							: null;

						a.Message.FromId.Should()
							.Be(userId);

						a.Message.Text.Should()
							.Be(text);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageAllowTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageAllowTest));

		const int userId = 123;
		var groupId = new GroupId(1234);
		const string key = "123456";

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

					case MessageAllow:
					{
						var a = x.Instance is MessageAllow b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						a.Key.Should()
							.Be(key);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageDenyTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageDenyTest));

		const int userId = 123;
		var groupId = new GroupId(1234);

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

					case MessageDeny:
					{
						var a = x.Instance is MessageDeny b
							? b
							: null;

						a.UserId.Should()
							.Be(userId);

						break;
					}
				}
			});
	}

	[Fact]
	public void GetBotsLongPollHistory_MessageEventTest()
	{
		ReadCategoryJsonPath(nameof(GetBotsLongPollHistory_MessageEventTest));

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
							.Be(new GroupId(1234));
						break;

					case MessageEvent:
					{
						var a = x.Instance is MessageEvent b
							? b
							: null;

						a.EventId.Should()
							.Be("feleyinek");

						a.UserId.Should()
							.Be(123456789);

						a.PeerId.Should()
							.Be(123456789);

						a.ConversationMessageId.Should()
							.Be(1234);

						a.Payload.Should()
							.Be("{}");

						break;
					}
				}
			});
	}
}