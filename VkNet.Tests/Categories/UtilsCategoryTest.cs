using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class UtilsCategoryTest : BaseTest
	{
		[Test]
		public void CheckLink_BannedLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";

			Json =
					@"{
                    'response': {
                      'status': 'banned',
                      'link': 'http://www.kreml.ru/'
                    }
                  }";

			var type = Api.Utils.CheckLink(url: "http://www.kreml.ru/‎");
			Assert.That(actual: type, expression: Is.EqualTo(expected: LinkAccessType.Banned));

			type = Api.Utils.CheckLink(url: new Uri(uriString: "http://www.kreml.ru/‎"));

			Assert.That(actual: type, expression: Is.EqualTo(expected: LinkAccessType.Banned));
		}

		[Test]
		public void CheckLink_GoogleLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";

			Json =
					@"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'https://www.google.ru/'
                    }
                  }";

			var type = Api.Utils.CheckLink(url: "https://www.google.ru/");

			Assert.That(actual: type, expression: Is.EqualTo(expected: LinkAccessType.NotBanned));

			type = Api.Utils.CheckLink(url: new Uri(uriString: "https://www.google.ru/"));

			Assert.That(actual: type, expression: Is.EqualTo(expected: LinkAccessType.NotBanned));
		}

		[Test]
		public void CheckLink_NotLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";

			Json =
					@"{
                    'response': {
                      'status': 'not_banned',
                      'link': 'http://vk.com/'
                    }
                  }";

			Assert.That(del: () => Api.Utils.CheckLink(url: "hsfasfsf"), expr: Throws.InstanceOf<UriFormatException>());
		}

		[Test]
		public void DeleteFromLastShortened()
		{
			Json = @"
            {
				'response': 1
			}";

			Url = "https://api.vk.com/method/utils.deleteFromLastShortened";
			var result = Api.Utils.DeleteFromLastShortened(key: "qwe");
			Assert.True(condition: result);
		}

		[Test]
		public void GetLastShortenedLinks()
		{
			Json = @"
            {
				'response': {
					'count': 2,
					'items': [
					{
						'timestamp': 1490085185,
						'url': 'http://google.ru',
						'short_url': 'https://vk.cc/6oOGVh',
						'key': '6oOGVh',
						'views': 0,
						'access_key': 'a2760354e62e87ab13'
					}, 
					{
						'timestamp': 1490038465,
						'url': 'http://google.ru',
						'short_url': 'https://vk.cc/29npqH',
						'key': '29npqH',
						'views': 721
					}]
				}
			}";

			Url = "https://api.vk.com/method/utils.getLastShortenedLinks";
			var result = Api.Utils.GetLastShortenedLinks();
			Assert.NotNull(anObject: result);
		}

		[Test]
		public void GetLinksStats()
		{
			Json = @"
            {
				'response': {
					'key': '6drK78',
					'stats': [{
						'timestamp': 1489309200,
						'views': 1,
						'sex_age': [{
							'age_range': '18-21',
							'female': 2,
							'male': 1
						}],
						'countries': [{
							'country_id': 1,
							'views': 1
						}],
						'cities': [{
							'city_id': 1,
							'views': 1
						}]
					}]
				}
			}";

			Url = "https://api.vk.com/method/utils.getLinkStats";
			var result = Api.Utils.GetLinkStats(@params: new LinkStatsParams());
			Assert.NotNull(anObject: result);
			Assert.That(actual: result.Key, expression: Is.EqualTo(expected: "6drK78"));
			Assert.That(actual: result.Stats, expression: Is.Not.Empty);
			var stat = result.Stats.FirstOrDefault();
			Assert.NotNull(anObject: stat);
			Assert.That(actual: stat.Views, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: stat.Timestamp
					, expression: Is.EqualTo(expected: VkResponse.TimestampToDateTime(unixTimeStamp: 1489309200)));

			var sexAge = stat.SexAge.FirstOrDefault();
			Assert.NotNull(anObject: sexAge);
			Assert.That(actual: sexAge.AgeRange, expression: Is.EqualTo(expected: "18-21"));
			Assert.That(actual: sexAge.Female, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: sexAge.Male, expression: Is.EqualTo(expected: 1));
			var country = stat.Countries.FirstOrDefault();
			Assert.NotNull(anObject: country);
			Assert.That(actual: country.CountryId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: country.Views, expression: Is.EqualTo(expected: 1));
			var city = stat.Cities.FirstOrDefault();
			Assert.NotNull(anObject: city);
			Assert.That(actual: city.CityId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: city.Views, expression: Is.EqualTo(expected: 1));
		}

		[Test]
		public void GetServerTime()
		{
			Json = @"
            {
				'response': 1489309200
			}";

			Url = "https://api.vk.com/method/utils.getServerTime";
			var result = Api.Utils.GetServerTime();
			Assert.That(actual: result, expression: Is.EqualTo(expected: VkResponse.TimestampToDateTime(unixTimeStamp: 1489309200)));
		}

		[Test]
		public void GetShortLink()
		{
			Json = @"
            {
				'response': {
					'short_url': 'https://vk.cc/7dMDvY',
					'url': 'http://google.ru',
					'key': '7dMDvY'
				}
			}";

			Url = "https://api.vk.com/method/utils.getShortLink";
			var result = Api.Utils.GetShortLink(url: new Uri(uriString: "http://google.ru"), isPrivate: false);
			Assert.NotNull(anObject: result);
			Assert.That(actual: result.ShortUrl, expression: Is.EqualTo(expected: new Uri(uriString: "https://vk.cc/7dMDvY")));
			Assert.That(actual: result.Url, expression: Is.EqualTo(expected: new Uri(uriString: "http://google.ru")));
			Assert.That(actual: result.Key, expression: Is.EqualTo(expected: "7dMDvY"));
		}

		[Test]
		public void ResolveScreenName()
		{
			Json = @"
            {
				'response': {
					'type': 'user',
					'object_id': 1
				}
			}";

			Url = "https://api.vk.com/method/utils.resolveScreenName";
			var result = Api.Utils.ResolveScreenName(screenName: "durov");
			Assert.NotNull(anObject: result);
			Assert.AreEqual(expected: result.Type, actual: VkObjectType.User);
			Assert.That(actual: result.Id, expression: Is.EqualTo(expected: 1));
		}

		[Test]
		public void ResolveScreenName_BadScreenName()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";

			Json =
					@"{
                    'response': []
                  }";

			var obj = Api.Utils.ResolveScreenName(screenName: "3f625aef-b285-4006-a87f-0367a04f1138");

			Assert.That(actual: obj, expression: Is.Null);
		}

		[Test]
		public void ResolveScreenName_EmptyStringName_ThrowException()
		{
			Assert.That(del: () => Api.Utils.ResolveScreenName(screenName: string.Empty), expr: Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void ResolveScreenName_Group()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";

			Json =
					@"{
                    'response': {
                      'type': 'group',
                      'object_id': 10639516.0
                    }
                  }";

			var obj = Api.Utils.ResolveScreenName(screenName: "mdk");

			// assert
			Assert.That(actual: obj, expression: Is.Not.Null);
			Assert.That(actual: obj.Type, expression: Is.EqualTo(expected: VkObjectType.Group));
			Assert.That(actual: obj.Id, expression: Is.EqualTo(expected: 10639516));
		}

		[Test]
		public void ResolveScreenName_ObjectIdIsVeryBig_User()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";

			Json =
					@"{
                    'response': {
                      'type': 'user',
                      'object_id': 922337203685471.0
                    }
                  }";

			var obj = Api.Utils.ResolveScreenName(screenName: "azhidkov");

			// assert
			Assert.That(actual: obj, expression: Is.Not.Null);
			Assert.That(actual: obj.Id, expression: Is.EqualTo(expected: 922337203685471));
			Assert.That(actual: obj.Type, expression: Is.EqualTo(expected: VkObjectType.User));
		}

		[Test]
		public void ResolveScreenName_User()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";

			Json =
					@"{
                    'response': {
                      'type': 'user',
                      'object_id': 186085938.0
                    }
                  }";

			var obj = Api.Utils.ResolveScreenName(screenName: "azhidkov");

			// assert
			Assert.That(actual: obj, expression: Is.Not.Null);
			Assert.That(actual: obj.Id, expression: Is.EqualTo(expected: 186085938));
			Assert.That(actual: obj.Type, expression: Is.EqualTo(expected: VkObjectType.User));
		}
	}
}