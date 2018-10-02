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
			const string json = "{\"failed\":1, \"ts\":10}";
			var groupCategory = GetMockedGroupCategory("https://vk.com", json);

			Assert.Throws<LongPollOutdateException>(() => groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}));
		}

		[Test]
		public void GetBotsLongPollHistory_Failed1Ts()
		{
			const string json = "{\"failed\":1, \"ts\":10}";
			var groupCategory = GetMockedGroupCategory("https://vk.com", json);

			const int ts = 10;

			try
			{
				groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
				{
					Key = "test",
					Server = "https://vk.com",
					Ts = 0,
					Wait = 10
				});

				Assert.Fail();
			}
			catch (LongPollOutdateException exception)
			{
				Assert.AreEqual(ts, exception.Ts);
			}
		}

		[Test]
		public void GetBotsLongPollHistory_Failed2()
		{
			const string json = "{\"failed\":2}";
			var groupCategory = GetMockedGroupCategory("https://vk.com", json);

			Assert.Throws<LongPollKeyExpiredException>(() => groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}));
		}

		[Test]
		public void GetBotsLongPollHistory_Failed3()
		{
			const string json = "{\"failed\":3}";
			var groupCategory = GetMockedGroupCategory("https://vk.com", json);

			Assert.Throws<LongPollInfoLostException>(() => groupCategory.GetBotsLongPollHistory(new BotsLongPollHistoryParams
			{
				Key = "test",
				Server = "https://vk.com",
				Ts = 0,
				Wait = 10
			}));
		}
	}
}