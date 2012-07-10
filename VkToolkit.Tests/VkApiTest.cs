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
        [ExpectedException(typeof(UserAuthorizationFailException), ExpectedMessage = "User authorization failed: invalid access_token.")]
        public void ThrowExceptionOnServerError_UserAuthorizationFail_ThrowUserAuthorizationFailExcption()
        {
            const string json =
                "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: invalid access_token.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"getProfiles\"},{\"key\":\"uid\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"sfastybdsjhdg\"}]}}";

            vk.ThrowExceptionOnServerError(json);
        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "Wrong json data.")]
        public void ThrowExceptionOnServerError_WrongJson_ThrowVkApiException()
        {
            const string json = "ThisIsNotJson";
            vk.ThrowExceptionOnServerError(json);
        }
    }
}
