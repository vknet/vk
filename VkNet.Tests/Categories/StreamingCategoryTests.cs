using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories
{
	public class StreamingCategoryTests : BaseTest
	{
		[Test]
		public void GetServerUrl()
		{
			Url = "https://api.vk.com/method/streaming.getServerUrl";

			Json =
					@"{
					""response"": {
						""endpoint"": ""streaming.vk.com"",
						""key"": ""be8d29c05546e58cb52420aaf2b9f51f0a440f89""
					}
				}
            ";

			var result = Api.Streaming.GetServerUrl();

			Assert.IsNotNull(anObject: result);
			Assert.AreEqual(expected: "streaming.vk.com", actual: result.Endpoint);
			Assert.AreEqual(expected: "be8d29c05546e58cb52420aaf2b9f51f0a440f89", actual: result.Key);
		}

		[Test]
		public void GetSettings()
		{
			Url = "https://api.vk.com/method/streaming.getSettings";

			Json =
					@"{
					""response"": {
						""monthly_limit"": ""tier_6""
					}
				}
            ";

			var result = Api.Streaming.GetSettings();

			Assert.IsNotNull(anObject: result);
			Assert.AreEqual(expected: MonthlyLimit.Tier6, actual: result.MonthlyLimit);
		}

		[Test]
		public void GetStats()
		{
			Url = "https://api.vk.com/method/streaming.getStats";

			Json =
					@"{
					response: [
						{
							event_type: ""post"",
							stats: [
								{
									timestamp: 1525208400,
									value: 160
								},
								{
									timestamp: 1525294800,
									value: 155
								}
							]
						}
					]
				}
            ";

			var result = Api.Streaming.GetStats(type: "prepared", interval: "24h", startTime: new DateTime(year: 2018, month: 5, day: 1)
					, endTime: new DateTime(year: 2018, month: 5, day: 20));

			Assert.IsNotEmpty(collection: result);

			var stats = result.FirstOrDefault();
			Assert.NotNull(anObject: stats);
			Assert.AreEqual(expected: StreamingEventType.Post, actual: stats.EventType);
			Assert.IsNotEmpty(collection: stats.Stats);
		}

		[Test]
		public void SetSettings()
		{
			Url = "https://api.vk.com/method/streaming.setSettings";

			Json =
					@"{
					response: 1
				}
            ";

			var result = Api.Streaming.SetSettings(monthlyTier: MonthlyLimit.Tier6);

			Assert.IsTrue(condition: result);
		}
	}
}