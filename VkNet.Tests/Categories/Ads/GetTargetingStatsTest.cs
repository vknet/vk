using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetTargetingStatsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetTargetingStats()
	{
		Url = "https://api.vk.com/method/ads.getTargetingStats";

		ReadCategoryJsonPath(nameof(Api.Ads.GetTargetingStats));

		var result = Api.Ads.GetTargetingStats(new()
		{
			AccountId = 123
		});

		result.AudienceCount.Should()
			.Be(79189000);
	}
}