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

			Assert.Throws<LongPollOutdateException>(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			}));
		}

		[Test]
		public void GetBotsLongPollHistory_Failed1Ts()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed1Ts));

			const string ts = "10";

			try
			{
				Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = "0",
					Wait = 10
				});

				Assert.Fail();
			}
			catch (LongPollOutdateException exception)
			{
				exception.Ts.Should().Be(ts);
			}
		}

		[Test]
		public void GetBotsLongPollHistory_Failed2()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed2));

			Assert.Throws<LongPollKeyExpiredException>(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			}));
		}

		[Test]
		public void GetBotsLongPollHistory_Failed3()
		{
			Url = "https://vk.com";
			ReadJsonFile("Categories", Folder, nameof(GetBotsLongPollHistory_Failed3));

			Assert.Throws<LongPollInfoLostException>(() => Api.Groups.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = "0",
				Wait = 10
			}));
		}
	}
}