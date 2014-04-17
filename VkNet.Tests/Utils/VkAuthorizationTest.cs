using System;

using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
    [TestFixture]
    public class VkAuthorizationTest
    {
/*        
        private const string Email = "test@test.com";
        private const string Password = "pwd1234";
        private const int AppId = 123;

        private Mock<IBrowser> browser;

        [SetUp]
        public void SetUp()
        {
            browser = new Mock<IBrowser>();
            service = new VkAuthorizationService(browser.Object);
        }
*/
        [Test]
        public void CreateAuthorizeUrl_OneSettingsItem_RightUrl()
        {
            const string expected =
                "https://oauth.vk.com/authorize?client_id=123&scope=friends&redirect_uri=https://oauth.vk.com/blank.html&display=page&response_type=token";
            string url = Browser.CreateAuthorizeUrlFor(123, Settings.Friends, Display.Page);

            Assert.That(url, Is.EqualTo(expected));
        }

        [Test]
        public void Authorize_InvalidLoginOrPassword_NotAuthorizedAndAuthorizationNotRequired()
        {
            const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail";            

            var authorization = VkAuthorization.From(new Uri(urlWithBadLoginOrPassword));

            Assert.IsFalse(authorization.IsAuthorized);
            Assert.IsFalse(authorization.IsAuthorizationRequired);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "UserId is not integer value.")]
        public void Authorize_BadUserId_ThrowVkApiException()
        {
            const string urlWithBadUserId = "http://oauth.vk.com/blank.html#access_token=token&expires_in=86400&user_id=4793858sd";
            
            var authorization = VkAuthorization.From(new Uri(urlWithBadUserId));

            long userId = authorization.UserId;
        }

        [Test]
        public void Authorize_RightInput_AccessToken()
        {
            const string returnUrl = "http://oauth.vk.com/blank.html#access_token=token&expires_in=86400&user_id=4793858";
            
            var authorization = VkAuthorization.From(new Uri(returnUrl));
            
            Assert.IsTrue(authorization.IsAuthorized);

            Assert.That(authorization.AccessToken, Is.EqualTo("token"));
            Assert.That(authorization.ExpiresIn, Is.EqualTo("86400"));
            Assert.That(authorization.UserId, Is.EqualTo(4793858));
        }
    }
}