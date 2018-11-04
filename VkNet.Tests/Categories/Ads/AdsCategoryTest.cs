using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class AdsCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetAccounts_GenerateOutParametersCorrectly()
		{
			Url = "https://api.vk.com/method/ads.getAccounts";

			ReadCategoryJsonPath(nameof(Api.Ads.GetAccounts));

			var accounts = Api.Ads.GetAccounts();

			Assert.That(accounts.Count, Is.EqualTo(3));

			Assert.That(accounts[1].AccountId, Is.EqualTo(1900013324));
			Assert.That(accounts[1].AccountType, Is.EqualTo(AccountType.Agency));
			Assert.That(accounts[1].AccountStatus, Is.EqualTo(AccountStatus.Active));
			Assert.That(accounts[1].AccountName, Is.EqualTo("Кабинет агентства"));
			Assert.That(accounts[1].AccessRole, Is.EqualTo(AccessRole.Manager));
		}

		[Test]
		public void GetCampaigns_AgencyAccount_Arch_Filtered_OutParametersCorrect()
		{
			Url = "https://api.vk.com/method/ads.getCampaigns";

			ReadCategoryJsonPath(nameof(Api.Ads.GetCampaigns));

			var campaigns = Api.Ads.GetCampaigns(1900013324,
				new List<long>
				{
					1009157560,
					1009088099,
					1009150293,
					1009316667
				},
				1604555949,
				true);

			Assert.That(campaigns.Count, Is.EqualTo(4));

			// ID кампании
			Assert.That(campaigns[3].Id, Is.EqualTo(1009316667));
		}

		[Test]
		public void GetCampaigns_GeneralAccount_OutParametersCorrect()
		{
			Url = "https://api.vk.com/method/ads.getCampaigns";

			ReadCategoryJsonPath(nameof(GetCampaigns_GeneralAccount_OutParametersCorrect));

			var campaigns = Api.Ads.GetCampaigns(1603879239, new List<long>());

			Assert.That(campaigns.Count, Is.EqualTo(6));

			// ID кампании
			Assert.That(campaigns[3].Id, Is.EqualTo(1008003092));

			// ID кампании
			Assert.That(campaigns[4].Name, Is.EqualTo("Продвижение записей"));

			// Типы кампаний
			Assert.That(campaigns[0].Type, Is.EqualTo(CampaignType.Normal));
			Assert.That(campaigns[1].Type, Is.EqualTo(CampaignType.VkAppsManaged));
			Assert.That(campaigns[2].Type, Is.EqualTo(CampaignType.MobileApps));
			Assert.That(campaigns[3].Type, Is.EqualTo(CampaignType.PromotedPosts));

			// Лимиты
			Assert.That(campaigns[3].DayLimit, Is.EqualTo(10000));
			Assert.That(campaigns[3].AllLimit, Is.EqualTo(200000));

			// Даты
			Assert.That(campaigns[3].StartTime,
				Is.EqualTo(new DateTime(2017, 10, 1, 19, 37, 24)));

			Assert.That(campaigns[3].StopTime,
				Is.EqualTo(new DateTime(2017, 10, 1, 19, 56, 39)));

			Assert.That(campaigns[3].CreateTime,
				Is.EqualTo(new DateTime(2017, 09, 29, 10, 22, 15)));

			Assert.That(campaigns[3].UpdateTime,
				Is.EqualTo(new DateTime(2018, 01, 23, 17, 02, 48)));
		}
	}
}