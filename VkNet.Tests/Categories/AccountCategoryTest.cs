using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class AccountCategoryTest
	{
		private AccountCategory GetMockedAccountCategory(string url, string json, string version = "5.9")
		{
			return GetMockedAccountCategoryAndMockOfBrowser(url, json, version).Item1;
		}

		private Tuple<AccountCategory, Mock<IBrowser>> GetMockedAccountCategoryAndMockOfBrowser(string url, string json, string version = "5.9")
		{
			var mock = new Mock<IBrowser>(MockBehavior.Strict);
			mock.Setup(m => m.GetJson(url)).Returns(json);
			return new Tuple<AccountCategory, Mock<IBrowser>>(
				new AccountCategory(new VkApi { AccessToken = "token", Browser = mock.Object, ApiVersion = version })
				, mock);
		}


		#region SetNameInMenu

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void SetNameInMenu_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.SetNameInMenu("name");
		}

		[Test]
		public void SetNameInMenu_EmptyName_ThrowArgumentNullException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.SetNameInMenu(null), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.SetNameInMenu(string.Empty), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void SetNameInMenu_SetsCorrectly_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.setNameInMenu?name=example&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetNameInMenu("example"), Is.True);
		}

		[Test]
		public void SetNameInMenu_NotSets_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setNameInMenu?name=example&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetNameInMenu("example"), Is.False);
		}

		#endregion

		#region SetOnline

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.SetOnline();
		}

		[Test]
		public void SetOnline_SetsCorrectly_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.setOnline?access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetOnline(), Is.True);
		}

		[Test]
		public void SetOnline_NotSets_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setOnline?access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetOnline(), Is.False);
		}

		[Test]
		public void SetOnline_WithVoipParameter()
		{
			const string url = "https://api.vk.com/method/account.setOnline?voip=1&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			account.Item1.SetOnline(true);
			account.Item2.VerifyAll();
		}

		#endregion

		#region SetOffline

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.SetOffline();
		}

		[Test]
		public void SetOffline_SetsCorrectly_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.setOffline?access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetOffline(), Is.True);
		}

		[Test]
		public void SetOffline_NotSets_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setOffline?access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetOffline(), Is.False);
		}

		#endregion

		#region RegisterDevice

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.RegisterDevice("tokenVal", null, null);
		}

		[Test]
		public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			var mock = new Mock<IBrowser>(MockBehavior.Strict);
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.RegisterDevice(null, "example", "example"), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.RegisterDevice(string.Empty, "example", "example"), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void RegisterDevice_CorrectParameters_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.RegisterDevice("tokenVal", "deviceModelVal", "systemVersionVal"), Is.True);
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.RegisterDevice("tokenVal", "deviceModelVal", "systemVersionVal"), Is.False);
		}

		[Test]
		public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
		{
			const string url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(() => account.RegisterDevice("tokenVal", null, null, null, null), Throws.Nothing);
			Assert.That(() => account.RegisterDevice("tokenVal", string.Empty, string.Empty, null, null), Throws.Nothing);
		}

		[Test]
		public void RegisterDevice_ExplicitNoTextAndSomeSubscribes_ParametersAddsToUrlCorrectly()
		{
			const string url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&no_text=1&subscribe=msg,friend,call&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			account.Item1.RegisterDevice("tokenVal", "deviceModelVal", "systemVersionVal", true,
									SubscribeFilter.Message | SubscribeFilter.Friend | SubscribeFilter.Call);
			account.Item2.VerifyAll();
		}

		[Test]
		public void RegisterDevice_ExplicitNoTextAndAllSubscribes_ParametersAddsToUrlCorrectly()
		{
			const string url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&no_text=1&subscribe=msg,friend,call,reply,mention,group,like&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			account.Item1.RegisterDevice("tokenVal", "deviceModelVal", "systemVersionVal", true, SubscribeFilter.All);
			account.Item2.VerifyAll();
		}

		#endregion

		#region UnregisterDevice

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.UnregisterDevice("tokenVal");
		}

		[Test]
		public void UnregisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			var mock = new Mock<IBrowser>(MockBehavior.Strict);
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.UnregisterDevice(null), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.UnregisterDevice(string.Empty), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.unregisterDevice?token=tokenVal&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.UnregisterDevice("tokenVal"), Is.True);
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.unregisterDevice?token=tokenVal&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.UnregisterDevice("tokenVal"), Is.False);


		}

		#endregion

		#region SetSilenceMode

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.SetSilenceMode("tokenVal");
		}

		[Test]
		public void SetSilenceMode_NullOrEmptyToken_ThrowArgumentNullException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.SetSilenceMode(null), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.SetSilenceMode(string.Empty), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.setSilenceMode?token=tokenVal&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetSilenceMode("tokenVal"), Is.True);
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setSilenceMode?token=tokenVal&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetSilenceMode("tokenVal"), Is.False);
		}

		[Test]
		public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
		{
			{
				const string url = "https://api.vk.com/method/account.setSilenceMode?token=tokenVal&time=10&chat_id=15&user_id=42&sound=1&access_token=token";
				const string json = @"{ 'response': 0 }";
				var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

				account.Item1.SetSilenceMode("tokenVal", 10, 15, 42, true);
				account.Item2.VerifyAll();
			}

			{
				const string url = "https://api.vk.com/method/account.setSilenceMode?token=tokenVal&time=-1&user_id=10&sound=0&access_token=token";
				const string json = @"{ 'response': 0 }";
				var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

				account.Item1.SetSilenceMode("tokenVal", -1, userID: 10, sound:false);
				account.Item2.VerifyAll();
			}


		}

		#endregion

		#region BanUser

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.BanUser(42);
		}

		[Test]
		public void BanUser_IncorrectUserID_ThrowArgumentException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.BanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userID"));
			Assert.That(() => account.BanUser(0), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userID"));
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void BanUser_CorrectParameters_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.banUser?user_id=4&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.BanUser(4), Is.True); // 
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.banUser?user_id=1&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.BanUser(1), Is.False); // Нельзя просто так взять и забанить Дурова
		}

		#endregion

		#region UnbanUser

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.UnbanUser(42);
		}

		[Test]
		public void UnbanUser_IncorrectUserID_ThrowArgumentException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.UnbanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userID"));
			Assert.That(() => account.UnbanUser(0), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userID"));
			// ReSharper restore AssignNullToNotNullAttribute
		}


		[Test]
		public void UnbanUser_CorrectParameters_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.unbanUser?user_id=4&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.UnbanUser(4), Is.True); 
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.unbanUser?user_id=1&access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.UnbanUser(1), Is.False);
		}

		#endregion

		#region GetBanned

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			int res;
			account.GetBanned(out res);
		}

		[Test]
		public void GetBanned_IncorrectParameters_ThrowArgumentException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			int buf;
			Assert.That(() => account.GetBanned(out buf, offset: -1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("offset"));
			Assert.That(() => account.GetBanned(out buf, count: -1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("count"));
			
		}


		[Test]
		public void GetBanned_WithDefaultParameters()
		{
			const string url = "https://api.vk.com/method/account.getBanned?access_token=token";
			const string json = @"{ 'response': {
									count: 10,
									items: [{
									id: 247704457,
									first_name: 'Твой',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}, {
									id: 205041002,
									first_name: 'Ваш',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}]
									}}";
			var account = GetMockedAccountCategory(url, json);

			int total;
			var items = account.GetBanned(out total);
			Assert.That(total, Is.EqualTo(10));
			Assert.That(items, Has.Count.EqualTo(2));
			Assert.That(items.First().Id, Is.EqualTo(247704457));
			Assert.That(items.First().FirstName, Is.EqualTo("Твой"));
			Assert.That(items.First().LastName, Is.EqualTo("День-Рождения"));
			Assert.That(items.First().DeactiveReason, Is.EqualTo("banned"));
		}

		[Test]
		public void GetBanned_WithCorrectCountParameter()
		{
			const string url = "https://api.vk.com/method/account.getBanned?count=2&access_token=token";
			const string json = @"{ 'response': {
									count: 10,
									items: [{
									id: 247704457,
									first_name: 'Твой',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}, {
									id: 205041002,
									first_name: 'Ваш',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}]
									}}";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);
			
			int total;
			account.Item1.GetBanned(out total, count: 2);
			account.Item2.VerifyAll();
		}

		[Test]
		public void GetBanned_WithCorrectOffsetParameter()
		{
			const string url = "https://api.vk.com/method/account.getBanned?offset=10&access_token=token";
			const string json = @"{ 'response': {
									count: 10,
									items: [{
									id: 247704457,
									first_name: 'Твой',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}, {
									id: 205041002,
									first_name: 'Ваш',
									last_name: 'День-Рождения',
									deactivated: 'banned'
									}]
									}}";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			int total;
			account.Item1.GetBanned(out total, offset: 10);
			account.Item2.VerifyAll();
		}

		[Test]
		public void GetBanned_WhenThereIsNoBannedUsers()
		{
			const string url = "https://api.vk.com/method/account.getBanned?access_token=token";
			const string json = @"{ 'response': {
									count: 0,
									items: []
									}}";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			int total;
			Assert.That(account.Item1.GetBanned(out total), Has.Count.EqualTo(0));
			Assert.That(total, Is.EqualTo(0));
		}

		[Test]
		public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
		{
			const string url = "https://api.vk.com/method/account.getBanned?offset=50&access_token=token";
			const string json = @"{ 'response': {
									count: 5,
									items: []
									}}";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			int total;
			Assert.That(account.Item1.GetBanned(out total, offset: 50), Has.Count.EqualTo(0));
			Assert.That(total, Is.EqualTo(5));
		}

		#endregion

		#region GetInfo

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			// ReSharper disable AssignNullToNotNullAttribute
			account.GetInfo();
			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void GetInfo_WhenServerReturnsEmptyResponse()
		{
			const string url = "https://api.vk.com/method/account.getInfo?access_token=token";
			const string json = @"{ 'response': { } }";
			var account = GetMockedAccountCategory(url, json);

			var info = account.GetInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.Country,		Is.Null);
			Assert.That(info.HttpsRequired, Is.Null);
			Assert.That(info.Intro,			Is.Null);
			Assert.That(info.Language,		Is.Null);
		}

		[Test]
		public void GetInfo_WhenServerReturnsAllFields()
		{
			const string url = "https://api.vk.com/method/account.getInfo?access_token=token";
			const string json = @"{ 'response': {
										country: 'RU',
										https_required: 1,
										intro: 10,
										lang: 0
										}}";
			var account = GetMockedAccountCategory(url, json);

			var info = account.GetInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.Country, Is.EqualTo("RU"));
			Assert.That(info.HttpsRequired, Is.EqualTo(true));
			Assert.That(info.Intro, Is.EqualTo(10));
			Assert.That(info.Language, Is.EqualTo(0));
		}

		#endregion

		#region SetInfo

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void SetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			account.SetInfo(10);
		}

		[Test]
		public void SetInfo_IncorrectUserID_ThrowArgumentException()
		{
			var account = new AccountCategory(new VkApi { AccessToken = "token", Browser = null });

			Assert.That(() => account.SetInfo(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("intro"));
		}

		[Test]
		public void SetInfo_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/account.setInfo?access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetInfo(), Is.True);
		}

		[Test]
		public void SetInfo_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setInfo?access_token=token";
			const string json = @"{ 'response': 0 }";
			var account = GetMockedAccountCategory(url, json);

			Assert.That(account.SetInfo(), Is.False);
		}

		[Test]
		public void SetInfo_WithIntroParameter_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/account.setInfo?intro=10&access_token=token";
			const string json = @"{ 'response': 1 }";
			var account = GetMockedAccountCategoryAndMockOfBrowser(url, json);

			account.Item1.SetInfo(10);
			account.Item2.VerifyAll();
		}

		#endregion

	}

}