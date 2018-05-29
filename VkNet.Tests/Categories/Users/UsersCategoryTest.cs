using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class UsersCategoryTest : BaseTest
	{
		private const string Query = "Masha Ivanova";

		private UsersCategory GetMockedUsersCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new UsersCategory(vk: Api);
		}

		[Test]
		public void Get_NotAccessToInternet_ThrowVkApiException()
		{
			Mock.Get(mocked: Api.RestClient)
					.Setup(expression: f =>
							f.PostAsync(uri: It.IsAny<Uri>(), parameters: It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
					.Throws(exception: new VkApiException(message: "The remote name could not be resolved: 'api.vk.com'"));

			var ex = Assert.Throws<VkApiException>(code: () => Api.Users.Get(userIds: new long[] { 1 }));
			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "The remote name could not be resolved: 'api.vk.com'"));
		}

		[Test]
		[Ignore(reason: "Метод может быть вызван без авторизации")]
		public void Get_WrongAccesToken_Throw_ThrowUserAuthorizationException()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'error': {
                      'error_code': 5,
                      'error_msg': 'User authorization failed: invalid access_token.',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'getProfiles'
                        },
                        {
                          'key': 'uid',
                          'value': '1'
                        },
                        {
                          'key': 'access_token',
                          'value': 'sfastybdsjhdg'
                        }
                      ]
                    }
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);
			var ex = Assert.Throws<UserAuthorizationFailException>(code: () => users.Get(userId: 1));
			Assert.That(actual: ex.Message, expression: Is.EqualTo(expected: "User authorization failed: invalid access_token."));
		}

		[Test]
		public void Get_WithSomeFields_FirstNameLastNameEducation()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров',
                        'university': 1,
                        'university_name': 'СПбГУ',
                        'faculty': 0,
                        'faculty_name': '',
                        'graduation': 2006
                      }
                    ]
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);

			// act
			var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Education;
			var user = users.Get(userId: 1, fields: fields);

			// assert
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дуров"));
			Assert.That(actual: user.Education, expression: Is.Not.Null);
			Assert.That(actual: user.Education.UniversityId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Education.UniversityName, expression: Is.EqualTo(expected: "СПбГУ"));
			Assert.That(actual: user.Education.FacultyId, expression: Is.Null);
			Assert.That(actual: user.Education.FacultyName, expression: Is.EqualTo(expected: ""));
			Assert.That(actual: user.Education.Graduation, expression: Is.EqualTo(expected: 2006));
		}

		[Test]
		public void Get_CountersFields_CountersObject()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров',
                        'counters': {
                          'albums': 1,
                          'videos': 8,
                          'audios': 0,
                          'notes': 6,
                          'photos': 153,
                          'friends': 689,
                          'online_friends': 85,
                          'mutual_friends': 0,
                          'followers': 5937280,
                          'subscriptions': 0,
                          'pages': 51
                        }
                      }
                    ]
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);

			// act
			var user = users.Get(userId: 1, fields: ProfileFields.Counters);

			// assert
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дуров"));
			Assert.That(actual: user.Counters, expression: Is.Not.Null);
			Assert.That(actual: user.Counters.Albums, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Counters.Videos, expression: Is.EqualTo(expected: 8));
			Assert.That(actual: user.Counters.Audios, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Notes, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: user.Counters.Photos, expression: Is.EqualTo(expected: 153));
			Assert.That(actual: user.Counters.Friends, expression: Is.EqualTo(expected: 689));
			Assert.That(actual: user.Counters.OnlineFriends, expression: Is.EqualTo(expected: 85));
			Assert.That(actual: user.Counters.MutualFriends, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Followers, expression: Is.EqualTo(expected: 5937280));
			Assert.That(actual: user.Counters.Subscriptions, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Pages, expression: Is.EqualTo(expected: 51));
		}

		[Test]
		public void Get_DefaultFields_UidFirstNameLastName()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров'
                      }
                    ]
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);

			// act
			var user = users.Get(userId: 1);

			// assert
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дуров"));
		}

		[Test]
		public void Get_EmptyListOfUids_ThrowArgumentNullException()
		{
			IEnumerable<long> userIds = null;
			Assert.That(del: () => Api.Users.Get(userIds: userIds), expr: Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void Get_Mutliple_TwoUidsDefaultFields_TwoProfiles()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров'
                      },
                      {
                        'id': 672,
                        'first_name': 'Кристина',
                        'last_name': 'Смирнова'
                      }
                    ]
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);

			var lst = users.Get(userIds: new long[]
			{
					1
					, 672
			});

			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: lst[index: 0], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: lst[index: 0].FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: lst[index: 0].LastName, expression: Is.EqualTo(expected: "Дуров"));

			Assert.That(actual: lst[index: 1], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 1].Id, expression: Is.EqualTo(expected: 672));
			Assert.That(actual: lst[index: 1].FirstName, expression: Is.EqualTo(expected: "Кристина"));
			Assert.That(actual: lst[index: 1].LastName, expression: Is.EqualTo(expected: "Смирнова"));
		}

		[Test]
		public void Get_TwoUidsEducationField_TwoProfiles()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров',
                        'university': 1,
                        'university_name': 'СПбГУ',
                        'faculty': 0,
                        'faculty_name': '',
                        'graduation': 2006
                      },
                      {
                        'id': 5041431,
                        'first_name': 'Тайфур',
                        'last_name': 'Касеев',
                        'university': 431,
                        'university_name': 'ВолгГТУ',
                        'faculty': 3162,
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': 2012,
                        'education_form': 'Дневное отделение',
                        'education_status': 'Студент (специалист)'
                      }
                    ]
                  }";

			var users = GetMockedUsersCategory(url: url, json: json);

			var lst = users.Get(userIds: new long[]
			{
					1
					, 5041431
			}, fields: ProfileFields.Education);

			Assert.That(condition: lst.Count == 2);
			Assert.That(actual: lst[index: 0], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: lst[index: 0].FirstName, expression: Is.EqualTo(expected: "Павел"));
			Assert.That(actual: lst[index: 0].LastName, expression: Is.EqualTo(expected: "Дуров"));
			Assert.That(actual: lst[index: 0].Education, expression: Is.Not.Null);
			Assert.That(actual: lst[index: 0].Education.UniversityId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: lst[index: 0].Education.UniversityName, expression: Is.EqualTo(expected: "СПбГУ"));
			Assert.That(actual: lst[index: 0].Education.FacultyId, expression: Is.Null);
			Assert.That(actual: lst[index: 0].Education.FacultyName, expression: Is.Null.Or.Empty);
			Assert.That(actual: lst[index: 0].Education.Graduation, expression: Is.EqualTo(expected: 2006));

			Assert.That(actual: lst[index: 1], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 1].Id, expression: Is.EqualTo(expected: 5041431));
			Assert.That(actual: lst[index: 1].FirstName, expression: Is.EqualTo(expected: "Тайфур"));
			Assert.That(actual: lst[index: 1].LastName, expression: Is.EqualTo(expected: "Касеев"));
			Assert.That(actual: lst[index: 1].Education, expression: Is.Not.Null);
			Assert.That(actual: lst[index: 1].Education.UniversityId, expression: Is.EqualTo(expected: 431));
			Assert.That(actual: lst[index: 1].Education.UniversityName, expression: Is.EqualTo(expected: "ВолгГТУ"));
			Assert.That(actual: lst[index: 1].Education.FacultyId, expression: Is.EqualTo(expected: 3162));

			Assert.That(actual: lst[index: 1].Education.FacultyName
					, expression: Is.EqualTo(expected: "Электроники и вычислительной техники"));

			Assert.That(actual: lst[index: 1].Education.Graduation, expression: Is.EqualTo(expected: 2012));
		}

		[Test]
		public void Search_BadQuery_EmptyList()
		{
			const string url = "https://api.vk.com/method/users.search";

			const string json =
					@"{
					response: {
						count: 0,
						items: []
					}
				}";

			var users = GetMockedUsersCategory(url: url, json: json);
			var lst = users.Search(@params: new UserSearchParams { Query = "fa'sosjvsoidf" });

			Assert.That(actual: lst.TotalCount, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: lst, expression: Is.Not.Null);
			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void Search_EducationField_ListofProfileObjects()
		{
			const string url = "https://api.vk.com/method/users.search";

			const string json =
					@"{
					response: {
						count: 26953,
						items: [
							{
								'uid': 165614770,
								'first_name': 'Маша',
								'last_name': 'Иванова',
								'university': '0',
								'university_name': '',
								'faculty': '0',
								'faculty_name': '',
								'graduation': '0'
							},
							{
								'uid': 174063570,
								'first_name': 'Маша',
								'last_name': 'Иванова',
								'university': '0',
								'university_name': '',
								'faculty': '0',
								'faculty_name': '',
								'graduation': '0'
							},
							{
								'uid': 76817368,
								'first_name': 'Маша',
								'last_name': 'Иванова',
								'university': '0',
								'university_name': '',
								'faculty': '0',
								'faculty_name': '',
								'graduation': '0'
							}
						]
					}
				}";

			var users = GetMockedUsersCategory(url: url, json: json);

			var lst = users.Search(@params: new UserSearchParams
			{
					Query = Query
					, Fields = ProfileFields.Education
					, Count = 3
					, Offset = 123
			});

			Assert.That(actual: lst.TotalCount, expression: Is.EqualTo(expected: 26953));
			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: lst[index: 0], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 0].Id, expression: Is.EqualTo(expected: 165614770));
			Assert.That(actual: lst[index: 0].FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: lst[index: 0].LastName, expression: Is.EqualTo(expected: "Иванова"));
			Assert.That(actual: lst[index: 0].Education, expression: Is.Null);

			Assert.That(actual: lst[index: 1], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 1].Id, expression: Is.EqualTo(expected: 174063570));
			Assert.That(actual: lst[index: 1].FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: lst[index: 1].LastName, expression: Is.EqualTo(expected: "Иванова"));
			Assert.That(actual: lst[index: 1].Education, expression: Is.Null);

			Assert.That(actual: lst[index: 2], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 2].Id, expression: Is.EqualTo(expected: 76817368));
			Assert.That(actual: lst[index: 2].FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: lst[index: 2].LastName, expression: Is.EqualTo(expected: "Иванова"));
			Assert.That(actual: lst[index: 2].Education, expression: Is.Null);
		}

		[Test]
		public void Search_CarierCase()
		{
			const string url = "https://api.vk.com/method/users.search";

			const string json =
					@"{
					response: {
						count: 26953,
						items: [
							{
								'uid': 165614770,
								'first_name': 'Маша',
								'last_name': 'Иванова',
								'university': '0',
								'university_name': '',
								'faculty': '0',
								'faculty_name': '',
								'graduation': '0',
                                'career': [{
                                  'company': 'ООО Рога и копыта',
                                  'country_id': 1,
                                  'city_id': 1041822,
                                  'until': 9.2233720368547779E+18,
                                  'position': '　'
                                }],
							}
						]
					}
				}";

			var users = GetMockedUsersCategory(url: url, json: json);

			var lst = users.Search(@params: new UserSearchParams
			{
					Query = Query
					, Fields = ProfileFields.Education
					, Count = 3
					, Offset = 123
			});

			Assert.That(actual: lst.TotalCount, expression: Is.EqualTo(expected: 26953));
			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 1));

			var maria = lst.FirstOrDefault();
			Assert.That(actual: maria, expression: Is.Not.Null);
			Assert.That(actual: maria.Id, expression: Is.EqualTo(expected: 165614770));
			Assert.That(actual: maria.FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: maria.LastName, expression: Is.EqualTo(expected: "Иванова"));
			Assert.That(actual: maria.Education, expression: Is.Null);
			Assert.That(actual: maria.Career.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: maria.Career.FirstOrDefault()?.Until, expression: Is.EqualTo(expected: 9223372036854777856));
		}

		[Test]
		public void Search_DefaultFields_ListOfProfileObjects()
		{
			const string url = "https://api.vk.com/method/users.search";

			const string json =
					@"{
				response: {
					count: 26953,
					items: [
						{
							'uid': 449928,
							'first_name': 'Маша',
							'last_name': 'Иванова'
						},
						{
							'uid': 70145254,
							'first_name': 'Маша',
							'last_name': 'Шаблинская-Иванова'
						},
						{
							'uid': 62899425,
							'first_name': 'Masha',
							'last_name': 'Ivanova'
						}
					]
					}
				}";

			var users = GetMockedUsersCategory(url: url, json: json);
			var lst = users.Search(@params: new UserSearchParams { Query = Query });

			Assert.That(actual: lst.TotalCount, expression: Is.EqualTo(expected: 26953));
			Assert.That(actual: lst.Count, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: lst[index: 0], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 0].Id, expression: Is.EqualTo(expected: 449928));
			Assert.That(actual: lst[index: 0].FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: lst[index: 0].LastName, expression: Is.EqualTo(expected: "Иванова"));

			Assert.That(actual: lst[index: 1], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 1].Id, expression: Is.EqualTo(expected: 70145254));
			Assert.That(actual: lst[index: 1].FirstName, expression: Is.EqualTo(expected: "Маша"));
			Assert.That(actual: lst[index: 1].LastName, expression: Is.EqualTo(expected: "Шаблинская-Иванова"));

			Assert.That(actual: lst[index: 2], expression: Is.Not.Null);
			Assert.That(actual: lst[index: 2].Id, expression: Is.EqualTo(expected: 62899425));
			Assert.That(actual: lst[index: 2].FirstName, expression: Is.EqualTo(expected: "Masha"));
			Assert.That(actual: lst[index: 2].LastName, expression: Is.EqualTo(expected: "Ivanova"));
		}

		// ===================================================================
		[Test]
		public void IsAppUser_5_5_version_of_api_return_false()
		{
			const string url = "https://api.vk.com/method/users.isAppUser";

			const string json =
					@"{
                    'response': 0
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.IsAppUser(userId: 1);

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result, expression: Is.False);
		}

		[Test]
		public void IsAppUser_5_5_version_of_api_return_true()
		{
			const string url = "https://api.vk.com/method/users.isAppUser";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.IsAppUser(userId: 123);

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Get_ListOfUsers()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павла',
                        'last_name': 'Дурова',
                        'sex': 2,
                        'nickname': '',
                        'domain': 'durov',
                        'bdate': '10.10.1984',
                        'city': {
                          'id': 2,
                          'title': 'Санкт-Петербург'
                        },
                        'country': {
                          'id': 1,
                          'title': 'Россия'
                        },
                        'timezone': 3,
                        'photo_50': 'http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg',
                        'photo_100': 'http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg',
                        'photo_200': 'http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg',
                        'photo_max': 'http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg',
                        'photo_200_orig': 'http://cs7004.vk.me/c7003/v7003736/3a08/mEqSflTauxA.jpg',
                        'photo_400_orig': 'http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg',
                        'photo_max_orig': 'http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg',
                        'has_mobile': 1,
                        'online': 1,
                        'can_post': 0,
                        'can_see_all_posts': 0,
                        'can_see_audio': 0,
                        'can_write_private_message': 0,
                        'twitter': 'durov',
                        'site': '',
                        'status': '',
                        'last_seen': {
                          'time': 1392634257,
                          'platform': 7
                        },
                        'common_count': 0,
                        'counters': {
                          'albums': 1,
                          'videos': 8,
                          'audios': 0,
                          'notes': 6,
                          'photos': 153,
                          'friends': 688,
                          'online_friends': 146,
                          'mutual_friends': 0,
                          'followers': 5934786,
                          'subscriptions': 0,
                          'pages': 51
                        },
                        'university': 1,
                        'university_name': '',
                        'faculty': 0,
                        'faculty_name': '',
                        'graduation': 2006,
                        'relation': 0,
                        'universities': [
                          {
                            'id': 1,
                            'country': 1,
                            'city': 2,
                            'name': 'СПбГУ',
                            'graduation': 2006
                          }
                        ],
                        'schools': [
                          {
                            'id': '1035386',
                            'country': '88',
                            'city': '16',
                            'name': 'Sc.Elem. Coppino - Falletti di Barolo',
                            'year_from': 1990,
                            'year_to': 1992,
                            'class': ''
                          },
                          {
                            'id': '1',
                            'country': '1',
                            'city': '2',
                            'name': 'Академическая (АГ) СПбГУ',
                            'year_from': 1996,
                            'year_to': 2001,
                            'year_graduated': 2001,
                            'class': 'о',
                            'type': 1,
                            'type_str': 'Гимназия'
                          }
                        ],
                        'relatives': []
                      }
                    ]
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.Get(userIds: new long[] { 1 }, fields: ProfileFields.All, nameCase: NameCase.Gen);

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 1));

			var user = result.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);
			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павла"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дурова"));
			Assert.That(actual: user.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user.Nickname, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Domain, expression: Is.EqualTo(expected: "durov"));
			Assert.That(actual: user.BirthDate, expression: Is.EqualTo(expected: "10.10.1984"));
			Assert.That(actual: user.City, expression: Is.Not.Null);
			Assert.That(actual: user.City.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.City.Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));
			Assert.That(actual: user.Country, expression: Is.Not.Null);
			Assert.That(actual: user.Country.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Country.Title, expression: Is.EqualTo(expected: "Россия"));
			Assert.That(actual: user.Timezone, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: user.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo400
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg")));

			Assert.That(actual: user.PhotoPreviews.PhotoMax
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));

			Assert.That(actual: user.HasMobile.HasValue, expression: Is.True);
			Assert.That(actual: user.HasMobile.Value, expression: Is.True);
			Assert.That(actual: user.Online.HasValue, expression: Is.True);
			Assert.That(actual: user.Online.Value, expression: Is.True);
			Assert.That(actual: user.CanPost, expression: Is.False);
			Assert.That(actual: user.CanSeeAllPosts, expression: Is.False);
			Assert.That(actual: user.CanSeeAudio, expression: Is.False);
			Assert.That(actual: user.CanWritePrivateMessage, expression: Is.False);
			Assert.That(actual: user.Connections.Twitter, expression: Is.EqualTo(expected: "durov"));
			Assert.That(actual: user.Site, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Status, expression: Is.EqualTo(expected: string.Empty));

			// TODO: u.LastSeen
			Assert.That(actual: user.CommonCount.Value, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Albums, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Counters.Videos, expression: Is.EqualTo(expected: 8));
			Assert.That(actual: user.Counters.Audios, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Notes.Value, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: user.Counters.Photos.Value, expression: Is.EqualTo(expected: 153));
			Assert.That(actual: user.Counters.Friends.Value, expression: Is.EqualTo(expected: 688));
			Assert.That(actual: user.Counters.OnlineFriends, expression: Is.EqualTo(expected: 146));
			Assert.That(actual: user.Counters.MutualFriends, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Followers, expression: Is.EqualTo(expected: 5934786));
			Assert.That(actual: user.Counters.Subscriptions, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Pages, expression: Is.EqualTo(expected: 51));
			Assert.That(actual: user.Universities.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].Country, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].City, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Universities[index: 0].Name, expression: Is.EqualTo(expected: "СПбГУ"));
			Assert.That(actual: user.Universities[index: 0].Graduation, expression: Is.EqualTo(expected: 2006));

			Assert.That(actual: user.Schools.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Schools[index: 0].Id, expression: Is.EqualTo(expected: 1035386));
			Assert.That(actual: user.Schools[index: 0].Country, expression: Is.EqualTo(expected: 88));
			Assert.That(actual: user.Schools[index: 0].City, expression: Is.EqualTo(expected: 16));
			Assert.That(actual: user.Schools[index: 0].Name, expression: Is.EqualTo(expected: "Sc.Elem. Coppino - Falletti di Barolo"));
			Assert.That(actual: user.Schools[index: 0].YearFrom, expression: Is.EqualTo(expected: 1990));
			Assert.That(actual: user.Schools[index: 0].YearTo, expression: Is.EqualTo(expected: 1992));
			Assert.That(actual: user.Schools[index: 0].Class, expression: Is.EqualTo(expected: string.Empty));

			Assert.That(actual: user.Schools[index: 1].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].Country, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].City, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Schools[index: 1].Name, expression: Is.EqualTo(expected: "Академическая (АГ) СПбГУ"));
			Assert.That(actual: user.Schools[index: 1].YearFrom, expression: Is.EqualTo(expected: 1996));
			Assert.That(actual: user.Schools[index: 1].YearTo, expression: Is.EqualTo(expected: 2001));
			Assert.That(actual: user.Schools[index: 1].YearGraduated, expression: Is.EqualTo(expected: 2001));
			Assert.That(actual: user.Schools[index: 1].Class, expression: Is.EqualTo(expected: "о"));
			Assert.That(actual: user.Schools[index: 1].Type, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].TypeStr, expression: Is.EqualTo(expected: "Гимназия"));

			Assert.That(actual: user.Relatives.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void Get_SingleUser()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 1,
                        'first_name': 'Павла',
                        'last_name': 'Дурова',
                        'sex': 2,
                        'nickname': '',
                        'domain': 'durov',
                        'bdate': '10.10.1984',
                        'city': {
                          'id': 2,
                          'title': 'Санкт-Петербург'
                        },
                        'country': {
                          'id': 1,
                          'title': 'Россия'
                        },
                        'timezone': 3,
                        'photo_50': 'http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg',
                        'photo_100': 'http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg',
                        'photo_200': 'http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg',
                        'photo_max': 'http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg',
                        'photo_200_orig': 'http://cs7004.vk.me/c7003/v7003736/3a08/mEqSflTauxA.jpg',
                        'photo_400_orig': 'http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg',
                        'photo_max_orig': 'http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg',
                        'has_mobile': 1,
                        'online': 1,
                        'can_post': 0,
                        'can_see_all_posts': 0,
                        'can_see_audio': 0,
                        'can_write_private_message': 0,
                        'twitter': 'durov',
                        'site': '',
                        'status': '',
                        'last_seen': {
                          'time': 1392634257,
                          'platform': 7
                        },
                        'common_count': 0,
                        'counters': {
                          'albums': 1,
                          'videos': 8,
                          'audios': 0,
                          'notes': 6,
                          'photos': 153,
                          'friends': 688,
                          'online_friends': 146,
                          'mutual_friends': 0,
                          'followers': 5934786,
                          'subscriptions': 0,
                          'pages': 51
                        },
                        'university': 1,
                        'university_name': '',
                        'faculty': 0,
                        'faculty_name': '',
                        'graduation': 2006,
                        'relation': 0,
                        'universities': [
                          {
                            'id': 1,
                            'country': 1,
                            'city': 2,
                            'name': 'СПбГУ',
                            'graduation': 2006
                          }
                        ],
                        'schools': [
                          {
                            'id': '1035386',
                            'country': '88',
                            'city': '16',
                            'name': 'Sc.Elem. Coppino - Falletti di Barolo',
                            'year_from': 1990,
                            'year_to': 1992,
                            'class': ''
                          },
                          {
                            'id': '1',
                            'country': '1',
                            'city': '2',
                            'name': 'Академическая (АГ) СПбГУ',
                            'year_from': 1996,
                            'year_to': 2001,
                            'year_graduated': 2001,
                            'class': 'о',
                            'type': 1,
                            'type_str': 'Гимназия'
                          }
                        ],
                        'relatives': []
                      }
                    ]
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var user = cat.Get(userId: 1, fields: ProfileFields.All, nameCase: NameCase.Gen);

			Assert.That(actual: user, expression: Is.Not.Null);

			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Павла"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Дурова"));
			Assert.That(actual: user.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user.Nickname, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Domain, expression: Is.EqualTo(expected: "durov"));
			Assert.That(actual: user.BirthDate, expression: Is.EqualTo(expected: "10.10.1984"));
			Assert.That(actual: user.City, expression: Is.Not.Null);
			Assert.That(actual: user.City.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.City.Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));
			Assert.That(actual: user.Country, expression: Is.Not.Null);
			Assert.That(actual: user.Country.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Country.Title, expression: Is.EqualTo(expected: "Россия"));
			Assert.That(actual: user.Timezone, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: user.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo400
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg")));

			Assert.That(actual: user.PhotoPreviews.PhotoMax
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));

			Assert.That(actual: user.HasMobile.HasValue, expression: Is.True);
			Assert.That(actual: user.HasMobile.Value, expression: Is.True);
			Assert.That(actual: user.Online.HasValue, expression: Is.True);
			Assert.That(actual: user.Online.Value, expression: Is.True);
			Assert.That(actual: user.CanPost, expression: Is.False);
			Assert.That(actual: user.CanSeeAllPosts, expression: Is.False);
			Assert.That(actual: user.CanSeeAudio, expression: Is.False);
			Assert.That(actual: user.CanWritePrivateMessage, expression: Is.False);
			Assert.That(actual: user.Connections.Twitter, expression: Is.EqualTo(expected: "durov"));
			Assert.That(actual: user.Site, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Status, expression: Is.EqualTo(expected: string.Empty));

			// TODO: u.LastSeen
			Assert.That(actual: user.CommonCount.Value, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Albums, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Counters.Videos, expression: Is.EqualTo(expected: 8));
			Assert.That(actual: user.Counters.Audios, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Notes.Value, expression: Is.EqualTo(expected: 6));
			Assert.That(actual: user.Counters.Photos.Value, expression: Is.EqualTo(expected: 153));
			Assert.That(actual: user.Counters.Friends.Value, expression: Is.EqualTo(expected: 688));
			Assert.That(actual: user.Counters.OnlineFriends, expression: Is.EqualTo(expected: 146));
			Assert.That(actual: user.Counters.MutualFriends, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Followers, expression: Is.EqualTo(expected: 5934786));
			Assert.That(actual: user.Counters.Subscriptions, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Counters.Pages, expression: Is.EqualTo(expected: 51));

			Assert.That(actual: user.Universities.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].Country, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Universities[index: 0].City, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Universities[index: 0].Name, expression: Is.EqualTo(expected: "СПбГУ"));
			Assert.That(actual: user.Universities[index: 0].Graduation, expression: Is.EqualTo(expected: 2006));

			Assert.That(actual: user.Schools.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Schools[index: 0].Id, expression: Is.EqualTo(expected: 1035386));
			Assert.That(actual: user.Schools[index: 0].Country, expression: Is.EqualTo(expected: 88));
			Assert.That(actual: user.Schools[index: 0].City, expression: Is.EqualTo(expected: 16));
			Assert.That(actual: user.Schools[index: 0].Name, expression: Is.EqualTo(expected: "Sc.Elem. Coppino - Falletti di Barolo"));
			Assert.That(actual: user.Schools[index: 0].YearFrom, expression: Is.EqualTo(expected: 1990));
			Assert.That(actual: user.Schools[index: 0].YearTo, expression: Is.EqualTo(expected: 1992));
			Assert.That(actual: user.Schools[index: 0].Class, expression: Is.EqualTo(expected: string.Empty));

			Assert.That(actual: user.Schools[index: 1].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].Country, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].City, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user.Schools[index: 1].Name, expression: Is.EqualTo(expected: "Академическая (АГ) СПбГУ"));
			Assert.That(actual: user.Schools[index: 1].YearFrom, expression: Is.EqualTo(expected: 1996));
			Assert.That(actual: user.Schools[index: 1].YearTo, expression: Is.EqualTo(expected: 2001));
			Assert.That(actual: user.Schools[index: 1].YearGraduated, expression: Is.EqualTo(expected: 2001));
			Assert.That(actual: user.Schools[index: 1].Class, expression: Is.EqualTo(expected: "о"));
			Assert.That(actual: user.Schools[index: 1].Type, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.Schools[index: 1].TypeStr, expression: Is.EqualTo(expected: "Гимназия"));

			Assert.That(actual: user.Relatives.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void Get_DeletedUser()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 4793858,
                        'first_name': 'Антон',
                        'last_name': 'Жидков',
                        'deactivated': 'deleted'
                      }
                    ]
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var user = cat.Get(userId: 4793858, fields: ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Education);
			Assert.That(actual: user, expression: Is.Not.Null);

			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 4793858));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Антон"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Жидков"));
			Assert.That(actual: user.Deactivated, expression: Is.EqualTo(expected: Deactivated.Deleted));
			Assert.That(actual: user.IsDeactivated, expression: Is.True);
		}

		[Test]
		public void GetSubscriptions_Extended()
		{
			const string url = "https://api.vk.com/method/users.getSubscriptions";

			const string json =
					@"{
                    'response': {
                      'count': 51,
                      'items': [
                        {
                          'id': 32295218,
                          'name': 'LIVE Экспресс',
                          'screen_name': 'liveexp',
                          'is_closed': 0,
                          'type': 'page',
                          'is_admin': 0,
                          'is_member': 0,
                          'photo_50': 'http://cs412129.vk.me/v412129558/6cea/T3jVq9A5hN4.jpg',
                          'photo_100': 'http://cs412129.vk.me/v412129558/6ce9/Rs47ldlt4Ko.jpg',
                          'photo_200': 'http://cs412129.vk.me/v412129604/1238/RhEgZqrsv-w.jpg'
                        },
                        {
                          'id': 43694972,
                          'name': 'Sophie Ellis-Bextor',
                          'screen_name': 'sophieellisbextor',
                          'is_closed': 0,
                          'type': 'page',
                          'is_admin': 0,
                          'is_member': 0,
                          'photo_50': 'http://cs417031.vk.me/v417031989/59cb/65zF-xnOQsk.jpg',
                          'photo_100': 'http://cs417031.vk.me/v417031989/59ca/eOJ7ER_eJok.jpg',
                          'photo_200': 'http://cs417031.vk.me/v417031989/59c8/zI9aAlI-PHc.jpg'
                        }
                      ]
                    }
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.GetSubscriptions(userId: 1, count: 2, offset: 3);
			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 2));

			var group = result.FirstOrDefault();
			Assert.That(actual: group, expression: Is.Not.Null);

			Assert.That(actual: group.Id, expression: Is.EqualTo(expected: 32295218));
			Assert.That(actual: group.Name, expression: Is.EqualTo(expected: "LIVE Экспресс"));
			Assert.That(actual: group.ScreenName, expression: Is.EqualTo(expected: "liveexp"));
			Assert.That(actual: group.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group.IsAdmin, expression: Is.False);
			Assert.That(actual: group.IsMember, expression: Is.EqualTo(expected: false));

			Assert.That(actual: group.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs412129.vk.me/v412129558/6cea/T3jVq9A5hN4.jpg")));

			Assert.That(actual: group.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs412129.vk.me/v412129558/6ce9/Rs47ldlt4Ko.jpg")));

			Assert.That(actual: group.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs412129.vk.me/v412129604/1238/RhEgZqrsv-w.jpg")));

			var group1 = result.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: group1, expression: Is.Not.Null);

			Assert.That(actual: group1.Id, expression: Is.EqualTo(expected: 43694972));
			Assert.That(actual: group1.Name, expression: Is.EqualTo(expected: "Sophie Ellis-Bextor"));
			Assert.That(actual: group1.ScreenName, expression: Is.EqualTo(expected: "sophieellisbextor"));
			Assert.That(actual: group1.IsClosed, expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: group1.Type, expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: group1.IsAdmin, expression: Is.EqualTo(expected: false));
			Assert.That(actual: group1.IsMember, expression: Is.EqualTo(expected: false));

			Assert.That(actual: group1.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs417031.vk.me/v417031989/59cb/65zF-xnOQsk.jpg")));

			Assert.That(actual: group1.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs417031.vk.me/v417031989/59ca/eOJ7ER_eJok.jpg")));

			Assert.That(actual: group1.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs417031.vk.me/v417031989/59c8/zI9aAlI-PHc.jpg")));
		}

		[Test]
		public void GetFollowers_WithoutFields()
		{
			const string url = "https://api.vk.com/method/users.getFollowers";

			const string json =
					@"{
                    'response': {
                      'count': 5937503,
                      'items': [
                        5984118,
                        179652233
                      ]
                    }
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.GetFollowers(userId: 1, count: 2, offset: 3);
			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 2));

			Assert.That(actual: result[index: 0].Id, expression: Is.EqualTo(expected: 5984118));
			Assert.That(actual: result[index: 1].Id, expression: Is.EqualTo(expected: 179652233));
		}

		[Test]
		public void GetFollowers_WithAllFields()
		{
			const string url = "https://api.vk.com/method/users.getFollowers";

			const string json =
					@"{
                    'response': {
                      'count': 5937505,
                      'items': [
                        {
                          'id': 243663122,
                          'first_name': 'Ивана',
                          'last_name': 'Радюна',
                          'sex': 2,
                          'nickname': '',
                          'domain': 'id243663122',
                          'bdate': '27.8.1985',
                          'city': {
                            'id': 18632,
                            'title': 'Вороново'
                          },
                          'country': {
                            'id': 3,
                            'title': 'Беларусь'
                          },
                          'timezone': 3,
                          'photo_50': 'http://cs606327.vk.me/v606327122/35ac/R57FNUr34iw.jpg',
                          'photo_100': 'http://cs606327.vk.me/v606327122/35ab/HUsGNVxBoQU.jpg',
                          'photo_200': 'http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg',
                          'photo_max': 'http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg',
                          'photo_200_orig': 'http://cs606327.vk.me/v606327122/35a9/3GW5bsTOvCA.jpg',
                          'photo_max_orig': 'http://cs606327.vk.me/v606327122/35a9/3GW5bsTOvCA.jpg',
                          'has_mobile': 1,
                          'online': 1,
                          'online_mobile': 1,
                          'can_post': 0,
                          'can_see_all_posts': 1,
                          'can_see_audio': 1,
                          'can_write_private_message': 1,
                          'mobile_phone': '',
                          'home_phone': '',
                          'site': '',
                          'status': 'Пусть ветер гудит в проводах пусть будет осенняя влага пусть люди забудут о нас,но ни забудем друг друга.',
                          'last_seen': {
                            'time': 1392710539,
                            'platform': 1
                          },
                          'common_count': 0,
                          'university': 0,
                          'university_name': '',
                          'faculty': 0,
                          'faculty_name': '',
                          'graduation': 0,
                          'relation': 6,
                          'universities': [],
                          'schools': [],
                          'relatives': []
                        },
                        {
                          'id': 239897398,
                          'first_name': 'Софійки',
                          'last_name': 'Довгалюк',
                          'sex': 1,
                          'nickname': '',
                          'domain': 'id239897398',
                          'bdate': '16.6.2000',
                          'city': {
                            'id': 1559,
                            'title': 'Тернополь'
                          },
                          'country': {
                            'id': 2,
                            'title': 'Украина'
                          },
                          'timezone': 1,
                          'photo_50': 'http://cs310121.vk.me/v310121398/8023/LMm-uoyk1-M.jpg',
                          'photo_100': 'http://cs310121.vk.me/v310121398/8022/KajnVK0lvFA.jpg',
                          'photo_200': 'http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg',
                          'photo_max': 'http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg',
                          'photo_200_orig': 'http://cs310121.vk.me/v310121398/8020/N2DK1JeENJM.jpg',
                          'photo_400_orig': 'http://cs310121.vk.me/v310121398/801f/FSWGaDlq3L4.jpg',
                          'photo_max_orig': 'http://cs310121.vk.me/v310121398/801f/FSWGaDlq3L4.jpg',
                          'has_mobile': 1,
                          'online': 1,
                          'can_post': 0,
                          'can_see_all_posts': 1,
                          'can_see_audio': 1,
                          'can_write_private_message': 1,
                          'mobile_phone': '**********',
                          'home_phone': '*****',
                          'skype': 'немає',
                          'site': '',
                          'status': 'Не варто ображатися на людей за те, що вони не виправдали наших очікувань... ми самі винні, що чекали від них більше, ніж варто було!',
                          'last_seen': {
                            'time': 1392710474,
                            'platform': 7
                          },
                          'common_count': 0,
                          'university': 0,
                          'university_name': '',
                          'faculty': 0,
                          'faculty_name': '',
                          'graduation': 0,
                          'relation': 0,
                          'universities': [],
                          'schools': [],
                          'relatives': [
                            {
                              'id': 222462523,
                              'type': 'sibling'
                            },
                            {
                              'id': 207105159,
                              'type': 'sibling'
                            }
                          ]
                        }
                      ]
                    }
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var users = cat.GetFollowers(userId: 1, count: 2, offset: 3, fields: ProfileFields.All, nameCase: NameCase.Gen);
			Assert.That(actual: users, expression: Is.Not.Null);
			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 2));

			var user = users.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);

			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 243663122));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Ивана"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Радюна"));
			Assert.That(actual: user.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user.Nickname, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Domain, expression: Is.EqualTo(expected: "id243663122"));
			Assert.That(actual: user.BirthDate, expression: Is.EqualTo(expected: "27.8.1985"));
			Assert.That(actual: user.City.Id, expression: Is.EqualTo(expected: 18632));
			Assert.That(actual: user.City.Title, expression: Is.EqualTo(expected: "Вороново"));
			Assert.That(actual: user.Country.Id, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: user.Country.Title, expression: Is.EqualTo(expected: "Беларусь"));
			Assert.That(actual: user.Timezone, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: user.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs606327.vk.me/v606327122/35ac/R57FNUr34iw.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs606327.vk.me/v606327122/35ab/HUsGNVxBoQU.jpg")));

			Assert.That(actual: user.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg")));

			Assert.That(actual: user.PhotoPreviews.PhotoMax
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg")));

			Assert.That(actual: user.HasMobile, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.Online, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.OnlineMobile, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.CanPost, expression: Is.EqualTo(expected: false));
			Assert.That(actual: user.CanSeeAllPosts, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.CanSeeAudio, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.CanWritePrivateMessage, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user.MobilePhone, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.HomePhone, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user.Site, expression: Is.EqualTo(expected: string.Empty));

			Assert.That(actual: user.Status
					, expression: Is.EqualTo(
							expected:
							"Пусть ветер гудит в проводах пусть будет осенняя влага пусть люди забудут о нас,но ни забудем друг друга."));

			Assert.That(actual: user.LastSeen.Time
					, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1392710539)));

			Assert.That(actual: user.CommonCount, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Universities.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Relation, expression: Is.EqualTo(expected: RelationType.InActiveSearch));
			Assert.That(actual: user.Schools.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user.Relatives.Count, expression: Is.EqualTo(expected: 0));

			var user1 = users.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: user1, expression: Is.Not.Null);

			Assert.That(actual: user1.Id, expression: Is.EqualTo(expected: 239897398));
			Assert.That(actual: user1.FirstName, expression: Is.EqualTo(expected: "Софійки"));
			Assert.That(actual: user1.LastName, expression: Is.EqualTo(expected: "Довгалюк"));
			Assert.That(actual: user1.Sex, expression: Is.EqualTo(expected: Sex.Female));
			Assert.That(actual: user1.Nickname, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: user1.Domain, expression: Is.EqualTo(expected: "id239897398"));
			Assert.That(actual: user1.BirthDate, expression: Is.EqualTo(expected: "16.6.2000"));
			Assert.That(actual: user1.City.Id, expression: Is.EqualTo(expected: 1559));
			Assert.That(actual: user1.City.Title, expression: Is.EqualTo(expected: "Тернополь"));
			Assert.That(actual: user1.Country.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user1.Country.Title, expression: Is.EqualTo(expected: "Украина"));
			Assert.That(actual: user1.Timezone, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: user1.PhotoPreviews.Photo50
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310121.vk.me/v310121398/8023/LMm-uoyk1-M.jpg")));

			Assert.That(actual: user1.PhotoPreviews.Photo100
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310121.vk.me/v310121398/8022/KajnVK0lvFA.jpg")));

			Assert.That(actual: user1.PhotoPreviews.Photo200
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg")));

			Assert.That(actual: user1.PhotoPreviews.PhotoMax
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg")));

			Assert.That(actual: user1.HasMobile, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user1.Online, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user1.CanPost, expression: Is.EqualTo(expected: false));
			Assert.That(actual: user1.CanSeeAllPosts, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user1.CanSeeAudio, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user1.CanWritePrivateMessage, expression: Is.EqualTo(expected: true));
			Assert.That(actual: user1.MobilePhone, expression: Is.EqualTo(expected: "**********"));
			Assert.That(actual: user1.HomePhone, expression: Is.EqualTo(expected: "*****"));
			Assert.That(actual: user1.Connections.Skype, expression: Is.EqualTo(expected: "немає"));
			Assert.That(actual: user1.Site, expression: Is.EqualTo(expected: string.Empty));

			Assert.That(actual: user1.Status
					, expression: Is.EqualTo(
							expected:
							"Не варто ображатися на людей за те, що вони не виправдали наших очікувань... ми самі винні, що чекали від них більше, ніж варто було!"));

			Assert.That(actual: user1.LastSeen.Time
					, expression: Is.EqualTo(expected: new DateTime(year: 2014, month: 2, day: 18, hour: 8, minute: 1, second: 14
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: user1.CommonCount, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user1.Universities.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user1.Relation, expression: Is.EqualTo(expected: RelationType.Unknown));
			Assert.That(actual: user1.Schools.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: user1.Relatives.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user1.Relatives[index: 0].Id, expression: Is.EqualTo(expected: 222462523));
			Assert.That(actual: user1.Relatives[index: 0].Type, expression: Is.EqualTo(expected: RelativeType.Sibling));
			Assert.That(actual: user1.Relatives[index: 1].Id, expression: Is.EqualTo(expected: 207105159));
			Assert.That(actual: user1.Relatives[index: 1].Type, expression: Is.EqualTo(expected: RelativeType.Sibling));
		}

		[Test]
		public void Report_NormalCase()
		{
			const string url = "https://api.vk.com/method/users.report";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var result = cat.Report(userId: 243663122, type: ReportType.Insult, comment: "комментарий");

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Get_DmAndDurov_ListOfUsers()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 53083705,
                        'first_name': 'Дмитрия',
                        'last_name': 'Медведева',
                        'sex': 2,
                        'city': {
                          'id': 1,
                          'title': 'Москва'
                        }
                      },
                      {
                        'id': 1,
                        'first_name': 'Павла',
                        'last_name': 'Дурова',
                        'sex': 2,
                        'city': {
                          'id': 2,
                          'title': 'Санкт-Петербург'
                        }
                      }
                    ]
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var screenNames = new[]
			{
					"dm"
					, "durov"
			};

			var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Sex|ProfileFields.City;
			var users = cat.Get(screenNames: screenNames, fields: fields, nameCase: NameCase.Gen);

			Assert.That(actual: users, expression: Is.Not.Null);
			Assert.That(actual: users.Count, expression: Is.EqualTo(expected: 2));

			var user = users.FirstOrDefault();
			Assert.That(actual: user, expression: Is.Not.Null);

			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 53083705));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Дмитрия"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Медведева"));
			Assert.That(actual: user.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user.City.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.City.Title, expression: Is.EqualTo(expected: "Москва"));

			var user1 = users.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: user1, expression: Is.Not.Null);
			Assert.That(actual: user1.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user1.FirstName, expression: Is.EqualTo(expected: "Павла"));
			Assert.That(actual: user1.LastName, expression: Is.EqualTo(expected: "Дурова"));
			Assert.That(actual: user1.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user1.City.Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: user1.City.Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));
		}

		[Test]
		public void Get_Dimon_SingleUser()
		{
			const string url = "https://api.vk.com/method/users.get";

			const string json =
					@"{
                    'response': [
                      {
                        'id': 53083705,
                        'first_name': 'Дмитрия',
                        'last_name': 'Медведева',
                        'sex': 2,
                        'city': {
                          'id': 1,
                          'title': 'Москва'
                        }
                      }
                    ]
                  }";

			var cat = GetMockedUsersCategory(url: url, json: json);

			var fields = ProfileFields.FirstName|ProfileFields.LastName|ProfileFields.Sex|ProfileFields.City;
			var user = cat.Get(screenName: "dm", fields: fields, nameCase: NameCase.Gen);

			Assert.That(actual: user, expression: Is.Not.Null);

			Assert.That(actual: user.Id, expression: Is.EqualTo(expected: 53083705));
			Assert.That(actual: user.FirstName, expression: Is.EqualTo(expected: "Дмитрия"));
			Assert.That(actual: user.LastName, expression: Is.EqualTo(expected: "Медведева"));
			Assert.That(actual: user.Sex, expression: Is.EqualTo(expected: Sex.Male));
			Assert.That(actual: user.City.Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: user.City.Title, expression: Is.EqualTo(expected: "Москва"));
		}

	#if false
        #region Async methods

        [Test]
        public async Task Async_GetAsync_DmAndDurov_ListOfUsers()
        {
            const string url = "https://api.vk.com/method/users.get";
            const string json =
            @"{
                    'response': [
                      {
                        'id': 53083705,
                        'first_name': 'Дмитрия',
                        'last_name': 'Медведева',
                        'sex': 2,
                        'city': {
                          'id': 1,
                          'title': 'Москва'
                        }
                      },
                      {
                        'id': 1,
                        'first_name': 'Павла',
                        'last_name': 'Дурова',
                        'sex': 2,
                        'city': {
                          'id': 2,
                          'title': 'Санкт-Петербург'
                        }
                      }
                    ]
                  }";

            UsersCategory cat = GetMockedUsersCategory(url, json);

            var screenNames = new[] { "dm", "durov" };
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.City;
            ReadOnlyCollection<User> users = await cat.GetAsync(screenNames, fields, NameCase.Gen);

            users.Count.ShouldEqual(2);
            users[0].Id.ShouldEqual(53083705);
            users[0].FirstName.ShouldEqual("Дмитрия");
            users[0].LastName.ShouldEqual("Медведева");
            users[0].Sex.ShouldEqual(Sex.Male);
            users[0].City.Id.ShouldEqual(1);
            users[0].City.Title.ShouldEqual("Москва");

            users[1].Id.ShouldEqual(1);
            users[1].FirstName.ShouldEqual("Павла");
            users[1].LastName.ShouldEqual("Дурова");
            users[1].Sex.ShouldEqual(Sex.Male);
            users[1].City.Id.ShouldEqual(2);
            users[1].City.Title.ShouldEqual("Санкт-Петербург");
        }

        #endregion
#endif
	}
}