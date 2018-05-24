using NUnit.Framework;
using VkNet.Model.RequestParams.Leads;

namespace VkNet.Tests.Categories
{
	public class LeadsCategoryTests : BaseTest
	{
		[Test]
		public void Complete()
		{
			Url = "https://api.vk.com/method/leads.complete";

			Json =
				@"{
					""response"": {
						""limit"": 1000,
						""day_limit"": 500,
						""spent"": 10,
						""cost"": ""1"",
						""test_mode"": 1,
						""success"": 1
					}
				}
            ";

			var result = Api.Leads.Complete("test8f4f23fb62c5c89fbb", "bb4f37150027a9cf51", string.Empty);
			Assert.IsNotNull(result);
			Assert.AreEqual(1000, result.Limit);
			Assert.AreEqual(500, result.DayLimit);
			Assert.AreEqual(10, result.Spent);
			Assert.AreEqual("1", result.Cost);
			Assert.AreEqual(1, result.TestMode);
			Assert.AreEqual(1, result.Success);
		}

		[Test]
		public void Start()
		{
			Url = "https://api.vk.com/method/leads.start";

			Json =
				@"{
					""response"": {
						""test_mode"": 1,
						""vk_sid"": ""vk_sid""
					}
				}
            ";

			var result = Api.Leads.Start(new StartParams());
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.TestMode);
			Assert.AreEqual("vk_sid", result.VkSid);
			
		}
	}
}