using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GroupsCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void BanUser_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.banUser";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.BanUser(new()
		{
			GroupId = 6596823,
			UserId = 242506753,
			Comment = "просто комментарий",
			CommentVisible = true
		});

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Edit_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.edit";

		ReadJsonFile(JsonPaths.True);

		var group = new GroupsEditParams
		{
			GroupId = 103292418,
			Title = "Raven"
		};

		var groups = Api.Groups.Edit(group);

		groups.Should()
			.BeTrue();
	}

	[Fact]
	public void EditPlace_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.editPlace";

		ReadCategoryJsonPath(nameof(Api.Groups.EditPlace));

		var place = new Place
		{
			Title = "Test",
			CityId = 1,
			CountryId = 1,
			Longitude = 30,
			Latitude = 30,
			Address = "1"
		};

		var groups = Api.Groups.EditPlace(103292418, place);

		groups.Should()
			.BeTrue();
	}

	[Fact]
	public void Get_NormalCaseAllFields_ReturnFullGroupInfo()
	{
		Url = "https://api.vk.com/method/groups.get";

		ReadCategoryJsonPath(nameof(Get_NormalCaseAllFields_ReturnFullGroupInfo));

		// 1, true, GroupsFilters.Events, GroupsFields.All
		var groups = Api.Groups.Get(new()
			{
				UserId = 1,
				Extended = true,
				Filter = GroupsFilters.Events,
				Fields = GroupsFields.All
			})
			.ToList();

		groups[1]
			.Id.Should()
			.Be(1181795);

		groups[1]
			.Name.Should()
			.Be("Геннадий Бачинский");

		groups[1]
			.ScreenName.Should()
			.Be("club1181795");

		groups[1]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[1]
			.City.Id.Should()
			.Be(1);

		groups[1]
			.Country.Id.Should()
			.Be(1);

		groups[1]
			.Description.Should()
			.Be("В связи с небольшим количеством...");

		groups[1]
			.StartDate.Should()
			.Be(new(2008,
				1,
				15,
				7,
				0,
				0,
				DateTimeKind.Utc));

		groups[1]
			.Type.Should()
			.Be(GroupType.Event);

		groups[1]
			.IsAdmin.Should()
			.BeFalse();

		groups[1]
			.IsMember.Should()
			.BeTrue();

		groups[1]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1181795/c_efd67aca.jpg"));

		groups[1]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1181795/b_369a1c47.jpg"));

		groups[1]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1181795/a_c58272b3.jpg"));

		groups.Should()
			.HaveCount(2);

		groups[0]
			.Id.Should()
			.Be(1153959);

		groups[0]
			.Name.Should()
			.Be("The middle of spring");

		groups[0]
			.ScreenName.Should()
			.Be("club1153959");

		groups[0]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[0]
			.City.Id.Should()
			.Be(10);

		groups[0]
			.Country.Id.Should()
			.Be(1);

		groups[0]
			.Description.Should()
			.Be("Попади в не реальную сказку пришествия...");

		groups[0]
			.StartDate.Should()
			.Be(new(2008,
				04,
				20,
				14,
				0,
				30,
				DateTimeKind.Utc));

		groups[0]
			.Type.Should()
			.Be(GroupType.Event);

		groups[0]
			.IsAdmin.Should()
			.BeFalse();

		groups[0]
			.IsMember.Should()
			.BeTrue();

		groups[0]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1153959/c_6d43acf8.jpg"));

		groups[0]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1153959/b_5bad925c.jpg"));

		groups[0]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs1122.userapi.com/g1153959/a_3c9f63ea.jpg"));
	}

	[Fact]
	public void Get_NormalCaseDefaultFields_ReturnOnlyGroupIds()
	{
		Url = "https://api.vk.com/method/groups.get";

		ReadCategoryJsonPath(nameof(Get_NormalCaseDefaultFields_ReturnOnlyGroupIds));

		var groups = Api.Groups.Get(new()
			{
				UserId = 4793858
			})
			.ToList();

		groups.Should()
			.HaveCount(5);

		groups.Should()
			.SatisfyRespectively(x => x.Id.Should()
					.Be(29689780),
				x => x.Id.Should()
					.Be(33489538),
				x => x.Id.Should()
					.Be(16108331),
				x => x.Id.Should()
					.Be(40724899),
				x => x.Id.Should()
					.Be(36346468));
	}

	[Fact]
	public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var groups = new GroupsCategory(new VkApi());

		FluentActions.Invoking(() => groups.GetById(new List<string>(), "1", null))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetById_BanInfo()
	{
		Url = "https://api.vk.com/method/groups.getById";
		ReadCategoryJsonPath(nameof(GetById_BanInfo));

		var group = Api.Groups.GetById(new List<string>(), "66464944", GroupsFields.BanInfo)
			.FirstOrDefault();

		group.Should()
			.NotBeNull();

		group.Id.Should()
			.Be(66464944);

		group.Name.Should()
			.Be("Подслушано в Ст.Кривянской");

		group.ScreenName.Should()
			.Be("club66464944");

		group.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group.Type.Should()
			.Be(GroupType.Page);

		group.IsAdmin.Should()
			.BeFalse();

		group.IsMember.Should()
			.BeTrue();

		group.BanInfo.Comment.Should()
			.Be("Сам попросил :D");
	}

	[Fact]
	public void GetById_InvalidGid_ThrowsInvalidParameterException()
	{
		Url = "https://api.vk.com/method/groups.getById";

		ReadJsonFile("Errors", "125");

		FluentActions.Invoking(() => Api.Groups.GetById(new List<string>(), "0", null))
			.Should()
			.ThrowExactly<InvalidGroupIdException>();
	}

	[Fact]
	public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var groups = new GroupsCategory(new VkApi());

		FluentActions.Invoking(() => groups.GetById(new List<string>(), "2", null))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void GetById_Multiple_InvalidGids_ThrowsInvalidParameterException()
	{
		Url = "https://api.vk.com/method/groups.getById";

		ReadJsonFile("Errors", "125");

		FluentActions.Invoking(() => Api.Groups.GetById(new[]
				{
					"0"
				},
				null,
				null))
			.Should()
			.ThrowExactly<InvalidGroupIdException>();
	}

	[Fact]
	public void GetById_Multiple_NormalCaseAllFields_ReturnTwoItems()
	{
		Url =
			"https://api.vk.com/method/groups.getById";

		ReadCategoryJsonPath(nameof(GetById_Multiple_NormalCaseAllFields_ReturnTwoItems));

		var groups = Api.Groups.GetById(new[]
				{
					"17683660",
					"637247"
				},
				null,
				GroupsFields.All)
			.ToList();

		groups.Should()
			.HaveCount(2);

		groups[0]
			.Id.Should()
			.Be(17683660);

		groups[0]
			.Name.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля");

		groups[0]
			.ScreenName.Should()
			.Be("club17683660");

		groups[0]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[0]
			.IsAdmin.Should()
			.BeFalse();

		groups[0]
			.Type.Should()
			.Be(GroupType.Event);

		groups[0]
			.IsMember.Should()
			.BeFalse();

		groups[0]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

		groups[0]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

		groups[0]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

		groups[0]
			.City.Id.Should()
			.Be(95);

		groups[0]
			.Country.Id.Should()
			.Be(1);

		groups[0]
			.Description.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21...");

		groups[0]
			.StartDate.Should()
			.Be(new(2012,
				7,
				21,
				6,
				0,
				0,
				DateTimeKind.Utc));

		groups[1]
			.Id.Should()
			.Be(637247);

		groups[1]
			.Name.Should()
			.Be("Чак Паланик - Сумасшедший гений литературы");

		groups[1]
			.ScreenName.Should()
			.Be("club637247");

		groups[1]
			.IsClosed.Should()
			.Be(GroupPublicity.Closed);

		groups[1]
			.IsAdmin.Should()
			.BeFalse();

		groups[1]
			.WikiPage.Should()
			.Be("Chuk Palahniuk");

		groups[1]
			.Type.Should()
			.Be(GroupType.Group);

		groups[1]
			.IsMember.Should()
			.BeTrue();

		groups[1]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));

		groups[1]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));

		groups[1]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));

		groups[1]
			.City.Id.Should()
			.Be(95);

		groups[1]
			.Country.Id.Should()
			.Be(1);

		groups[1]
			.Description.Should()
			.Be("Кто он, этот неординарный и талантливый человек? Его творчество спо...");

		groups[1]
			.StartDate.Should()
			.BeNull();
	}

	[Fact]
	public void GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems()
	{
		Url = "https://api.vk.com/method/groups.getById";

		ReadCategoryJsonPath(nameof(GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems));

		var groups = Api.Groups.GetById(new[]
				{
					"17683660",
					"637247"
				},
				null,
				null)
			.ToList();

		groups.Should()
			.HaveCount(2);

		groups[0]
			.Id.Should()
			.Be(17683660);

		groups[0]
			.Name.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля");

		groups[0]
			.ScreenName.Should()
			.Be("club17683660");

		groups[0]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[0]
			.IsAdmin.Should()
			.BeFalse();

		groups[0]
			.Type.Should()
			.Be(GroupType.Event);

		groups[0]
			.IsMember.Should()
			.BeFalse();

		groups[0]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

		groups[0]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

		groups[0]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

		groups[1]
			.Id.Should()
			.Be(637247);

		groups[1]
			.Name.Should()
			.Be("Чак Паланик - Сумасшедший гений литературы");

		groups[1]
			.ScreenName.Should()
			.Be("club637247");

		groups[1]
			.IsClosed.Should()
			.Be(GroupPublicity.Closed);

		groups[1]
			.Type.Should()
			.Be(GroupType.Group);

		groups[1]
			.IsAdmin.Should()
			.BeFalse();

		groups[1]
			.IsMember.Should()
			.BeTrue();

		groups[1]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));

		groups[1]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));

		groups[1]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));
	}

	[Fact]
	public void GetById_NormalCaseAllFields_ReturnTwoItems()
	{
		Url = "https://api.vk.com/method/groups.getById";

		ReadCategoryJsonPath(nameof(GetById_NormalCaseAllFields_ReturnTwoItems));

		var group = Api.Groups.GetById(new List<string>(), "17683660", GroupsFields.All)
			.FirstOrDefault();

		group.Should()
			.NotBeNull();

		group.Id.Should()
			.Be(17683660);

		group.Name.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля");

		group.ScreenName.Should()
			.Be("club17683660");

		group.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group.IsAdmin.Should()
			.BeFalse();

		group.Type.Should()
			.Be(GroupType.Event);

		group.IsMember.Should()
			.BeFalse();

		group.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

		group.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

		group.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

		group.City.Id.Should()
			.Be(95);

		group.Country.Id.Should()
			.Be(1);

		group.Description.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля<br>....");

		group.StartDate.Should()
			.Be(new(2012,
				7,
				21,
				6,
				0,
				0,
				DateTimeKind.Utc));
	}

	[Fact]
	public void GetById_NormalCaseDefaultFields_ReturnTwoItems()
	{
		Url = "https://api.vk.com/method/groups.getById";

		ReadCategoryJsonPath(nameof(GetById_NormalCaseDefaultFields_ReturnTwoItems));

		var g = Api.Groups.GetById(new List<string>(), "17683660", null)
			.FirstOrDefault();

		g.Should()
			.NotBeNull();

		g.Id.Should()
			.Be(17683660);

		g.Name.Should()
			.Be("Творческие каникулы ART CAMP с 21 по 29 июля");

		g.ScreenName.Should()
			.Be("club17683660");

		g.IsClosed.Should()
			.Be(GroupPublicity.Public);

		g.IsAdmin.Should()
			.BeFalse();

		g.Type.Should()
			.Be(GroupType.Event);

		g.IsMember.Should()
			.BeFalse();

		g.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

		g.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

		g.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));
	}

	[Fact]
	public void GetCatalog_WithAllParams()
	{
		Url = "https://api.vk.com/method/groups.getCatalog";

		ReadCategoryJsonPath(nameof(GetCatalog_WithAllParams));

		var catalog = Api.Groups.GetCatalog(11, 12);

		catalog.Should()
			.NotBeNull();

		catalog.TotalCount.Should()
			.Be(35);

		catalog.Should()
			.HaveCount(2);

		var group1 = catalog.FirstOrDefault();

		group1.Should()
			.NotBeNull();

		group1.Id.Should()
			.Be(50245628);

		group1.Name.Should()
			.Be("СвадьбанаБали.СвадебнаяцеремониянаБали.");

		group1.ScreenName.Should()
			.Be("svadbanabali");

		group1.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group1.Type.Should()
			.Be(GroupType.Group);

		group1.IsAdmin.Should()
			.BeFalse();

		group1.IsMember.Should()
			.BeFalse();

		group1.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c620330/v620330740/cf2a/4Lal9LxRuII.jpg"));

		group1.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c620330/v620330740/cf29/6anB7BfUduc.jpg"));

		group1.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c620330/v620330740/cf28/wPYJcCw4dJA.jpg"));

		var group2 = catalog.Skip(1)
			.FirstOrDefault();

		group2.Should()
			.NotBeNull();

		group2.Id.Should()
			.Be(34267994);

		group2.Name.Should()
			.Be("Логотип.Лендинг.Оформлениегрупп.Реклама");

		group2.ScreenName.Should()
			.Be("pixelike");

		group2.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group2.Type.Should()
			.Be(GroupType.Page);

		group2.IsAdmin.Should()
			.BeFalse();

		group2.IsMember.Should()
			.BeFalse();

		group2.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c631129/v631129289/a7b2/IsslJ3YB_Ho.jpg"));

		group2.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c631129/v631129289/a7b1/Ud8vrcXY4jE.jpg"));

		group2.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c631129/v631129289/a7b0/1Xle1sPdGWU.jpg"));
	}

	[Fact]
	public void GetCatalog_WithoutParams()
	{
		Url = "https://api.vk.com/method/groups.getCatalog";
		ReadCategoryJsonPath(nameof(GetCatalog_WithoutParams));

		var catalog = Api.Groups.GetCatalog();

		catalog.Should()
			.NotBeNull();

		catalog.TotalCount.Should()
			.Be(27);

		catalog.Should()
			.HaveCount(2);

		var group1 = catalog.FirstOrDefault();

		group1.Should()
			.NotBeNull();

		group1.Id.Should()
			.Be(15911874);

		group1.Name.Should()
			.Be("Собака.ru");

		group1.ScreenName.Should()
			.Be("sobaka_ru");

		group1.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group1.Type.Should()
			.Be(GroupType.Page);

		group1.IsAdmin.Should()
			.BeFalse();

		group1.IsMember.Should()
			.BeFalse();

		group1.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c629209/v629209418/39246/tARC41vYcko.jpg"));

		group1.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c629209/v629209418/39245/oqo-rj5a3JY.jpg"));

		group1.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c629209/v629209418/39244/LNkpNaZWlkE.jpg"));

		var group2 = catalog.Skip(1)
			.FirstOrDefault();

		group2.Should()
			.NotBeNull();

		group2.Id.Should()
			.Be(79794);

		group2.Name.Should()
			.Be("CirqueduSoleil|ЦиркдюСолей");

		group2.ScreenName.Should()
			.Be("cds");

		group2.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group2.Type.Should()
			.Be(GroupType.Group);

		group2.IsAdmin.Should()
			.BeFalse();

		group2.IsMember.Should()
			.BeFalse();

		group2.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c629511/v629511851/2dec6/FqIHKdp4u2U.jpg"));

		group2.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c629511/v629511851/2dec5/h10vBfOoRnk.jpg"));

		group2.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c629511/v629511851/2dec4/VRFDlbtQGH4.jpg"));
	}

	[Fact]
	public void GetCatalog_WithParamCategoryId()
	{
		Url = "https://api.vk.com/method/groups.getCatalog";

		ReadCategoryJsonPath(nameof(GetCatalog_WithParamCategoryId));

		var catalog = Api.Groups.GetCatalog(11);

		catalog.Should()
			.NotBeNull();

		catalog.TotalCount.Should()
			.Be(693);

		catalog.Should()
			.HaveCount(2);

		var group1 = catalog.FirstOrDefault();

		group1.Should()
			.NotBeNull();

		group1.Id.Should()
			.Be(21528946);

		group1.Name.Should()
			.Be("Kochut.Ювелирныеизделияподзаказ");

		group1.ScreenName.Should()
			.Be("kochut");

		group1.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group1.Type.Should()
			.Be(GroupType.Group);

		group1.IsAdmin.Should()
			.BeFalse();

		group1.IsMember.Should()
			.BeFalse();

		group1.Photo50.Should()
			.Be(new Uri("https://cs7062.vk.me/c628023/v628023574/45681/YL78hc3tDzE.jpg"));

		group1.Photo100.Should()
			.Be(new Uri("https://cs7062.vk.me/c628023/v628023574/45680/ga_NTah7dDo.jpg"));

		group1.Photo200.Should()
			.Be(new Uri("https://cs7062.vk.me/c628023/v628023574/4567f/QD1aAZsZVHE.jpg"));

		var group2 = catalog.Skip(1)
			.FirstOrDefault();

		group2.Should()
			.NotBeNull();

		group2.Id.Should()
			.Be(81178058);

		group2.Name.Should()
			.Be("Подушкисмайлы|интернетмагазин");

		group2.ScreenName.Should()
			.Be("emoji.shop");

		group2.IsClosed.Should()
			.Be(GroupPublicity.Public);

		group2.Type.Should()
			.Be(GroupType.Group);

		group2.IsAdmin.Should()
			.BeFalse();

		group2.IsMember.Should()
			.BeFalse();

		group2.Photo50.Should()
			.Be(new Uri("https://pp.vk.me/c629121/v629121767/1fb3a/nzbm9sfxlnI.jpg"));

		group2.Photo100.Should()
			.Be(new Uri("https://pp.vk.me/c629121/v629121767/1fb39/fz0oilONN9A.jpg"));

		group2.Photo200.Should()
			.Be(new Uri("https://pp.vk.me/c629121/v629121767/1fb38/gz5b7w4k7u4.jpg"));
	}

	[Fact]
	public void GetCatalogInfo()
	{
		Url = "https://api.vk.com/method/groups.getCatalogInfo";

		ReadCategoryJsonPath(nameof(Api.Groups.GetCatalogInfo));

		var catalogInfo = Api.Groups.GetCatalogInfo();

		catalogInfo.Should()
			.NotBeNull();

		catalogInfo.Enabled.Should()
			.BeTrue();

		catalogInfo.Categories.Should()
			.NotBeEmpty();

		catalogInfo.Categories.Count()
			.Should()
			.Be(13);

		var category = catalogInfo.Categories.FirstOrDefault();

		category.Should()
			.NotBeNull();

		category.Id.Should()
			.Be(0);

		category.Name.Should()
			.Be("Рекомендации");
	}

	[Fact]
	public void GetCatalogInfo_AllParams()
	{
		Url = "https://api.vk.com/method/groups.getCatalogInfo";

		ReadCategoryJsonPath(nameof(GetCatalogInfo_AllParams));

		var catalogInfo = Api.Groups.GetCatalogInfo(true, true);

		catalogInfo.Should()
			.NotBeNull();

		catalogInfo.Enabled.Should()
			.BeTrue();

		catalogInfo.Categories.Should()
			.NotBeEmpty();

		catalogInfo.Categories.Count()
			.Should()
			.Be(2);

		var category = catalogInfo.Categories.FirstOrDefault();

		category.Should()
			.NotBeNull();

		category.Id.Should()
			.Be(6);

		category.Name.Should()
			.Be("Бренды");

		category.PageCount.Should()
			.Be(162);

		category.PagePreviews.Count()
			.Should()
			.Be(1);

		var category1 = catalogInfo.Categories.Skip(1)
			.FirstOrDefault();

		category1.Should()
			.NotBeNull();

		category1.Id.Should()
			.Be(11);

		category1.Name.Should()
			.Be("Магазины");

		category1.PageCount.Should()
			.Be(696);

		category1.PagePreviews.Count()
			.Should()
			.Be(1);

		category1.Subcategories.Should()
			.NotBeEmpty();

		var sub1 = category1.Subcategories.FirstOrDefault();

		sub1.Should()
			.NotBeNull();

		sub1.Id.Should()
			.Be(1);

		sub1.Name.Should()
			.Be("Детскиетовары");

		sub1.PageCount.Should()
			.Be(63);

		sub1.PagePreviews.Should()
			.NotBeEmpty();

		var sub2 = category1.Subcategories.Skip(1)
			.FirstOrDefault();

		sub2.Should()
			.NotBeNull();

		sub2.Id.Should()
			.Be(2);

		sub2.Name.Should()
			.Be("Электроника");

		sub2.PageCount.Should()
			.Be(38);

		sub2.PagePreviews.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetCatalogInfo_Extended()
	{
		Url = "https://api.vk.com/method/groups.getCatalogInfo";

		ReadCategoryJsonPath(nameof(GetCatalogInfo_Extended));

		var catalogInfo = Api.Groups.GetCatalogInfo(true);

		catalogInfo.Should()
			.NotBeNull();

		catalogInfo.Enabled.Should()
			.BeTrue();

		catalogInfo.Categories.Should()
			.NotBeEmpty();

		catalogInfo.Categories.Count()
			.Should()
			.Be(2);

		var category = catalogInfo.Categories.FirstOrDefault();

		category.Should()
			.NotBeNull();

		category.Id.Should()
			.Be(0);

		category.Name.Should()
			.Be("Рекомендации");

		category.PageCount.Should()
			.Be(30);

		category.PagePreviews.Count()
			.Should()
			.Be(2);

		var category1 = catalogInfo.Categories.Skip(1)
			.FirstOrDefault();

		category1.Should()
			.NotBeNull();

		category1.Id.Should()
			.Be(1);

		category1.Name.Should()
			.Be("Новости");

		category1.PageCount.Should()
			.Be(21);

		category1.PagePreviews.Count()
			.Should()
			.Be(2);
	}

	[Fact]
	public void GetCatalogInfo_Subcategories()
	{
		Url = "https://api.vk.com/method/groups.getCatalogInfo";

		ReadCategoryJsonPath(nameof(GetCatalogInfo_Subcategories));

		var catalogInfo = Api.Groups.GetCatalogInfo(true, true);

		catalogInfo.Should()
			.NotBeNull();

		catalogInfo.Enabled.Should()
			.BeTrue();

		catalogInfo.Categories.Should()
			.NotBeEmpty();

		catalogInfo.Categories.Count()
			.Should()
			.Be(2);

		var category = catalogInfo.Categories.FirstOrDefault();

		category.Should()
			.NotBeNull();

		category.Id.Should()
			.Be(6);

		category.Name.Should()
			.Be("Бренды");

		var category1 = catalogInfo.Categories.Skip(1)
			.FirstOrDefault();

		category1.Should()
			.NotBeNull();

		category1.Id.Should()
			.Be(11);

		category1.Name.Should()
			.Be("Магазины");

		category1.Subcategories.Should()
			.NotBeEmpty();

		var sub1 = category1.Subcategories.FirstOrDefault();

		sub1.Should()
			.NotBeNull();

		sub1.Id.Should()
			.Be(1);

		sub1.Name.Should()
			.Be("Детскиетовары");

		var sub2 = category1.Subcategories.Skip(1)
			.FirstOrDefault();

		sub2.Should()
			.NotBeNull();

		sub2.Id.Should()
			.Be(2);

		sub2.Name.Should()
			.Be("Электроника");
	}

	[Fact]
	public void GetInivites_NotInvites()
	{
		Url = "https://api.vk.com/method/groups.getInvites";
		ReadJsonFile(JsonPaths.EmptyVkCollection);

		var groups = Api.Groups.GetInvites(3, 0);

		groups.Should()
			.NotBeNull();

		groups.Should()
			.BeEmpty();
	}

	[Fact]
	public void GetInvitedUsers_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.getInvitedUsers";

		ReadCategoryJsonPath(nameof(GetInvitedUsers_NormalCase));
		var users = Api.Groups.GetInvitedUsers(103292418, 0, 20, UsersFields.BirthDate, NameCase.Dat);

		users.Should()
			.NotBeNull();

		var user = users.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Id.Should()
			.Be(221634238);

		user.FirstName.Should()
			.Be("Александру");

		user.LastName.Should()
			.Be("Инютину");

		user.BirthDate.Should()
			.Be("23.6.2000");
	}

	[Fact]
	public void GetInvites_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.getInvites";

		ReadCategoryJsonPath(nameof(GetInvites_NormalCase));

		var groups = Api.Groups.GetInvites(3, 0);

		groups.Should()
			.NotBeNull();

		groups.Should()
			.ContainSingle();

		var group = groups.FirstOrDefault();

		group.Should()
			.NotBeNull();

		group.Id.Should()
			.Be(66528333);

		group.Name.Should()
			.Be("группа 123");

		group.ScreenName.Should()
			.Be("club66528333");

		group.IsClosed.Should()
			.Be(GroupPublicity.Closed);

		group.Type.Should()
			.Be(GroupType.Group);

		group.IsAdmin.Should()
			.BeFalse();

		group.IsMember.Should()
			.BeFalse();

		group.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://vk.com/images/community_50.gif"));

		group.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://vk.com/images/community_100.gif"));

		group.PhotoPreviews.PhotoMax.Should()
			.Be(new Uri("http://vk.com/images/question_a.gif"));

		group.InvitedBy.Should()
			.Be(242508789);
	}

	[Fact]
	public void GetMembers_InvalidGid_ThrowsInvalidParameterException()
	{
		Url = "https://api.vk.com/method/groups.getMembers";

		ReadJsonFile("Errors", "125");

		FluentActions.Invoking(() => Api.Groups.GetMembers(new()
			{
				GroupId = "0"
			}))
			.Should()
			.ThrowExactly<InvalidGroupIdException>();
	}

	[Fact]
	public void GetMembers_NormalCase_ListOfUsesIds()
	{
		Url = "https://api.vk.com/method/groups.getMembers";

		ReadCategoryJsonPath(nameof(GetMembers_NormalCase_ListOfUsesIds));

		var ids = Api.Groups.GetMembers(new()
		{
			GroupId = "17683660"
		});

		ids.TotalCount.Should()
			.Be(861);

		ids.Should()
			.HaveCount(8);

		ids.Should()
			.SatisfyRespectively(x => x.Id.Should()
					.Be(116446865),
				x => x.Id.Should()
					.Be(485839),
				x => x.Id.Should()
					.Be(23483719),
				x => x.Id.Should()
					.Be(3428459),
				x => x.Id.Should()
					.Be(153698746),
				x => x.Id.Should()
					.Be(16080868),
				x => x.Id.Should()
					.Be(5054657),
				x => x.Id.Should()
					.Be(38690458));
	}

	[Fact]
	public void GetMembers_NormalCaseAllInputParameters_ListOfUsesIds()
	{
		Url = "https://api.vk.com/method/groups.getMembers";

		ReadCategoryJsonPath(nameof(GetMembers_NormalCaseAllInputParameters_ListOfUsesIds));

		var ids = Api.Groups.GetMembers(new()
		{
			GroupId = "17683660",
			Count = 7,
			Offset = 15,
			Sort = GroupsSort.IdAsc,
			Fields = UsersFields.Nickname
		});

		ids.TotalCount.Should()
			.Be(861);

		ids.Should()
			.HaveCount(2);

		ids.Should()
			.SatisfyRespectively(x => x.Id.Should()
					.Be(5),
				x => x.Id.Should()
					.Be(6));
	}

	[Fact]
	public void GetSettings_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.getSettings";

		ReadCategoryJsonPath(nameof(GetSettings_NormalCase));
		var groups = Api.Groups.GetSettings(103292418);

		groups.Should()
			.NotBeNull();

		groups.GroupId.Should()
			.Be(103292418);
	}

	[Fact]
	public void Invite_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.invite";

		ReadJsonFile(JsonPaths.True);

		var users = Api.Groups.Invite(103292418, 221634238);

		users.Should()
			.BeTrue();
	}

	[Fact]
	public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var groups = new GroupsCategory(new VkApi());

		FluentActions.Invoking(() => groups.IsMember("2", 1, false))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void IsMember_UserAuthorizationFail_ThrowUserAuthorizationFailException()
	{
		Url = "https://api.vk.com/method/groups.isMember";

		ReadErrorsJsonFile(5);

		FluentActions.Invoking(() =>
				Api.Groups.IsMember("637247", 4793858, true))
			.Should()
			.ThrowExactly<UserAuthorizationFailException>()
			.And.Message.Should()
			.Be("User authorization failed: access_token was given to another ip address.");
	}

	[Fact]
	public void IsMember_UserIsAMember_ReturnTrue()
	{
		Url = "https://api.vk.com/method/groups.isMember";

		ReadCategoryJsonPath(nameof(IsMember_UserIsAMember_ReturnTrue));

		var result = Api.Groups.IsMember("637247", new long[]{4793858}, true);

		result.Should()
			.NotBeEmpty();

		result[0]
			.Member.Should()
			.BeTrue();
	}

	[Fact]
	public void IsMember_UserNotAMember_ReturnFalse()
	{
		Url = "https://api.vk.com/method/groups.isMember";

		ReadCategoryJsonPath(nameof(IsMember_UserNotAMember_ReturnFalse));

		var result = Api.Groups.IsMember("17683660", new long[]{4793858}, null);

		result.Should()
			.NotBeEmpty();

		result[0]
			.Member.Should()
			.BeFalse();
	}

	[Fact]
	public void IsMember_WrongGid_ThrowsInvalidParameterException()
	{
		Url = "https://api.vk.com/method/groups.isMember";

		ReadErrorsJsonFile(125);

		FluentActions.Invoking(() =>
				Api.Groups.IsMember("0", 4793858, true))
			.Should()
			.ThrowExactly<InvalidGroupIdException>()
			.And.Message.Should()
			.Be("Invalid group id");
	}

	[Fact]
	public void IsMember_WrongUid_ReturnFalse()
	{
		Url = "https://api.vk.com/method/groups.isMember";
		ReadJsonFile(JsonPaths.False);

		var result = Api.Groups.IsMember("637247", 1000000000000, false);

		result.Should()
			.BeFalse();
	}

	[Fact]
	public void Join_AccessDenied_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.com/method/groups.join";

		ReadErrorsJsonFile(7);

		FluentActions.Invoking(() => Api.Groups.Join(2, true))
			.Should()
			.ThrowExactly<PermissionToPerformThisActionException>();
	}

	[Fact]
	public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var groups = new GroupsCategory(new VkApi());

		FluentActions.Invoking(() => groups.Join(1))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void Join_NormalCase_ReturnTrue()
	{
		Url = "https://api.vk.com/method/groups.join";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.Join(2);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Join_NormalCaseNotSure_ReturnTrue()
	{
		Url = "https://api.vk.com/method/groups.join";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.Join(2, true);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
	{
		Url = "https://api.vk.com/method/groups.join";
		ReadErrorsJsonFile(5);

		FluentActions.Invoking(() => Api.Groups.Join(1))
			.Should()
			.ThrowExactly<UserAuthorizationFailException>();
	}

	[Fact]
	public void Join_WrongGid_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.com/method/groups.join";
		ReadErrorsJsonFile(15);

		FluentActions.Invoking(() => Api.Groups.Join(0, true))
			.Should()
			.ThrowExactly<CannotBlacklistYourselfException>()
			.And.Message.Should()
			.Be("Access denied: you can not join this private community");
	}

	[Fact]
	public void Leave_AccessDenied_ThrowAccessDeniedException()
	{
		Url = "https://api.vk.com/method/groups.leave";

		ReadErrorsJsonFile(7);

		FluentActions.Invoking(() => Api.Groups.Leave(2))
			.Should()
			.ThrowExactly<PermissionToPerformThisActionException>();
	}

	[Fact]
	public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
	{
		var groups = new GroupsCategory(new VkApi());

		FluentActions.Invoking(() => groups.Leave(1))
			.Should()
			.ThrowExactly<AccessTokenInvalidException>();
	}

	[Fact]
	public void Leave_NormalCase_ReturnTrue()
	{
		Url = "https://api.vk.com/method/groups.leave";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.Leave(2);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
	{
		Url = "https://api.vk.com/method/groups.leave";
		ReadErrorsJsonFile(5);

		FluentActions.Invoking(() => Api.Groups.Leave(1))
			.Should()
			.ThrowExactly<UserAuthorizationFailException>();
	}

	[Fact]
	public void Leave_WrongGid_ReturnTrue()
	{
		Url = "https://api.vk.com/method/groups.leave";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.Leave(0);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Search_DefaultCase_ListOfGroups()
	{
		Url = "https://api.vk.com/method/groups.search";

		ReadCategoryJsonPath(nameof(Search_DefaultCase_ListOfGroups));

		var groups = Api.Groups.Search(new()
			{
				Query = "Music"
			},
			true);

		groups.Should()
			.HaveCount(2);

		groups.TotalCount.Should()
			.Be(78152);

		groups[1]
			.Id.Should()
			.Be(27895931);

		groups[1]
			.Name.Should()
			.Be("MUSIC 2012");

		groups[1]
			.ScreenName.Should()
			.Be("exclusive_muzic");

		groups[1]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[1]
			.Type.Should()
			.Be(GroupType.Group);

		groups[1]
			.IsAdmin.Should()
			.BeFalse();

		groups[1]
			.IsMember.Should()
			.BeFalse();

		groups[1]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs410222.userapi.com/g27895931/e_d8c8a46f.jpg"));

		groups[1]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs410222.userapi.com/g27895931/d_2869e827.jpg"));

		groups[1]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs410222.userapi.com/g27895931/a_32935e91.jpg"));

		groups[0]
			.Id.Should()
			.Be(339767);

		groups[0]
			.Name.Should()
			.Be("A-ONE HIP-HOP MUSIC CHANNEL");

		groups[0]
			.ScreenName.Should()
			.Be("a1tv");

		groups[0]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[0]
			.Type.Should()
			.Be(GroupType.Group);

		groups[0]
			.IsAdmin.Should()
			.BeFalse();

		groups[0]
			.IsMember.Should()
			.BeFalse();

		groups[0]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs9365.userapi.com/g339767/e_a590d16b.jpg"));

		groups[0]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs9365.userapi.com/g339767/d_f653c773.jpg"));

		groups[0]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs9365.userapi.com/g339767/a_4653ba99.jpg"));
	}

	[Fact]
	public void Search_DefaultCaseAllParams_ListOfGroups()
	{
		Url = "https://api.vk.com/method/groups.search";

		ReadCategoryJsonPath(nameof(Search_DefaultCaseAllParams_ListOfGroups));

		var groups = Api.Groups.Search(new()
			{
				Query = "Music",
				Offset = 20,
				Count = 3
			},
			true);

		groups.Should()
			.HaveCount(3);

		groups.TotalCount.Should()
			.Be(78152);

		groups[2]
			.Id.Should()
			.Be(23995866);

		groups[2]
			.Name.Should()
			.Be(@"E:\music\");

		groups[2]
			.ScreenName.Should()
			.Be("e_music");

		groups[2]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[2]
			.Type.Should()
			.Be(GroupType.Page);

		groups[2]
			.IsAdmin.Should()
			.BeFalse();

		groups[2]
			.IsMember.Should()
			.BeFalse();

		groups[2]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs9913.userapi.com/g23995866/e_319d8573.jpg"));

		groups[2]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs9913.userapi.com/g23995866/d_166572a9.jpg"));

		groups[2]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs9913.userapi.com/g23995866/a_fc553960.jpg"));

		groups[1]
			.Id.Should()
			.Be(23727386);

		groups[1]
			.Name.Should()
			.Be("Classical Music Humor");

		groups[1]
			.ScreenName.Should()
			.Be("mushumor");

		groups[1]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[1]
			.Type.Should()
			.Be(GroupType.Page);

		groups[1]
			.IsAdmin.Should()
			.BeFalse();

		groups[1]
			.IsMember.Should()
			.BeFalse();

		groups[1]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs10650.userapi.com/g23727386/e_8006da42.jpg"));

		groups[1]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs10650.userapi.com/g23727386/d_cbea0559.jpg"));

		groups[1]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs10650.userapi.com/g23727386/a_7743aab2.jpg"));

		groups[0]
			.Id.Should()
			.Be(26442631);

		groups[0]
			.Name.Should()
			.Be("Music Quotes. First Public.");

		groups[0]
			.ScreenName.Should()
			.Be("music_quotes_public");

		groups[0]
			.IsClosed.Should()
			.Be(GroupPublicity.Public);

		groups[0]
			.Type.Should()
			.Be(GroupType.Page);

		groups[0]
			.IsAdmin.Should()
			.BeFalse();

		groups[0]
			.IsMember.Should()
			.BeFalse();

		groups[0]
			.PhotoPreviews.Photo50.Should()
			.Be(new Uri("http://cs303205.userapi.com/g26442631/e_bcb8704f.jpg"));

		groups[0]
			.PhotoPreviews.Photo100.Should()
			.Be(new Uri("http://cs303205.userapi.com/g26442631/d_a3627c6f.jpg"));

		groups[0]
			.PhotoPreviews.Photo200.Should()
			.Be(new Uri("http://cs303205.userapi.com/g26442631/a_32dd770f.jpg"));
	}

	[Fact]
	public void Search_EmptyQuery_ThrowsArgumentException()
	{
		var groups = new GroupsCategory(Api);

		FluentActions.Invoking(() => groups.Search(new()
			{
				Query = ""
			}))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void Search_GroupsNotFounded_EmptyList()
	{
		Url = "https://api.vk.com/method/groups.search";
		ReadJsonFile(JsonPaths.EmptyVkCollection);

		var groups = Api.Groups.Search(new()
			{
				Query = "ThisQueryDoesNotExistAtAll",
				Offset = 20,
				Count = 3
			},
			true);

		groups.Should()
			.BeEmpty();

		groups.TotalCount.Should()
			.Be(0);
	}

	[Fact]
	public void Unban_NormalCase()
	{
		Url = "https://api.vk.com/method/groups.unban";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Groups.Unban(65960, 242508);

		result.Should()
			.BeTrue();
	}
}