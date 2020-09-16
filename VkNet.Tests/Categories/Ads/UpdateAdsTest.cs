using System;
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

			AdEditSpecification adEditSpecification1 = new AdEditSpecification
			{
				AdId = 1012219949,
				AgeRestriction = AdAgeRestriction.NoRestriction,
				Name = "123",
				Cpc = 3156,
				AdPlatform = AdPlatform.All,
				LinkUrl = new Uri("https://vk.com/nixus9?w=wall-126102803_64")
			};

			AdEditSpecification adEditSpecification2 = new AdEditSpecification
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

			Assert.That(officeUsers[0].Id, Is.EqualTo(1));
			Assert.That(officeUsers[0].ErrorCode, Is.EqualTo(100));
			Assert.That(officeUsers[1].Id, Is.EqualTo(2));
		}
	}
}