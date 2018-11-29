using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Account
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AccountCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Account";

		[Ignore("")]
		[Test]
		public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.BanUser(42), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.banUser";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.BanUser(1), Is.False); // Нельзя просто так взять и забанить Дурова
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.banUser";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.BanUser(4), Is.True);
		}

		[Test]
		[Ignore("Будет переписываться")]
		public void BanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.BanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userId"));

			Assert.That(() => account.BanUser(0), Throws.InstanceOf<NullReferenceException>().And.Property("ParamName").EqualTo("userId"));

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Ignore("")]
		[Test]
		public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.GetBanned(), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetBanned_IncorrectParameters_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			Assert.That(() => account.GetBanned(-1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("offset"));

			Assert.That(() => account.GetBanned(count: -1),
				Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("count"));
		}

		[Test]
		public void GetBanned_WhenThereIsNoBannedUsers()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadJsonFile(JsonPaths.EmptyVkCollection);

			Assert.That(Api.Account.GetBanned(), Has.Count.EqualTo(0));
		}

		[Test]
		public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath(nameof(GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange));

			var result = Api.Account.GetBanned(50);
			Assert.That(result, Has.Count.EqualTo(0));
			Assert.That(result.TotalCount, Is.EqualTo(5));
		}

		[Test]
		public void GetBanned_WithCorrectCountParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath(nameof(GetBanned_WithCorrectCountParameter));

			var items = Api.Account.GetBanned(count: 2);

			Assert.That(items.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetBanned_WithCorrectOffsetParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath(nameof(GetBanned_WithCorrectOffsetParameter));

			var items = Api.Account.GetBanned(null, 10);
			Assert.That(items.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetBanned_WithDefaultParameters()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath(nameof(GetBanned_WithDefaultParameters));

			var items = Api.Account.GetBanned();
			Assert.That(items.TotalCount, Is.EqualTo(10));
			Assert.That(items, Has.Count.EqualTo(2));
			var banned = items.FirstOrDefault();
			Assert.That(banned, Is.Not.Null);
			Assert.That(banned.Id, Is.EqualTo(247704457));
			Assert.That(banned.FirstName, Is.EqualTo("Твой"));
			Assert.That(banned.LastName, Is.EqualTo("День-Рождения"));
			Assert.That(banned.Deactivated, Is.EqualTo(Deactivated.Banned));
		}

		[Test]
		public void GetCounters_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getCounters";
			ReadCategoryJsonPath(nameof(GetCounters_WhenServerReturnsAllFields));

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

		[Test]
		public void GetCounters_WhenServerReturnsEmptyResponse()
		{
			Url = "https://api.vk.com/method/account.getCounters";
			ReadJsonFile(JsonPaths.EmptyArray);

			var counters = Api.Account.GetCounters(CountersFilter.All);
			Assert.That(counters, Is.Null);
		}

		[Ignore("")]
		[Test]
		public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.GetInfo(), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetInfo_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getInfo";
			ReadCategoryJsonPath(nameof(GetInfo_WhenServerReturnsAllFields));

			var info = Api.Account.GetInfo();
			Assert.That(info, Is.Not.Null);

			Assert.That(info.Country, Is.EqualTo("RU"));
			Assert.That(info.HttpsRequired, Is.EqualTo(true));
			Assert.That(info.Intro, Is.EqualTo(10));
			Assert.That(info.Language, Is.EqualTo(0));
		}

		[Test]
		public void GetInfo_WhenServerReturnsEmptyResponse()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			Url = "https://api.vk.com/method/account.getInfo";
			ReadJsonFile(JsonPaths.EmptyObject);
			Assert.That(Api.Account.GetInfo(), Is.Null);
		}

		[Ignore("")]
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
			Url = "https://api.vk.com/method/account.getProfileInfo";
			ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnAllFields));

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

			Assert.That(info.Status,
				Is.EqualTo("♠ Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал."));

			Assert.That(info.Phone, Is.EqualTo("+7 *** *** ** 74"));
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnSomeFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo";

			ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnSomeFields));

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

		[Ignore("")]
		[Test]
		public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());

			Assert.Throws<AccessTokenInvalidException>(() => account.RegisterDevice(new AccountRegisterDeviceParams
			{
				Token = "tokenVal", DeviceModel = null, SystemVersion = null
			}));
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.False);

			Assert.That(Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal", DeviceModel = "deviceModelVal", SystemVersion = "systemVersionVal"
				}),
				Is.False);
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.True);

			Assert.That(Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal", DeviceModel = "deviceModelVal", SystemVersion = "systemVersionVal"
				}),
				Is.True);
		}

		[Test]
		public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			Assert.That(() => account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = null, DeviceModel = "example", SystemVersion = "example"
				}),
				Throws.InstanceOf<ArgumentNullException>());

			Assert.That(() => account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = string.Empty, DeviceModel = "example", SystemVersion = "example"
				}),
				Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.True);

			Assert.That(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal", DeviceModel = null, SystemVersion = null
				}),
				Throws.Nothing);

			Assert.That(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal", DeviceModel = string.Empty, SystemVersion = string.Empty
				}),
				Throws.Nothing);
		}

		[Test]
		public void SaveProfileInfo_AllParameters_UrlIsCreatedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";

			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

			Assert.That(() => Api.Account.SaveProfileInfo(out var _,
					new AccountSaveProfileInfoParams
					{
						FirstName = "fn", LastName = "ln", MaidenName = "mn", Sex = Sex.Female, Relation = RelationType.Married,
						RelationPartner = new User { Id = 10 },
						BirthDate = new DateTime(1984, 11, 15, 0, 0, 0, DateTimeKind.Utc).ToShortDateString(),
						BirthdayVisibility = BirthdayVisibility.Full, HomeTown = "ht", Country = new Country { Id = 1 },
						City = new City { Id = 2 }
					}),
				Is.True);
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_NegativeRequestId_ThrowArgumentException()
		{
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));
			Url = "";

			Assert.That(() => Api.Account.SaveProfileInfo(-10),
				Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("cancelRequestId"));
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_UrlIsGeneratedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));
			Assert.That(Api.Account.SaveProfileInfo(42), Is.True);
		}

		[Test]
		[Ignore("Падает на Linux")]

		// TODO Падает на Linux
		public void SaveProfileInfo_DateIsParsedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

			Assert.That(() => Api.Account.SaveProfileInfo(out var _,
					new AccountSaveProfileInfoParams
					{
						BirthDate = new DateTime(1984, 11, 150, 0, 0, 0, DateTimeKind.Utc)
							.ToShortDateString()
					}),
				Is.True);

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			Assert.That(() => Api.Account.SaveProfileInfo(out var _,
					new AccountSaveProfileInfoParams
					{
						BirthDate = new DateTime(2014, 9, 8, 0, 0, 0, DateTimeKind.Utc)
							.ToShortDateString()
					}),
				Is.True);
		}

		[Test]
		public void SaveProfileInfo_ResultWasParsedCorrectly_AndEmptyParametersIsProcessedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_False");

			Assert.That(Api.Account.SaveProfileInfo(out var request, new AccountSaveProfileInfoParams()), Is.False); // Second overload

			Assert.That(request, Is.Null);

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_Success");

			Assert.That(Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams()), Is.True); // Second overload

			Assert.That(request, Is.Not.Null);
			Assert.That(request.Status, Is.EqualTo(ChangeNameStatus.Success));
		}

		[Ignore("")]
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
			Url = "https://api.vk.com/method/account.setInfo";

			ReadJsonFile("Errors", "100");

			Assert.That(() => account.SetInfo("intro", "-10"), Throws.InstanceOf<ParameterMissingOrInvalidException>());
		}

		[Test]
		public void SetInfo_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.SetInfo("own_posts_default", "1"), Is.False);
		}

		[Test]
		public void SetInfo_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetInfo("own_posts_default", "1"), Is.True);
		}

		[Test]
		public void SetInfo_WithIntroParameter_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetInfo("intro", "10"), Is.True);
		}

		[Test]
		public void SetNameInMenu_EmptyName_ThrowArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => Api.Account.SetNameInMenu(string.Empty));
		}

		[Test]
		public void SetNameInMenu_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.SetNameInMenu("example"), Is.False);
		}

		[Test]
		public void SetNameInMenu_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetNameInMenu("example"), Is.True);
		}

		[Ignore("")]
		[Test]
		public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account =
				new AccountCategory(
					new VkApi()); // TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки

			Assert.Throws<AccessTokenInvalidException>(() => account.SetOffline());
		}

		[Test]
		public void SetOffline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.SetOffline(), Is.False);
		}

		[Test]
		public void SetOffline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetOffline(), Is.True);
		}

		[Ignore("")]
		[Test]
		public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => account.SetOnline());
		}

		[Test]
		public void SetOnline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.SetOnline(), Is.False);
		}

		[Test]
		public void SetOnline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetOnline(), Is.True);
		}

		[Test]
		public void SetOnline_WithVoipParameter()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.True);
			Assert.That(() => Api.Account.SetOnline(true), Is.True);
		}

		[Ignore("")]
		[Test]
		public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.SetSilenceMode("tokenVal"), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
		{
			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				ReadJsonFile(JsonPaths.False);
				Assert.That(() => Api.Account.SetSilenceMode("tokenVal", 10, 15, true), Is.False);
			}

			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				ReadJsonFile(JsonPaths.False);

				Assert.That(() => Api.Account.SetSilenceMode("tokenVal", -1, 10, false), Is.False);
			}
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
		public void SetSilenceMode_SetsCorrectly_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.SetSilenceMode("tokenVal"), Is.False);
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.SetSilenceMode("tokenVal"), Is.True);
		}

		[Ignore("")]
		[Test]
		public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.That(() => account.UnbanUser(42), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unbanUser";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.UnbanUser(1), Is.False);
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unbanUser";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.UnbanUser(4), Is.True);
		}

		[Test]
		[Ignore("Будет переписываться")]
		public void UnbanUser_IncorrectUserID_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			Assert.That(() => account.UnbanUser(-10), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("userId"));

			Assert.That(() => account.UnbanUser(0),
				Throws.InstanceOf<NullReferenceException>().And.Property("ParamName").EqualTo("userId"));

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Ignore("")]
		[Test]
		public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => account.UnregisterDevice("tokenVal"));
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			ReadJsonFile(JsonPaths.False);
			Assert.That(Api.Account.UnregisterDevice("tokenVal"), Is.False);
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			ReadJsonFile(JsonPaths.True);
			Assert.That(Api.Account.UnregisterDevice("tokenVal"), Is.True);
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
	}
}