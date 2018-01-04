using System;
using VkNet.Enums;

namespace VkNet.Tests.Categories
{
	using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using VkNet.Categories;
	using Exception;
	using Model.RequestParams;
    using Enums.Filters;
    using Enums.SafetyEnums;

	[TestFixture]
    public class UsersCategoryTest : BaseTest
	{
        private const string Query = "Masha Ivanova";

        private UsersCategory GetMockedUsersCategory(string url, string json)
        {
            Json = json;
            Url = url;
            return new UsersCategory(Api);
        }

        [Test]
        public void Get_NotAccessToInternet_ThrowVkApiException()
        {
			Mock.Get(Api.Browser).Setup(f => f.GetJson(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));
			var ex = Assert.Throws<VkApiException>(() => Api.Users.Get(new long[]{1}));
			Assert.That(ex.Message, Is.EqualTo("The remote name could not be resolved: 'api.vk.com'"));
		}

        [Test, Ignore("Метод может быть вызван без авторизации")]
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

            var users = GetMockedUsersCategory(url, json);
			var ex = Assert.Throws<UserAuthorizationFailException>(() => users.Get(1));
			Assert.That(ex.Message, Is.EqualTo("User authorization failed: invalid access_token."));
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

            var users = GetMockedUsersCategory(url, json);

			// act
			var fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Education;
            var user = users.Get(1, fields, skipAuthorization: false);

			// assert
			Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(1));
            Assert.That(user.FirstName, Is.EqualTo("Павел"));
            Assert.That(user.LastName, Is.EqualTo("Дуров"));
            Assert.That(user.Education, Is.Not.Null);
            Assert.That(user.Education.UniversityId, Is.EqualTo(1));
            Assert.That(user.Education.UniversityName, Is.EqualTo("СПбГУ"));
            Assert.That(user.Education.FacultyId, Is.Null);
            Assert.That(user.Education.FacultyName, Is.EqualTo(""));
            Assert.That(user.Education.Graduation, Is.EqualTo(2006));
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


            var users = GetMockedUsersCategory(url, json);
            // act
            var user = users.Get(1, ProfileFields.Counters, skipAuthorization: false);

