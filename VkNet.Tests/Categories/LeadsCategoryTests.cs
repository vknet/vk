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

			var result = Api.Leads.Complete(vkSid: "test8f4f23fb62c5c89fbb", secret: "bb4f37150027a9cf51", comment: string.Empty);
			Assert.IsNotNull(anObject: result);
			Assert.AreEqual(expected: 1000, actual: result.Limit);
			Assert.AreEqual(expected: 500, actual: result.DayLimit);
			Assert.AreEqual(expected: 10, actual: result.Spent);
			Assert.AreEqual(expected: "1", actual: result.Cost);
			Assert.AreEqual(expected: 1, actual: result.TestMode);
			Assert.AreEqual(expected: 1, actual: result.Success);
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

			var result = Api.Leads.Start(startParams: new StartParams());
			Assert.IsNotNull(anObject: result);
			Assert.AreEqual(expected: 1, actual: result.TestMode);
			Assert.AreEqual(expected: "vk_sid", actual: result.VkSid);
		}

		[Test]
		public void GetUsers()
		{
			Url = "https://api.vk.com/method/leads.getUsers";

			Json =
					@"{
					response: [
						{
							uid: 214402965,
							aid: 3812231,
							sid: ""testcb94fcab4fb7107250"",
							date: 1376468670,
							status: 1,
							test_mode: 1,
							comment: ""group autocomplete"",
							start_date: 1376468668
						}
					]
				}
            ";

			var result = Api.Leads.GetUsers(getUsersParams: new GetUsersParams());
			Assert.IsNotNull(anObject: result);
			Assert.IsNotEmpty(collection: result);
		}
	}
}