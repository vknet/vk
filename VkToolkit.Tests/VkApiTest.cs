using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Utils;
using WatiN.Core.Exceptions;
using Settings = VkToolkit.Enum.Settings;

namespace VkToolkit.Tests
{
    [TestFixture]
    public class VkApiTest
    {
        private VkApi vk;
        private IDictionary<string, string> values;

        private const string ReturnUrl =
                "http://oauth.vk.com/blank.html#access_token=token&expires_in=86400&user_id=4793858";

        private const string Email = "test@test.com";
        private const string Password = "pwd1234";
        private const int AppId = 123;
            
        [SetUp]
        public void SetUp()
        {
            vk = new VkApi {AccessToken = "token"};
            values = new Dictionary<string, string>();
        }

        [Test]
        public void VkApi_Constructor_SetDefaultValues()
        {
            Assert.That(vk.ResponseType, Is.EqualTo(ResponseType.Json));
            // todo continue later
        }

        [Test]
        public void VkApi_Constructor_SetDefaultMethodCategories()
        {
            Assert.That(vk.Users, Is.Not.Null);
            Assert.That(vk.Friends, Is.Not.Null);
            // todo continue later
        }

        [Test]
        [Ignore]
        public void Invoke_Users_GetProfile_From_VkApi_NotNull()
        {
            Assert.That(vk.Users.Get(0), Is.Not.Null);
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
        public void GetApiUrl_GetProfile_XmlFormatOutput()
        {
            vk.ResponseType = ResponseType.Xml;
            values.Add("uid", "66748");

            const string expected = "https://api.vk.com/method/getProfiles.xml?uid=66748&access_token=token";

            string output = vk.GetApiUrl("getProfiles", values);
           
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void GetApiUrl_GetProfile_WithFields()
        {
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.ScreenName | ProfileFields.Education;
            values.Add("uid", "66748");
            values.Add("fields", fields.ToString().Replace(" ", ""));
            const string expected = "https://api.vk.com/method/getProfiles?uid=66748&fields=first_name,screen_name,education&access_token=token";

            string output = vk.GetApiUrl("getProfiles", values);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void IfErrorThrowException_NormalCase_NothingExceptions()
        {
            const string json =
                "{\"response\":[{\"uid\":1,\"first_name\":\"Павел\",\"last_name\":\"Дуров\",\"university\":\"1\",\"university_name\":\"СПбГУ\",\"faculty\":\"0\",\"faculty_name\":\"\",\"graduation\":\"0\"}]}";

            vk.IfErrorThrowException(json);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
        public void IfErrorThrowException_UserAuthorizationFail_ThrowUserAuthorizationFailExcption()
        {
            const string json =
                "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: invalid access_token.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"getProfiles\"},{\"key\":\"uid\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"sfastybdsjhdg\"}]}}";

            vk.IfErrorThrowException(json);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Access to the groups list is denied due to the user's privacy settings.")]
        public void IfErrorThrowException_GroupAccessDenied_ThrowAccessDeniedException()
        {
            const string json =
                "{\"error\":{\"error_code\":260,\"error_msg\":\"Access to the groups list is denied due to the user's privacy settings.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"getGroups\"},{\"key\":\"uid\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"2f3e43eb608a87632f68d140d82f5a9efa22f772f7765eb2f49f67514987c5e\"}]}}";

            vk.IfErrorThrowException(json);
        }

        [Test]
        [Ignore]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "Wrong json data.")]
        public void IfErrorThrowException_WrongJson_ThrowVkApiException()
        {
            const string json = "ThisIsNotJson";
            vk.IfErrorThrowException(json);
        }

        [Test]
        public void CreateAuthorizeUrl_OneSettingsItem_RightUrl()
        {
            const string expected = "http://oauth.vk.com/authorize?client_id=123&scope=friends&redirect_uri=http://oauth.vk.com/blank.html&display=page&response_type=token";
            string url = vk.CreateAuthorizeUrl(123, Settings.Friends, Display.Page);

            Assert.That(url, Is.EqualTo(expected));
            
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "Could not load a page.")]
        public void Authorize_NoInternet_ThrowVkApiException()
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.Authorize(Email, Password)).Throws(new ElementNotFoundException("","", "", null));

            var vk = new VkApi(browser.Object);
            vk.Authorize(AppId, Email, Password, Settings.Friends, Display.Page);
        }

        [Test]
        [ExpectedException(typeof(VkApiAuthorizationException), ExpectedMessage = "Invalid login or password")]
        public void Authorize_InvalidLoginOrPassword_ThrowVkApiAuthorizationException()
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.ContainsText(VkApi.InvalidLoginOrPassword)).Returns(true);

            var vk = new VkApi(browser.Object);
            vk.Authorize(AppId, Email, Password, Settings.Friends, Display.Page);
        }

        [Test]
        [ExpectedException(typeof(VkApiException))]
        public void Authorize_LoginNotSuccessed_ThrowVkApiException()
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.ContainsText(VkApi.LoginSuccessed)).Returns(false);

            var vk = new VkApi(browser.Object);
            vk.Authorize(AppId, Email, Password, Settings.Friends, Display.Page);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "UserId is not integer value.")]
        public void Authorize_BadUserId_ThrowVkApiException()
        {
            const string badUrl = "http://oauth.vk.com/blank.html#access_token=token&expires_in=86400&user_id=4793858sd";
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.ContainsText(VkApi.LoginSuccessed)).Returns(true);
            browser.Setup(m => m.Uri).Returns(new Uri(badUrl));

            var vk = new VkApi(browser.Object);
            vk.Authorize(AppId, Email, Password, Settings.Friends, Display.Page);
        }

        [Test]
        public void Authorize_RightInput_AccessToken()
        {   
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.ContainsText(VkApi.LoginSuccessed)).Returns(true);
            browser.Setup(m => m.Uri).Returns(new Uri(ReturnUrl));
            
            var vk = new VkApi(browser.Object);
            vk.Authorize(AppId, Email, Password, Settings.Friends, Display.Page);

            Assert.That(vk.AppId, Is.EqualTo(AppId));
            Assert.That(vk.Email, Is.EqualTo(Email));
            Assert.That(vk.Password, Is.EqualTo(Password));
            Assert.That(vk.AccessToken, Is.EqualTo("token"));
            Assert.That(vk.ExpiresIn, Is.EqualTo("86400"));
            Assert.That(vk.UserId, Is.EqualTo(4793858));

            browser.Verify(m => m.ClearCookies(), Times.Once());
            browser.Verify(m => m.Close(), Times.Once());
            browser.Verify(m => m.GoTo(It.IsAny<string>()), Times.Once());
            browser.Verify(m => m.Authorize(Email, Password));
            browser.Verify(m => m.ContainsText(It.IsAny<string>()), Times.Exactly(2));
            browser.Verify(m => m.ContainsText(VkApi.LoginSuccessed), Times.Once());
            browser.Verify(m => m.ContainsText(VkApi.InvalidLoginOrPassword), Times.Once());
        }
        
    }
}
