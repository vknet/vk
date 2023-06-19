using System;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Categories.Utils;

public class UtilsCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Utils";

	[Fact]
	public void CheckLink_BannedLink()
	{
		Url = "https://api.vk.com/method/utils.checkLink";
		ReadCategoryJsonPath(nameof(CheckLink_BannedLink));

		var type = Api.Utils.CheckLink("http://www.kreml.ru/‎");

		type.Status.Should()
			.Be(LinkAccessType.Banned);

		type = Api.Utils.CheckLink(new Uri("http://www.kreml.ru/‎"));

		type.Status.Should()
			.Be(LinkAccessType.Banned);
	}

	[Fact]
	public void CheckLink_GoogleLink()
	{
		Url = "https://api.vk.com/method/utils.checkLink";
		ReadCategoryJsonPath(nameof(CheckLink_GoogleLink));

		var type = Api.Utils.CheckLink("https://www.google.ru/");

		type.Status.Should()
			.Be(LinkAccessType.NotBanned);

		type = Api.Utils.CheckLink(new Uri("https://www.google.ru/"));

		type.Status.Should()
			.Be(LinkAccessType.NotBanned);
	}

	[Fact]
	public void CheckLink_NotLink()
	{
		Url = "https://api.vk.com/method/utils.checkLink";
		ReadCategoryJsonPath(nameof(CheckLink_NotLink));

		FluentActions.Invoking(() => Api.Utils.CheckLink("hsfasfsf"))
			.Should()
			.ThrowExactly<UriFormatException>();
	}

	[Fact]
	public void DeleteFromLastShortened()
	{
		Url = "https://api.vk.com/method/utils.deleteFromLastShortened";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Utils.DeleteFromLastShortened("qwe");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void GetLastShortenedLinks()
	{
		Url = "https://api.vk.com/method/utils.getLastShortenedLinks";
		ReadCategoryJsonPath(nameof(GetLastShortenedLinks));

		var result = Api.Utils.GetLastShortenedLinks();

		result.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetLinksStats()
	{
		Url = "https://api.vk.com/method/utils.getLinkStats";
		ReadCategoryJsonPath(nameof(GetLinksStats));

		var result = Api.Utils.GetLinkStats(new());

		result.Should()
			.NotBeNull();

		result.Key.Should()
			.Be("6drK78");

		result.Stats.Should()
			.NotBeEmpty();

		var stat = result.Stats.FirstOrDefault();

		stat.Should()
			.NotBeNull();

		stat.Views.Should()
			.Be(1);

		stat.Timestamp.Should()
			.Be(VkResponse.TimestampToDateTime(1489309200));

		var sexAge = stat.SexAge.FirstOrDefault();

		sexAge.Should()
			.NotBeNull();

		sexAge.AgeRange.Should()
			.Be("18-21");

		sexAge.Female.Should()
			.Be(2);

		sexAge.Male.Should()
			.Be(1);

		var country = stat.Countries.FirstOrDefault();

		country.Should()
			.NotBeNull();

		country.CountryId.Should()
			.Be(1);

		country.Views.Should()
			.Be(1);

		var city = stat.Cities.FirstOrDefault();

		city.Should()
			.NotBeNull();

		city.CityId.Should()
			.Be(1);

		city.Views.Should()
			.Be(1);
	}

	[Fact]
	public void GetServerTime()
	{
		Url = "https://api.vk.com/method/utils.getServerTime";
		ReadCategoryJsonPath(nameof(GetServerTime));

		var result = Api.Utils.GetServerTime();

		result.Should()
			.Be(VkResponse.TimestampToDateTime(1489309200));
	}

	[Fact]
	public void GetShortLink()
	{
		Url = "https://api.vk.com/method/utils.getShortLink";
		ReadCategoryJsonPath(nameof(GetShortLink));

		var result = Api.Utils.GetShortLink(new("http://google.ru"), false);

		result.Should()
			.NotBeNull();

		result.ShortUrl.Should()
			.Be(new Uri("https://vk.cc/7dMDvY"));

		result.Url.Should()
			.Be(new Uri("http://google.ru"));

		result.Key.Should()
			.Be("7dMDvY");
	}

	[Fact]
	public void ResolveScreenName()
	{
		Url = "https://api.vk.com/method/utils.resolveScreenName";
		ReadCategoryJsonPath(nameof(ResolveScreenName));

		var result = Api.Utils.ResolveScreenName("durov");

		result.Should()
			.NotBeNull();

		result.Type.Should()
			.Be(VkObjectType.User);

		result.Id.Should()
			.Be(1);
	}

	[Fact]
	public void ResolveScreenName_BadScreenName()
	{
		Url = "https://api.vk.com/method/utils.resolveScreenName";
		ReadJsonFile(JsonPaths.EmptyObject);

		var obj = Api.Utils.ResolveScreenName("3f625aef-b285-4006-a87f-0367a04f1138");

		obj.Id.Should()
			.BeNull();

		obj.Type.Should().Be(0);
	}

	[Fact]
	public void ResolveScreenName_EmptyStringName_ThrowException() => FluentActions
		.Invoking(() => Api.Utils.ResolveScreenName(string.Empty))
		.Should()
		.ThrowExactly<ArgumentNullException>();

	[Fact]
	public void ResolveScreenName_Group()
	{
		Url = "https://api.vk.com/method/utils.resolveScreenName";
		ReadCategoryJsonPath(nameof(ResolveScreenName_Group));

		var obj = Api.Utils.ResolveScreenName("mdk");

		// assert
		obj.Should()
			.NotBeNull();

		obj.Type.Should()
			.Be(VkObjectType.Group);

		obj.Id.Should()
			.Be(10639516);
	}

	[Fact]
	public void ResolveScreenName_ObjectIdIsVeryBig_User()
	{
		Url = "https://api.vk.com/method/utils.resolveScreenName";
		ReadCategoryJsonPath(nameof(ResolveScreenName_ObjectIdIsVeryBig_User));

		var obj = Api.Utils.ResolveScreenName("azhidkov");

		// assert
		obj.Should()
			.NotBeNull();

		obj.Id.Should()
			.Be(922337203685471);

		obj.Type.Should()
			.Be(VkObjectType.User);
	}

	[Fact]
	public void ResolveScreenName_User()
	{
		Url = "https://api.vk.com/method/utils.resolveScreenName";
		ReadCategoryJsonPath(nameof(ResolveScreenName_User));

		var obj = Api.Utils.ResolveScreenName("azhidkov");

		// assert
		obj.Should()
			.NotBeNull();

		obj.Id.Should()
			.Be(186085938);

		obj.Type.Should()
			.Be(VkObjectType.User);
	}
}