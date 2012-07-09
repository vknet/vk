using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VkToolkit.Enum;

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
    }
}
