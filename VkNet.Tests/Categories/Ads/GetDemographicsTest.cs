using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetDemographicsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetDemographics()
	{
		Url = "https://api.vk.com/method/ads.getDemographics";

		ReadCategoryJsonPath(nameof(Api.Ads.GetDemographics));

		var result = Api.Ads.GetDemographics(new()
		{
			AccountId = 123,
			DateFrom = "123",
			DateTo = "123",
			Ids = "123,123",
			IdsType = IdsType.Ad,
			Period = "123"
		});

		result[0]
			.Id.Should()
			.Be(1012219949);
	}
}