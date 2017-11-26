using NUnit.Framework;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests
{
    [TestFixture]
    public class VkAuthorizationTests
    {
        private const string Input =
            "http://oauth.vk.com/blank.html" +
            "#access_token=bf81b33c4f88f45c5e2fa3874054c3c7ae1cb0c632583ca3d9d0d949d4123d8c2c4d7069d9066eceaf815" +
            "&expires_in=86400" +
            "&user_id=32190123" +
            "&email=inyutin_maxim@mail.ru";

        [Test]
        public void CorrectParseInputString()
        {
            var auth = VkAuthorization.From(Input);
            Assert.AreEqual(auth.AccessToken,
                "bf81b33c4f88f45c5e2fa3874054c3c7ae1cb0c632583ca3d9d0d949d4123d8c2c4d7069d9066eceaf815");
            Assert.AreEqual(auth.ExpiresIn, 86400);
            Assert.AreEqual(auth.UserId, 32190123L);
            Assert.AreEqual(auth.Email, "inyutin_maxim@mail.ru");
        }

        [Test]
        public void GetUserId_Exception()
        {
            var auth = VkAuthorization.From(Input.Replace("32190123", "qwe"));
            var error = Assert.Throws<VkApiException>(() =>
            {
                var authUserId = auth.UserId;
                Assert.NotZero(authUserId);
            });

            Assert.AreEqual(error.Message, "UserId is not long value.");
        }

        [Test]
        public void GetExpiresIn_Exception()
        {
            var auth = VkAuthorization.From(Input.Replace("86400", "qwe"));
            var error = Assert.Throws<VkApiException>(() =>
            {
                var expiresIn = auth.ExpiresIn;
                Assert.NotZero(expiresIn);
            });

            Assert.AreEqual(error.Message, "ExpiresIn is not integer value.");
        }

        [Test]
        public void IsAuthorized_Success()
        {
            var auth = VkAuthorization.From(Input);
            Assert.IsTrue(auth.IsAuthorized);
        }

        [Test]
        public void IsAuthorized_Failed()
        {
            var auth = VkAuthorization.From(Input.Replace("access_token", "qwe"));
            Assert.IsFalse(auth.IsAuthorized);
        }

        [Test]
        public void IsAuthorizationRequired_False()
        {
            var auth = VkAuthorization.From(Input);
            Assert.IsFalse(auth.IsAuthorizationRequired);
        }

        [Test]
        public void IsAuthorizationRequired_True()
        {
            const string uriQuery = "https://oauth.vk.com/authorize" +
                                    "?client_id=4268118" +
                                    "&redirect_uri=https:%2F%2Foauth.vk.com%2Fblank.html" +
                                    "&response_type=token" +
                                    "&scope=140426399" +
                                    "&v=" +
                                    "&state=" +
                                    "&display=page" +
                                    "&__q_hash=90f3ddf308ca69fca660e32b09e3617b";
            var auth = VkAuthorization.From(uriQuery);
            Assert.IsTrue(auth.IsAuthorizationRequired);
        }
        
        [Test]
        public void Authorize_InvalidLoginOrPassword_NotAuthorizedAndAuthorizationNotRequired()
        {
            const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize" +
                                                     "?client_id=1" +
                                                     "&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html" +
                                                     "&response_type=token" +
                                                     "&scope=2" +
                                                     "&v=" +
                                                     "&state=" +
                                                     "&display=wap" +
                                                     "&m=4" +
                                                     "&email=mail";

            var authorization = VkAuthorization.From(urlWithBadLoginOrPassword);

            Assert.IsFalse(authorization.IsAuthorized);
            Assert.IsFalse(authorization.IsAuthorizationRequired);
        }
    }
}