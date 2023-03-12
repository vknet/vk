using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Enum.SafetyEnums;

public class SafetyEnumsTest
{
	[Fact]
	public void NullTest()
	{
		var result = AppFilter.FromJsonString("");

		result.Should()
			.BeNull();
	}

	[Fact]
	public void AppFilterTest()
	{
		// get test
		AppFilter.Installed.ToString()
			.Should()
			.Be("installed");

		AppFilter.Featured.ToString()
			.Should()
			.Be("featured");

		// parse test
		AppFilter.FromJsonString("installed")
			.Should()
			.Be(AppFilter.Installed);

		AppFilter.FromJsonString("featured")
			.Should()
			.Be(AppFilter.Featured);
	}

	[Fact]
	public void AppPlatformsTest()
	{
		// get test
		AppPlatforms.Ios.ToString()
			.Should()
			.Be("ios");

		AppPlatforms.Android.ToString()
			.Should()
			.Be("android");

		AppPlatforms.WinPhone.ToString()
			.Should()
			.Be("winphone");

		AppPlatforms.Web.ToString()
			.Should()
			.Be("web");

		// parse test
		AppPlatforms.FromJsonString("ios")
			.Should()
			.Be(AppPlatforms.Ios);

		AppPlatforms.FromJsonString("android")
			.Should()
			.Be(AppPlatforms.Android);

		AppPlatforms.FromJsonString("winphone")
			.Should()
			.Be(AppPlatforms.WinPhone);

		AppPlatforms.FromJsonString("web")
			.Should()
			.Be(AppPlatforms.Web);
	}

	[Fact]
	public void AppRequestTypeTest()
	{
		// get test
		AppRequestType.Invite.ToString()
			.Should()
			.Be("invite");

		AppRequestType.Request.ToString()
			.Should()
			.Be("request");

		// parse test
		AppRequestType.FromJsonString("invite")
			.Should()
			.Be(AppRequestType.Invite);

		AppRequestType.FromJsonString("request")
			.Should()
			.Be(AppRequestType.Request);
	}

	[Fact]
	public void AppSortTest()
	{
		// get test
		AppSort.PopularToday.ToString()
			.Should()
			.Be("popular_today");

		AppSort.Visitors.ToString()
			.Should()
			.Be("visitors");

		AppSort.CreateDate.ToString()
			.Should()
			.Be("create_date");

		AppSort.GrowthRate.ToString()
			.Should()
			.Be("growth_rate");

		AppSort.PopularWeek.ToString()
			.Should()
			.Be("popular_week");

		// parse test
		AppSort.FromJsonString("popular_today")
			.Should()
			.Be(AppSort.PopularToday);

		AppSort.FromJsonString("visitors")
			.Should()
			.Be(AppSort.Visitors);

		AppSort.FromJsonString("create_date")
			.Should()
			.Be(AppSort.CreateDate);

		AppSort.FromJsonString("growth_rate")
			.Should()
			.Be(AppSort.GrowthRate);

		AppSort.FromJsonString("popular_week")
			.Should()
			.Be(AppSort.PopularWeek);
	}

	[Fact]
	public void ChangeNameStatusTest()
	{
		// get test
		ChangeNameStatus.Processing.ToString()
			.Should()
			.Be("processing");

		ChangeNameStatus.Declined.ToString()
			.Should()
			.Be("declined");

		ChangeNameStatus.Success.ToString()
			.Should()
			.Be("success");

		ChangeNameStatus.WasAccepted.ToString()
			.Should()
			.Be("was_accepted");

		ChangeNameStatus.WasDeclined.ToString()
			.Should()
			.Be("was_declined");

		// parse test
		ChangeNameStatus.FromJsonString("processing")
			.Should()
			.Be(ChangeNameStatus.Processing);

		ChangeNameStatus.FromJsonString("declined")
			.Should()
			.Be(ChangeNameStatus.Declined);

		ChangeNameStatus.FromJsonString("success")
			.Should()
			.Be(ChangeNameStatus.Success);

		ChangeNameStatus.FromJsonString("was_accepted")
			.Should()
			.Be(ChangeNameStatus.WasAccepted);

		ChangeNameStatus.FromJsonString("was_declined")
			.Should()
			.Be(ChangeNameStatus.WasDeclined);
	}

