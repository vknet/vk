using VkNet.Enums.Filters;

namespace VkNet.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using VkNet.Enums;
    using VkNet.Exception;
    using VkNet.Utils;
    using VkNet.Utils.Tests;

    [TestFixture]
    public class VkApiTest
    {
        private const string Email = "test@test.com";
        private const string Password = "pwd1234";
        private const int AppId = 123;

        private VkApi vk;
        private IDictionary<string, string> values;

        [SetUp]
        public void SetUp()
        {
            vk = new VkApi { AccessToken = "token" };
            values = new Dictionary<string, string>();
        }
        
        [Test]
        public void GetApiUrl_IntArray()
        {
            int[] arr = new[] {1, 65};

            //var parameters = new VkParameters { { "country_ids", arr } };
            var parameters = new VkParameters();
            parameters.Add<int>("country_ids", arr);

            const string expected = "https://api.vk.com/method/database.getCountriesById?country_ids=1,65&access_token=token";

            string url = vk.GetApiUrl("database.getCountriesById", parameters);

            Assert.That(url, Is.EqualTo(expected));
        }

        [Test]
        public void VkApi_Constructor_SetDefaultMethodCategories()
        {
            Assert.That(vk.Users, Is.Not.Null);
            Assert.That(vk.Friends, Is.Not.Null);
            Assert.That(vk.Status, Is.Not.Null);
            Assert.That(vk.Messages, Is.Not.Null);
            Assert.That(vk.Groups, Is.Not.Null);
            Assert.That(vk.Audio, Is.Not.Null);
            Assert.That(vk.Wall, Is.Not.Null);
            Assert.That(vk.Database, Is.Not.Null);
            Assert.That(vk.Utils, Is.Not.Null);

            vk.Fave.ShouldNotBeNull();
            vk.Video.ShouldNotBeNull();
            // TODO: continue later
        }

        [Test]
        public void GetApiUrl_GetProfile_RightUrl()
        {
            values.Add("uid", "66748");
            const string expected = "https://api.vk.com/method/getProfiles?uid=66748&access_token=token";

            var output = vk.GetApiUrl("getProfiles", values);

            Assert.That(output, Is.Not.Null.Or.Empty);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void GetApiUrl_GetProfile_WithFields()
        {
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.Domain | ProfileFields.Education;
            values.Add("uid", "66748");
            values.Add("fields", fields.ToString().Replace(" ", ""));
            const string expected = "https://api.vk.com/method/getProfiles?uid=66748&fields=first_name,domain,education&access_token=token";

            string output = vk.GetApiUrl("getProfiles", values);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof(VkApiAuthorizationException), ExpectedMessage = VkApi.InvalidAuthorization)]
        public void Authorize_BadLoginOrPasswrod_ThrowVkApiAuthorizationException()
        {
            const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail";            

            var browser = new Mock<IBrowser>();
            browser.Setup(b => b.Authorize(AppId, Email, Password, Settings.Friends)).Returns(VkAuthorization.From(new Uri(urlWithBadLoginOrPassword)));

            vk.Browser = browser.Object;
            vk.Authorize(AppId, Email, Password, Settings.Friends);
        }

        [Test]
        public void Call_ThrowsCaptchaNeededException()
        {
            const string url = "https://api.vk.com/method/messages.send?uid=1&message=hello10&type=0&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 14,
                      'error_msg': 'Captcha needed',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'messages.send'
                        },
                        {
                          'key': 'uid',
                          'value': '242508553'
                        },
                        {
                          'key': 'message',
                          'value': 'hello10'
                        },
                        {
                          'key': 'type',
                          'value': '0'
                        },
                        {
                          'key': 'access_token',
                          'value': '1fe7889c3395722934b1'
                        }
                      ],
                      'captcha_sid': '548747100691',
                      'captcha_img': 'http://api.vk.com/captcha.php?sid=548747100284&s=1'
                    }
                  }";

            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(It.IsAny<string>())).Returns(json);

            var api = new VkApi {Browser = browser.Object};

            var ex = ExceptionAssert.Throws<CaptchaNeededException>(() => api.Call("messages.send", VkParameters.Empty, true));

            ex.Sid.ShouldEqual(548747100691);
            ex.Img.ShouldEqual(new Uri("http://api.vk.com/captcha.php?sid=548747100284&s=1"));
        }

        [Test]
        public void Call_NotMoreThen3CallsPerSecond()
        {
            int invocationCount = 0;
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(It.IsAny<string>()))
                   .Returns(@"{ ""response"": 2 }")
                   .Callback(() => invocationCount++);

            var api = new VkApi {Browser = browser.Object};

            var start = DateTimeOffset.Now;
            while (true)
            {
                api.Call("someMethod", VkParameters.Empty, true);

                int total = (int)(DateTimeOffset.Now - start).TotalMilliseconds;
                if (total > 999)
                    break;
                
            }

            // Не больше 4 раз, т.к. 4-ый раз вызывается через 1002 мс после первого вызова, а total выходит через 1040 мс
            // переписать тест, когда придумаю более подходящий метод проверки
            browser.Verify(m => m.GetJson(It.IsAny<string>()), Times.AtMost(4));
        }
    }
}
