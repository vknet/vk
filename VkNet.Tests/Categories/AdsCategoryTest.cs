using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class AdsCategoryTest : BaseTest
	{
		[Test]
		public void GetAccounts_GenerateOutParametersCorrectly()
		{
			Url = "https://api.vk.com/method/ads.getAccounts";

			Json =
					@"{
                    ""response"": [
                        {
                            ""account_id"": 1603879239,
                            ""account_type"": ""general"",
                            ""account_status"": 1,
                            ""account_name"": ""Личный кабинет"",
                            ""access_role"": ""admin""
                        },
                        {
                            ""account_id"": 1900013324,
                            ""account_type"": ""agency"",
                            ""account_status"": 1,
                            ""account_name"": ""Кабинет агентства"",
                            ""access_role"": ""manager""
                        },
                        {
                            ""account_id"": 1604369480,
                            ""account_type"": ""general"",
                            ""account_status"": 1,
                            ""account_name"": ""Николай Петров"",
                            ""access_role"": ""manager""
                        }
                    ]
                }";

			var accounts = Api.Ads.GetAccounts();

			Assert.That(actual: accounts.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: accounts[index: 1].AccountId, expression: Is.EqualTo(expected: 1900013324));
			Assert.That(actual: accounts[index: 1].AccountType, expression: Is.EqualTo(expected: AccountType.Agency));
			Assert.That(actual: accounts[index: 1].AccountStatus, expression: Is.EqualTo(expected: AccountStatus.Active));
			Assert.That(actual: accounts[index: 1].AccountName, expression: Is.EqualTo(expected: "Кабинет агентства"));
			Assert.That(actual: accounts[index: 1].AccessRole, expression: Is.EqualTo(expected: AccessRole.Manager));
		}

		[Test]
		public void GetCampaigns_AgencyAccount_Arch_Filtered_OutParametersCorrect()
		{
			Url = "https://api.vk.com/method/ads.getCampaigns";

			Json =
					@"{
                        ""response"": [{
                        ""id"": 1009088099,
                        ""type"": ""promoted_posts"",
                        ""name"": ""Сюрприз51 - Тест - День рождения"",
                        ""status"": 1,
                        ""day_limit"": ""2000"",
                        ""all_limit"": ""0"",
                        ""start_time"": ""0"",
                        ""stop_time"": ""0"",
                        ""create_time"": ""1521361421"",
                        ""update_time"": ""1525812787""
                        }, {
                        ""id"": 1009150293,
                        ""type"": ""promoted_posts"",
                        ""name"": ""Сюрприз51 - Рабочие"",
                        ""status"": 1,
                        ""day_limit"": ""2000"",
                        ""all_limit"": ""0"",
                        ""start_time"": ""0"",
                        ""stop_time"": ""0"",
                        ""create_time"": ""1522074190"",
                        ""update_time"": ""1526330822""
                        }, {
                        ""id"": 1009157560,
                        ""type"": ""promoted_posts"",
                        ""name"": ""Сюрприз51 - Тест - По конкурентам"",
                        ""status"": 0,
                        ""day_limit"": ""200"",
                        ""all_limit"": ""0"",
                        ""start_time"": ""0"",
                        ""stop_time"": ""0"",
                        ""create_time"": ""1522155165"",
                        ""update_time"": ""1523949817""
                        }, {
                        ""id"": 1009316667,
                        ""type"": ""normal"",
                        ""name"": ""Тизеры ЦА Родители с детьми"",
                        ""status"": 0,
                        ""day_limit"": ""1000"",
                        ""all_limit"": ""7000"",
                        ""start_time"": ""0"",
                        ""stop_time"": ""0"",
                        ""create_time"": ""1524046841"",
                        ""update_time"": ""1526923163""
                        }]
                }";

			var campaigns = Api.Ads.GetCampaigns(@params: new AdsGetCampaignsParams
			{
					AccountId = 1900013324
					, ClientId = 1604555949
					, IncludeDeleted = true
					, CampaignIds = new List<long>
					{
							1009157560
							, 1009088099
							, 1009150293
							, 1009316667
					}
			});

			Assert.That(actual: campaigns.Count, expression: Is.EqualTo(expected: 4));

			// ID кампании
			Assert.That(actual: campaigns[index: 3].Id, expression: Is.EqualTo(expected: 1009316667));
		}

		[Test]
		public void GetCampaigns_GeneralAccount_OutParametersCorrect()
		{
			Url = "https://api.vk.com/method/ads.getCampaigns";

			Json =
					@"{
                    ""response"": [{
                    ""id"": 1007993739,
                    ""type"": ""normal"",
                    ""name"": ""Студия Съёдиных кнопка"",
                    ""status"": 0,
                    ""day_limit"": ""0"",
                    ""all_limit"": ""0"",
                    ""start_time"": ""0"",
                    ""stop_time"": ""0"",
                    ""create_time"": ""1506536323"",
                    ""update_time"": ""1507465573""
                    }, {
                    ""id"": 1007993929,
                    ""type"": ""vk_apps_managed"",
                    ""name"": ""Студия универс"",
                    ""status"": 0,
                    ""day_limit"": ""0"",
                    ""all_limit"": ""0"",
                    ""start_time"": ""0"",
                    ""stop_time"": ""0"",
                    ""create_time"": ""1506538073"",
                    ""update_time"": ""1516726969""
                    }, {
                    ""id"": 1008001037,
                    ""type"": ""mobile_apps"",
                    ""name"": ""Студия Съединых узнаваемость"",
                    ""status"": 0,
                    ""day_limit"": ""0"",
                    ""all_limit"": ""0"",
                    ""start_time"": ""0"",
                    ""stop_time"": ""0"",
                    ""create_time"": ""1506634785"",
                    ""update_time"": ""1507465566""
                    }, {
                    ""id"": 1008003092,
                    ""type"": ""promoted_posts"",
                    ""name"": ""Студия Съединых карусель"",
                    ""status"": 0,
                    ""day_limit"": ""10000"",
                    ""all_limit"": ""200000"",
                    ""start_time"": ""1506886644"",
                    ""stop_time"": ""1506887799"",
                    ""create_time"": ""1506680535"",
                    ""update_time"": ""1516726968""
                    }, {
                    ""id"": 1008386575,
                    ""type"": ""promoted_posts"",
                    ""name"": ""Продвижение записей"",
                    ""status"": 0,
                    ""day_limit"": ""0"",
                    ""all_limit"": ""0"",
                    ""start_time"": ""0"",
                    ""stop_time"": ""0"",
                    ""create_time"": ""1512074538"",
                    ""update_time"": ""1516726968""
                    }, {
                    ""id"": 1008695393,
                    ""type"": ""promoted_posts"",
                    ""name"": ""GAUSS MEDIA"",
                    ""status"": 1,
                    ""day_limit"": ""0"",
                    ""all_limit"": ""0"",
                    ""start_time"": ""0"",
                    ""stop_time"": ""0"",
                    ""create_time"": ""1516726280"",
                    ""update_time"": ""1517647518""
                    }]
                }";

			var campaigns = Api.Ads.GetCampaigns(@params: new AdsGetCampaignsParams { AccountId = 1603879239 });

			Assert.That(actual: campaigns.Count, expression: Is.EqualTo(expected: 6));

			// ID кампании
			Assert.That(actual: campaigns[index: 3].Id, expression: Is.EqualTo(expected: 1008003092));

			// ID кампании
			Assert.That(actual: campaigns[index: 4].Name, expression: Is.EqualTo(expected: "Продвижение записей"));

			// Типы кампаний
			Assert.That(actual: campaigns[index: 0].Type, expression: Is.EqualTo(expected: CampaignType.Normal));
			Assert.That(actual: campaigns[index: 1].Type, expression: Is.EqualTo(expected: CampaignType.VkAppsManaged));
			Assert.That(actual: campaigns[index: 2].Type, expression: Is.EqualTo(expected: CampaignType.MobileApps));
			Assert.That(actual: campaigns[index: 3].Type, expression: Is.EqualTo(expected: CampaignType.PromotedPosts));

			// Лимиты
			Assert.That(actual: campaigns[index: 3].DayLimit, expression: Is.EqualTo(expected: 10000));
			Assert.That(actual: campaigns[index: 3].AllLimit, expression: Is.EqualTo(expected: 200000));

			// Даты
			Assert.That(actual: campaigns[index: 3].StartTime
					, expression: Is.EqualTo(expected: new DateTime(year: 2017, month: 10, day: 1, hour: 19, minute: 37, second: 24)));

			Assert.That(actual: campaigns[index: 3].StopTime
					, expression: Is.EqualTo(expected: new DateTime(year: 2017, month: 10, day: 1, hour: 19, minute: 56, second: 39)));

			Assert.That(actual: campaigns[index: 3].CreateTime
					, expression: Is.EqualTo(expected: new DateTime(year: 2017, month: 09, day: 29, hour: 10, minute: 22, second: 15)));

			Assert.That(actual: campaigns[index: 3].UpdateTime
					, expression: Is.EqualTo(expected: new DateTime(year: 2018, month: 01, day: 23, hour: 17, minute: 02, second: 48)));
		}

		[Test]
		public void GetAds_GenerateAdsCorrectly()
		{
			Url = "https://api.vk.com/method/ads.getAds";

			Json =
					@"{
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
						}, {
						""id"": ""42333973"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1526129474"",
						""update_time"": ""1528474634"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Ретаргет. Карусель"",
						""events_retargeting_groups"": {
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""18072"",
						""impressions_limit"": 1,
						""ad_platform"": ""all"",
						""ad_platform_no_wall"": 1,
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41999689"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1524899569"",
						""update_time"": ""1528273886"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""СЭТ из шаров (vk.com/wall-81751075_11025) (33к)"",
						""events_retargeting_groups"": {
						""26422269"": [1, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""12501"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41950350"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1524743667"",
						""update_time"": ""1526035464"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Опрос по своим подписчикам"",
						""events_retargeting_groups"": [],
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""8000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41921686"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1524662224"",
						""update_time"": ""1526036304"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Акция по шарам 25.04.2018 По всем отобранным аудиториям"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""3000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41921443"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1524661894"",
						""update_time"": ""1526036251"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Воздушные шары | Сюрприз51 | Мурманск шарики"",
						""events_retargeting_groups"": [],
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""5000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41907929"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1524641827"",
						""update_time"": ""1525812272"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Шары по конкурентам 25.04.2018"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""10000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41890092"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1524578786"",
						""update_time"": ""1527174062"",
						""day_limit"": ""0"",
						""all_limit"": ""3500"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Сэты из шаров (vk.com/wall-81751075_10995)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""3000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41820526"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1524385881"",
						""update_time"": ""1528273857"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Дет. сады,Ж, дети до 6 лет"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""8001"",
						""impressions_limit"": 2,
						""ad_platform"": ""all""
						}, {
						""id"": ""41757238"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1524154248"",
						""update_time"": ""1525812273"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Сэты №5"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""3000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41654214"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1523893893"",
						""update_time"": ""1525812273"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Цветы+шары по Ж"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""4500"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41648477"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1523884105"",
						""update_time"": ""1525812275"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Цветы+шарики по муж"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""6000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41646747"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1523881602"",
						""update_time"": ""1527174435"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Наша картинка цветы+шары"",
						""events_retargeting_groups"": [],
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""8000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41625892"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1523814289"",
						""update_time"": ""1527583808"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Укр. на свадьбу №1"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""6001"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41614224"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1523777579"",
						""update_time"": ""1527174519"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Шары + Цветы"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""8000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41601200"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1523704702"",
						""update_time"": ""1527699660"",
						""day_limit"": ""500"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Сэт из шаров №4 (vk.com/wall-81751075_10815)"",
						""events_retargeting_groups"": [],
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""21005"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41543152"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1523532961"",
						""update_time"": ""1528474618"",
						""day_limit"": ""500"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Сэт шары №3 (vk.com/wall-81751075_10802)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""23699"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41513372"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1523454458"",
						""update_time"": ""1528474616"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""сэт из шаров №2 (vk.com/wall-81751075_10797)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 21, 20],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""23699"",
						""impressions_limit"": 1,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41483649"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1523372752"",
						""update_time"": ""1528474595"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Сэты с шарами (vk.com/wall-81751075_10725) (33 000к)"",
						""events_retargeting_groups"": [],
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""22899"",
						""impressions_limit"": 3,
						""ad_platform"": ""all""
						}, {
						""id"": ""41476597"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1523362897"",
						""update_time"": ""1524917986"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Опрос Подписчицы свадебных групп из Мура"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""30000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all""
						}, {
						""id"": ""41448346"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1523285156"",
						""update_time"": ""1523371829"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Акция от 20180409"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""3000"",
						""impressions_limit"": 1,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41403764"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1523111177"",
						""update_time"": ""1528273917"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Ж от 20 по МО"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2700"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41403673"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1523110872"",
						""update_time"": ""1528273907"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Ж с детьми по МО"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2700"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41200671"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522511003"",
						""update_time"": ""1524916437"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""ДР в течении недели Клики"",
						""events_retargeting_groups"": [],
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2500"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41200656"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1522510912"",
						""update_time"": ""1527174193"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Женщины Мур Обл Клики"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2700"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41200625"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1522510788"",
						""update_time"": ""1527174196"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Кнопка Женщины Мур обл Клики"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2700"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41114956"",
						""campaign_id"": 1009150293,
						""status"": 0,
						""approved"": ""2"",
						""create_time"": ""1522247782"",
						""update_time"": ""1529052441"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Кнопка. Подписчики воздушных шаров. парс по 2 ( 2к ) Клик"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2700"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41114862"",
						""campaign_id"": 1009150293,
						""status"": 1,
						""approved"": ""2"",
						""create_time"": ""1522247617"",
						""update_time"": ""1529051497"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""291"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Карусель. конкуренты торты на заказ (6к)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""24099"",
						""impressions_limit"": 1,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41101709"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522226094"",
						""update_time"": ""1524916438"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Брат/Сестра. ДР у Ж (Сестры) Клики"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2500"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41101611"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522225936"",
						""update_time"": ""1524916438"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""ДР у Ж в течении недели Клики"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 0,
						""ad_format"": 9,
						""cpc"": ""2500"",
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41053271"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522075356"",
						""update_time"": ""1524917765"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Карусель. Пары именинников"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""10000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41053239"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522075299"",
						""update_time"": ""1524916439"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Брат/Сестра. ДР у М (Брата)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""20000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41053155"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522075238"",
						""update_time"": ""1524916439"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""ДР у Ж в течении недели"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""13000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41053122"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522075194"",
						""update_time"": ""1524917653"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Родители. ДР у Сына"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""30000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41053085"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522075133"",
						""update_time"": ""1524920136"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Карусель. Активные друзья. ДР у Ж показ Ж"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""15000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41052981"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522074978"",
						""update_time"": ""1524917764"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Брат/Сестра. ДР у Ж (Сестры)"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""25000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41052646"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522074488"",
						""update_time"": ""1524918075"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Активные друзья. ДР у Ж показ М"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""30000"",
						""impressions_limit"": 2,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41052542"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522074309"",
						""update_time"": ""1524917712"",
						""day_limit"": ""0"",
						""all_limit"": ""300"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Пары. ДР у М показ Ж"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""12000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}, {
						""id"": ""41052459"",
						""campaign_id"": 1009150293,
						""status"": 2,
						""approved"": ""2"",
						""create_time"": ""1522074190"",
						""update_time"": ""1524917653"",
						""day_limit"": ""0"",
						""all_limit"": ""0"",
						""start_time"": ""0"",
						""stop_time"": ""0"",
						""category1_id"": ""285"",
						""category2_id"": ""0"",
						""age_restriction"": ""0"",
						""name"": ""Родители. ДР у Дочери"",
						""events_retargeting_groups"": {
						""26422269"": [2, 20, 21],
						""26897268"": [5, 6]
						},
						""cost_type"": 1,
						""ad_format"": 9,
						""cpm"": ""17000"",
						""impressions_limit"": 3,
						""ad_platform"": ""all"",
						""ad_platform_no_ad_network"": 1
						}]
						}";

			var ads = Api.Ads.GetAds(@params: new AdsGetAdsParams () { AccountId = 1900013324, ClientId = 1604555949, CampaignIds = new List<long>() { 1009150293, 1009400691 } });

			Assert.That(actual: ads.Count, expression: Is.EqualTo(expected: 39));

			Assert.That(actual: ads[index: 38].Id, expression: Is.EqualTo(expected: 41052459));
			Assert.That(actual: ads[index: 38].CampaignId, expression: Is.EqualTo(expected: 1009150293));
			Assert.That(actual: ads[index: 38].Status, expression: Is.EqualTo(expected: AdStatus.Deleted));
			Assert.That(actual: ads[index: 38].ModerationStatus, expression: Is.EqualTo(expected: ModerationStatus.Approved));
			Assert.That(actual: ads[index: 38].AllLimit, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: ads[index: 38].Category1Id, expression: Is.EqualTo(expected: 285));
			Assert.That(actual: ads[index: 38].Category2Id, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: ads[index: 38].Name, expression: Is.EqualTo(expected: "Родители. ДР у Дочери"));
			Assert.That(actual: ads[index: 38].CostType, expression: Is.EqualTo(expected: CostType.CPM));
			Assert.That(actual: ads[index: 38].AdFormat, expression: Is.EqualTo(expected: AdFormat.Public));
			Assert.That(actual: ads[index: 38].CPM, expression: Is.EqualTo(expected: 17000));
			Assert.That(actual: ads[index: 38].ImpressionsLimit, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: ads[index: 38].AdPlatform, expression: Is.EqualTo(expected: AdPlatform.All));
			Assert.That(actual: ads[index: 0].AdPlatformNoAdNetwork, expression: Is.EqualTo(expected: true));
			Assert.That(actual: ads[index: 0].AdPPlatformNoWall, expression: Is.EqualTo(expected: true));
			Assert.That(actual: ads[index: 38].CreateTime, expression: Is.EqualTo(expected: new DateTime(2018, 3, 26, 14, 23, 10)));
			Assert.That(actual: ads[index: 38].UpdateTime, expression: Is.EqualTo(expected: new DateTime(2018, 4, 28, 12, 14, 13)));
			Assert.That(actual: ads[index: 16].DayLimit, expression: Is.EqualTo(expected: 500));
			Assert.That(actual: ads[index: 0].AgeRestriction, expression: Is.EqualTo(expected: AdAgeRestriction.EighteeenPlus));

		}
	}
}