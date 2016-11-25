using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class SafetyEnumsTest
    {

		[Test]
        public void AppFilterTest()
        {
			// get test
			Assert.That(AppFilter.Installed.ToString(), Is.EqualTo("installed"));
			Assert.That(AppFilter.Featured.ToString(), Is.EqualTo("featured"));
			// parse test
			Assert.That(AppFilter.FromJson("installed"), Is.EqualTo(AppFilter.Installed));
			Assert.That(AppFilter.FromJson("featured"), Is.EqualTo(AppFilter.Featured));
		}

		[Test]
        public void AppPlatformsTest()
        {
			// get test
			Assert.That(AppPlatforms.Ios.ToString(), Is.EqualTo("ios"));
			Assert.That(AppPlatforms.Android.ToString(), Is.EqualTo("android"));
			Assert.That(AppPlatforms.WinPhone.ToString(), Is.EqualTo("winphone"));
			Assert.That(AppPlatforms.Web.ToString(), Is.EqualTo("web"));
			// parse test
			Assert.That(AppPlatforms.FromJson("ios"), Is.EqualTo(AppPlatforms.Ios));
			Assert.That(AppPlatforms.FromJson("android"), Is.EqualTo(AppPlatforms.Android));
			Assert.That(AppPlatforms.FromJson("winphone"), Is.EqualTo(AppPlatforms.WinPhone));
			Assert.That(AppPlatforms.FromJson("web"), Is.EqualTo(AppPlatforms.Web));
		}

		[Test]
        public void AppRatingTypeTest()
        {
			// get test
			Assert.That(AppRatingType.Level.ToString(), Is.EqualTo("level"));
			Assert.That(AppRatingType.Points.ToString(), Is.EqualTo("points"));
			// parse test
			Assert.That(AppRatingType.FromJson("level"), Is.EqualTo(AppRatingType.Level));
			Assert.That(AppRatingType.FromJson("points"), Is.EqualTo(AppRatingType.Points));
		}

		[Test]
        public void AppRequestTypeTest()
        {
			// get test
			Assert.That(AppRequestType.Invite.ToString(), Is.EqualTo("invite"));
			Assert.That(AppRequestType.Request.ToString(), Is.EqualTo("request"));
			// parse test
			Assert.That(AppRequestType.FromJson("invite"), Is.EqualTo(AppRequestType.Invite));
			Assert.That(AppRequestType.FromJson("request"), Is.EqualTo(AppRequestType.Request));
		}

		[Test]
        public void AppSortTest()
        {
			// get test
			Assert.That(AppSort.PopularToday.ToString(), Is.EqualTo("popular_today"));
			Assert.That(AppSort.Visitors.ToString(), Is.EqualTo("visitors"));
			Assert.That(AppSort.CreateDate.ToString(), Is.EqualTo("create_date"));
			Assert.That(AppSort.GrowthRate.ToString(), Is.EqualTo("growth_rate"));
			Assert.That(AppSort.PopularWeek.ToString(), Is.EqualTo("popular_week"));
			// parse test
			Assert.That(AppSort.FromJson("popular_today"), Is.EqualTo(AppSort.PopularToday));
			Assert.That(AppSort.FromJson("visitors"), Is.EqualTo(AppSort.Visitors));
			Assert.That(AppSort.FromJson("create_date"), Is.EqualTo(AppSort.CreateDate));
			Assert.That(AppSort.FromJson("growth_rate"), Is.EqualTo(AppSort.GrowthRate));
			Assert.That(AppSort.FromJson("popular_week"), Is.EqualTo(AppSort.PopularWeek));
		}

		[Test]
        public void ChangeNameStatusTest()
        {
			// get test
			Assert.That(ChangeNameStatus.Processing.ToString(), Is.EqualTo("processing"));
			Assert.That(ChangeNameStatus.Declined.ToString(), Is.EqualTo("declined"));
			Assert.That(ChangeNameStatus.Success.ToString(), Is.EqualTo("success"));
			Assert.That(ChangeNameStatus.WasAccepted.ToString(), Is.EqualTo("was_accepted"));
			Assert.That(ChangeNameStatus.WasDeclined.ToString(), Is.EqualTo("was_declined"));
			// parse test
			Assert.That(ChangeNameStatus.FromJson("processing"), Is.EqualTo(ChangeNameStatus.Processing));
			Assert.That(ChangeNameStatus.FromJson("declined"), Is.EqualTo(ChangeNameStatus.Declined));
			Assert.That(ChangeNameStatus.FromJson("success"), Is.EqualTo(ChangeNameStatus.Success));
			Assert.That(ChangeNameStatus.FromJson("was_accepted"), Is.EqualTo(ChangeNameStatus.WasAccepted));
			Assert.That(ChangeNameStatus.FromJson("was_declined"), Is.EqualTo(ChangeNameStatus.WasDeclined));
		}

		[Test]
        public void CommentObjectTypeTest()
        {
			// get test
			Assert.That(CommentObjectType.Post.ToString(), Is.EqualTo("post"));
			Assert.That(CommentObjectType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(CommentObjectType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(CommentObjectType.Topic.ToString(), Is.EqualTo("topic"));
			Assert.That(CommentObjectType.Note.ToString(), Is.EqualTo("note"));
			// parse test
			Assert.That(CommentObjectType.FromJson("post"), Is.EqualTo(CommentObjectType.Post));
			Assert.That(CommentObjectType.FromJson("photo"), Is.EqualTo(CommentObjectType.Photo));
			Assert.That(CommentObjectType.FromJson("video"), Is.EqualTo(CommentObjectType.Video));
			Assert.That(CommentObjectType.FromJson("topic"), Is.EqualTo(CommentObjectType.Topic));
			Assert.That(CommentObjectType.FromJson("note"), Is.EqualTo(CommentObjectType.Note));
		}

		[Test]
        public void CommentsSortTest()
        {
			// get test
			Assert.That(CommentsSort.Asc.ToString(), Is.EqualTo("asc"));
			Assert.That(CommentsSort.Desc.ToString(), Is.EqualTo("desc"));
			// parse test
			Assert.That(CommentsSort.FromJson("asc"), Is.EqualTo(CommentsSort.Asc));
			Assert.That(CommentsSort.FromJson("desc"), Is.EqualTo(CommentsSort.Desc));
		}

		[Test]
        public void DeactivatedTest()
        {
			// get test
			Assert.That(Deactivated.Deleted.ToString(), Is.EqualTo("deleted"));
			Assert.That(Deactivated.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(Deactivated.Activated.ToString(), Is.EqualTo("activated"));
			// parse test
			Assert.That(Deactivated.FromJson("deleted"), Is.EqualTo(Deactivated.Deleted));
			Assert.That(Deactivated.FromJson("banned"), Is.EqualTo(Deactivated.Banned));
			Assert.That(Deactivated.FromJson("activated"), Is.EqualTo(Deactivated.Activated));
		}

		[Test]
        public void DisplayTest()
        {
			// get test
			Assert.That(Display.Page.ToString(), Is.EqualTo("page"));
			Assert.That(Display.Popup.ToString(), Is.EqualTo("popup"));
			Assert.That(Display.Wap.ToString(), Is.EqualTo("wap"));
			// parse test
			Assert.That(Display.FromJson("page"), Is.EqualTo(Display.Page));
			Assert.That(Display.FromJson("popup"), Is.EqualTo(Display.Popup));
			Assert.That(Display.FromJson("wap"), Is.EqualTo(Display.Wap));
		}

		[Test]
        public void FeedTypeTest()
        {
			// get test
			Assert.That(FeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(FeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			// parse test
			Assert.That(FeedType.FromJson("photo"), Is.EqualTo(FeedType.Photo));
			Assert.That(FeedType.FromJson("photo_tag"), Is.EqualTo(FeedType.PhotoTag));
		}

		[Test]
        public void FriendsFilterTest()
        {
			// get test
			Assert.That(FriendsFilter.Mutual.ToString(), Is.EqualTo("mutual"));
			Assert.That(FriendsFilter.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(FriendsFilter.MutualContacts.ToString(), Is.EqualTo("mutual_contacts"));
			// parse test
			Assert.That(FriendsFilter.FromJson("mutual"), Is.EqualTo(FriendsFilter.Mutual));
			Assert.That(FriendsFilter.FromJson("contacts"), Is.EqualTo(FriendsFilter.Contacts));
			Assert.That(FriendsFilter.FromJson("mutual_contacts"), Is.EqualTo(FriendsFilter.MutualContacts));
		}

		[Test]
        public void FriendsOrderTest()
        {
			// get test
			Assert.That(FriendsOrder.Name.ToString(), Is.EqualTo("name"));
			Assert.That(FriendsOrder.Hints.ToString(), Is.EqualTo("hints"));
			Assert.That(FriendsOrder.Random.ToString(), Is.EqualTo("random"));
			// parse test
			Assert.That(FriendsOrder.FromJson("name"), Is.EqualTo(FriendsOrder.Name));
			Assert.That(FriendsOrder.FromJson("hints"), Is.EqualTo(FriendsOrder.Hints));
			Assert.That(FriendsOrder.FromJson("random"), Is.EqualTo(FriendsOrder.Random));
		}

		[Test]
        public void GroupsSortTest()
        {
			// get test
			Assert.That(GroupsSort.IdAsc.ToString(), Is.EqualTo("id_asc"));
			Assert.That(GroupsSort.IdDesc.ToString(), Is.EqualTo("id_desc"));
			Assert.That(GroupsSort.TimeAsc.ToString(), Is.EqualTo("time_asc"));
			Assert.That(GroupsSort.TimeDesc.ToString(), Is.EqualTo("time_desc"));
			// parse test
			Assert.That(GroupsSort.FromJson("id_asc"), Is.EqualTo(GroupsSort.IdAsc));
			Assert.That(GroupsSort.FromJson("id_desc"), Is.EqualTo(GroupsSort.IdDesc));
			Assert.That(GroupsSort.FromJson("time_asc"), Is.EqualTo(GroupsSort.TimeAsc));
			Assert.That(GroupsSort.FromJson("time_desc"), Is.EqualTo(GroupsSort.TimeDesc));
		}

		[Test]
        public void GroupTypeTest()
        {
			// get test
			Assert.That(GroupType.Page.ToString(), Is.EqualTo("page"));
			Assert.That(GroupType.Group.ToString(), Is.EqualTo("group"));
			Assert.That(GroupType.Event.ToString(), Is.EqualTo("event"));
			Assert.That(GroupType.Undefined.ToString(), Is.EqualTo("undefined"));
			// parse test
			Assert.That(GroupType.FromJson("page"), Is.EqualTo(GroupType.Page));
			Assert.That(GroupType.FromJson("group"), Is.EqualTo(GroupType.Group));
			Assert.That(GroupType.FromJson("event"), Is.EqualTo(GroupType.Event));
			Assert.That(GroupType.FromJson("undefined"), Is.EqualTo(GroupType.Undefined));
		}

		[Test]
        public void LikeObjectTypeTest()
        {
			// get test
			Assert.That(LikeObjectType.Post.ToString(), Is.EqualTo("post"));
			Assert.That(LikeObjectType.Comment.ToString(), Is.EqualTo("comment"));
			Assert.That(LikeObjectType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(LikeObjectType.Audio.ToString(), Is.EqualTo("audio"));
			Assert.That(LikeObjectType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(LikeObjectType.Note.ToString(), Is.EqualTo("note"));
			Assert.That(LikeObjectType.PhotoComment.ToString(), Is.EqualTo("photo_comment"));
			Assert.That(LikeObjectType.VideoComment.ToString(), Is.EqualTo("video_comment"));
			Assert.That(LikeObjectType.TopicComment.ToString(), Is.EqualTo("topic_comment"));
			Assert.That(LikeObjectType.SitePage.ToString(), Is.EqualTo("sitepage"));
			Assert.That(LikeObjectType.Market.ToString(), Is.EqualTo("market"));
			Assert.That(LikeObjectType.MarketComment.ToString(), Is.EqualTo("market_comment"));
			// parse test
			Assert.That(LikeObjectType.FromJson("post"), Is.EqualTo(LikeObjectType.Post));
			Assert.That(LikeObjectType.FromJson("comment"), Is.EqualTo(LikeObjectType.Comment));
			Assert.That(LikeObjectType.FromJson("photo"), Is.EqualTo(LikeObjectType.Photo));
			Assert.That(LikeObjectType.FromJson("audio"), Is.EqualTo(LikeObjectType.Audio));
			Assert.That(LikeObjectType.FromJson("video"), Is.EqualTo(LikeObjectType.Video));
			Assert.That(LikeObjectType.FromJson("note"), Is.EqualTo(LikeObjectType.Note));
			Assert.That(LikeObjectType.FromJson("photo_comment"), Is.EqualTo(LikeObjectType.PhotoComment));
			Assert.That(LikeObjectType.FromJson("video_comment"), Is.EqualTo(LikeObjectType.VideoComment));
			Assert.That(LikeObjectType.FromJson("topic_comment"), Is.EqualTo(LikeObjectType.TopicComment));
			Assert.That(LikeObjectType.FromJson("sitepage"), Is.EqualTo(LikeObjectType.SitePage));
			Assert.That(LikeObjectType.FromJson("market"), Is.EqualTo(LikeObjectType.Market));
			Assert.That(LikeObjectType.FromJson("market_comment"), Is.EqualTo(LikeObjectType.MarketComment));
		}

		[Test]
        public void LikesFilterTest()
        {
			// get test
			Assert.That(LikesFilter.Likes.ToString(), Is.EqualTo("likes"));
			Assert.That(LikesFilter.Copies.ToString(), Is.EqualTo("copies"));
			// parse test
			Assert.That(LikesFilter.FromJson("likes"), Is.EqualTo(LikesFilter.Likes));
			Assert.That(LikesFilter.FromJson("copies"), Is.EqualTo(LikesFilter.Copies));
		}

		[Test]
        public void LinkAccessTypeTest()
        {
			// get test
			Assert.That(LinkAccessType.NotBanned.ToString(), Is.EqualTo("not_banned"));
			Assert.That(LinkAccessType.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(LinkAccessType.Processing.ToString(), Is.EqualTo("processing"));
			// parse test
			Assert.That(LinkAccessType.FromJson("not_banned"), Is.EqualTo(LinkAccessType.NotBanned));
			Assert.That(LinkAccessType.FromJson("banned"), Is.EqualTo(LinkAccessType.Banned));
			Assert.That(LinkAccessType.FromJson("processing"), Is.EqualTo(LinkAccessType.Processing));
		}

		[Test]
        public void MediaTypeTest()
        {
			// get test
			Assert.That(MediaType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(MediaType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(MediaType.Audio.ToString(), Is.EqualTo("audio"));
			Assert.That(MediaType.Doc.ToString(), Is.EqualTo("doc"));
			Assert.That(MediaType.Link.ToString(), Is.EqualTo("link"));
			Assert.That(MediaType.Market.ToString(), Is.EqualTo("market"));
			Assert.That(MediaType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(MediaType.Share.ToString(), Is.EqualTo("share"));
			// parse test
			Assert.That(MediaType.FromJson("photo"), Is.EqualTo(MediaType.Photo));
			Assert.That(MediaType.FromJson("video"), Is.EqualTo(MediaType.Video));
			Assert.That(MediaType.FromJson("audio"), Is.EqualTo(MediaType.Audio));
			Assert.That(MediaType.FromJson("doc"), Is.EqualTo(MediaType.Doc));
			Assert.That(MediaType.FromJson("link"), Is.EqualTo(MediaType.Link));
			Assert.That(MediaType.FromJson("market"), Is.EqualTo(MediaType.Market));
			Assert.That(MediaType.FromJson("wall"), Is.EqualTo(MediaType.Wall));
			Assert.That(MediaType.FromJson("share"), Is.EqualTo(MediaType.Share));
		}

		[Test]
        public void NameCaseTest()
        {
			// get test
			Assert.That(NameCase.Nom.ToString(), Is.EqualTo("nom"));
			Assert.That(NameCase.Gen.ToString(), Is.EqualTo("gen"));
			Assert.That(NameCase.Dat.ToString(), Is.EqualTo("dat"));
			Assert.That(NameCase.Acc.ToString(), Is.EqualTo("acc"));
			Assert.That(NameCase.Ins.ToString(), Is.EqualTo("ins"));
			Assert.That(NameCase.Abl.ToString(), Is.EqualTo("abl"));
			// parse test
			Assert.That(NameCase.FromJson("nom"), Is.EqualTo(NameCase.Nom));
			Assert.That(NameCase.FromJson("gen"), Is.EqualTo(NameCase.Gen));
			Assert.That(NameCase.FromJson("dat"), Is.EqualTo(NameCase.Dat));
			Assert.That(NameCase.FromJson("acc"), Is.EqualTo(NameCase.Acc));
			Assert.That(NameCase.FromJson("ins"), Is.EqualTo(NameCase.Ins));
			Assert.That(NameCase.FromJson("abl"), Is.EqualTo(NameCase.Abl));
		}

		[Test]
        public void NewsObjectTypesTest()
        {
			// get test
			Assert.That(NewsObjectTypes.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(NewsObjectTypes.Tag.ToString(), Is.EqualTo("tag"));
			Assert.That(NewsObjectTypes.ProfilePhoto.ToString(), Is.EqualTo("profilephoto"));
			Assert.That(NewsObjectTypes.Video.ToString(), Is.EqualTo("video"));
			Assert.That(NewsObjectTypes.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(NewsObjectTypes.Audio.ToString(), Is.EqualTo("audio"));
			// parse test
			Assert.That(NewsObjectTypes.FromJson("wall"), Is.EqualTo(NewsObjectTypes.Wall));
			Assert.That(NewsObjectTypes.FromJson("tag"), Is.EqualTo(NewsObjectTypes.Tag));
			Assert.That(NewsObjectTypes.FromJson("profilephoto"), Is.EqualTo(NewsObjectTypes.ProfilePhoto));
			Assert.That(NewsObjectTypes.FromJson("video"), Is.EqualTo(NewsObjectTypes.Video));
			Assert.That(NewsObjectTypes.FromJson("photo"), Is.EqualTo(NewsObjectTypes.Photo));
			Assert.That(NewsObjectTypes.FromJson("audio"), Is.EqualTo(NewsObjectTypes.Audio));
		}

		[Test]
        public void NewsTypesTest()
        {
			// get test
			Assert.That(NewsTypes.Post.ToString(), Is.EqualTo("post"));
			Assert.That(NewsTypes.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(NewsTypes.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			Assert.That(NewsTypes.WallPhoto.ToString(), Is.EqualTo("wall_photo"));
			Assert.That(NewsTypes.Friend.ToString(), Is.EqualTo("friend"));
			Assert.That(NewsTypes.Note.ToString(), Is.EqualTo("note"));
			// parse test
			Assert.That(NewsTypes.FromJson("post"), Is.EqualTo(NewsTypes.Post));
			Assert.That(NewsTypes.FromJson("photo"), Is.EqualTo(NewsTypes.Photo));
			Assert.That(NewsTypes.FromJson("photo_tag"), Is.EqualTo(NewsTypes.PhotoTag));
			Assert.That(NewsTypes.FromJson("wall_photo"), Is.EqualTo(NewsTypes.WallPhoto));
			Assert.That(NewsTypes.FromJson("friend"), Is.EqualTo(NewsTypes.Friend));
			Assert.That(NewsTypes.FromJson("note"), Is.EqualTo(NewsTypes.Note));
		}

		[Test]
        public void OccupationTypeTest()
        {
			// get test
			Assert.That(OccupationType.Work.ToString(), Is.EqualTo("work"));
			Assert.That(OccupationType.School.ToString(), Is.EqualTo("school"));
			Assert.That(OccupationType.University.ToString(), Is.EqualTo("university"));
			// parse test
			Assert.That(OccupationType.FromJson("work"), Is.EqualTo(OccupationType.Work));
			Assert.That(OccupationType.FromJson("school"), Is.EqualTo(OccupationType.School));
			Assert.That(OccupationType.FromJson("university"), Is.EqualTo(OccupationType.University));
		}

		[Test]
        public void PhotoAlbumTypeTest()
        {
			// get test
			Assert.That(PhotoAlbumType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(PhotoAlbumType.Profile.ToString(), Is.EqualTo("profile"));
			Assert.That(PhotoAlbumType.Saved.ToString(), Is.EqualTo("saved"));
			// parse test
			Assert.That(PhotoAlbumType.FromJson("wall"), Is.EqualTo(PhotoAlbumType.Wall));
			Assert.That(PhotoAlbumType.FromJson("profile"), Is.EqualTo(PhotoAlbumType.Profile));
			Assert.That(PhotoAlbumType.FromJson("saved"), Is.EqualTo(PhotoAlbumType.Saved));
		}

		[Test]
        public void PhotoFeedTypeTest()
        {
			// get test
			Assert.That(PhotoFeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(PhotoFeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			// parse test
			Assert.That(PhotoFeedType.FromJson("photo"), Is.EqualTo(PhotoFeedType.Photo));
			Assert.That(PhotoFeedType.FromJson("photo_tag"), Is.EqualTo(PhotoFeedType.PhotoTag));
		}

		[Test]
        public void PhotoSearchRadiusTest()
        {
			// get test
			Assert.That(PhotoSearchRadius.Ten.ToString(), Is.EqualTo("10"));
			Assert.That(PhotoSearchRadius.OneHundred.ToString(), Is.EqualTo("100"));
			Assert.That(PhotoSearchRadius.Eighty.ToString(), Is.EqualTo("800"));
			Assert.That(PhotoSearchRadius.SixThousand.ToString(), Is.EqualTo("6000"));
			Assert.That(PhotoSearchRadius.FiftyThousand.ToString(), Is.EqualTo("50000"));
			// parse test
			Assert.That(PhotoSearchRadius.FromJson("10"), Is.EqualTo(PhotoSearchRadius.Ten));
			Assert.That(PhotoSearchRadius.FromJson("100"), Is.EqualTo(PhotoSearchRadius.OneHundred));
			Assert.That(PhotoSearchRadius.FromJson("800"), Is.EqualTo(PhotoSearchRadius.Eighty));
			Assert.That(PhotoSearchRadius.FromJson("6000"), Is.EqualTo(PhotoSearchRadius.SixThousand));
			Assert.That(PhotoSearchRadius.FromJson("50000"), Is.EqualTo(PhotoSearchRadius.FiftyThousand));
		}

		[Test]
        public void PhotoSizeTypeTest()
        {
			// get test
			Assert.That(PhotoSizeType.S.ToString(), Is.EqualTo("s"));
			Assert.That(PhotoSizeType.M.ToString(), Is.EqualTo("m"));
			Assert.That(PhotoSizeType.X.ToString(), Is.EqualTo("x"));
			Assert.That(PhotoSizeType.O.ToString(), Is.EqualTo("o"));
			Assert.That(PhotoSizeType.P.ToString(), Is.EqualTo("p"));
			Assert.That(PhotoSizeType.Q.ToString(), Is.EqualTo("q"));
			Assert.That(PhotoSizeType.R.ToString(), Is.EqualTo("r"));
			Assert.That(PhotoSizeType.Y.ToString(), Is.EqualTo("y"));
			Assert.That(PhotoSizeType.Z.ToString(), Is.EqualTo("z"));
			Assert.That(PhotoSizeType.W.ToString(), Is.EqualTo("w"));
			// parse test
			Assert.That(PhotoSizeType.FromJson("s"), Is.EqualTo(PhotoSizeType.S));
			Assert.That(PhotoSizeType.FromJson("m"), Is.EqualTo(PhotoSizeType.M));
			Assert.That(PhotoSizeType.FromJson("x"), Is.EqualTo(PhotoSizeType.X));
			Assert.That(PhotoSizeType.FromJson("o"), Is.EqualTo(PhotoSizeType.O));
			Assert.That(PhotoSizeType.FromJson("p"), Is.EqualTo(PhotoSizeType.P));
			Assert.That(PhotoSizeType.FromJson("q"), Is.EqualTo(PhotoSizeType.Q));
			Assert.That(PhotoSizeType.FromJson("r"), Is.EqualTo(PhotoSizeType.R));
			Assert.That(PhotoSizeType.FromJson("y"), Is.EqualTo(PhotoSizeType.Y));
			Assert.That(PhotoSizeType.FromJson("z"), Is.EqualTo(PhotoSizeType.Z));
			Assert.That(PhotoSizeType.FromJson("w"), Is.EqualTo(PhotoSizeType.W));
		}

		[Test]
        public void PlatformTest()
        {
			// get test
			Assert.That(Platform.Android.ToString(), Is.EqualTo("android"));
			Assert.That(Platform.IPhone.ToString(), Is.EqualTo("iphone"));
			Assert.That(Platform.WindowsPhone.ToString(), Is.EqualTo("wphone"));
			// parse test
			Assert.That(Platform.FromJson("android"), Is.EqualTo(Platform.Android));
			Assert.That(Platform.FromJson("iphone"), Is.EqualTo(Platform.IPhone));
			Assert.That(Platform.FromJson("wphone"), Is.EqualTo(Platform.WindowsPhone));
		}

		[Test]
        public void PostSourceTypeTest()
        {
			// get test
			Assert.That(PostSourceType.Vk.ToString(), Is.EqualTo("vk"));
			Assert.That(PostSourceType.Widget.ToString(), Is.EqualTo("widget"));
			Assert.That(PostSourceType.Api.ToString(), Is.EqualTo("api"));
			Assert.That(PostSourceType.Rss.ToString(), Is.EqualTo("rss"));
			Assert.That(PostSourceType.Sms.ToString(), Is.EqualTo("sms"));
			// parse test
			Assert.That(PostSourceType.FromJson("vk"), Is.EqualTo(PostSourceType.Vk));
			Assert.That(PostSourceType.FromJson("widget"), Is.EqualTo(PostSourceType.Widget));
			Assert.That(PostSourceType.FromJson("api"), Is.EqualTo(PostSourceType.Api));
			Assert.That(PostSourceType.FromJson("rss"), Is.EqualTo(PostSourceType.Rss));
			Assert.That(PostSourceType.FromJson("sms"), Is.EqualTo(PostSourceType.Sms));
		}

		[Test]
        public void PostTypeTest()
        {
			// get test
			Assert.That(PostType.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostType.Copy.ToString(), Is.EqualTo("copy"));
			Assert.That(PostType.Reply.ToString(), Is.EqualTo("reply"));
			Assert.That(PostType.Postpone.ToString(), Is.EqualTo("postpone"));
			Assert.That(PostType.Suggest.ToString(), Is.EqualTo("suggest"));
			// parse test
			Assert.That(PostType.FromJson("post"), Is.EqualTo(PostType.Post));
			Assert.That(PostType.FromJson("copy"), Is.EqualTo(PostType.Copy));
			Assert.That(PostType.FromJson("reply"), Is.EqualTo(PostType.Reply));
			Assert.That(PostType.FromJson("postpone"), Is.EqualTo(PostType.Postpone));
			Assert.That(PostType.FromJson("suggest"), Is.EqualTo(PostType.Suggest));
		}

		[Test]
        public void PostTypeOrderTest()
        {
			// get test
			Assert.That(PostTypeOrder.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostTypeOrder.Copy.ToString(), Is.EqualTo("copy"));
			// parse test
			Assert.That(PostTypeOrder.FromJson("post"), Is.EqualTo(PostTypeOrder.Post));
			Assert.That(PostTypeOrder.FromJson("copy"), Is.EqualTo(PostTypeOrder.Copy));
		}

		[Test]
        public void PrivacyTest()
        {
			// get test
			Assert.That(Privacy.All.ToString(), Is.EqualTo("all"));
			Assert.That(Privacy.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(Privacy.FriendsOfFriends.ToString(), Is.EqualTo("friends_of_friends"));
			Assert.That(Privacy.FriendsOfFriendsOnly.ToString(), Is.EqualTo("friends_of_friends_only"));
			Assert.That(Privacy.Nobody.ToString(), Is.EqualTo("nobody"));
			Assert.That(Privacy.OnlyMe.ToString(), Is.EqualTo("only_me"));
			// parse test
			Assert.That(Privacy.FromJson("all"), Is.EqualTo(Privacy.All));
			Assert.That(Privacy.FromJson("friends"), Is.EqualTo(Privacy.Friends));
			Assert.That(Privacy.FromJson("friends_of_friends"), Is.EqualTo(Privacy.FriendsOfFriends));
			Assert.That(Privacy.FromJson("friends_of_friends_only"), Is.EqualTo(Privacy.FriendsOfFriendsOnly));
			Assert.That(Privacy.FromJson("nobody"), Is.EqualTo(Privacy.Nobody));
			Assert.That(Privacy.FromJson("only_me"), Is.EqualTo(Privacy.OnlyMe));
		}

		[Test]
        public void RelativeTypeTest()
        {
			// get test
			Assert.That(RelativeType.Sibling.ToString(), Is.EqualTo("sibling"));
			Assert.That(RelativeType.Parent.ToString(), Is.EqualTo("parent"));
			Assert.That(RelativeType.Child.ToString(), Is.EqualTo("child"));
			Assert.That(RelativeType.Grandparent.ToString(), Is.EqualTo("grandparent"));
			Assert.That(RelativeType.Grandchild.ToString(), Is.EqualTo("grandchild"));
			// parse test
			Assert.That(RelativeType.FromJson("sibling"), Is.EqualTo(RelativeType.Sibling));
			Assert.That(RelativeType.FromJson("parent"), Is.EqualTo(RelativeType.Parent));
			Assert.That(RelativeType.FromJson("child"), Is.EqualTo(RelativeType.Child));
			Assert.That(RelativeType.FromJson("grandparent"), Is.EqualTo(RelativeType.Grandparent));
			Assert.That(RelativeType.FromJson("grandchild"), Is.EqualTo(RelativeType.Grandchild));
		}

		[Test]
        public void ReportTypeTest()
        {
			// get test
			Assert.That(ReportType.Porn.ToString(), Is.EqualTo("porn"));
			Assert.That(ReportType.Spam.ToString(), Is.EqualTo("spam"));
			Assert.That(ReportType.Insult.ToString(), Is.EqualTo("insult"));
			Assert.That(ReportType.Advertisment.ToString(), Is.EqualTo("advertisment"));
			// parse test
			Assert.That(ReportType.FromJson("porn"), Is.EqualTo(ReportType.Porn));
			Assert.That(ReportType.FromJson("spam"), Is.EqualTo(ReportType.Spam));
			Assert.That(ReportType.FromJson("insult"), Is.EqualTo(ReportType.Insult));
			Assert.That(ReportType.FromJson("advertisment"), Is.EqualTo(ReportType.Advertisment));
		}

		[Test]
        public void ServicesTest()
        {
			// get test
			Assert.That(Services.Email.ToString(), Is.EqualTo("email"));
			Assert.That(Services.Phone.ToString(), Is.EqualTo("phone"));
			Assert.That(Services.Twitter.ToString(), Is.EqualTo("twitter"));
			Assert.That(Services.Facebook.ToString(), Is.EqualTo("facebook"));
			Assert.That(Services.Odnoklassniki.ToString(), Is.EqualTo("odnoklassniki"));
			Assert.That(Services.Instagram.ToString(), Is.EqualTo("instagram"));
			Assert.That(Services.Google.ToString(), Is.EqualTo("google"));
			// parse test
			Assert.That(Services.FromJson("email"), Is.EqualTo(Services.Email));
			Assert.That(Services.FromJson("phone"), Is.EqualTo(Services.Phone));
			Assert.That(Services.FromJson("twitter"), Is.EqualTo(Services.Twitter));
			Assert.That(Services.FromJson("facebook"), Is.EqualTo(Services.Facebook));
			Assert.That(Services.FromJson("odnoklassniki"), Is.EqualTo(Services.Odnoklassniki));
			Assert.That(Services.FromJson("instagram"), Is.EqualTo(Services.Instagram));
			Assert.That(Services.FromJson("google"), Is.EqualTo(Services.Google));
		}

		[Test]
        public void UserSectionTest()
        {
			// get test
			Assert.That(UserSection.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(UserSection.Subscriptions.ToString(), Is.EqualTo("subscriptions"));
			// parse test
			Assert.That(UserSection.FromJson("friends"), Is.EqualTo(UserSection.Friends));
			Assert.That(UserSection.FromJson("subscriptions"), Is.EqualTo(UserSection.Subscriptions));
		}

		[Test]
        public void VideoCatalogItemTypeTest()
        {
			// get test
			Assert.That(VideoCatalogItemType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(VideoCatalogItemType.Album.ToString(), Is.EqualTo("album"));
			// parse test
			Assert.That(VideoCatalogItemType.FromJson("video"), Is.EqualTo(VideoCatalogItemType.Video));
			Assert.That(VideoCatalogItemType.FromJson("album"), Is.EqualTo(VideoCatalogItemType.Album));
		}

		[Test]
        public void VideoCatalogTypeTest()
        {
			// get test
			Assert.That(VideoCatalogType.Channel.ToString(), Is.EqualTo("channel"));
			Assert.That(VideoCatalogType.Category.ToString(), Is.EqualTo("category"));
			// parse test
			Assert.That(VideoCatalogType.FromJson("channel"), Is.EqualTo(VideoCatalogType.Channel));
			Assert.That(VideoCatalogType.FromJson("category"), Is.EqualTo(VideoCatalogType.Category));
		}

		[Test]
        public void WallFilterTest()
        {
			// get test
			Assert.That(WallFilter.Owner.ToString(), Is.EqualTo("owner"));
			Assert.That(WallFilter.Others.ToString(), Is.EqualTo("others"));
			Assert.That(WallFilter.All.ToString(), Is.EqualTo("all"));
			Assert.That(WallFilter.Suggests.ToString(), Is.EqualTo("suggests"));
			Assert.That(WallFilter.Postponed.ToString(), Is.EqualTo("postponed"));
			// parse test
			Assert.That(WallFilter.FromJson("owner"), Is.EqualTo(WallFilter.Owner));
			Assert.That(WallFilter.FromJson("others"), Is.EqualTo(WallFilter.Others));
			Assert.That(WallFilter.FromJson("all"), Is.EqualTo(WallFilter.All));
			Assert.That(WallFilter.FromJson("suggests"), Is.EqualTo(WallFilter.Suggests));
			Assert.That(WallFilter.FromJson("postponed"), Is.EqualTo(WallFilter.Postponed));
		}

	}
}

