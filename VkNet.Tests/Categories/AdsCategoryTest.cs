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
	}
}