using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetBudgetTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetBudget()
	{
		Url = "https://api.vk.com/method/ads.getBudget";

		ReadCategoryJsonPath(nameof(Api.Ads.GetBudget));

		var result = Api.Ads.GetBudget(1605245430);

		result.Should()
			.Be(100.00);
	}
}