	[Fact]
	public void CommentObjectTypeTest()
	{
		// get test
		CommentObjectType.Post.ToString()
			.Should()
			.Be("post");

		CommentObjectType.Photo.ToString()
			.Should()
			.Be("photo");

		CommentObjectType.Video.ToString()
			.Should()
			.Be("video");

		CommentObjectType.Topic.ToString()
			.Should()
			.Be("topic");

		CommentObjectType.Note.ToString()
			.Should()
			.Be("note");

		// parse test
		CommentObjectType.FromJsonString("post")
			.Should()
			.Be(CommentObjectType.Post);

		CommentObjectType.FromJsonString("photo")
			.Should()
			.Be(CommentObjectType.Photo);

		CommentObjectType.FromJsonString("video")
			.Should()
			.Be(CommentObjectType.Video);

		CommentObjectType.FromJsonString("topic")
			.Should()
			.Be(CommentObjectType.Topic);

		CommentObjectType.FromJsonString("note")
			.Should()
			.Be(CommentObjectType.Note);
	}

	[Fact]
	public void CommentsSortTest()
	{
		// get test
		CommentsSort.Asc.ToString()
			.Should()
			.Be("asc");

		CommentsSort.Desc.ToString()
			.Should()
			.Be("desc");

		// parse test
		CommentsSort.FromJsonString("asc")
			.Should()
			.Be(CommentsSort.Asc);

		CommentsSort.FromJsonString("desc")
			.Should()
			.Be(CommentsSort.Desc);
	}

	[Fact]
	public void DisplayTest()
	{
		// get test
		Display.Page.ToString()
			.Should()
			.Be("page");

		Display.Popup.ToString()
			.Should()
			.Be("popup");

		Display.Mobile.ToString()
			.Should()
			.Be("mobile");

		// parse test
		Display.FromJsonString("page")
			.Should()
			.Be(Display.Page);

		Display.FromJsonString("popup")
			.Should()
			.Be(Display.Popup);

		Display.FromJsonString("mobile")
			.Should()
			.Be(Display.Mobile);
	}

	[Fact]
	public void FeedTypeTest()
	{
		// get test
		FeedType.Photo.ToString()
			.Should()
			.Be("photo");

		FeedType.PhotoTag.ToString()
			.Should()
			.Be("photo_tag");

		// parse test
		FeedType.FromJsonString("photo")
			.Should()
			.Be(FeedType.Photo);

		FeedType.FromJsonString("photo_tag")
			.Should()
			.Be(FeedType.PhotoTag);
	}

	[Fact]
	public void FriendsFilterTest()
	{
		// get test
		FriendsFilter.Mutual.ToString()
			.Should()
			.Be("mutual");

		FriendsFilter.Contacts.ToString()
			.Should()
			.Be("contacts");

		FriendsFilter.MutualContacts.ToString()
			.Should()
			.Be("mutual_contacts");

		// parse test
		FriendsFilter.FromJsonString("mutual")
			.Should()
			.Be(FriendsFilter.Mutual);

		FriendsFilter.FromJsonString("contacts")
			.Should()
			.Be(FriendsFilter.Contacts);

		FriendsFilter.FromJsonString("mutual_contacts")
			.Should()
			.Be(FriendsFilter.MutualContacts);
	}

