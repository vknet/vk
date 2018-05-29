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
		[Test]
		public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.BanUser(userId: 42), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.banUser";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.BanUser(userId: 1), expression: Is.False); // Нельзя просто так взять и забанить Дурова
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.banUser";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.BanUser(userId: 4), expression: Is.True);
		}

		[Test]
		[Ignore(reason: "Будет переписываться")]
		public void BanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(del: () => account.BanUser(userId: -10)
					, expr: Throws.InstanceOf<ArgumentException>().And.Property(name: "ParamName").EqualTo(expected: "userId"));

			Assert.That(del: () => account.BanUser(userId: 0)
					, expr: Throws.InstanceOf<NullReferenceException>().And.Property(name: "ParamName").EqualTo(expected: "userId"));

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.GetBanned(), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetBanned_IncorrectParameters_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			Assert.That(del: () => account.GetBanned(offset: -1)
					, expr: Throws.InstanceOf<ArgumentException>().And.Property(name: "ParamName").EqualTo(expected: "offset"));

			Assert.That(del: () => account.GetBanned(count: -1)
					, expr: Throws.InstanceOf<ArgumentException>().And.Property(name: "ParamName").EqualTo(expected: "count"));
		}

		[Test]
		public void GetBanned_WhenThereIsNoBannedUsers()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			Json = @"{
				'response': {
					count: 0,
					items: []
				}
			}";

			Assert.That(actual: Api.Account.GetBanned(), expression: Has.Count.EqualTo(expected: 0));
		}

		[Test]
		public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			Json = @"{
				'response': {
					count: 5,
					items: []
				}
			}";

			var result = Api.Account.GetBanned(offset: 50);
			Assert.That(actual: result, expression: Has.Count.EqualTo(expected: 0));
			Assert.That(actual: result.TotalCount, expression: Is.EqualTo(expected: 5));
		}

		[Test]
		public void GetBanned_WithCorrectCountParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

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

			var items = Api.Account.GetBanned(count: 2);

			Assert.That(actual: items.Count, expression: Is.EqualTo(expected: 2));
		}

		[Test]
		public void GetBanned_WithCorrectOffsetParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

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

			var items = Api.Account.GetBanned(offset: null, count: 10);
			Assert.That(actual: items.Count, expression: Is.EqualTo(expected: 2));
		}

		[Test]
		public void GetBanned_WithDefaultParameters()
		{
			Url = "https://api.vk.com/method/account.getBanned";

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

			var items = Api.Account.GetBanned();
			Assert.That(actual: items.TotalCount, expression: Is.EqualTo(expected: 10));
			Assert.That(actual: items, expression: Has.Count.EqualTo(expected: 2));
			var banned = items.FirstOrDefault();
			Assert.That(actual: banned, expression: Is.Not.Null);
			Assert.That(actual: banned.Id, expression: Is.EqualTo(expected: 247704457));
			Assert.That(actual: banned.FirstName, expression: Is.EqualTo(expected: "Твой"));
			Assert.That(actual: banned.LastName, expression: Is.EqualTo(expected: "День-Рождения"));
			Assert.That(actual: banned.Deactivated, expression: Is.EqualTo(expected: Deactivated.Banned));
		}

		[Test]
		public void GetCounters_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getCounters";

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

			var counters = Api.Account.GetCounters(filter: CountersFilter.All);
			Assert.That(actual: counters, expression: Is.Not.Null);

			Assert.That(actual: counters.Friends, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: counters.Messages, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: counters.Photos, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: counters.Videos, expression: Is.EqualTo(expected: 4));
			Assert.That(actual: counters.Notes, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: counters.Gifts, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: counters.Events, expression: Is.EqualTo(expected: 7));
			Assert.That(actual: counters.Groups, expression: Is.EqualTo(expected: 8));
			Assert.That(actual: counters.Notifications, expression: Is.EqualTo(expected: 9));
		}

		[Test]
		public void GetCounters_WhenServerReturnsEmptyResponse()
		{
			Url = "https://api.vk.com/method/account.getCounters";
			Json = @"{ 'response': [] }";

			var counters = Api.Account.GetCounters(filter: CountersFilter.All);
			Assert.That(actual: counters, expression: Is.Null);
		}

		[Test]
		public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.GetInfo(), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetInfo_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getInfo";

			Json = @"{
				'response': {
					country: 'RU',
					https_required: 1,
					intro: 10,
					lang: 0
				}
			}";

			var info = Api.Account.GetInfo();
			Assert.That(actual: info, expression: Is.Not.Null);

			Assert.That(actual: info.Country, expression: Is.EqualTo(expected: "RU"));
			Assert.That(actual: info.HttpsRequired, expression: Is.EqualTo(expected: true));
			Assert.That(actual: info.Intro, expression: Is.EqualTo(expected: 10));
			Assert.That(actual: info.Language, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetInfo_WhenServerReturnsEmptyResponse()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			Url = "https://api.vk.com/method/account.getInfo";
			Json = @"{ 'response': { } }";
			Assert.That(actual: Api.Account.GetInfo(), expression: Is.Null);
		}

		[Test]
		public void GetProfileInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.GetProfileInfo(), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnAllFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo";

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
			Assert.That(actual: info, expression: Is.Not.Null);

			Assert.That(actual: info.FirstName, expression: Is.EqualTo(expected: "Максим"));
			Assert.That(actual: info.LastName, expression: Is.EqualTo(expected: "Инютин"));
			Assert.That(actual: info.ScreenName, expression: Is.EqualTo(expected: "inyutin_maxim"));
			Assert.That(actual: info.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: info.Relation, expression: Is.EqualTo(expected: RelationType.InActiveSearch));
			Assert.That(actual: info.RelationPartner, expression: Is.Null);
			Assert.That(actual: info.BirthDate, expression: Is.EqualTo(expected: "15.1.1991"));
			Assert.That(actual: info.BirthdayVisibility, expression: Is.EqualTo(expected: BirthdayVisibility.Full));
			Assert.That(actual: info.HomeTown, expression: Is.EqualTo(expected: "Новочеркасск, Станица Кривянская"));
			Assert.That(actual: info.Country.Title, expression: Is.EqualTo(expected: "Россия"));
			Assert.That(actual: info.City.Title, expression: Is.EqualTo(expected: "Кривянская"));

			Assert.That(actual: info.Status
					, expression: Is.EqualTo(
							expected: "♠ Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал."));

			Assert.That(actual: info.Phone, expression: Is.EqualTo(expected: "+7 *** *** ** 74"));
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnSomeFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo";

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
			Assert.That(actual: info, expression: Is.Not.Null);

			Assert.That(actual: info.FirstName, expression: Is.EqualTo(expected: "Анна"));
			Assert.That(actual: info.LastName, expression: Is.EqualTo(expected: "Каренина"));
			Assert.That(actual: info.MaidenName, expression: Is.EqualTo(expected: "Облонская"));
			Assert.That(actual: info.Sex, expression: Is.EqualTo(expected: Sex.Female));
			Assert.That(actual: info.Relation, expression: Is.EqualTo(expected: RelationType.Engaged));
			Assert.That(actual: info.RelationPartner, expression: Is.Null);
			Assert.That(actual: info.BirthdayVisibility, expression: Is.EqualTo(expected: BirthdayVisibility.Invisible));
			Assert.That(actual: info.Country.Title, expression: Is.EqualTo(expected: "Российская империя"));
			Assert.That(actual: info.City.Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));
		}

		[Test]
		public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());

			Assert.Throws<AccessTokenInvalidException>(code: () => account.RegisterDevice(@params: new AccountRegisterDeviceParams
			{
					Token = "tokenVal"
					, DeviceModel = null
					, SystemVersion = null
			}));
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			Json = @"{ 'response': 0 }";

			Assert.That(actual: Api.Account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = "tokenVal"
							, DeviceModel = "deviceModelVal"
							, SystemVersion = "systemVersionVal"
					})
					, expression: Is.False);
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			Json = @"{ 'response': 1 }";

			Assert.That(actual: Api.Account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = "tokenVal"
							, DeviceModel = "deviceModelVal"
							, SystemVersion = "systemVersionVal"
					})
					, expression: Is.True);
		}

		[Test]
		public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			Assert.That(del: () => account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = null
							, DeviceModel = "example"
							, SystemVersion = "example"
					})
					, expr: Throws.InstanceOf<ArgumentNullException>());

			Assert.That(del: () => account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = string.Empty
							, DeviceModel = "example"
							, SystemVersion = "example"
					})
					, expr: Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			Json = @"{ 'response': 1 }";

			Assert.That(del: () => Api.Account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = "tokenVal"
							, DeviceModel = null
							, SystemVersion = null
					})
					, expr: Throws.Nothing);

			Assert.That(del: () => Api.Account.RegisterDevice(@params: new AccountRegisterDeviceParams
					{
							Token = "tokenVal"
							, DeviceModel = string.Empty
							, SystemVersion = string.Empty
					})
					, expr: Throws.Nothing);
		}

		[Test] // TODO Падает на Linux
		public void SaveProfileInfo_AllPArameters_UrlIsCreatedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";

			Json = @"{ 'response': { changed: 1 } }";

			Assert.That(del: () => Api.Account.SaveProfileInfo(changeNameRequest: out var _
							, @params: new AccountSaveProfileInfoParams
							{
									FirstName = "fn"
									, LastName = "ln"
									, MaidenName = "mn"
									, Sex = Sex.Female
									, Relation = RelationType.Married
									, RelationPartner = new User { Id = 10 }
									, BirthDate = new DateTime(year: 1984
											, month: 11
											, day: 15
											, hour: 0
											, minute: 0
											, second: 0
											, kind: DateTimeKind.Utc).ToShortDateString()
									, BirthdayVisibility = BirthdayVisibility.Full
									, HomeTown = "ht"
									, Country = new Country { Id = 1 }
									, City = new City { Id = 2 }
							})
					, expr: Is.True);
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_NegativeRequestId_ThrowArgumentException()
		{
			Json = "";
			Url = "";

			Assert.That(del: () => Api.Account.SaveProfileInfo(cancelRequestId: -10)
					, expr: Throws.InstanceOf<ArgumentException>().And.Property(name: "ParamName").EqualTo(expected: "cancelRequestId"));
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_UrlIsGeneratedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			Json = @"{ 'response': { changed: 1 } }";
			Assert.That(actual: Api.Account.SaveProfileInfo(cancelRequestId: 42), expression: Is.True);
		}

		[Test]
		[Ignore(reason: "Падает на Linux")] // TODO Падает на Linux
		public void SaveProfileInfo_DateIsParsedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			Json = @"{ 'response': { changed: 1 } }";

			Assert.That(del: () => Api.Account.SaveProfileInfo(changeNameRequest: out var _
							, @params: new AccountSaveProfileInfoParams
							{
									BirthDate = new DateTime(year: 1984
													, month: 11
													, day: 150
													, hour: 0
													, minute: 0
													, second: 0
													, kind: DateTimeKind.Utc)
											.ToShortDateString()
							})
					, expr: Is.True);

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			Assert.That(del: () => Api.Account.SaveProfileInfo(changeNameRequest: out var _
							, @params: new AccountSaveProfileInfoParams
							{
									BirthDate = new DateTime(year: 2014
													, month: 9
													, day: 8
													, hour: 0
													, minute: 0
													, second: 0
													, kind: DateTimeKind.Utc)
											.ToShortDateString()
							})
					, expr: Is.True);
		}

		[Test]
		public void SaveProfileInfo_ResultWasParsedCorrectly_AndEmptyParametersIsProcessedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			Json = @"{ 'response': { changed: 0 } }";

			Assert.That(actual: Api.Account.SaveProfileInfo(changeNameRequest: out var request, @params: new AccountSaveProfileInfoParams())
					, expression: Is.False); //Second overload

			Assert.That(actual: request, expression: Is.Null);

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			Json = @"{
				'response':{
					changed: 1,
					name_request: {
						status: 'success'
					}
				}
			}";

			Assert.That(actual: Api.Account.SaveProfileInfo(changeNameRequest: out request, @params: new AccountSaveProfileInfoParams())
					, expression: Is.True); //Second overload

			Assert.That(actual: request, expression: Is.Not.Null);
			Assert.That(actual: request.Status, expression: Is.EqualTo(expected: ChangeNameStatus.Success));
		}

		[Test]
		public void SetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.SetInfo(name: "intro", value: "10"), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetInfo_IncorrectUserID_ThrowInvalidParameterException()
		{
			var account = new AccountCategory(vk: Api);
			Url = "https://api.vk.com/method/account.setInfo";

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

			Assert.That(del: () => account.SetInfo(name: "intro", value: "-10")
					, expr: Throws.InstanceOf<ParameterMissingOrInvalidException>());
		}

		[Test]
		public void SetInfo_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.SetInfo(name: "own_posts_default", value: "1"), expression: Is.False);
		}

		[Test]
		public void SetInfo_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetInfo(name: "own_posts_default", value: "1"), expression: Is.True);
		}

		[Test]
		public void SetInfo_WithIntroParameter_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetInfo(name: "intro", value: "10"), expression: Is.True);
		}

		[Test]
		public void SetNameInMenu_EmptyName_ThrowArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(code: () => Api.Account.SetNameInMenu(name: string.Empty));
		}

		[Test]
		public void SetNameInMenu_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.SetNameInMenu(name: "example"), expression: Is.False);
		}

		[Test]
		public void SetNameInMenu_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetNameInMenu(name: "example"), expression: Is.True);
		}

		[Test]
		public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account =
					new AccountCategory(
							vk: new VkApi()); // TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки

			Assert.Throws<AccessTokenInvalidException>(code: () => account.SetOffline());
		}

		[Test]
		public void SetOffline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.SetOffline(), expression: Is.False);
		}

		[Test]
		public void SetOffline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetOffline(), expression: Is.True);
		}

		[Test]
		public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.Throws<AccessTokenInvalidException>(code: () => account.SetOnline());
		}

		[Test]
		public void SetOnline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.SetOnline(), expression: Is.False);
		}

		[Test]
		public void SetOnline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetOnline(), expression: Is.True);
		}

		[Test]
		public void SetOnline_WithVoipParameter()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			Json = @"{ 'response': 1 }";
			Assert.That(del: () => Api.Account.SetOnline(voip: true), expr: Is.True);
		}

		[Test]
		public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.SetSilenceMode(deviceId: "tokenVal"), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
		{
			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				Json = @"{ 'response': 0 }";
				Assert.That(del: () => Api.Account.SetSilenceMode(deviceId: "tokenVal", time: 10, peerId: 15, sound: true), expr: Is.False);
			}

			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				Json = @"{ 'response': 0 }";

				Assert.That(del: () => Api.Account.SetSilenceMode(deviceId: "tokenVal", time: -1, peerId: 10, sound: false)
						, expr: Is.False);
			}
		}

		[Test]
		public void SetSilenceMode_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(del: () => account.SetSilenceMode(deviceId: null), expr: Throws.InstanceOf<ArgumentNullException>());
			Assert.That(del: () => account.SetSilenceMode(deviceId: string.Empty), expr: Throws.InstanceOf<ArgumentNullException>());

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.SetSilenceMode(deviceId: "tokenVal"), expression: Is.False);
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.SetSilenceMode(deviceId: "tokenVal"), expression: Is.True);
		}

		[Test]
		public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.That(del: () => account.UnbanUser(userId: 42), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unbanUser";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.UnbanUser(userId: 1), expression: Is.False);
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unbanUser";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.UnbanUser(userId: 4), expression: Is.True);
		}

		[Test]
		[Ignore(reason: "Будет переписываться")]
		public void UnbanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(del: () => account.UnbanUser(userId: -10)
					, expr: Throws.InstanceOf<ArgumentException>().And.Property(name: "ParamName").EqualTo(expected: "userId"));

			Assert.That(del: () => account.UnbanUser(userId: 0)
					, expr: Throws.InstanceOf<NullReferenceException>().And.Property(name: "ParamName").EqualTo(expected: "userId"));

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: new VkApi());
			Assert.Throws<AccessTokenInvalidException>(code: () => account.UnregisterDevice(deviceId: "tokenVal"));
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			Json = @"{ 'response': 0 }";
			Assert.That(actual: Api.Account.UnregisterDevice(deviceId: "tokenVal"), expression: Is.False);
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			Json = @"{ 'response': 1 }";
			Assert.That(actual: Api.Account.UnregisterDevice(deviceId: "tokenVal"), expression: Is.True);
		}

		[Test]
		public void UnregisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(vk: Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(del: () => account.UnregisterDevice(deviceId: null), expr: Throws.InstanceOf<ArgumentNullException>());
			Assert.That(del: () => account.UnregisterDevice(deviceId: string.Empty), expr: Throws.InstanceOf<ArgumentNullException>());

			// ReSharper restore AssignNullToNotNullAttribute
		}
	}
}