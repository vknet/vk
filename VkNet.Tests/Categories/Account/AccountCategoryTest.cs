using System;
using System.Linq;
using FluentAssertions;
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
	public class AccountCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Account";

		[Test]
		public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.BanUser(42)).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.ban";
			ReadJsonFile(JsonPaths.False);
			Api.Account.BanUser(1).Should().BeFalse(); // Нельзя просто так взять и забанить Дурова
		}

		[Test]
		public void BanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.ban";
			ReadJsonFile(JsonPaths.True);
			Api.Account.BanUser(4).Should().BeTrue();
		}

		[Test]
		public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			//
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.GetBanned()).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void GetBanned_IncorrectParameters_ThrowArgumentException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			FluentActions.Invoking(() => account.GetBanned(-1))
				.Should()
				.ThrowExactly<ArgumentException>()
				.And.ParamName.Should()
				.Be("offset");

			FluentActions.Invoking(() => account.GetBanned(count: -1))
				.Should()
				.ThrowExactly<ArgumentException>()
				.And.ParamName.Should()
				.Be("count");
		}

		[Test]
		public void GetBanned_WhenThereIsNoBannedUsers()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadJsonFile(JsonPaths.EmptyVkCollection);

			Api.Account.GetBanned().Should().Be(0);
		}

		[Test]
		public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath(nameof(GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange));

			var result = Api.Account.GetBanned(50);
			result.Count.Should().Be(5);
		}

		[Test]
		public void GetBanned_WithCorrectCountParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath("GetBannedResult");

			var items = Api.Account.GetBanned(count: 2);

			items.Count.Should().Be(2);
		}

		[Test]
		public void GetBanned_WithCorrectOffsetParameter()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath("GetBannedResult");

			var items = Api.Account.GetBanned(null, 2);
			items.Count.Should().Be(2);
		}

		[Test]
		public void GetBanned_WithDefaultParameters()
		{
			Url = "https://api.vk.com/method/account.getBanned";

			ReadCategoryJsonPath("GetBannedResult");

			var items = Api.Account.GetBanned();
			items.Count.Should().Be(2);
			var banned = items.Items.FirstOrDefault();
			banned.Should().Be(256477844);
		}

		[Test]
		public void GetCounters_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getCounters";
			ReadCategoryJsonPath(nameof(GetCounters_WhenServerReturnsAllFields));

			var counters = Api.Account.GetCounters(CountersFilter.All);
			counters.Should().NotBeNull();

			counters.Friends.Should().Be(1);
			counters.Messages.Should().Be(2);
			counters.Photos.Should().Be(3);
			counters.Videos.Should().Be(4);
			counters.Notes.Should().Be(5);
			counters.Gifts.Should().Be(6);
			counters.Events.Should().Be(7);
			counters.Groups.Should().Be(8);
			counters.Notifications.Should().Be(9);
		}

		[Test]
		public void GetCounters_WhenServerReturnsEmptyResponse()
		{
			Url = "https://api.vk.com/method/account.getCounters";
			ReadJsonFile(JsonPaths.EmptyArray);

			var counters = Api.Account.GetCounters(CountersFilter.All);
			counters.Should().BeNull();
		}

		[Test]
		public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.GetInfo()).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void GetInfo_WhenServerReturnsAllFields()
		{
			Url = "https://api.vk.com/method/account.getInfo";
			ReadCategoryJsonPath(nameof(GetInfo_WhenServerReturnsAllFields));

			var info = Api.Account.GetInfo();
			info.Should().NotBeNull();

			info.Country.Should().Be("RU");
			info.HttpsRequired.Should().Be(true);
			info.Intro.Should().Be(10);
			info.Language.Should().Be(0);
		}

		[Test]
		public void GetInfo_WhenServerReturnsEmptyResponse()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			Url = "https://api.vk.com/method/account.getInfo";
			ReadJsonFile(JsonPaths.EmptyObject);
			Api.Account.GetInfo().Should().BeNull();
		}

		[Test]
		public void GetPrivacySettings()
		{
			// Arrange
			Url = "https://api.vk.com/method/account.getPrivacySettings";
			ReadCategoryJsonPath(nameof(GetPrivacySettings));

			// Act
			var settings = Api.Account.GetPrivacySettings();

			// Assert
			settings.Should().NotBeNull();
			settings.Sections.Should().NotBeEmpty();
			settings.Settings.Should().NotBeEmpty();
			settings.SupportedCategories.Should().NotBeEmpty();
		}

		[Test]
		public void GetProfileInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.GetProfileInfo()).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnAllFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo";
			ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnAllFields));

			var info = Api.Account.GetProfileInfo();
			info.Should().NotBeNull();

			info.FirstName.Should().Be("Максим");
			info.LastName.Should().Be("Инютин");
			info.ScreenName.Should().Be("inyutin_maxim");
			info.Sex.Should().Be(Sex.Male);
			info.Relation.Should().Be(RelationType.InActiveSearch);
			info.RelationPartner.Should().BeNull();
			info.BirthDate.Should().Be("15.1.1991");
			info.BirthdayVisibility.Should().Be(BirthdayVisibility.Full);
			info.HomeTown.Should().Be("Новочеркасск, Станица Кривянская");
			info.Country.Title.Should().Be("Россия");
			info.City.Title.Should().Be("Кривянская");

			info.Status.Should().Be("♠ Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал.");

			info.Phone.Should().Be("+7 *** *** ** 74");
		}

		[Test]
		public void GetProfileInfo_WhenServerReturnSomeFields()
		{
			Url = "https://api.vk.com/method/account.getProfileInfo";

			ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnSomeFields));

			var info = Api.Account.GetProfileInfo();
			info.Should().NotBeNull();

			info.FirstName.Should().Be("Анна");
			info.LastName.Should().Be("Каренина");
			info.MaidenName.Should().Be("Облонская");
			info.Sex.Should().Be(Sex.Female);
			info.Relation.Should().Be(RelationType.Engaged);
			info.RelationPartner.Should().BeNull();
			info.BirthdayVisibility.Should().Be(BirthdayVisibility.Invisible);
			info.Country.Title.Should().Be("Российская империя");
			info.City.Title.Should().Be("Санкт-Петербург");
		}

		[Test]
		public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());

			FluentActions.Invoking(() => account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal",
					DeviceModel = null,
					SystemVersion = null
				}))
				.Should()
				.ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.False);

			Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal",
					DeviceModel = "deviceModelVal",
					SystemVersion = "systemVersionVal"
				})
				.Should()
				.BeFalse();
		}

		[Test]
		public void RegisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.True);

			Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal",
					DeviceModel = "deviceModelVal",
					SystemVersion = "systemVersionVal"
				})
				.Should()
				.BeTrue();
		}

		[Test]
		public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			FluentActions.Invoking(() => account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = null,
					DeviceModel = "example",
					SystemVersion = "example"
				}))
				.Should()
				.ThrowExactly<ArgumentNullException>();

			FluentActions.Invoking(() => account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = string.Empty,
					DeviceModel = "example",
					SystemVersion = "example"
				}))
				.Should()
				.ThrowExactly<ArgumentNullException>();
		}

		[Test]
		public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
		{
			Url = "https://api.vk.com/method/account.registerDevice";
			ReadJsonFile(JsonPaths.True);

			FluentActions.Invoking(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal",
					DeviceModel = null,
					SystemVersion = null
				}))
				.Should()
				.NotThrow();

			FluentActions.Invoking(() => Api.Account.RegisterDevice(new AccountRegisterDeviceParams
				{
					Token = "tokenVal",
					DeviceModel = string.Empty,
					SystemVersion = string.Empty
				}))
				.Should()
				.NotThrow();
		}

		[Test]
		public void SaveProfileInfo_AllParameters_UrlIsCreatedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";

			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

			var result = Api.Account.SaveProfileInfo(out var _,
				new AccountSaveProfileInfoParams
				{
					FirstName = "fn",
					LastName = "ln",
					MaidenName = "mn",
					Sex = Sex.Female,
					Relation = RelationType.Married,
					RelationPartner = new User
					{
						Id = 10
					},
					BirthDate = new DateTime(1984,
						11,
						15,
						0,
						0,
						0,
						DateTimeKind.Utc).ToShortDateString(),
					BirthdayVisibility = BirthdayVisibility.Full,
					HomeTown = "ht",
					Country = new Country
					{
						Id = 1
					},
					City = new City
					{
						Id = 2
					}
				});

			result.Should().BeTrue();
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_NegativeRequestId_ThrowArgumentException()
		{
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));
			Url = "";

			FluentActions.Invoking(() => Api.Account.SaveProfileInfo(-10))
				.Should()
				.ThrowExactly<ArgumentException>()
				.And.ParamName.Should()
				.Be("cancelRequestId");
		}

		[Test]
		public void SaveProfileInfo_CancelChangeNameRequest_UrlIsGeneratedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));
			Api.Account.SaveProfileInfo(42).Should().BeTrue();
		}

		[Test]
		public void SaveProfileInfo_DateIsParsedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

			var result1 = Api.Account.SaveProfileInfo(out var _,
				new AccountSaveProfileInfoParams
				{
					BirthDate = new DateTime(1984,
							11,
							15,
							0,
							0,
							0,
							DateTimeKind.Utc)
						.ToShortDateString()
				});

			result1.Should().BeTrue();

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			var result = Api.Account.SaveProfileInfo(out var _,
				new AccountSaveProfileInfoParams
				{
					BirthDate = new DateTime(2014,
							9,
							8,
							0,
							0,
							0,
							DateTimeKind.Utc)
						.ToShortDateString()
				});

			result.Should().BeTrue();
		}

		[Test]
		public void SaveProfileInfo_ResultWasParsedCorrectly_AndEmptyParametersIsProcessedCorrectly()
		{
			Url = "https://api.vk.com/method/account.saveProfileInfo";
			ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_False");

			Api.Account.SaveProfileInfo(out var request, new AccountSaveProfileInfoParams()).Should().BeFalse(); // Second overload

			request.Should().BeNull();

			Url = "https://api.vk.com/method/account.saveProfileInfo";

			ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_Success");

			Api.Account.SaveProfileInfo(out request, new AccountSaveProfileInfoParams()).Should().BeTrue(); // Second overload

			request.Should().NotBeNull();
			request.Status.Should().Be(ChangeNameStatus.Success);
		}

		[Test]
		public void SetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.SetInfo("intro", "10")).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void SetInfo_IncorrectUserID_ThrowInvalidParameterException()
		{
			var account = new AccountCategory(Api);
			Url = "https://api.vk.com/method/account.setInfo";

			ReadErrorsJsonFile(100);

			FluentActions.Invoking(() => account.SetInfo("intro", "-10")).Should().ThrowExactly<ParameterMissingOrInvalidException>();
		}

		[Test]
		public void SetInfo_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.False);
			Api.Account.SetInfo("own_posts_default", "1").Should().BeFalse();
		}

		[Test]
		public void SetInfo_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetInfo("own_posts_default", "1").Should().BeTrue();
		}

		[Test]
		public void SetInfo_WithIntroParameter_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setInfo";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetInfo("intro", "10").Should().BeTrue();
		}

		[Test]
		public void SetNameInMenu_EmptyName_ThrowArgumentNullException()
		{
			FluentActions.Invoking(() => Api.Account.SetNameInMenu(string.Empty, 1)).Should().ThrowExactly<ArgumentNullException>();
		}

		[Test]
		public void SetNameInMenu_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			ReadJsonFile(JsonPaths.False);
			Api.Account.SetNameInMenu("example", 1).Should().BeFalse();
		}

		[Test]
		public void SetNameInMenu_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setNameInMenu";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetNameInMenu("example", 1).Should().BeTrue();
		}

		[Test]
		public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var account =
				new AccountCategory(
					new VkApi()); // TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки

			FluentActions.Invoking(() => account.SetOffline()).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void SetOffline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			ReadJsonFile(JsonPaths.False);
			Api.Account.SetOffline().Should().BeFalse();
		}

		[Test]
		public void SetOffline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOffline";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetOffline().Should().BeTrue();
		}

		[Test]
		public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.SetOnline()).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void SetOnline_NotSets_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.False);
			Api.Account.SetOnline().Should().BeFalse();
		}

		[Test]
		public void SetOnline_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetOnline().Should().BeTrue();
		}

		[Test]
		public void SetOnline_WithVoipParameter()
		{
			Url = "https://api.vk.com/method/account.setOnline";
			ReadJsonFile(JsonPaths.True);
			var result = Api.Account.SetOnline(true);
			result.Should().BeTrue();
		}

		[Test]
		public void SetPrivacy()
		{
			// Arrange
			Url = "https://api.vk.com/method/account.setPrivacy";
			ReadCategoryJsonPath(nameof(SetPrivacy));

			// Act
			var result = Api.Account.SetPrivacy("key", "only_me");

			// Assert
			result.Should().NotBeNull();
			result.Category.Should().Be("only_me");
		}

		[Test]
		public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.SetSilenceMode("tokenVal")).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
		{
			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				ReadJsonFile(JsonPaths.False);
				var result = Api.Account.SetSilenceMode("tokenVal", 10, 15, true);
				result.Should().BeFalse();
			}

			{
				Url = "https://api.vk.com/method/account.setSilenceMode";
				ReadJsonFile(JsonPaths.False);
				var result = Api.Account.SetSilenceMode("tokenVal", -1, 10, false);
				result.Should().BeFalse();
			}
		}

		[Test]
		public void SetSilenceMode_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			FluentActions.Invoking(() => account.SetSilenceMode(null)).Should().ThrowExactly<ArgumentNullException>();
			FluentActions.Invoking(() => account.SetSilenceMode(string.Empty)).Should().ThrowExactly<ArgumentNullException>();

			// ReSharper restore AssignNullToNotNullAttribute
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.False);
			Api.Account.SetSilenceMode("tokenVal").Should().BeFalse();
		}

		[Test]
		public void SetSilenceMode_SetsCorrectly_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.True);
			Api.Account.SetSilenceMode("tokenVal").Should().BeTrue();
		}

		[Test]
		public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.UnbanUser(42)).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unban";
			ReadJsonFile(JsonPaths.False);
			Api.Account.UnbanUser(1).Should().BeFalse();
		}

		[Test]
		public void UnbanUser_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unban";
			ReadJsonFile(JsonPaths.True);
			Api.Account.UnbanUser(4).Should().BeTrue();
		}

		[Test]
		public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(new VkApi());
			FluentActions.Invoking(() => account.UnregisterDevice("tokenVal")).Should().ThrowExactly<AccessTokenInvalidException>();
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnFalse()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			ReadJsonFile(JsonPaths.False);
			Api.Account.UnregisterDevice("tokenVal").Should().BeFalse();
		}

		[Test]
		public void UnregisterDevice_CorrectParameters_ReturnTrue()
		{
			Url = "https://api.vk.com/method/account.unregisterDevice";
			ReadJsonFile(JsonPaths.True);
			Api.Account.UnregisterDevice("tokenVal").Should().BeTrue();
		}

		[Test]
		public void UnregisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var account = new AccountCategory(Api);

			// ReSharper disable AssignNullToNotNullAttribute
			FluentActions.Invoking(() => account.UnregisterDevice(null)).Should().ThrowExactly<ArgumentNullException>();
			FluentActions.Invoking(() => account.UnregisterDevice(string.Empty)).Should().ThrowExactly<ArgumentNullException>();

			// ReSharper restore AssignNullToNotNullAttribute
		}
	}
}