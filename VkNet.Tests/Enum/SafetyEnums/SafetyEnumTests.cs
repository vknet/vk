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
	public void LikeObjectTypeTest()
	{
		// get test
		LikeObjectType.Post.ToString()
			.Should()
			.Be("post");

		LikeObjectType.Comment.ToString()
			.Should()
			.Be("comment");

		LikeObjectType.Photo.ToString()
			.Should()
			.Be("photo");

		LikeObjectType.Audio.ToString()
			.Should()
			.Be("audio");

		LikeObjectType.Video.ToString()
			.Should()
			.Be("video");

		LikeObjectType.Note.ToString()
			.Should()
			.Be("note");

		LikeObjectType.PhotoComment.ToString()
			.Should()
			.Be("photo_comment");

		LikeObjectType.VideoComment.ToString()
			.Should()
			.Be("video_comment");

		LikeObjectType.TopicComment.ToString()
			.Should()
			.Be("topic_comment");

		LikeObjectType.SitePage.ToString()
			.Should()
			.Be("sitepage");

		LikeObjectType.Market.ToString()
			.Should()
			.Be("market");

		LikeObjectType.MarketComment.ToString()
			.Should()
			.Be("market_comment");

		// parse test
		LikeObjectType.FromJsonString("post")
			.Should()
			.Be(LikeObjectType.Post);

		LikeObjectType.FromJsonString("comment")
			.Should()
			.Be(LikeObjectType.Comment);

		LikeObjectType.FromJsonString("photo")
			.Should()
			.Be(LikeObjectType.Photo);

		LikeObjectType.FromJsonString("audio")
			.Should()
			.Be(LikeObjectType.Audio);

		LikeObjectType.FromJsonString("video")
			.Should()
			.Be(LikeObjectType.Video);

		LikeObjectType.FromJsonString("note")
			.Should()
			.Be(LikeObjectType.Note);

		LikeObjectType.FromJsonString("photo_comment")
			.Should()
			.Be(LikeObjectType.PhotoComment);

		LikeObjectType.FromJsonString("video_comment")
			.Should()
			.Be(LikeObjectType.VideoComment);

		LikeObjectType.FromJsonString("topic_comment")
			.Should()
			.Be(LikeObjectType.TopicComment);

		LikeObjectType.FromJsonString("sitepage")
			.Should()
			.Be(LikeObjectType.SitePage);

		LikeObjectType.FromJsonString("market")
			.Should()
			.Be(LikeObjectType.Market);

		LikeObjectType.FromJsonString("market_comment")
			.Should()
			.Be(LikeObjectType.MarketComment);
	}

	[Fact]
	public void LikesFilterTest()
	{
		// get test
		LikesFilter.Likes.ToString()
			.Should()
			.Be("likes");

		LikesFilter.Copies.ToString()
			.Should()
			.Be("copies");

		// parse test
		LikesFilter.FromJsonString("likes")
			.Should()
			.Be(LikesFilter.Likes);

		LikesFilter.FromJsonString("copies")
			.Should()
			.Be(LikesFilter.Copies);
	}

	[Fact]
	public void MediaTypeTest()
	{
		// get test
		MediaType.Photo.ToString()
			.Should()
			.Be("photo");

		MediaType.Video.ToString()
			.Should()
			.Be("video");

		MediaType.Audio.ToString()
			.Should()
			.Be("audio");

		MediaType.Doc.ToString()
			.Should()
			.Be("doc");

		MediaType.Link.ToString()
			.Should()
			.Be("link");

		MediaType.Market.ToString()
			.Should()
			.Be("market");

		MediaType.Wall.ToString()
			.Should()
			.Be("wall");

		MediaType.Share.ToString()
			.Should()
			.Be("share");

		MediaType.Graffiti.ToString()
			.Should()
			.Be("graffiti");

		// parse test
		MediaType.FromJsonString("photo")
			.Should()
			.Be(MediaType.Photo);

		MediaType.FromJsonString("video")
			.Should()
			.Be(MediaType.Video);

		MediaType.FromJsonString("audio")
			.Should()
			.Be(MediaType.Audio);

		MediaType.FromJsonString("doc")
			.Should()
			.Be(MediaType.Doc);

		MediaType.FromJsonString("link")
			.Should()
			.Be(MediaType.Link);

		MediaType.FromJsonString("market")
			.Should()
			.Be(MediaType.Market);

		MediaType.FromJsonString("wall")
			.Should()
			.Be(MediaType.Wall);

		MediaType.FromJsonString("share")
			.Should()
			.Be(MediaType.Share);

		MediaType.FromJsonString("graffiti")
			.Should()
			.Be(MediaType.Graffiti);
	}

	[Fact]
	public void NameCaseTest()
	{
		// get test
		NameCase.Nom.ToString()
			.Should()
			.Be("nom");

		NameCase.Gen.ToString()
			.Should()
			.Be("gen");

		NameCase.Dat.ToString()
			.Should()
			.Be("dat");

		NameCase.Acc.ToString()
			.Should()
			.Be("acc");

		NameCase.Ins.ToString()
			.Should()
			.Be("ins");

		NameCase.Abl.ToString()
			.Should()
			.Be("abl");

		// parse test
		NameCase.FromJsonString("nom")
			.Should()
			.Be(NameCase.Nom);

		NameCase.FromJsonString("gen")
			.Should()
			.Be(NameCase.Gen);

		NameCase.FromJsonString("dat")
			.Should()
			.Be(NameCase.Dat);

		NameCase.FromJsonString("acc")
			.Should()
			.Be(NameCase.Acc);

		NameCase.FromJsonString("ins")
			.Should()
			.Be(NameCase.Ins);

		NameCase.FromJsonString("abl")
			.Should()
			.Be(NameCase.Abl);
	}

	[Fact]
	public void NewsObjectTypesTest()
	{
		// get test
		NewsObjectTypes.Wall.ToString()
			.Should()
			.Be("wall");

		NewsObjectTypes.Tag.ToString()
			.Should()
			.Be("tag");

		NewsObjectTypes.ProfilePhoto.ToString()
			.Should()
			.Be("profilephoto");

		NewsObjectTypes.Video.ToString()
			.Should()
			.Be("video");

		NewsObjectTypes.Photo.ToString()
			.Should()
			.Be("photo");

		NewsObjectTypes.Audio.ToString()
			.Should()
			.Be("audio");

		// parse test
		NewsObjectTypes.FromJsonString("wall")
			.Should()
			.Be(NewsObjectTypes.Wall);

		NewsObjectTypes.FromJsonString("tag")
			.Should()
			.Be(NewsObjectTypes.Tag);

		NewsObjectTypes.FromJsonString("profilephoto")
			.Should()
			.Be(NewsObjectTypes.ProfilePhoto);

		NewsObjectTypes.FromJsonString("video")
			.Should()
			.Be(NewsObjectTypes.Video);

		NewsObjectTypes.FromJsonString("photo")
			.Should()
			.Be(NewsObjectTypes.Photo);

		NewsObjectTypes.FromJsonString("audio")
			.Should()
			.Be(NewsObjectTypes.Audio);
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
	public void OccupationTypeTest()
	{
		// get test
		OccupationType.Work.ToString()
			.Should()
			.Be("work");

		OccupationType.School.ToString()
			.Should()
			.Be("school");

		OccupationType.University.ToString()
			.Should()
			.Be("university");

		// parse test
		OccupationType.FromJsonString("work")
			.Should()
			.Be(OccupationType.Work);

		OccupationType.FromJsonString("school")
			.Should()
			.Be(OccupationType.School);

		OccupationType.FromJsonString("university")
			.Should()
			.Be(OccupationType.University);
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
	public void PhotoFeedTypeTest()
	{
		// get test
		PhotoFeedType.Photo.ToString()
			.Should()
			.Be("photo");

		PhotoFeedType.PhotoTag.ToString()
			.Should()
			.Be("photo_tag");

		// parse test
		PhotoFeedType.FromJsonString("photo")
			.Should()
			.Be(PhotoFeedType.Photo);

		PhotoFeedType.FromJsonString("photo_tag")
			.Should()
			.Be(PhotoFeedType.PhotoTag);
	}

	[Fact]
	public void PhotoSearchRadiusTest()
	{
		// get test
		PhotoSearchRadius.Ten.ToString()
			.Should()
			.Be("10");

		PhotoSearchRadius.OneHundred.ToString()
			.Should()
			.Be("100");

		PhotoSearchRadius.Eighty.ToString()
			.Should()
			.Be("800");

		PhotoSearchRadius.SixThousand.ToString()
			.Should()
			.Be("6000");

		PhotoSearchRadius.FiftyThousand.ToString()
			.Should()
			.Be("50000");

		// parse test
		PhotoSearchRadius.FromJsonString("10")
			.Should()
			.Be(PhotoSearchRadius.Ten);

		PhotoSearchRadius.FromJsonString("100")
			.Should()
			.Be(PhotoSearchRadius.OneHundred);

		PhotoSearchRadius.FromJsonString("800")
			.Should()
			.Be(PhotoSearchRadius.Eighty);

		PhotoSearchRadius.FromJsonString("6000")
			.Should()
			.Be(PhotoSearchRadius.SixThousand);

		PhotoSearchRadius.FromJsonString("50000")
			.Should()
			.Be(PhotoSearchRadius.FiftyThousand);
	}

	[Fact]
	public void PhotoSizeTypeTest()
	{
		// get test
		PhotoSizeType.S.ToString()
			.Should()
			.Be("s");

		PhotoSizeType.M.ToString()
			.Should()
			.Be("m");

		PhotoSizeType.X.ToString()
			.Should()
			.Be("x");

		PhotoSizeType.O.ToString()
			.Should()
			.Be("o");

		PhotoSizeType.P.ToString()
			.Should()
			.Be("p");

		PhotoSizeType.Q.ToString()
			.Should()
			.Be("q");

		PhotoSizeType.R.ToString()
			.Should()
			.Be("r");

		PhotoSizeType.Y.ToString()
			.Should()
			.Be("y");

		PhotoSizeType.Z.ToString()
			.Should()
			.Be("z");

		PhotoSizeType.W.ToString()
			.Should()
			.Be("w");

		// parse test
		PhotoSizeType.FromJsonString("s")
			.Should()
			.Be(PhotoSizeType.S);

		PhotoSizeType.FromJsonString("m")
			.Should()
			.Be(PhotoSizeType.M);

		PhotoSizeType.FromJsonString("x")
			.Should()
			.Be(PhotoSizeType.X);

		PhotoSizeType.FromJsonString("o")
			.Should()
			.Be(PhotoSizeType.O);

		PhotoSizeType.FromJsonString("p")
			.Should()
			.Be(PhotoSizeType.P);

		PhotoSizeType.FromJsonString("q")
			.Should()
			.Be(PhotoSizeType.Q);

		PhotoSizeType.FromJsonString("r")
			.Should()
			.Be(PhotoSizeType.R);

		PhotoSizeType.FromJsonString("y")
			.Should()
			.Be(PhotoSizeType.Y);

		PhotoSizeType.FromJsonString("z")
			.Should()
			.Be(PhotoSizeType.Z);

		PhotoSizeType.FromJsonString("w")
			.Should()
			.Be(PhotoSizeType.W);
	}

	[Fact]
	public void PlatformTest()
	{
		// get test
		Platform.Android.ToString()
			.Should()
			.Be("android");

		Platform.IPhone.ToString()
			.Should()
			.Be("iphone");

		Platform.WindowsPhone.ToString()
			.Should()
			.Be("wphone");

		// parse test
		Platform.FromJsonString("android")
			.Should()
			.Be(Platform.Android);

		Platform.FromJsonString("iphone")
			.Should()
			.Be(Platform.IPhone);

		Platform.FromJsonString("wphone")
			.Should()
			.Be(Platform.WindowsPhone);
	}

	[Fact]
	public void PostSourceTypeTest()
	{
		// get test
		PostSourceType.Vk.ToString()
			.Should()
			.Be("vk");

		PostSourceType.Widget.ToString()
			.Should()
			.Be("widget");

		PostSourceType.Api.ToString()
			.Should()
			.Be("api");

		PostSourceType.Rss.ToString()
			.Should()
			.Be("rss");

		PostSourceType.Sms.ToString()
			.Should()
			.Be("sms");

		// parse test
		PostSourceType.FromJsonString("vk")
			.Should()
			.Be(PostSourceType.Vk);

		PostSourceType.FromJsonString("widget")
			.Should()
			.Be(PostSourceType.Widget);

		PostSourceType.FromJsonString("api")
			.Should()
			.Be(PostSourceType.Api);

		PostSourceType.FromJsonString("rss")
			.Should()
			.Be(PostSourceType.Rss);

		PostSourceType.FromJsonString("sms")
			.Should()
			.Be(PostSourceType.Sms);
	}

	[Fact]
	public void PostTypeOrderTest()
	{
		// get test
		PostTypeOrder.Post.ToString()
			.Should()
			.Be("post");

		PostTypeOrder.Copy.ToString()
			.Should()
			.Be("copy");

		// parse test
		PostTypeOrder.FromJsonString("post")
			.Should()
			.Be(PostTypeOrder.Post);

		PostTypeOrder.FromJsonString("copy")
			.Should()
			.Be(PostTypeOrder.Copy);
	}

	[Fact]
	public void PostTypeTest()
	{
		// get test
		PostType.Post.ToString()
			.Should()
			.Be("post");

		PostType.Copy.ToString()
			.Should()
			.Be("copy");

		PostType.Reply.ToString()
			.Should()
			.Be("reply");

		PostType.Postpone.ToString()
			.Should()
			.Be("postpone");

		PostType.Suggest.ToString()
			.Should()
			.Be("suggest");

		// parse test
		PostType.FromJsonString("post")
			.Should()
			.Be(PostType.Post);

		PostType.FromJsonString("copy")
			.Should()
			.Be(PostType.Copy);

		PostType.FromJsonString("reply")
			.Should()
			.Be(PostType.Reply);

		PostType.FromJsonString("postpone")
			.Should()
			.Be(PostType.Postpone);

		PostType.FromJsonString("suggest")
			.Should()
			.Be(PostType.Suggest);
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
	public void RelativeTypeTest()
	{
		// get test
		RelativeType.Sibling.ToString()
			.Should()
			.Be("sibling");

		RelativeType.Parent.ToString()
			.Should()
			.Be("parent");

		RelativeType.Child.ToString()
			.Should()
			.Be("child");

		RelativeType.Grandparent.ToString()
			.Should()
			.Be("grandparent");

		RelativeType.Grandchild.ToString()
			.Should()
			.Be("grandchild");

		// parse test
		RelativeType.FromJsonString("sibling")
			.Should()
			.Be(RelativeType.Sibling);

		RelativeType.FromJsonString("parent")
			.Should()
			.Be(RelativeType.Parent);

		RelativeType.FromJsonString("child")
			.Should()
			.Be(RelativeType.Child);

		RelativeType.FromJsonString("grandparent")
			.Should()
			.Be(RelativeType.Grandparent);

		RelativeType.FromJsonString("grandchild")
			.Should()
			.Be(RelativeType.Grandchild);
	}

	[Fact]
	public void ReportTypeTest()
	{
		// get test
		ReportType.Porn.ToString()
			.Should()
			.Be("porn");

		ReportType.Spam.ToString()
			.Should()
			.Be("spam");

		ReportType.Insult.ToString()
			.Should()
			.Be("insult");

		ReportType.Advertisment.ToString()
			.Should()
			.Be("advertisment");

		// parse test
		ReportType.FromJsonString("porn")
			.Should()
			.Be(ReportType.Porn);

		ReportType.FromJsonString("spam")
			.Should()
			.Be(ReportType.Spam);

		ReportType.FromJsonString("insult")
			.Should()
			.Be(ReportType.Insult);

		ReportType.FromJsonString("advertisment")
			.Should()
			.Be(ReportType.Advertisment);
	}

	[Fact]
	public void ServicesTest()
	{
		// get test
		Services.Email.ToString()
			.Should()
			.Be("email");

		Services.Phone.ToString()
			.Should()
			.Be("phone");

		Services.Twitter.ToString()
			.Should()
			.Be("twitter");

		Services.Facebook.ToString()
			.Should()
			.Be("facebook");

		Services.Odnoklassniki.ToString()
			.Should()
			.Be("odnoklassniki");

		Services.Instagram.ToString()
			.Should()
			.Be("instagram");

		Services.Google.ToString()
			.Should()
			.Be("google");

		// parse test
		Services.FromJsonString("email")
			.Should()
			.Be(Services.Email);

		Services.FromJsonString("phone")
			.Should()
			.Be(Services.Phone);

		Services.FromJsonString("twitter")
			.Should()
			.Be(Services.Twitter);

		Services.FromJsonString("facebook")
			.Should()
			.Be(Services.Facebook);

		Services.FromJsonString("odnoklassniki")
			.Should()
			.Be(Services.Odnoklassniki);

		Services.FromJsonString("instagram")
			.Should()
			.Be(Services.Instagram);

		Services.FromJsonString("google")
			.Should()
			.Be(Services.Google);
	}

	[Fact]
	public void UserSectionTest()
	{
		// get test
		UserSection.Friends.ToString()
			.Should()
			.Be("friends");

		UserSection.Subscriptions.ToString()
			.Should()
			.Be("subscriptions");

		// parse test
		UserSection.FromJsonString("friends")
			.Should()
			.Be(UserSection.Friends);

		UserSection.FromJsonString("subscriptions")
			.Should()
			.Be(UserSection.Subscriptions);
	}

	[Fact]
	public void KeyboardButtonColorTest()
	{
		// get test
		KeyboardButtonColor.Default.ToString()
			.Should()
			.Be("default");

		KeyboardButtonColor.Negative.ToString()
			.Should()
			.Be("negative");

		KeyboardButtonColor.Positive.ToString()
			.Should()
			.Be("positive");

		KeyboardButtonColor.Primary.ToString()
			.Should()
			.Be("primary");

		// parse test
		KeyboardButtonColor.FromJsonString("default")
			.Should()
			.Be(KeyboardButtonColor.Default);

		KeyboardButtonColor.FromJsonString("negative")
			.Should()
			.Be(KeyboardButtonColor.Negative);

		KeyboardButtonColor.FromJsonString("positive")
			.Should()
			.Be(KeyboardButtonColor.Positive);

		KeyboardButtonColor.FromJsonString("primary")
			.Should()
			.Be(KeyboardButtonColor.Primary);
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
	public void StoryObjectStateTest()
	{
		// get test
		StoryObjectState.Hidden.ToString()
			.Should()
			.Be("hidden");

		StoryObjectState.On.ToString()
			.Should()
			.Be("on");

		StoryObjectState.Off.ToString()
			.Should()
			.Be("off");

		// parse test
		StoryObjectState.FromJsonString("hidden")
			.Should()
			.Be(StoryObjectState.Hidden);

		StoryObjectState.FromJsonString("on")
			.Should()
			.Be(StoryObjectState.On);

		StoryObjectState.FromJsonString("off")
			.Should()
			.Be(StoryObjectState.Off);
	}

	[Fact]
	public void StoryLinkTextTest()
	{
		// get test
		StoryLinkText.Book.ToString()
			.Should()
			.Be("book");

		StoryLinkText.Buy.ToString()
			.Should()
			.Be("buy");

		StoryLinkText.Contact.ToString()
			.Should()
			.Be("contact");

		StoryLinkText.Enroll.ToString()
			.Should()
			.Be("enroll");

		StoryLinkText.Fill.ToString()
			.Should()
			.Be("fill");

		StoryLinkText.GoTo.ToString()
			.Should()
			.Be("go_to");

		StoryLinkText.Install.ToString()
			.Should()
			.Be("install");

		StoryLinkText.LearnMore.ToString()
			.Should()
			.Be("learn_more");

		StoryLinkText.More.ToString()
			.Should()
			.Be("more");

		StoryLinkText.Open.ToString()
			.Should()
			.Be("open");

		StoryLinkText.Order.ToString()
			.Should()
			.Be("order");

		StoryLinkText.Play.ToString()
			.Should()
			.Be("play");

		StoryLinkText.Read.ToString()
			.Should()
			.Be("read");

		StoryLinkText.Signup.ToString()
			.Should()
			.Be("signup");

		StoryLinkText.View.ToString()
			.Should()
			.Be("view");

		StoryLinkText.Vote.ToString()
			.Should()
			.Be("vote");

		StoryLinkText.Watch.ToString()
			.Should()
			.Be("watch");

		StoryLinkText.Write.ToString()
			.Should()
			.Be("write");

		// parse test
		StoryLinkText.FromJsonString("book")
			.Should()
			.Be(StoryLinkText.Book);

		StoryLinkText.FromJsonString("buy")
			.Should()
			.Be(StoryLinkText.Buy);

		StoryLinkText.FromJsonString("contact")
			.Should()
			.Be(StoryLinkText.Contact);

		StoryLinkText.FromJsonString("enroll")
			.Should()
			.Be(StoryLinkText.Enroll);

		StoryLinkText.FromJsonString("fill")
			.Should()
			.Be(StoryLinkText.Fill);

		StoryLinkText.FromJsonString("go_to")
			.Should()
			.Be(StoryLinkText.GoTo);

		StoryLinkText.FromJsonString("install")
			.Should()
			.Be(StoryLinkText.Install);

		StoryLinkText.FromJsonString("learn_more")
			.Should()
			.Be(StoryLinkText.LearnMore);

		StoryLinkText.FromJsonString("more")
			.Should()
			.Be(StoryLinkText.More);

		StoryLinkText.FromJsonString("open")
			.Should()
			.Be(StoryLinkText.Open);

		StoryLinkText.FromJsonString("order")
			.Should()
			.Be(StoryLinkText.Order);

		StoryLinkText.FromJsonString("play")
			.Should()
			.Be(StoryLinkText.Play);

		StoryLinkText.FromJsonString("read")
			.Should()
			.Be(StoryLinkText.Read);

		StoryLinkText.FromJsonString("signup")
			.Should()
			.Be(StoryLinkText.Signup);

		StoryLinkText.FromJsonString("view")
			.Should()
			.Be(StoryLinkText.View);

		StoryLinkText.FromJsonString("vote")
			.Should()
			.Be(StoryLinkText.Vote);

		StoryLinkText.FromJsonString("watch")
			.Should()
			.Be(StoryLinkText.Watch);

		StoryLinkText.FromJsonString("write")
			.Should()
			.Be(StoryLinkText.Write);
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

	[Fact]
	public void TranscriptStatesTest()
	{
		// get test
		TranscriptStates.Done.ToString()
			.Should()
			.Be("done");

		TranscriptStates.InProgress.ToString()
			.Should()
			.Be("in_progress");

		// parse test
		TranscriptStates.FromJsonString("done")
			.Should()
			.Be(TranscriptStates.Done);

		TranscriptStates.FromJsonString("in_progress")
			.Should()
			.Be(TranscriptStates.InProgress);
	}

	[Fact]
	public void MessageEventTypeTest()
	{
		// get test
		MessageEventType.OpenApp.ToString()
			.Should()
			.Be("open_app");

		MessageEventType.OpenLink.ToString()
			.Should()
			.Be("open_link");

		MessageEventType.SnowSnackbar.ToString()
			.Should()
			.Be("show_snackbar");

		// parse test
		MessageEventType.FromJsonString("open_app")
			.Should()
			.Be(MessageEventType.OpenApp);

		MessageEventType.FromJsonString("open_link")
			.Should()
			.Be(MessageEventType.OpenLink);

		MessageEventType.FromJsonString("show_snackbar")
			.Should()
			.Be(MessageEventType.SnowSnackbar);
	}
}