using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
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

			var campaigns = Api.Ads.GetCampaigns(1900013324, new List<long>
			{
				1009157560, 1009088099, 1009150293, 1009316667
			}, 1604555949, true);

			Assert.That(campaigns.Count, Is.EqualTo(4));

			// ID кампании
			Assert.That(campaigns[3].Id, Is.EqualTo(1009316667));
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