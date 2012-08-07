using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class MessagesCategoryTest
    {
        private MessagesCategory GetMockedMessagesCategory(string url, string json)
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            return new MessagesCategory(new VkApi { AccessToken = "token", Browser = browser.Object });
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void SearchDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Send_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void DeleteDialog_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void MarkAsNew_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void MarkAsRead_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void SetActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetLastActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void CreateChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void EditChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetChatUsers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void AddChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void RemoveChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetLongPollHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {

        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetLongPollServer_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.GetLongPollServer();
        }

        [Test]
        public void GetLongPollServer_NormalCase_LongPollServerResponse()
        {
            const string url = "https://api.vk.com/method/messages.getLongPollServer?access_token=token";
            const string json = "{\"response\":{\"key\":\"6f4120988efaf3a7d398054b5bb5d019c5844bz3\",\"server\":\"im46.vk.com\\/im1858\",\"ts\":1627957305}}";

            var response = GetMockedMessagesCategory(url, json).GetLongPollServer();

            Assert.That(response.Key, Is.EqualTo("6f4120988efaf3a7d398054b5bb5d019c5844bz3"));
            Assert.That(response.Server, Is.EqualTo("im46.vk.com/im1858"));
            Assert.That(response.Ts, Is.EqualTo(1627957305));
        }
    }
}