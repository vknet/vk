namespace VkNet.Tests.Categories
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using Moq;
	using NUnit.Framework;
	using VkNet.Categories;
	using VkNet.Utils;
	using FluentNUnit;

	using Enums;
	using Exception;
	using Model;
	using Enums.Filters;
	using Enums.SafetyEnums;


	[TestFixture]
	public class GroupsCategoryTest
	{
		[SetUp]
		public void SetUp()
		{

		}

		private GroupsCategory GetMockedGroupCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
			return new GroupsCategory(new VkApi { AccessToken = "token", Browser = browser });
		}

		[Test]
		public void Join_WrongGid_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/groups.join?group_id=0&not_sure=1&v=5.44&access_token=token";
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
			This.Action(() => groups.Join(0, true)).Throws<AccessDeniedException>()
				.Message.ShouldEqual("Access denied: you can not join this private community");
		}

		[Test]
		public void Leave_WrongGid_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.leave?group_id=0&v=5.44&access_token=token";
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
			const string url = "https://api.vk.com/method/groups.join?group_id=2&v=5.44&access_token=token";
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
			const string url = "https://api.vk.com/method/groups.join?group_id=2&not_sure=1&v=5.44&access_token=token";
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
			const string url = "https://api.vk.com/method/groups.leave?group_id=2&v=5.44&access_token=token";
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
			const string url = "https://api.vk.com/method/groups.join?group_id=2&not_sure=1&v=5.44&access_token=token";
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

			This.Action(() => groups.Join(2, true)).Throws<AccessDeniedException>();
		}

		[Test]
		public void Leave_AccessDenied_ThrowAccessDeniedException()
		{
			const string url = "https://api.vk.com/method/groups.leave?group_id=2&v=5.44&access_token=token";
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
			This.Action(() => groups.Leave(2)).Throws<AccessDeniedException>();
		}

		[Test]
		public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.Join(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.Leave(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.join?group_id=1&v=5.44&access_token=token";
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
			This.Action(() => groups.Join(1)).Throws<UserAuthorizationFailException>();
		}

		[Test]
		public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.leave?group_id=1&v=5.44&access_token=token";
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
			This.Action(() => groups.Leave(1)).Throws<UserAuthorizationFailException>();
		}

		[Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.Get(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Get_NormalCaseDefaultFields_ReturnOnlyGroupIds()
		{
			const string url = "https://api.vk.com/method/groups.get?user_id=4793858&offset=0&count=1000&v=5.44&access_token=token";

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
			var groups = category.Get(4793858).ToList();

			Assert.That(groups.Count, Is.EqualTo(5));
			Assert.That(groups[0].Id, Is.EqualTo(29689780));
			Assert.That(groups[1].Id, Is.EqualTo(33489538));
			Assert.That(groups[2].Id, Is.EqualTo(16108331));
			Assert.That(groups[3].Id, Is.EqualTo(40724899));
			Assert.That(groups[4].Id, Is.EqualTo(36346468));
		}

		[Test, Ignore]
		public void Get_NormalCaseAllFields_ReturnFullGroupInfo()
		{
			const string url =
				"https://api.vk.com/method/groups.get?uid=1&extended=1&filter=events&fields=city,country,place,description,wiki_page,members_count,counters,start_date,end_date,can_post,can_see_all_posts,can_create_topic,activity,status,contacts,links,fixed_post,verified,site&offset=0&count=1000&v=5.28&access_token=token";

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
			var groups = category.Get(1, true, GroupsFilters.Events, GroupsFields.All).ToList();

			Assert.That(groups[1].Id, Is.EqualTo(1181795));
			Assert.That(groups[1].Name, Is.EqualTo("Геннадий Бачинский"));
			Assert.That(groups[1].ScreenName, Is.EqualTo("club1181795"));
			Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(groups[1].City.Id, Is.EqualTo(1));
			Assert.That(groups[1].Country.Id, Is.EqualTo(1));
			Assert.That(groups[1].Description, Is.EqualTo("В связи с небольшим количеством..."));
			Assert.That(groups[1].StartDate, Is.EqualTo(new DateTime(2008, 1, 15, 7, 0, 0, DateTimeKind.Utc).ToLocalTime()));
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
			Assert.That(groups[0].StartDate, Is.EqualTo(new DateTime(2008, 04, 20, 14, 0, 30, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
			Assert.That(groups[0].IsAdmin, Is.False);
			Assert.That(groups[0].IsMember, Is.True);
			Assert.That(groups[0].PhotoPreviews.Photo50, Is.EqualTo("http://cs1122.userapi.com/g1153959/c_6d43acf8.jpg"));
			Assert.That(groups[0].PhotoPreviews.Photo100, Is.EqualTo("http://cs1122.userapi.com/g1153959/b_5bad925c.jpg"));
			Assert.That(groups[0].PhotoPreviews.Photo200, Is.EqualTo("http://cs1122.userapi.com/g1153959/a_3c9f63ea.jpg"));
		}

		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.GetById(1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var g = new GroupsCategory(new VkApi());
			This.Action(() => g.IsMember(2, 1)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void IsMemeber_UserAuthorizationFail_ThrowUserAuthorizationFailException()
		{
			const string url = "https://api.vk.com/method/groups.isMember?gid=637247&uid=4793858&access_token=token";
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

			This.Action(() => groups.IsMember(637247, 4793858)).Throws<UserAuthorizationFailException>()
				.Message.ShouldEqual("User authorization failed: access_token was given to another ip address.");
		}

		[Test]
		public void IsMember_WrongGid_ThrowsInvalidParameterException()
		{
			const string url = "https://api.vk.com/method/groups.isMember?gid=0&uid=4793858&access_token=token";
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
			This.Action(() => groups.IsMember(0, 4793858)).Throws<InvalidParameterException>()
				.Message.ShouldEqual("Invalid group id");
		}

		[Test]
		public void IsMember_WrongUid_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/groups.isMember?gid=637247&uid=0&access_token=token";
			const string json =
				@"{
					'response': 0
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember(637247, 0);
			Assert.That(result, Is.False);
		}

		[Test]
		public void IsMemeber_UserIsAMember_ReturnTrue()
		{
			const string url = "https://api.vk.com/method/groups.isMember?gid=637247&uid=4793858&access_token=token";
			const string json =
				@"{
					'response': 1
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember(637247, 4793858);
			Assert.That(result, Is.True);
		}

		[Test]
		public void IsMemeber_UserNotAMember_ReturnFalse()
		{
			const string url = "https://api.vk.com/method/groups.isMember?gid=17683660&uid=4793858&access_token=token";
			const string json =
				@"{
					'response': 0
				  }";

			var groups = GetMockedGroupCategory(url, json);
			var result = groups.IsMember(17683660, 4793858);
			Assert.That(result, Is.False);
		}

		[Test]
		public void GetMembers_NormalCase_ListOfUsesIds()
		{
			const string url = "https://api.vk.com/method/groups.getMembers?group_id=17683660&v=5.44&access_token=token";
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

			int totalCount;
			var ids = groups.GetMembers(17683660, out totalCount).ToList();

			Assert.That(totalCount, Is.EqualTo(861));
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
			const string url = "https://api.vk.com/method/groups.getMembers?group_id=17683660&sort=id_asc&offset=15&count=7&v=5.44&access_token=token";
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
			int totalCount;
			var ids = groups.GetMembers(17683660, out totalCount, 7, 15, GroupsSort.IdAsc).ToList();

			Assert.That(totalCount, Is.EqualTo(861));
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
			const string url = "https://api.vk.com/method/groups.getMembers?group_id=0&v=5.44&access_token=token";
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

			int totalCount;
			This.Action(() => groups.GetMembers(0, out totalCount)).Throws<InvalidParameterException>();
		}

		[Test]
		public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			int totalCount;
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.Search("Music", out totalCount)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void Search_EmptyQuery_ThrowsArgumentException()
		{
			int totalCount;

			var groups = new GroupsCategory(new VkApi { AccessToken = "token" });
			This.Action(() => groups.Search("", out totalCount)).Throws<ArgumentNullException>();
		}

		[Test]
		public void Search_DefaultCase_ListOfGroups()
		{
			const string url = "https://api.vk.com/method/groups.search?q=Music&sort=0&v=5.44&access_token=token";
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

			int totalCount;
			var category = GetMockedGroupCategory(url, json);
			var groups = category.Search("Music", out totalCount).ToList();

			Assert.That(groups.Count, Is.EqualTo(2));
			Assert.That(totalCount, Is.EqualTo(78152));

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
			const string url = "https://api.vk.com/method/groups.search?q=Music&sort=0&offset=20&count=3&v=5.44&access_token=token";
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

			int totalCount;
			var category = GetMockedGroupCategory(url, json);
			var groups = category.Search("Music", out totalCount, 20, 3).ToList();

			Assert.That(groups.Count, Is.EqualTo(3));
			Assert.That(totalCount, Is.EqualTo(78152));

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
			const string url = "https://api.vk.com/method/groups.search?q=ThisQueryDoesNotExistAtAll&sort=0&offset=20&count=3&v=5.44&access_token=token";

			const string json =
				@"{
					response: {
						count: 0,
						items: []
					}
				  }";

			var category = GetMockedGroupCategory(url, json);

			int totalCount;
			var groups = category.Search("ThisQueryDoesNotExistAtAll", out totalCount, 20, 3).ToList();

			Assert.That(groups.Count, Is.EqualTo(0));
			Assert.That(totalCount, Is.EqualTo(0));
		}

		[Test]
		public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			var groups = new GroupsCategory(new VkApi());
			This.Action(() => groups.GetById(2)).Throws<AccessTokenInvalidException>();
		}

		[Test]
		public void GetById_NormalCaseDefaultFields_ReturnTwoItems()
		{
			const string url = "https://api.vk.com/method/groups.getById?group_id=17683660&v=5.44&access_token=token";
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
			var g = cat.GetById(17683660);

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
			const string url = "https://api.vk.com/method/groups.getById?group_id=0&v=5.44&access_token=token";
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

			This.Action(() => cat.GetById(0)).Throws<InvalidParameterException>();
		}

		[Test]
		public void GetById_BanInfo()
		{
			const string url = "https://api.vk.com/method/groups.getById?group_id=66464944&fields=ban_info&v=5.44&access_token=token";
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

			var group = cat.GetById(66464944, GroupsFields.BanInfo);
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
			const string url = "https://api.vk.com/method/groups.getById?group_ids=0&v=5.44&access_token=token";
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

			This.Action(() => cat.GetById(new long[] { 0 })).Throws<InvalidParameterException>();
		}

		[Test]
		public void GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems()
		{
			const string url = "https://api.vk.com/method/groups.getById?group_ids=17683660,637247&v=5.44&access_token=token";
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
			var groups = cat.GetById(new long[] { 17683660, 637247 }).ToList();

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

		[Test, Ignore]
		public void GetById_Multiple_NormalCaseAllFields_ReturnTwoItems()
		{
			const string url =
				"https://api.vk.com/method/groups.getById?gids=17683660,637247&fields=city,country,place,description,wiki_page,members_count,counters,start_date,end_date,can_post,can_see_all_posts,can_create_topic,activity,status,contacts,links,fixed_post,verified,site&access_token=token";
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

			var groups = category.GetById(new long[] { 17683660, 637247 }, GroupsFields.All).ToList();

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
			Assert.That(groups[0].StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0)));

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

		[Test, Ignore]
		public void GetById_NormalCaseAllFields_ReturnTwoItems()
		{
			const string url =
				"https://api.vk.com/method/groups.getById?gid=17683660&fields=city,country,place,description,wiki_page,members_count,counters,start_date,end_date,can_post,can_see_all_posts,can_create_topic,activity,status,contacts,links,fixed_post,verified,site&access_token=token";
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
			var @group = category.GetById(17683660, GroupsFields.All);

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
			Assert.That(@group.StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0)));
		}

		[Test]
		public void GetInvites_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getInvites?offset=0&count=3&v=5.44&access_token=token";
			const string json =
			@"{
					'response': [
					  1,
					  {
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
					  }
					]
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var groups = cat.GetInvites(3, 0);

			groups.ShouldNotBeNull();
			groups.Count.ShouldEqual(1);

			Assert.That(groups[0].Id, Is.EqualTo(66528333));
			groups[0].Name.ShouldEqual("группа 123");
			groups[0].ScreenName.ShouldEqual("club66528333");
			groups[0].IsClosed.ShouldEqual(GroupPublicity.Closed);
			groups[0].Type.ShouldEqual(GroupType.Group);
			groups[0].IsAdmin.ShouldBeFalse();
			groups[0].IsMember.ShouldEqual(false);
			groups[0].PhotoPreviews.Photo50.ShouldEqual(new Uri("http://vk.com/images/community_50.gif"));
			groups[0].PhotoPreviews.Photo100.ShouldEqual(new Uri("http://vk.com/images/community_100.gif"));
			groups[0].PhotoPreviews.PhotoMax.ShouldEqual(new Uri("http://vk.com/images/question_a.gif"));
			Assert.That(groups[0].InvitedBy, Is.EqualTo(242508789));
		}

		[Test]
		public void GetInivites_NotInvites()
		{
			const string url = "https://api.vk.com/method/groups.getInvites?offset=0&count=3&v=5.44&access_token=token";
			const string json =
				@"{
					'response': [
					  0
					]
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var groups = cat.GetInvites(3, 0);

			groups.ShouldNotBeNull();
			groups.Count.ShouldEqual(0);
		}

		[Test]
		public void BanUser_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.banUser?group_id=6596823&user_id=242506753&comment=просто комментарий&comment_visible=1&access_token=token";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var result = cat.BanUser(6596823, 242506753, comment: "просто комментарий", commentVisible: true);

			result.ShouldBeTrue();
		}

		[Test]
		public void GetBanned_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getBanned?group_id=65968111&count=3&v=5.44&access_token=token";
			const string json =
			@"{
					'response': [
					  1,
					  {
						'uid': 242508345,
						'first_name': 'Маша',
						'last_name': 'Иванова',
						'ban_info': {
						  'admin_id': 234695672,
						  'date': 1392543301,
						  'reason': 1,
						  'comment': 'просто комментарий',
						  'end_date': 1392802497
						}
					  }
					]
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var users = cat.GetBanned(65968111,null, 3);

			users.ShouldNotBeNull();
			users.Count.ShouldEqual(1);

			users[0].Id = 242508345;
			users[0].FirstName = "Маша";
			users[0].LastName = "Иванова";
			users[0].BanInfo.AdminId.ShouldEqual(234695672);
			users[0].BanInfo.Date.ShouldEqual(new DateTime(2014, 2, 16, 9, 35, 1, DateTimeKind.Utc).ToLocalTime());
			users[0].BanInfo.Reason.ShouldEqual(BanReason.Spam);
			users[0].BanInfo.Comment.ShouldEqual("просто комментарий");
			users[0].BanInfo.EndDate.ShouldEqual(new DateTime(2014, 2, 19, 9, 34, 57, DateTimeKind.Utc).ToLocalTime());
		}

		[Test]
		public void UnbanUser_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.unbanUser?group_id=65960&user_id=242508&v=5.44&access_token=token";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);

			var result = cat.UnbanUser(65960, 242508);

			result.ShouldBeTrue();
		}

		[Test]
		public void GetSettings_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getSettings?group_id=103292418&v=5.44&access_token=token";
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

			groups.ShouldNotBeNull();
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.edit?group_id=103292418&title=Raven&v=5.44&access_token=token";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);
			var group = new GroupInfo
			{
				Title = "Raven"
			};
			var groups = cat.Edit(103292418, group);

			groups.ShouldBeTrue();
		}

		[Test]
		public void EditPlace_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.editPlace?group_id=103292418&title=Test&address=1&country_id=1&city_id=1&latitude=30&longitude=30&v=5.44&access_token=token";
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

			groups.ShouldBeTrue();
		}

		[Test]
		public void GetInvitedUsers_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.getInvitedUsers?group_id=103292418&offset=0&count=20&fields=bdate&name_case=dat&v=5.44&access_token=token";
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
			int count;
			var users = cat.GetInvitedUsers(103292418, out count, 0, 20, UsersFields.BirthDate, NameCase.Dat);

			users.ShouldNotBeNull();

			users[0].Id = 221634238;
			users[0].FirstName = "Александру";
			users[0].LastName = "Инютину";
			users[0].BirthDate = "23.6.2000";
		}

		[Test]
		public void Invite_NormalCase()
		{
			const string url = "https://api.vk.com/method/groups.invite?group_id=103292418&user_id=221634238&v=5.44&access_token=token";
			const string json =
				@"{
					'response': 1
				  }";

			var cat = GetMockedGroupCategory(url, json);
			var users = cat.Invite(103292418, 221634238);

			users.ShouldBeTrue();
		}
	}
}