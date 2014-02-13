using System;
using System.Collections.ObjectModel;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
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
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            return new UsersCategory(new VkApi { AccessToken = "token", Browser = browser.Object });
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            users.Get(1);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "The remote name could not be resolved: 'api.vk.com'")]
        public void Get_NotAccessToInternet_ThrowVkApiException()
        {   
            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetJson(It.IsAny<string>())).Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));

            var users = new UsersCategory(new VkApi {AccessToken = "asgsstsfast", Browser = mockBrowser.Object});

            users.Get(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
        public void Get_WrongAccesToken_Throw_ThrowUserAuthorizationException()
        {
            const string url = "https://api.vk.com/method/getProfiles?uid=1&access_token=token";

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
            users.Get(1);
        }

        [Test]
        public void Get_WithSomeFields_FirstNameLastNameEducation()
        {
            const string url = "https://api.vk.com/method/getProfiles?uid=1&fields=first_name,last_name,education&access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'uid': 1,
                        'first_name': 'Павел',
                        'last_name': 'Дуров',
                        'university': '1',
                        'university_name': 'СПбГУ',
                        'faculty': '0',
                        'faculty_name': '',
                        'graduation': '0'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);

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
            Assert.That(p.Education.Graduation, Is.Null);
        }

        [Test]
        public void Get_CountersFields_CountersObject()
        {
            const string url = "https://api.vk.com/method/getProfiles?uid=4793858&fields=counters&access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'uid': 4793858,
                        'first_name': 'Антон',
                        'last_name': 'Жидков',
                        'counters': {
                          'albums': 1,
                          'videos': 100,
                          'audios': 153,
                          'notes': 3,
                          'photos': 54,
                          'groups': 40,
                          'friends': 371,
                          'online_friends': 44,
                          'mutual_friends': 2,
                          'user_photos': 164,
                          'user_videos': 87,
                          'followers': 1,
                          'subscriptions': 1,
                          'pages': 1
                        }
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            // act
            User p = users.Get(4793858, ProfileFields.Counters);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Id, Is.EqualTo(4793858));
            Assert.That(p.FirstName, Is.EqualTo("Антон"));
            Assert.That(p.LastName, Is.EqualTo("Жидков"));
            Assert.That(p.Counters, Is.Not.Null);
            Assert.That(p.Counters.Albums, Is.EqualTo(1));
            Assert.That(p.Counters.Videos, Is.EqualTo(100));
            Assert.That(p.Counters.Audios, Is.EqualTo(153));
            Assert.That(p.Counters.Notes, Is.EqualTo(3));
            Assert.That(p.Counters.Photos, Is.EqualTo(54));
            Assert.That(p.Counters.Groups, Is.EqualTo(40));
            Assert.That(p.Counters.Friends, Is.EqualTo(371));
            Assert.That(p.Counters.OnlineFriends, Is.EqualTo(44));
            Assert.That(p.Counters.MutualFriends, Is.EqualTo(2));
            Assert.That(p.Counters.UserPhotos, Is.EqualTo(164));
            Assert.That(p.Counters.UserVideos, Is.EqualTo(87));
            Assert.That(p.Counters.Followers, Is.EqualTo(1));
            Assert.That(p.Counters.Subscriptions, Is.EqualTo(1));
            Assert.That(p.Counters.Pages, Is.EqualTo(1));
        }

        [Test]
        public void Get_DefaultFields_UidFirstNameLastName()
        {
            const string url = "https://api.vk.com/method/getProfiles?uid=4793858&access_token=token";
            const string json =
                @"{
                    'response': [
                      {
                        'uid': 4793858,
                        'first_name': 'Антон',
                        'last_name': 'Жидков'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);

            // act
            User p = users.Get(4793858);

            // assert
            Assert.That(p.Id, Is.EqualTo(4793858));
            Assert.That(p.FirstName, Is.EqualTo("Антон"));
            Assert.That(p.LastName, Is.EqualTo("Жидков"));
        }

        [Test]
        public void GetProfile_AllFields_FullProfile()
        {
            const string url = "https://api.vk.com/method/getProfiles?uid=4793858&fields=uid,first_name,last_name,sex,bdate,city,country,photo_50,photo_100,photo_200,photo_200_orig,photo_400_orig,photo_max,photo_max_orig,online,lists,domain,has_mobile,contacts,connections,site,education,universities,schools,can_post,can_see_all_posts,can_see_audio,can_write_private_message,status,last_seen,common_count,relation,relatives,counters,nickname,timezone&access_token=token";

           const string json =
                @"{
                    'response': [
                      {
                        'uid': 4793858,
                        'first_name': 'Антон',
                        'last_name': 'Жидков',
                        'nickname': '[Удален]',
                        'domain': 'azhidkov',
                        'sex': 2,
                        'bdate': '30.9',
                        'city': '10',
                        'country': '1',
                        'timezone': 3,
                        'photo_50': 'http://cs9215.userapi.com/u4793858/e_1b975695.jpg',
                        'photo_100': 'http://cs9215.userapi.com/u4793858/b_8ba11bd6.jpg',
                        'photo_200': 'http://cs9215.userapi.com/u4793858/a_33cbff34.jpg',
                        'photo_max': 'http://cs9215.userapi.com/u4793858/a_33cbff34.jpg',
                        'has_mobile': 1,
                        'mobile_phone': '+79191234567',
                        'home_phone': '87-98-12',
                        'skype': 'df',
                        'facebook': '100006407887907',
                        'facebook_name': 'Yvavay  Fyvayva',
                        'twitter': 'ivanovivan1221',
                        'instagram': 'ivanovivan1221',
                        'university': '431',
                        'university_name': 'ВолгГТУ',
                        'faculty': '3162',
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': '2013',
                        'education_form': 'Вечернее отделение',
                        'education_status': 'Выпускник (специалист)',
                        'site': 'http://wzor.net',
                        'status': 'Всегда',
                        'last_seen': {
                          'time': 1382851837
                        },
                        'relation': '2',
                        'relation_partner': {
                          'id': 2338123,
                          'first_name': 'Пенелопа',
                          'last_name': 'Круз'
                        },
                        'personal': {
                          'political': 9,
                          'langs': [
                            'Русский',
                            'Polski'
                          ],
                          'religion': 'Иудаизм',
                          'inspired_by': 'книга \'Как ограбить Бразилию\'',
                          'people_main': 6,
                          'life_main': 8,
                          'smoking': 4,
                          'alcohol': 3
                        },
                        'online': 1,
                        'online_mobile': 1,
                        'online_app': 11,
                        'can_post': 1,
                        'can_see_all_posts': 1,
                        'can_see_audio': 1,
                        'can_write_private_message': 1,
                        'language' : 0,
                        'interests': 'разработка приложений',
                        'music': 'Пикник, Король и Шут',
                        'activities': 'двачую капчу',
                        'movies': 'Реквием по Мечте',
                        'tv': 'Время',
                        'books': 'Пауло Коельо',
                        'games': 'S.T.A.L.K.E.R',
                        'schools': [
                          {
                            'id': 52978,
                            'country': 1,
                            'city': 1,
                            'name': '№ 1',
                            'year_from': 2011,
                            'year_to': 2018,
                            'year_graduated': 2018,
                            'class': 'в',
                            'speciality': 'физ-мат',
                            'type': 2,
                            'type_str': 'Лицей'
                          }
                        ],
                        'universities': [
                          {
                            'id': 2,
                            'country': 1,
                            'city': 1,
                            'name': 'МГУ',
                            'faculty': 23,
                            'faculty_name': 'Вычислительной математики и кибернетики',
                            'chair': 307,
                            'chair_name': 'Математической физики\r\n',
                            'graduation': 2009,
                            'education_form': 'Дневное отделение',
                            'education_status': 'Студент (специалист)'
                          }
                        ],
                        'about': 'отличный мужик',
                        'relatives': [
                          {
                            'id': 1,
                            'type': 'sibling'
                          },
                        ],
                        'quotes': 'Хорошо, что нам не дано знать будущее. Иначе мы вовсе не поднимались бы из постели.',                        
                        'counters': {
                          'albums': 1,
                          'videos': 100,
                          'audios': 153,
                          'notes': 3,
                          'photos': 54,
                          'groups': 40,
                          'friends': 371,
                          'online_friends': 44,
                          'mutual_friends': 2,
                          'user_photos': 164,
                          'user_videos': 87,
                          'followers': 1,
                          'subscriptions': 1,
                          'pages': 1
                        }
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);

            // act
            User p = users.Get(4793858, ProfileFields.All);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Id, Is.EqualTo(4793858));
            Assert.That(p.FirstName, Is.EqualTo("Антон"));
            Assert.That(p.LastName, Is.EqualTo("Жидков"));
            Assert.That(p.Nickname, Is.EqualTo("[Удален]"));
            Assert.That(p.Domain, Is.EqualTo("azhidkov"));
            Assert.That(p.Sex, Is.EqualTo(Sex.Male));
            Assert.That(p.BirthDate, Is.EqualTo("30.9"));
            Assert.That(p.City, Is.EqualTo(10));
            Assert.That(p.Country, Is.EqualTo(1));
            Assert.That(p.Timezone, Is.EqualTo(3));
            Assert.That(p.PhotoPreviews.Photo50, Is.EqualTo("http://cs9215.userapi.com/u4793858/e_1b975695.jpg"));
            Assert.That(p.PhotoPreviews.Photo100, Is.EqualTo("http://cs9215.userapi.com/u4793858/b_8ba11bd6.jpg"));
            Assert.That(p.PhotoPreviews.Photo200, Is.EqualTo("http://cs9215.userapi.com/u4793858/a_33cbff34.jpg"));
            Assert.IsNull(p.PhotoPreviews.Photo400);
            Assert.That(p.PhotoPreviews.PhotoMax, Is.EqualTo("http://cs9215.userapi.com/u4793858/a_33cbff34.jpg"));
            Assert.That(p.HasMobile, Is.EqualTo(true));
            Assert.That(p.MobilePhone, Is.EqualTo("+79191234567"));
            Assert.That(p.HomePhone, Is.EqualTo("87-98-12"));
            Assert.That(p.Connections.Skype, Is.EqualTo("df"));
            Assert.That(p.Connections.FacebookId, Is.EqualTo(100006407887907));
            Assert.That(p.Connections.FacebookName, Is.EqualTo("Yvavay  Fyvayva"));
            Assert.That(p.Connections.Twitter, Is.EqualTo("ivanovivan1221"));
            Assert.That(p.Connections.Instagram, Is.EqualTo("ivanovivan1221"));
            Assert.That(p.StandInLife.Political, Is.EqualTo(PoliticalPreferences.Libertarian));
            Assert.That(p.StandInLife.Languages, Is.EquivalentTo(new[] { "Русский", "Polski" }));
            Assert.That(p.StandInLife.Religion, Is.EqualTo("Иудаизм"));
            Assert.That(p.StandInLife.InspiredBy, Is.EqualTo("книга 'Как ограбить Бразилию'"));
            Assert.That(p.StandInLife.PeopleMain, Is.EqualTo(PeopleMain.HumorAndLoveForLife));
            Assert.That(p.StandInLife.LifeMain, Is.EqualTo(LifeMain.FameAndInfluence));
            Assert.That(p.StandInLife.Smoking, Is.EqualTo(Attitude.Neutral));
            Assert.That(p.StandInLife.Alcohol, Is.EqualTo(Attitude.Compromise));
            Assert.That(p.Online, Is.EqualTo(true));
            Assert.That(p.OnlineMobile, Is.EqualTo(true));
            Assert.That(p.OnlineApp, Is.EqualTo(11));
            Assert.That(p.Education, Is.Not.Null);
            Assert.That(p.Education.UniversityId, Is.EqualTo(431));
            Assert.That(p.Education.UniversityName, Is.EqualTo("ВолгГТУ"));
            Assert.That(p.Education.FacultyId, Is.EqualTo(3162));
            Assert.That(p.Education.FacultyName, Is.EqualTo("Электроники и вычислительной техники"));
            Assert.That(p.Education.Graduation, Is.EqualTo(2013));
            Assert.That(p.Education.EducationForm, Is.EqualTo("Вечернее отделение"));
            Assert.That(p.Education.EducationStatus, Is.EqualTo("Выпускник (специалист)"));
            Assert.That(p.Site, Is.EqualTo("http://wzor.net"));
            Assert.That(p.Status, Is.EqualTo("Всегда"));
            Assert.That(p.LastSeen, Is.EqualTo(new DateTime(2013, 10, 27, 09, 30, 37)));
            Assert.That(p.Relation, Is.EqualTo(RelationType.HasFriend));
            Assert.That(p.RelationPartner.Id, Is.EqualTo(2338123));
            Assert.That(p.RelationPartner.FirstName, Is.EqualTo("Пенелопа"));
            Assert.That(p.RelationPartner.LastName, Is.EqualTo("Круз"));
            Assert.That(p.Counters, Is.Not.Null);
            Assert.That(p.Counters.Albums, Is.EqualTo(1));
            Assert.That(p.Counters.Videos, Is.EqualTo(100));
            Assert.That(p.Counters.Audios, Is.EqualTo(153));
            Assert.That(p.Counters.Notes, Is.EqualTo(3));
            Assert.That(p.Counters.Photos, Is.EqualTo(54));
            Assert.That(p.Counters.Groups, Is.EqualTo(40));
            Assert.That(p.Counters.Friends, Is.EqualTo(371));
            Assert.That(p.Counters.OnlineFriends, Is.EqualTo(44));
            Assert.That(p.Counters.MutualFriends, Is.EqualTo(2));
            Assert.That(p.Counters.UserPhotos, Is.EqualTo(164));
            Assert.That(p.Counters.UserVideos, Is.EqualTo(87));
            Assert.That(p.Counters.Followers, Is.EqualTo(1));
            Assert.That(p.Counters.Subscriptions, Is.EqualTo(1));
            Assert.That(p.Counters.Pages, Is.EqualTo(1));
            Assert.IsTrue(p.CanPost);
            Assert.IsTrue(p.CanSeeAllPosts);
            Assert.IsTrue(p.CanSeeAudio);
            Assert.IsTrue(p.CanWritePrivateMessage);
            Assert.That(p.Language, Is.EqualTo(0));
            Assert.That(p.Interests, Is.EqualTo("разработка приложений"));
            Assert.That(p.Music, Is.EqualTo("Пикник, Король и Шут"));
            Assert.That(p.Activities, Is.EqualTo("двачую капчу"));
            Assert.That(p.Movies, Is.EqualTo("Реквием по Мечте"));
            Assert.That(p.Tv, Is.EqualTo("Время"));
            Assert.That(p.Books, Is.EqualTo("Пауло Коельо"));
            Assert.That(p.Games, Is.EqualTo("S.T.A.L.K.E.R"));
            
            Assert.That(p.Schools.Count, Is.EqualTo(1));            
            School school = p.Schools[0];
            Assert.That(school.Id, Is.EqualTo(52978));
            Assert.That(school.Country, Is.EqualTo(1));
            Assert.That(school.City, Is.EqualTo(1));
            Assert.That(school.Name, Is.EqualTo("№ 1"));
            Assert.That(school.YearFrom, Is.EqualTo(2011));
            Assert.That(school.YearTo, Is.EqualTo(2018));
            Assert.That(school.YearGraduated, Is.EqualTo(2018));
            Assert.That(school.Class, Is.EqualTo("в"));
            Assert.That(school.Speciality, Is.EqualTo("физ-мат"));
            Assert.That(school.Type, Is.EqualTo(2));
            Assert.That(school.TypeStr, Is.EqualTo("Лицей"));

            Assert.That(p.Universities.Count, Is.EqualTo(1));
            University university = p.Universities[0];
            Assert.That(university.Id, Is.EqualTo(2));
            Assert.That(university.Country, Is.EqualTo(1));
            Assert.That(university.City, Is.EqualTo(1));
            Assert.That(university.Name, Is.EqualTo("МГУ"));
            Assert.That(university.Faculty, Is.EqualTo(23));
            Assert.That(university.FacultyName, Is.EqualTo("Вычислительной математики и кибернетики"));
            Assert.That(university.Chair, Is.EqualTo(307));
            Assert.That(university.Graduation, Is.EqualTo(2009));
            Assert.That(university.EducationForm, Is.EqualTo("Дневное отделение"));
            Assert.That(university.EducationStatus, Is.EqualTo("Студент (специалист)"));

            Assert.That(p.About, Is.EqualTo("отличный мужик"));

            Assert.That(p.Relatives.Count, Is.EqualTo(1));
            Relative relative = p.Relatives[0];
            Assert.That(relative.Id, Is.EqualTo(1));
            Assert.That(relative.Type, Is.EqualTo("sibling"));

            Assert.That(p.Quotes, Is.EqualTo("Хорошо, что нам не дано знать будущее. Иначе мы вовсе не поднимались бы из постели."));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetGropus_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            users.GetGroups(1);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Access to the groups list is denied due to the user privacy settings.")]
        public void GetGroups_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/getGroups?uid=1&access_token=token";

            const string json =
                @"{
                    'error': {
                      'error_code': 260,
                      'error_msg': 'Access to the groups list is denied due to the user privacy settings.',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'getGroups'
                        },
                        {
                          'key': 'uid',
                          'value': '1'
                        },
                        {
                          'key': 'access_token',
                          'value': '2f3e43eb608a87632f68d140d82f5a9efa22f772f7765eb2f49f67514987c5e'
                        }
                      ]
                    }
                  }";

            var users = GetMockedUsersCategory(url, json);
            users.GetGroups(1);
        }

        [Test]
        public void GetGroups_UserHaveNoGroups_EmptyList()
        {
            // undone: check it later
            const string url = "https://api.vk.com/method/getGroups?uid=4793858&access_token=token";

            const string json =
                @"{
                    'response': []
                  }";

            var users = GetMockedUsersCategory(url, json);
            var groups = users.GetGroups(4793858).ToList();

            Assert.That(groups.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetGroups_AccessGranted_ListOfGroups()
        {
            const string url = "https://api.vk.com/method/getGroups?uid=4793858&access_token=token";

            const string json =
                @"{
                    'response': [
                      1,
                      15,
                      134,
                      1673
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            var groups = users.GetGroups(4793858).ToList();

            Assert.That(groups.Count, Is.EqualTo(4));
            Assert.That(groups[0].Id, Is.EqualTo(1));
            Assert.That(groups[1].Id, Is.EqualTo(15));
            Assert.That(groups[2].Id, Is.EqualTo(134));
            Assert.That(groups[3].Id, Is.EqualTo(1673));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_Multiple_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            users.Get(new long[] {1, 2});
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_EmptyListOfUids_ThrowArgumentNullException()
        {
            var users = new UsersCategory(new VkApi { AccessToken = "token" });
            users.Get(null);
        }

        [Test]
        public void Get_Mutliple_TwoUidsDefaultFields_TwoProfiles()
        {
            const string url = "https://api.vk.com/method/getProfiles?uids=1,4793858&access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'uid': 1,
                        'first_name': 'Pavel',
                        'last_name': 'Durov'
                      },
                      {
                        'uid': 4793858,
                        'first_name': 'Anton',
                        'last_name': 'Zhidkov'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            var lst = users.Get(new long[] {1, 4793858}).ToList();

            Assert.That(lst.Count, Is.EqualTo(2));
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(1));
            Assert.That(lst[0].FirstName, Is.EqualTo("Pavel"));
            Assert.That(lst[0].LastName, Is.EqualTo("Durov"));

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(4793858));
            Assert.That(lst[1].FirstName, Is.EqualTo("Anton"));
            Assert.That(lst[1].LastName, Is.EqualTo("Zhidkov"));
        }

        [Test]
        public void Get_TwoUidsEducationField_TwoProfiles()
        {
            const string url =
                "https://api.vk.com/method/getProfiles?uids=102674754,5041431&fields=education&access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'uid': 102674754,
                        'first_name': 'Artyom',
                        'last_name': 'Plotnikov',
                        'university': '431',
                        'university_name': 'ВолгГТУ',
                        'faculty': '3162',
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': '2010'
                      },
                      {
                        'uid': 5041431,
                        'first_name': 'Tayfur',
                        'last_name': 'Kaseev',
                        'university': '431',
                        'university_name': 'ВолгГТУ',
                        'faculty': '3162',
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': '2012'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            ReadOnlyCollection<User> lst = users.Get(new long[] {102674754, 5041431}, ProfileFields.Education);

            Assert.That(lst.Count == 2);
            Assert.That(lst[0], Is.Not.Null);
            Assert.That(lst[0].Id, Is.EqualTo(102674754));
            Assert.That(lst[0].FirstName, Is.EqualTo("Artyom"));
            Assert.That(lst[0].LastName, Is.EqualTo("Plotnikov"));
            Assert.That(lst[0].Education, Is.Not.Null);
            Assert.That(lst[0].Education.UniversityId, Is.EqualTo(431));
            Assert.That(lst[0].Education.UniversityName, Is.EqualTo("ВолгГТУ"));
            Assert.That(lst[0].Education.FacultyId, Is.EqualTo(3162));
            Assert.That(lst[0].Education.FacultyName, Is.EqualTo("Электроники и вычислительной техники"));
            Assert.That(lst[0].Education.Graduation, Is.EqualTo(2010));

            Assert.That(lst[1], Is.Not.Null);
            Assert.That(lst[1].Id, Is.EqualTo(5041431));
            Assert.That(lst[1].FirstName, Is.EqualTo("Tayfur"));
            Assert.That(lst[1].LastName, Is.EqualTo("Kaseev"));
            Assert.That(lst[1].Education, Is.Not.Null);
            Assert.That(lst[1].Education.UniversityId, Is.EqualTo(431));
            Assert.That(lst[1].Education.UniversityName, Is.EqualTo("ВолгГТУ"));
            Assert.That(lst[1].Education.FacultyId, Is.EqualTo(3162));
            Assert.That(lst[1].Education.FacultyName, Is.EqualTo("Электроники и вычислительной техники"));
            Assert.That(lst[1].Education.Graduation, Is.EqualTo(2012));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetGroupsFull_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            vk.Users.GetGroupsFull();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetGroupsFull_Multiple_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            vk.Users.GetGroupsFull(new long[]{1, 2});
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetGroupsFull_NullGids_ThrowArgumentNullException()
        {
            var vk = new VkApi { AccessToken = "token" };
            vk.Users.GetGroupsFull(null);
        }

        [Test]
        public void GetGroupsFull_Mulitple_TwoGroups()
        {
            const string url = "https://api.vk.com/method/getGroupsFull?gids=29689780,33489538&access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'id': 29689780,
                        'name': 'Art and Life ©',
                        'screen_name': 'art.and.life',
                        'is_closed': 0,
                        'type': 'page',
                        'photo': 'http://cs11003.userapi.com/g29689780/e_1bea6489.jpg',
                        'photo_medium': 'http://cs11003.userapi.com/g29689780/d_f50bf769.jpg',
                        'photo_big': 'http://cs11003.userapi.com/g29689780/a_1889c16e.jpg'
                      },
                      {
                        'id': 33489538,
                        'name': 'Английский как стиль жизни. Где перевод?',
                        'screen_name': 'english_for_adults',
                        'is_closed': 0,
                        'type': 'event',
                        'photo': 'http://cs5538.userapi.com/g33489538/e_1d36792d.jpg',
                        'photo_medium': 'http://cs5538.userapi.com/g33489538/d_caafe13e.jpg',
                        'photo_big': 'http://cs5538.userapi.com/g33489538/a_6d6f2525.jpg'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            var groups = users.GetGroupsFull(new long[] { 29689780, 33489538 }).ToList();

            Assert.That(groups.Count, Is.EqualTo(2));
            Assert.That(groups[0], Is.Not.Null);
            Assert.That(groups[0].Id, Is.EqualTo(29689780));
            Assert.That(groups[0].Name, Is.EqualTo("Art and Life ©"));
            Assert.That(groups[0].ScreenName, Is.EqualTo("art.and.life"));
            Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
            Assert.That(groups[0].IsAdmin, Is.False);
            Assert.That(groups[0].Type, Is.EqualTo(GroupType.Page));

            Assert.That(groups[1], Is.Not.Null);
            Assert.That(groups[1].Id, Is.EqualTo(33489538));
            Assert.That(groups[1].Name, Is.EqualTo("Английский как стиль жизни. Где перевод?"));
            Assert.That(groups[1].ScreenName, Is.EqualTo("english_for_adults"));
            Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
            Assert.That(groups[1].IsAdmin, Is.False);
            Assert.That(groups[1].Type, Is.EqualTo(GroupType.Event));
        }

        [Test]
        public void GetGroupsFull_GroupsOfCurrentUser()
        {
            const string url = "https://api.vk.com/method/getGroupsFull?access_token=token";

            const string json =
                @"{
                    'response': [
                      {
                        'id': 29689780,
                        'name': 'Art and Life ©',
                        'screen_name': 'art.and.life',
                        'is_closed': 0,
                        'is_admin': 1,
                        'type': 'page',
                        'photo': 'http://cs11003.userapi.com/g29689780/e_1bea6489.jpg',
                        'photo_medium': 'http://cs11003.userapi.com/g29689780/d_f50bf769.jpg',
                        'photo_big': 'http://cs11003.userapi.com/g29689780/a_1889c16e.jpg'
                      },
                      {
                        'id': 33489538,
                        'name': 'Английский как стиль жизни. Где перевод?',
                        'screen_name': 'english_for_adults',
                        'is_closed': 0,
                        'type': 'event',
                        'photo': 'http://cs5538.userapi.com/g33489538/e_1d36792d.jpg',
                        'photo_medium': 'http://cs5538.userapi.com/g33489538/d_caafe13e.jpg',
                        'photo_big': 'http://cs5538.userapi.com/g33489538/a_6d6f2525.jpg'
                      }
                    ]
                  }";

            var users = GetMockedUsersCategory(url, json);
            var groups = users.GetGroupsFull().ToList();

            Assert.That(groups.Count, Is.EqualTo(2));
            Assert.That(groups[0], Is.Not.Null);
            Assert.That(groups[0].Id, Is.EqualTo(29689780));
            Assert.That(groups[0].Name, Is.EqualTo("Art and Life ©"));
            Assert.That(groups[0].ScreenName, Is.EqualTo("art.and.life"));
            Assert.That(groups[0].IsClosed, Is.EqualTo(GroupPublicity.Public));
            Assert.That(groups[0].IsAdmin, Is.True);
            Assert.That(groups[0].Type, Is.EqualTo(GroupType.Page));

            Assert.That(groups[1], Is.Not.Null);
            Assert.That(groups[1].Id, Is.EqualTo(33489538));
            Assert.That(groups[1].Name, Is.EqualTo("Английский как стиль жизни. Где перевод?"));
            Assert.That(groups[1].ScreenName, Is.EqualTo("english_for_adults"));
            Assert.That(groups[1].IsClosed, Is.EqualTo(GroupPublicity.Public));
            Assert.That(groups[1].IsAdmin, Is.False);
            Assert.That(groups[1].Type, Is.EqualTo(GroupType.Event));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void IsAppUser_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var users = new UsersCategory(new VkApi());
            users.IsAppUser(1);
        }

        [Test]
        public void IsAppUser_AppIsInstalled_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/isAppUser?uid=1234&access_token=token";

            const string json =
                @"{
                    'response': '1'
                  }";

            var users = GetMockedUsersCategory(url, json);
            bool result = users.IsAppUser(1234);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAppUser_AppNotInstalled_ReturnFalse()
        {
            const string url = "https://api.vk.com/method/isAppUser?uid=1234&access_token=token";

            const string json =
                @"{
                    'response': '0'
                  }";

            var users = GetMockedUsersCategory(url, json);
            bool result = users.IsAppUser(1234);

            Assert.That(result, Is.False);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetUserSettings_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            vk.Users.GetUserSettings(100);
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
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Search_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var vk = new VkApi();
            int count;
            vk.Users.Search(Query, out count);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Query can not be null or empty.")]
        public void Search_EmptyQuery_ThrowArgumentException()
        {
            int count;
            var vk = new VkApi { AccessToken = "token" };
            vk.Users.Search("", out count);
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
    }
}