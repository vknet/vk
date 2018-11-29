using System;
using System.Collections.Generic;
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

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GroupsCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void BanUser_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.banUser";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.BanUser(new GroupsBanUserParams
			{
				GroupId = 6596823,
				UserId = 242506753,
				Comment = "просто комментарий",
				CommentVisible = true
			});

			Assert.That(result, Is.True);
		}

		[Test]
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

			Assert.That(groups, Is.True);
		}

		[Test]
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

			Assert.That(groups, Is.True);
		}

		[Test]
		[Ignore("")]
		public void Get_NormalCaseAllFields_ReturnFullGroupInfo()
		{
			Url = "https://api.vk.com/method/groups.get";

			ReadCategoryJsonPath(nameof(Get_NormalCaseAllFields_ReturnFullGroupInfo));

			// 1, true, GroupsFilters.Events, GroupsFields.All
			var groups = Api.Groups.Get(new GroupsGetParams
				{
					UserId = 1, Extended = true, Filter = GroupsFilters.Events, Fields = GroupsFields.All
				})
				.ToList();

			Assert.That(groups[1].Id, Is.EqualTo(1181795));
			Assert.That(groups[1].Name, Is.EqualTo("Геннадий Бачинский"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("club1181795"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[1].City.Id, Is.EqualTo(1));
			Assert.That(groups[1].Country.Id, Is.EqualTo(1));
			Assert.That(groups[1].Description, Is.EqualTo("В связи с небольшим количеством..."));

			Assert.That(groups[1].StartDate, Is.EqualTo(new DateTime(2008, 1, 15, 7, 0, 0, DateTimeKind.Utc)));

			Assert.That(groups[1].Type, Is.EqualTo(GroupType.Event));
			Assert.That(groups[1].IsAdmin, Is.False);
			Assert.That(groups[1].IsMember, Is.True);

			Assert.That(groups[1].PhotoPreviews.Photo50, Is.EqualTo("http://cs1122.userapi.com/g1181795/c_efd67aca.jpg"));

			Assert.That(groups[1].PhotoPreviews.Photo100, Is.EqualTo("http://cs1122.userapi.com/g1181795/b_369a1c47.jpg"));

			Assert.That(groups[1].PhotoPreviews.Photo200, Is.EqualTo("http://cs1122.userapi.com/g1181795/a_c58272b3.jpg"));

			Assert.That(groups.Count, Is.EqualTo(2));
			Assert.That(groups[0].Id, Is.EqualTo(1153959));
			Assert.That(groups[0].Name, Is.EqualTo("The middle of spring"));
			Assert.That(groups[0].ScreenName, Is.EqualTo("club1153959"));
			Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[0].City.Id, Is.EqualTo(10));
			Assert.That(groups[0].Country.Id, Is.EqualTo(1));

			Assert.That(groups[0].Description, Is.EqualTo("Попади в не реальную сказку пришествия..."));

			Assert.That(groups[0].StartDate, Is.EqualTo(new DateTime(2008, 04, 20, 14, 0, 30, DateTimeKind.Utc)));

			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].IsMember, Is.True);

			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo("http://cs1122.userapi.com/g1153959/c_6d43acf8.jpg"));

			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo("http://cs1122.userapi.com/g1153959/b_5bad925c.jpg"));

			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo("http://cs1122.userapi.com/g1153959/a_3c9f63ea.jpg"));
		}

		[Test]
		public void Get_NormalCaseDefaultFields_ReturnOnlyGroupIds()
		{
			Url = "https://api.vk.com/method/groups.get";

			ReadCategoryJsonPath(nameof(Get_NormalCaseDefaultFields_ReturnOnlyGroupIds));

			var groups = Api.Groups.Get(new GroupsGetParams
				{
					UserId = 4793858
				})
				.ToList();

			Assert.That(groups.Count, Is.EqualTo(5));
			Assert.That(groups[0].Id, Is.EqualTo(29689780));
			Assert.That(groups[1].Id, Is.EqualTo(33489538));
			Assert.That(groups[2].Id, Is.EqualTo(16108331));
			Assert.That(groups[3].Id, Is.EqualTo(40724899));
			Assert.That(groups[4].Id, Is.EqualTo(36346468));
		}

		[Test]
		[Ignore("Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());

			Assert.That(() => groups.GetById(new List<string>(), "1", null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_BanInfo()
		{
			Url = "https://api.vk.com/method/groups.getById";
			ReadCategoryJsonPath(nameof(GetById_BanInfo));

			var group = Api.Groups.GetById(new List<string>(), "66464944", GroupsFields.BanInfo).FirstOrDefault();
			Assert.That(group, Is.Not.Null);
			Assert.That(group.Id, Is.EqualTo(66464944));
			Assert.That(group.Name, Is.EqualTo("Подслушано в Ст.Кривянской"));
			Assert.That(group.ScreenName, Is.EqualTo("club66464944"));
			Assert.That(group.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group.Type, Is.EqualTo(GroupType.Page));
			Assert.That(group.IsAdmin, Is.EqualTo(false));
			Assert.That(group.IsMember, Is.EqualTo(true));
			Assert.That(group.BanInfo.Comment, Is.EqualTo("Сам попросил :D"));
		}

		[Test]
		public void GetById_InvalidGid_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/groups.getById";

			ReadJsonFile("Errors", "125");

			Assert.That(() => Api.Groups.GetById(new List<string>(), "0", null), Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		[Ignore("Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());

			Assert.That(() => groups.GetById(new List<string>(), "2", null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_Multiple_InvalidGids_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/groups.getById";

			ReadJsonFile("Errors", "125");

			Assert.That(() => Api.Groups.GetById(new[] { "0" }, null, null), Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		[Ignore("")]
		public void GetById_Multiple_NormalCaseAllFields_ReturnTwoItems()
		{
			Url =
				"https://api.vk.com/method/groups.getById";

			ReadCategoryJsonPath(nameof(GetById_Multiple_NormalCaseAllFields_ReturnTwoItems));

			var groups = Api.Groups.GetById(new[]
					{
						"17683660", "637247"
					},
					null,
					GroupsFields.All)
				.ToList();

			Assert.That(groups.Count, Is.EqualTo(2));
			Assert.That(groups[0].Id, Is.EqualTo(17683660));
			Assert.That(groups[0].Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(groups[0].ScreenName, Is.EqualTo("club17683660"));
			Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
			Assert.That(groups[0].IsMember, Is.False);

			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

			Assert.That(groups[0].City.Id, Is.EqualTo(95));
			Assert.That(groups[0].Country.Id, Is.EqualTo(1));

			Assert.That(groups[0].Description, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21..."));

			Assert.That(groups[0].StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0, DateTimeKind.Utc)));

			Assert.That(groups[1].Id, Is.EqualTo(637247));
			Assert.That(groups[1].Name, Is.EqualTo("Чак Паланик - Сумасшедший гений литературы"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("club637247"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Closed));
			Assert.That(groups[1].IsAdmin, Is.False);
			Assert.That(groups[1].WikiPage, Is.EqualTo("Chuk Palahniuk"));
			Assert.That(groups[1].Type, Is.EqualTo(GroupType.Group));
			Assert.That(groups[1].IsMember, Is.True);

			Assert.That(groups[1].PhotoPreviews.Photo50, Is.EqualTo("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));

			Assert.That(groups[1].PhotoPreviews.Photo100, Is.EqualTo("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));

			Assert.That(groups[1].PhotoPreviews.Photo200, Is.EqualTo("http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));

			Assert.That(groups[1].City.Id, Is.EqualTo(95));
			Assert.That(groups[1].Country.Id, Is.EqualTo(1));

			Assert.That(groups[1].Description, Is.EqualTo("Кто он, этот неординарный и талантливый человек? Его творчество спо..."));

			Assert.That(groups[1].StartDate, Is.Null);
		}

		[Test]
		public void GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems()
		{
			Url = "https://api.vk.com/method/groups.getById";

			ReadCategoryJsonPath(nameof(GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems));

			var groups = Api.Groups.GetById(new[]
					{
						"17683660", "637247"
					},
					null,
					null)
				.ToList();

			Assert.That(groups.Count == 2);
			Assert.That(groups[0].Id, Is.EqualTo(17683660));
			Assert.That(groups[0].Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(groups[0].ScreenName, Is.EqualTo("club17683660"));
			Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
			Assert.That(groups[0].IsMember, Is.False);

			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg")));

			Assert.That(groups[1].Id, Is.EqualTo(637247));
			Assert.That(groups[1].Name, Is.EqualTo("Чак Паланик - Сумасшедший гений литературы"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("club637247"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Closed));
			Assert.That(groups[1].Type, Is.EqualTo(GroupType.Group));
			Assert.That(groups[1].IsAdmin, Is.False);
			Assert.That(groups[1].IsMember, Is.True);

			Assert.That(groups[1].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs11418.userapi.com/g637247/a_6be98c68.jpg")));
		}

		[Test]
		[Ignore("")]
		public void GetById_NormalCaseAllFields_ReturnTwoItems()
		{
			Url = "https://api.vk.com/method/groups.getById";

			ReadCategoryJsonPath(nameof(GetById_NormalCaseAllFields_ReturnTwoItems));

			var group = Api.Groups.GetById(new List<string>(), "17683660", GroupsFields.All).FirstOrDefault();

			Assert.NotNull(group);
			Assert.That(group.Id, Is.EqualTo(17683660));
			Assert.That(group.Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(group.ScreenName, Is.EqualTo("club17683660"));
			Assert.That(group.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group.IsAdmin, Is.False);
			Assert.That(group.Type, Is.EqualTo(GroupType.Event));
			Assert.That(group.IsMember, Is.False);

			Assert.That(group.PhotoPreviews.Photo50, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

			Assert.That(group.PhotoPreviews.Photo100, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

			Assert.That(group.PhotoPreviews.Photo200, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

			Assert.That(group.City.Id, Is.EqualTo(95));
			Assert.That(group.Country.Id, Is.EqualTo(1));

			Assert.That(group.Description, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля<br>...."));

			Assert.That(group.StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0, DateTimeKind.Utc)));
		}

		[Test]
		public void GetById_NormalCaseDefaultFields_ReturnTwoItems()
		{
			Url = "https://api.vk.com/method/groups.getById";

			ReadCategoryJsonPath(nameof(GetById_NormalCaseDefaultFields_ReturnTwoItems));

			var g = Api.Groups.GetById(new List<string>(), "17683660", null).FirstOrDefault();

			Assert.NotNull(g);
			Assert.That(g.Id, Is.EqualTo(17683660));
			Assert.That(g.Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(g.ScreenName, Is.EqualTo("club17683660"));
			Assert.That(g.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(g.IsAdmin, Is.False);
			Assert.That(g.Type, Is.EqualTo(GroupType.Event));
			Assert.That(g.IsMember, Is.False);

			Assert.That(g.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/e_f700c806.jpg")));

			Assert.That(g.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg")));

			Assert.That(g.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg")));
		}

		[Test]
		public void GetCatalog_WithAllParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";

			ReadCategoryJsonPath(nameof(GetCatalog_WithAllParams));

			var catalog = Api.Groups.GetCatalog(11, 12);
			Assert.That(catalog, Is.Not.Null);
			Assert.That(catalog.TotalCount, Is.EqualTo(35));
			Assert.That(catalog.Count, Is.EqualTo(2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(group1, Is.Not.Null);
			Assert.That(group1.Id, Is.EqualTo(50245628));
			Assert.That(group1.Name, Is.EqualTo("СвадьбанаБали.СвадебнаяцеремониянаБали."));
			Assert.That(group1.ScreenName, Is.EqualTo("svadbanabali"));
			Assert.That(group1.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group1.Type, Is.EqualTo(GroupType.Group));
			Assert.That(group1.IsAdmin, Is.False);
			Assert.That(group1.IsMember, Is.False);

			Assert.That(group1.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c620330/v620330740/cf2a/4Lal9LxRuII.jpg")));

			Assert.That(group1.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c620330/v620330740/cf29/6anB7BfUduc.jpg")));

			Assert.That(group1.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c620330/v620330740/cf28/wPYJcCw4dJA.jpg")));

			var group2 = catalog.Skip(1).FirstOrDefault();
			Assert.That(group2, Is.Not.Null);
			Assert.That(group2.Id, Is.EqualTo(34267994));
			Assert.That(group2.Name, Is.EqualTo("Логотип.Лендинг.Оформлениегрупп.Реклама"));
			Assert.That(group2.ScreenName, Is.EqualTo("pixelike"));
			Assert.That(group2.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group2.Type, Is.EqualTo(GroupType.Page));
			Assert.That(group2.IsAdmin, Is.False);
			Assert.That(group2.IsMember, Is.False);

			Assert.That(group2.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c631129/v631129289/a7b2/IsslJ3YB_Ho.jpg")));

			Assert.That(group2.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c631129/v631129289/a7b1/Ud8vrcXY4jE.jpg")));

			Assert.That(group2.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c631129/v631129289/a7b0/1Xle1sPdGWU.jpg")));
		}

		[Test]
		public void GetCatalog_WithoutParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";
			ReadCategoryJsonPath(nameof(GetCatalog_WithoutParams));

			var catalog = Api.Groups.GetCatalog();
			Assert.That(catalog, Is.Not.Null);
			Assert.That(catalog.TotalCount, Is.EqualTo(27));
			Assert.That(catalog.Count, Is.EqualTo(2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(group1, Is.Not.Null);
			Assert.That(group1.Id, Is.EqualTo(15911874));
			Assert.That(group1.Name, Is.EqualTo("Собака.ru"));
			Assert.That(group1.ScreenName, Is.EqualTo("sobaka_ru"));
			Assert.That(group1.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group1.Type, Is.EqualTo(GroupType.Page));
			Assert.That(group1.IsAdmin, Is.False);
			Assert.That(group1.IsMember, Is.False);

			Assert.That(group1.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c629209/v629209418/39246/tARC41vYcko.jpg")));

			Assert.That(group1.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c629209/v629209418/39245/oqo-rj5a3JY.jpg")));

			Assert.That(group1.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c629209/v629209418/39244/LNkpNaZWlkE.jpg")));

			var group2 = catalog.Skip(1).FirstOrDefault();
			Assert.That(group2, Is.Not.Null);
			Assert.That(group2.Id, Is.EqualTo(79794));
			Assert.That(group2.Name, Is.EqualTo("CirqueduSoleil|ЦиркдюСолей"));
			Assert.That(group2.ScreenName, Is.EqualTo("cds"));
			Assert.That(group2.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group2.Type, Is.EqualTo(GroupType.Group));
			Assert.That(group2.IsAdmin, Is.False);
			Assert.That(group2.IsMember, Is.False);

			Assert.That(group2.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c629511/v629511851/2dec6/FqIHKdp4u2U.jpg")));

			Assert.That(group2.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c629511/v629511851/2dec5/h10vBfOoRnk.jpg")));

			Assert.That(group2.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c629511/v629511851/2dec4/VRFDlbtQGH4.jpg")));
		}

		[Test]
		public void GetCatalog_WithParamCategoryId()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";

			ReadCategoryJsonPath(nameof(GetCatalog_WithParamCategoryId));

			var catalog = Api.Groups.GetCatalog(11);
			Assert.That(catalog, Is.Not.Null);
			Assert.That(catalog.TotalCount, Is.EqualTo(693));
			Assert.That(catalog.Count, Is.EqualTo(2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(group1, Is.Not.Null);
			Assert.That(group1.Id, Is.EqualTo(21528946));
			Assert.That(group1.Name, Is.EqualTo("Kochut.Ювелирныеизделияподзаказ"));
			Assert.That(group1.ScreenName, Is.EqualTo("kochut"));
			Assert.That(group1.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group1.Type, Is.EqualTo(GroupType.Group));
			Assert.That(group1.IsAdmin, Is.False);
			Assert.That(group1.IsMember, Is.False);

			Assert.That(group1.Photo50, Is.EqualTo(new Uri("https://cs7062.vk.me/c628023/v628023574/45681/YL78hc3tDzE.jpg")));

			Assert.That(group1.Photo100, Is.EqualTo(new Uri("https://cs7062.vk.me/c628023/v628023574/45680/ga_NTah7dDo.jpg")));

			Assert.That(group1.Photo200, Is.EqualTo(new Uri("https://cs7062.vk.me/c628023/v628023574/4567f/QD1aAZsZVHE.jpg")));

			var group2 = catalog.Skip(1).FirstOrDefault();
			Assert.That(group2, Is.Not.Null);
			Assert.That(group2.Id, Is.EqualTo(81178058));
			Assert.That(group2.Name, Is.EqualTo("Подушкисмайлы|интернетмагазин"));
			Assert.That(group2.ScreenName, Is.EqualTo("emoji.shop"));
			Assert.That(group2.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(group2.Type, Is.EqualTo(GroupType.Group));
			Assert.That(group2.IsAdmin, Is.False);
			Assert.That(group2.IsMember, Is.False);

			Assert.That(group2.Photo50, Is.EqualTo(new Uri("https://pp.vk.me/c629121/v629121767/1fb3a/nzbm9sfxlnI.jpg")));

			Assert.That(group2.Photo100, Is.EqualTo(new Uri("https://pp.vk.me/c629121/v629121767/1fb39/fz0oilONN9A.jpg")));

			Assert.That(group2.Photo200, Is.EqualTo(new Uri("https://pp.vk.me/c629121/v629121767/1fb38/gz5b7w4k7u4.jpg")));
		}

		[Test]
		public void GetCatalogInfo()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			ReadCategoryJsonPath(nameof(Api.Groups.GetCatalogInfo));

			var catalogInfo = Api.Groups.GetCatalogInfo();

			Assert.NotNull(catalogInfo);
			Assert.That(catalogInfo.Enabled, Is.True);
			CollectionAssert.IsNotEmpty(catalogInfo.Categories);
			Assert.That(catalogInfo.Categories.Count(), Is.EqualTo(13));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(category, Is.Not.Null);
			Assert.That(category.Id, Is.EqualTo(0));
			Assert.That(category.Name, Is.EqualTo("Рекомендации"));
		}

		[Test]
		public void GetCatalogInfo_AllParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			ReadCategoryJsonPath(nameof(GetCatalogInfo_AllParams));

			var catalogInfo = Api.Groups.GetCatalogInfo(true, true);
			Assert.That(catalogInfo, Is.Not.Null);
			Assert.That(catalogInfo.Enabled, Is.True);
			CollectionAssert.IsNotEmpty(catalogInfo.Categories);
			Assert.That(catalogInfo.Categories.Count(), Is.EqualTo(2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(category, Is.Not.Null);
			Assert.That(category.Id, Is.EqualTo(6));
			Assert.That(category.Name, Is.EqualTo("Бренды"));
			Assert.That(category.PageCount, Is.EqualTo(162));
			Assert.That(category.PagePreviews.Count(), Is.EqualTo(1));

			var category1 = catalogInfo.Categories.Skip(1).FirstOrDefault();
			Assert.That(category1, Is.Not.Null);
			Assert.That(category1.Id, Is.EqualTo(11));
			Assert.That(category1.Name, Is.EqualTo("Магазины"));
			Assert.That(category1.PageCount, Is.EqualTo(696));
			Assert.That(category1.PagePreviews.Count(), Is.EqualTo(1));
			CollectionAssert.IsNotEmpty(category1.Subcategories);

			var sub1 = category1.Subcategories.FirstOrDefault();
			Assert.That(sub1, Is.Not.Null);
			Assert.That(sub1.Id, Is.EqualTo(1));
			Assert.That(sub1.Name, Is.EqualTo("Детскиетовары"));
			Assert.That(sub1.PageCount, Is.EqualTo(63));
			CollectionAssert.IsNotEmpty(sub1.PagePreviews);

			var sub2 = category1.Subcategories.Skip(1).FirstOrDefault();
			Assert.That(sub2, Is.Not.Null);
			Assert.That(sub2.Id, Is.EqualTo(2));
			Assert.That(sub2.Name, Is.EqualTo("Электроника"));
			Assert.That(sub2.PageCount, Is.EqualTo(38));
			CollectionAssert.IsNotEmpty(sub2.PagePreviews);
		}

		[Test]
		public void GetCatalogInfo_Extended()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			ReadCategoryJsonPath(nameof(GetCatalogInfo_Extended));

			var catalogInfo = Api.Groups.GetCatalogInfo(true);
			Assert.That(catalogInfo, Is.Not.Null);
			Assert.That(catalogInfo.Enabled, Is.True);
			CollectionAssert.IsNotEmpty(catalogInfo.Categories);
			Assert.That(catalogInfo.Categories.Count(), Is.EqualTo(2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(category, Is.Not.Null);
			Assert.That(category.Id, Is.EqualTo(0));
			Assert.That(category.Name, Is.EqualTo("Рекомендации"));
			Assert.That(category.PageCount, Is.EqualTo(30));
			Assert.That(category.PagePreviews.Count(), Is.EqualTo(2));

			var category1 = catalogInfo.Categories.Skip(1).FirstOrDefault();
			Assert.That(category1, Is.Not.Null);
			Assert.That(category1.Id, Is.EqualTo(1));
			Assert.That(category1.Name, Is.EqualTo("Новости"));
			Assert.That(category1.PageCount, Is.EqualTo(21));
			Assert.That(category1.PagePreviews.Count(), Is.EqualTo(2));
		}

		[Test]
		public void GetCatalogInfo_Subcategories()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			ReadCategoryJsonPath(nameof(GetCatalogInfo_Subcategories));

			var catalogInfo = Api.Groups.GetCatalogInfo(true, true);
			Assert.That(catalogInfo, Is.Not.Null);
			Assert.That(catalogInfo.Enabled, Is.True);
			CollectionAssert.IsNotEmpty(catalogInfo.Categories);
			Assert.That(catalogInfo.Categories.Count(), Is.EqualTo(2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(category, Is.Not.Null);
			Assert.That(category.Id, Is.EqualTo(6));
			Assert.That(category.Name, Is.EqualTo("Бренды"));

			var category1 = catalogInfo.Categories.Skip(1).FirstOrDefault();
			Assert.That(category1, Is.Not.Null);
			Assert.That(category1.Id, Is.EqualTo(11));
			Assert.That(category1.Name, Is.EqualTo("Магазины"));
			CollectionAssert.IsNotEmpty(category1.Subcategories);

			var sub1 = category1.Subcategories.FirstOrDefault();
			Assert.That(sub1, Is.Not.Null);
			Assert.That(sub1.Id, Is.EqualTo(1));
			Assert.That(sub1.Name, Is.EqualTo("Детскиетовары"));

			var sub2 = category1.Subcategories.Skip(1).FirstOrDefault();
			Assert.That(sub2, Is.Not.Null);
			Assert.That(sub2.Id, Is.EqualTo(2));
			Assert.That(sub2.Name, Is.EqualTo("Электроника"));
		}

		[Test]
		public void GetInivites_NotInvites()
		{
			Url = "https://api.vk.com/method/groups.getInvites";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var groups = Api.Groups.GetInvites(3, 0);

			Assert.That(groups, Is.Not.Null);
			Assert.That(groups.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetInvitedUsers_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.getInvitedUsers";

			ReadCategoryJsonPath(nameof(GetInvitedUsers_NormalCase));
			var users = Api.Groups.GetInvitedUsers(103292418, 0, 20, UsersFields.BirthDate, NameCase.Dat);

			Assert.That(users, Is.Not.Null);
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Id, Is.EqualTo(221634238));
			Assert.That(user.FirstName, Is.EqualTo("Александру"));
			Assert.That(user.LastName, Is.EqualTo("Инютину"));
			Assert.That(user.BirthDate, Is.EqualTo("23.6.2000"));
		}

		[Test]
		public void GetInvites_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.getInvites";

			ReadCategoryJsonPath(nameof(GetInvites_NormalCase));

			var groups = Api.Groups.GetInvites(3, 0);

			Assert.That(groups, Is.Not.Null);
			Assert.That(groups.Count, Is.EqualTo(1));
			var group = groups.FirstOrDefault();
			Assert.That(group, Is.Not.Null);
			Assert.That(group.Id, Is.EqualTo(66528333));
			Assert.That(group.Name, Is.EqualTo("группа 123"));
			Assert.That(group.ScreenName, Is.EqualTo("club66528333"));
			Assert.That(group.IsClosed, Is.EqualTo(GroupPublicity.Closed));
			Assert.That(group.Type, Is.EqualTo(GroupType.Group));
			Assert.That(group.IsAdmin, Is.False);
			Assert.That(group.IsMember, Is.EqualTo(false));

			Assert.That(group.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://vk.com/images/community_50.gif")));

			Assert.That(group.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://vk.com/images/community_100.gif")));

			Assert.That(group.PhotoPreviews.PhotoMax, Is.EqualTo(new Uri("http://vk.com/images/question_a.gif")));

			Assert.That(group.InvitedBy, Is.EqualTo(242508789));
		}

		[Test]
		public void GetMembers_InvalidGid_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/groups.getMembers";

			ReadJsonFile("Errors", "125");

			Assert.That(() => Api.Groups.GetMembers(new GroupsGetMembersParams
				{
					GroupId = "0"
				}),
				Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		public void GetMembers_NormalCase_ListOfUsesIds()
		{
			Url = "https://api.vk.com/method/groups.getMembers";

			ReadCategoryJsonPath(nameof(GetMembers_NormalCase_ListOfUsesIds));

			var ids = Api.Groups.GetMembers(new GroupsGetMembersParams
			{
				GroupId = "17683660"
			});

			Assert.That(ids.TotalCount, Is.EqualTo(861));
			Assert.That(ids.Count, Is.EqualTo(8));

			Assert.That(ids[0].Id, Is.EqualTo(116446865));
			Assert.That(ids[1].Id, Is.EqualTo(485839));
			Assert.That(ids[2].Id, Is.EqualTo(23483719));
			Assert.That(ids[3].Id, Is.EqualTo(3428459));
			Assert.That(ids[4].Id, Is.EqualTo(153698746));
			Assert.That(ids[5].Id, Is.EqualTo(16080868));
			Assert.That(ids[6].Id, Is.EqualTo(5054657));
			Assert.That(ids[7].Id, Is.EqualTo(38690458));
		}

		[Test]
		public void GetMembers_NormalCaseAllInputParameters_ListOfUsesIds()
		{
			Url = "https://api.vk.com/method/groups.getMembers";

			ReadCategoryJsonPath(nameof(GetMembers_NormalCaseAllInputParameters_ListOfUsesIds));

			var ids = Api.Groups.GetMembers(new GroupsGetMembersParams
			{
				GroupId = "17683660", Count = 7, Offset = 15, Sort = GroupsSort.IdAsc
			});

			Assert.That(ids.TotalCount, Is.EqualTo(861));
			Assert.That(ids.Count, Is.EqualTo(7));

			Assert.That(ids[0].Id, Is.EqualTo(1129147));
			Assert.That(ids[1].Id, Is.EqualTo(1137997));
			Assert.That(ids[2].Id, Is.EqualTo(1201582));
			Assert.That(ids[3].Id, Is.EqualTo(1205554));
			Assert.That(ids[4].Id, Is.EqualTo(1220166));
			Assert.That(ids[5].Id, Is.EqualTo(1238937));
			Assert.That(ids[6].Id, Is.EqualTo(1239796));
		}

		[Test]
		public void GetSettings_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.getSettings";

			ReadCategoryJsonPath(nameof(GetSettings_NormalCase));
			var groups = Api.Groups.GetSettings(103292418);

			Assert.That(groups, Is.Not.Null);
			Assert.That(groups.GroupId, Is.EqualTo(103292418));
		}

		[Test]
		public void Invite_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.invite";

			ReadJsonFile(JsonPaths.True);

			var users = Api.Groups.Invite(103292418, 221634238);

			Assert.That(users, Is.True);
		}

		[Test]
		[Ignore("Это открытый метод, не требующий access_token.")]
		public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());

			Assert.That(() => groups.IsMember("2", 1, null, null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void IsMember_WrongGid_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/groups.isMember";

			ReadErrorsJsonFile(125);

			var ex = Assert.Throws<InvalidGroupIdException>(() =>
				Api.Groups.IsMember("0", 4793858, null, null));

			Assert.That(ex.Message, Is.EqualTo("Invalid group id"));
		}

		[Test]
		public void IsMember_WrongUid_ReturnFalse()
		{
			Url = "https://api.vk.com/method/groups.isMember";
			ReadJsonFile(JsonPaths.False);

			var result = Api.Groups.IsMember("637247", 1000000000000, null, null);
			Assert.That(result.Count > 0 && result[0].Member, Is.False);
		}

		[Test]
		[Ignore("Это открытый метод, не требующий access_token.")]
		public void IsMemeber_UserAuthorizationFail_ThrowUserAuthorizationFailException()
		{
			Url = "https://api.vk.com/method/groups.isMember";

			ReadErrorsJsonFile(5);

			var ex = Assert.Throws<UserAuthorizationFailException>(() =>
				Api.Groups.IsMember("637247", 4793858, null, null));

			Assert.That(ex.Message, Is.EqualTo("User authorization failed: access_token was given to another ip address."));
		}

		[Test]
		public void IsMember_UserIsAMember_ReturnTrue()
		{
			Url = "https://api.vk.com/method/groups.isMember";

			ReadCategoryJsonPath(nameof(IsMember_UserIsAMember_ReturnTrue));

			var result = Api.Groups.IsMember("637247", 4793858, null, null);
			Assert.That(result.Count > 0 && result[0].Member, Is.True);
		}

		[Test]
		public void IsMember_UserNotAMember_ReturnFalse()
		{
			Url = "https://api.vk.com/method/groups.isMember";

			ReadCategoryJsonPath(nameof(IsMember_UserNotAMember_ReturnFalse));

			var result = Api.Groups.IsMember("17683660", 4793858, null, null);
			Assert.That(result.Count > 0 && result[0].Member, Is.False);
		}

		[Test]
		public void Join_AccessDenied_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/groups.join";

			ReadErrorsJsonFile(7);

			Assert.That(() => Api.Groups.Join(2, true), Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Ignore("")]
		[Test]
		public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.Join(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Join_NormalCase_ReturnTrue()
		{
			Url = "https://api.vk.com/method/groups.join";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.Join(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Join_NormalCaseNotSure_ReturnTrue()
		{
			Url = "https://api.vk.com/method/groups.join";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.Join(2, true);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			Url = "https://api.vk.com/method/groups.join";
			ReadErrorsJsonFile(5);

			Assert.That(() => Api.Groups.Join(1), Throws.InstanceOf<UserAuthorizationFailException>());
		}

		[Test]
		public void Join_WrongGid_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/groups.join";
			ReadErrorsJsonFile(15);

			var ex = Assert.Throws<CannotBlacklistYourselfException>(() => Api.Groups.Join(0, true));
			Assert.That(ex.Message, Is.EqualTo("Access denied: you can not join this private community"));
		}

		[Test]
		public void Leave_AccessDenied_ThrowAccessDeniedException()
		{
			Url = "https://api.vk.com/method/groups.leave";

			ReadErrorsJsonFile(7);

			Assert.That(() => Api.Groups.Leave(2), Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Ignore("")]
		[Test]
		public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.Leave(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Leave_NormalCase_ReturnTrue()
		{
			Url = "https://api.vk.com/method/groups.leave";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.Leave(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			Url = "https://api.vk.com/method/groups.leave";
			ReadErrorsJsonFile(5);

			Assert.That(() => Api.Groups.Leave(1), Throws.InstanceOf<UserAuthorizationFailException>());
		}

		[Test]
		public void Leave_WrongGid_ReturnTrue()
		{
			Url = "https://api.vk.com/method/groups.leave";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.Leave(0);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Search_DefaultCaseAllParams_ListOfGroups()
		{
			Url = "https://api.vk.com/method/groups.search";

			ReadCategoryJsonPath(nameof(Search_DefaultCaseAllParams_ListOfGroups));

			var groups = Api.Groups.Search(new GroupsSearchParams
				{
					Query = "Music", Offset = 20, Count = 3
				},
				true);

			Assert.That(groups.Count, Is.EqualTo(3));
			Assert.That(groups.TotalCount, Is.EqualTo(78152));

			Assert.That(groups[2].Id, Is.EqualTo(23995866));
			Assert.That(groups[2].Name, Is.EqualTo(@"E:\music\"));
			Assert.That(groups[2].ScreenName, Is.EqualTo("e_music"));
			Assert.That(groups[2].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[2].Type, Is.EqualTo(GroupType.Page));
			Assert.That(groups[2].IsAdmin, Is.False);
			Assert.That(groups[2].IsMember, Is.False);

			Assert.That(groups[2].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs9913.userapi.com/g23995866/e_319d8573.jpg")));

			Assert.That(groups[2].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs9913.userapi.com/g23995866/d_166572a9.jpg")));

			Assert.That(groups[2].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs9913.userapi.com/g23995866/a_fc553960.jpg")));

			Assert.That(groups[1].Id, Is.EqualTo(23727386));
			Assert.That(groups[1].Name, Is.EqualTo("Classical Music Humor"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("mushumor"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[1].Type, Is.EqualTo(GroupType.Page));
			Assert.That(groups[1].IsAdmin, Is.False);
			Assert.That(groups[1].IsMember, Is.False);

			Assert.That(groups[1].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs10650.userapi.com/g23727386/e_8006da42.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs10650.userapi.com/g23727386/d_cbea0559.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs10650.userapi.com/g23727386/a_7743aab2.jpg")));

			Assert.That(groups[0].Id, Is.EqualTo(26442631));
			Assert.That(groups[0].Name, Is.EqualTo("Music Quotes. First Public."));
			Assert.That(groups[0].ScreenName, Is.EqualTo("music_quotes_public"));
			Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Page));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].IsMember, Is.False);

			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs303205.userapi.com/g26442631/e_bcb8704f.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs303205.userapi.com/g26442631/d_a3627c6f.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs303205.userapi.com/g26442631/a_32dd770f.jpg")));
		}

		[Test]
		public void Search_DefaultCase_ListOfGroups()
		{
			Url = "https://api.vk.com/method/groups.search";

			ReadCategoryJsonPath(nameof(Search_DefaultCase_ListOfGroups));

			var groups = Api.Groups.Search(new GroupsSearchParams
				{
					Query = "Music"
				},
				true);

			Assert.That(groups.Count, Is.EqualTo(2));
			Assert.That(groups.TotalCount, Is.EqualTo(78152));

			Assert.That(groups[1].Id, Is.EqualTo(27895931));
			Assert.That(groups[1].Name, Is.EqualTo("MUSIC 2012"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("exclusive_muzic"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[1].Type, Is.EqualTo(GroupType.Group));
			Assert.That(groups[1].IsAdmin, Is.False);
			Assert.That(groups[1].IsMember, Is.False);

			Assert.That(groups[1].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs410222.userapi.com/g27895931/e_d8c8a46f.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs410222.userapi.com/g27895931/d_2869e827.jpg")));

			Assert.That(groups[1].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs410222.userapi.com/g27895931/a_32935e91.jpg")));

			Assert.That(groups[0].Id, Is.EqualTo(339767));
			Assert.That(groups[0].Name, Is.EqualTo("A-ONE HIP-HOP MUSIC CHANNEL"));
			Assert.That(groups[0].ScreenName, Is.EqualTo("a1tv"));
			Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Group));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].IsMember, Is.False);

			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs9365.userapi.com/g339767/e_a590d16b.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs9365.userapi.com/g339767/d_f653c773.jpg")));

			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs9365.userapi.com/g339767/a_4653ba99.jpg")));
		}

		[Test]
		public void Search_EmptyQuery_ThrowsArgumentException()
		{
			var groups = new GroupsCategory(Api);

			Assert.That(() => groups.Search(new GroupsSearchParams
				{
					Query = ""
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void Search_GroupsNotFounded_EmptyList()
		{
			Url = "https://api.vk.com/method/groups.search";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var groups = Api.Groups.Search(new GroupsSearchParams
				{
					Query = "ThisQueryDoesNotExistAtAll", Offset = 20, Count = 3
				},
				true);

			Assert.That(groups.Count, Is.EqualTo(0));
			Assert.That(groups.TotalCount, Is.EqualTo(0));
		}

		[Test]
		public void UnbanUser_NormalCase()
		{
			Url = "https://api.vk.com/method/groups.unbanUser";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Groups.UnbanUser(65960, 242508);

			Assert.That(result, Is.True);
		}
	}
}