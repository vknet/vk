using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests
{
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
            // TODO: continue later
        }

        [Test]
        [Ignore]
        public void Invoke_Users_GetProfile_From_VkApi_NotNull()
        {
            Assert.That(vk.Users.Get(vk.UserId), Is.Not.Null);
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
    }
}
