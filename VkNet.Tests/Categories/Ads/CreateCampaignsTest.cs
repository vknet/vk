using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class CreateCampaignsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CreateCampaigns()
		{
			Url = "https://api.vk.com/method/ads.createCampaigns";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateCampaigns));

			CampaignSpecification campaignSpecification1 = new CampaignSpecification
			{
				ClientId = 1012219949,
				Type = CampaignType.Normal,
				Name = "123",
				Status = AdStatus.Stopped,
				AllLimit = 100,
				DayLimit = 100,
				StartTime = DateTime.Today ,
				StopTime = DateTime.Now
			};

			CampaignSpecification campaignSpecification2 = new CampaignSpecification
			{
				ClientId = 1012219949,
				Type = CampaignType.Normal,
				Name = "123",
				Status = AdStatus.Stopped,
				AllLimit = 100,
				DayLimit = 100,
				StartTime = DateTime.Today,
				StopTime = DateTime.Now
			};

			CampaignSpecification[] data =
			{
				campaignSpecification1,
				campaignSpecification2
			};

			var officeUsers = Api.Ads.CreateCampaigns(new AdsDataSpecificationParams<CampaignSpecification>
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