using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class AdsGetAdsTests : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetAds_GenerateAdsCorrectly()
	{
		Url = "https://api.vk.com/method/ads.getAds";

		ReadCategoryJsonPath(nameof(Api.Ads.GetAds));

		var ads = Api.Ads.GetAds(new()
		{
			AccountId = 1900013324,
			ClientId = 1604555949,
			CampaignIds = new List<long>
			{
				1009150293,
				1009400691
			}
		});

		ads.Should()
			.NotBeEmpty();

		var ad = ads.FirstOrDefault();

		ads.Should()
			.ContainSingle();

		ad.Id.Should()
			.Be(42644528);

		ad.CampaignId.Should()
			.Be(1009150293);

		ad.Status.Should()
			.Be(AdStatus.Stopped);

		ad.ModerationStatus.Should()
			.Be(ModerationStatus.Waiting);

		ad.AllLimit.Should()
			.Be(0);

		ad.Category1Id.Should()
			.Be(285);

		ad.Category2Id.Should()
			.Be(0);

		ad.Name.Should()
			.Be("Сеты шаров на свою группу.");

		ad.CostType.Should()
			.Be(CostType.Cpm);

		ad.AdFormat.Should()
			.Be(AdFormat.Public);

		ad.Cpm.Should()
			.Be(23699);

		ad.ImpressionsLimit.Should()
			.Be(1);

		ad.AdPlatform.Should()
			.Be(AdPlatform.All);

		ad.AdPlatformNoAdNetwork.Should()
			.BeTrue();

		ad.AdPPlatformNoWall.Should()
			.BeTrue();

		ad.CreateTime.Should()
			.Be(new(2018, 5, 23, 9, 59,
				18));

		ad.UpdateTime.Should()
			.Be(new(2018, 6, 16, 14, 48,
				42));

		ad.DayLimit.Should()
			.Be(0);

		ad.AgeRestriction.Should()
			.Be(AdAgeRestriction.EighteeenPlus);

		ad.EventsRetargetingGroups[26897268][0]
			.Should()
			.Be(EventsRetargetingGroup.PublicNewsUnsubscription);

		ad.EventsRetargetingGroups[26897268][1]
			.Should()
			.Be(EventsRetargetingGroup.HidingOrComplaint);
	}
}