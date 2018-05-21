using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class AdsCategoryTest : BaseTest
	{
		private AdsCategory _defaultAds;

		[SetUp]
		public void SetUp()
		{
            _defaultAds = new AdsCategory(new VkApi());
		}

		private AdsCategory GetMockedAdsCategory(string url, string json)
		{
            Json = json;
            Url = url;
            return new AdsCategory(Api);
		}


        #region Ads.GetAccounts

        [Test]
        public void GetAccounts_GenerateOutParametersCorrectly()
        {
            const string url = "https://api.vk.com/method/ads.getAccounts";
            const string json =
                @"{
                    'response': [{
                    'account_id': 1603879239,
                    'account_type': 'general',
                    'account_status': 1,
                    'account_name': 'Личный кабинет',
                    'access_role': 'admin'
                    }, {
                    'account_id': 1900013324,
                    'account_type': 'agency',
                    'account_status': 1,
                    'account_name': 'Кабинет агентства',
                    'access_role': 'manager'
                    }, {
                    'account_id': 1604369480,
                    'account_type': 'general',
                    'account_status': 1,
                    'account_name': 'Николай Петров',
                    'access_role': 'manager'
                    }]
                    }";

            var accounts = GetMockedAdsCategory(url, json).GetAccounts();

            Assert.That(accounts.Accounts.Count, Is.EqualTo(3));

            Assert.That(accounts.Accounts[1].AccountId, Is.EqualTo(1900013324));
            Assert.That(accounts.Accounts[1].AccountType, Is.EqualTo(AccountType.Agency));
            Assert.That(accounts.Accounts[1].AccountStatus, Is.EqualTo(AccountStatus.Active));
            Assert.That(accounts.Accounts[1].AccountName, Is.EqualTo("Кабинет агентства"));
            Assert.That(accounts.Accounts[1].AccessRole, Is.EqualTo(AccessRole.Manager));
        }

        #endregion  
    }
}