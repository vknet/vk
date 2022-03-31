using FluentAssertions;
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

			result.Should().NotBeNull();
			result.Limit.Should().Be(1000);
			result.DayLimit.Should().Be(500);
			result.Spent.Should().Be(10);
			result.Cost.Should().Be("1");
			result.TestMode.Should().Be(1);
			result.Success.Should().Be(1);
		}

		[Test]
		public void Start()
		{
			Url = "https://api.vk.com/method/leads.start";
			ReadCategoryJsonPath(nameof(Start));

			var result = Api.Leads.Start(new StartParams());

			result.Should().NotBeNull();
			result.TestMode.Should().Be(1);
			result.VkSid.Should().Be("vk_sid");
		}

		[Test]
		public void GetUsers()
		{
			Url = "https://api.vk.com/method/leads.getUsers";
			ReadCategoryJsonPath(nameof(GetUsers));

			var result = Api.Leads.GetUsers(new GetUsersParams());

			result.Should().NotBeNull();
			Assert.IsNotEmpty(result);
		}
	}
}