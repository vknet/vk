using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class MessagesCategoryTest
    {
        public string json;
        public string url;

        public MessagesCategory Cat
        {
            get { return GetMockedMessagesCategory(); }
        }

        [SetUp]
        public void SetUp()
        {
            url = "";
            json = "";
        }
        
        private MessagesCategory GetMockedMessagesCategory()
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
            cat.Get(MessageType.Received, out totalCount);
        }
        
        [Test]
        public void Get_NormalCaseAllFields_Messages()
        {
            url = "https://api.vk.com/method/messages.get?out=0&offset=5&count=3&filters=4&preview_length=100&time_offset=41712634&access_token=token";
            json =
                @"{
                    'response': [
                      2217,
                      {
                        'id': 4434,
                        'date': 1342169928,
                        'out': 0,
                        'user_id': 245242,
                        'read_state': 0,
                        'title': ' ... ',
                        'body': 'собирлись больше'
                      },
                      {
                        'id': 4433,
                        'date': 1342169920,
                        'out': 0,
                        'user_id': 245242,
                        'read_state': 0,
                        'title': ' ... ',
                        'body': 'не особо'
                      },
                      {
                        'id': 4431,
                        'date': 1342169360,
                        'out': 0,
                        'user_id': 245242,
                        'read_state': 1,
                        'title': ' ... ',
                        'body': 'наверное точно для демографии))'
                      }
                    ]
                  }";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(It.IsAny<string>())).Returns(json);
            var cat = new MessagesCategory(new VkApi {AccessToken = "token", Browser = browser.Object});

            int totalCount;
            var msgs = cat.Get(MessageType.Received, out totalCount, 3, 5, MessagesFilter.FromFriends, 100, new DateTime(2012, 7, 1)).ToList();
            
            Assert.That(totalCount, Is.EqualTo(2217));
            Assert.That(msgs.Count, Is.EqualTo(3));

            Assert.That(msgs[0].Id, Is.EqualTo(4434));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 58, 48)));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[0].UserId, Is.EqualTo(245242));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Unreaded));
            Assert.That(msgs[0].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[0].Body, Is.EqualTo("собирлись больше"));

            Assert.That(msgs[1].Id, Is.EqualTo(4433));
            Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 58, 40)));
            Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[1].UserId, Is.EqualTo(245242));
            Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Unreaded));
            Assert.That(msgs[1].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[1].Body, Is.EqualTo("не особо"));
            
            Assert.That(msgs[2].Id, Is.EqualTo(4431));
            Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 49, 20)));
            Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[2].UserId, Is.EqualTo(245242));
            Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[2].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[2].Body, Is.EqualTo("наверное точно для демографии))"));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            int totalCount;
            cat.GetDialogs(1, out totalCount);
        }

        [Test]
        public void GetDialogs_NormalCase_Messages()
        {
            url = "https://api.vk.com/method/messages.getDialogs?uid=77128&count=3&access_token=token";
            json =
                @"{
                    'response': [
                      18,
                      {
                        'id': 2105,
                        'date': 1285442252,
                        'out': 0,
                        'user_id': 77128,
                        'read_state': 1,
                        'title': 'Re(15): Привет!',
                        'body': 'не..не зеленая точно...'
                      }
                    ]
                  }";

            int totalCount;
            var msgs = Cat.GetDialogs(77128, out totalCount, null, 3).ToList();

            Assert.That(totalCount, Is.EqualTo(18));
            Assert.That(msgs.Count, Is.EqualTo(1));
            Assert.That(msgs[0].Id, Is.EqualTo(2105));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2010, 9, 25, 23, 17, 32)));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[0].UserId, Is.EqualTo(77128));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[0].Title, Is.EqualTo("Re(15): Привет!"));
            Assert.That(msgs[0].Body, Is.EqualTo("не..не зеленая точно..."));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetHistory_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            int totalCount;
            cat.GetHistory(1, false, out totalCount);
        }

        [Test]
        public void GetHistory_NormalCaseAllFields_Messages()
        {
            url = "https://api.vk.com/method/messages.getHistory?uid=7712&offset=5&count=3&rev=1&access_token=token";
            json =
                @"{
                    'response': [
                      18,
                      {
                        'body': 'Таких литовкиных и сычевых',
                        'id': 2093,
                        'user_id': 4793858,
                        'from_id': 4793858,
                        'date': 1285439088,
                        'read_state': 1,
                        'out': 1
                      },
                      {
                        'body': 'в одноклассниках и в майле есть.',
                        'id': 2094,
                        'user_id': 7712,
                        'from_id': 7712,
                        'date': 1285439216,
                        'read_state': 1,
                        'out': 0
                      },
                      {
                        'body': 'думаю пива предложит попить',
                        'id': 2095,
                        'user_id': 4793858,
                        'from_id': 4793858,
                        'date': 1285439644,
                        'read_state': 1,
                        'out': 1
                      }
                    ]
                  }";
            
            int totalCount;
            var msgs = Cat.GetHistory(7712, false, out totalCount, 5, 3, true).ToList();

            Assert.That(msgs[2].Body, Is.EqualTo("думаю пива предложит попить"));
            Assert.That(msgs[2].Id, Is.EqualTo(2095));
            Assert.That(msgs[2].UserId, Is.EqualTo(4793858));
            Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2010, 9, 25, 22, 34, 4)));
            Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Sended));
            
            Assert.That(totalCount, Is.EqualTo(18));
            Assert.That(msgs.Count, Is.EqualTo(3));

            Assert.That(msgs[0].Id, Is.EqualTo(2093));
            Assert.That(msgs[0].Body, Is.EqualTo("Таких литовкиных и сычевых"));
            Assert.That(msgs[0].UserId, Is.EqualTo(4793858));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2010, 9, 25, 22, 24, 48)));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Sended));
            
            Assert.That(msgs[1].Body, Is.EqualTo("в одноклассниках и в майле есть."));
            Assert.That(msgs[1].Id, Is.EqualTo(2094));
            Assert.That(msgs[1].UserId, Is.EqualTo(7712));
            Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2010, 9, 25, 22, 26, 56)));
            Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Received));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.GetById(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            int totalCount;
            cat.GetById(new long[]{1, 3, 5}, out totalCount);
        }

        [Test]
        public void GetById_NormalCase_Message()
        {
            url = "https://api.vk.com/method/messages.getById?mids=1&access_token=token";
            json =
                @"{
                    'response': [
                      1,
                      {
                        'id': 1,
                        'date': 1197929120,
                        'out': 0,
                        'user_id': 684559,
                        'read_state': 1,
                        'title': ' ... ',
                        'body': 'Привеееет!!!!!!!!!!!'
                      }
                    ]
                  }";

            Message msg = Cat.GetById(1);

            Assert.That(msg.Id, Is.EqualTo(1));
            Assert.That(msg.Date, Is.EqualTo(new DateTime(2007, 12, 18, 2, 5, 20)));
            Assert.That(msg.Type, Is.EqualTo(MessageType.Received));
            Assert.That(msg.UserId, Is.EqualTo(684559));
            Assert.That(msg.ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msg.Title, Is.EqualTo(" ... "));
            Assert.That(msg.Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
        }

        [Test]
        public void GetById_Multiple_NormalCase_Messages()
        {
            url = "https://api.vk.com/method/messages.getById?mids=1,3,5&access_token=token";
            json =
                @"{
                    'response': [
                      3,
                      {
                        'id': 1,
                        'date': 1197929120,
                        'out': 0,
                        'user_id': 684559,
                        'read_state': 1,
                        'title': ' ... ',
                        'body': 'Привеееет!!!!!!!!!!!'
                      },
                      {
                        'id': 3,
                        'date': 1198616980,
                        'out': 1,
                        'user_id': 684559,
                        'read_state': 1,
                        'title': 'Re: Как там зачетная неделя продвигаетсо?)',
                        'body': 'Парят и парят во все дыры)... у тебя как?'
                      },
                      {
                        'id': 5,
                        'date': 1198617408,
                        'out': 0,
                        'user_id': 684559,
                        'read_state': 1,
                        'title': 'Re(2): Как там зачетная неделя продвигаетсо?)',
                        'body': 'Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)'
                      }
                    ]
                  }";
            
            int totalCount;
            var msgs = Cat.GetById(new long[] {1, 3, 5}, out totalCount).ToList();

            Assert.That(totalCount, Is.EqualTo(3));
            Assert.That(msgs.Count, Is.EqualTo(3));

            Assert.That(msgs[2].Id, Is.EqualTo(5));
            Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2007, 12, 26, 1, 16, 48)));
            Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[2].UserId, Is.EqualTo(684559));
            Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[2].Title, Is.EqualTo("Re(2): Как там зачетная неделя продвигаетсо?)"));
            Assert.That(msgs[2].Body, Is.EqualTo("Да тож не малина - последняя неделя жуть!<br>Надеюсь, домой успею ;)"));

            Assert.That(msgs[1].Id, Is.EqualTo(3));
            Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2007, 12, 26, 1, 9, 40)));
            Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
            Assert.That(msgs[1].UserId, Is.EqualTo(684559));
            Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[1].Title, Is.EqualTo("Re: Как там зачетная неделя продвигаетсо?)"));
            Assert.That(msgs[1].Body, Is.EqualTo("Парят и парят во все дыры)... у тебя как?"));
            Assert.That(msgs[0].Id, Is.EqualTo(1));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2007, 12, 18, 2, 5, 20)));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[0].UserId, Is.EqualTo(684559));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[0].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[0].Body, Is.EqualTo("Привеееет!!!!!!!!!!!"));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void SearchDialogs_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.SearchDialogs("hello");
        }

        [Test]
        public void SearchDialogs_EmptyResponse_MessageResponseWithEmptyLists()
        {
            url = "https://api.vk.com/method/messages.searchDialogs?q=привет&access_token=token";
            json =
                @"{
                    'response': []
                  }";
            
            var response = Cat.SearchDialogs("привет");

            Assert.That(response.Chats.Count, Is.EqualTo(0));
            Assert.That(response.Users.Count, Is.EqualTo(0));
        }

        [Test]
        public void SearchDialogs_NastyaQuery_TwoProfiles()
        {
            url = "https://api.vk.com/method/messages.searchDialogs?q=Настя&access_token=token";
            json =
                @"{
                    'response': [
                      {
                        'type': 'profile',
                        'uid': 7503978,
                        'first_name': 'Настя',
                        'last_name': 'Иванова'
                      },
                      {
                        'type': 'profile',
                        'uid': 68274561,
                        'first_name': 'Настя',
                        'last_name': 'Петрова'
                      }
                    ]
                  }";

            var response = Cat.SearchDialogs("Настя");
            Assert.That(response.Users.Count, Is.EqualTo(2));
            Assert.That(response.Chats.Count, Is.EqualTo(0));
            Assert.That(response.Users.ElementAt(0).Id, Is.EqualTo(7503978));
            Assert.That(response.Users.ElementAt(0).FirstName, Is.EqualTo("Настя"));
            Assert.That(response.Users.ElementAt(0).LastName, Is.EqualTo("Иванова"));
            Assert.That(response.Users.ElementAt(1).Id, Is.EqualTo(68274561));
            Assert.That(response.Users.ElementAt(1).FirstName, Is.EqualTo("Настя"));
            Assert.That(response.Users.ElementAt(1).LastName, Is.EqualTo("Петрова"));
        }

        [Test]
        public void SearchDialogs_ProfileAndChat_Response()
        {
            url = "https://api.vk.com/method/messages.searchDialogs?q=Маша&access_token=token";
            json =
                @"{
                    'response': [
                      {
                        'type': 'profile',
                        'uid': 1708231,
                        'first_name': 'Григорий',
                        'last_name': 'Клюшников'
                      },
                      {
                        'type': 'chat',
                        'id': 109,
                        'title': 'Андрей, Григорий',
                        'users': [
                          66748,
                          6492,
                          1708231
                        ]
                      }
                    ]
                  }";

            var response = Cat.SearchDialogs("Маша");

            Assert.That(response.Users.Count, Is.EqualTo(1));
            Assert.That(response.Chats.Count, Is.EqualTo(1));

            Assert.That(response.Users[0].Id, Is.EqualTo(1708231));
            Assert.That(response.Users[0].FirstName, Is.EqualTo("Григорий"));
            Assert.That(response.Users[0].LastName, Is.EqualTo("Клюшников"));

            Assert.That(response.Chats[0].Id, Is.EqualTo(109));
            Assert.That(response.Chats[0].Title, Is.EqualTo("Андрей, Григорий"));
            Assert.That(response.Chats[0].Users.Count(), Is.EqualTo(3));
            Assert.That(response.Chats[0].Users.ElementAt(0), Is.EqualTo(66748));
            Assert.That(response.Chats[0].Users.ElementAt(1), Is.EqualTo(6492));
            Assert.That(response.Chats[0].Users.ElementAt(2), Is.EqualTo(1708231));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            int totalCount;
            cat.Search("привет", out totalCount);
        }

        [Test]
        public void Search_NormalCase_Messages()
        {
            url = "https://api.vk.com/method/messages.search?q=привет&count=3&access_token=token";
            json =
                @"{
                    'response': [
                      680,
                      {
                        'id': 4442,
                        'date': 1343764972,
                        'out': 0,
                        'user_id': 1016149,
                        'read_state': 1,
                        'title': '...',
                        'body': 'Привет, Антон! Как дела?'
                      },
                      {
                        'id': 4415,
                        'date': 1342169208,
                        'out': 1,
                        'user_id': 245242,
                        'read_state': 1,
                        'title': ' ... ',
                        'body': 'привет))'
                      },
                      {
                        'id': 4414,
                        'date': 1342169192,
                        'out': 0,
                        'user_id': 245242,
                        'read_state': 1,
                        'title': ' ... ',
                        'body': 'привет, антон))'
                      }
                    ]
                  }";

            int totalCount;
            var msgs = Cat.Search("привет", out totalCount, 3).ToList();

            Assert.That(totalCount, Is.EqualTo(680));
            Assert.That(msgs.Count, Is.EqualTo(3));

            Assert.That(msgs[2].Id, Is.EqualTo(4414));
            Assert.That(msgs[2].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 46, 32)));
            Assert.That(msgs[2].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[2].UserId, Is.EqualTo(245242));
            Assert.That(msgs[2].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[2].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[2].Body, Is.EqualTo("привет, антон))"));

            Assert.That(msgs[1].Id, Is.EqualTo(4415));
            Assert.That(msgs[1].Date, Is.EqualTo(new DateTime(2012, 7, 13, 12, 46, 48)));
            Assert.That(msgs[1].Type, Is.EqualTo(MessageType.Sended));
            Assert.That(msgs[1].UserId, Is.EqualTo(245242));
            Assert.That(msgs[1].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[1].Title, Is.EqualTo(" ... "));
            Assert.That(msgs[1].Body, Is.EqualTo("привет))"));
            
            Assert.That(msgs[0].Id, Is.EqualTo(4442));
            Assert.That(msgs[0].Date, Is.EqualTo(new DateTime(2012, 8, 1, 0, 2, 52)));
            Assert.That(msgs[0].Type, Is.EqualTo(MessageType.Received));
            Assert.That(msgs[0].UserId, Is.EqualTo(1016149));
            Assert.That(msgs[0].ReadState, Is.EqualTo(MessageReadState.Readed));
            Assert.That(msgs[0].Title, Is.EqualTo("..."));
            Assert.That(msgs[0].Body, Is.EqualTo("Привет, Антон! Как дела?"));
        }

        [Test]
        public void Search_NotExistedQuery_EmptyList()
        {
            url = "https://api.vk.com/method/messages.search?q=fsjkadoivhjioashdpfisd&count=3&access_token=token";
            json =
                @"{
                    'response': [
                      0
                    ]
                  }";

            int totalCount;
            var msgs = Cat.Search("fsjkadoivhjioashdpfisd", out totalCount, 3).ToList();

            Assert.That(totalCount, Is.EqualTo(0));
            Assert.That(msgs.Count, Is.EqualTo(0));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Send_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.Send(1, false, "Привет, Паша!");
        }

        [Test]
        public void Send_DefaultFields_MessageId()
        {
            url = "https://api.vk.com/method/messages.send?uid=7550525&message=Test+from+vk.net+%3b)+%23+2&title=Test+title&type=0&access_token=token";
            json =
                @"{
                    'response': 4457
                  }";

            long id = Cat.Send(7550525, false, "Test from vk.net ;) # 2", "Test title");

            Assert.That(id, Is.EqualTo(4457));
        }

        [Test]
        public void Send_RussianText_MessageId()
        {
            url = "https://api.vk.com/method/messages.send?uid=7550525&message=%d0%97%d0%b0%d0%b8%d0%b1%d0%b8%d1%81%d1%8c+%d1%80%d0%b0%d0%b1%d0%be%d1%82%d0%b0%d0%b5%d1%82+%23+2+--++%d0%b5%d1%89%d0%b5+%d1%80%d0%b0%d0%b7%d0%be%d0%ba&title=%d0%a2%d0%b0%d0%b9%d1%82%d0%bb&type=0&access_token=token";
            json =
                @"{
                    'response': 4464
                  }";

            long id = Cat.Send(7550525, false, "Заибись работает # 2 --  еще разок", "Тайтл");

            Assert.That(id, Is.EqualTo(4464));
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "Message can not be null.")]
        public void Send_EmptyMessage_ThrowInvalidParamException()
        {
            Cat.Send(1, false, "");
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.Delete(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Delete_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.Delete(new long[] { 1 });
        }

        [Test]
        public void Delete_Id4446_True()
        {
            url = "https://api.vk.com/method/messages.delete?mids=4446&access_token=token";
            json =
                @"{
                    'response': {
                      '4446': 1
                    }
                  }";

            bool result = Cat.Delete(4446);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Delete_Multipre_4457And4464_True()
        {
            url = "https://api.vk.com/method/messages.delete?mids=4457,4464&access_token=token";
            json =
                @"{
                    'response': {
                      '4457': 1,
                      '4464': 1
                    }
                  }";

            var dict = Cat.Delete((new long[] {4457, 4464}));

            Assert.That(dict.Count, Is.EqualTo(2));
            Assert.That(dict[4457], Is.True);
            Assert.That(dict[4464], Is.True);
        }

        [Test]
        [ExpectedException(typeof(VkApiException))]
        public void Delete_Id999999_False()
        {
            url = "https://api.vk.com/method/messages.delete?mids=999999&access_token=token";
            json =
                @"{
                    'error': {
                      'error_code': 1,
                      'error_msg': 'Unknown error occured',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'messages.delete'
                        },
                        {
                          'key': 'mids',
                          'value': '999999'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            Cat.Delete(999999);
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void DeleteDialog_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.DeleteDialog(111, false);
        }

        [Test]
        public void DeleteDialog_UserId_DeleteAllMessages()
        {
            url = "https://api.vk.com/method/messages.deleteDialog?uid=4460019&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.DeleteDialog(4460019, false);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteDialog_WithAllInputParams_DeleteTwoMessages()
        {
            url = "https://api.vk.com/method/messages.deleteDialog?uid=4460019&offset=2&limit=2&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.DeleteDialog(4460019, false, 2, 2);

            Assert.That(result, Is.True);
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.Restore(1);
        }

        [Test]
        public void Restore_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.restore?message_id=134&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.Restore(134);

            Assert.That(result, Is.True);
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void MarkAsNew_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.MarkAsNew(1);
        }

        [Test]
        public void MarkAsNew_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.markAsNew?mids=1&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.MarkAsNew(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void MarkAsNew_Multiple_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.markAsNew?mids=2,3&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.MarkAsNew(new long[] {2, 3});

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void MarkAsRead_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.MarkAsRead(1);
        }

        [Test]
        public void MarkAsRead_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.markAsRead?mids=1&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.MarkAsRead(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void MarkAsRead_Multiple_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.markAsRead?mids=2,3&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.MarkAsRead(new long[]{2, 3});

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void SetActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.SetActivity(1);
        }

        [Test]
        public void SetActivity_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.setActivity?used_id=7550525&type=typing&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.SetActivity(7550525);

            Assert.That(result, Is.True);
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetLastActivity_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.GetLastActivity(1);
        }

        [Test]
        public void GetLastActivity_NormalCast_LastActivityObject()
        {
            url = "https://api.vk.com/method/messages.getLastActivity?user_id=77128&access_token=token";
            json =
                @"{
                    'response': {
                      'online': 0,
                      'time': 1344484645
                    }
                  }";

            var activity = Cat.GetLastActivity(77128);

            Assert.That(activity.UserId, Is.EqualTo(77128));
            Assert.That(activity.IsOnline, Is.False);
            Assert.That(activity.Time, Is.EqualTo(new DateTime(2012, 8, 9, 7, 57, 25)));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.GetChat(1);
        }

        [Test]
        public void GetChat_NormalCase_ChatObject()
        {
            url = "https://api.vk.com/method/messages.getChat?chat_id=2&access_token=token";
            json =
                @"{
                    'response': {
                      'type': 'chat',
                      'id': 2,
                      'title': 'test chat title',
                      'admin_id': '4793858',
                      'users': [
                        4793858,
                        5041431,
                        10657891
                      ]
                    }
                  }";

            Chat chat = Cat.GetChat(2);

            Assert.That(chat.Id, Is.EqualTo(2));
            Assert.That(chat.Title, Is.EqualTo("test chat title"));
            Assert.That(chat.AdminId, Is.EqualTo(4793858));
            Assert.That(chat.Users.Count(), Is.EqualTo(3));
            Assert.That(chat.Users.ElementAt(0), Is.EqualTo(4793858));
            Assert.That(chat.Users.ElementAt(1), Is.EqualTo(5041431));
            Assert.That(chat.Users.ElementAt(2), Is.EqualTo(10657891));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void CreateChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.CreateChat(new long[] { 1, 2 }, "hi, friends");
        }

        [Test]
        public void CreateChat_NormalCase_ChatId()
        {
            url = "https://api.vk.com/method/messages.createChat?uids=5041431,10657891&title=test+chat's+title&access_token=token";
            json =
                @"{
                    'response': 3
                  }";

            long chatId = Cat.CreateChat(new long[] { 5041431, 10657891 }, "test chat's title");

            Assert.That(chatId, Is.EqualTo(3));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void EditChat_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.EditChat(2, "new title");
        }

        [Test]
        public void EditChat_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.editChat?chat_id=2&title=new+title&access_token=token";
            json =
                @"{
                    'response': 1
                  }"; 
            
            bool result = Cat.EditChat(2, "new title");
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetChatUsers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.GetChatUsers(2);
        }

        [Test]
        public void GetChatUsers_ChatId_UserIds()
        {
            url = "https://api.vk.com/method/messages.getChatUsers?chat_id=2&access_token=token";
            json =
                @"{
                    'response': [
                      4793858,
                      5041431,
                      10657891
                    ]
                  }";

            var users = Cat.GetChatUsers(2).ToList();

            Assert.That(users.Count, Is.EqualTo(3));
            Assert.That(users[0], Is.EqualTo(4793858));
            Assert.That(users[1], Is.EqualTo(5041431));
            Assert.That(users[2], Is.EqualTo(10657891));
        }

        [Test]
        public void GetChatUsers_ChatIdWithFields_Users()
        {
            url = "https://api.vk.com/method/messages.getChatUsers?chat_id=2&fields=education&access_token=token";
            json =
                @"{
                    'response': [
                      {
                        'uid': 4793858,
                        'first_name': 'Антон',
                        'last_name': 'Жидков',
                        'university': 0,
                        'university_name': '',
                        'faculty': 0,
                        'faculty_name': '',
                        'graduation': 0,
                        'invited_by': 4793858
                      },
                      {
                        'uid': 5041431,
                        'first_name': 'Тайфур',
                        'last_name': 'Касеев',
                        'university': 431,
                        'university_name': 'ВолгГТУ',
                        'faculty': 3162,
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': 2012,
                        'invited_by': 4793858
                      },
                      {
                        'uid': 10657891,
                        'first_name': 'Максим',
                        'last_name': 'Денисов',
                        'university': 431,
                        'university_name': 'ВолгГТУ',
                        'faculty': 3162,
                        'faculty_name': 'Электроники и вычислительной техники',
                        'graduation': 2011,
                        'invited_by': 4793858
                      }
                    ]
                  }";

            var users = Cat.GetChatUsers(2, ProfileFields.Education).ToList();

            Assert.That(users.Count, Is.EqualTo(3));
            Assert.That(users[0].Id, Is.EqualTo(4793858));
            Assert.That(users[0].FirstName, Is.EqualTo("Антон"));
            Assert.That(users[0].LastName, Is.EqualTo("Жидков"));
            Assert.That(users[0].Education, Is.Null);
            Assert.That(users[0].InvitedBy, Is.EqualTo(4793858));

            Assert.That(users[1].Id, Is.EqualTo(5041431));
            Assert.That(users[1].FirstName, Is.EqualTo("Тайфур"));
            Assert.That(users[1].LastName, Is.EqualTo("Касеев"));
            Assert.That(users[1].Education.UniversityId, Is.EqualTo(431));
            Assert.That(users[1].InvitedBy, Is.EqualTo(4793858));

            Assert.That(users[2].Id, Is.EqualTo(10657891));
            Assert.That(users[2].FirstName, Is.EqualTo("Максим"));
            Assert.That(users[2].LastName, Is.EqualTo("Денисов"));
            Assert.That(users[2].Education.UniversityId, Is.EqualTo(431));
            Assert.That(users[2].Education.FacultyId, Is.EqualTo(3162));
            Assert.That(users[2].Education.Graduation, Is.EqualTo(2011));
            Assert.That(users[2].InvitedBy, Is.EqualTo(4793858));
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void AddChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.AddChatUser(2, 2);
        }

        [Test]
        public void AddChatUser_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.addChatUser?chat_id=2&uid=7550525&access_token=token";
            json =
                @"{
                    'response': 1
                  }"; 

            bool result = Cat.AddChatUser(2, 7550525);

            Assert.That(result, Is.True);
        }
        
        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void RemoveChatUser_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new MessagesCategory(new VkApi());
            cat.RemoveChatUser(2, 2);
        }

        [Test]
        public void RemoveChatUser_NormalCase_True()
        {
            url = "https://api.vk.com/method/messages.removeChatUser?chat_id=2&uid=7550525&access_token=token";
            json =
                @"{
                    'response': 1
                  }";

            bool result = Cat.RemoveChatUser(2, 7550525);

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        [Ignore]
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
            url = "https://api.vk.com/method/messages.getLongPollServer?access_token=token";
            json =
                @"{
                    'response': {
                      'key': '6f4120988efaf3a7d398054b5bb5d019c5844bz3',
                      'server': 'im46.vk.com/im1858',
                      'ts': 1627957305
                    }
                  }";

            var response = Cat.GetLongPollServer();

            Assert.That(response.Key, Is.EqualTo("6f4120988efaf3a7d398054b5bb5d019c5844bz3"));
            Assert.That(response.Server, Is.EqualTo("im46.vk.com/im1858"));
            Assert.That(response.Ts, Is.EqualTo(1627957305));
        }
    }
}