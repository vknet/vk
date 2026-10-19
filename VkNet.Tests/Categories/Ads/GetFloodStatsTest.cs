using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetFloodStatsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get flood stats")]
	public void GetFloodStats()
	{
		Url = "https://api.vk.ru/method/ads.getFloodStats";

		ReadCategoryJsonPath(nameof(Api.Ads.GetFloodStats));

		var result = Api.Ads.GetFloodStats(123213);

		result.Left.Should()
			.Be(4998);
	}
}