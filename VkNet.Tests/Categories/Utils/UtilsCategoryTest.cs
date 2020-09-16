using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;

namespace VkNet.Tests.Categories.Utils
{
	[TestFixture]

	public class UtilsCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Utils";

		[Test]
		public void CheckLink_BannedLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";
			ReadCategoryJsonPath(nameof(CheckLink_BannedLink));

			var type = Api.Utils.CheckLink("http://www.kreml.ru/‎");

			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));

			type = Api.Utils.CheckLink(new Uri("http://www.kreml.ru/‎"));

			Assert.That(type, Is.EqualTo(LinkAccessType.Banned));
		}

		[Test]
		public void CheckLink_GoogleLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";
			ReadCategoryJsonPath(nameof(CheckLink_GoogleLink));

			var type = Api.Utils.CheckLink("https://www.google.ru/");

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));

			type = Api.Utils.CheckLink(new Uri("https://www.google.ru/"));

			Assert.That(type, Is.EqualTo(LinkAccessType.NotBanned));
		}

		[Test]
		public void CheckLink_NotLink()
		{
			Url = "https://api.vk.com/method/utils.checkLink";
			ReadCategoryJsonPath(nameof(CheckLink_NotLink));

			Assert.That(() => Api.Utils.CheckLink("hsfasfsf"), Throws.InstanceOf<UriFormatException>());
		}

		[Test]
		public void DeleteFromLastShortened()
		{
			Url = "https://api.vk.com/method/utils.deleteFromLastShortened";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Utils.DeleteFromLastShortened("qwe");

			Assert.True(result);
		}

		[Test]
		public void GetLastShortenedLinks()
		{
			Url = "https://api.vk.com/method/utils.getLastShortenedLinks";
			ReadCategoryJsonPath(nameof(GetLastShortenedLinks));

			var result = Api.Utils.GetLastShortenedLinks();

			Assert.NotNull(result);
		}

		[Test]
		public void GetLinksStats()
		{
			Url = "https://api.vk.com/method/utils.getLinkStats";
			ReadCategoryJsonPath(nameof(GetLinksStats));

			var result = Api.Utils.GetLinkStats(new LinkStatsParams());

			Assert.NotNull(result);
			Assert.That(result.Key, Is.EqualTo("6drK78"));
			Assert.That(result.Stats, Is.Not.Empty);
			var stat = result.Stats.FirstOrDefault();
			Assert.NotNull(stat);
			Assert.That(stat.Views, Is.EqualTo(1));

			Assert.That(stat.Timestamp, Is.EqualTo(VkResponse.TimestampToDateTime(1489309200)));

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
			Url = "https://api.vk.com/method/utils.getServerTime";
			ReadCategoryJsonPath(nameof(GetServerTime));

			var result = Api.Utils.GetServerTime();

			Assert.That(result, Is.EqualTo(VkResponse.TimestampToDateTime(1489309200)));
		}

		[Test]
		public void GetShortLink()
		{
			Url = "https://api.vk.com/method/utils.getShortLink";
			ReadCategoryJsonPath(nameof(GetShortLink));

			var result = Api.Utils.GetShortLink(new Uri("http://google.ru"), false);

			Assert.NotNull(result);
			Assert.That(result.ShortUrl, Is.EqualTo(new Uri("https://vk.cc/7dMDvY")));
			Assert.That(result.Url, Is.EqualTo(new Uri("http://google.ru")));
			Assert.That(result.Key, Is.EqualTo("7dMDvY"));
		}

		[Test]
		public void ResolveScreenName()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";
			ReadCategoryJsonPath(nameof(ResolveScreenName));

			var result = Api.Utils.ResolveScreenName("durov");

			Assert.NotNull(result);
			Assert.AreEqual(result.Type, VkObjectType.User);
			Assert.That(result.Id, Is.EqualTo(1));
		}

		[Test]
		public void ResolveScreenName_BadScreenName()
		{
			Url = "https://api.vk.com/method/utils.resolveScreenName";
			ReadJsonFile(JsonPaths.EmptyObject);

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
			ReadCategoryJsonPath(nameof(ResolveScreenName_Group));

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
			ReadCategoryJsonPath(nameof(ResolveScreenName_ObjectIdIsVeryBig_User));

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
			ReadCategoryJsonPath(nameof(ResolveScreenName_User));

			var obj = Api.Utils.ResolveScreenName("azhidkov");

			// assert
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.Id, Is.EqualTo(186085938));
			Assert.That(obj.Type, Is.EqualTo(VkObjectType.User));
		}
	}
}