			// assert
			Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(1));
            Assert.That(user.FirstName, Is.EqualTo("Павел"));
            Assert.That(user.LastName, Is.EqualTo("Дуров"));
            Assert.That(user.Counters, Is.Not.Null);
            Assert.That(user.Counters.Albums, Is.EqualTo(1));
            Assert.That(user.Counters.Videos, Is.EqualTo(8));
            Assert.That(user.Counters.Audios, Is.EqualTo(0));
            Assert.That(user.Counters.Notes, Is.EqualTo(6));
            Assert.That(user.Counters.Photos, Is.EqualTo(153));
            Assert.That(user.Counters.Friends, Is.EqualTo(689));
            Assert.That(user.Counters.OnlineFriends, Is.EqualTo(85));
            Assert.That(user.Counters.MutualFriends, Is.EqualTo(0));
            Assert.That(user.Counters.Followers, Is.EqualTo(5937280));
            Assert.That(user.Counters.Subscriptions, Is.EqualTo(0));
            Assert.That(user.Counters.Pages, Is.EqualTo(51));
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

            var users = GetMockedUsersCategory(url, json);

			// act
			var user = users.Get(1, skipAuthorization: false);

            // assert
            Assert.That(user.Id, Is.EqualTo(1));
            Assert.That(user.FirstName, Is.EqualTo("Павел"));
            Assert.That(user.LastName, Is.EqualTo("Дуров"));
        }

        [Test]
        public void Get_EmptyListOfUids_ThrowArgumentNullException()
        {
            IEnumerable<long> userIds = null;
			Assert.That(() => Api.Users.Get(userIds), Throws.InstanceOf<ArgumentNullException>());
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

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Get(new long[] {1, 672}, skipAuthorization: false);

			Assert.That(lst.Count, Is.EqualTo(2));
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(1));
            Assert.That(lst[0].FirstName, Is.EqualTo("Павел"));
            Assert.That(lst[0].LastName, Is.EqualTo("Дуров"));

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(672));
            Assert.That(lst[1].FirstName, Is.EqualTo("Кристина"));
            Assert.That(lst[1].LastName, Is.EqualTo("Смирнова"));
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

            var users = GetMockedUsersCategory(url, json);
			var lst = users.Get(new long[] {1, 5041431}, ProfileFields.Education, skipAuthorization:false);

            Assert.That(lst.Count == 2);
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(1));
            Assert.That(lst[0].FirstName, Is.EqualTo("Павел"));
            Assert.That(lst[0].LastName, Is.EqualTo("Дуров"));
            Assert.That(lst[0].Education, Is.Not.Null);
            Assert.That(lst[0].Education.UniversityId, Is.EqualTo(1));
            Assert.That(lst[0].Education.UniversityName, Is.EqualTo("СПбГУ"));
            Assert.That(lst[0].Education.FacultyId, Is.Null);
            Assert.That(lst[0].Education.FacultyName, Is.Null.Or.Empty);
            Assert.That(lst[0].Education.Graduation, Is.EqualTo(2006));

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(5041431));
            Assert.That(lst[1].FirstName, Is.EqualTo("Тайфур"));
            Assert.That(lst[1].LastName, Is.EqualTo("Касеев"));
            Assert.That(lst[1].Education, Is.Not.Null);
            Assert.That(lst[1].Education.UniversityId, Is.EqualTo(431));
            Assert.That(lst[1].Education.UniversityName, Is.EqualTo("ВолгГТУ"));
            Assert.That(lst[1].Education.FacultyId, Is.EqualTo(3162));
            Assert.That(lst[1].Education.FacultyName, Is.EqualTo("Электроники и вычислительной техники"));
            Assert.That(lst[1].Education.Graduation, Is.EqualTo(2012));
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

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(new UserSearchParams { Query = "fa'sosjvsoidf" });

            Assert.That(lst.TotalCount, Is.EqualTo(0));
            Assert.That(lst, Is.Not.Null);
            Assert.That(lst.Count, Is.EqualTo(0));
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

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(new UserSearchParams { Query = Query, Fields = ProfileFields.Education, Count = 3, Offset = 123});

            Assert.That(lst.TotalCount, Is.EqualTo(26953));
            Assert.That(lst.Count, Is.EqualTo(3));
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(165614770));
            Assert.That(lst[0].FirstName, Is.EqualTo("Маша"));
            Assert.That(lst[0].LastName, Is.EqualTo("Иванова"));
            Assert.That(lst[0].Education, Is.Null);

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(174063570));
            Assert.That(lst[1].FirstName, Is.EqualTo("Маша"));
            Assert.That(lst[1].LastName, Is.EqualTo("Иванова"));
            Assert.That(lst[1].Education, Is.Null);

            Assert.That(lst[2], Is.Not.Null);
            Assert.That(lst[2].Id, Is.EqualTo(76817368));
            Assert.That(lst[2].FirstName, Is.EqualTo("Маша"));
            Assert.That(lst[2].LastName, Is.EqualTo("Иванова"));
            Assert.That(lst[2].Education, Is.Null);
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

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(new UserSearchParams { Query = Query, Fields = ProfileFields.Education, Count = 3, Offset = 123 });

            Assert.That(lst.TotalCount, Is.EqualTo(26953));
            Assert.That(lst.Count, Is.EqualTo(1));

            var maria = lst.FirstOrDefault();
            Assert.That(maria, Is.Not.Null);
            Assert.That(maria.Id, Is.EqualTo(165614770));
            Assert.That(maria.FirstName, Is.EqualTo("Маша"));
            Assert.That(maria.LastName, Is.EqualTo("Иванова"));
            Assert.That(maria.Education, Is.Null);
            Assert.That(maria.Career.Count, Is.EqualTo(1));
            Assert.That(maria.Career.FirstOrDefault()?.Until, Is.EqualTo(9223372036854777856));
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

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(new UserSearchParams { Query = Query });

            Assert.That(lst.TotalCount, Is.EqualTo(26953));
            Assert.That(lst.Count, Is.EqualTo(3));
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(449928));
            Assert.That(lst[0].FirstName, Is.EqualTo("Маша"));
            Assert.That(lst[0].LastName, Is.EqualTo("Иванова"));

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(70145254));
            Assert.That(lst[1].FirstName, Is.EqualTo("Маша"));
            Assert.That(lst[1].LastName, Is.EqualTo("Шаблинская-Иванова"));

            Assert.That(lst[2], Is.Not.Null);
            Assert.That(lst[2].Id, Is.EqualTo(62899425));
            Assert.That(lst[2].FirstName, Is.EqualTo("Masha"));
            Assert.That(lst[2].LastName, Is.EqualTo("Ivanova"));
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

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.IsAppUser(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.False);
		}

        [Test]
        public void IsAppUser_5_5_version_of_api_return_true()
        {
            const string url = "https://api.vk.com/method/users.isAppUser";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.IsAppUser(123);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
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

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.Get(new long[] {1}, ProfileFields.All, NameCase.Gen, false);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(1));

			var user = result.FirstOrDefault();
			Assert.That(user, Is.Not.Null);
			Assert.That(user.Id, Is.EqualTo(1));
			Assert.That(user.FirstName, Is.EqualTo("Павла"));
			Assert.That(user.LastName, Is.EqualTo("Дурова"));
			Assert.That(user.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user.Nickname, Is.EqualTo(string.Empty));
			Assert.That(user.Domain, Is.EqualTo("durov"));
			Assert.That(user.BirthDate, Is.EqualTo("10.10.1984"));
			Assert.That(user.City, Is.Not.Null);
			Assert.That(user.City.Id, Is.EqualTo(2));
			Assert.That(user.City.Title, Is.EqualTo("Санкт-Петербург"));
			Assert.That(user.Country, Is.Not.Null);
			Assert.That(user.Country.Id, Is.EqualTo(1));
			Assert.That(user.Country.Title, Is.EqualTo("Россия"));
			Assert.That(user.Timezone, Is.EqualTo(3));
			Assert.That(user.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg")));
			Assert.That(user.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg")));
			Assert.That(user.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));
			Assert.That(user.PhotoPreviews.Photo400, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg")));
			Assert.That(user.PhotoPreviews.PhotoMax, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));
			Assert.That(user.HasMobile.HasValue, Is.True);
			Assert.That(user.HasMobile.Value, Is.True);
			Assert.That(user.Online.HasValue, Is.True);
			Assert.That(user.Online.Value, Is.True);
			Assert.That(user.CanPost, Is.False);
			Assert.That(user.CanSeeAllPosts, Is.False);
			Assert.That(user.CanSeeAudio, Is.False);
			Assert.That(user.CanWritePrivateMessage, Is.False);
			Assert.That(user.Connections.Twitter, Is.EqualTo("durov"));
			Assert.That(user.Site, Is.EqualTo(string.Empty));
			Assert.That(user.Status, Is.EqualTo(string.Empty));
			// TODO: u.LastSeen
			Assert.That(user.CommonCount.Value, Is.EqualTo(0));
			Assert.That(user.Counters.Albums, Is.EqualTo(1));
			Assert.That(user.Counters.Videos, Is.EqualTo(8));
			Assert.That(user.Counters.Audios, Is.EqualTo(0));
			Assert.That(user.Counters.Notes.Value, Is.EqualTo(6));
			Assert.That(user.Counters.Photos.Value, Is.EqualTo(153));
			Assert.That(user.Counters.Friends.Value, Is.EqualTo(688));
			Assert.That(user.Counters.OnlineFriends, Is.EqualTo(146));
			Assert.That(user.Counters.MutualFriends, Is.EqualTo(0));
			Assert.That(user.Counters.Followers, Is.EqualTo(5934786));
			Assert.That(user.Counters.Subscriptions, Is.EqualTo(0));
			Assert.That(user.Counters.Pages, Is.EqualTo(51));
			Assert.That(user.Universities.Count, Is.EqualTo(1));
			Assert.That(user.Universities[0].Id, Is.EqualTo(1));
			Assert.That(user.Universities[0].Country, Is.EqualTo(1));
			Assert.That(user.Universities[0].City, Is.EqualTo(2));
			Assert.That(user.Universities[0].Name, Is.EqualTo("СПбГУ"));
			Assert.That(user.Universities[0].Graduation, Is.EqualTo(2006));

			Assert.That(user.Schools.Count, Is.EqualTo(2));
			Assert.That(user.Schools[0].Id, Is.EqualTo(1035386));
			Assert.That(user.Schools[0].Country, Is.EqualTo(88));
			Assert.That(user.Schools[0].City, Is.EqualTo(16));
			Assert.That(user.Schools[0].Name, Is.EqualTo("Sc.Elem. Coppino - Falletti di Barolo"));
			Assert.That(user.Schools[0].YearFrom, Is.EqualTo(1990));
			Assert.That(user.Schools[0].YearTo, Is.EqualTo(1992));
			Assert.That(user.Schools[0].Class, Is.EqualTo(string.Empty));

			Assert.That(user.Schools[1].Id, Is.EqualTo(1));
			Assert.That(user.Schools[1].Country, Is.EqualTo(1));
			Assert.That(user.Schools[1].City, Is.EqualTo(2));
			Assert.That(user.Schools[1].Name, Is.EqualTo("Академическая (АГ) СПбГУ"));
			Assert.That(user.Schools[1].YearFrom, Is.EqualTo(1996));
			Assert.That(user.Schools[1].YearTo, Is.EqualTo(2001));
			Assert.That(user.Schools[1].YearGraduated, Is.EqualTo(2001));
			Assert.That(user.Schools[1].Class, Is.EqualTo("о"));
			Assert.That(user.Schools[1].Type, Is.EqualTo(1));
			Assert.That(user.Schools[1].TypeStr, Is.EqualTo("Гимназия"));

			Assert.That(user.Relatives.Count, Is.EqualTo(0));
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

            var cat = GetMockedUsersCategory(url, json);

            var user = cat.Get(1, ProfileFields.All, NameCase.Gen, false);

			Assert.That(user, Is.Not.Null);

			Assert.That(user.Id, Is.EqualTo(1));
			Assert.That(user.FirstName, Is.EqualTo("Павла"));
			Assert.That(user.LastName, Is.EqualTo("Дурова"));
			Assert.That(user.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user.Nickname, Is.EqualTo(string.Empty));
			Assert.That(user.Domain, Is.EqualTo("durov"));
			Assert.That(user.BirthDate, Is.EqualTo("10.10.1984"));
			Assert.That(user.City, Is.Not.Null);
			Assert.That(user.City.Id, Is.EqualTo(2));
			Assert.That(user.City.Title, Is.EqualTo("Санкт-Петербург"));
			Assert.That(user.Country, Is.Not.Null);
			Assert.That(user.Country.Id, Is.EqualTo(1));
			Assert.That(user.Country.Title, Is.EqualTo("Россия"));
			Assert.That(user.Timezone, Is.EqualTo(3));
			Assert.That(user.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg")));
			Assert.That(user.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg")));
			Assert.That(user.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));
			Assert.That(user.PhotoPreviews.Photo400, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg")));
			Assert.That(user.PhotoPreviews.PhotoMax, Is.EqualTo(new Uri("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg")));
			Assert.That(user.HasMobile.HasValue, Is.True);
			Assert.That(user.HasMobile.Value, Is.True);
			Assert.That(user.Online.HasValue, Is.True);
			Assert.That(user.Online.Value, Is.True);
			Assert.That(user.CanPost, Is.False);
			Assert.That(user.CanSeeAllPosts, Is.False);
			Assert.That(user.CanSeeAudio, Is.False);
			Assert.That(user.CanWritePrivateMessage, Is.False);
			Assert.That(user.Connections.Twitter, Is.EqualTo("durov"));
			Assert.That(user.Site, Is.EqualTo(string.Empty));
			Assert.That(user.Status, Is.EqualTo(string.Empty));
			// TODO: u.LastSeen
			Assert.That(user.CommonCount.Value, Is.EqualTo(0));
			Assert.That(user.Counters.Albums, Is.EqualTo(1));
			Assert.That(user.Counters.Videos, Is.EqualTo(8));
			Assert.That(user.Counters.Audios, Is.EqualTo(0));
			Assert.That(user.Counters.Notes.Value, Is.EqualTo(6));
			Assert.That(user.Counters.Photos.Value, Is.EqualTo(153));
			Assert.That(user.Counters.Friends.Value, Is.EqualTo(688));
			Assert.That(user.Counters.OnlineFriends, Is.EqualTo(146));
			Assert.That(user.Counters.MutualFriends, Is.EqualTo(0));
			Assert.That(user.Counters.Followers, Is.EqualTo(5934786));
			Assert.That(user.Counters.Subscriptions, Is.EqualTo(0));
			Assert.That(user.Counters.Pages, Is.EqualTo(51));

			Assert.That(user.Universities.Count, Is.EqualTo(1));
			Assert.That(user.Universities[0].Id, Is.EqualTo(1));
			Assert.That(user.Universities[0].Country, Is.EqualTo(1));
			Assert.That(user.Universities[0].City, Is.EqualTo(2));
			Assert.That(user.Universities[0].Name, Is.EqualTo("СПбГУ"));
			Assert.That(user.Universities[0].Graduation, Is.EqualTo(2006));

			Assert.That(user.Schools.Count, Is.EqualTo(2));
			Assert.That(user.Schools[0].Id, Is.EqualTo(1035386));
			Assert.That(user.Schools[0].Country, Is.EqualTo(88));
			Assert.That(user.Schools[0].City, Is.EqualTo(16));
			Assert.That(user.Schools[0].Name, Is.EqualTo("Sc.Elem. Coppino - Falletti di Barolo"));
			Assert.That(user.Schools[0].YearFrom, Is.EqualTo(1990));
			Assert.That(user.Schools[0].YearTo, Is.EqualTo(1992));
			Assert.That(user.Schools[0].Class, Is.EqualTo(string.Empty));

			Assert.That(user.Schools[1].Id, Is.EqualTo(1));
			Assert.That(user.Schools[1].Country, Is.EqualTo(1));
			Assert.That(user.Schools[1].City, Is.EqualTo(2));
			Assert.That(user.Schools[1].Name, Is.EqualTo("Академическая (АГ) СПбГУ"));
			Assert.That(user.Schools[1].YearFrom, Is.EqualTo(1996));
			Assert.That(user.Schools[1].YearTo, Is.EqualTo(2001));
			Assert.That(user.Schools[1].YearGraduated, Is.EqualTo(2001));
			Assert.That(user.Schools[1].Class, Is.EqualTo("о"));
			Assert.That(user.Schools[1].Type, Is.EqualTo(1));
			Assert.That(user.Schools[1].TypeStr, Is.EqualTo("Гимназия"));

			Assert.That(user.Relatives.Count, Is.EqualTo(0));
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

            var cat = GetMockedUsersCategory(url, json);

			var user = cat.Get(4793858, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Education, skipAuthorization: false);
			Assert.That(user, Is.Not.Null);

			Assert.That(user.Id, Is.EqualTo(4793858));
			Assert.That(user.FirstName, Is.EqualTo("Антон"));
			Assert.That(user.LastName, Is.EqualTo("Жидков"));
			Assert.That(user.Deactivated, Is.EqualTo(Deactivated.Deleted));
			Assert.That(user.IsDeactivated, Is.True);
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

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.GetSubscriptions(1, 2, 3, skipAuthorization: false);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(2));

			var @group = result.FirstOrDefault();
			Assert.That(@group, Is.Not.Null);

			Assert.That(@group.Id, Is.EqualTo(32295218));
			Assert.That(@group.Name, Is.EqualTo("LIVE Экспресс"));
			Assert.That(@group.ScreenName, Is.EqualTo("liveexp"));
			Assert.That(@group.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(@group.Type, Is.EqualTo(GroupType.Page));
			Assert.That(@group.IsAdmin, Is.False);
			Assert.That(@group.IsMember, Is.EqualTo(false));
			Assert.That(@group.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs412129.vk.me/v412129558/6cea/T3jVq9A5hN4.jpg")));
			Assert.That(@group.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs412129.vk.me/v412129558/6ce9/Rs47ldlt4Ko.jpg")));
			Assert.That(@group.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs412129.vk.me/v412129604/1238/RhEgZqrsv-w.jpg")));

			var @group1 = result.Skip(1).FirstOrDefault();
			Assert.That(@group1, Is.Not.Null);

			Assert.That(@group1.Id, Is.EqualTo(43694972));
			Assert.That(@group1.Name, Is.EqualTo("Sophie Ellis-Bextor"));
			Assert.That(@group1.ScreenName, Is.EqualTo("sophieellisbextor"));
			Assert.That(@group1.IsClosed, Is.EqualTo(GroupPublicity.Public));
			Assert.That(@group1.Type, Is.EqualTo(GroupType.Page));
			Assert.That(@group1.IsAdmin, Is.EqualTo(false));
			Assert.That(@group1.IsMember, Is.EqualTo(false));
			Assert.That(@group1.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs417031.vk.me/v417031989/59cb/65zF-xnOQsk.jpg")));
			Assert.That(@group1.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs417031.vk.me/v417031989/59ca/eOJ7ER_eJok.jpg")));
			Assert.That(@group1.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs417031.vk.me/v417031989/59c8/zI9aAlI-PHc.jpg")));
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

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.GetFollowers(1, 2, 3, skipAuthorization: false);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(2));

			Assert.That(result[0].Id, Is.EqualTo(5984118));
			Assert.That(result[1].Id, Is.EqualTo(179652233));
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

            var cat = GetMockedUsersCategory(url, json);

			var users = cat.GetFollowers(1, 2, 3, ProfileFields.All, NameCase.Gen, false);
			Assert.That(users, Is.Not.Null);
			Assert.That(users.Count, Is.EqualTo(2));

			var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);

			Assert.That(user.Id, Is.EqualTo(243663122));
			Assert.That(user.FirstName, Is.EqualTo("Ивана"));
			Assert.That(user.LastName, Is.EqualTo("Радюна"));
			Assert.That(user.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user.Nickname, Is.EqualTo(string.Empty));
			Assert.That(user.Domain, Is.EqualTo("id243663122"));
			Assert.That(user.BirthDate, Is.EqualTo("27.8.1985"));
			Assert.That(user.City.Id, Is.EqualTo(18632));
			Assert.That(user.City.Title, Is.EqualTo("Вороново"));
			Assert.That(user.Country.Id, Is.EqualTo(3));
			Assert.That(user.Country.Title, Is.EqualTo("Беларусь"));
			Assert.That(user.Timezone, Is.EqualTo(3));
			Assert.That(user.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs606327.vk.me/v606327122/35ac/R57FNUr34iw.jpg")));
			Assert.That(user.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs606327.vk.me/v606327122/35ab/HUsGNVxBoQU.jpg")));
			Assert.That(user.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg")));
			Assert.That(user.PhotoPreviews.PhotoMax, Is.EqualTo(new Uri("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg")));
			Assert.That(user.HasMobile, Is.EqualTo(true));
			Assert.That(user.Online, Is.EqualTo(true));
			Assert.That(user.OnlineMobile, Is.EqualTo(true));
			Assert.That(user.CanPost, Is.EqualTo(false));
			Assert.That(user.CanSeeAllPosts, Is.EqualTo(true));
			Assert.That(user.CanSeeAudio, Is.EqualTo(true));
			Assert.That(user.CanWritePrivateMessage, Is.EqualTo(true));
			Assert.That(user.MobilePhone, Is.EqualTo(string.Empty));
			Assert.That(user.HomePhone, Is.EqualTo(string.Empty));
			Assert.That(user.Site, Is.EqualTo(string.Empty));
			Assert.That(user.Status, Is.EqualTo("Пусть ветер гудит в проводах пусть будет осенняя влага пусть люди забудут о нас,но ни забудем друг друга."));
			Assert.That(user.LastSeen.Time, Is.EqualTo(DateHelper.TimeStampToDateTime(1392710539)));
			Assert.That(user.CommonCount, Is.EqualTo(0));
			Assert.That(user.Universities.Count, Is.EqualTo(0));
			Assert.That(user.Relation, Is.EqualTo(RelationType.InActiveSearch));
			Assert.That(user.Schools.Count, Is.EqualTo(0));
			Assert.That(user.Relatives.Count, Is.EqualTo(0));

			var user1 = users.Skip(1).FirstOrDefault();
			Assert.That(user1, Is.Not.Null);

			Assert.That(user1.Id, Is.EqualTo(239897398));
			Assert.That(user1.FirstName, Is.EqualTo("Софійки"));
			Assert.That(user1.LastName, Is.EqualTo("Довгалюк"));
			Assert.That(user1.Sex, Is.EqualTo(Sex.Female));
			Assert.That(user1.Nickname, Is.EqualTo(string.Empty));
			Assert.That(user1.Domain, Is.EqualTo("id239897398"));
			Assert.That(user1.BirthDate, Is.EqualTo("16.6.2000"));
			Assert.That(user1.City.Id, Is.EqualTo(1559));
			Assert.That(user1.City.Title, Is.EqualTo("Тернополь"));
			Assert.That(user1.Country.Id, Is.EqualTo(2));
			Assert.That(user1.Country.Title, Is.EqualTo("Украина"));
			Assert.That(user1.Timezone, Is.EqualTo(1));
			Assert.That(user1.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs310121.vk.me/v310121398/8023/LMm-uoyk1-M.jpg")));
			Assert.That(user1.PhotoPreviews.Photo100, Is.EqualTo(new Uri("http://cs310121.vk.me/v310121398/8022/KajnVK0lvFA.jpg")));
			Assert.That(user1.PhotoPreviews.Photo200, Is.EqualTo(new Uri("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg")));
			Assert.That(user1.PhotoPreviews.PhotoMax, Is.EqualTo(new Uri("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg")));
			Assert.That(user1.HasMobile, Is.EqualTo(true));
			Assert.That(user1.Online, Is.EqualTo(true));
			Assert.That(user1.CanPost, Is.EqualTo(false));
			Assert.That(user1.CanSeeAllPosts, Is.EqualTo(true));
			Assert.That(user1.CanSeeAudio, Is.EqualTo(true));
			Assert.That(user1.CanWritePrivateMessage, Is.EqualTo(true));
			Assert.That(user1.MobilePhone, Is.EqualTo("**********"));
			Assert.That(user1.HomePhone, Is.EqualTo("*****"));
			Assert.That(user1.Connections.Skype, Is.EqualTo("немає"));
			Assert.That(user1.Site, Is.EqualTo(string.Empty));
			Assert.That(user1.Status, Is.EqualTo("Не варто ображатися на людей за те, що вони не виправдали наших очікувань... ми самі винні, що чекали від них більше, ніж варто було!"));
			Assert.That(user1.LastSeen.Time, Is.EqualTo(new DateTime(2014, 2, 18, 8, 1, 14, DateTimeKind.Utc).ToLocalTime()));
			Assert.That(user1.CommonCount, Is.EqualTo(0));
			Assert.That(user1.Universities.Count, Is.EqualTo(0));
			Assert.That(user1.Relation, Is.EqualTo(RelationType.Unknown));
			Assert.That(user1.Schools.Count, Is.EqualTo(0));
			Assert.That(user1.Relatives.Count, Is.EqualTo(2));
			Assert.That(user1.Relatives[0].Id, Is.EqualTo(222462523));
			Assert.That(user1.Relatives[0].Type, Is.EqualTo(RelativeType.Sibling));
			Assert.That(user1.Relatives[1].Id, Is.EqualTo(207105159));
			Assert.That(user1.Relatives[1].Type, Is.EqualTo(RelativeType.Sibling));
		}

		[Test]
        public void Report_NormalCase()
        {
            const string url = "https://api.vk.com/method/users.report";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedUsersCategory(url, json);

			var result = cat.Report(243663122, ReportType.Insult, "комментарий");

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
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

            var cat = GetMockedUsersCategory(url, json);

			var screenNames = new [] {"dm", "durov"};
            var fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.City;
			var users = cat.Get(screenNames, fields, NameCase.Gen, false);

			Assert.That(users, Is.Not.Null);
			Assert.That(users.Count, Is.EqualTo(2));

	        var user = users.FirstOrDefault();
			Assert.That(user, Is.Not.Null);

			Assert.That(user.Id, Is.EqualTo(53083705));
			Assert.That(user.FirstName, Is.EqualTo("Дмитрия"));
			Assert.That(user.LastName, Is.EqualTo("Медведева"));
			Assert.That(user.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user.City.Id, Is.EqualTo(1));
			Assert.That(user.City.Title, Is.EqualTo("Москва"));

			var user1 = users.Skip(1).FirstOrDefault();
			Assert.That(user1, Is.Not.Null);
			Assert.That(user1.Id, Is.EqualTo(1));
			Assert.That(user1.FirstName, Is.EqualTo("Павла"));
			Assert.That(user1.LastName, Is.EqualTo("Дурова"));
			Assert.That(user1.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user1.City.Id, Is.EqualTo(2));
			Assert.That(user1.City.Title, Is.EqualTo("Санкт-Петербург"));
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

            var cat = GetMockedUsersCategory(url, json);

			var fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.City;
            var user = cat.Get("dm", fields, NameCase.Gen, false);

			Assert.That(user, Is.Not.Null);

			Assert.That(user.Id, Is.EqualTo(53083705));
			Assert.That(user.FirstName, Is.EqualTo("Дмитрия"));
			Assert.That(user.LastName, Is.EqualTo("Медведева"));
			Assert.That(user.Sex, Is.EqualTo(Sex.Male));
			Assert.That(user.City.Id, Is.EqualTo(1));
			Assert.That(user.City.Title, Is.EqualTo("Москва"));
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