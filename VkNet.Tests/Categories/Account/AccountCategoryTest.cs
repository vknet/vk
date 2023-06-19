using System;
using System.Linq;
using FluentAssertions;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Account;

public class AccountCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Account";

	[Fact]
	public void BanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.BanUser(42))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void BanUser_CorrectParameters_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.ban";
		ReadJsonFile(JsonPaths.False);

		Api.Account.BanUser(1)
			.Should()
			.BeFalse(); // Нельзя просто так взять и забанить Дурова
	}

	[Fact]
	public void BanUser_CorrectParameters_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.ban";
		ReadJsonFile(JsonPaths.True);

		Api.Account.BanUser(4)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void GetBanned_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		//
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.GetBanned())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
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

	[Fact]
	public void GetBanned_WhenThereIsNoBannedUsers()
	{
		Url = "https://api.vk.com/method/account.getBanned";

		ReadJsonFile(JsonPaths.EmptyVkCollection);

		var result = Api.Account.GetBanned();

		result.Count.Should().Be(0);
	}

	[Fact]
	public void GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange()
	{
		Url = "https://api.vk.com/method/account.getBanned";

		ReadCategoryJsonPath(nameof(GetBanned_WhenThereIsSomeBannedUsersButNotInTheOffsetRange));

		var result = Api.Account.GetBanned(50);

		result.Count.Should()
			.Be(5);
	}

	[Fact]
	public void GetBanned_WithCorrectCountParameter()
	{
		Url = "https://api.vk.com/method/account.getBanned";

		ReadCategoryJsonPath("GetBannedResult");

		var items = Api.Account.GetBanned(count: 2);

		items.Count.Should()
			.Be(2);
	}

	[Fact]
	public void GetBanned_WithCorrectOffsetParameter()
	{
		Url = "https://api.vk.com/method/account.getBanned";

		ReadCategoryJsonPath("GetBannedResult");

		var items = Api.Account.GetBanned(null, 2);

		items.Count.Should()
			.Be(2);
	}

	[Fact]
	public void GetBanned_WithDefaultParameters()
	{
		Url = "https://api.vk.com/method/account.getBanned";

		ReadCategoryJsonPath("GetBannedResult");

		var items = Api.Account.GetBanned();

		items.Count.Should()
			.Be(2);

		var banned = items.Items.FirstOrDefault();

		banned.Should()
			.Be(256477844);
	}

	[Fact]
	public void GetCounters_WhenServerReturnsAllFields()
	{
		Url = "https://api.vk.com/method/account.getCounters";
		ReadCategoryJsonPath(nameof(GetCounters_WhenServerReturnsAllFields));

		var counters = Api.Account.GetCounters(CountersFilter.All);

		counters.Should()
			.NotBeNull();

		counters.Friends.Should()
			.Be(1);

		counters.Messages.Should()
			.Be(2);

		counters.Photos.Should()
			.Be(3);

		counters.Videos.Should()
			.Be(4);

		counters.Notes.Should()
			.Be(5);

		counters.Gifts.Should()
			.Be(6);

		counters.Events.Should()
			.Be(7);

		counters.Groups.Should()
			.Be(8);

		counters.Notifications.Should()
			.Be(9);
	}

	[Fact]
	public void GetCounters_WhenServerReturnsEmptyResponse()
	{
		Url = "https://api.vk.com/method/account.getCounters";
		ReadJsonFile(JsonPaths.EmptyObject);

		var counters = Api.Account.GetCounters(CountersFilter.All);

		counters.Events.Should()
			.BeNull();
		counters.Albums.Should()
			.BeNull();
		counters.Groups.Should()
			.BeNull();
		counters.Gifts.Should()
			.BeNull();
		counters.Audios.Should()
			.BeNull();
		counters.Followers.Should()
			.BeNull();
		counters.UserPhotos.Should()
			.BeNull();
		counters.UserVideos.Should()
			.BeNull();
	}

	[Fact]
	public void GetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.GetInfo())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetInfo_WhenServerReturnsAllFields()
	{
		Url = "https://api.vk.com/method/account.getInfo";
		ReadCategoryJsonPath(nameof(GetInfo_WhenServerReturnsAllFields));

		var info = Api.Account.GetInfo();

		info.Should()
			.NotBeNull();

		info.Country.Should()
			.Be("RU");

		info.HttpsRequired.Should()
			.BeTrue();

		info.Intro.Should()
			.Be(10);

		info.Language.Should()
			.Be(0);
	}

	[Fact]
	public void GetPrivacySettings()
	{
		// Arrange
		Url = "https://api.vk.com/method/account.getPrivacySettings";
		ReadCategoryJsonPath(nameof(GetPrivacySettings));

		// Act
		var settings = Api.Account.GetPrivacySettings();

		// Assert
		settings.Should()
			.NotBeNull();

		settings.Sections.Should()
			.NotBeEmpty();

		settings.Settings.Should()
			.NotBeEmpty();

		settings.SupportedCategories.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetProfileInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.GetProfileInfo())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetProfileInfo_WhenServerReturnAllFields()
	{
		Url = "https://api.vk.com/method/account.getProfileInfo";
		ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnAllFields));

		var info = Api.Account.GetProfileInfo();

		info.Should()
			.NotBeNull();

		info.FirstName.Should()
			.Be("Максим");

		info.LastName.Should()
			.Be("Инютин");

		info.ScreenName.Should()
			.Be("inyutin_maxim");

		info.Sex.Should()
			.Be(Sex.Male);

		info.Relation.Should()
			.Be(RelationType.InActiveSearch);

		info.RelationPartner.Should()
			.BeNull();

		info.BirthDate.Should()
			.Be("15.1.1991");

		info.BirthdayVisibility.Should()
			.Be(BirthdayVisibility.Full);

		info.HomeTown.Should()
			.Be("Новочеркасск, Станица Кривянская");

		info.Country.Title.Should()
			.Be("Россия");

		info.City.Title.Should()
			.Be("Кривянская");

		info.Status.Should()
			.Be("&#9824; Во мне нет ничего первоначального. Я — совместное усилие всех тех, кого я когда-то знал.");

		info.Phone.Should()
			.Be("+7 *** *** ** 74");
	}

	[Fact]
	public void GetProfileInfo_WhenServerReturnSomeFields()
	{
		Url = "https://api.vk.com/method/account.getProfileInfo";

		ReadCategoryJsonPath(nameof(GetProfileInfo_WhenServerReturnSomeFields));

		var info = Api.Account.GetProfileInfo();

		info.Should()
			.NotBeNull();

		info.FirstName.Should()
			.Be("Анна");

		info.LastName.Should()
			.Be("Каренина");

		info.MaidenName.Should()
			.Be("Облонская");

		info.Sex.Should()
			.Be(Sex.Female);

		info.Relation.Should()
			.Be(RelationType.Engaged);

		info.RelationPartner.Should()
			.BeNull();

		info.BirthdayVisibility.Should()
			.Be(BirthdayVisibility.Invisible);

		info.Country.Title.Should()
			.Be("Российская империя");

		info.City.Title.Should()
			.Be("Санкт-Петербург");
	}

	[Fact]
	public void RegisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.RegisterDevice(new()
			{
				Token = "tokenVal",
				DeviceModel = null,
				SystemVersion = null
			}))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void RegisterDevice_CorrectParameters_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.registerDevice";
		ReadJsonFile(JsonPaths.False);

		Api.Account.RegisterDevice(new()
			{
				Token = "tokenVal",
				DeviceModel = "deviceModelVal",
				SystemVersion = "systemVersionVal"
			})
			.Should()
			.BeFalse();
	}

	[Fact]
	public void RegisterDevice_CorrectParameters_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.registerDevice";
		ReadJsonFile(JsonPaths.True);

		Api.Account.RegisterDevice(new()
			{
				Token = "tokenVal",
				DeviceModel = "deviceModelVal",
				SystemVersion = "systemVersionVal"
			})
			.Should()
			.BeTrue();
	}

	[Fact]
	public void RegisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(Api);

		FluentActions.Invoking(() => account.RegisterDevice(new()
			{
				Token = null,
				DeviceModel = "example",
				SystemVersion = "example"
			}))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		FluentActions.Invoking(() => account.RegisterDevice(new()
			{
				Token = string.Empty,
				DeviceModel = "example",
				SystemVersion = "example"
			}))
			.Should()
			.ThrowExactly<ArgumentNullException>();
	}

	[Fact]
	public void RegisterDevice_ParametersAreEqualsToNullOrEmptyExceptToken_NotThrowsException()
	{
		Url = "https://api.vk.com/method/account.registerDevice";
		ReadJsonFile(JsonPaths.True);

		FluentActions.Invoking(() => Api.Account.RegisterDevice(new()
			{
				Token = "tokenVal",
				DeviceModel = null,
				SystemVersion = null
			}))
			.Should()
			.NotThrow();

		FluentActions.Invoking(() => Api.Account.RegisterDevice(new()
			{
				Token = "tokenVal",
				DeviceModel = string.Empty,
				SystemVersion = string.Empty
			}))
			.Should()
			.NotThrow();
	}

	[Fact]
	public void SaveProfileInfo_AllParameters_UrlIsCreatedCorrectly()
	{
		Url = "https://api.vk.com/method/account.saveProfileInfo";

		ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

		var result = Api.Account.SaveProfileInfo(
			new AccountSaveProfileInfoParams
			{
				FirstName = "fn",
				LastName = "ln",
				MaidenName = "mn",
				Sex = Sex.Female,
				Relation = RelationType.Married,
				RelationPartner = new()
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
				Country = new()
				{
					Id = 1
				},
				City = new()
				{
					Id = 2
				}
			});

		result.Changed.Should()
			.BeTrue();
	}

	[Fact]
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

	[Fact]
	public void SaveProfileInfo_CancelChangeNameRequest_UrlIsGeneratedCorrectly()
	{
		Url = "https://api.vk.com/method/account.saveProfileInfo";
		ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

		Api.Account.SaveProfileInfo(42)
			.Changed.Should()
			.BeTrue();
	}

	[Fact]
	public void SaveProfileInfo_DateIsParsedCorrectly()
	{
		Url = "https://api.vk.com/method/account.saveProfileInfo";
		ReadCategoryJsonPath(nameof(Api.Account.SaveProfileInfo));

		var result1 = Api.Account.SaveProfileInfo(
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

		result1.Changed.Should()
			.BeTrue();

		Url = "https://api.vk.com/method/account.saveProfileInfo";

		var result = Api.Account.SaveProfileInfo(
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

		result.Changed.Should()
			.BeTrue();
	}

	[Fact]
	public void SaveProfileInfo_ResultWasParsedCorrectly_AndEmptyParametersIsProcessedCorrectly()
	{
		Url = "https://api.vk.com/method/account.saveProfileInfo";
		ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_False");

		var result = Api.Account.SaveProfileInfo(new AccountSaveProfileInfoParams());

		result.Changed
			.Should()
			.BeFalse(); // Second overload

		result.NameRequest.Should()
			.BeNull();

		Url = "https://api.vk.com/method/account.saveProfileInfo";

		ReadCategoryJsonPath($"{nameof(Api.Account.SaveProfileInfo)}_Success");

		var result1 = Api.Account.SaveProfileInfo(new AccountSaveProfileInfoParams());

		result1.Changed
			.Should()
			.BeTrue(); // Second overload

		result1.NameRequest.Status.Should()
			.NotBe(null);

		result1.NameRequest.Status.Should()
			.Be(ChangeNameStatus.Success);
	}

	[Fact]
	public void SetInfo_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.SetInfo("intro", "10"))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void SetInfo_IncorrectUserID_ThrowInvalidParameterException()
	{
		var account = new AccountCategory(Api);
		Url = "https://api.vk.com/method/account.setInfo";

		ReadErrorsJsonFile(100);

		FluentActions.Invoking(() => account.SetInfo("intro", "-10"))
			.Should()
			.ThrowExactly<ParameterMissingOrInvalidException>();
	}

	[Fact]
	public void SetInfo_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setInfo";
		ReadJsonFile(JsonPaths.False);

		Api.Account.SetInfo("own_posts_default", "1")
			.Should()
			.BeFalse();
	}

	[Fact]
	public void SetInfo_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.setInfo";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetInfo("own_posts_default", "1")
			.Should()
			.BeTrue();
	}

	[Fact]
	public void SetInfo_WithIntroParameter_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setInfo";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetInfo("intro", "10")
			.Should()
			.BeTrue();
	}

	[Fact]
	public void SetNameInMenu_EmptyName_ThrowArgumentNullException() => FluentActions
		.Invoking(() => Api.Account.SetNameInMenu(string.Empty, 1))
		.Should()
		.ThrowExactly<ArgumentNullException>();

	[Fact]
	public void SetNameInMenu_NotSets_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setNameInMenu";
		ReadJsonFile(JsonPaths.False);

		Api.Account.SetNameInMenu("example", 1)
			.Should()
			.BeFalse();
	}

	[Fact]
	public void SetNameInMenu_SetsCorrectly_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.setNameInMenu";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetNameInMenu("example", 1)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void SetOffline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var account =
			new AccountCategory(
				new VkApi()); // TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки

		FluentActions.Invoking(() => account.SetOffline())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void SetOffline_NotSets_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setOffline";
		ReadJsonFile(JsonPaths.False);

		Api.Account.SetOffline()
			.Should()
			.BeFalse();
	}

	[Fact]
	public void SetOffline_SetsCorrectly_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.setOffline";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetOffline()
			.Should()
			.BeTrue();
	}

	[Fact]
	public void SetOnline_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.SetOnline())
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void SetOnline_NotSets_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setOnline";
		ReadJsonFile(JsonPaths.False);

		Api.Account.SetOnline()
			.Should()
			.BeFalse();
	}

	[Fact]
	public void SetOnline_SetsCorrectly_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.setOnline";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetOnline()
			.Should()
			.BeTrue();
	}

	[Fact]
	public void SetOnline_WithVoipParameter()
	{
		Url = "https://api.vk.com/method/account.setOnline";
		ReadJsonFile(JsonPaths.True);
		var result = Api.Account.SetOnline(true);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void SetPrivacy()
	{
		// Arrange
		Url = "https://api.vk.com/method/account.setPrivacy";
		ReadCategoryJsonPath(nameof(SetPrivacy));

		// Act
		var result = Api.Account.SetPrivacy(PrivacyKey.Audios, "only_me");

		// Assert
		result.Should()
			.NotBeNull();

		result.Category.Should()
			.Be(Privacy.OnlyMe);
	}

	[Fact]
	public void SetSilenceMode_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.SetSilenceMode("tokenVal"))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void SetSilenceMode_AllParametersAddsToUrlCorrectly()
	{
		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.False);
			var result = Api.Account.SetSilenceMode("tokenVal", 10, 15, true);

			result.Should()
				.BeFalse();
		}

		{
			Url = "https://api.vk.com/method/account.setSilenceMode";
			ReadJsonFile(JsonPaths.False);
			var result = Api.Account.SetSilenceMode("tokenVal", -1, 10, false);

			result.Should()
				.BeFalse();
		}
	}

	[Fact]
	public void SetSilenceMode_NullOrEmptyToken_ThrowArgumentNullException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(Api);

		// ReSharper disable AssignNullToNotNullAttribute
		FluentActions.Invoking(() => account.SetSilenceMode(null))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		FluentActions.Invoking(() => account.SetSilenceMode(string.Empty))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		// ReSharper restore AssignNullToNotNullAttribute
	}

	[Fact]
	public void SetSilenceMode_SetsCorrectly_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.setSilenceMode";
		ReadJsonFile(JsonPaths.False);

		Api.Account.SetSilenceMode("tokenVal")
			.Should()
			.BeFalse();
	}

	[Fact]
	public void SetSilenceMode_SetsCorrectly_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.setSilenceMode";
		ReadJsonFile(JsonPaths.True);

		Api.Account.SetSilenceMode("tokenVal")
			.Should()
			.BeTrue();
	}

	[Fact]
	public void UnbanUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.UnbanUser(42))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void UnbanUser_CorrectParameters_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.unban";
		ReadJsonFile(JsonPaths.False);

		Api.Account.UnbanUser(1)
			.Should()
			.BeFalse();
	}

	[Fact]
	public void UnbanUser_CorrectParameters_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.unban";
		ReadJsonFile(JsonPaths.True);

		Api.Account.UnbanUser(4)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void UnregisterDevice_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(new VkApi());

		FluentActions.Invoking(() => account.UnregisterDevice("tokenVal"))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void UnregisterDevice_CorrectParameters_ReturnFalse()
	{
		Url = "https://api.vk.com/method/account.unregisterDevice";
		ReadJsonFile(JsonPaths.False);

		Api.Account.UnregisterDevice("tokenVal")
			.Should()
			.BeFalse();
	}

	[Fact]
	public void UnregisterDevice_CorrectParameters_ReturnTrue()
	{
		Url = "https://api.vk.com/method/account.unregisterDevice";
		ReadJsonFile(JsonPaths.True);

		Api.Account.UnregisterDevice("tokenVal")
			.Should()
			.BeTrue();
	}

	[Fact]
	public void UnregisterDevice_NullOrEmptyToken_ThrowArgumentNullException()
	{
		// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
		var account = new AccountCategory(Api);

		// ReSharper disable AssignNullToNotNullAttribute
		FluentActions.Invoking(() => account.UnregisterDevice(null))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		FluentActions.Invoking(() => account.UnregisterDevice(string.Empty))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		// ReSharper restore AssignNullToNotNullAttribute
	}
}