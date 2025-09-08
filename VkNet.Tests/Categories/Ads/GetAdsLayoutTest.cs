using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetAdsLayoutTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact(DisplayName = "Get ads layout")]
	public void GetAdsLayout()
	{
		Url = "https://api.vk.ru/method/ads.getAdsLayout";

		ReadCategoryJsonPath(nameof(Api.Ads.GetAdsLayout));

		var result = Api.Ads.GetAdsLayout(new()
		{
			AccountId = 1
		});

		result[0]
			.Id.Should()
			.Be(1);
	}
}