namespace VkNet.Tests.Categories
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using VkNet.Categories;
    
    using Enums;
    using Exception;
    using Model;
    using Enums.Filters;
    using Enums.SafetyEnums;

    using VkNet.Utils;
    using FluentNUnit;

    [TestFixture]
    public class UsersCategoryTest
    {
        private const string Query = "Masha Ivanova";

        [SetUp]
        public void SetUp()
        {
        
        }

        private UsersCategory GetMockedUsersCategory(string url, string json)
        {
#if false // async version
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json && m.GetJsonAsync(url) == Task.FromResult(json));
#endif
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json && m.GetJson(url) == json);

            return new UsersCategory(new VkApi { AccessToken = "token", Browser = browser});
        }

        [Test]
        public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());

            This.Action(() => users.Get(1)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Get_NotAccessToInternet_ThrowVkApiException()
        {   
            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetJson(It.IsAny<string>())).Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));

            var users = new UsersCategory(new VkApi {AccessToken = "asgsstsfast", Browser = mockBrowser.Object});

            var ex = This.Action(() => users.Get(1)).Throws<VkApiException>(); 
            ex.Message.ShouldEqual("The remote name could not be resolved: 'api.vk.com'");
        }

        [Test]
        public void Get_WrongAccesToken_Throw_ThrowUserAuthorizationException()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=1&v=5.9&access_token=token";

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
            var ex = This.Action(() => users.Get(1)).Throws<UserAuthorizationFailException>();
            ex.Message.ShouldEqual("User authorization failed: invalid access_token.");
        }

        [Test]
        public void Get_WithSomeFields_FirstNameLastNameEducation()
        {
            const string url = "https://api.vk.com/method/users.get?fields=first_name,last_name,education&user_ids=1&v=5.9&access_token=token";
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

            UsersCategory users = GetMockedUsersCategory(url, json);

            // act
            var fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Education;
            User p = users.Get(1, fields);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Id, Is.EqualTo(1));
            Assert.That(p.FirstName, Is.EqualTo("Павел"));
            Assert.That(p.LastName, Is.EqualTo("Дуров"));
            Assert.That(p.Education, Is.Not.Null);
            Assert.That(p.Education.UniversityId, Is.EqualTo(1));
            Assert.That(p.Education.UniversityName, Is.EqualTo("СПбГУ"));
            Assert.That(p.Education.FacultyId, Is.Null);
            Assert.That(p.Education.FacultyName, Is.EqualTo(""));
            Assert.That(p.Education.Graduation, Is.EqualTo(2006));
        }

        [Test]
        public void Get_CountersFields_CountersObject()
        {
            const string url = "https://api.vk.com/method/users.get?fields=counters&user_ids=1&v=5.9&access_token=token";
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
            User p = users.Get(1, ProfileFields.Counters);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Id, Is.EqualTo(1));
            Assert.That(p.FirstName, Is.EqualTo("Павел"));
            Assert.That(p.LastName, Is.EqualTo("Дуров"));
            Assert.That(p.Counters, Is.Not.Null);
            Assert.That(p.Counters.Albums, Is.EqualTo(1));
            Assert.That(p.Counters.Videos, Is.EqualTo(8));
            Assert.That(p.Counters.Audios, Is.EqualTo(0));
            Assert.That(p.Counters.Notes, Is.EqualTo(6));
            Assert.That(p.Counters.Photos, Is.EqualTo(153));
            Assert.That(p.Counters.Friends, Is.EqualTo(689));
            Assert.That(p.Counters.OnlineFriends, Is.EqualTo(85));
            Assert.That(p.Counters.MutualFriends, Is.EqualTo(0));
            Assert.That(p.Counters.Followers, Is.EqualTo(5937280));
            Assert.That(p.Counters.Subscriptions, Is.EqualTo(0));
            Assert.That(p.Counters.Pages, Is.EqualTo(51));
        }

        [Test]
        public void Get_DefaultFields_UidFirstNameLastName()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=1&v=5.9&access_token=token";
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

            UsersCategory users = GetMockedUsersCategory(url, json);

            // act
            User p = users.Get(1);

            // assert
            Assert.That(p.Id, Is.EqualTo(1));
            Assert.That(p.FirstName, Is.EqualTo("Павел"));
            Assert.That(p.LastName, Is.EqualTo("Дуров"));
        }

        [Test]
        public void Get_Multiple_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            This.Action(() => users.Get(new long[] {1, 2})).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Get_EmptyListOfUids_ThrowArgumentNullException()
        {
            var users = new UsersCategory(new VkApi { AccessToken = "token" });
            IEnumerable<long> userIds = null;
            This.Action(() => users.Get(userIds)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Get_Mutliple_TwoUidsDefaultFields_TwoProfiles()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=1,672&v=5.21&access_token=token";
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
            ReadOnlyCollection<User> lst = users.Get(new long[] {1, 672});

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
            const string url = "https://api.vk.com/method/users.get?fields=education&user_ids=1,5041431&v=5.9&access_token=token";
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

            UsersCategory users = GetMockedUsersCategory(url, json);
            ReadOnlyCollection<User> lst = users.Get(new long[] {1, 5041431}, ProfileFields.Education);

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
        public void IsAppUser_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            This.Action(() => users.IsAppUser(1)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetUserSettings_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            This.Action(() => vk.Users.GetUserSettings(100)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetUserSettings_AccessToFriends_Return2()
        {
            const string url = "https://api.vk.com/method/getUserSettings?uid=1&access_token=token";

            const string json =
                @"{
                    'response': 2
                  }";

            var users = GetMockedUsersCategory(url, json);
            int settings = users.GetUserSettings(1);

            Assert.That(settings, Is.EqualTo(2));
        }

        [Test]
        public void Search_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            int count;
            This.Action(() => vk.Users.Search(Query, out count)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Search_EmptyQuery_ThrowArgumentException()
        {
            int count;
            var vk = new VkApi { AccessToken = "token" };
            This.Action(() => vk.Users.Search("", out count)).Throws<ArgumentException>()
                .Message.ShouldEqual("Query can not be null or empty.");
        }

        [Test]
        public void Search_BadQuery_EmptyList()
        {
            const string url = "https://api.vk.com/method/users.search?q=fa'sosjvsoidf&count=20&access_token=token";

            const string json =
                @"{
                    'response': [
                      0
                    ]
                  }";

            int count;
            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search("fa'sosjvsoidf", out count).ToList();

            Assert.That(count, Is.EqualTo(0));
            Assert.That(lst, Is.Not.Null);
            Assert.That(lst.Count, Is.EqualTo(0));
        }

        [Test]
        public void Search_EducationField_ListofProfileObjects()
        {
            const string url = "https://api.vk.com/method/users.search?q=Masha Ivanova&fields=education&count=3&offset=123&access_token=token";

            const string json =
                @"{
                    'response': [
                      26953,
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
                  }";

            int count;
            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(Query, out count, ProfileFields.Education, 3, 123).ToList();

            Assert.That(count, Is.EqualTo(26953));
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
        public void Search_DefaultFields_ListOfProfileObjects()
        {
            const string url = "https://api.vk.com/method/users.search?q=Masha Ivanova&count=20&access_token=token";

            const string json =
                @"{
                    'response': [
                      26953,
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
                  }";

            int count;
            var users = GetMockedUsersCategory(url, json);
            var lst = users.Search(Query, out count).ToList();

            Assert.That(count, Is.EqualTo(26953));
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
            const string url = "https://api.vk.com/method/users.isAppUser?user_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 0
                  }";

            UsersCategory cat = GetMockedUsersCategory(url, json);

            bool result = cat.IsAppUser(1);

            result.ShouldBeFalse();
        }

        [Test]
        public void IsAppUser_5_5_version_of_api_return_true()
        {
            const string url = "https://api.vk.com/method/users.isAppUser?user_id=123&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            UsersCategory cat = GetMockedUsersCategory(url, json);

            bool result = cat.IsAppUser(123);

            result.ShouldBeTrue();
        }

        [Test]
        public void Get_ListOfUsers()
        {
            const string url = "https://api.vk.com/method/users.get?fields=uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections,site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message,status,last_seen,common_count,relation,relatives,counters,nickname,timezone&name_case=gen&user_ids=1&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            ReadOnlyCollection<User> result = cat.Get(new long[] {1}, ProfileFields.All, NameCase.Gen);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(1);
            
            var u = result[0];
            u.Id.ShouldEqual(1);
            u.FirstName.ShouldEqual("Павла");
            u.LastName.ShouldEqual("Дурова");
            u.Sex.ShouldEqual(Sex.Male);
            u.Nickname.ShouldEqual(string.Empty);
            u.Domain.ShouldEqual("durov");
            u.BirthDate.ShouldEqual("10.10.1984");
            u.City.ShouldNotBeNull();
            u.City.Id.ShouldEqual(2);
            u.City.Title.ShouldEqual("Санкт-Петербург");
            u.Country.ShouldNotBeNull();
            u.Country.Id.ShouldEqual(1);
            u.Country.Title.ShouldEqual("Россия");
            u.Timezone.ShouldEqual(3);
            u.PhotoPreviews.Photo50.ShouldEqual("http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg");
            u.PhotoPreviews.Photo100.ShouldEqual("http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg");
            u.PhotoPreviews.Photo200.ShouldEqual("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg");
            u.PhotoPreviews.Photo400.ShouldEqual("http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg");
            u.PhotoPreviews.PhotoMax.ShouldEqual("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg");
            u.HasMobile.HasValue.ShouldBeTrue();
            u.HasMobile.Value.ShouldBeTrue();
            u.Online.HasValue.ShouldBeTrue();
            u.Online.Value.ShouldBeTrue();
            u.CanPost.ShouldBeFalse();
            u.CanSeeAllPosts.ShouldBeFalse();
            u.CanSeeAudio.ShouldBeFalse();
            u.CanWritePrivateMessage.ShouldBeFalse();
            u.Connections.Twitter.ShouldEqual("durov");
            u.Site.ShouldEqual(string.Empty);
            u.Status.ShouldEqual(string.Empty);
            // TODO: u.LastSeen
            u.CommonCount.Value.ShouldEqual(0);
            u.Counters.Albums.ShouldEqual(1);
            u.Counters.Videos.ShouldEqual(8);
            u.Counters.Audios.ShouldEqual(0);
            u.Counters.Notes.Value.ShouldEqual(6);
            u.Counters.Photos.Value.ShouldEqual(153);
            u.Counters.Friends.Value.ShouldEqual(688);
            u.Counters.OnlineFriends.ShouldEqual(146);
            u.Counters.MutualFriends.ShouldEqual(0);
            u.Counters.Followers.ShouldEqual(5934786);
            u.Counters.Subscriptions.ShouldEqual(0);
            u.Counters.Pages.ShouldEqual(51);
            u.Universities.Count.ShouldEqual(1);
            u.Universities[0].Id.ShouldEqual(1);
            u.Universities[0].Country.ShouldEqual(1);
            u.Universities[0].City.ShouldEqual(2);
            u.Universities[0].Name.ShouldEqual("СПбГУ");
            u.Universities[0].Graduation.ShouldEqual(2006);

            u.Schools.Count.ShouldEqual(2);
            u.Schools[0].Id.ShouldEqual(1035386);
            u.Schools[0].Country.ShouldEqual(88);
            u.Schools[0].City.ShouldEqual(16);
            u.Schools[0].Name.ShouldEqual("Sc.Elem. Coppino - Falletti di Barolo");
            u.Schools[0].YearFrom.ShouldEqual(1990);
            u.Schools[0].YearTo.ShouldEqual(1992);
            u.Schools[0].Class.ShouldEqual(string.Empty);

            u.Schools[1].Id.ShouldEqual(1);
            u.Schools[1].Country.ShouldEqual(1);
            u.Schools[1].City.ShouldEqual(2);
            u.Schools[1].Name.ShouldEqual("Академическая (АГ) СПбГУ");
            u.Schools[1].YearFrom.ShouldEqual(1996);
            u.Schools[1].YearTo.ShouldEqual(2001);
            u.Schools[1].YearGraduated.ShouldEqual(2001);
            u.Schools[1].Class.ShouldEqual("о");
            u.Schools[1].Type.ShouldEqual(1);
            u.Schools[1].TypeStr.ShouldEqual("Гимназия");

            u.Relatives.Count.ShouldEqual(0);
        }

        [Test]
        public void Get_SingleUser()
        {
            const string url = "https://api.vk.com/method/users.get?fields=uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections,site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message,status,last_seen,common_count,relation,relatives,counters,nickname,timezone&name_case=gen&user_ids=1&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            User u = cat.Get(1, ProfileFields.All, NameCase.Gen);

            u.ShouldNotBeNull();
            u.Id.ShouldEqual(1);
            u.FirstName.ShouldEqual("Павла");
            u.LastName.ShouldEqual("Дурова");
            u.Sex.ShouldEqual(Sex.Male);
            u.Nickname.ShouldEqual(string.Empty);
            u.Domain.ShouldEqual("durov");
            u.BirthDate.ShouldEqual("10.10.1984");
            u.City.ShouldNotBeNull();
            u.City.Id.ShouldEqual(2);
            u.City.Title.ShouldEqual("Санкт-Петербург");
            u.Country.ShouldNotBeNull();
            u.Country.Id.ShouldEqual(1);
            u.Country.Title.ShouldEqual("Россия");
            u.Timezone.ShouldEqual(3);
            u.PhotoPreviews.Photo50.ShouldEqual("http://cs7004.vk.me/c7003/v7003079/374b/53lwetwOxD8.jpg");
            u.PhotoPreviews.Photo100.ShouldEqual("http://cs7004.vk.me/c7003/v7003563/359e/Hei0g6eeaAc.jpg");
            u.PhotoPreviews.Photo200.ShouldEqual("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg");
            u.PhotoPreviews.Photo400.ShouldEqual("http://cs7004.vk.me/c7003/v7003397/3824/JjPJbkvJxpM.jpg");
            u.PhotoPreviews.PhotoMax.ShouldEqual("http://cs7004.vk.me/c7003/v7003237/369a/x4RqtBxY4kc.jpg");
            u.HasMobile.HasValue.ShouldBeTrue();
            u.HasMobile.Value.ShouldBeTrue();
            u.Online.HasValue.ShouldBeTrue();
            u.Online.Value.ShouldBeTrue();
            u.CanPost.ShouldBeFalse();
            u.CanSeeAllPosts.ShouldBeFalse();
            u.CanSeeAudio.ShouldBeFalse();
            u.CanWritePrivateMessage.ShouldBeFalse();
            u.Connections.Twitter.ShouldEqual("durov");
            u.Site.ShouldEqual(string.Empty);
            u.Status.ShouldEqual(string.Empty);
            // TODO: u.LastSeen
            u.CommonCount.Value.ShouldEqual(0);
            u.Counters.Albums.ShouldEqual(1);
            u.Counters.Videos.ShouldEqual(8);
            u.Counters.Audios.ShouldEqual(0);
            u.Counters.Notes.Value.ShouldEqual(6);
            u.Counters.Photos.Value.ShouldEqual(153);
            u.Counters.Friends.Value.ShouldEqual(688);
            u.Counters.OnlineFriends.ShouldEqual(146);
            u.Counters.MutualFriends.ShouldEqual(0);
            u.Counters.Followers.ShouldEqual(5934786);
            u.Counters.Subscriptions.ShouldEqual(0);
            u.Counters.Pages.ShouldEqual(51);
            u.Universities.Count.ShouldEqual(1);
            u.Universities[0].Id.ShouldEqual(1);
            u.Universities[0].Country.ShouldEqual(1);
            u.Universities[0].City.ShouldEqual(2);
            u.Universities[0].Name.ShouldEqual("СПбГУ");
            u.Universities[0].Graduation.ShouldEqual(2006);

            u.Schools.Count.ShouldEqual(2);
            u.Schools[0].Id.ShouldEqual(1035386);
            u.Schools[0].Country.ShouldEqual(88);
            u.Schools[0].City.ShouldEqual(16);
            u.Schools[0].Name.ShouldEqual("Sc.Elem. Coppino - Falletti di Barolo");
            u.Schools[0].YearFrom.ShouldEqual(1990);
            u.Schools[0].YearTo.ShouldEqual(1992);
            u.Schools[0].Class.ShouldEqual(string.Empty);

            u.Schools[1].Id.ShouldEqual(1);
            u.Schools[1].Country.ShouldEqual(1);
            u.Schools[1].City.ShouldEqual(2);
            u.Schools[1].Name.ShouldEqual("Академическая (АГ) СПбГУ");
            u.Schools[1].YearFrom.ShouldEqual(1996);
            u.Schools[1].YearTo.ShouldEqual(2001);
            u.Schools[1].YearGraduated.ShouldEqual(2001);
            u.Schools[1].Class.ShouldEqual("о");
            u.Schools[1].Type.ShouldEqual(1);
            u.Schools[1].TypeStr.ShouldEqual("Гимназия");

            u.Relatives.Count.ShouldEqual(0);
        }

        [Test]
        public void Get_DeletedUser()
        {
            const string url = "https://api.vk.com/method/users.get?fields=first_name,last_name,education&user_ids=4793858&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            User user = cat.Get(4793858, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Education);

            user.ShouldNotBeNull();
            user.Id.ShouldEqual(4793858);
            user.FirstName.ShouldEqual("Антон");
            user.LastName.ShouldEqual("Жидков");
            user.DeactiveReason.ShouldEqual("deleted");
            user.IsDeactivated.ShouldBeTrue();
        }

        [Test]
        public void GetSubscriptions_Extended()
        {
            const string url = "https://api.vk.com/method/users.getSubscriptions?user_id=1&extended=1&offset=3&count=2&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            ReadOnlyCollection<Group> result = cat.GetSubscriptions(1, 2, 3);

            result.Count.ShouldEqual(2);
            result[0].Id.ShouldEqual(32295218);
            result[0].Name.ShouldEqual("LIVE Экспресс");
            result[0].ScreenName.ShouldEqual("liveexp");
            result[0].IsClosed.ShouldEqual(GroupPublicity.Public);
            result[0].Type.ShouldEqual(GroupType.Page);
            result[0].IsAdmin.ShouldBeFalse();
            result[0].IsMember.ShouldEqual(false);
            result[0].PhotoPreviews.Photo50.ShouldEqual("http://cs412129.vk.me/v412129558/6cea/T3jVq9A5hN4.jpg");
            result[0].PhotoPreviews.Photo100.ShouldEqual("http://cs412129.vk.me/v412129558/6ce9/Rs47ldlt4Ko.jpg");
            result[0].PhotoPreviews.Photo200.ShouldEqual("http://cs412129.vk.me/v412129604/1238/RhEgZqrsv-w.jpg");

            result[1].Id.ShouldEqual(43694972);
            result[1].Name.ShouldEqual("Sophie Ellis-Bextor");
            result[1].ScreenName.ShouldEqual("sophieellisbextor");
            result[1].IsClosed.ShouldEqual(GroupPublicity.Public);
            result[1].Type.ShouldEqual(GroupType.Page);
            result[1].IsAdmin.ShouldEqual(false);
            result[1].IsMember.ShouldEqual(false);
            result[1].PhotoPreviews.Photo50.ShouldEqual("http://cs417031.vk.me/v417031989/59cb/65zF-xnOQsk.jpg");
            result[1].PhotoPreviews.Photo100.ShouldEqual("http://cs417031.vk.me/v417031989/59ca/eOJ7ER_eJok.jpg");
            result[1].PhotoPreviews.Photo200.ShouldEqual("http://cs417031.vk.me/v417031989/59c8/zI9aAlI-PHc.jpg");
        }

        [Test]
        public void GetFollowers_WithoutFields()
        {
            const string url = "https://api.vk.com/method/users.getFollowers?user_id=1&offset=3&count=2&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            ReadOnlyCollection<User> result = cat.GetFollowers(1, 2, 3);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(2);
            result[0].Id.ShouldEqual(5984118);
            result[1].Id.ShouldEqual(179652233);
        }

        [Test]
        public void GetFollowers_WithAllFields()
        {
            const string url = "https://api.vk.com/method/users.getFollowers?user_id=1&offset=3&count=2&fields=uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections,site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message,status,last_seen,common_count,relation,relatives,counters,nickname,timezone&name_case=gen&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            ReadOnlyCollection<User> result = cat.GetFollowers(1, 2, 3, ProfileFields.All, NameCase.Gen);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(2);

            result[0].Id.ShouldEqual(243663122);
            result[0].FirstName.ShouldEqual("Ивана");
            result[0].LastName.ShouldEqual("Радюна");
            result[0].Sex.ShouldEqual(Sex.Male);
            result[0].Nickname.ShouldEqual(string.Empty);
            result[0].Domain.ShouldEqual("id243663122");
            result[0].BirthDate.ShouldEqual("27.8.1985");
            result[0].City.Id.ShouldEqual(18632);
            result[0].City.Title.ShouldEqual("Вороново");
            result[0].Country.Id.ShouldEqual(3);
            result[0].Country.Title.ShouldEqual("Беларусь");
            result[0].Timezone.ShouldEqual(3);
            result[0].PhotoPreviews.Photo50.ShouldEqual("http://cs606327.vk.me/v606327122/35ac/R57FNUr34iw.jpg");
            result[0].PhotoPreviews.Photo100.ShouldEqual("http://cs606327.vk.me/v606327122/35ab/HUsGNVxBoQU.jpg");
            result[0].PhotoPreviews.Photo200.ShouldEqual("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg");
            result[0].PhotoPreviews.PhotoMax.ShouldEqual("http://cs606327.vk.me/v606327122/35aa/4SIM1EWPmes.jpg");
            result[0].HasMobile.ShouldEqual(true);
            result[0].Online.ShouldEqual(true);
            result[0].OnlineMobile.ShouldEqual(true);
            result[0].CanPost.ShouldEqual(false);
            result[0].CanSeeAllPosts.ShouldEqual(true);
            result[0].CanSeeAudio.ShouldEqual(true);
            result[0].CanWritePrivateMessage.ShouldEqual(true);
            result[0].MobilePhone.ShouldEqual(string.Empty);
            result[0].HomePhone.ShouldEqual(string.Empty);
            result[0].Site.ShouldEqual(string.Empty);
            result[0].Status.ShouldEqual("Пусть ветер гудит в проводах пусть будет осенняя влага пусть люди забудут о нас,но ни забудем друг друга.");
            result[0].LastSeen.ShouldEqual(new DateTime(2014, 2, 18, 8, 2, 19, DateTimeKind.Utc).ToLocalTime());
            result[0].CommonCount.ShouldEqual(0);
            result[0].Universities.Count.ShouldEqual(0);
            result[0].Relation.ShouldEqual(RelationType.InActiveSearch);
            result[0].Schools.Count.ShouldEqual(0);
            result[0].Relatives.Count.ShouldEqual(0);

            result[1].Id.ShouldEqual(239897398);
            result[1].FirstName.ShouldEqual("Софійки");
            result[1].LastName.ShouldEqual("Довгалюк");
            result[1].Sex.ShouldEqual(Sex.Female);
            result[1].Nickname.ShouldEqual(string.Empty);
            result[1].Domain.ShouldEqual("id239897398");
            result[1].BirthDate.ShouldEqual("16.6.2000");
            result[1].City.Id.ShouldEqual(1559);
            result[1].City.Title.ShouldEqual("Тернополь");
            result[1].Country.Id.ShouldEqual(2);
            result[1].Country.Title.ShouldEqual("Украина");
            result[1].Timezone.ShouldEqual(1);
            result[1].PhotoPreviews.Photo50.ShouldEqual("http://cs310121.vk.me/v310121398/8023/LMm-uoyk1-M.jpg");
            result[1].PhotoPreviews.Photo100.ShouldEqual("http://cs310121.vk.me/v310121398/8022/KajnVK0lvFA.jpg");
            result[1].PhotoPreviews.Photo200.ShouldEqual("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg");
            result[1].PhotoPreviews.PhotoMax.ShouldEqual("http://cs310121.vk.me/v310121398/8021/u0l0caRL1lY.jpg");
            result[1].HasMobile.ShouldEqual(true);
            result[1].Online.ShouldEqual(true);
            result[1].CanPost.ShouldEqual(false);
            result[1].CanSeeAllPosts.ShouldEqual(true);
            result[1].CanSeeAudio.ShouldEqual(true);
            result[1].CanWritePrivateMessage.ShouldEqual(true);
            result[1].MobilePhone.ShouldEqual("**********");
            result[1].HomePhone.ShouldEqual("*****");
            result[1].Connections.Skype.ShouldEqual("немає");
            result[1].Site.ShouldEqual(string.Empty);
            result[1].Status.ShouldEqual("Не варто ображатися на людей за те, що вони не виправдали наших очікувань... ми самі винні, що чекали від них більше, ніж варто було!");
            result[1].LastSeen.ShouldEqual(new DateTime(2014, 2, 18, 8, 1, 14, DateTimeKind.Utc).ToLocalTime());
            result[1].CommonCount.ShouldEqual(0);
            result[1].Universities.Count.ShouldEqual(0);
            result[1].Relation.ShouldEqual(RelationType.Unknown);
            result[1].Schools.Count.ShouldEqual(0);
            result[1].Relatives.Count.ShouldEqual(2);
            result[1].Relatives[0].Id.ShouldEqual(222462523);
            result[1].Relatives[0].Type.ShouldEqual("sibling");

            result[1].Relatives[1].Id.ShouldEqual(207105159);
            result[1].Relatives[1].Type.ShouldEqual("sibling");
        }

        [Test]
        public void Report_NormalCase()
        {
            const string url = "https://api.vk.com/method/users.report?user_id=243663122&type=insult&comment=комментарий&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            UsersCategory cat = GetMockedUsersCategory(url, json);

            bool result = cat.Report(243663122, ReportType.Insult, "комментарий");

            result.ShouldBeTrue();
        }

        [Test]
        public void Get_DmAndDurov_ListOfUsers()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=dm,durov&fields=first_name,last_name,sex,city&name_case=gen&v=5.9&access_token=token";
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

            var screenNames = new [] {"dm", "durov"};
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.City;
            ReadOnlyCollection<User> users = cat.Get(screenNames, fields, NameCase.Gen);

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

        [Test]
        public void Get_Dimon_SingleUser()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=dm&fields=first_name,last_name,sex,city&name_case=gen&v=5.9&access_token=token";
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

            UsersCategory cat = GetMockedUsersCategory(url, json);

            ProfileFields fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.City;
            User user = cat.Get("dm", fields, NameCase.Gen);

            user.ShouldNotBeNull();

            user.Id.ShouldEqual(53083705);
            user.FirstName.ShouldEqual("Дмитрия");
            user.LastName.ShouldEqual("Медведева");
            user.Sex.ShouldEqual(Sex.Male);
            user.City.Id.ShouldEqual(1);
            user.City.Title.ShouldEqual("Москва");
        }

#if false
        #region Async methods

        [Test]
        public async Task Async_GetAsync_DmAndDurov_ListOfUsers()
        {
            const string url = "https://api.vk.com/method/users.get?user_ids=dm,durov&fields=first_name,last_name,sex,city&name_case=gen&v=5.9&access_token=token";
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