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

			Assert.IsNotNull(result);
			Assert.AreEqual("streaming.vk.com", result.Endpoint);
			Assert.AreEqual("be8d29c05546e58cb52420aaf2b9f51f0a440f89", result.Key);
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

			Assert.IsNotNull(result);
			Assert.AreEqual(MonthlyLimit.Tier6, result.MonthlyLimit);
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

			var result = Api.Streaming.GetStats("prepared"
					, "24h"
					, new DateTime(2018, 5, 1)
					, new DateTime(2018, 5, 20));

			Assert.IsNotEmpty(result);

			var stats = result.FirstOrDefault();
			Assert.NotNull(stats);
			Assert.AreEqual(StreamingEventType.Post, stats.EventType);
			Assert.IsNotEmpty(stats.Stats);
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

			var result = Api.Streaming.SetSettings(MonthlyLimit.Tier6);

			Assert.IsTrue(result);
		}
	}
}