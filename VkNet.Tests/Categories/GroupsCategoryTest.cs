using System;
using System.Collections.Generic;
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
	public class GroupsCategoryTest : BaseTest
	{
		private GroupsCategory GetMockedGroupCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new GroupsCategory(vk: Api);
		}

		[Test]
		public void BanUser_NormalCase()
		{
			const string url =
					"https://api.vk.com/method/groups.banUser";

			const string json =
					@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var result = cat.BanUser(@params: new GroupsBanUserParams
			{
					GroupId = 6596823
					, UserId = 242506753
					, Comment = "просто комментарий"
					, CommentVisible = true
			});

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.edit";

			const string json =
					@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var group = new GroupsEditParams
			{
					GroupId = 103292418
					, Title = "Raven"
			};

			var groups = cat.Edit(@params: group);

			Assert.That(actual: groups, expression: Is.True);
		}

		[Test]
		public void EditPlace_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.editPlace";

			const string json =
					@"{
					'response': {
					  'success': 1,
					  'address': ''
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var place = new Place
			{
					Title = "Test"
					, CityId = 1
					, CountryId = 1
					, Longitude = 30
					, Latitude = 30
					, Address = "1"
			};

			var groups = cat.EditPlace(groupId: 103292418, place: place);

			Assert.That(actual: groups, expression: Is.True);
		}

		[Test]
		[Ignore(reason: "")]
		public void Get_NormalCaseAllFields_ReturnFullGroupInfo()
		{
			const string url =
					"https://api.vk.com/method/groups.get";

			const string json =
					@"{
					'response': [
					  92,
					  {
						'id': 1153959,
						'name': 'The middle of spring',
						'screen_name': 'club1153959',
						'is_closed': 0,
						city: {
							id: 10,
							title: 'Санкт-Петербург'
						},
						country: {
							id: 1,
							title: 'Россия'
						},
						'description': 'Попади в не реальную сказку пришествия...',
						'start_date': '1208700030',
						'type': 'event',
						'is_admin': 0,
						'is_member': 1,
						'photo_50': 'http://cs1122.userapi.com/g1153959/c_6d43acf8.jpg',
						'photo_100': 'http://cs1122.userapi.com/g1153959/b_5bad925c.jpg',
						'photo_200': 'http://cs1122.userapi.com/g1153959/a_3c9f63ea.jpg'
					  },
					  {
						'id': 1181795,
						'name': 'Геннадий Бачинский',
						'screen_name': 'club1181795',
						'is_closed': 0,
						city: {
							id: 1,
							title: 'Санкт-Петербург'
						},
						country: {
							id: 1,
							title: 'Россия'
						},
						'description': 'В связи с небольшим количеством...',
						'start_date': '1200380400',
						'type': 'event',
						'is_admin': 0,
						'is_member': 1,
						'photo_50': 'http://cs1122.userapi.com/g1181795/c_efd67aca.jpg',
						'photo_100': 'http://cs1122.userapi.com/g1181795/b_369a1c47.jpg',
						'photo_200': 'http://cs1122.userapi.com/g1181795/a_c58272b3.jpg'
					  }
					]
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			// 1, true, GroupsFilters.Events, GroupsFields.All
			var groups = category.Get(@params: new GroupsGetParams
					{
							UserId = 1
							, Extended = true
							, Filter = GroupsFilters.Events
							, Fields = GroupsFields.All
					})
					.ToList();

			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 1181795));
			Assert.That(actual: groups[index: 1].Name, expression: Is.EqualTo(expected: "Геннадий Бачинский"));
			Assert.That(actual: groups[index: 1].ScreenName, expression: Is.EqualTo(expected: "club1181795"));
			Assert.That(actual: groups[index: 1].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 1].City.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: groups[index: 1].Country.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: groups[index: 1].Description, expression: Is.EqualTo(expected: "В связи с небольшим количеством..."));

			Assert.That(actual: groups[index: 1].StartDate
					, expression: Is.EqualTo(expected: new DateTime(year: 2008, month: 1, day: 15, hour: 7, minute: 0, second: 0
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: groups[index: 1].Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: groups[index: 1].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 1].IsMember, expression: Is.True);

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1181795/c_efd67aca.jpg"));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1181795/b_369a1c47.jpg"));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1181795/a_c58272b3.jpg"));

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 1153959));
			Assert.That(actual: groups[index: 0].Name, expression: Is.EqualTo(expected: "The middle of spring"));
			Assert.That(actual: groups[index: 0].ScreenName, expression: Is.EqualTo(expected: "club1153959"));
			Assert.That(actual: groups[index: 0].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 0].City.Id, expression: Is.EqualTo(expected: 10));
			Assert.That(actual: groups[index: 0].Country.Id, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: groups[index: 0].Description
					, expression: Is.EqualTo(expected: "Попади в не реальную сказку пришествия..."));

			Assert.That(actual: groups[index: 0].StartDate
					, expression: Is.EqualTo(expected: new DateTime(year: 2008, month: 04, day: 20, hour: 14, minute: 0, second: 30
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: groups[index: 0].Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: groups[index: 0].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 0].IsMember, expression: Is.True);

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1153959/c_6d43acf8.jpg"));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1153959/b_5bad925c.jpg"));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: "http://cs1122.userapi.com/g1153959/a_3c9f63ea.jpg"));
		}

		[Test]
		public void Get_NormalCaseDefaultFields_ReturnOnlyGroupIds()
		{
			const string url = "https://api.vk.com/method/groups.get";

			const string json =
					@"{
					response: {
						count: 8,
						items: [
						  29689780,
						  33489538,
						  16108331,
						  40724899,
						  36346468
						]
					}
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			var groups = category.Get(@params: new GroupsGetParams
					{
							UserId = 4793858
					})
					.ToList();

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 29689780));
			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 33489538));
			Assert.That(actual: groups[index: 2].Id, expression: Is.EqualTo(expected: 16108331));
			Assert.That(actual: groups[index: 3].Id, expression: Is.EqualTo(expected: 40724899));
			Assert.That(actual: groups[index: 4].Id, expression: Is.EqualTo(expected: 36346468));
		}

		[Test]
		[Ignore(reason: "Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(vk: new VkApi());

			Assert.That(del: () => groups.GetById(groupIds: new List<string>(), groupId: "1", fields: null),
					expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_BanInfo()
		{
			const string url = "https://api.vk.com/method/groups.getById";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 66464944,
                        'name': 'Подслушано в Ст.Кривянской',
                        'screen_name': 'club66464944',
                        'is_closed': 0,
                        'type': 'page',
                        'is_admin': 0,
                        'is_member': 1,
                        'ban_info': {
                          'end_date': 1446061273,
                          'comment': 'Сам попросил :D'
                        },
                        'photo_50': 'https://pp.vk.me/...1f1/EQ4pWlWdL74.jpg',
                        'photo_100': 'https://pp.vk.me/...1f0/0Rl3JI-Oyyo.jpg',
                        'photo_200': 'https://pp.vk.me/...1ef/ozzx8hmX3Bk.jpg'
                      }
                    ]
                  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var group = cat.GetById(groupIds: new List<string>(), groupId: "66464944", fields: GroupsFields.BanInfo).FirstOrDefault();
			Assert.That(actual: group, expression: Is.Not.Null);
			Assert.That(actual: group.Id, expression: Is.EqualTo(expected: 66464944));
			Assert.That(actual: group.Name, expression: Is.EqualTo(expected: "Подслушано в Ст.Кривянской"));
			Assert.That(actual: group.ScreenName, expression: Is.EqualTo(expected: "club66464944"));
			Assert.That(actual: group.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group.IsAdmin, expression: Is.EqualTo(expected: false));
			Assert.That(actual: group.IsMember, expression: Is.EqualTo(expected: true));
			Assert.That(actual: group.BanInfo.Comment, expression: Is.EqualTo(expected: "Сам попросил :D"));
		}

		[Test]
		public void GetById_InvalidGid_ThrowsInvalidParameterException()
		{
			const string url = "https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'error': {
					  'error_code': 125,
					  'error_msg': 'Invalid group id',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.getById'
						},
						{
						  'key': 'gid',
						  'value': '17683660,637247'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			Assert.That(del: () => cat.GetById(groupIds: new List<string>(), groupId: "0", fields: null)
					, expr: Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		[Ignore(reason: "Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(vk: new VkApi());

			Assert.That(del: () => groups.GetById(groupIds: new List<string>(), groupId: "2", fields: null),
					expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_Multiple_InvalidGids_ThrowsInvalidParameterException()
		{
			const string url = "https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'error': {
					  'error_code': 125,
					  'error_msg': 'Invalid group id',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.getById'
						},
						{
						  'key': 'gids',
						  'value': '-1'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			Assert.That(del: () => cat.GetById(groupIds: new[] { "0" }, groupId: null, fields: null)
					, expr: Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		[Ignore(reason: "")]
		public void GetById_Multiple_NormalCaseAllFields_ReturnTwoItems()
		{
			const string url =
					"https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'response': [
					  {
						'id': 17683660,
						'name': 'Творческие каникулы ART CAMP с 21 по 29 июля',
						'screen_name': 'club17683660',
						'is_closed': 0,
						city: {
							id: 95,
							title: 'Санкт-Петербург'
						},
						country: {
							id: 1,
							title: 'Россия'
						},
						'description': 'Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21...',
						'start_date': '1342850400',
						'type': 'event',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs407631.userapi.com/g17683660/e_f700c806.jpg',
						'photo_100': 'http://cs407631.userapi.com/g17683660/d_26f909c0.jpg',
						'photo_200': 'http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg'
					  },
					  {
						'id': 637247,
						'name': 'Чак Паланик - Сумасшедший гений литературы',
						'screen_name': 'club637247',
						'is_closed': 1,
						city: {
							id: 95,
							title: 'Санкт-Петербург'
						},
						country: {
							id: 1,
							title: 'Россия'
						},
						'description': 'Кто он, этот неординарный и талантливый человек? Его творчество спо...',
						'wiki_page': 'Chuk Palahniuk',
						'start_date': '0',
						'type': 'group',
						'is_admin': 0,
						'is_member': 1,
						'photo_50': 'http://cs11418.userapi.com/g637247/c_f597d0f8.jpg',
						'photo_100': 'http://cs11418.userapi.com/g637247/b_898ae7f1.jpg',
						'photo_200': 'http://cs11418.userapi.com/g637247/a_6be98c68.jpg'
					  }
					]
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			var groups = category.GetById(groupIds: new[]
					{
							"17683660"
							, "637247"
					}, groupId: null, fields: GroupsFields.All)
					.ToList();

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 17683660));
			Assert.That(actual: groups[index: 0].Name, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(actual: groups[index: 0].ScreenName, expression: Is.EqualTo(expected: "club17683660"));
			Assert.That(actual: groups[index: 0].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 0].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 0].Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: groups[index: 0].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

			Assert.That(actual: groups[index: 0].City.Id, expression: Is.EqualTo(expected: 95));
			Assert.That(actual: groups[index: 0].Country.Id, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: groups[index: 0].Description
					, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21..."));

			Assert.That(actual: groups[index: 0].StartDate
					, expression: Is.EqualTo(expected: new DateTime(year: 2012, month: 7, day: 21, hour: 10, minute: 0, second: 0
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 637247));
			Assert.That(actual: groups[index: 1].Name, expression: Is.EqualTo(expected: "Чак Паланик - Сумасшедший гений литературы"));
			Assert.That(actual: groups[index: 1].ScreenName, expression: Is.EqualTo(expected: "club637247"));
			Assert.That(actual: groups[index: 1].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Closed));
			Assert.That(actual: groups[index: 1].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 1].WikiPage, expression: Is.EqualTo(expected: "Chuk Palahniuk"));
			Assert.That(actual: groups[index: 1].Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: groups[index: 1].IsMember, expression: Is.True);

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: "http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: "http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: "http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));

			Assert.That(actual: groups[index: 1].City.Id, expression: Is.EqualTo(expected: 95));
			Assert.That(actual: groups[index: 1].Country.Id, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: groups[index: 1].Description,
					expression: Is.EqualTo(expected: "Кто он, этот неординарный и талантливый человек? Его творчество спо..."));

			Assert.That(actual: groups[index: 1].StartDate, expression: Is.Null);
		}

		[Test]
		public void GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems()
		{
			const string url = "https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'response': [
					  {
						'id': 17683660,
						'name': 'Творческие каникулы ART CAMP с 21 по 29 июля',
						'screen_name': 'club17683660',
						'is_closed': 0,
						'type': 'event',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs407631.userapi.com/g17683660/e_f700c806.jpg',
						'photo_100': 'http://cs407631.userapi.com/g17683660/d_26f909c0.jpg',
						'photo_200': 'http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg'
					  },
					  {
						'id': 637247,
						'name': 'Чак Паланик - Сумасшедший гений литературы',
						'screen_name': 'club637247',
						'is_closed': 1,
						'type': 'group',
						'is_admin': 0,
						'is_member': 1,
						'photo_50': 'http://cs11418.userapi.com/g637247/c_f597d0f8.jpg',
						'photo_100': 'http://cs11418.userapi.com/g637247/b_898ae7f1.jpg',
						'photo_200': 'http://cs11418.userapi.com/g637247/a_6be98c68.jpg'
					  }
					]
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var groups = cat.GetById(groupIds: new[]
					{
							"17683660"
							, "637247"
					}, groupId: null, fields: null)
					.ToList();

			Assert.That(condition: groups.Count == 2);
			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 17683660));
			Assert.That(actual: groups[index: 0].Name, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(actual: groups[index: 0].ScreenName, expression: Is.EqualTo(expected: "club17683660"));
			Assert.That(actual: groups[index: 0].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 0].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 0].Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: groups[index: 0].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/e_f700c806.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/d_26f909c0.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg")));

			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 637247));
			Assert.That(actual: groups[index: 1].Name, expression: Is.EqualTo(expected: "Чак Паланик - Сумасшедший гений литературы"));
			Assert.That(actual: groups[index: 1].ScreenName, expression: Is.EqualTo(expected: "club637247"));
			Assert.That(actual: groups[index: 1].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Closed));
			Assert.That(actual: groups[index: 1].Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: groups[index: 1].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 1].IsMember, expression: Is.True);

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs11418.userapi.com/g637247/c_f597d0f8.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs11418.userapi.com/g637247/b_898ae7f1.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs11418.userapi.com/g637247/a_6be98c68.jpg")));
		}

		[Test]
		[Ignore(reason: "")]
		public void GetById_NormalCaseAllFields_ReturnTwoItems()
		{
			const string url =
					"https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'response': [
					  {
						'id': 17683660,
						'name': 'Творческие каникулы ART CAMP с 21 по 29 июля',
						'screen_name': 'club17683660',
						'is_closed': 0,
						city: {
							id: 95,
							title: 'Санкт-Петербург'
						},
						country: {
							id: 1,
							title: 'Россия'
						},
						'description': 'Творческие каникулы ART CAMP с 21 по 29 июля<br>....',
						'start_date': '1342850400',
						'type': 'event',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs407631.userapi.com/g17683660/e_f700c806.jpg',
						'photo_100': 'http://cs407631.userapi.com/g17683660/d_26f909c0.jpg',
						'photo_200': 'http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg'
					  }
					]
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);
			var group = category.GetById(groupIds: new List<string>(), groupId: "17683660", fields: GroupsFields.All).FirstOrDefault();

			Assert.That(actual: group.Id, expression: Is.EqualTo(expected: 17683660));
			Assert.That(actual: group.Name, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(actual: group.ScreenName, expression: Is.EqualTo(expected: "club17683660"));
			Assert.That(actual: group.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group.IsAdmin, expression: Is.False);
			Assert.That(actual: group.Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: group.IsMember, expression: Is.False);

			Assert.That(actual: group.PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));

			Assert.That(actual: group.PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));

			Assert.That(actual: group.PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: "http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

			Assert.That(actual: group.City.Id, expression: Is.EqualTo(expected: 95));
			Assert.That(actual: group.Country.Id, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: group.Description
					, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля<br>...."));

			Assert.That(actual: group.StartDate
					, expression: Is.EqualTo(expected: new DateTime(year: 2012, month: 7, day: 21, hour: 10, minute: 0, second: 0
							, kind: DateTimeKind.Utc)));
		}

		[Test]
		public void GetById_NormalCaseDefaultFields_ReturnTwoItems()
		{
			const string url = "https://api.vk.com/method/groups.getById";

			const string json =
					@"{
					'response': [
					  {
						'id': 17683660,
						'name': 'Творческие каникулы ART CAMP с 21 по 29 июля',
						'screen_name': 'club17683660',
						'is_closed': 0,
						'type': 'event',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs407631.userapi.com/g17683660/e_f700c806.jpg',
						'photo_100': 'http://cs407631.userapi.com/g17683660/d_26f909c0.jpg',
						'photo_200': 'http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg'
					  }
					]
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);
			var g = cat.GetById(groupIds: new List<string>(), groupId: "17683660", fields: null).FirstOrDefault();

			Assert.That(actual: g.Id, expression: Is.EqualTo(expected: 17683660));
			Assert.That(actual: g.Name, expression: Is.EqualTo(expected: "Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(actual: g.ScreenName, expression: Is.EqualTo(expected: "club17683660"));
			Assert.That(actual: g.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: g.IsAdmin, expression: Is.False);
			Assert.That(actual: g.Type, expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: g.IsMember, expression: Is.False);

			Assert.That(actual: g.PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/e_f700c806.jpg")));

			Assert.That(actual: g.PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/d_26f909c0.jpg")));

			Assert.That(actual: g.PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg")));
		}

		[Test]
		public void GetCatalog_WithAllParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";

			Json = @"{
				response: {
	                count: 35,
	                items: [{
		                id: 50245628,
		                name: 'СвадьбанаБали.СвадебнаяцеремониянаБали.',
		                screen_name: 'svadbanabali',
		                is_closed: 0,
		                type: 'group',
		                is_admin: 0,
		                is_member: 0,
		                photo_50: 'https://pp.vk.me/c620330/v620330740/cf2a/4Lal9LxRuII.jpg',
		                photo_100: 'https://pp.vk.me/c620330/v620330740/cf29/6anB7BfUduc.jpg',
		                photo_200: 'https://pp.vk.me/c620330/v620330740/cf28/wPYJcCw4dJA.jpg'
	                },
	                {
		                id: 34267994,
		                name: 'Логотип.Лендинг.Оформлениегрупп.Реклама',
		                screen_name: 'pixelike',
		                is_closed: 0,
		                type: 'page',
		                is_admin: 0,
		                is_member: 0,
		                photo_50: 'https://pp.vk.me/c631129/v631129289/a7b2/IsslJ3YB_Ho.jpg',
		                photo_100: 'https://pp.vk.me/c631129/v631129289/a7b1/Ud8vrcXY4jE.jpg',
		                photo_200: 'https://pp.vk.me/c631129/v631129289/a7b0/1Xle1sPdGWU.jpg'
	                }]
                }
			}";

			var catalog = Api.Groups.GetCatalog(categoryId: 11, subcategoryId: 12);
			Assert.That(actual: catalog, expression: Is.Not.Null);
			Assert.That(actual: catalog.TotalCount, expression: Is.EqualTo(expected: 35));
			Assert.That(actual: catalog.Count, expression: Is.EqualTo(expected: 2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(actual: group1, expression: Is.Not.Null);
			Assert.That(actual: group1.Id, expression: Is.EqualTo(expected: 50245628));
			Assert.That(actual: group1.Name, expression: Is.EqualTo(expected: "СвадьбанаБали.СвадебнаяцеремониянаБали."));
			Assert.That(actual: group1.ScreenName, expression: Is.EqualTo(expected: "svadbanabali"));
			Assert.That(actual: group1.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group1.Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: group1.IsAdmin, expression: Is.False);
			Assert.That(actual: group1.IsMember, expression: Is.False);

			Assert.That(actual: group1.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c620330/v620330740/cf2a/4Lal9LxRuII.jpg")));

			Assert.That(actual: group1.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c620330/v620330740/cf29/6anB7BfUduc.jpg")));

			Assert.That(actual: group1.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c620330/v620330740/cf28/wPYJcCw4dJA.jpg")));

			var group2 = catalog.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: group2, expression: Is.Not.Null);
			Assert.That(actual: group2.Id, expression: Is.EqualTo(expected: 34267994));
			Assert.That(actual: group2.Name, expression: Is.EqualTo(expected: "Логотип.Лендинг.Оформлениегрупп.Реклама"));
			Assert.That(actual: group2.ScreenName, expression: Is.EqualTo(expected: "pixelike"));
			Assert.That(actual: group2.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group2.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group2.IsAdmin, expression: Is.False);
			Assert.That(actual: group2.IsMember, expression: Is.False);

			Assert.That(actual: group2.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c631129/v631129289/a7b2/IsslJ3YB_Ho.jpg")));

			Assert.That(actual: group2.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c631129/v631129289/a7b1/Ud8vrcXY4jE.jpg")));

			Assert.That(actual: group2.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c631129/v631129289/a7b0/1Xle1sPdGWU.jpg")));
		}

		[Test]
		public void GetCatalog_WithoutParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";

			Json = @"{
				response: {
					count: 27,
					items: [{
						id: 15911874,
						name: 'Собака.ru',
						screen_name: 'sobaka_ru',
						is_closed: 0,
						type: 'page',
						is_admin: 0,
						is_member: 0,
						photo_50: 'https://pp.vk.me/c629209/v629209418/39246/tARC41vYcko.jpg',
						photo_100: 'https://pp.vk.me/c629209/v629209418/39245/oqo-rj5a3JY.jpg',
						photo_200: 'https://pp.vk.me/c629209/v629209418/39244/LNkpNaZWlkE.jpg'
					},
					{
						id: 79794,
						name: 'CirqueduSoleil|ЦиркдюСолей',
						screen_name: 'cds',
						is_closed: 0,
						type: 'group',
						is_admin: 0,
						is_member: 0,
						photo_50: 'https://pp.vk.me/c629511/v629511851/2dec6/FqIHKdp4u2U.jpg',
						photo_100: 'https://pp.vk.me/c629511/v629511851/2dec5/h10vBfOoRnk.jpg',
						photo_200: 'https://pp.vk.me/c629511/v629511851/2dec4/VRFDlbtQGH4.jpg'
					}]
				}
			}";

			var catalog = Api.Groups.GetCatalog();
			Assert.That(actual: catalog, expression: Is.Not.Null);
			Assert.That(actual: catalog.TotalCount, expression: Is.EqualTo(expected: 27));
			Assert.That(actual: catalog.Count, expression: Is.EqualTo(expected: 2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(actual: group1, expression: Is.Not.Null);
			Assert.That(actual: group1.Id, expression: Is.EqualTo(expected: 15911874));
			Assert.That(actual: group1.Name, expression: Is.EqualTo(expected: "Собака.ru"));
			Assert.That(actual: group1.ScreenName, expression: Is.EqualTo(expected: "sobaka_ru"));
			Assert.That(actual: group1.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group1.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group1.IsAdmin, expression: Is.False);
			Assert.That(actual: group1.IsMember, expression: Is.False);

			Assert.That(actual: group1.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629209/v629209418/39246/tARC41vYcko.jpg")));

			Assert.That(actual: group1.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629209/v629209418/39245/oqo-rj5a3JY.jpg")));

			Assert.That(actual: group1.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629209/v629209418/39244/LNkpNaZWlkE.jpg")));

			var group2 = catalog.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: group2, expression: Is.Not.Null);
			Assert.That(actual: group2.Id, expression: Is.EqualTo(expected: 79794));
			Assert.That(actual: group2.Name, expression: Is.EqualTo(expected: "CirqueduSoleil|ЦиркдюСолей"));
			Assert.That(actual: group2.ScreenName, expression: Is.EqualTo(expected: "cds"));
			Assert.That(actual: group2.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group2.Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: group2.IsAdmin, expression: Is.False);
			Assert.That(actual: group2.IsMember, expression: Is.False);

			Assert.That(actual: group2.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629511/v629511851/2dec6/FqIHKdp4u2U.jpg")));

			Assert.That(actual: group2.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629511/v629511851/2dec5/h10vBfOoRnk.jpg")));

			Assert.That(actual: group2.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629511/v629511851/2dec4/VRFDlbtQGH4.jpg")));
		}

		[Test]
		public void GetCatalog_WithParamCategoryId()
		{
			Url = "https://api.vk.com/method/groups.getCatalog";

			Json = @"{
				response: {
	                count: 693,
	                items: [{
		                id: 21528946,
		                name: 'Kochut.Ювелирныеизделияподзаказ',
		                screen_name: 'kochut',
		                is_closed: 0,
		                type: 'group',
		                is_admin: 0,
		                is_member: 0,
		                photo_50: 'https://cs7062.vk.me/c628023/v628023574/45681/YL78hc3tDzE.jpg',
		                photo_100: 'https://cs7062.vk.me/c628023/v628023574/45680/ga_NTah7dDo.jpg',
		                photo_200: 'https://cs7062.vk.me/c628023/v628023574/4567f/QD1aAZsZVHE.jpg'
	                },
	                {
		                id: 81178058,
		                name: 'Подушкисмайлы|интернетмагазин',
		                screen_name: 'emoji.shop',
		                is_closed: 0,
		                type: 'group',
		                is_admin: 0,
		                is_member: 0,
		                photo_50: 'https://pp.vk.me/c629121/v629121767/1fb3a/nzbm9sfxlnI.jpg',
		                photo_100: 'https://pp.vk.me/c629121/v629121767/1fb39/fz0oilONN9A.jpg',
		                photo_200: 'https://pp.vk.me/c629121/v629121767/1fb38/gz5b7w4k7u4.jpg'
	                }]
                }
			}";

			var catalog = Api.Groups.GetCatalog(categoryId: 11);
			Assert.That(actual: catalog, expression: Is.Not.Null);
			Assert.That(actual: catalog.TotalCount, expression: Is.EqualTo(expected: 693));
			Assert.That(actual: catalog.Count, expression: Is.EqualTo(expected: 2));

			var group1 = catalog.FirstOrDefault();
			Assert.That(actual: group1, expression: Is.Not.Null);
			Assert.That(actual: group1.Id, expression: Is.EqualTo(expected: 21528946));
			Assert.That(actual: group1.Name, expression: Is.EqualTo(expected: "Kochut.Ювелирныеизделияподзаказ"));
			Assert.That(actual: group1.ScreenName, expression: Is.EqualTo(expected: "kochut"));
			Assert.That(actual: group1.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group1.Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: group1.IsAdmin, expression: Is.False);
			Assert.That(actual: group1.IsMember, expression: Is.False);

			Assert.That(actual: group1.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://cs7062.vk.me/c628023/v628023574/45681/YL78hc3tDzE.jpg")));

			Assert.That(actual: group1.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://cs7062.vk.me/c628023/v628023574/45680/ga_NTah7dDo.jpg")));

			Assert.That(actual: group1.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://cs7062.vk.me/c628023/v628023574/4567f/QD1aAZsZVHE.jpg")));

			var group2 = catalog.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: group2, expression: Is.Not.Null);
			Assert.That(actual: group2.Id, expression: Is.EqualTo(expected: 81178058));
			Assert.That(actual: group2.Name, expression: Is.EqualTo(expected: "Подушкисмайлы|интернетмагазин"));
			Assert.That(actual: group2.ScreenName, expression: Is.EqualTo(expected: "emoji.shop"));
			Assert.That(actual: group2.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group2.Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: group2.IsAdmin, expression: Is.False);
			Assert.That(actual: group2.IsMember, expression: Is.False);

			Assert.That(actual: group2.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629121/v629121767/1fb3a/nzbm9sfxlnI.jpg")));

			Assert.That(actual: group2.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629121/v629121767/1fb39/fz0oilONN9A.jpg")));

			Assert.That(actual: group2.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "https://pp.vk.me/c629121/v629121767/1fb38/gz5b7w4k7u4.jpg")));
		}

		[Test]
		public void GetCatalogInfo()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			Json = @"{
				response: {
					enabled: 1,
					categories: [{
						id: 0,
						name: 'Рекомендации'
					},
					{
						id: 1,
						name: 'Новости'
					},
					{
						id: 2,
						name: 'Спорт'
					},
					{
						id: 3,
						name: 'Музыка'
					},
					{
						id: 9,
						name: 'Радиоителевидение'
					},
					{
						id: 7,
						name: 'Наукаитехнологии'
					},
					{
						id: 4,
						name: 'Развлеченияиюмор'
					},
					{
						id: 12,
						name: 'Красотаистиль'
					},
					{
						id: 8,
						name: 'Культураиискусство'
					},
					{
						id: 10,
						name: 'Игрыикиберспорт'
					},
					{
						id: 13,
						name: 'Автомобили'
					},
					{
						id: 6,
						name: 'Бренды'
					},
					{
						id: 11,
						name: 'Магазины'
					}]
				}
			}";

			var catalogInfo = Api.Groups.GetCatalogInfo();
			Assert.That(actual: catalogInfo, expression: Is.Not.Null);
			Assert.That(actual: catalogInfo.Enabled, expression: Is.True);
			CollectionAssert.IsNotEmpty(collection: catalogInfo.Categories);
			Assert.That(actual: catalogInfo.Categories.Count(), expression: Is.EqualTo(expected: 13));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(actual: category, expression: Is.Not.Null);
			Assert.That(actual: category.Id, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: category.Name, expression: Is.EqualTo(expected: "Рекомендации"));
		}

		[Test]
		public void GetCatalogInfo_AllParams()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			Json = @"{
				response: {
					enabled: 1,
					categories: [{
						id: 6,
						name: 'Бренды',
						page_count: 162,
						page_previews: [{
							id: 30637940,
							name: 'KFCРоссия',
							screen_name: 'kfcrussia',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c631322/v631322521/2389b/G9mB6ONcyG8.jpg',
							photo_100: 'https://pp.vk.me/c631322/v631322521/2389a/qVAjs1J9yT8.jpg',
							photo_200: 'https://pp.vk.me/c631322/v631322521/23899/VDXY8eWi9JE.jpg'
						}]
					},
					{
						id: 11,
						name: 'Магазины',
						page_count: 696,
						page_previews: [{
							id: 55525992,
							name: 'АвточехлыSEATEX®|Автомобильныечехлы',
							screen_name: 'seatex',
							is_closed: 0,
							type: 'group',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c625729/v625729577/42d90/-ayhVQKKwuA.jpg',
							photo_100: 'https://pp.vk.me/c625729/v625729577/42d8f/zfp_vADJZ_E.jpg',
							photo_200: 'https://pp.vk.me/c625729/v625729577/42d8e/OtJWRTBoLrk.jpg'
						}],
						subcategories: [
						{
							id: 1,
							name: 'Детскиетовары',
							page_count: 63,
							page_previews: [{
								id: 104472144,
								name: 'Мягкаяигрушка""Мимиляндия""',
								screen_name: 'mimilyandiya',
								is_closed: 0,
								type: 'group',
								is_admin: 0,
								is_member: 0,
								photo_50: 'https://pp.vk.me/c628830/v628830962/1d8c7/zSJxvXXSsZk.jpg',
								photo_100: 'https://pp.vk.me/c628830/v628830962/1d8c6/XhyjV9Mwvp8.jpg',
								photo_200: 'https://pp.vk.me/c628830/v628830962/1d8c5/8PmGXLlDgqQ.jpg'
							}]
						},
						{
							id: 2,
							name: 'Электроника',
							page_count: 38,
							page_previews: [{
								id: 97587446,
								name: 'AstroBuy-купитьтелескоп,
								микроскоп,
								бинокль',
								screen_name: 'astrobuy',
								is_closed: 0,
								type: 'group',
								is_admin: 0,
								is_member: 0,
								photo_50: 'https://pp.vk.me/c628823/v628823905/277c4/3N1nHMnv2so.jpg',
								photo_100: 'https://pp.vk.me/c628823/v628823905/277c3/S1tPjT1fkqI.jpg',
								photo_200: 'https://pp.vk.me/c628823/v628823905/277c1/2zCWcZ-zQk4.jpg'
							}]
						}]
					}]
				}
			}";

			var catalogInfo = Api.Groups.GetCatalogInfo(extended: true, subcategories: true);
			Assert.That(actual: catalogInfo, expression: Is.Not.Null);
			Assert.That(actual: catalogInfo.Enabled, expression: Is.True);
			CollectionAssert.IsNotEmpty(collection: catalogInfo.Categories);
			Assert.That(actual: catalogInfo.Categories.Count(), expression: Is.EqualTo(expected: 2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(actual: category, expression: Is.Not.Null);
			Assert.That(actual: category.Id, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: category.Name, expression: Is.EqualTo(expected: "Бренды"));
			Assert.That(actual: category.PageCount, expression: Is.EqualTo(expected: 162));
			Assert.That(actual: category.PagePreviews.Count(), expression: Is.EqualTo(expected: 1));

			var category1 = catalogInfo.Categories.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: category1, expression: Is.Not.Null);
			Assert.That(actual: category1.Id, expression: Is.EqualTo(expected: 11));
			Assert.That(actual: category1.Name, expression: Is.EqualTo(expected: "Магазины"));
			Assert.That(actual: category1.PageCount, expression: Is.EqualTo(expected: 696));
			Assert.That(actual: category1.PagePreviews.Count(), expression: Is.EqualTo(expected: 1));
			CollectionAssert.IsNotEmpty(collection: category1.Subcategories);

			var sub1 = category1.Subcategories.FirstOrDefault();
			Assert.That(actual: sub1, expression: Is.Not.Null);
			Assert.That(actual: sub1.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: sub1.Name, expression: Is.EqualTo(expected: "Детскиетовары"));
			Assert.That(actual: sub1.PageCount, expression: Is.EqualTo(expected: 63));
			CollectionAssert.IsNotEmpty(collection: sub1.PagePreviews);

			var sub2 = category1.Subcategories.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: sub2, expression: Is.Not.Null);
			Assert.That(actual: sub2.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: sub2.Name, expression: Is.EqualTo(expected: "Электроника"));
			Assert.That(actual: sub2.PageCount, expression: Is.EqualTo(expected: 38));
			CollectionAssert.IsNotEmpty(collection: sub2.PagePreviews);
		}

		[Test]
		public void GetCatalogInfo_Extended()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			Json = @"{
				response: {
					enabled: 1,
					categories: [{
						id: 0,
						name: 'Рекомендации',
						page_count: 30,
						page_previews: [{
							id: 111572021,
							name: 'Реалити-шоу«НаЭкране»',
							screen_name: 'na_ekrane',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c629531/v629531353/29e68/1P32EV5zAxM.jpg',
							photo_100: 'https://pp.vk.me/c629531/v629531353/29e67/g-eu6gNO768.jpg',
							photo_200: 'https://pp.vk.me/c629531/v629531353/29e66/8rHS3aC7Nps.jpg'
						},
						{
							id: 101982925,
							name: 'МатчТВ',
							screen_name: 'matchtv',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c627817/v627817317/2c710/_0BJ4mIYCW8.jpg',
							photo_100: 'https://pp.vk.me/c627817/v627817317/2c70f/qkYU3iMrO30.jpg',
							photo_200: 'https://pp.vk.me/c627817/v627817317/2c70d/2fuHkWrOUro.jpg'
						}]
					},
					{
						id: 1,
						name: 'Новости',
						page_count: 21,
						page_previews: [{
							id: 68263002,
							name: 'TheNextWeb',
							screen_name: 'thenextweb',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c616216/v616216614/5f1a/EAgnMHjtbFc.jpg',
							photo_100: 'https://pp.vk.me/c616216/v616216614/5f19/WSyBxalc3cE.jpg',
							photo_200: 'https://pp.vk.me/c616216/v616216614/5f18/_5nXyMOAwr8.jpg'
						},
						{
							id: 43986871,
							name: 'Парламентскаягазета',
							screen_name: 'pnpru',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 0,
							photo_50: 'https://pp.vk.me/c307503/v307503831/6e62/z1EpCTQPyZQ.jpg',
							photo_100: 'https://pp.vk.me/c307503/v307503831/6e61/RP_fl1Q9tIw.jpg',
							photo_200: 'https://pp.vk.me/c307503/v307503831/6e60/bJnb2-6SSeA.jpg'
						}]
					}]
				}
			}";

			var catalogInfo = Api.Groups.GetCatalogInfo(extended: true);
			Assert.That(actual: catalogInfo, expression: Is.Not.Null);
			Assert.That(actual: catalogInfo.Enabled, expression: Is.True);
			CollectionAssert.IsNotEmpty(collection: catalogInfo.Categories);
			Assert.That(actual: catalogInfo.Categories.Count(), expression: Is.EqualTo(expected: 2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(actual: category, expression: Is.Not.Null);
			Assert.That(actual: category.Id, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: category.Name, expression: Is.EqualTo(expected: "Рекомендации"));
			Assert.That(actual: category.PageCount, expression: Is.EqualTo(expected: 30));
			Assert.That(actual: category.PagePreviews.Count(), expression: Is.EqualTo(expected: 2));

			var category1 = catalogInfo.Categories.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: category1, expression: Is.Not.Null);
			Assert.That(actual: category1.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: category1.Name, expression: Is.EqualTo(expected: "Новости"));
			Assert.That(actual: category1.PageCount, expression: Is.EqualTo(expected: 21));
			Assert.That(actual: category1.PagePreviews.Count(), expression: Is.EqualTo(expected: 2));
		}

		[Test]
		public void GetCatalogInfo_Subcategories()
		{
			Url = "https://api.vk.com/method/groups.getCatalogInfo";

			Json = @"{
				response: {
					enabled: 1,
					categories: [
					{
						id: 6,
						name: 'Бренды'
					},
					{
						id: 11,
						name: 'Магазины',
						subcategories: [
						{
							id: 1,
							name: 'Детскиетовары'
						},
						{
							id: 2,
							name: 'Электроника'
						}]
					}]
				}
			}";

			var catalogInfo = Api.Groups.GetCatalogInfo(extended: true, subcategories: true);
			Assert.That(actual: catalogInfo, expression: Is.Not.Null);
			Assert.That(actual: catalogInfo.Enabled, expression: Is.True);
			CollectionAssert.IsNotEmpty(collection: catalogInfo.Categories);
			Assert.That(actual: catalogInfo.Categories.Count(), expression: Is.EqualTo(expected: 2));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(actual: category, expression: Is.Not.Null);
			Assert.That(actual: category.Id, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: category.Name, expression: Is.EqualTo(expected: "Бренды"));

			var category1 = catalogInfo.Categories.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: category1, expression: Is.Not.Null);
			Assert.That(actual: category1.Id, expression: Is.EqualTo(expected: 11));
			Assert.That(actual: category1.Name, expression: Is.EqualTo(expected: "Магазины"));
			CollectionAssert.IsNotEmpty(collection: category1.Subcategories);

			var sub1 = category1.Subcategories.FirstOrDefault();
			Assert.That(actual: sub1, expression: Is.Not.Null);
			Assert.That(actual: sub1.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: sub1.Name, expression: Is.EqualTo(expected: "Детскиетовары"));

			var sub2 = category1.Subcategories.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: sub2, expression: Is.Not.Null);
			Assert.That(actual: sub2.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: sub2.Name, expression: Is.EqualTo(expected: "Электроника"));
		}

		[Test]
		public void GetInivites_NotInvites()
		{
			const string url = "https://api.vk.com/method/groups.getInvites";

			const string json =
					@"{
					response: {
						count: 0,
						items: []
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var groups = cat.GetInvites(count: 3, offset: 0);

			Assert.That(actual: groups, expression: Is.Not.Null);
			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetInvitedUsers_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getInvitedUsers";

			const string json =
					@"{
					'response': {
					  'count': 1,
					  'items': [
						{
						  'id': 221634238,
						  'first_name': 'Александру',
						  'last_name': 'Инютину',
						  'bdate': '23.6.2000'
						}
					  ]
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var users =
					cat.GetInvitedUsers(groupId: 103292418, offset: 0, count: 20, fields: UsersFields.BirthDate, nameCase: NameCase.Dat);

			Assert.That(actual: users, expression: Is.Not.Null);
			var user = users.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 221634238));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Александру"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Инютину"));
			Assert.That(actual: user.BirthDate, expression: Is.EqualTo(expected: "23.6.2000"));
		}

		[Test]
		public void GetInvites_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getInvites";

			const string json =
					@"{
					'response': {
					  count: 1,
					  items: [{
						'gid': 66528333,
						'name': 'группа 123',
						'screen_name': 'club66528333',
						'is_closed': 1,
						'type': 'group',
						'is_admin': 0,
						'is_member': 0,
						'photo': 'http://vk.com/images/community_50.gif',
						'photo_medium': 'http://vk.com/images/community_100.gif',
						'photo_big': 'http://vk.com/images/question_a.gif',
						'invited_by': 242508789
					  }]
					}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var groups = cat.GetInvites(count: 3, offset: 0);

			Assert.That(actual: groups, expression: Is.Not.Null);
			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 1));
			var group = groups.FirstOrDefault();
			Assert.That(actual: group, expression: Is.Not.Null);
			Assert.That(actual: group.Id, expression: Is.EqualTo(expected: 66528333));
			Assert.That(actual: group.Name, expression: Is.EqualTo(expected: "группа 123"));
			Assert.That(actual: group.ScreenName, expression: Is.EqualTo(expected: "club66528333"));
			Assert.That(actual: group.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Closed));
			Assert.That(actual: group.Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: group.IsAdmin, expression: Is.False);
			Assert.That(actual: group.IsMember, expression: Is.EqualTo(expected: false));

			Assert.That(actual: group.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://vk.com/images/community_50.gif")));

			Assert.That(actual: group.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://vk.com/images/community_100.gif")));

			Assert.That(actual: group.PhotoPreviews.PhotoMax
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://vk.com/images/question_a.gif")));

			Assert.That(actual: group.InvitedBy, expression: Is.EqualTo(expected: 242508789));
		}

		[Test]
		public void GetMembers_InvalidGid_ThrowsInvalidParameterException()
		{
			const string url = "https://api.vk.com/method/groups.getMembers";

			const string json =
					@"{
					'error': {
					  'error_code': 125,
					  'error_msg': 'Invalid group id',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.getMembers'
						},
						{
						  'key': 'gid',
						  'value': '-1'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			Assert.That(del: () => groups.GetMembers(@params: new GroupsGetMembersParams
			{
					GroupId = "0"
			}), expr: Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		public void GetMembers_NormalCase_ListOfUsesIds()
		{
			const string url = "https://api.vk.com/method/groups.getMembers";

			const string json =
					@"{
					'response': {
					  'count': 861,
					  'items': [
						116446865,
						485839,
						23483719,
						3428459,
						153698746,
						16080868,
						5054657,
						38690458
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			var ids = groups.GetMembers(@params: new GroupsGetMembersParams
			{
					GroupId = "17683660"
			});

			Assert.That(actual: ids.TotalCount, expression: Is.EqualTo(expected: 861));
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 8));

			Assert.That(actual: ids[index: 0].Id, expression: Is.EqualTo(expected: 116446865));
			Assert.That(actual: ids[index: 1].Id, expression: Is.EqualTo(expected: 485839));
			Assert.That(actual: ids[index: 2].Id, expression: Is.EqualTo(expected: 23483719));
			Assert.That(actual: ids[index: 3].Id, expression: Is.EqualTo(expected: 3428459));
			Assert.That(actual: ids[index: 4].Id, expression: Is.EqualTo(expected: 153698746));
			Assert.That(actual: ids[index: 5].Id, expression: Is.EqualTo(expected: 16080868));
			Assert.That(actual: ids[index: 6].Id, expression: Is.EqualTo(expected: 5054657));
			Assert.That(actual: ids[index: 7].Id, expression: Is.EqualTo(expected: 38690458));
		}

		[Test]
		public void GetMembers_NormalCaseAllInputParameters_ListOfUsesIds()
		{
			const string url = "https://api.vk.com/method/groups.getMembers";

			const string json =
					@"{
					'response': {
					  'count': 861,
					  'items': [
						1129147,
						1137997,
						1201582,
						1205554,
						1220166,
						1238937,
						1239796
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			var ids = groups.GetMembers(@params: new GroupsGetMembersParams
			{
					GroupId = "17683660"
					, Count = 7
					, Offset = 15
					, Sort = GroupsSort.IdAsc
			});

			Assert.That(actual: ids.TotalCount, expression: Is.EqualTo(expected: 861));
			Assert.That(actual: ids.Count, expression: Is.EqualTo(expected: 7));

			Assert.That(actual: ids[index: 0].Id, expression: Is.EqualTo(expected: 1129147));
			Assert.That(actual: ids[index: 1].Id, expression: Is.EqualTo(expected: 1137997));
			Assert.That(actual: ids[index: 2].Id, expression: Is.EqualTo(expected: 1201582));
			Assert.That(actual: ids[index: 3].Id, expression: Is.EqualTo(expected: 1205554));
			Assert.That(actual: ids[index: 4].Id, expression: Is.EqualTo(expected: 1220166));
			Assert.That(actual: ids[index: 5].Id, expression: Is.EqualTo(expected: 1238937));
			Assert.That(actual: ids[index: 6].Id, expression: Is.EqualTo(expected: 1239796));
		}

		[Test]
		public void GetSettings_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getSettings";

			const string json =
					@"{
					'response': {
						title: 'Test',
						description: 'TEST',
						address: 'club103292418',
						place: {
							id: 12991570,
							title: 'Test',
							latitude: 47.39719,
							longitude: 40.166811,
							created: 1443432436,
							icon: 'http://vk.com/images/places/place.png',
							group_id: 103292418,
							group_photo: 'https://vk.com/images/community_50.png',
							checkins: 0,
							type: 21,
							country: 1,
							city: 1079336,
							address: 'Октябрьская ул., 60'
						},
						wall: 1,
						photos: 1,
						video: 2,
						audio: 2,
						docs: 2,
						topics: 1,
						wiki: 1,
						access: 2,
						subject: 8,
						subject_list: [{
							id: 1,
							name: 'Авто/мото'
							}, {
							id: 2,
							name: 'Активный отдых'
							}, {
							id: 19,
							name: 'Безопасность'
							}, {
							id: 3,
							name: 'Бизнес'
							}, {
							id: 42,
							name: 'Дизайн и графика'
							}, {
							id: 29,
							name: 'Дом и семья'
							}, {
							id: 4,
							name: 'Домашние животные'
							}, {
							id: 5,
							name: 'Здоровье'
							}, {
							id: 6,
							name: 'Знакомство и общение'
							}, {
							id: 7,
							name: 'Игры'
							}, {
							id: 8,
							name: 'ИТ (компьютеры и софт)'
							}, {
							id: 9,
							name: 'Кино'
							}, {
							id: 10,
							name: 'Красота и мода'
							}, {
							id: 11,
							name: 'Кулинария'
							}, {
							id: 12,
							name: 'Культура и искусство'
							}, {
							id: 13,
							name: 'Литература'
							}, {
							id: 14,
							name: 'Мобильная связь и интернет'
							}, {
							id: 15,
							name: 'Музыка'
							}, {
							id: 16,
							name: 'Наука и техника'
							}, {
							id: 17,
							name: 'Недвижимость'
							}, {
							id: 18,
							name: 'Новости и СМИ'
							}, {
							id: 20,
							name: 'Образование'
							}, {
							id: 21,
							name: 'Обустройство и ремонт'
							}, {
							id: 41,
							name: 'Общество, гуманитарные науки'
							}, {
							id: 22,
							name: 'Политика'
							}, {
							id: 23,
							name: 'Продукты питания'
							}, {
							id: 24,
							name: 'Промышленность'
							}, {
							id: 25,
							name: 'Путешествия'
							}, {
							id: 26,
							name: 'Работа'
							}, {
							id: 27,
							name: 'Развлечения'
							}, {
							id: 28,
							name: 'Религия'
							}, {
							id: 30,
							name: 'Спорт'
							}, {
							id: 31,
							name: 'Страхование'
							}, {
							id: 32,
							name: 'Телевидение'
							}, {
							id: 33,
							name: 'Товары и услуги'
							}, {
							id: 34,
							name: 'Увлечения и хобби'
							}, {
							id: 35,
							name: 'Финансы'
							}, {
							id: 36,
							name: 'Фото'
							}, {
							id: 37,
							name: 'Эзотерика'
							}, {
							id: 38,
							name: 'Электроника и бытовая техника'
							}, {
							id: 39,
							name: 'Эротика'
							}, {
							id: 40,
							name: 'Юмор'
						}],
						website: 'http://vk.com/club103292418'
						}
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var groups = cat.GetSettings(groupId: 103292418);

			Assert.That(actual: groups, expression: Is.Not.Null);
			Assert.That(actual: groups.GroupId, expression: Is.EqualTo(expected: 103292418));
		}

		[Test]
		public void Invite_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.invite";

			const string json =
					@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);
			var users = cat.Invite(groupId: 103292418, userId: 221634238);

			Assert.That(actual: users, expression: Is.True);
		}

		[Test]
		[Ignore(reason: "Это открытый метод, не требующий access_token.")]
		public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(vk: new VkApi());

			Assert.That(del: () => groups.IsMember(groupId: "2", userId: 1, userIds: null, extended: null)
					, expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void IsMember_WrongGid_ThrowsInvalidParameterException()
		{
			const string url = "https://api.vk.com/method/groups.isMember";

			const string json =
					@"{
					'error': {
					  'error_code': 125,
					  'error_msg': 'Invalid group id',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.isMember'
						},
						{
						  'key': 'gid',
						  'value': '-1'
						},
						{
						  'key': 'uid',
						  'value': '4793858'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			var ex = Assert.Throws<InvalidGroupIdException>(code: () =>
					groups.IsMember(groupId: "0", userId: 4793858, userIds: null, extended: null));

			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "Invalid group id"));
		}

		[Test]
		public void IsMember_WrongUid_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/groups.isMember";

			const string json =
					@"{
					response: 0
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.IsMember(groupId: "637247", userId: 1000000000000, userIds: null, extended: null);
			Assert.That(actual: result.Count > 0 && result[index: 0].Member, expression: Is.False);
		}

		[Test]
		[Ignore(reason: "Это открытый метод, не требующий access_token.")]
		public void IsMemeber_UserAuthorizationFail_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.isMember";

			const string json =
					@"{
					'error': {
					  'error_code': 5,
					  'error_msg': 'User authorization failed: access_token was given to another ip address.',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.getMembers'
						},
						{
						  'key': 'gid',
						  'value': '637247'
						},
						{
						  'key': 'uid',
						  'value': '4793858'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			var ex = Assert.Throws<UserAuthorizationFailException>(code: () =>
					groups.IsMember(groupId: "637247", userId: 4793858, userIds: null, extended: null));

			Assert.That(actual: ex.Message,
					expression: Is.EqualTo(expected: "User authorization failed: access_token was given to another ip address."));
		}

		[Test]
		public void IsMemeber_UserIsAMember_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.isMember";

			const string json =
					@"{
					response: [{
						member: 1,
						user_id: 4793858
					}]
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.IsMember(groupId: "637247", userId: 4793858, userIds: null, extended: null);
			Assert.That(actual: result.Count > 0 && result[index: 0].Member, expression: Is.True);
		}

		[Test]
		public void IsMemeber_UserNotAMember_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/groups.isMember";

			const string json =
					@"{
					response: [{
						member: 0,
						user_id: 4793858
					}]
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.IsMember(groupId: "17683660", userId: 4793858, userIds: null, extended: null);
			Assert.That(actual: result.Count > 0 && result[index: 0].Member, expression: Is.False);
		}

		[Test]
		public void Join_AccessDenied_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/groups.join";

			const string json =
					@"{
					'error': {
					  'error_code': 7,
					  'error_msg': 'Permission to perform this action is denied',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.leave'
						},
						{
						  'key': 'text',
						  'value': 'test'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);

			Assert.That(del: () => groups.Join(groupId: 2, notSure: true)
					, expr: Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Test]
		public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(vk: new VkApi());
			Assert.That(del: () => groups.Join(groupId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Join_NormalCase_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.join";

			const string json =
					@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.Join(groupId: 2);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Join_NormalCaseNotSure_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.join";

			const string json =
					@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.Join(groupId: 2, notSure: true);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.join";

			const string json =
					@"{
					'error': {
					  'error_code': 5,
					  'error_msg': 'User authorization failed: access_token was given to another ip address.',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.join'
						},
						{
						  'key': 'gid',
						  'value': '40724899'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			Assert.That(del: () => groups.Join(groupId: 1), expr: Throws.InstanceOf<UserAuthorizationFailException>());
		}

		[Test]
		public void Join_WrongGid_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/groups.join";

			const string json =
					@"{
					'error': {
					  'error_code': 15,
					  'error_msg': 'Access denied: you can not join this private community',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.join'
						},
						{
						  'key': 'gid',
						  'value': '0'
						},
						{
						  'key': 'not_sure',
						  'value': '1'
						},
						{
						  'key': 'access_token',
						  'value': ''
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var ex = Assert.Throws<CannotBlacklistYourselfException>(code: () => groups.Join(groupId: 0, notSure: true));
			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "Access denied: you can not join this private community"));
		}

		[Test]
		public void Leave_AccessDenied_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/groups.leave";

			const string json =
					@"{
					'error': {
					  'error_code': 7,
					  'error_msg': 'Permission to perform this action is denied',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.leave'
						},
						{
						  'key': 'text',
						  'value': 'test'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			Assert.That(del: () => groups.Leave(groupId: 2), expr: Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Test]
		public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(vk: new VkApi());
			Assert.That(del: () => groups.Leave(groupId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Leave_NormalCase_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.leave";

			const string json =
					@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.Leave(groupId: 2);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.leave";

			const string json =
					@"{
					'error': {
					  'error_code': 5,
					  'error_msg': 'User authorization failed: access_token was given to another ip address.',
					  'request_params': [
						{
						  'key': 'oauth',
						  'value': '1'
						},
						{
						  'key': 'method',
						  'value': 'groups.join'
						},
						{
						  'key': 'gid',
						  'value': '40724899'
						},
						{
						  'key': 'access_token',
						  'value': 'token'
						}
					  ]
					}
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			Assert.That(del: () => groups.Leave(groupId: 1), expr: Throws.InstanceOf<UserAuthorizationFailException>());
		}

		[Test]
		public void Leave_WrongGid_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.leave";

			const string json =
					@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url: url, json: json);
			var result = groups.Leave(groupId: 0);

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Search_DefaulCaseAllParams_ListOfGroups()
		{
			const string url = "https://api.vk.com/method/groups.search";

			const string json =
					@"{
					'response': {
					  count: 78152,
					  items: [{
						'id': 26442631,
						'name': 'Music Quotes. First Public.',
						'screen_name': 'music_quotes_public',
						'is_closed': 0,
						'type': 'page',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs303205.userapi.com/g26442631/e_bcb8704f.jpg',
						'photo_100': 'http://cs303205.userapi.com/g26442631/d_a3627c6f.jpg',
						'photo_200': 'http://cs303205.userapi.com/g26442631/a_32dd770f.jpg'
					  },
					  {
						'id': 23727386,
						'name': 'Classical Music Humor',
						'screen_name': 'mushumor',
						'is_closed': 0,
						'type': 'page',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs10650.userapi.com/g23727386/e_8006da42.jpg',
						'photo_100': 'http://cs10650.userapi.com/g23727386/d_cbea0559.jpg',
						'photo_200': 'http://cs10650.userapi.com/g23727386/a_7743aab2.jpg'
					  },
					  {
						'id': 23995866,
						'name': 'E:\\music\\',
						'screen_name': 'e_music',
						'is_closed': 0,
						'type': 'page',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs9913.userapi.com/g23995866/e_319d8573.jpg',
						'photo_100': 'http://cs9913.userapi.com/g23995866/d_166572a9.jpg',
						'photo_200': 'http://cs9913.userapi.com/g23995866/a_fc553960.jpg'
					  }]
					}
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			var groups = category.Search(@params: new GroupsSearchParams
			{
					Query = "Music"
					, Offset = 20
					, Count = 3
			}, skipAuthorization: true);

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: groups.TotalCount, expression: Is.EqualTo(expected: 78152));

			Assert.That(actual: groups[index: 2].Id, expression: Is.EqualTo(expected: 23995866));
			Assert.That(actual: groups[index: 2].Name, expression: Is.EqualTo(expected: @"E:\music\"));
			Assert.That(actual: groups[index: 2].ScreenName, expression: Is.EqualTo(expected: "e_music"));
			Assert.That(actual: groups[index: 2].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 2].Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: groups[index: 2].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 2].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 2].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9913.userapi.com/g23995866/e_319d8573.jpg")));

			Assert.That(actual: groups[index: 2].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9913.userapi.com/g23995866/d_166572a9.jpg")));

			Assert.That(actual: groups[index: 2].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9913.userapi.com/g23995866/a_fc553960.jpg")));

			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 23727386));
			Assert.That(actual: groups[index: 1].Name, expression: Is.EqualTo(expected: "Classical Music Humor"));
			Assert.That(actual: groups[index: 1].ScreenName, expression: Is.EqualTo(expected: "mushumor"));
			Assert.That(actual: groups[index: 1].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 1].Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: groups[index: 1].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 1].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs10650.userapi.com/g23727386/e_8006da42.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs10650.userapi.com/g23727386/d_cbea0559.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs10650.userapi.com/g23727386/a_7743aab2.jpg")));

			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 26442631));
			Assert.That(actual: groups[index: 0].Name, expression: Is.EqualTo(expected: "Music Quotes. First Public."));
			Assert.That(actual: groups[index: 0].ScreenName, expression: Is.EqualTo(expected: "music_quotes_public"));
			Assert.That(actual: groups[index: 0].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 0].Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: groups[index: 0].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 0].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs303205.userapi.com/g26442631/e_bcb8704f.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs303205.userapi.com/g26442631/d_a3627c6f.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs303205.userapi.com/g26442631/a_32dd770f.jpg")));
		}

		[Test]
		public void Search_DefaultCase_ListOfGroups()
		{
			const string url = "https://api.vk.com/method/groups.search";

			const string json =
					@"{
					'response': {
					  count: 78152,
					  items:[{
						'id': 339767,
						'name': 'A-ONE HIP-HOP MUSIC CHANNEL',
						'screen_name': 'a1tv',
						'is_closed': 0,
						'type': 'group',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs9365.userapi.com/g339767/e_a590d16b.jpg',
						'photo_100': 'http://cs9365.userapi.com/g339767/d_f653c773.jpg',
						'photo_200': 'http://cs9365.userapi.com/g339767/a_4653ba99.jpg'
					  },
					  {
						'id': 27895931,
						'name': 'MUSIC 2012',
						'screen_name': 'exclusive_muzic',
						'is_closed': 0,
						'type': 'group',
						'is_admin': 0,
						'is_member': 0,
						'photo_50': 'http://cs410222.userapi.com/g27895931/e_d8c8a46f.jpg',
						'photo_100': 'http://cs410222.userapi.com/g27895931/d_2869e827.jpg',
						'photo_200': 'http://cs410222.userapi.com/g27895931/a_32935e91.jpg'
					  }]
					}
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			var groups = category.Search(@params: new GroupsSearchParams
			{
					Query = "Music"
			}, skipAuthorization: true);

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: groups.TotalCount, expression: Is.EqualTo(expected: 78152));

			Assert.That(actual: groups[index: 1].Id, expression: Is.EqualTo(expected: 27895931));
			Assert.That(actual: groups[index: 1].Name, expression: Is.EqualTo(expected: "MUSIC 2012"));
			Assert.That(actual: groups[index: 1].ScreenName, expression: Is.EqualTo(expected: "exclusive_muzic"));
			Assert.That(actual: groups[index: 1].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 1].Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: groups[index: 1].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 1].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs410222.userapi.com/g27895931/e_d8c8a46f.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs410222.userapi.com/g27895931/d_2869e827.jpg")));

			Assert.That(actual: groups[index: 1].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs410222.userapi.com/g27895931/a_32935e91.jpg")));

			Assert.That(actual: groups[index: 0].Id, expression: Is.EqualTo(expected: 339767));
			Assert.That(actual: groups[index: 0].Name, expression: Is.EqualTo(expected: "A-ONE HIP-HOP MUSIC CHANNEL"));
			Assert.That(actual: groups[index: 0].ScreenName, expression: Is.EqualTo(expected: "a1tv"));
			Assert.That(actual: groups[index: 0].IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: groups[index: 0].Type, expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: groups[index: 0].IsAdmin, expression: Is.False);
			Assert.That(actual: groups[index: 0].IsMember, expression: Is.False);

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo50,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9365.userapi.com/g339767/e_a590d16b.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo100,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9365.userapi.com/g339767/d_f653c773.jpg")));

			Assert.That(actual: groups[index: 0].PhotoPreviews.Photo200,
					expression: Is.EqualTo(expected: new Uri(uriString: "http://cs9365.userapi.com/g339767/a_4653ba99.jpg")));
		}

		[Test]
		public void Search_EmptyQuery_ThrowsArgumentException()
		{
			var groups = new GroupsCategory(vk: Api);

			Assert.That(del: () => groups.Search(@params: new GroupsSearchParams
			{
					Query = ""
			}), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void Search_GroupsNotFounded_EmptyList()
		{
			const string url = "https://api.vk.com/method/groups.search";

			const string json =
					@"{
					response: {
						count: 0,
						items: []
					}
				  }";

			var category = GetMockedGroupCategory(url: url, json: json);

			var groups = category.Search(@params: new GroupsSearchParams
			{
					Query = "ThisQueryDoesNotExistAtAll"
					, Offset = 20
					, Count = 3
			}, skipAuthorization: true);

			Assert.That(actual: groups.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: groups.TotalCount, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void UnbanUser_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.unbanUser";

			const string json =
					@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url: url, json: json);

			var result = cat.UnbanUser(groupId: 65960, userId: 242508);

			Assert.That(actual: result, expression: Is.True);
		}
	}
}