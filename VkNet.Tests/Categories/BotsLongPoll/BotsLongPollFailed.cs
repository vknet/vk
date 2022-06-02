using FluentAssertions;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.BotsLongPoll
{
	[TestFixture]
	public class BotsLongPollFailed : BotsLongPollBaseTest
	{
		[Test]
		public void GetBotsLongPollHistory_Failed1()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1));

			FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = "0",
					Wait = 10
				}))
				.Should()
				.ThrowExactly<LongPollOutdateException>();
		}

		[Test]
		public void GetBotsLongPollHistory_Failed1Ts()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1Ts));

			const string ts = "10";

			FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = "0",
					Wait = 10
				}))
				.Should()
				.ThrowExactly<LongPollOutdateException>()
				.And.Ts.Should()
				.Be(ts);
		}

		[Test]
		public void GetBotsLongPollHistory_Failed2()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed2));

			FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = "0",
					Wait = 10
				}))
				.Should()
				.ThrowExactly<LongPollKeyExpiredException>();
		}

		[Test]
		public void GetBotsLongPollHistory_Failed3()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed3));

			FluentActions.Invoking(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = "0",
					Wait = 10
				}))
				.Should()
				.ThrowExactly<LongPollInfoLostException>();
		}
	}
}