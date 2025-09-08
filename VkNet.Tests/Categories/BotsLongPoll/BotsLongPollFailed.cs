using AwesomeAssertions;
using VkNet.Exception;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollFailed : BotsLongPollBaseTest
{
	[Fact(DisplayName = "Get bots long poll history failed1")]
	public void GetBotsLongPollHistory_Failed1()
	{
		Url = "https://vk.ru";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.ru",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollOutdateException>();
	}

	[Fact(DisplayName = "Get bots long poll history failed1 ts")]
	public void GetBotsLongPollHistory_Failed1Ts()
	{
		Url = "https://vk.ru";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1Ts));

		const ulong ts = 10;

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.ru",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollOutdateException>()
			.And.Ts.Should()
			.Be(ts);
	}

	[Fact(DisplayName = "Get bots long poll history failed2")]
	public void GetBotsLongPollHistory_Failed2()
	{
		Url = "https://vk.ru";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed2));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.ru",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollKeyExpiredException>();
	}

	[Fact(DisplayName = "Get bots long poll history failed3")]
	public void GetBotsLongPollHistory_Failed3()
	{
		Url = "https://vk.ru";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed3));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.ru",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollInfoLostException>();
	}
}