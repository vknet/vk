using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class PagesCategoryTest : BaseTest
	{
		private PagesCategory GetMockedPagesCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new PagesCategory(vk: Api);
		}

		[Test]
		public void ClearCache()
		{
			const string url = "https://api.vk.com/method/pages.clearCache";

			const string json =
					@"{
					'response': 1
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var cache = db.ClearCache(url: new Uri(uriString: "https://www.vk.com/dev/groups.addLink"));

			Assert.That(actual: cache, expression: Is.True);
		}

		[Test]
		public void Get1_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.get";

			const string json =
					@"{
					'response': {
					  'id': 50050492,
					  'group_id': 103292418,
					  'title': 'Свежие новости',
					  'current_user_can_edit': 1,
					  'current_user_can_edit_access': 1,
					  'who_can_view': 1,
					  'who_can_edit': 0,
					  'edited': 1444643546,
					  'created': 1444643546,
					  'views': 1,
					  'editor_id': 32190123,
					  'creator_id': 32190123,
					  'view_url': 'http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e'
					}
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var page = db.Get(@params: new PagesGetParams
			{
					OwnerId = -103292418
					, Title = "Свежие новости"
			});

			Assert.That(actual: page.Id, expression: Is.EqualTo(expected: 50050492));
			Assert.That(actual: page.GroupId, expression: Is.EqualTo(expected: 103292418));
			Assert.That(actual: page.Title, expression: Is.EqualTo(expected: "Свежие новости"));
			Assert.That(actual: page.CurrentUserCanEdit, expression: Is.EqualTo(expected: true));
			Assert.That(actual: page.CurrentUserCanEditAccess, expression: Is.EqualTo(expected: true));

			Assert.That(actual: page.WhoCanEdit, expression: Is.EqualTo(expected: PageAccessKind.OnlyAdministrators));
			Assert.That(actual: page.WhoCanView, expression: Is.EqualTo(expected: PageAccessKind.OnlyMembers));
			Assert.That(actual: page.Edited, expression: Is.EqualTo(expected: "1444643546"));
			Assert.That(actual: page.Created, expression: Is.EqualTo(expected: "1444643546"));
			Assert.That(actual: page.EditorId, expression: Is.EqualTo(expected: 32190123));
			Assert.That(actual: page.CreatorId, expression: Is.EqualTo(expected: 32190123));

			Assert.That(actual: page.ViewUrl
					, expression: Is.EqualTo(expected: "http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e"));
		}

		[Test]
		public void Get2_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.get";

			const string json =
					@"{
					'response': {
					  'id': 50050492,
					  'group_id': 103292418,
					  'title': 'Свежие новости',
					  'current_user_can_edit': 1,
					  'current_user_can_edit_access': 1,
					  'who_can_view': 1,
					  'who_can_edit': 0,
					  'edited': 1444643546,
					  'created': 1444643546,
					  'views': 1,
					  'editor_id': 32190123,
					  'creator_id': 32190123,
					  'view_url': 'http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e'
					}
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var page = db.Get(@params: new PagesGetParams
			{
					OwnerId = -103292418
					, PageId = 50050492
			});

			Assert.That(actual: page.Id, expression: Is.EqualTo(expected: 50050492));
			Assert.That(actual: page.GroupId, expression: Is.EqualTo(expected: 103292418));
			Assert.That(actual: page.Title, expression: Is.EqualTo(expected: "Свежие новости"));
			Assert.That(actual: page.CurrentUserCanEdit, expression: Is.EqualTo(expected: true));
			Assert.That(actual: page.CurrentUserCanEditAccess, expression: Is.EqualTo(expected: true));

			Assert.That(actual: page.WhoCanEdit, expression: Is.EqualTo(expected: PageAccessKind.OnlyAdministrators));
			Assert.That(actual: page.WhoCanView, expression: Is.EqualTo(expected: PageAccessKind.OnlyMembers));
			Assert.That(actual: page.Edited, expression: Is.EqualTo(expected: "1444643546"));
			Assert.That(actual: page.Created, expression: Is.EqualTo(expected: "1444643546"));
			Assert.That(actual: page.EditorId, expression: Is.EqualTo(expected: 32190123));
			Assert.That(actual: page.CreatorId, expression: Is.EqualTo(expected: 32190123));

			Assert.That(actual: page.ViewUrl
					, expression: Is.EqualTo(expected: "http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e"));
		}

		[Test]
		public void GetHistory_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.getHistory";

			const string json =
					@"{
					'response': [
						{
						'id': 184657345,
						'length': 3,
						'date': 1444651212,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 184657327,
						'length': 3,
						'date': 1444651093,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 184657321,
						'length': 3,
						'date': 1444651048,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 184657309,
						'length': 3,
						'date': 1444650925,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 184657308,
						'length': 3,
						'date': 1444650923,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 184657135,
						'length': 4,
						'date': 1444644359,
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}
					]
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var histories = db.GetHistory(pageId: 50050492, groupId: 103292418);

			Assert.That(actual: histories, expression: Is.Not.Null);
		}

		[Test]
		public void GetTitles_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.getTitles";

			const string json =
					@"{
					'response': [{
						'id': 50010549,
						'title': 'Условия оплаты и доставки',
						'group_id': 103292418,
						'created': 1443433192,
						'edited': 1444653608,
						'who_can_view': 2,
						'who_can_edit': 0,
						'views': 0,
						'creator_id': 32190123,
						'creator_name': 'Максим Инютин',
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}, {
						'id': 50050492,
						'title': 'Свежие новости',
						'group_id': 103292418,
						'created': 1444643546,
						'edited': 1444651212,
						'who_can_view': 0,
						'who_can_edit': 0,
						'views': 1,
						'creator_id': 32190123,
						'creator_name': 'Максим Инютин',
						'editor_id': 32190123,
						'editor_name': 'Максим Инютин'
						}
					]
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var titles = db.GetTitles(groupId: 103292418);

			Assert.That(actual: titles, expression: Is.Not.Null);
		}

		[Test]
		public void GetVersion_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.getVersion";

			const string json =
					@"{
					'response': {
						'id': 184657135,
						'page_id': 50050492,
						'group_id': 103292418,
						'title': 'Свежие новости',
						'source': 'test',
						'current_user_can_edit': 1,
						'who_can_view': 0,
						'who_can_edit': 0,
						'version_created': 1444644359,
						'creator_id': 32190123,
						'html': '<!--4-->test '
					}
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var version = db.GetVersion(versionId: 184657135, groupId: 103292418);

			Assert.That(actual: version.Id, expression: Is.EqualTo(expected: 50050492));
			Assert.That(actual: version.GroupId, expression: Is.EqualTo(expected: 103292418));
			Assert.That(actual: version.Title, expression: Is.EqualTo(expected: "Свежие новости"));
			Assert.That(actual: version.Source, expression: Is.EqualTo(expected: "test"));
			Assert.That(actual: version.CurrentUserCanEdit, expression: Is.EqualTo(expected: true));
			Assert.That(actual: version.WhoCanView, expression: Is.EqualTo(expected: PageAccessKind.OnlyAdministrators));
			Assert.That(actual: version.WhoCanEdit, expression: Is.EqualTo(expected: PageAccessKind.OnlyAdministrators));
			Assert.That(actual: version.VersionCreated, expression: Is.EqualTo(expected: "1444644359"));
			Assert.That(actual: version.CreatorId, expression: Is.EqualTo(expected: 32190123));
			Assert.That(actual: version.Html, expression: Is.EqualTo(expected: "<!--4-->test "));
		}

		[Test]
		public void Save1_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.save";

			const string json =
					@"{
					'response': 50050492
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var page = db.Save(text: "123", pageId: 103292418, groupId: 123, userId: 32190123, title: "Свежие новости");

			Assert.That(actual: page, expression: Is.EqualTo(expected: 50050492));
		}

		[Test]
		public void Save2_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.save";

			const string json =
					@"{
					'response': 50050492
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var page = db.Save(text: "123", pageId: 103292418, groupId: 50050492, userId: 32190123);

			Assert.That(actual: page, expression: Is.EqualTo(expected: 50050492));
		}

		[Test]
		public void SaveAccess_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.saveAccess";

			const string json =
					@"{
					'response': 50050492
				  }";

			var db = GetMockedPagesCategory(url: url, json: json);

			var page = db.SaveAccess(pageId: 50050492, groupId: 103292418);

			Assert.That(actual: page, expression: Is.EqualTo(expected: 50050492));
		}
	}
}