	[Fact]
	public void FriendsOrderTest()
	{
		// get test
		FriendsOrder.Name.ToString()
			.Should()
			.Be("name");

		FriendsOrder.Hints.ToString()
			.Should()
			.Be("hints");

		FriendsOrder.Random.ToString()
			.Should()
			.Be("random");

		// parse test
		FriendsOrder.FromJsonString("name")
			.Should()
			.Be(FriendsOrder.Name);

		FriendsOrder.FromJsonString("hints")
			.Should()
			.Be(FriendsOrder.Hints);

		FriendsOrder.FromJsonString("random")
			.Should()
			.Be(FriendsOrder.Random);
	}

	[Fact]
	public void NewsTypesTest()
	{
		// get test
		NewsTypes.Post.ToString()
			.Should()
			.Be("post");

		NewsTypes.Photo.ToString()
			.Should()
			.Be("photo");

		NewsTypes.PhotoTag.ToString()
			.Should()
			.Be("photo_tag");

		NewsTypes.WallPhoto.ToString()
			.Should()
			.Be("wall_photo");

		NewsTypes.Friend.ToString()
			.Should()
			.Be("friend");

		NewsTypes.Note.ToString()
			.Should()
			.Be("note");

		// parse test
		NewsTypes.FromJsonString("post")
			.Should()
			.Be(NewsTypes.Post);

		NewsTypes.FromJsonString("photo")
			.Should()
			.Be(NewsTypes.Photo);

		NewsTypes.FromJsonString("photo_tag")
			.Should()
			.Be(NewsTypes.PhotoTag);

		NewsTypes.FromJsonString("wall_photo")
			.Should()
			.Be(NewsTypes.WallPhoto);

		NewsTypes.FromJsonString("friend")
			.Should()
			.Be(NewsTypes.Friend);

		NewsTypes.FromJsonString("note")
			.Should()
			.Be(NewsTypes.Note);
	}

	[Fact]
	public void PhotoAlbumTypeTest()
	{
		// get test
		PhotoAlbumType.Wall.ToString()
			.Should()
			.Be("wall");

		PhotoAlbumType.Profile.ToString()
			.Should()
			.Be("profile");

		PhotoAlbumType.Saved.ToString()
			.Should()
			.Be("saved");

		// parse test
		PhotoAlbumType.FromJsonString("wall")
			.Should()
			.Be(PhotoAlbumType.Wall);

		PhotoAlbumType.FromJsonString("profile")
			.Should()
			.Be(PhotoAlbumType.Profile);

		PhotoAlbumType.FromJsonString("saved")
			.Should()
			.Be(PhotoAlbumType.Saved);
	}

	[Fact]
	public void PrivacyTest()
	{
		// get test
		Privacy.All.ToString()
			.Should()
			.Be("all");

		Privacy.Friends.ToString()
			.Should()
			.Be("friends");

		Privacy.FriendsOfFriends.ToString()
			.Should()
			.Be("friends_of_friends");

		Privacy.FriendsOfFriendsOnly.ToString()
			.Should()
			.Be("friends_of_friends_only");

		Privacy.Nobody.ToString()
			.Should()
			.Be("nobody");

		Privacy.OnlyMe.ToString()
			.Should()
			.Be("only_me");

		// parse test
		Privacy.FromJsonString("all")
			.Should()
			.Be(Privacy.All);

		Privacy.FromJsonString("friends")
			.Should()
			.Be(Privacy.Friends);

		Privacy.FromJsonString("friends_of_friends")
			.Should()
			.Be(Privacy.FriendsOfFriends);

		Privacy.FromJsonString("friends_of_friends_only")
			.Should()
			.Be(Privacy.FriendsOfFriendsOnly);

		Privacy.FromJsonString("nobody")
			.Should()
			.Be(Privacy.Nobody);

		Privacy.FromJsonString("only_me")
			.Should()
			.Be(Privacy.OnlyMe);
	}

