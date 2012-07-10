using Moq;
using NUnit.Framework;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests
{
    [TestFixture]
    public class UsersTest
    {
        private Users users;

        [SetUp]
        public void SetUp()
        {
            users = new Users(new VkApi());       
        }

        [Test]
        [ExpectedException(typeof(AccessTokenNotSetException))]
        public void GetProfiles_EmptyAccessToken_ThrowAccessTokenNotSetException()
        {
            users.GetProfiles(1);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "The remote name could not be resolved: 'api.vk.com'")]
        public void GetProfiles_NotAccessToInternet_ThrowVkApiException()
        {
            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetRawHtml(It.IsAny<string>())).Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));

            users = new Users(new VkApi(mockBrowser.Object){AccessToken = "asgsstsfast"});

            users.GetProfiles(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
        public void GetProfiles_WrongAccesToken_Throw_ThrowUserAuthorizationException()
        {
            const string json =
                "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: invalid access_token.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"getProfiles\"},{\"key\":\"uid\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"sfastybdsjhdg\"}]}}";

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetRawHtml(It.IsAny<string>())).Returns(json);

            users = new Users(new VkApi(mockBrowser.Object){AccessToken = "sfastybdsjhdg"});
            users.GetProfiles(1);
        }

        [Test]
        public void GetProfiles_WithSomeFields_FirstNameLastNameEducation()
        {
            const string json =
                "{\"response\":[{\"uid\":1,\"first_name\":\"Павел\",\"last_name\":\"Дуров\",\"university\":\"1\",\"university_name\":\"СПбГУ\",\"faculty\":\"0\",\"faculty_name\":\"\",\"graduation\":\"0\"}]}";

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(m => m.GetRawHtml(It.IsAny<string>())).Returns(json);

            users = new Users(new VkApi(mockBrowser.Object) {AccessToken = "token"});

            // act
            var fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Education;
            Profile p = users.GetProfiles(1, fields);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Uid, Is.EqualTo(1));
            Assert.That(p.FirstName, Is.EqualTo("Павел"));
            Assert.That(p.LastName, Is.EqualTo("Дуров"));
            Assert.That(p.Education, Is.Not.Null);
            Assert.That(p.Education.UniversityId, Is.EqualTo("1"));
            Assert.That(p.Education.UniversityName, Is.EqualTo("СПбГУ"));
            Assert.That(p.Education.FacultyId, Is.EqualTo("0"));
            Assert.That(p.Education.FacultyName, Is.EqualTo(""));
            Assert.That(p.Education.Graduation, Is.EqualTo("0"));
        }

        [Test]
        public void GetProfile_CountersFields_CountersObject()
        {
            const string json =
                "{\"response\":[{\"uid\":4793858,\"first_name\":\"Антон\",\"last_name\":\"Жидков\",\"counters\":{\"albums\":1,\"videos\":100,\"audios\":153,\"notes\":3,\"photos\":54,\"groups\":40,\"friends\":371,\"online_friends\":44,\"user_photos\":164,\"user_videos\":87,\"followers\":1,\"subscriptions\":1}}]}";

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(m => m.GetRawHtml(It.IsAny<string>())).Returns(json);

            users = new Users(new VkApi(mockBrowser.Object) { AccessToken = "token" });

            // act
            Profile p = users.GetProfiles(4793858, ProfileFields.Counters);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Uid, Is.EqualTo(4793858));
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
            Assert.That(p.Counters.UserPhotos, Is.EqualTo(164));
            Assert.That(p.Counters.UserVideos, Is.EqualTo(87));
            Assert.That(p.Counters.Followers, Is.EqualTo(1));
            Assert.That(p.Counters.Subscriptions, Is.EqualTo(1));
        }

        [Test]
        public void GetProfile_DefaultFields_UidFirstNameLastName()
        {
            const string json = "{\"response\":[{\"uid\":4793858,\"first_name\":\"Антон\",\"last_name\":\"Жидков\"}]}";

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(m => m.GetRawHtml(It.IsAny<string>())).Returns(json);
            users = new Users(new VkApi(mockBrowser.Object) {AccessToken = "token"});

            // act
            Profile p = users.GetProfiles(4793858);

            // assert
            Assert.That(p.Uid, Is.EqualTo(4793858));
            Assert.That(p.FirstName, Is.EqualTo("Антон"));
            Assert.That(p.LastName, Is.EqualTo("Жидков"));
        }

        [Test]
        public void GetProfile_AllFields_FullProfile()
        {
            const string json =
                "{\"response\":[{\"uid\":4793858,\"first_name\":\"Антон\",\"last_name\":\"Жидков\",\"nickname\":\"[Удален]\",\"screen_name\":\"azhidkov\",\"sex\":2,\"bdate\":\"30.9\",\"city\":\"10\",\"country\":\"1\",\"timezone\":3,\"photo\":\"http:\\/\\/cs9215.userapi.com\\/u4793858\\/e_1b975695.jpg\",\"photo_medium\":\"http:\\/\\/cs9215.userapi.com\\/u4793858\\/b_8ba11bd6.jpg\",\"photo_big\":\"http:\\/\\/cs9215.userapi.com\\/u4793858\\/a_33cbff34.jpg\",\"has_mobile\":1,\"rate\":\"85\",\"mobile_phone\":\"+79191234567\",\"home_phone\":\"87-98-12\",\"university\":\"431\",\"university_name\":\"ВолгГТУ\",\"faculty\":\"3162\",\"faculty_name\":\"Электроники и вычислительной техники\",\"graduation\":\"2013\",\"online\":1,\"counters\":{\"albums\":1,\"videos\":100,\"audios\":153,\"notes\":3,\"photos\":54,\"groups\":40,\"friends\":371,\"online_friends\":54,\"user_photos\":164,\"user_videos\":87,\"followers\":1,\"subscriptions\":1}}]}";
                

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(m => m.GetRawHtml(It.IsAny<string>())).Returns(json);

            users = new Users(new VkApi(mockBrowser.Object) { AccessToken = "token" });

            // act
            Profile p = users.GetProfiles(4793858, ProfileFields.All);

            // assert
            Assert.That(p, Is.Not.Null);
            Assert.That(p.Uid, Is.EqualTo(4793858));
            Assert.That(p.FirstName, Is.EqualTo("Антон"));
            Assert.That(p.LastName, Is.EqualTo("Жидков"));

            Assert.That(p.Nickname, Is.EqualTo("[Удален]"));
            Assert.That(p.ScreenName, Is.EqualTo("azhidkov"));
            Assert.That(p.Sex, Is.EqualTo(2));
            Assert.That(p.BirthDate, Is.EqualTo("30.9"));
            Assert.That(p.City, Is.EqualTo("10"));
            Assert.That(p.Country, Is.EqualTo("1"));
            Assert.That(p.Timezone, Is.EqualTo(3));
            Assert.That(p.Photo, Is.EqualTo("http://cs9215.userapi.com/u4793858/e_1b975695.jpg"));
            Assert.That(p.PhotoMedium, Is.EqualTo("http://cs9215.userapi.com/u4793858/b_8ba11bd6.jpg"));
            Assert.That(p.PhotoBig, Is.EqualTo("http://cs9215.userapi.com/u4793858/a_33cbff34.jpg"));
            Assert.That(p.HasMobile, Is.EqualTo(1));
            Assert.That(p.Rate, Is.EqualTo("85"));
            Assert.That(p.MobilePhone, Is.EqualTo("+79191234567"));
            Assert.That(p.HomePhone, Is.EqualTo("87-98-12"));
            Assert.That(p.Online, Is.EqualTo(1));
            Assert.That(p.Education, Is.Not.Null);
            Assert.That(p.Education.UniversityId, Is.EqualTo("431"));
            Assert.That(p.Education.UniversityName, Is.EqualTo("ВолгГТУ"));
            Assert.That(p.Education.FacultyId, Is.EqualTo("3162"));
            Assert.That(p.Education.FacultyName, Is.EqualTo("Электроники и вычислительной техники"));
            Assert.That(p.Education.Graduation, Is.EqualTo("2013"));

            Assert.That(p.Counters, Is.Not.Null);
            Assert.That(p.Counters.Albums, Is.EqualTo(1));
            Assert.That(p.Counters.Videos, Is.EqualTo(100));
            Assert.That(p.Counters.Audios, Is.EqualTo(153));
            Assert.That(p.Counters.Notes, Is.EqualTo(3));
            Assert.That(p.Counters.Photos, Is.EqualTo(54));
            Assert.That(p.Counters.Groups, Is.EqualTo(40));
            Assert.That(p.Counters.Friends, Is.EqualTo(371));
            Assert.That(p.Counters.OnlineFriends, Is.EqualTo(54));
            Assert.That(p.Counters.UserPhotos, Is.EqualTo(164));
            Assert.That(p.Counters.UserVideos, Is.EqualTo(87));
            Assert.That(p.Counters.Followers, Is.EqualTo(1));
            Assert.That(p.Counters.Subscriptions, Is.EqualTo(1));
        }
    }
}