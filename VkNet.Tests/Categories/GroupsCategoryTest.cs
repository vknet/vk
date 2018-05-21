using System.Collections.Generic;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	using System;
	using System.Linq;
	using NUnit.Framework;
	using VkNet.Categories;
	using Enums;
	using Model;
	using Enums.Filters;
	using Enums.SafetyEnums;

	[TestFixture]
	public class GroupsCategoryTest : BaseTest
	{
		private GroupsCategory GetMockedGroupCategory(string url, string json)
		{
            Json = json;
            Url = url;
            return new GroupsCategory(Api);
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

			var groups = GetMockedGroupCategory(url, json);
			var ex = Assert.Throws<CannotBlacklistYourselfException>(() => groups.Join(0, true));
			Assert.That(ex.Message, Is.EqualTo("Access denied: you can not join this private community"));
		}

		[Test]
		public void Leave_WrongGid_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.leave";
			const string json =
				@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.Leave(0);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Join_NormalCase_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.join";
			const string json =
				@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.Join(2);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Join_NormalCaseNotSure_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.join";
			const string json =
				@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.Join(2, true);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Leave_NormalCase_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.leave";
			const string json =
				@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.Leave(2);

			Assert.That(result, Is.True);
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

			var groups = GetMockedGroupCategory(url, json);
			Assert.That(() => groups.Join(2, true), Throws.InstanceOf<PermissionToPerformThisActionException>());
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

			var groups = GetMockedGroupCategory(url, json);
			Assert.That(() => groups.Leave(2), Throws.InstanceOf<PermissionToPerformThisActionException>());
		}

		[Test]
		public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.Join(1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.Leave(1), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var groups = GetMockedGroupCategory(url, json);
			Assert.That(() => groups.Join(1), Throws.InstanceOf<UserAuthorizationFailException>());
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

			var groups = GetMockedGroupCategory(url, json);
			Assert.That(() => groups.Leave(1), Throws.InstanceOf<UserAuthorizationFailException>());
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

			var category = GetMockedGroupCategory(url, json);
			var groups = category.Get(new GroupsGetParams
			{
				UserId = 4793858
			}).ToList();

			Assert.That(groups.Count, Is.EqualTo(5));
			Assert.That(groups[0].Id, Is.EqualTo(29689780));
			Assert.That(groups[1].Id, Is.EqualTo(33489538));
			Assert.That(groups[2].Id, Is.EqualTo(16108331));
			Assert.That(groups[3].Id, Is.EqualTo(40724899));
			Assert.That(groups[4].Id, Is.EqualTo(36346468));
		}

		[Test, Ignore("")]
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

			var category = GetMockedGroupCategory(url, json);
			// 1, true, GroupsFilters.Events, GroupsFields.All
			var groups = category.Get(new GroupsGetParams
			{
				UserId = 1,
				Extended = true,
				Filter = GroupsFilters.Events,
				Fields = GroupsFields.All
			}).ToList();

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

		[Test, Ignore("Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.GetById(new List<string>(),"1", null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test, Ignore("Это открытый метод, не требующий access_token.")]
		public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.IsMember("2", 1, null, null), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test, Ignore("Это открытый метод, не требующий access_token.")]
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

			var groups = GetMockedGroupCategory(url, json);
			var ex = Assert.Throws<UserAuthorizationFailException>(() => groups.IsMember("637247", 4793858, null, null));
			Assert.That(ex.Message, Is.EqualTo("User authorization failed: access_token was given to another ip address."));
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

			var groups = GetMockedGroupCategory(url, json);
			var ex = Assert.Throws<InvalidGroupIdException>(() => groups.IsMember("0", 4793858,null,null));
			Assert.That(ex.Message, Is.EqualTo("Invalid group id"));
		}

		[Test]
		public void IsMember_WrongUid_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/groups.isMember";
            const string json =
				@"{
					response: 0
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember("637247", 1000000000000,null,null);
			Assert.That(result.Count > 0 && result[0].Member, Is.False);
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

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember("637247", 4793858,null,null);
			Assert.That(result.Count > 0 && result[0].Member, Is.True);
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

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember("17683660", 4793858,null,null);
			Assert.That(result.Count > 0 && result[0].Member, Is.False);
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

			var groups = GetMockedGroupCategory(url, json);

			var ids = groups.GetMembers(new GroupsGetMembersParams
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

			var groups = GetMockedGroupCategory(url, json);
			
			var ids = groups.GetMembers(new GroupsGetMembersParams
			{
				GroupId = "17683660",
				Count = 7,
				Offset = 15,
				Sort = GroupsSort.IdAsc
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

			var groups = GetMockedGroupCategory(url, json);

			Assert.That(() => groups.GetMembers(new GroupsGetMembersParams
			{
				GroupId = "0"
			}), Throws.InstanceOf<InvalidGroupIdException>());
		}

		[Test]
		public void Search_EmptyQuery_ThrowsArgumentException()
		{
			var groups = new GroupsCategory(Api);
			Assert.That(() => groups.Search(new GroupsSearchParams
			{
				Query = ""
			}), Throws.InstanceOf<ArgumentException>());
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

			var category = GetMockedGroupCategory(url, json);
            var groups = category.Search(new GroupsSearchParams
            {
                Query = "Music"
            }, true);
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

			var category = GetMockedGroupCategory(url, json);
            var groups = category.Search(new GroupsSearchParams
            {
                Query = "Music",
                Offset = 20,
                Count = 3
            }, true);

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

			var category = GetMockedGroupCategory(url, json);

            var groups = category.Search(new GroupsSearchParams
            {
                Query = "ThisQueryDoesNotExistAtAll",
                Offset = 20,
                Count = 3
            }, true);

            Assert.That(groups.Count, Is.EqualTo(0));
			Assert.That(groups.TotalCount, Is.EqualTo(0));
		}

		[Test, Ignore("Этот метод можно вызвать без ключа доступа. Возвращаются только общедоступные данные.")]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			Assert.That(() => groups.GetById(new List<string>(), "2", null), Throws.InstanceOf<AccessTokenInvalidException>());
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

			var cat = GetMockedGroupCategory(url, json);
			var g = cat.GetById(new List<string>(), "17683660", null).FirstOrDefault();

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

			var cat = GetMockedGroupCategory(url, json);

			Assert.That(() => cat.GetById(new List<string>(), "0", null), Throws.InstanceOf<InvalidGroupIdException>());
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

			var cat = GetMockedGroupCategory(url, json);

			var group = cat.GetById(new List<string>(), "66464944", GroupsFields.BanInfo).FirstOrDefault();
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

			var cat = GetMockedGroupCategory(url, json);

			Assert.That(() => cat.GetById(new [] { "0" }, null, null), Throws.InstanceOf<InvalidGroupIdException>());
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

			var cat = GetMockedGroupCategory(url, json);
			var groups = cat.GetById(new [] { "17683660","637247" }, null, null).ToList();

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

		[Test, Ignore("")]
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

			var category = GetMockedGroupCategory(url, json);

			var groups = category.GetById(new [] { "17683660", "637247" }, null, GroupsFields.All).ToList();

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

		[Test, Ignore("")]
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

			var category = GetMockedGroupCategory(url, json);
			var @group = category.GetById(new List<string>(), "17683660", GroupsFields.All).FirstOrDefault();

			Assert.That(@group.Id, Is.EqualTo(17683660));
			Assert.That(@group.Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
			Assert.That(@group.ScreenName, Is.EqualTo("club17683660"));
			Assert.That(@group.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(@group.IsAdmin, Is.False);
			Assert.That(@group.Type, Is.EqualTo(GroupType.Event));
			Assert.That(@group.IsMember, Is.False);
			Assert.That(@group.PhotoPreviews.Photo50, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));
			Assert.That(@group.PhotoPreviews.Photo100, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));
			Assert.That(@group.PhotoPreviews.Photo200, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));
			Assert.That(@group.City.Id, Is.EqualTo(95));
			Assert.That(@group.Country.Id, Is.EqualTo(1));
			Assert.That(@group.Description, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля<br>...."));
			Assert.That(@group.StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0, DateTimeKind.Utc)));
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

			var cat = GetMockedGroupCategory(url, json);

			var groups = cat.GetInvites(3, 0);

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

			var cat = GetMockedGroupCategory(url, json);

			var groups = cat.GetInvites(3, 0);

			Assert.That(groups, Is.Not.Null);
			Assert.That(groups.Count, Is.EqualTo(0));
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

			var cat = GetMockedGroupCategory(url, json);

			var result = cat.BanUser(new GroupsBanUserParams
			{
				GroupId = 6596823,
				UserId = 242506753, 
				Comment = "просто комментарий",
				CommentVisible = true
			});

			Assert.That(result, Is.True);
		}

		[Test]
		public void UnbanUser_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.unbanUser";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var result = cat.UnbanUser(65960, 242508);

			Assert.That(result, Is.True);
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

			var cat = GetMockedGroupCategory(url, json);

			var groups = cat.GetSettings(103292418);

			Assert.That(groups, Is.Not.Null);
            Assert.That(groups.GroupId, Is.EqualTo(103292418));
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.edit";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);
			var group = new GroupsEditParams
            {
                GroupId = 103292418,
                Title = "Raven"
			};
            var groups = cat.Edit(group);

            Assert.That(groups, Is.True);
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

			var cat = GetMockedGroupCategory(url, json);
			var place = new Place
			{
				Title = "Test",
				CityId = 1,
				CountryId = 1,
				Longitude = 30,
				Latitude = 30,
				Address = "1"
			};
			var groups = cat.EditPlace(103292418, place);

			Assert.That(groups, Is.True);
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

			var cat = GetMockedGroupCategory(url, json);
			var users = cat.GetInvitedUsers(103292418, 0, 20, UsersFields.BirthDate, NameCase.Dat);

			Assert.That(users, Is.Not.Null);
			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Id, Is.EqualTo(221634238));
			Assert.That(user.FirstName, Is.EqualTo("Александру"));
			Assert.That(user.LastName, Is.EqualTo("Инютину"));
			Assert.That(user.BirthDate, Is.EqualTo("23.6.2000"));
		}

		[Test]
		public void Invite_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.invite";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);
			var users = cat.Invite(103292418, 221634238);

			Assert.That(users, Is.True);
		}

		#region GetCatalog

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
		#endregion

		#region GetCatalogInfo

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
			Assert.That(catalogInfo, Is.Not.Null);
			Assert.That(catalogInfo.Enabled, Is.True);
			CollectionAssert.IsNotEmpty(catalogInfo.Categories);
			Assert.That(catalogInfo.Categories.Count(), Is.EqualTo(13));

			var category = catalogInfo.Categories.FirstOrDefault();
			Assert.That(category, Is.Not.Null);
			Assert.That(category.Id, Is.EqualTo(0));
			Assert.That(category.Name, Is.EqualTo("Рекомендации"));
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
		#endregion

	}
}