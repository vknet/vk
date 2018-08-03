using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;

namespace VkNet.Tests.Categories.Ads
{
	public class AdsGetAdsTests : BaseTest
	{
		[Test]
		public void GetAds_GenerateAdsCorrectly()
		{
			Url = "https://api.vk.com/method/ads.getAds";

			Json = @"
			{
				""response"": [{
					""campaign_id"": 1009150293,
					""id"": ""42644528"",
					""status"": 0,
					""approved"": ""1"",
					""create_time"": ""1527069558"",
					""update_time"": ""1529160522"",
					""day_limit"": ""0"",
					""all_limit"": ""0"",
					""start_time"": ""0"",
					""stop_time"": ""0"",
					""category1_id"": ""285"",
					""category2_id"": ""0"",
					""age_restriction"": ""5"",
					""name"": ""Сеты шаров на свою группу."",
					""events_retargeting_groups"": {
						""26897268"": [5, 6]
					},
					""cost_type"": 1,
					""ad_format"": 9,
					""cpm"": ""23699"",
					""impressions_limit"": 1,
					""ad_platform"": ""all"",
					""ad_platform_no_wall"": 1,
					""ad_platform_no_ad_network"": 1
				}]
			}";

			var ads = Api.Ads.GetAds(new GetAdsParams()
				{ AccountId = 1900013324, ClientId = 1604555949, CampaignIds = new List<long>() { 1009150293, 1009400691 } });

			Assert.IsNotEmpty(ads);

			var ad = ads.FirstOrDefault();
			Assert.That(ads.Count, Is.EqualTo(1));
			Assert.That(ad.Id, Is.EqualTo(42644528));
			Assert.That(ad.CampaignId, Is.EqualTo(1009150293));
			Assert.That(ad.Status, Is.EqualTo(AdStatus.Stopped));
			Assert.That(ad.ModerationStatus, Is.EqualTo(ModerationStatus.Waiting));
			Assert.That(ad.AllLimit, Is.EqualTo(0));
			Assert.That(ad.Category1Id, Is.EqualTo(285));
			Assert.That(ad.Category2Id, Is.EqualTo(0));
			Assert.That(ad.Name, Is.EqualTo("Сеты шаров на свою группу."));
			Assert.That(ad.CostType, Is.EqualTo(CostType.Cpm));
			Assert.That(ad.AdFormat, Is.EqualTo(AdFormat.Public));
			Assert.That(ad.Cpm, Is.EqualTo(23699));
			Assert.That(ad.ImpressionsLimit, Is.EqualTo(1));
			Assert.That(ad.AdPlatform, Is.EqualTo(AdPlatform.All));
			Assert.That(ad.AdPlatformNoAdNetwork, Is.EqualTo(true));
			Assert.That(ad.AdPPlatformNoWall, Is.EqualTo(true));
			Assert.That(ad.CreateTime, Is.EqualTo(new DateTime(2018, 5, 23, 9, 59, 18)));
			Assert.That(ad.UpdateTime, Is.EqualTo(new DateTime(2018, 6, 16, 14, 48, 42)));
			Assert.That(ad.DayLimit, Is.EqualTo(0));
			Assert.That(ad.AgeRestriction, Is.EqualTo(AdAgeRestriction.EighteeenPlus));

			Assert.That(ad.EventsRetargetingGroups[26897268][0],
				Is.EqualTo(EventsRetargetingGroup.PublicNewsUnsubscription));

			Assert.That(ad.EventsRetargetingGroups[26897268][1],
				Is.EqualTo(EventsRetargetingGroup.HidingOrComplaint));
		}
	}
}