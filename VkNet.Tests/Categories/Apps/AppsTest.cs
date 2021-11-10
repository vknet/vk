using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Apps
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]

	public class AppsTest : CategoryBaseTest
	{
		protected override string Folder => "Apps";

		[Test]
		public void DeleteAppRequests_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.deleteAppRequests";
			ReadJsonFile(JsonPaths.True);

			var app = Api.Apps.DeleteAppRequests();

			Assert.That(app, Is.True);
		}

		[Test]
		public void Get_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.get";
			ReadCategoryJsonPath(nameof(Get_NormalCase));

			var app = Api.Apps.Get(new AppGetParams
			{
				AppIds = new ulong[] { 4268118 }, Platform = AppPlatforms.Web
			});

			Assert.That(app.TotalCount, Is.AtLeast(0));
			Assert.That(app.Apps.First().Title, Is.EqualTo("raventestapp"));
		}

		[Test]
		public void GetCatalog_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getCatalog";
			ReadCategoryJsonPath(nameof(GetCatalog_NormalCase));

			var app = Api.Apps.GetCatalog(new AppGetCatalogParams());

			Assert.That(app.TotalCount, Is.AtLeast(0));
			Assert.That(app.FirstOrDefault()?.Title, Is.EqualTo("Подземелья!"));
		}

		[Test]
		public void GetFriendsList_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getFriendsList";
			ReadCategoryJsonPath(nameof(GetFriendsList_NormalCase));

			var app = Api.Apps.GetFriendsList(AppRequestType.Invite);
			Assert.That(app.TotalCount, Is.GreaterThan(0));
			Assert.That(app, Is.Not.Null);
		}

		[Test]
		public void GetFriendsListEx_NormalCase()
		{
			Url = "https://api.vk.com/method/apps.getFriendsList";
			ReadCategoryJsonPath(nameof(GetFriendsListEx_NormalCase));

			var app = Api.Apps.GetFriendsList(AppRequestType.Invite, true, 5, 1, UsersFields.Online);

			Assert.That(app.TotalCount, Is.GreaterThan(0));
			Assert.That(app, Is.Not.Null);
		}

		[Test]
		public void GetLeaderboard_Extended()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";
			ReadCategoryJsonPath(nameof(GetLeaderboard_Extended));

			var app = Api.Apps.GetLeaderboard(AppRatingType.Points, null, true);

			app.Should().NotBeNull();
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Points, Is.EqualTo(256));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
			Assert.That(app.Profiles, Is.Not.Empty);
		}

		[Test]
		public void GetLeaderboard_Level()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";
			ReadCategoryJsonPath(nameof(GetLeaderboard_Level));

			var app = Api.Apps.GetLeaderboard(AppRatingType.Level);

			app.Should().NotBeNull();
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Level, Is.EqualTo(13));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
		}

		[Test]
		public void GetLeaderboard_Points()
		{
			Url = "https://api.vk.com/method/apps.getLeaderboard";
			ReadCategoryJsonPath(nameof(GetLeaderboard_Points));

			var app = Api.Apps.GetLeaderboard(AppRatingType.Points);

			app.Should().NotBeNull();
			Assert.That(app.Count, Is.EqualTo(130));
			Assert.That(app.Items, Is.Not.Empty);
			Assert.That(app.Items[0].Score, Is.EqualTo(221634238));
			Assert.That(app.Items[0].Points, Is.EqualTo(256));
			Assert.That(app.Items[0].UserId, Is.EqualTo(123));
		}
	}
}