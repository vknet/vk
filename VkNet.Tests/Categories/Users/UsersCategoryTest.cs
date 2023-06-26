using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions;
using Moq;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Users;

public class UsersCategoryTest : CategoryBaseTest
{
	private const string Query = "Masha Ivanova";

	protected override string Folder => "Users";

	[Fact]
	public void Get_CountersFields_CountersObject()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_CountersFields_CountersObject));

		// act
		var user = Api.Users.Get(new[]
				{
					"1"
				},
				ProfileFields.Counters)
			.FirstOrDefault();

		// assert
		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павел");

		user.LastName.Should()
			.Be("Дуров");

		user.Counters.Should()
			.NotBeNull();

		user.Counters.Albums.Should()
			.Be(1);

		user.Counters.Videos.Should()
			.Be(8);

		user.Counters.Audios.Should()
			.Be(0);

		user.Counters.Notes.Should()
			.Be(6);

		user.Counters.Photos.Should()
			.Be(153);

		user.Counters.Friends.Should()
			.Be(689);

		user.Counters.OnlineFriends.Should()
			.Be(85);

		user.Counters.MutualFriends.Should()
			.Be(0);

		user.Counters.Followers.Should()
			.Be(5937280);

		user.Counters.Subscriptions.Should()
			.Be(0);

		user.Counters.Pages.Should()
			.Be(51);
	}

	[Fact]
	public void Get_DefaultFields_UidFirstNameLastName()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_DefaultFields_UidFirstNameLastName));

		// act
		var user = Api.Users.Get(new[]
			{
				"1"
			})
			.FirstOrDefault();

		// assert
		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павел");

		user.LastName.Should()
			.Be("Дуров");
	}

	[Fact]
	public void Get_DeletedUser()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_DeletedUser));

		var user = Api.Users.Get(new[]
				{
					"4793858"
				},
				ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Education)
			.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(4793858);

		user.FirstName.Should()
			.Be("Антон");

		user.LastName.Should()
			.Be("Жидков");

		user.Deactivated.Should()
			.Be(Deactivated.Deleted);

		user.IsDeactivated.Should()
			.BeTrue();
	}

	[Fact]
	public void Get_Dimon_SingleUser()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_Dimon_SingleUser));

		var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Sex|ProfileFields.City;

		var user = Api.Users.Get(new[]
				{
					"dm"
				},
				fields,
				NameCase.Gen)
			.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(53083705);

		user.FirstName.Should()
			.Be("Дмитрия");

		user.LastName.Should()
			.Be("Медведева");

		user.Sex.Should()
			.Be(Sex.Male);

		user.City.Id.Should()
			.Be(1);

		user.City.Title.Should()
			.Be("Москва");
	}

	[Fact]
	public void Get_DmAndDurov_ListOfUsers()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_DmAndDurov_ListOfUsers));

		var screenNames = new[]
		{
			"dm",
			"durov"
		};

		var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Sex|ProfileFields.City;
		var users = Api.Users.Get(screenNames, fields, NameCase.Gen);

		users.Should()
			.NotBeNull();

		users.Should()
			.HaveCount(2);

		var user = users.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(53083705);

		user.FirstName.Should()
			.Be("Дмитрия");

		user.LastName.Should()
			.Be("Медведева");

		user.Sex.Should()
			.Be(Sex.Male);

		user.City.Id.Should()
			.Be(1);

		user.City.Title.Should()
			.Be("Москва");

		var user1 = users.Skip(1)
			.FirstOrDefault();

		user1.Should()
			.NotBeNull();

		user1.Id.Should()
			.Be(1);

		user1.FirstName.Should()
			.Be("Павла");

		user1.LastName.Should()
			.Be("Дурова");

		user1.Sex.Should()
			.Be(Sex.Male);

		user1.City.Id.Should()
			.Be(2);

		user1.City.Title.Should()
			.Be("Санкт-Петербург");
	}

	[Fact]
	public void Get_EmptyListOfUids_ThrowArgumentNullException()
	{
		IEnumerable<long> userIds = null;

		FluentActions.Invoking(() => Api.Users.Get(userIds))
			.Should()
			.ThrowExactly<ArgumentNullException>();
	}

	[Fact]
	public void Get_ListOfUsers()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_ListOfUsers));

		var result = Api.Users.Get(new long[]
			{
				1
			},
			ProfileFields.All,
			NameCase.Gen);

		result.Should()
			.NotBeNull();

		result.Should()
			.ContainSingle();

		var user = result.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павла");

		user.LastName.Should()
			.Be("Дурова");

		user.Sex.Should()
			.Be(Sex.Male);

		user.Nickname.Should()
			.BeEmpty();

		user.Domain.Should()
			.Be("durov");

		user.BirthDate.Should()
			.Be("10.10.1984");

		user.City.Should()
			.NotBeNull();

		user.City.Id.Should()
			.Be(2);

		user.City.Title.Should()
			.Be("Санкт-Петербург");

		user.Country.Should()
			.NotBeNull();

		user.Country.Id.Should()
			.Be(1);

		user.Country.Title.Should()
			.Be("Россия");

		user.Timezone.Should()
			.Be(3);

		user.PhotoPreviews.Photo50.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo100.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo200.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo400.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.PhotoMax.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.HasMobile.HasValue.Should()
			.BeTrue();

		user.HasMobile.Value.Should()
			.BeTrue();

		user.Online.HasValue.Should()
			.BeTrue();

		user.Online.Value.Should()
			.BeTrue();

		user.CanPost.Should()
			.BeFalse();

		user.CanSeeAllPosts.Should()
			.BeFalse();

		user.CanSeeAudio.Should()
			.BeFalse();

		user.CanWritePrivateMessage.Should()
			.BeFalse();

		user.Twitter.Should()
			.Be("durov");

		user.Site.Should()
			.BeEmpty();

		user.Status.Should()
			.BeEmpty();

		// TODO: u.LastSeen
		user.CommonCount.Value.Should()
			.Be(0);

		user.Counters.Albums.Should()
			.Be(1);

		user.Counters.Videos.Should()
			.Be(8);

		user.Counters.Audios.Should()
			.Be(0);

		user.Counters.Notes.Value.Should()
			.Be(6);

		user.Counters.Photos.Value.Should()
			.Be(153);

		user.Counters.Friends.Value.Should()
			.Be(688);

		user.Counters.OnlineFriends.Should()
			.Be(146);

		user.Counters.MutualFriends.Should()
			.Be(0);

		user.Counters.Followers.Should()
			.Be(5934786);

		user.Counters.Subscriptions.Should()
			.Be(0);

		user.Counters.Pages.Should()
			.Be(51);

		user.Universities.Should()
			.ContainSingle();

		user.Universities[0]
			.Id.Should()
			.Be(1);

		user.Universities[0]
			.Country.Should()
			.Be(1);

		user.Universities[0]
			.City.Should()
			.Be(2);

		user.Universities[0]
			.Name.Should()
			.Be("СПбГУ");

		user.Universities[0]
			.Graduation.Should()
			.Be(2006);

		user.Schools.Should()
			.HaveCount(2);

		user.Schools[0]
			.Id.Should()
			.Be(1035386);

		user.Schools[0]
			.Country.Should()
			.Be(88);

		user.Schools[0]
			.City.Should()
			.Be(16);

		user.Schools[0]
			.Name.Should()
			.Be("Sc.Elem. Coppino - Falletti di Barolo");

		user.Schools[0]
			.YearFrom.Should()
			.Be(1990);

		user.Schools[0]
			.YearTo.Should()
			.Be(1992);

		user.Schools[0]
			.Class.Should()
			.BeEmpty();

		user.Schools[1]
			.Id.Should()
			.Be(1);

		user.Schools[1]
			.Country.Should()
			.Be(1);

		user.Schools[1]
			.City.Should()
			.Be(2);

		user.Schools[1]
			.Name.Should()
			.Be("Академическая (АГ) СПбГУ");

		user.Schools[1]
			.YearFrom.Should()
			.Be(1996);

		user.Schools[1]
			.YearTo.Should()
			.Be(2001);

		user.Schools[1]
			.YearGraduated.Should()
			.Be(2001);

		user.Schools[1]
			.Class.Should()
			.Be("о");

		user.Schools[1]
			.Type.Should()
			.Be(1);

		user.Schools[1]
			.TypeStr.Should()
			.Be("Гимназия");

		user.Relatives.Should()
			.BeEmpty();
	}

	[Fact]
	public void Get_Mutliple_TwoUidsDefaultFields_TwoProfiles()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_Mutliple_TwoUidsDefaultFields_TwoProfiles));

		var lst = Api.Users.Get(new long[]
		{
			1,
			672
		});

		lst.Should()
			.HaveCount(2);

		lst[0]
			.Should()
			.NotBeNull();

		lst[0]
			.Id.Should()
			.Be(1);

		lst[0]
			.FirstName.Should()
			.Be("Павел");

		lst[0]
			.LastName.Should()
			.Be("Дуров");

		lst[1]
			.Should()
			.NotBeNull();

		lst[1]
			.Id.Should()
			.Be(672);

		lst[1]
			.FirstName.Should()
			.Be("Кристина");

		lst[1]
			.LastName.Should()
			.Be("Смирнова");
	}

	[Fact]
	public void Get_NotAccessToInternet_ThrowVkApiException()
	{
		Mock.Get(Api.RestClient)
			.Setup(f =>
				f.PostAsync(It.IsAny<Uri>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>(), Encoding.UTF8, null, CancellationToken.None))
			.Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));

		FluentActions.Invoking(() => Api.Users.Get(new long[]
			{
				1
			}))
			.Should()
			.ThrowExactly<VkApiException>()
			.And.Message.Should()
			.Be("The remote name could not be resolved: 'api.vk.com'");
	}

	[Fact]
	public void Get_SingleUser()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_SingleUser));

		var user = Api.Users.Get(new[]
				{
					"1"
				},
				ProfileFields.All,
				NameCase.Gen)
			.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павла");

		user.LastName.Should()
			.Be("Дурова");

		user.Sex.Should()
			.Be(Sex.Male);

		user.Nickname.Should()
			.BeEmpty();

		user.Domain.Should()
			.Be("durov");

		user.BirthDate.Should()
			.Be("10.10.1984");

		user.City.Should()
			.NotBeNull();

		user.City.Id.Should()
			.Be(2);

		user.City.Title.Should()
			.Be("Санкт-Петербург");

		user.Country.Should()
			.NotBeNull();

		user.Country.Id.Should()
			.Be(1);

		user.Country.Title.Should()
			.Be("Россия");

		user.Timezone.Should()
			.Be(3);

		user.PhotoPreviews.Photo50.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo100.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo200.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.Photo400.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.PhotoPreviews.PhotoMax.Should()
			.Be(new Uri("https://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg"));

		user.HasMobile.Should()
			.HaveValue();

		user.HasMobile.Should()
			.BeTrue();

		user.Online.Should()
			.HaveValue();

		user.Online.Should()
			.BeTrue();

		user.CanPost.Should()
			.BeFalse();

		user.CanSeeAllPosts.Should()
			.BeFalse();

		user.CanSeeAudio.Should()
			.BeFalse();

		user.CanWritePrivateMessage.Should()
			.BeFalse();

		user.Twitter.Should()
			.Be("durov");

		user.Site.Should()
			.BeEmpty();

		user.Status.Should()
			.BeEmpty();

		// TODO: u.LastSeen
		user.CommonCount.Value.Should()
			.Be(0);

		user.Counters.Albums.Should()
			.Be(1);

		user.Counters.Videos.Should()
			.Be(8);

		user.Counters.Audios.Should()
			.Be(0);

		user.Counters.Notes.Value.Should()
			.Be(6);

		user.Counters.Photos.Value.Should()
			.Be(153);

		user.Counters.Friends.Value.Should()
			.Be(688);

		user.Counters.OnlineFriends.Should()
			.Be(146);

		user.Counters.MutualFriends.Should()
			.Be(0);

		user.Counters.Followers.Should()
			.Be(5934786);

		user.Counters.Subscriptions.Should()
			.Be(0);

		user.Counters.Pages.Should()
			.Be(51);

		user.Universities.Should()
			.HaveCount(1);

		user.Universities[0]
			.Id.Should()
			.Be(1);

		user.Universities[0]
			.Country.Should()
			.Be(1);

		user.Universities[0]
			.City.Should()
			.Be(2);

		user.Universities[0]
			.Name.Should()
			.Be("СПбГУ");

		user.Universities[0]
			.Graduation.Should()
			.Be(2006);

		user.Schools.Should()
			.HaveCount(2);

		user.Schools[0]
			.Id.Should()
			.Be(1035386);

		user.Schools[0]
			.Country.Should()
			.Be(88);

		user.Schools[0]
			.City.Should()
			.Be(16);

		user.Schools[0]
			.Name.Should()
			.Be("Sc.Elem. Coppino - Falletti di Barolo");

		user.Schools[0]
			.YearFrom.Should()
			.Be(1990);

		user.Schools[0]
			.YearTo.Should()
			.Be(1992);

		user.Schools[0]
			.Class.Should()
			.BeEmpty();

		user.Schools[1]
			.Id.Should()
			.Be(1);

		user.Schools[1]
			.Country.Should()
			.Be(1);

		user.Schools[1]
			.City.Should()
			.Be(2);

		user.Schools[1]
			.Name.Should()
			.Be("Академическая (АГ) СПбГУ");

		user.Schools[1]
			.YearFrom.Should()
			.Be(1996);

		user.Schools[1]
			.YearTo.Should()
			.Be(2001);

		user.Schools[1]
			.YearGraduated.Should()
			.Be(2001);

		user.Schools[1]
			.Class.Should()
			.Be("о");

		user.Schools[1]
			.Type.Should()
			.Be(1);

		user.Schools[1]
			.TypeStr.Should()
			.Be("Гимназия");

		user.Relatives.Should()
			.BeEmpty();

		user.OwnerState.State.Should()
			.Be(1);

		user.OwnerState.Photos.Photo50.Should()
			.Be("https://vk.com/images/deactivated_50.png");
	}

	[Fact]
	public void Get_TwoUidsEducationField_TwoProfiles()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_TwoUidsEducationField_TwoProfiles));

		var lst = Api.Users.Get(new long[]
			{
				1,
				5041431
			},
			ProfileFields.Education);

		lst.Should()
			.HaveCount(2);

		lst[0]
			.Should()
			.NotBeNull();

		lst[0]
			.Id.Should()
			.Be(1);

		lst[0]
			.FirstName.Should()
			.Be("Павел");

		lst[0]
			.LastName.Should()
			.Be("Дуров");

		lst[0]
			.Education.Should()
			.NotBeNull();

		lst[0]
			.Education.UniversityId.Should()
			.Be(1);

		lst[0]
			.Education.UniversityName.Should()
			.Be("СПбГУ");

		lst[0]
			.Education.FacultyId.Should()
			.BeNull();

		lst[0]
			.Education.FacultyName.Should()
			.BeNullOrEmpty();

		lst[0]
			.Education.Graduation.Should()
			.Be(2006);

		lst[1]
			.Should()
			.NotBeNull();

		lst[1]
			.Id.Should()
			.Be(5041431);

		lst[1]
			.FirstName.Should()
			.Be("Тайфур");

		lst[1]
			.LastName.Should()
			.Be("Касеев");

		lst[1]
			.Education.Should()
			.NotBeNull();

		lst[1]
			.Education.UniversityId.Should()
			.Be(431);

		lst[1]
			.Education.UniversityName.Should()
			.Be("ВолгГТУ");

		lst[1]
			.Education.FacultyId.Should()
			.Be(3162);

		lst[1]
			.Education.FacultyName.Should()
			.Be("Электроники и вычислительной техники");

		lst[1]
			.Education.Graduation.Should()
			.Be(2012);
	}

	[Fact]
	public void Get_WithSomeFields_FirstNameLastNameEducation()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_WithSomeFields_FirstNameLastNameEducation));

		// act
		var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Education;

		var user = Api.Users.Get(new[]
				{
					"1"
				},
				fields)
			.FirstOrDefault();

		// assert
		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(1);

		user.FirstName.Should()
			.Be("Павел");

		user.LastName.Should()
			.Be("Дуров");

		user.Education.Should()
			.NotBeNull();

		user.Education.UniversityId.Should()
			.Be(1);

		user.Education.UniversityName.Should()
			.Be("СПбГУ");

		user.Education.FacultyId.Should()
			.BeNull();

		user.Education.FacultyName.Should()
			.BeEmpty();

		user.Education.Graduation.Should()
			.Be(2006);
	}

	[Fact]
	public void Get_WrongAccessToken_Throw_ThrowUserAuthorizationException()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadErrorsJsonFile(5);

		// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
		FluentActions.Invoking(() => Api.Users.Get(new List<long>()))
			.Should()
			.ThrowExactly<UserAuthorizationFailException>()
			.And.Message.Should()
			.Be("User authorization failed: access_token was given to another ip address.");
	}

	[Fact]
	public void GetFollowers_WithAllFields()
	{
		Url = "https://api.vk.com/method/users.getFollowers";
		ReadCategoryJsonPath(nameof(GetFollowers_WithAllFields));

		var users = Api.Users.GetFollowers(1, 2, 3, ProfileFields.All, NameCase.Gen);

		users.Should()
			.NotBeNull();

		users.Should()
			.HaveCount(2);

		var user = users.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(243663122);

		user.FirstName.Should()
			.Be("Ивана");

		user.LastName.Should()
			.Be("Радюна");

		user.Sex.Should()
			.Be(Sex.Male);

		user.Nickname.Should()
			.BeEmpty();

		user.Domain.Should()
			.Be("id243663122");

		user.BirthDate.Should()
			.Be("27.8.1985");

		user.City.Id.Should()
			.Be(18632);

		user.City.Title.Should()
			.Be("Вороново");

		user.Country.Id.Should()
			.Be(3);

		user.Country.Title.Should()
			.Be("Беларусь");

		user.Timezone.Should()
			.Be(3);

		user.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs606327.vk.me/v606327122/35ac/R57FNUr34iw.jpg"));

		user.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs606327.vk.me/v606327122/35ab/HUsGNVxBoQU.jpg"));

		user.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg"));

		user.PhotoPreviews.PhotoMax.Should()
			.Be(new Uri("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg"));

		user.HasMobile.Should()
			.BeTrue();

		user.Online.Should()
			.BeTrue();

		user.OnlineMobile.Should()
			.BeTrue();

		user.CanPost.Should()
			.BeFalse();

		user.CanSeeAllPosts.Should()
			.BeTrue();

		user.CanSeeAudio.Should()
			.BeTrue();

		user.CanWritePrivateMessage.Should()
			.BeTrue();

		user.MobilePhone.Should()
			.BeEmpty();

		user.HomePhone.Should()
			.BeEmpty();

		user.Site.Should()
			.BeEmpty();

		user.Status.Should()
			.Be("Пусть ветер гудит в проводах пусть будет осенняя влага пусть люди забудут о нас,но ни забудем друг друга.");

		user.LastSeen.Time.Should()
			.Be(DateHelper.TimeStampToDateTime(1392710539));

		user.CommonCount.Should()
			.Be(0);

		user.Universities.Should()
			.BeEmpty();

		user.Relation.Should()
			.Be(RelationType.InActiveSearch);

		user.Schools.Should()
			.BeEmpty();

		user.Relatives.Should()
			.BeEmpty();

		var user1 = users.Skip(1)
			.FirstOrDefault();

		user1.Should()
			.NotBeNull();

		user1.Id.Should()
			.Be(239897398);

		user1.FirstName.Should()
			.Be("Софійки");

		user1.LastName.Should()
			.Be("Довгалюк");

		user1.Sex.Should()
			.Be(Sex.Female);

		user1.Nickname.Should()
			.BeEmpty();

		user1.Domain.Should()
			.Be("id239897398");

		user1.BirthDate.Should()
			.Be("16.6.2000");

		user1.City.Id.Should()
			.Be(1559);

		user1.City.Title.Should()
			.Be("Тернополь");

		user1.Country.Id.Should()
			.Be(2);

		user1.Country.Title.Should()
			.Be("Украина");

		user1.Timezone.Should()
			.Be(1);

		user1.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs310121.vk.me/v310121398/8023/LMm-uoyk1-M.jpg"));

		user1.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs310121.vk.me/v310121398/8022/KajnVK0lvFA.jpg"));

		user1.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg"));

		user1.PhotoPreviews.PhotoMax.Should()
			.Be(new Uri("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg"));

		user1.HasMobile.Should()
			.BeTrue();

		user1.Online.Should()
			.BeTrue();

		user1.CanPost.Should()
			.BeFalse();

		user1.CanSeeAllPosts.Should()
			.BeTrue();

		user1.CanSeeAudio.Should()
			.BeTrue();

		user1.CanWritePrivateMessage.Should()
			.BeTrue();

		user1.MobilePhone.Should()
			.Be("**********");

		user1.HomePhone.Should()
			.Be("*****");

		user1.Skype.Should()
			.Be("немає");

		user1.Site.Should()
			.BeEmpty();

		user1.Status.Should()
			.Be(
				"Не варто ображатися на людей за те, що вони не виправдали наших очікувань... ми самі винні, що чекали від них більше, ніж варто було!");

		user1.LastSeen.Time.Should()
			.Be(new(2014,
				2,
				18,
				8,
				1,
				14,
				DateTimeKind.Utc));

		user1.CommonCount.Should()
			.Be(0);

		user1.Universities.Should()
			.BeEmpty();

		user1.Relation.Should()
			.Be(RelationType.Unknown);

		user1.Schools.Should()
			.BeEmpty();

		user1.Relatives.Should()
			.HaveCount(2);

		user1.Relatives[0]
			.Id.Should()
			.Be(222462523);

		user1.Relatives[0]
			.Type.Should()
			.Be(RelativeType.Sibling);

		user1.Relatives[1]
			.Id.Should()
			.Be(207105159);

		user1.Relatives[1]
			.Type.Should()
			.Be(RelativeType.Sibling);
	}

	[Fact]
	public void GetFollowers_WithoutFields()
	{
		Url = "https://api.vk.com/method/users.getFollowers";
		ReadCategoryJsonPath(nameof(GetFollowers_WithoutFields));

		var result = Api.Users.GetFollowers(1, 2, 3);

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(2);

		result[0]
			.Id.Should()
			.Be(5984118);

		result[1]
			.Id.Should()
			.Be(179652233);
	}

	[Fact]
	public void GetSubscriptions_Extended()
	{
		Url = "https://api.vk.com/method/users.getSubscriptions";
		ReadCategoryJsonPath(nameof(GetSubscriptions_Extended));

		var result = Api.Users.GetSubscriptions(1, 2, 3);

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(2);

		var group = result.FirstOrDefault();

		group.Should()
			.NotBeNull();

		group.Id.Should()
			.Be(32295218);

		group.Name.Should()
			.Be("LIVE Экспресс");

		group.ScreenName.Should()
			.Be("liveexp");

		group.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group.Type.Should()
			.Be(GroupType.Page);

		group.IsAdmin.Should()
			.BeFalse();

		group.IsMember.Should()
			.BeFalse();

		group.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs412129.vk.me/v412129558/6cea/T3jVq9A5hN4.jpg"));

		group.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs412129.vk.me/v412129558/6ce9/Rs47ldlt4Ko.jpg"));

		group.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs412129.vk.me/v412129604/1238/RhEgZqrsv-w.jpg"));

		var group1 = result.Skip(1)
			.FirstOrDefault();

		group1.Should()
			.NotBeNull();

		group1.Id.Should()
			.Be(43694972);

		group1.Name.Should()
			.Be("Sophie Ellis-Bextor");

		group1.ScreenName.Should()
			.Be("sophieellisbextor");

		group1.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group1.Type.Should()
			.Be(GroupType.Page);

		group1.IsAdmin.Should()
			.BeFalse();

		group1.IsMember.Should()
			.BeFalse();

		group1.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs417031.vk.me/v417031989/59cb/65zF-xnOQsk.jpg"));

		group1.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs417031.vk.me/v417031989/59ca/eOJ7ER_eJok.jpg"));

		group1.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs417031.vk.me/v417031989/59c8/zI9aAlI-PHc.jpg"));
	}

	// ===================================================================
	[Fact]
	public void IsAppUser_5_5_version_of_api_return_false()
	{
		Url = "https://api.vk.com/method/users.isAppUser";
		ReadJsonFile(JsonPaths.False);

		var result = Api.Users.IsAppUser(1);

		result.Should()
			.BeFalse();
	}

	[Fact]
	public void IsAppUser_5_5_version_of_api_return_true()
	{
		Url = "https://api.vk.com/method/users.isAppUser";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Users.IsAppUser(123);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Report_NormalCase()
	{
		Url = "https://api.vk.com/method/users.report";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Users.Report(243663122, ReportType.Insult, "комментарий");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Search_BadQuery_EmptyList()
	{
		Url = "https://api.vk.com/method/users.search";
		ReadJsonFile(JsonPaths.EmptyVkCollection);

		var lst = Api.Users.Search(new()
		{
			Query = "fa'sosjvsoidf"
		});

		lst.TotalCount.Should()
			.Be(0);

		lst.Should()
			.NotBeNull();

		lst.Should()
			.BeEmpty();
	}

	[Fact]
	public void Search_CarierCase()
	{
		Url = "https://api.vk.com/method/users.search";
		ReadCategoryJsonPath(nameof(Search_CarierCase));

		var lst = Api.Users.Search(new()
		{
			Query = Query,
			Fields = ProfileFields.Education,
			Count = 3,
			Offset = 123
		});

		lst.TotalCount.Should()
			.Be(26953);

		lst.Should()
			.ContainSingle();

		var maria = lst.FirstOrDefault();

		maria.Should()
			.NotBeNull();

		// ReSharper disable PossibleNullReferenceException
		maria.Id.Should()
			.Be(165614770);

		maria.FirstName.Should()
			.Be("Маша");

		maria.LastName.Should()
			.Be("Иванова");

		maria.Education.Should()
			.BeNull();

		maria.Career.Should()
			.HaveCount(1);

		maria.Career.Should()
			.SatisfyRespectively(x => x.Until.Should()
				.Be(9223372036854777856));

		// ReSharper restore PossibleNullReferenceException
	}

	[Fact]
	public void Search_DefaultFields_ListOfProfileObjects()
	{
		Url = "https://api.vk.com/method/users.search";
		ReadCategoryJsonPath(nameof(Search_DefaultFields_ListOfProfileObjects));

		var lst = Api.Users.Search(new()
		{
			Query = Query
		});

		lst.TotalCount.Should()
			.Be(26953);

		lst.Should()
			.HaveCount(3);

		lst[0]
			.Should()
			.NotBeNull();

		lst[0]
			.Id.Should()
			.Be(449928);

		lst[0]
			.FirstName.Should()
			.Be("Маша");

		lst[0]
			.LastName.Should()
			.Be("Иванова");

		lst[1]
			.Should()
			.NotBeNull();

		lst[1]
			.Id.Should()
			.Be(70145254);

		lst[1]
			.FirstName.Should()
			.Be("Маша");

		lst[1]
			.LastName.Should()
			.Be("Шаблинская-Иванова");

		lst[2]
			.Should()
			.NotBeNull();

		lst[2]
			.Id.Should()
			.Be(62899425);

		lst[2]
			.FirstName.Should()
			.Be("Masha");

		lst[2]
			.LastName.Should()
			.Be("Ivanova");
	}

	[Fact]
	public void Search_EducationField_ListofProfileObjects()
	{
		Url = "https://api.vk.com/method/users.search";
		ReadCategoryJsonPath(nameof(Search_EducationField_ListofProfileObjects));

		var lst = Api.Users.Search(new()
		{
			Query = Query,
			Fields = ProfileFields.Education,
			Count = 3,
			Offset = 123
		});

		lst.TotalCount.Should()
			.Be(26953);

		lst.Should()
			.HaveCount(3);

		lst[0]
			.Should()
			.NotBeNull();

		lst[0]
			.Id.Should()
			.Be(165614770);

		lst[0]
			.FirstName.Should()
			.Be("Маша");

		lst[0]
			.LastName.Should()
			.Be("Иванова");

		lst[0]
			.Education.Should()
			.BeNull();

		lst[1]
			.Should()
			.NotBeNull();

		lst[1]
			.Id.Should()
			.Be(174063570);

		lst[1]
			.FirstName.Should()
			.Be("Маша");

		lst[1]
			.LastName.Should()
			.Be("Иванова");

		lst[1]
			.Education.Should()
			.BeNull();

		lst[2]
			.Should()
			.NotBeNull();

		lst[2]
			.Id.Should()
			.Be(76817368);

		lst[2]
			.FirstName.Should()
			.Be("Маша");

		lst[2]
			.LastName.Should()
			.Be("Иванова");

		lst[2]
			.Education.Should()
			.BeNull();
	}
}