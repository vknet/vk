using System;
using System.Linq;
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
            var cat = new MessagesCategory(new VkApi());
            int totalCount;
            cat.Get(MessageType.Recived, out totalCount);
        }
        
        [Test]
        public void Get_NormalCaseAllFields_Messages()
        {
            const string url = "https://api.vk.com/method/messages.get?out=0&offset=5&count=3&filters=4&preview_length=100&time_offset=3281341&access_token=token";
            const string json = "{\"response\":[2217,{\"mid\":4434,\"date\":1342169928,\"out\":0,\"uid\":245242,\"read_state\":0,\"title\":\" ... \",\"body\":\"собирлись больше\"},{\"mid\":4433,\"date\":1342169920,\"out\":0,\"uid\":245242,\"read_state\":0,\"title\":\" ... \",\"body\":\"не особо\"},{\"mid\":4431,\"date\":1342169360,\"out\":0,\"uid\":245242,\"read_state\":1,\"title\":\" ... \",\"body\":\"наверное точно для демографии))\"}]}";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(It.IsAny<string>())).Returns(json);
            var cat = new MessagesCategory(new VkApi() {AccessToken = "token", Browser = browser.Object});

            int totalCount;
            var msgs = cat.Get(MessageType.Recived, out totalCount, 3, 5, MessagesFilter.FromFriends, 100, new DateTime(2012, 7, 1)).ToList();
            
            Assert.That(totalCount, Is.EqualTo(2217));
            Assert.That(msgs.Count, Is.EqualTo(3));

            Assert.That(msgs[0].Id, Is.EqualTo(4434));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 58, 48)));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Recived));
            Assert.That(msgs[0].UserId, Is.EqualTo(245242));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Unreaded));
            Assert.That(msgs[0].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[0].Body, Is.EqualTo("собирлись больше"));

            Assert.That(msgs[1].Id, Is.EqualTo(4433));
            Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 58, 40)));
            Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Recived));
            Assert.That(msgs[1].UserId, Is.EqualTo(245242));
            Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Unreaded));
            Assert.That(msgs[1].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[1].Body, Is.EqualTo("не особо"));
            
            Assert.That(msgs[2].Id, Is.EqualTo(4431));
            Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 49, 20)));
            Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Recived));
            Assert.That(msgs[2].UserId, Is.EqualTo(245242));
            Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[2].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[2].Body, Is.EqualTo("наверное точно для демографии))"));
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