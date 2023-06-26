using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetStatisticsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetStatistics()
	{
		Url = "https://api.vk.com/method/ads.getStatistics";

		ReadCategoryJsonPath(nameof(Api.Ads.GetStatistics));

		var result = Api.Ads.GetStatistics(new()
		{
			AccountId = 123,
			DateFrom = "123",
			DateTo = "123",
			Ids = "123",
			IdsType = IdsType.Campaign,
			Period = "123"
		});

		result[0]
			.Id.Should()
			.Be(1012219949);
	}
}