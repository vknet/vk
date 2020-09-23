using NUnit.Framework;
using VkNet.Model.RequestParams.Leads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Leads
{

	public class LeadsCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Leads";

		[Test]
		public void Complete()
		{
			Url = "https://api.vk.com/method/leads.complete";
			ReadCategoryJsonPath(nameof(Complete));

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
			ReadCategoryJsonPath(nameof(Start));

			var result = Api.Leads.Start(new StartParams());

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.TestMode);
			Assert.AreEqual("vk_sid", result.VkSid);
		}

		[Test]
		public void GetUsers()
		{
			Url = "https://api.vk.com/method/leads.getUsers";
			ReadCategoryJsonPath(nameof(GetUsers));

			var result = Api.Leads.GetUsers(new GetUsersParams());

			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);
		}
	}
}