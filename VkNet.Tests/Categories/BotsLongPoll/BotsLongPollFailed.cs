using FluentAssertions;
using VkNet.Exception;
using Xunit;

namespace VkNet.Tests.Categories.BotsLongPoll;

public class BotsLongPollFailed : BotsLongPollBaseTest
{
	[Fact]
	public void GetBotsLongPollHistory_Failed1()
	{
		Url = "https://vk.com";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollOutdateException>();
	}

	[Fact]
	public void GetBotsLongPollHistory_Failed1Ts()
	{
		Url = "https://vk.com";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1Ts));

		const ulong ts = 10;

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollOutdateException>()
			.And.Ts.Should()
			.Be(ts);
	}

	[Fact]
	public void GetBotsLongPollHistory_Failed2()
	{
		Url = "https://vk.com";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed2));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollKeyExpiredException>();
	}

	[Fact]
	public void GetBotsLongPollHistory_Failed3()
	{
		Url = "https://vk.com";
		ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed3));

		FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new()
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}))
			.Should()
			.ThrowExactly<LongPollInfoLostException>();
	}
}