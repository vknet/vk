using System;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Categories
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
        public void CheckLink_NullAsLink()
        {
            var utils = GetMockedUtilsCategory("", "");

            ExceptionAssert.Throws<ArgumentNullException>(() => utils.CheckLink(null));
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

            type.ShouldEqual(LinkAccessType.Banned);
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

            type.ShouldEqual(LinkAccessType.NotBanned);
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

            type.ShouldEqual(LinkAccessType.NotBanned);
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

             time.ShouldEqual(expected);
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

            obj.ShouldBeNull();
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

            // assert
            obj.ShouldNotBeNull();
            obj.Id.ShouldEqual(186085938);
            obj.Type.ShouldEqual(VkObjectType.User);
        }

        [Test]
        public void ResolveScreenName_ObjectIdIsVeryBig_User()
        {
            const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=azhidkov&access_token=";
            const string json =
                @"{
                    'response': {
                      'type': 'user',
                      'object_id': 922337203685471.0
                    }
                  }";

            var utils = GetMockedUtilsCategory(url, json);

            VkObject obj = utils.ResolveScreenName("azhidkov");

            // assert
            obj.ShouldNotBeNull();
            obj.Id.ShouldEqual(922337203685471);
            obj.Type.ShouldEqual(VkObjectType.User);
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

            // assert
            obj.ShouldNotBeNull();
            obj.Type.ShouldEqual(VkObjectType.Group);
            obj.Id.ShouldEqual(10639516);
        }

        [Test]
        public void ResolveScreenName_EmptyStringName_ThrowException()
        {
            var utils = GetMockedUtilsCategory("", "");

            ExceptionAssert.Throws<ArgumentNullException>(() => utils.ResolveScreenName(string.Empty));
        }
    }
}