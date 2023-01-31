using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetAdsTargetingTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetAdsTargeting()
	{
		Url = "https://api.vk.com/method/ads.getAdsTargeting";

		ReadCategoryJsonPath(nameof(Api.Ads.GetAdsTargeting));

		var result = Api.Ads.GetAdsTargeting(new()
		{
			AccountId = 1605245430,
			AdIds = "123",
			CampaignIds = "123",
			ClientId = 123,
			IncludeDeleted = true,
			Limit = 100,
			Offset = 0
		});

		result[0]
			.Id.Should()
			.Be("11021348");
	}
}