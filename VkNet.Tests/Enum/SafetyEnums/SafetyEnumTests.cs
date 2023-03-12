using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Enum.SafetyEnums;

public class SafetyEnumsTest
{
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
}