using System;
using FluentNUnit;
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
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
            return new StatusCategory(new VkApi { AccessToken = "token", Browser = browser });
        }

        [Test]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var status = new StatusCategory(new VkApi());
            This.Action(() => status.Get(1)).Throws<AccessTokenInvalidException>();
        }

        [Test]
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
            This.Action(() => status.Get(1)).Throws<AccessDeniedException>()
                .Message.ShouldEqual("Permission to perform this action is denied");
        }

        [Test]
        public void Set_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var status = new StatusCategory(new VkApi());
            This.Action(() => status.Set("test")).Throws<AccessTokenInvalidException>();
        }

        [Test]
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
            This.Action(() => status.Set("test")).Throws<AccessDeniedException>();
        }

        [Test]
        public void Set_TextIsNull_ThrowArgumentNullException()
        {
            var status = new StatusCategory(new VkApi { AccessToken = "token" });
            This.Action(() => status.Set(null)).Throws<ArgumentNullException>();
        }

        [Test]
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
            This.Action(() => status.Set("test test test", audio)).Throws<AccessDeniedException>()
                .Message.ShouldEqual("User disabled track name broadcast");
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
            var result = status.Set("test test test");

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
            var result = status.Set("test test test", audio);

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
            var actual = status.Get(1);

			Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Text, Is.EqualTo("it really work!!!"));
            Assert.That(actual.Audio, Is.Null);
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
            var actual = status.Get(1);

			Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Text, Is.EqualTo("Тараканы! – Собачье Сердце"));
            Assert.That(actual.Audio, Is.Not.Null);
            Assert.That(actual.Audio.Id, Is.EqualTo(158073513));
            Assert.That(actual.Audio.OwnerId, Is.EqualTo(4793858));
            Assert.That(actual.Audio.Artist, Is.EqualTo("Тараканы!"));
            Assert.That(actual.Audio.Title, Is.EqualTo("Собачье Сердце"));
            Assert.That(actual.Audio.Duration, Is.EqualTo(230));
            Assert.That(actual.Audio.Url.OriginalString, Is.EqualTo("http://cs4838.vkontakte.ru/u4198300/audio/3ada410d4830.mp3"));
            Assert.That(actual.Audio.LyricsId, Is.EqualTo(7985406));
            Assert.That(actual.Audio.AlbumId, Is.Null);
        }
    }
}