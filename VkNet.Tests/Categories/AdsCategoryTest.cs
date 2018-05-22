using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class AdsCategoryTest : BaseTest
	{
        #region Ads.GetAccounts

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

        #endregion  
    }
}