using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VkToolkit.Enum;
using VkToolkit.Exception;

namespace VkToolkit.Tests
{
    [TestFixture]
    public class VkApiTest
    {
        private VkApi vk;
        private IDictionary<string, string> values;
            
        [SetUp]
        public void SetUp()
        {
            vk = new VkApi {AccessToken = "533bacf01e11"};
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
            // todo continue later
        }

        [Test]
        [Ignore]
        public void Invoke_Users_GetProfile_From_VkApi_NotNull()
        {
            Assert.That(vk.Users.GetProfiles(0), Is.Not.Null);
        }

        [Test]
        public void GetApiUrl_GetProfile_RightUrl()
        {
            values.Add("uid", "66748");
            const string expected = "https://api.vk.com/method/getProfiles?uid=66748&access_token=533bacf01e11";

            var output = vk.GetApiUrl("getProfiles", values);

            Assert.That(output, Is.Not.Null.Or.Empty);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void GetApiUrl_GetProfile_XmlFormatOutput()
        {
            vk.ResponseType = ResponseType.Xml;
            values.Add("uid", "66748");

            const string expected = "https://api.vk.com/method/getProfiles.xml?uid=66748&access_token=533bacf01e11";

            string output = vk.GetApiUrl("getProfiles", values);
           
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void GetApiUrl_GetProfile_WithFields()
        {
            ProfileFields fields = ProfileFields.FirstName | ProfileFields.ScreenName | ProfileFields.Education;
            values.Add("uid", "66748");
            values.Add("fields", fields.ToString().Replace(" ", ""));
            const string expected = "https://api.vk.com/method/getProfiles?uid=66748&fields=first_name,screen_name,education&access_token=533bacf01e11";

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
    }
}
