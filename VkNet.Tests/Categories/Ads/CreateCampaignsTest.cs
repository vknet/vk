using System;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class CreateCampaignsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void CreateCampaigns()
	{
		Url = "https://api.vk.com/method/ads.createCampaigns";

		ReadCategoryJsonPath(nameof(Api.Ads.CreateCampaigns));

		var campaignSpecification1 = new CampaignSpecification
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

		var campaignSpecification2 = new CampaignSpecification
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

		var officeUsers = Api.Ads.CreateCampaigns(new()
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