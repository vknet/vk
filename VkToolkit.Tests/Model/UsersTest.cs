using Moq;
using NUnit.Framework;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Model
{
    [TestFixture]
    public class UsersTest
    {
        private Users users;

        [SetUp]
        public void SetUp()
        {
            users = new Users(new VkApi());       
        }

        [Test]
        [ExpectedException(typeof(AccessTokenNotSetException))]
        public void GetProfiles_EmptyAccessToken_ThrowAccessTokenNotSetException()
        {
            users.GetProfiles(1);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "The remote name could not be resolved: 'api.vk.com'")]
        public void GetProfiles_NotAccessToInternet_ThrowVkApiException()
        {
            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetRawHtml(It.IsAny<string>())).Throws(new VkApiException("The remote name could not be resolved: 'api.vk.com'"));

            users = new Users(new VkApi(mockBrowser.Object){AccessToken = "asgsstsfast"});

            users.GetProfiles(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
        public void GetProfiles_WrongAccesToken_Throw_ThrowUserAuthorizationException()
        {
            const string json =
                "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: invalid access_token.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"getProfiles\"},{\"key\":\"uid\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"sfastybdsjhdg\"}]}}";

            var mockBrowser = new Mock<IBrowser>();
            mockBrowser.Setup(f => f.GetRawHtml(It.IsAny<string>())).Returns(json);

            users = new Users(new VkApi(mockBrowser.Object){AccessToken = "sfastybdsjhdg"});
            users.GetProfiles(1);
        }
    }
}