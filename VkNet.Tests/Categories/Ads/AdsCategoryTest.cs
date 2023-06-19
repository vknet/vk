using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class AdsCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetAccounts_GenerateOutParametersCorrectly()
	{
		Url = "https://api.vk.com/method/ads.getAccounts";

		ReadCategoryJsonPath(nameof(Api.Ads.GetAccounts));

		var accounts = Api.Ads.GetAccounts();

		accounts.Should()
			.HaveCount(3);

		accounts[1]
			.AccountId.Should()
			.Be(1900013324);

		accounts[1]
			.AccountType.Should()
			.Be(AccountType.Agency);

		accounts[1]
			.AccountStatus.Should()
			.Be(AccountStatus.Active);

		accounts[1]
			.AccountName.Should()
			.Be("Кабинет агентства");

		accounts[1]
			.AccessRole.Should()
			.Be(AccessRole.Manager);
	}

	[Fact]
	public void GetCampaigns_AgencyAccount_Arch_Filtered_OutParametersCorrect()
	{
		Url = "https://api.vk.com/method/ads.getCampaigns";

		ReadCategoryJsonPath(nameof(Api.Ads.GetCampaigns));

		var campaigns = Api.Ads.GetCampaigns(new()
		{
			AccountId = 1900013324,
			CampaignIds = new List<long>
			{
				1009157560,
				1009088099,
				1009150293,
				1009316667
			},
			ClientId = 123,
			IncludeDeleted = true
		});

		campaigns.Should()
			.HaveCount(4);

		// ID кампании
		campaigns[3]
			.Id.Should()
			.Be(1009316667);
	}

	[Fact]
	public void GetCampaigns_GeneralAccount_OutParametersCorrect()
	{
		Url = "https://api.vk.com/method/ads.getCampaigns";

		ReadCategoryJsonPath(nameof(GetCampaigns_GeneralAccount_OutParametersCorrect));

		var campaigns = Api.Ads.GetCampaigns(new()
		{
			AccountId = 123,
			CampaignIds = new List<long>(),
			IncludeDeleted = true
		});

		campaigns.Should()
			.HaveCount(6);

		// ID кампании
		campaigns[3]
			.Id.Should()
			.Be(1008003092);

		// ID кампании
		campaigns[4]
			.Name.Should()
			.Be("Продвижение записей");

		// Типы кампаний
		campaigns[0]
			.Type.Should()
			.Be(CampaignType.Normal);

		campaigns[1]
			.Type.Should()
			.Be(CampaignType.VkAppsManaged);

		campaigns[2]
			.Type.Should()
			.Be(CampaignType.MobileApps);

		campaigns[3]
			.Type.Should()
			.Be(CampaignType.PromotedPosts);

		// Лимиты
		campaigns[3]
			.DayLimit.Should()
			.Be(10000);

		campaigns[3]
			.AllLimit.Should()
			.Be(200000);

		// Даты
		campaigns[3]
			.StartTime.Should()
			.Be(new(2017, 10, 1, 19, 37,
				24));

		campaigns[3]
			.StopTime.Should()
			.Be(new(2017, 10, 1, 19, 56,
				39));

		campaigns[3]
			.CreateTime.Should()
			.Be(new(2017, 09, 29, 10, 22,
				15));

		campaigns[3]
			.UpdateTime.Should()
			.Be(new(2018, 01, 23, 17, 02,
				48));
	}
}