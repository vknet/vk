using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class GroupsCategoryTest
    {   
        // join
        // уже есть в группе

        [SetUp]
        public void SetUp()
        {
             
        }

        private GroupsCategory GetMockedGroupCategory(string url, string json)
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            return new GroupsCategory(new VkApi(browser.Object) { AccessToken = "token" });
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Access denied: you can't join this private community")]
        public void Join_WrongGid_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=0&not_sure=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":15,\"error_msg\":\"Access denied: you can't join this private community\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"0\"},{\"key\":\"not_sure\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Join(0, true);
        }

        [Test]
        public void Leave_WrongGid_ReturnTrue()
        {
            const string url =
                "https://api.vk.com/method/groups.leave?gid=-1&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Leave(-1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Join_NormalCase_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=0&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            var result = groups.Join(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Join_NormalCaseNotSure_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=1&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Join(2, true);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Leave_NormalCase_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=2&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Leave(2);

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Join_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":7,\"error_msg\":\"Permission to perform this action is denied\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.leave\"},{\"key\":\"text\",\"value\":\"test\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);

            groups.Join(2, true);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Leave_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=2&access_token=token";
            const string json = "{\"error\":{\"error_code\":7,\"error_msg\":\"Permission to perform this action is denied\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.leave\"},{\"key\":\"text\",\"value\":\"test\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Leave(2);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Join(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Leave(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException))]
        public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=1&not_sure=0&access_token=token";
            const string json = "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: access_token was given to another ip address.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"40724899\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Join(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException))]
        public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: access_token was given to another ip address.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"40724899\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Leave(1);
        }
    }
}