using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Pages
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class PagesCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Pages";

		[Test]
		public void ClearCache()
		{
			Url = "https://api.vk.com/method/pages.clearCache";
			ReadJsonFile(JsonPaths.True);

			var cache = Api.Pages.ClearCache(new Uri("https://www.vk.com/dev/groups.addLink"));

			Assert.That(cache, Is.True);
		}

		[Test]
		public void Get1_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.get";
			ReadCategoryJsonPath(nameof(Get1_NormalCase));

			var page = Api.Pages.Get(new PagesGetParams
			{
				OwnerId = -103292418, Title = "Свежие новости"
			});

			Assert.That(page.Id, Is.EqualTo(50050492));
			Assert.That(page.GroupId, Is.EqualTo(103292418));
			Assert.That(page.Title, Is.EqualTo("Свежие новости"));
			Assert.That(page.CurrentUserCanEdit, Is.EqualTo(true));
			Assert.That(page.CurrentUserCanEditAccess, Is.EqualTo(true));

			Assert.That(page.WhoCanEdit, Is.EqualTo(PageAccessKind.OnlyAdministrators));
			Assert.That(page.WhoCanView, Is.EqualTo(PageAccessKind.OnlyMembers));
			Assert.That(page.Edited, Is.EqualTo("1444643546"));
			Assert.That(page.Created, Is.EqualTo("1444643546"));
			Assert.That(page.EditorId, Is.EqualTo(32190123));
			Assert.That(page.CreatorId, Is.EqualTo(32190123));

			Assert.That(page.ViewUrl, Is.EqualTo("http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e"));
		}

		[Test]
		public void Get2_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.get";
			ReadCategoryJsonPath(nameof(Get2_NormalCase));

			var page = Api.Pages.Get(new PagesGetParams
			{
				OwnerId = -103292418, PageId = 50050492
			});

			Assert.That(page.Id, Is.EqualTo(50050492));
			Assert.That(page.GroupId, Is.EqualTo(103292418));
			Assert.That(page.Title, Is.EqualTo("Свежие новости"));
			Assert.That(page.CurrentUserCanEdit, Is.EqualTo(true));
			Assert.That(page.CurrentUserCanEditAccess, Is.EqualTo(true));

			Assert.That(page.WhoCanEdit, Is.EqualTo(PageAccessKind.OnlyAdministrators));
			Assert.That(page.WhoCanView, Is.EqualTo(PageAccessKind.OnlyMembers));
			Assert.That(page.Edited, Is.EqualTo("1444643546"));
			Assert.That(page.Created, Is.EqualTo("1444643546"));
			Assert.That(page.EditorId, Is.EqualTo(32190123));
			Assert.That(page.CreatorId, Is.EqualTo(32190123));

			Assert.That(page.ViewUrl, Is.EqualTo("http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e"));
		}

		[Test]
		public void GetHistory_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.getHistory";
			ReadCategoryJsonPath(nameof(GetHistory_NormalCase));

			var histories = Api.Pages.GetHistory(50050492, 103292418);

			Assert.That(histories, Is.Not.Null);
		}

		[Test]
		public void GetTitles_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.getTitles";
			ReadCategoryJsonPath(nameof(GetTitles_NormalCase));

			var titles = Api.Pages.GetTitles(103292418);

			Assert.That(titles, Is.Not.Null);
		}

		[Test]
		public void GetVersion_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.getVersion";
			ReadCategoryJsonPath(nameof(GetVersion_NormalCase));

			var version = Api.Pages.GetVersion(184657135, 103292418);

			Assert.That(version.Id, Is.EqualTo(50050492));
			Assert.That(version.GroupId, Is.EqualTo(103292418));
			Assert.That(version.Title, Is.EqualTo("Свежие новости"));
			Assert.That(version.Source, Is.EqualTo("test"));
			Assert.That(version.CurrentUserCanEdit, Is.EqualTo(true));
			Assert.That(version.WhoCanView, Is.EqualTo(PageAccessKind.OnlyAdministrators));
			Assert.That(version.WhoCanEdit, Is.EqualTo(PageAccessKind.OnlyAdministrators));
			Assert.That(version.VersionCreated, Is.EqualTo("1444644359"));
			Assert.That(version.CreatorId, Is.EqualTo(32190123));
			Assert.That(version.Html, Is.EqualTo("<!--4-->test "));
		}

		[Test]
		public void Save1_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.save";
			ReadCategoryJsonPath(nameof(Api.Pages.Save));

			var page = Api.Pages.Save("123", 123, 32190123, "Свежие новости", 103292418);

			Assert.That(page, Is.EqualTo(50050492));
		}

		[Test]
		public void Save2_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.save";
			ReadCategoryJsonPath(nameof(Api.Pages.Save));

			var page = Api.Pages.Save("123", 50050492, 32190123, "", 103292418);

			Assert.That(page, Is.EqualTo(50050492));
		}

		[Test]
		public void SaveAccess_NormalCase()
		{
			Url = "https://api.vk.com/method/pages.saveAccess";
			ReadCategoryJsonPath(nameof(Api.Pages.Save));

			var page = Api.Pages.SaveAccess(50050492, 103292418);

			Assert.That(page, Is.EqualTo(50050492));
		}
	}
}