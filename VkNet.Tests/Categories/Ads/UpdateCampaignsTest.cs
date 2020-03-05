using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class UpdateCampaignsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void UpdateCampaigns()
		{
			Url = "https://api.vk.com/method/ads.updateCampaigns";

			ReadCategoryJsonPath(nameof(Api.Ads.UpdateCampaigns));

			CampaignModSpecification campaignModSpecification1 = new CampaignModSpecification
			{
				CampaignId = 1012219949,
				Status = AdStatus.Active,
				Name = "123",
				AllLimit = 100,
				DayLimit = 50,
				StartTime = DateTime.Now,
				StopTime = DateTime.Now
			};

			CampaignModSpecification campaignModSpecification2 = new CampaignModSpecification
			{
				CampaignId = 1012219949,
				Status = AdStatus.Active,
				Name = "123",
				AllLimit = 100,
				DayLimit = 50,
				StartTime = DateTime.Now,
				StopTime = DateTime.Now
			};

			CampaignModSpecification[] data =
			{
				campaignModSpecification1,
				campaignModSpecification2
			};

			var officeUsers = Api.Ads.UpdateCampaigns(new AdsDataSpecificationParams<CampaignModSpecification>
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