using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetBudgetTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetBudget()
		{
			Url = "https://api.vk.com/method/ads.getBudget";

			ReadCategoryJsonPath(nameof(Api.Ads.GetBudget));


			var result = Api.Ads.GetBudget(1605245430);

			result.Should().Be(100.00);
		}
	}
}