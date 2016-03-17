using System;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class UtilsCategoryTest : BaseTest
	{
		private UtilsCategory GetMockedUtilsCategory(string url, string json)
		{
			Json = json;
			Url = url;
			return new UtilsCategory(Api);
		}

		[Test]
		public void CheckLink_BannedLink()
		{
			const string url = "https://api.vk.com/method/utils.checkLink?url=http://www.kreml.ru/‎&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'status': 'banned',
                      'link': 'http://www.kreml.ru/'
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var type = utils.CheckLink("http://www.kreml.ru/‎");
			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));

			type = utils.CheckLink(new Uri("http://www.kreml.ru/‎"));

			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));
		}

		[Test]
		public void CheckLink_NotLink()
		{
			const string url = "https://api.vk.com/method/utils.checkLink?url=hsfasfsf&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'http://vk.com/'
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);
			var type = utils.CheckLink("hsfasfsf");

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
		}

		[Test]
		public void CheckLink_GoogleLink()
		{
			const string url = "https://api.vk.com/method/utils.checkLink?url=https://www.google.ru/&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'https://www.google.ru/'
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var type = utils.CheckLink("https://www.google.ru/");

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));

			type = utils.CheckLink(new Uri("https://www.google.ru/"));

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
		}


		[Test]
		public void GetServerTime_NormalCase()
		{
			const string url = "https://api.vk.com/method/utils.getServerTime?v=5.44&access_token=";
			const string json =
				@"{
                    'response': 1391153956
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var time = utils.GetServerTime();

			Assert.That(time, Is.EqualTo(DateHelper.TimeStampToDateTime(1391153956)));
		}

		[Test]
		public void ResolveScreenName_BadScreenName()
		{
			const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=3f625aef-b285-4006-a87f-0367a04f1138&v=5.44&access_token=";
			const string json =
				@"{
                    'response': []
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var obj = utils.ResolveScreenName("3f625aef-b285-4006-a87f-0367a04f1138");

			Assert.That(obj, Is.Null);
		}

		[Test]
		public void ResolveScreenName_User()
		{
			const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=azhidkov&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'type': 'user',
                      'object_id': 186085938.0
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var obj = utils.ResolveScreenName("azhidkov");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Id, Is.EqualTo(186085938));
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
		}

		[Test]
		public void ResolveScreenName_ObjectIdIsVeryBig_User()
		{
			const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=azhidkov&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'type': 'user',
                      'object_id': 922337203685471.0
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var obj = utils.ResolveScreenName("azhidkov");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Id, Is.EqualTo(922337203685471));
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
		}

		[Test]
		public void ResolveScreenName_Group()
		{
			const string url = "https://api.vk.com/method/utils.resolveScreenName?screen_name=mdk&v=5.44&access_token=";
			const string json =
				@"{
                    'response': {
                      'type': 'group',
                      'object_id': 10639516.0
                    }
                  }";

			var utils = GetMockedUtilsCategory(url, json);

			var obj = utils.ResolveScreenName("mdk");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.Group));
			Assert.That(obj.Id, Is.EqualTo(10639516));
		}

		[Test]
		public void ResolveScreenName_EmptyStringName_ThrowException()
		{
			var utils = GetMockedUtilsCategory("", "");
			Assert.That(() => utils.ResolveScreenName(string.Empty), Throws.InstanceOf<ArgumentNullException>());
		}
	}
}