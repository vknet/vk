using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetBudgetTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get budget")]
	public void GetBudget()
	{
		Url = "https://api.vk.ru/method/ads.getBudget";

		ReadCategoryJsonPath(nameof(Api.Ads.GetBudget));

		var result = Api.Ads.GetBudget(1605245430);

		result.Should()
			.Be(100.00);
	}
}