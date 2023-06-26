using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateAdsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateAds()
	{
		Url = "https://api.vk.com/method/ads.updateAds";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateAds));

		var adEditSpecification1 = new AdEditSpecification
		{
			AdId = 1012219949,
			AgeRestriction = AdAgeRestriction.NoRestriction,
			Name = "123",
			Cpc = 3156,
			AdPlatform = AdPlatform.All,
			LinkUrl = new("https://vk.com/nixus9?w=wall-126102803_64")
		};

		var adEditSpecification2 = new AdEditSpecification
		{
			AdId = 1012219949,
			AgeRestriction = AdAgeRestriction.NoRestriction,
			Name = "123",
			Cpc = 3156,
			AdPlatform = AdPlatform.All,
			LinkUrl = new("https://vk.com/nixus9?w=wall-126102803_64")
		};

		AdEditSpecification[] data =
		{
			adEditSpecification1,
			adEditSpecification2
		};

		var officeUsers = Api.Ads.UpdateAds(new()
		{
			Data = data,
			AccountId = 1605245430
		});

		officeUsers[0]
			.Id.Should()
			.Be(1);

		officeUsers[0]
			.ErrorCode.Should()
			.Be(100);

		officeUsers[1]
			.Id.Should()
			.Be(2);
	}
}