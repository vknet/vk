using System;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
    [TestFixture]
    public class StatusCategoryTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        private StatusCategory GetMockedStatusCategory(string url, string json)
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            return new StatusCategory(new VkApi { AccessToken = "token", Browser = browser.Object });
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var status = new StatusCategory(new VkApi());
            status.Get(1);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Permission to perform this action is denied")]
        public void Get_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/status.get?uid=1&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 7,
                      'error_msg': 'Permission to perform this action is denied',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'status.get'
                        },
                        {
                          'key': 'uid',
                          'value': '4793858'
                        },
                        {
                          'key': 'access_token',
                          'value': 'bf0403a1ef4f5ca4bf52913da3bf60deb0bbf4dbf4d25a1a7dba6b3476c3192'
                        }
                      ]
                    }
                  }";

            var status = GetMockedStatusCategory(url, json);
            status.Get(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var status = new StatusCategory(new VkApi());
            status.Set("test");
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Set_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/status.set?text=test&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 7,
                      'error_msg': 'Permission to perform this action is denied',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'status.set'
                        },
                        {
                          'key': 'text',
                          'value': 'test'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var status = GetMockedStatusCategory(url, json);
            status.Set("test");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_TextIsNull_ThrowArgumentNullException()
        {
            var status = new StatusCategory(new VkApi { AccessToken = "token" });
            status.Set(null);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "User disabled track name broadcast")]
        public void Set_UserDisabledTrackNameBroadcast_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/status.set?audio=0_0&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 221,
                      'error_msg': 'User disabled track name broadcast',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'status.set'
                        },
                        {
                          'key': 'audio',
                          'value': '0_0'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var status = GetMockedStatusCategory(url, json);
            var audio = new Audio {Id = 0, OwnerId = 0};
            status.Set("test test test", audio);
        }

        [Test]
        public void Set_SimpleText_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/status.set?text=test test test&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var status = GetMockedStatusCategory(url, json);
            bool result = status.Set("test test test");

            Assert.That(result, Is.True);
        }

        [Test]
        public void Set_Audio_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/status.set?audio=4793858_158073513&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var status = GetMockedStatusCategory(url, json);

            var audio = new Audio { Id = 158073513, OwnerId = 4793858 };
            bool result = status.Set("test test test", audio);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Get_SimpleText_ReturnStatus()
        {
            const string url = "https://api.vk.com/method/status.get?uid=1&access_token=token";
            const string json =
                @"{
                    'response': {
                      'text': 'it really work!!!'
                    }
                  }";

            var status = GetMockedStatusCategory(url, json);
            Status s = status.Get(1);

            Assert.That(s, Is.Not.Null);
            Assert.That(s.Text, Is.EqualTo("it really work!!!"));
            Assert.That(s.Audio, Is.Null);
        }

        [Test]
        public void Get_Audio_ReturnStatus()
        {
            const string url = "https://api.vk.com/method/status.get?uid=1&access_token=token";
            const string json =
                @"{
                    'response': {
                      'text': 'Тараканы! &ndash; Собачье Сердце',
                      'audio': {
                        'id': 158073513,
                        'owner_id': 4793858,
                        'artist': 'Тараканы!',
                        'title': 'Собачье Сердце',
                        'duration': 230,
                        'url': 'http://cs4838.vkontakte.ru/u4198300/audio/3ada410d4830.mp3',
                        'performer': 'Тараканы!',
                        'lyrics_id': '7985406'
                      }
                    }
                  }";

            var status = GetMockedStatusCategory(url, json);
            Status s = status.Get(1);

            Assert.That(s, Is.Not.Null);
            Assert.That(s.Text, Is.EqualTo("Тараканы! – Собачье Сердце"));
            Assert.That(s.Audio, Is.Not.Null);
            Assert.That(s.Audio.Id, Is.EqualTo(158073513));
            Assert.That(s.Audio.OwnerId, Is.EqualTo(4793858));
            Assert.That(s.Audio.Artist, Is.EqualTo("Тараканы!"));
            Assert.That(s.Audio.Title, Is.EqualTo("Собачье Сердце"));
            Assert.That(s.Audio.Duration, Is.EqualTo(230));
            Assert.That(s.Audio.Url.OriginalString, Is.EqualTo("http://cs4838.vkontakte.ru/u4198300/audio/3ada410d4830.mp3"));
            Assert.That(s.Audio.LyricsId, Is.EqualTo(7985406));
            Assert.That(s.Audio.AlbumId, Is.Null);
        }
    }
}