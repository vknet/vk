using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Apps;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class AppsTest : CategoryBaseTest
{
	protected override string Folder => "Apps";

	[Fact]
	public void DeleteAppRequests_NormalCase()
	{
		Url = "https://api.vk.com/method/apps.deleteAppRequests";
		ReadJsonFile(JsonPaths.True);

		var app = Api.Apps.DeleteAppRequests();

		app.Should()
			.BeTrue();
	}

	[Fact]
	public void Get_NormalCase()
	{
		Url = "https://api.vk.com/method/apps.get";
		ReadCategoryJsonPath(nameof(Get_NormalCase));

		var app = Api.Apps.Get(new()
		{
			AppIds = new ulong[]
			{
				4268118
			},
			Platform = AppPlatforms.Web
		});

		app.TotalCount.Should()
			.BeGreaterThanOrEqualTo(0);

		app.Apps.First()
			.Title.Should()
			.Be("raventestapp");
	}

	[Fact]
	public void GetMiniAppPolicies()
	{
		Url = "https://api.vk.com/method/apps.getMiniAppPolicies";
		ReadCategoryJsonPath(nameof(GetMiniAppPolicies));

		var app = Api.Apps.GetMiniAppPolicies(6909581);

		app.PrivacyPolicy.Should()
			.Be("https://vk.com/dev/uprivacy");
		app.Terms.Should()
			.Be("https://vk.com/dev/uterms");
	}

	[Fact]
	public void GetScopes()
	{
		Url = "https://api.vk.com/method/apps.getScopes";
		ReadCategoryJsonPath(nameof(GetScopes));

		var app = Api.Apps.GetScopes();

		app.Items.FirstOrDefault().Name.Should()
			.Be("friends");
		app.Items.FirstOrDefault().Title.Should()
			.Be("Friend list");
	}

	[Fact]
	public void GetCatalog_NormalCase()
	{
		Url = "https://api.vk.com/method/apps.getCatalog";
		ReadCategoryJsonPath(nameof(GetCatalog_NormalCase));

		var app = Api.Apps.GetCatalog(new());

		app.TotalCount.Should()
			.BeGreaterThanOrEqualTo(0);

		(app.FirstOrDefault()
				?.Title).Should()
			.Be("Подземелья!");
	}

	[Fact]
	public void GetFriendsList_NormalCase()
	{
		Url = "https://api.vk.com/method/apps.getFriendsList";
		ReadCategoryJsonPath(nameof(GetFriendsList_NormalCase));

		var app = Api.Apps.GetFriendsList(AppRequestType.Invite, null, null, null);

		app.TotalCount.Should()
			.BePositive();

		app.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetFriendsListEx_NormalCase()
	{
		Url = "https://api.vk.com/method/apps.getFriendsList";
		ReadCategoryJsonPath(nameof(GetFriendsListEx_NormalCase));

		var app = Api.Apps.GetFriendsList(AppRequestType.Invite, true, 5, 1, UsersFields.Online);

		app.TotalCount.Should()
			.BePositive();

		app.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetLeaderboard_Extended()
	{
		Url = "https://api.vk.com/method/apps.getLeaderboard";
		ReadCategoryJsonPath(nameof(GetLeaderboard_Extended));

		var app = Api.Apps.GetLeaderboard(AppRatingType.Points, null, true);

		app.Should()
			.NotBeNull();

		app.Count.Should()
			.Be(130);

		app.Items.Should()
			.NotBeEmpty();

		app.Items[0]
			.Score.Should()
			.Be(221634238);

		app.Items[0]
			.Points.Should()
			.Be(256);

		app.Items[0]
			.UserId.Should()
			.Be(123);

		app.Profiles.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetLeaderboard_Level()
	{
		Url = "https://api.vk.com/method/apps.getLeaderboard";
		ReadCategoryJsonPath(nameof(GetLeaderboard_Level));

		var app = Api.Apps.GetLeaderboard(AppRatingType.Level);

		app.Should()
			.NotBeNull();

		app.Count.Should()
			.Be(130);

		app.Items.Should()
			.NotBeEmpty();

		app.Items[0]
			.Score.Should()
			.Be(221634238);

		app.Items[0]
			.Level.Should()
			.Be(13);

		app.Items[0]
			.UserId.Should()
			.Be(123);
	}

	[Fact]
	public void GetLeaderboard_Points()
	{
		Url = "https://api.vk.com/method/apps.getLeaderboard";
		ReadCategoryJsonPath(nameof(GetLeaderboard_Points));

		var app = Api.Apps.GetLeaderboard(AppRatingType.Points);

		app.Should()
			.NotBeNull();

		app.Count.Should()
			.Be(130);

		app.Items.Should()
			.NotBeEmpty();

		app.Items[0]
			.Score.Should()
			.Be(221634238);

		app.Items[0]
			.Points.Should()
			.Be(256);

		app.Items[0]
			.UserId.Should()
			.Be(123);
	}
}