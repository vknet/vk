using System.Diagnostics.CodeAnalysis;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class PagesCategoryTest
	{
		private PagesCategory GetMockedPagesCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(b => b.GetJson(url.Replace('\'', '"')) == json);
			return new PagesCategory(new VkApi { AccessToken = "token", Browser = browser });
		}

		[Test]
		public void Get_NormalCase()
		{
			const string url = "https://api.vk.com/method/pages.get?owner_id=-103292418&global=0&site_preview=0&title=Свежие новости&need_source=0&need_html=0&v=5.37&access_token=token";
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

			var db = GetMockedPagesCategory(url, json);

			var page = db.Get(-103292418, "Свежие новости");

			Assert.That(page.Id, Is.EqualTo(50050492));
			Assert.That(page.GroupId, Is.EqualTo(103292418));
			Assert.That(page.Title, Is.EqualTo("Свежие новости"));
			Assert.That(page.CurrentUserCanEdit, Is.EqualTo(true));
			Assert.That(page.CurrentUserCanEditAccess, Is.EqualTo(true));

			Assert.That(page.WhoCanEdit, Is.EqualTo(PageAccessKind.OnlyAdministrators));
			Assert.That(page.WhoCanView, Is.EqualTo(PageAccessKind.OnlyMembers));
			Assert.That(page.Edited, Is.EqualTo("1444643546"));
			Assert.That(page.CreateTime, Is.EqualTo("1444643546"));
			Assert.That(page.EditorId, Is.EqualTo(32190123));
			Assert.That(page.CreatorId, Is.EqualTo(32190123));
			Assert.That(page.ViewUrl, Is.EqualTo("http://m.vk.com/page-103292418_50050492?api_view=bdf796b3489e4adbc46be1cb81863e"));
		}
	}
}