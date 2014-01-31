using System;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    public class UtilsCategoryTest
    {
        private UtilsCategory GetMockedUtilsCategory(string url, string json)
        {
            var mock = new Mock<IBrowser>();
            mock.Setup(m => m.GetJson(url.Replace('\'', '"'))).Returns(json);

            return new UtilsCategory(new VkApi{Browser = mock.Object});
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckLink_NullAsLink()
        {
            var utils = GetMockedUtilsCategory("", "");

            utils.CheckLink(null);
        }

        [Test]
        public void CheckLink_BannedLink()
        {
            const string url = "https://api.vk.com/method/utils.checkLink?url=http://www.kreml.ru/‎&access_token=";
            const string json =
                @"{
                    'response': {
                      'status': 'banned',
                      'link': 'http://www.kreml.ru/'
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            LinkAccessType type = utils.CheckLink("http://www.kreml.ru/‎");

            Assert.That(type, Is.EqualTo(LinkAccessType.Banned));
        }

        [Test]
        public void CheckLink_NotLink()
        {
            const string url = "https://api.vk.com/method/utils.checkLink?url=hsfasfsf&access_token=";
            const string json =
                @"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'http://vk.com/'
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);
            LinkAccessType type = utils.CheckLink("hsfasfsf");

            Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
        }

        [Test]
        public void CheckLink_GoogleLink()
        {
            const string url = "https://api.vk.com/method/utils.checkLink?url=http://www.google.com&access_token=";
            const string json =
                @"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'http://www.google.com'
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            LinkAccessType type = utils.CheckLink("http://www.google.com");

            Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
        }

         [Test]
         public void GetServerTime_NormalCase()
         {
             const string url = "https://api.vk.com/method/utils.getServerTime?access_token=";
             const string json =
                 @"{
                    'response': 1391153956
                  }";

             DateTime expected = new DateTime(2014, 1, 31, 11, 39, 16);

             var utils = GetMockedUtilsCategory(url, json);

             DateTime time = utils.GetServerTime();

             Assert.That(time, Is.EqualTo(expected));
         }

        [Test]
        public void ResolveScreenName_BadScreenName()
        {
            const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=3f625aef-b285-4006-a87f-0367a04f1138&access_token=";
            const string json =
                @"{
                    'response': []
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            VkObject obj = utils.ResolveScreenName("3f625aef-b285-4006-a87f-0367a04f1138");

            Assert.That(obj, Is.Null);
        }

        [Test]
        public void ResolveScreenName_User()
        {
            const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=azhidkov&access_token=";
            const string json =
                @"{
                    'response': {
                      'type': 'user',
                      'object_id': 186085938.0
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            VkObject obj = utils.ResolveScreenName("azhidkov");

            Assert.That(obj, Is.Not.Null);
            Assert.That(obj.Id, Is.EqualTo(186085938));
            Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
        }

        [Test]
        public void ResolveScreenName_Group()
        {
            const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=mdk&access_token=";
            const string json =
                @"{
                    'response': {
                      'type': 'group',
                      'object_id': 10639516.0
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            VkObject obj = utils.ResolveScreenName("mdk");

            Assert.That(obj, Is.Not.Null);
            Assert.That(obj.Type, Is.EqualTo(VkObjectType.Group));
            Assert.That(obj.Id, Is.EqualTo(10639516));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResolveScreenName_EmptyStringName_ThrowException()
        {
            var utils = GetMockedUtilsCategory("", "");

            utils.ResolveScreenName(string.Empty);
        }
    }
}