	[Fact]
	public void KeyboardButtonActionTypeTest()
	{
		// get test
		KeyboardButtonActionType.Text.ToString()
			.Should()
			.Be("text");

		KeyboardButtonActionType.Location.ToString()
			.Should()
			.Be("location");

		KeyboardButtonActionType.OpenLink.ToString()
			.Should()
			.Be("open_link");

		KeyboardButtonActionType.VkApp.ToString()
			.Should()
			.Be("open_app");

		KeyboardButtonActionType.VkPay.ToString()
			.Should()
			.Be("vkpay");

		KeyboardButtonActionType.Callback.ToString()
			.Should()
			.Be("callback");

		// parse test
		KeyboardButtonActionType.FromJsonString("text")
			.Should()
			.Be(KeyboardButtonActionType.Text);

		KeyboardButtonActionType.FromJsonString("location")
			.Should()
			.Be(KeyboardButtonActionType.Location);

		KeyboardButtonActionType.FromJsonString("open_link")
			.Should()
			.Be(KeyboardButtonActionType.OpenLink);

		KeyboardButtonActionType.FromJsonString("open_app")
			.Should()
			.Be(KeyboardButtonActionType.VkApp);

		KeyboardButtonActionType.FromJsonString("vkpay")
			.Should()
			.Be(KeyboardButtonActionType.VkPay);

		KeyboardButtonActionType.FromJsonString("callback")
			.Should()
			.Be(KeyboardButtonActionType.Callback);
	}

	[Fact]
	public void MarketItemButtonTitleTest()
	{
		// get test
		MarketItemButtonTitle.Buy.ToString()
			.Should()
			.Be("Купить");

		MarketItemButtonTitle.BuyATicket.ToString()
			.Should()
			.Be("Купить билет");

		MarketItemButtonTitle.GoToTheStore.ToString()
			.Should()
			.Be("Перейти в магазин");

		// parse test
		MarketItemButtonTitle.FromJsonString("Купить")
			.Should()
			.Be(MarketItemButtonTitle.Buy);

		MarketItemButtonTitle.FromJsonString("Купить билет")
			.Should()
			.Be(MarketItemButtonTitle.BuyATicket);

		MarketItemButtonTitle.FromJsonString("Перейти в магазин")
			.Should()
			.Be(MarketItemButtonTitle.GoToTheStore);
	}

	[Fact]
	public void AppWidgetTypeTest()
	{
		// get test
		AppWidgetType.Donation.ToString()
			.Should()
			.Be("donation");

		AppWidgetType.List.ToString()
			.Should()
			.Be("list");

		AppWidgetType.Match.ToString()
			.Should()
			.Be("match");

		AppWidgetType.Matches.ToString()
			.Should()
			.Be("matches");

		AppWidgetType.Table.ToString()
			.Should()
			.Be("table");

		AppWidgetType.Text.ToString()
			.Should()
			.Be("text");

		AppWidgetType.Tiles.ToString()
			.Should()
			.Be("tiles");

		AppWidgetType.CompactList.ToString()
			.Should()
			.Be("compact_list");

		AppWidgetType.CoverList.ToString()
			.Should()
			.Be("cover_list");

		// parse test
		AppWidgetType.FromJsonString("donation")
			.Should()
			.Be(AppWidgetType.Donation);

		AppWidgetType.FromJsonString("list")
			.Should()
			.Be(AppWidgetType.List);

		AppWidgetType.FromJsonString("match")
			.Should()
			.Be(AppWidgetType.Match);

		AppWidgetType.FromJsonString("matches")
			.Should()
			.Be(AppWidgetType.Matches);

		AppWidgetType.FromJsonString("table")
			.Should()
			.Be(AppWidgetType.Table);

		AppWidgetType.FromJsonString("text")
			.Should()
			.Be(AppWidgetType.Text);

		AppWidgetType.FromJsonString("tiles")
			.Should()
			.Be(AppWidgetType.Tiles);

		AppWidgetType.FromJsonString("compact_list")
			.Should()
			.Be(AppWidgetType.CompactList);

		AppWidgetType.FromJsonString("cover_list")
			.Should()
			.Be(AppWidgetType.CoverList);
	}
}