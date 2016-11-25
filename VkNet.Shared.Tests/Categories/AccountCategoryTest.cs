using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class AccountCategoryTest : BaseTest
	{
		#region GetCounters

		[Test]
		public void GetCounters_WhenServerReturnsEmptyResponse()
		{
			Url = "https://api.vk.com/method/account.getCounters?filter=friends,messages,photos,videos,notes,gifts,events,groups,notifications&v=" + VkApi.VkApiVersion + "&access_token=token";
            Json = @"{ 'response': [] }";

			var counters = Api.Account.GetCounters(CountersFilter.All);
			Assert.That(counters, Is.Null);
		}

		[Test]
		public void GetCounters_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getCounters?filter=friends,messages,photos,videos,notes,gifts,events,groups,notifications&v=" + VkApi.VkApiVersion + "&access_token=token";
            Json = @"{
				'response': {
					friends:1,
					messages: 2,
					photos: 3,
					videos: 4,
					notes: 5,
					gifts: 6,
					events: 7,
					groups: 8,
					notifications: 9
				}
			}";

			var counters = Api.Account.GetCounters(CountersFilter.All);
			Assert.That(counters, Is.Not.Null);

			Assert.That(counters.Friends, Is.EqualTo(1));
			Assert.That(counters.Messages, Is.EqualTo(2));
			Assert.That(counters.Photos, Is.EqualTo(3));
			Assert.That(counters.Videos, Is.EqualTo(4));
			Assert.That(counters.Notes, Is.EqualTo(5));
			Assert.That(counters.Gifts, Is.EqualTo(6));
			Assert.That(counters.Events, Is.EqualTo(7));
			Assert.That(counters.Groups, Is.EqualTo(8));
			Assert.That(counters.Notifications, Is.EqualTo(9));
		}

		#endregion

		#region SetNameInMenu

		[Test]
		public void SetNameInMenu_EmptyName_ThrowArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => Api.Account.SetNameInMenu(null));
			Assert.Throws<ArgumentNullException>(() => Api.Account.SetNameInMenu(string.Empty));
		}

		[Test]
		public void SetNameInMenu_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu?name=example&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetNameInMenu("example"), Is.True);
		}

		[Test]
		public void SetNameInMenu_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu?name=example&v=" + VkApi.VkApiVersion + "&access_token=token";
            Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.SetNameInMenu("example"), Is.False);
		}

		#endregion

		#region SetOnline

		[Test]
		public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => account.SetOnline());
		}

		[Test]
		public void SetOnline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOnline?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetOnline(), Is.True);
		}

		[Test]
		public void SetOnline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOnline?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.SetOnline(), Is.False);
		}

		[Test]
		public void SetOnline_WithVoipParameter()
		{
			Url = "https://api.vk.com/method/account.setOnline?voip=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(() => Api.Account.SetOnline(true), Is.True);
		}

		#endregion

		#region SetOffline

		[Test]
		public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			Assert.Throws<AccessTokenInvalidException>(() => account.SetOffline());
		}

		[Test]
		public void SetOffline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOffline?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetOffline(), Is.True);
		}

		[Test]
		public void SetOffline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOffline?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.SetOffline(), Is.False);
		}

		#endregion

		#region RegisterDevice

		[Test]
		public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal",
				DeviceModel = null,
				SystemVersion = null
			}));
		}

		[Test]
		public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);
			Assert.That(() => account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = null,
				DeviceModel = "example",
				SystemVersion = "example"
			}), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = string.Empty,
				DeviceModel = "example",
				SystemVersion = "example"
			}), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal",
				DeviceModel = "deviceModelVal",
				SystemVersion = "systemVersionVal"
			}), Is.True);
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&device_model=deviceModelVal&system_version=systemVersionVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal",
				DeviceModel = "deviceModelVal",
				SystemVersion = "systemVersionVal"
			}), Is.False);
		}

		[Test]
		public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
		{
			Url = "https://api.vk.com/method/account.registerDevice?token=tokenVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal",
				DeviceModel = null,
				SystemVersion = null,

			}), Throws.Nothing);
			Assert.That(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal",
				DeviceModel = string.Empty,
				SystemVersion = string.Empty
			}), Throws.Nothing);
		}

		#endregion

		#region UnregisterDevice

		[Test]
		public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => account.UnregisterDevice("tokenVal"));
		}

		[Test]
		public void UnregisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.UnregisterDevice(null), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.UnregisterDevice(string.Empty), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice?device_id=tokenVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.UnregisterDevice("tokenVal"), Is.True);
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice?device_id=tokenVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.UnregisterDevice("tokenVal"), Is.False);
		}

		#endregion

		#region SetSilenceMode

		[Test]
		public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			//This.Action(() => account.SetSilenceMode("tokenVal")).Throws<AccessTokenInvalidException>();
			Assert.That(() => account.SetSilenceMode("tokenVal"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetSilenceMode_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.SetSilenceMode(null), Throws.InstanceOf<ArgumentNullException>());
			Assert.That(() => account.SetSilenceMode(string.Empty), Throws.InstanceOf<ArgumentNullException>());
			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode?device_id=tokenVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetSilenceMode("tokenVal"), Is.True);
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode?device_id=tokenVal&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.SetSilenceMode("tokenVal"), Is.False);
		}

		[Test]
		public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
		{
			{
				Url = "https://api.vk.com/method/account.setSilenceMode?device_id=tokenVal&time=10&peer_id=15&sound=1&v=" + VkApi.VkApiVersion + "&access_token=token";
				Json = @"{ 'response': 0 }";
				Assert.That(() => Api.Account.SetSilenceMode("tokenVal", 10, 15, true), Is.False);
			}

			{
				Url = "https://api.vk.com/method/account.setSilenceMode?device_id=tokenVal&time=-1&peer_id=10&v=" + VkApi.VkApiVersion + "&access_token=token";
				Json = @"{ 'response': 0 }";
				Assert.That(() => Api.Account.SetSilenceMode("tokenVal", -1, 10, false), Is.False);
			}
		}

		#endregion

		#region BanUser

		[Test]
		public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.BanUser(42), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test, Ignore("Будет переписываться")]
		public void BanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.BanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userId"));
			Assert.That(() => account.BanUser(0), Throws.InstanceOf<NullReferenceException>().And.Property("ParamName").EqualTo("userId"));
			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.banUser?user_id=4&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.BanUser(4), Is.True);
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.banUser?user_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.BanUser(1), Is.False); // Нельзя просто так взять и забанить Дурова
		}

		#endregion

		#region UnbanUser

		[Test]
		public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.UnbanUser(42), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test, Ignore("Будет переписываться")]
		public void UnbanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.UnbanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userId"));
			Assert.That(() => account.UnbanUser(0), Throws.InstanceOf<NullReferenceException>().And.Property("ParamName").EqualTo("userId"));
			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unbanUser?user_id=4&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.UnbanUser(4), Is.True);
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unbanUser?user_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.UnbanUser(1), Is.False);
		}

		#endregion

		#region GetBanned

		[Test]
		public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			int res;
			Assert.That(() => account.GetBanned(out res), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetBanned_IncorrectParameters_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			int buf;
			Assert.That(() => account.GetBanned(out buf, offset: -1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("offset"));
			Assert.That(() => account.GetBanned(out buf, count: -1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("count"));

		}

		[Test]
		public void GetBanned_WithDefaultParameters()
		{
			Url = "https://api.vk.com/method/account.getBanned?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
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
				}
			}";

			int total;
			var items = Api.Account.GetBanned(out total);
			Assert.That(total, Is.EqualTo(10));
			Assert.That(items, Has.Count.EqualTo(2));
			var banned = items.FirstOrDefault();
			Assert.That(banned, Is.Not.Null);
			Assert.That(banned.Id, Is.EqualTo(247704457));
			Assert.That(banned.FirstName, Is.EqualTo("Твой"));
			Assert.That(banned.LastName, Is.EqualTo("День-Рождения"));
			Assert.That(banned.Deactivated, Is.EqualTo(Deactivated.Banned));
		}

		[Test]
		public void GetBanned_WithCorrectCountParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned?count=2&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
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
				}
			}";
			int total;
			var items = Api.Account.GetBanned(out total, count: 2);

			Assert.That(items.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetBanned_WithCorrectOffsetParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned?offset=10&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
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
				}
			}";

			int total;
			var items = Api.Account.GetBanned(out total, 10);
			Assert.That(items.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetBanned_WhenThereIsNoBannedUsers()
		{
			Url = "https://api.vk.com/method/account.getBanned?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
					count: 0,
					items: []
				}
			}";

			int total;
			Assert.That(Api.Account.GetBanned(out total), Has.Count.EqualTo(0));
			Assert.That(total, Is.EqualTo(0));
		}

		[Test]
		public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
		{
			Url = "https://api.vk.com/method/account.getBanned?offset=50&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
					count: 5,
					items: []
				}
			}";

			int total;
			Assert.That(Api.Account.GetBanned(out total, offset: 50), Has.Count.EqualTo(0));
			Assert.That(total, Is.EqualTo(5));
		}

		#endregion

		#region GetInfo

		[Test]
		public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.GetInfo(), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetInfo_WhenServerReturnsEmptyResponse()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			Url = "https://api.vk.com/method/account.getInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': { } }";
			Assert.That(Api.Account.GetInfo(), Is.Null);
		}

		[Test]
		public void GetInfo_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
					country: 'RU',
					https_required: 1,
					intro: 10,
					lang: 0
				}
			}";

			var info = Api.Account.GetInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.Country, Is.EqualTo("RU"));
			Assert.That(info.HttpsRequired, Is.EqualTo(true));
			Assert.That(info.Intro, Is.EqualTo(10));
			Assert.That(info.Language, Is.EqualTo(0));
		}

		#endregion

		#region SetInfo

		[Test]
		public void SetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.SetInfo("intro", "10"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetInfo_IncorrectUserID_ThrowInvalidParameterException()
		{
			var account = new AccountCategory(Api);
			Url = "https://api.vk.com/method/account.setInfo?name=intro&value=-10&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				error: {
					error_code: 100,
					error_msg: 'One of the parameters specified was missing or invalid: value should be positive',
					request_params: [{
						key: 'oauth',
						value: '1'
					}, {
						key: 'method',
						value: 'account.setInfo'
					}, {
						key: 'name',
						value: 'intro'
					}, {
						key: 'v',
						value: '5.50'
					}, {
						key: 'value',
						value: '-10'
					}]
				}
			}";
			Assert.That(() => account.SetInfo("intro", "-10"), Throws.InstanceOf<InvalidParameterException>());
		}

		[Test]
		public void SetInfo_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setInfo?name=own_posts_default&value=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetInfo("own_posts_default", "1"), Is.True);
		}

		[Test]
		public void SetInfo_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo?name=own_posts_default&value=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 0 }";
			Assert.That(Api.Account.SetInfo("own_posts_default", "1"), Is.False);
		}

		[Test]
		public void SetInfo_WithIntroParameter_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo?name=intro&value=10&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': 1 }";
			Assert.That(Api.Account.SetInfo("intro", "10"), Is.True);
		}

		#endregion

		#region GetProfileInfo

		[Test]
		public void GetProfileInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.GetProfileInfo(), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnAllFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: {
					first_name: 'Максим',
					last_name: 'Инютин',
					screen_name: 'inyutin_maxim',
					sex: 2,
					relation: 6,
					bdate: '15.1.1991',
					bdate_visibility: 1,
					home_town: 'Новочеркасск, Станица Кривянская',
					country: {
						id: 1,
						title: 'Россия'
					},
					city: {
						id: 1079336,
						title: 'Кривянская'
					},
					status: '&#9824; Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал.',
					phone: '+7 *** *** ** 74'
				}
			}";

			var info = Api.Account.GetProfileInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.FirstName, Is.EqualTo("Максим"));
			Assert.That(info.LastName, Is.EqualTo("Инютин"));
			Assert.That(info.ScreenName, Is.EqualTo("inyutin_maxim"));
			Assert.That(info.Sex, Is.EqualTo(Sex.Male));
			Assert.That(info.Relation, Is.EqualTo(RelationType.InActiveSearch));
			Assert.That(info.RelationPartner, Is.Null);
			Assert.That(info.BirthDate, Is.EqualTo("15.1.1991"));
			Assert.That(info.BirthdayVisibility, Is.EqualTo(BirthdayVisibility.Full));
			Assert.That(info.HomeTown, Is.EqualTo("Новочеркасск, Станица Кривянская"));
			Assert.That(info.Country.Title, Is.EqualTo("Россия"));
			Assert.That(info.City.Title, Is.EqualTo("Кривянская"));
			Assert.That(info.Status, Is.EqualTo("♠ Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал."));
			Assert.That(info.Phone, Is.EqualTo("+7 *** *** ** 74"));
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnSomeFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response': {
					first_name: 'Анна',
					last_name: 'Каренина',
					maiden_name: 'Облонская',
					sex: 1,
					relation: 3,
					bdate_visibility: 0,
					country: {
						id: 1,
						title: 'Российская империя'
					},
					city: {
						id: 2,
						title: 'Санкт-Петербург'
					}
				}
			}";
			var info = Api.Account.GetProfileInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.FirstName, Is.EqualTo("Анна"));
			Assert.That(info.LastName, Is.EqualTo("Каренина"));
			Assert.That(info.MaidenName, Is.EqualTo("Облонская"));
			Assert.That(info.Sex, Is.EqualTo(Sex.Female));
			Assert.That(info.Relation, Is.EqualTo(RelationType.Engaged));
			Assert.That(info.RelationPartner, Is.Null);
			Assert.That(info.BirthdayVisibility, Is.EqualTo(BirthdayVisibility.Invisible));
			Assert.That(info.Country.Title, Is.EqualTo("Российская империя"));
			Assert.That(info.City.Title, Is.EqualTo("Санкт-Петербург"));
		}

		#endregion

		#region SaveProfileInfo

		[Test, Ignore("Устаревший метод")]
		public void SaveProfileInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account = new AccountCategory(new VkApi());
			ChangeNameRequest request;
			Assert.That(() => account.SaveProfileInfo(firstName: null), Throws.InstanceOf<AccessTokenInvalidException>());
			Assert.That(() => account.SaveProfileInfo(out request), Throws.InstanceOf<AccessTokenInvalidException>());
			Assert.That(() => account.SaveProfileInfo(10), Throws.InstanceOf<AccessTokenInvalidException>());

		}

		[Test]
		public void SaveProfileInfo_ResultWasParsedCorrectly_AndEmptyParametersIsProcessedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': { changed: 0 } }";
			ChangeNameRequest request;
			Assert.That(Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams()), Is.False);    //Second overload
			Assert.That(request, Is.Null);

			Url = "https://api.vk.com/method/account.saveProfileInfo?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				'response':{
					changed: 1,
					name_request: {
						status: 'success'
					}
				}
			}";

			Assert.That(Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams()), Is.True);     //Second overload
			Assert.That(request, Is.Not.Null);
			Assert.That(request.Status, Is.EqualTo(ChangeNameStatus.Success));
		}

        [Test, Ignore("Падает на Linux")] // TODO Падает на Linux
		public void SaveProfileInfo_AllPArameters_UrlIsCreatedCorrectly()
		{
			Url =
				"https://api.vk.com/method/account.saveProfileInfo?first_name=fn&last_name=ln&maiden_name=mn&sex=1&relation=4&relation_partner_id=10" +
				"&bdate=15.11.1984&bdate_visibility=1&home_town=ht&country_id=1&city_id=2&v=" + VkApi.VkApiVersion + "&access_token=token";

			Json = @"{ 'response': { changed: 1 } }";

			ChangeNameRequest request;
			Assert.That(() => Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams
			{
				FirstName = "fn",
				LastName = "ln",
				MaidenName = "mn",
				Sex = Sex.Female,
				Relation = RelationType.Married,
				RelationPartner = new User { Id = 10 },
				BirthDate = new DateTime(1984, 11, 15).ToShortDateString(),
				BirthdayVisibility = BirthdayVisibility.Full,
				HomeTown = "ht",
				Country = new Country { Id = 1 },
				City = new City { Id = 2 }
			}),
			Is.True);
		}

		[Test, Ignore("Падает на Linux")] // TODO Падает на Linux
		public void SaveProfileInfo_DateIsParsedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo?bdate=15.11.1984&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': { changed: 1 } }";

			ChangeNameRequest request;
			Assert.That(() => Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams
			{
				BirthDate = new DateTime(1984, 11, 15).ToShortDateString()
			}),
			Is.True);
			Url = "https://api.vk.com/method/account.saveProfileInfo?bdate=08.09.2014&v=" + VkApi.VkApiVersion + "&access_token=token";
			Assert.That(() => Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams
			{
				BirthDate = new DateTime(2014, 9, 8).ToShortDateString()
			}),
			Is.True);

		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_NegativeRequestId_ThrowArgumentException()
		{
			Json = "";
			Url = "";
			Assert.That(() => Api.Account.SaveProfileInfo(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("cancelRequestId"));
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_UrlIsGeneratedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo?cancel_request_id=42&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{ 'response': { changed: 1 } }";
			Assert.That(Api.Account.SaveProfileInfo(42), Is.True);
		}

		#endregion
	}
}