using System;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateCampaignsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateCampaigns()
	{
		Url = "https://api.vk.com/method/ads.updateCampaigns";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateCampaigns));

		var campaignModSpecification1 = new CampaignModSpecification
		{
			CampaignId = 1012219949,
			Status = AdStatus.Active,
			Name = "123",
			AllLimit = 100,
			DayLimit = 50,
			StartTime = DateTime.Now,
			StopTime = DateTime.Now
		};

		var campaignModSpecification2 = new CampaignModSpecification
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

		var officeUsers = Api.Ads.UpdateCampaigns(new()
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