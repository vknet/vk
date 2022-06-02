using System;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class UpdateAdsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
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
				LinkUrl = new Uri("https://vk.com/nixus9?w=wall-126102803_64")
			};

			var adEditSpecification2 = new AdEditSpecification
			{
				AdId = 1012219949,
				AgeRestriction = AdAgeRestriction.NoRestriction,
				Name = "123",
				Cpc = 3156,
				AdPlatform = AdPlatform.All,
				LinkUrl = new Uri("https://vk.com/nixus9?w=wall-126102803_64")
			};

			AdEditSpecification[] data =
			{
				adEditSpecification1,
				adEditSpecification2
			};

			var officeUsers = Api.Ads.UpdateAds(new AdsDataSpecificationParams<AdEditSpecification>
			{
				Data = data,
				AccountId = 1605245430
			});

			officeUsers[0].Id.Should().Be(1);
			officeUsers[0].ErrorCode.Should().Be(100);
			officeUsers[1].Id.Should().Be(2);
		}
	}
}