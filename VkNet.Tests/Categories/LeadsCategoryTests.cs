using NUnit.Framework;

namespace VkNet.Tests.Categories
{
	public class LeadsCategoryTests: BaseTest
	{
		[Test]
		public void GetPages()
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
		
	}
}