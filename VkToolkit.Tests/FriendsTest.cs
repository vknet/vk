using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Tests
{
    [TestFixture]
    public class FriendsTest
    {
        [SetUp]
        public void SetUp()
        {
             
        }

        [Test]
        [ExpectedException(typeof(AccessTokenNotSetException))]
        public void Get_EmptyAccessToken_ThrowAccessTokenNotSetException()
        {
            var f = new Friends(new VkApi());
            f.Get(1);
        }

        [Test]
        public void Get_FriendsForDurov_ListOfFriends()
        {
            const string url =
                "https://api.vk.com/method/friends.get?uid=1&access_token=token";
            const string json =
                "{\"response\":[2,5,6,7,12]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends((new VkApi(browser.Object) { AccessToken = "token" }));

            var users = friends.Get(1).ToList();

            Assert.That(users.Count, Is.EqualTo(5));
            Assert.That(users[0].Uid, Is.EqualTo(2));
            Assert.That(users[1].Uid, Is.EqualTo(5));
            Assert.That(users[2].Uid, Is.EqualTo(6));
            Assert.That(users[3].Uid, Is.EqualTo(7));
            Assert.That(users[4].Uid, Is.EqualTo(12));

        }

        [Test]
        public void Get_FirstNameLastName_ListOfObjects()
        {
            const string url =
                "https://api.vk.com/method/friends.get?uid=1&fields=first_name,last_name&count=3&access_token=token";
            const string json =
                "{\"response\":[{\"uid\":2,\"first_name\":\"Александра\",\"last_name\":\"Владимирова\",\"online\":0},{\"uid\":5,\"first_name\":\"Илья\",\"last_name\":\"Перекопский\",\"online\":0},{\"uid\":6,\"first_name\":\"Николай\",\"last_name\":\"Дуров\",\"online\":0}]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) {AccessToken = "token"});

            var lst = friends.Get(1, ProfileFields.FirstName | ProfileFields.LastName, 3).ToList();

            Assert.That(lst.Count, Is.EqualTo(3));
            Assert.That(lst[0].Uid, Is.EqualTo(2));
            Assert.That(lst[0].FirstName, Is.EqualTo("Александра"));
            Assert.That(lst[0].LastName, Is.EqualTo("Владимирова"));
            Assert.That(lst[0].Online, Is.EqualTo(0));

            Assert.That(lst[1].Uid, Is.EqualTo(5));
            Assert.That(lst[1].FirstName, Is.EqualTo("Илья"));
            Assert.That(lst[1].LastName, Is.EqualTo("Перекопский"));
            Assert.That(lst[1].Online, Is.EqualTo(0));

            Assert.That(lst[2].Uid, Is.EqualTo(6));
            Assert.That(lst[2].FirstName, Is.EqualTo("Николай"));
            Assert.That(lst[2].LastName, Is.EqualTo("Дуров"));
            Assert.That(lst[2].Online, Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenNotSetException))]
        public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenNotSetException()
        {
            var f = new Friends(new VkApi());
            f.GetAppUsers();
        }

        [Test]
        public void GetAppUsers_NoOne_EmptyList()
        {
            const string url = "https://api.vk.com/method/friends.getAppUsers?access_token=token";
            const string json = "{\"response\":[]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) {AccessToken = "token"});

            var users = friends.GetAppUsers().ToList();

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetAppUsers_TwoUsers_ListOfObjects()
        {
            const string url = "https://api.vk.com/method/friends.getAppUsers?access_token=token";
            const string json = "{\"response\":[15221,17836,19194]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var users = friends.GetAppUsers().ToList();

            Assert.That(users.Count, Is.EqualTo(3));
            Assert.That(users[0], Is.EqualTo(15221));
            Assert.That(users[1], Is.EqualTo(17836));
            Assert.That(users[2], Is.EqualTo(19194));
        }
    }
}