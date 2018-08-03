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

			var type = Api.Utils.CheckLink("http://www.kreml.ru/‎");
			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));

			type = Api.Utils.CheckLink(new Uri("http://www.kreml.ru/‎"));

			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));
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

			var type = Api.Utils.CheckLink("https://www.google.ru/");

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));

			type = Api.Utils.CheckLink(new Uri("https://www.google.ru/"));

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
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

			Assert.That(() => Api.Utils.CheckLink("hsfasfsf"), Throws.InstanceOf<UriFormatException>());
		}

		[Test]
		public void DeleteFromLastShortened()
		{
			Json = @"
            {
				'response': 1
			}";

			Url = "https://api.vk.com/method/utils.deleteFromLastShortened";
			var result = Api.Utils.DeleteFromLastShortened("qwe");
			Assert.True(result);
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
			Assert.NotNull(result);
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
			var result = Api.Utils.GetLinkStats(new LinkStatsParams());
			Assert.NotNull(result);
			Assert.That(result.Key, Is.EqualTo("6drK78"));
			Assert.That(result.Stats, Is.Not.Empty);
			var stat = result.Stats.FirstOrDefault();
			Assert.NotNull(stat);
			Assert.That(stat.Views, Is.EqualTo(1));

			Assert.That(stat.Timestamp
					, Is.EqualTo(VkResponse.TimestampToDateTime(1489309200)));

			var sexAge = stat.SexAge.FirstOrDefault();
			Assert.NotNull(sexAge);
			Assert.That(sexAge.AgeRange, Is.EqualTo("18-21"));
			Assert.That(sexAge.Female, Is.EqualTo(2));
			Assert.That(sexAge.Male, Is.EqualTo(1));
			var country = stat.Countries.FirstOrDefault();
			Assert.NotNull(country);
			Assert.That(country.CountryId, Is.EqualTo(1));
			Assert.That(country.Views, Is.EqualTo(1));
			var city = stat.Cities.FirstOrDefault();
			Assert.NotNull(city);
			Assert.That(city.CityId, Is.EqualTo(1));
			Assert.That(city.Views, Is.EqualTo(1));
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
			Assert.That(result, Is.EqualTo(VkResponse.TimestampToDateTime(1489309200)));
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
			var result = Api.Utils.GetShortLink(new Uri("http://google.ru"), false);
			Assert.NotNull(result);
			Assert.That(result.ShortUrl, Is.EqualTo(new Uri("https://vk.cc/7dMDvY")));
			Assert.That(result.Url, Is.EqualTo(new Uri("http://google.ru")));
			Assert.That(result.Key, Is.EqualTo("7dMDvY"));
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
			var result = Api.Utils.ResolveScreenName("durov");
			Assert.NotNull(result);
			Assert.AreEqual(result.Type, VkObjectType.User);
			Assert.That(result.Id, Is.EqualTo(1));
		}

		[Test]
		public void ResolveScreenName_BadScreenName()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";

			Json =
					@"{
                    'response': []
                  }";

			var obj = Api.Utils.ResolveScreenName("3f625aef-b285-4006-a87f-0367a04f1138");

			Assert.That(obj, Is.Null);
		}

		[Test]
		public void ResolveScreenName_EmptyStringName_ThrowException()
		{
			Assert.That(() => Api.Utils.ResolveScreenName(string.Empty), Throws.InstanceOf<ArgumentNullException>());
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

			var obj = Api.Utils.ResolveScreenName("mdk");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.Group));
			Assert.That(obj.Id, Is.EqualTo(10639516));
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

			var obj = Api.Utils.ResolveScreenName("azhidkov");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Id, Is.EqualTo(922337203685471));
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
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

			var obj = Api.Utils.ResolveScreenName("azhidkov");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Id, Is.EqualTo(186085938));
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
		}
	}
}