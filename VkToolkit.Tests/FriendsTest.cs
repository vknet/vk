using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Enums;
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
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_EmptyAccessToken_ThrowAccessTokenInvalidException()
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
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetAppUsers_EmptyAccessToken_ThrowAccessTokenInvalidException()
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
        public void GetAppUsers_ThreeUsers_ListOfObjects()
        {
            const string url = "https://api.vk.com/method/friends.getAppUsers?access_token=token";
            const string json = "{\"response\":[15221,17836,19194]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var ids = friends.GetAppUsers().ToList();

            Assert.That(ids.Count, Is.EqualTo(3));
            Assert.That(ids[0], Is.EqualTo(15221));
            Assert.That(ids[1], Is.EqualTo(17836));
            Assert.That(ids[2], Is.EqualTo(19194));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetOnline_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var f = new Friends(new VkApi());
            f.GetOnline(1);
        }

        [Test]
        public void GetOnline_NoOne_EmptyList()
        {
            const string url = "https://api.vk.com/method/friends.getOnline?uid=1&access_token=token";
            const string json = "{\"response\":[]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var users = friends.GetOnline(1).ToList();

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetOnline_FiveUsers_ListOfObjects()
        {
            const string url = "https://api.vk.com/method/friends.getOnline?uid=1&access_token=token";
            const string json = "{\"response\":[5,467,2943,4424,13033]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var ids = friends.GetOnline(1).ToList();

            Assert.That(ids.Count, Is.EqualTo(5));
            Assert.That(ids[0], Is.EqualTo(5));
            Assert.That(ids[1], Is.EqualTo(467));
            Assert.That(ids[2], Is.EqualTo(2943));
            Assert.That(ids[3], Is.EqualTo(4424));
            Assert.That(ids[4], Is.EqualTo(13033));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetMutual_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var f = new Friends(new VkApi());
            f.GetMutual(2, 3);
        }

        [Test]
        public void GetMutual_ThreeUsers_ListOfObjects()
        {
            const string url = "https://api.vk.com/method/friends.getMutual?target_uid=2&source_uid=1&access_token=token";
            const string json = "{\"response\":[3,31,43]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });
            
            var ids = friends.GetMutual(2, 1).ToList();

            Assert.That(ids.Count, Is.EqualTo(3));
            Assert.That(ids[0], Is.EqualTo(3));
            Assert.That(ids[1], Is.EqualTo(31));
            Assert.That(ids[2], Is.EqualTo(43));
        }

        [Test]
        public void GetMutual_NoOne_EmptyList()
        {
            const string url = "https://api.vk.com/method/friends.getMutual?target_uid=2&source_uid=1&access_token=token";
            const string json = "{\"response\":[]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var users = friends.GetMutual(2, 1).ToList();

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void AreFriends_EmptyAccessToken_ThrowAccessTokenInvalidException()
        {
            var f = new Friends(new VkApi());
            f.AreFriends(new long[]{2, 3});
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AreFriends_NullInput_ThrowArgumentNullException()
        {
            var f = new Friends(new VkApi(){AccessToken = "token"});
            f.AreFriends(null);
        }

        [Test]
        public void AreFriends_FourTypes_RightFriendStatuses()
        {
            const string url = "https://api.vk.com/method/friends.areFriends?uids=24181068,22911407,155810539,3505305&access_token=token";
            const string json = "{\"response\":[{\"uid\":24181068,\"friend_status\":0},{\"uid\":22911407,\"friend_status\":3},{\"uid\":155810539,\"friend_status\":2},{\"uid\":3505305,\"friend_status\":1}]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            var friends = new Friends(new VkApi(browser.Object) { AccessToken = "token" });

            var dict = friends.AreFriends(new long[] {24181068, 22911407, 155810539, 3505305});

            Assert.That(dict.Count, Is.EqualTo(4));
            Assert.That(dict[24181068], Is.EqualTo(FriendStatus.NotFriend));
            Assert.That(dict[22911407], Is.EqualTo(FriendStatus.Friend));
            Assert.That(dict[155810539], Is.EqualTo(FriendStatus.InputRequest));
            Assert.That(dict[3505305], Is.EqualTo(FriendStatus.OutputRequest));
        }
    }
}