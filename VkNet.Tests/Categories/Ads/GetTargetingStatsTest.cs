using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetTargetingStatsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get targeting stats")]
	public void GetTargetingStats()
	{
		Url = "https://api.vk.ru/method/ads.getTargetingStats";

		ReadCategoryJsonPath(nameof(Api.Ads.GetTargetingStats));

		var result = Api.Ads.GetTargetingStats(new()
		{
			AccountId = 123
		});

		result.AudienceCount.Should()
			.Be(79189000);
	}
}