using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Pages;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class PagesCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Pages";

	[Fact]
	public void ClearCache()
	{
		Url = "https://api.vk.com/method/pages.clearCache";
		ReadJsonFile(JsonPaths.True);

		var cache = Api.Pages.ClearCache(new("https://www.vk.com/dev/groups.addLink"));

		cache.Should()
			.BeTrue();
	}

	[Fact]
	public void Get1_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.get";
		ReadCategoryJsonPath(nameof(Get1_NormalCase));

		var page = Api.Pages.Get(new()
		{
			OwnerId = -103292418,
			Title = "Свежие новости"
		});

		page.Id.Should()
			.Be(50050492);

		page.GroupId.Should()
			.Be(103292418);

		page.Title.Should()
			.Be("Свежие новости");

		page.CurrentUserCanEdit.Should()
			.BeTrue();

		page.CurrentUserCanEditAccess.Should()
			.BeTrue();

		page.WhoCanEdit.Should()
			.Be(PageAccessKind.OnlyAdministrators);

		page.WhoCanView.Should()
			.Be(PageAccessKind.OnlyMembers);

		page.Edited.Should()
			.Be("1444643546");

		page.Created.Should()
			.Be("1444643546");

		page.EditorId.Should()
			.Be(32190123);

		page.CreatorId.Should()
			.Be(32190123);

		page.ViewUrl.Should()
			.Be("http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e");
	}

	[Fact]
	public void Get2_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.get";
		ReadCategoryJsonPath(nameof(Get2_NormalCase));

		var page = Api.Pages.Get(new()
		{
			OwnerId = -103292418,
			PageId = 50050492
		});

		page.Id.Should()
			.Be(50050492);

		page.GroupId.Should()
			.Be(103292418);

		page.Title.Should()
			.Be("Свежие новости");

		page.CurrentUserCanEdit.Should()
			.BeTrue();

		page.CurrentUserCanEditAccess.Should()
			.BeTrue();

		page.WhoCanEdit.Should()
			.Be(PageAccessKind.OnlyAdministrators);

		page.WhoCanView.Should()
			.Be(PageAccessKind.OnlyMembers);

		page.Edited.Should()
			.Be("1444643546");

		page.Created.Should()
			.Be("1444643546");

		page.EditorId.Should()
			.Be(32190123);

		page.CreatorId.Should()
			.Be(32190123);

		page.ViewUrl.Should()
			.Be("http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e");
	}

	[Fact]
	public void GetHistory_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.getHistory";
		ReadCategoryJsonPath(nameof(GetHistory_NormalCase));

		var histories = Api.Pages.GetHistory(50050492, 103292418);

		histories.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetTitles_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.getTitles";
		ReadCategoryJsonPath(nameof(GetTitles_NormalCase));

		var titles = Api.Pages.GetTitles(103292418);

		titles.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetVersion_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.getVersion";
		ReadCategoryJsonPath(nameof(GetVersion_NormalCase));

		var version = Api.Pages.GetVersion(184657135, 103292418);

		version.Id.Should()
			.Be(50050492);

		version.GroupId.Should()
			.Be(103292418);

		version.Title.Should()
			.Be("Свежие новости");

		version.Source.Should()
			.Be("test");

		version.CurrentUserCanEdit.Should()
			.BeTrue();

		version.WhoCanView.Should()
			.Be(PageAccessKind.OnlyAdministrators);

		version.WhoCanEdit.Should()
			.Be(PageAccessKind.OnlyAdministrators);

		version.VersionCreated.Should()
			.Be("1444644359");

		version.CreatorId.Should()
			.Be(32190123);

		version.Html.Should()
			.Be("<!--4-->test ");
	}

	[Fact]
	public void Save1_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.save";
		ReadCategoryJsonPath(nameof(Api.Pages.Save));

		var page = Api.Pages.Save("123", 123, 32190123, "Свежие новости", 103292418);

		page.Should()
			.Be(50050492);
	}

	[Fact]
	public void Save2_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.save";
		ReadCategoryJsonPath(nameof(Api.Pages.Save));

		var page = Api.Pages.Save("123", 50050492, 32190123, "", 103292418);

		page.Should()
			.Be(50050492);
	}

	[Fact]
	public void SaveAccess_NormalCase()
	{
		Url = "https://api.vk.com/method/pages.saveAccess";
		ReadCategoryJsonPath(nameof(Api.Pages.Save));

		var page = Api.Pages.SaveAccess(50050492, 103292418);

		page.Should()
			.Be(50050492);
	}
}