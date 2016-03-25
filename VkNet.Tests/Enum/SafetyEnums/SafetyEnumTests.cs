using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
    public class SafetyEnumsTest
    {

		[Test]
        public void FeedTypeTest()
        {
			Assert.That(FeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(FeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
		}

		[Test]
        public void MediaTypeTest()
        {
			Assert.That(MediaType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(MediaType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(MediaType.Audio.ToString(), Is.EqualTo("audio"));
			Assert.That(MediaType.Doc.ToString(), Is.EqualTo("doc"));
			Assert.That(MediaType.Link.ToString(), Is.EqualTo("link"));
			Assert.That(MediaType.Market.ToString(), Is.EqualTo("market"));
			Assert.That(MediaType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(MediaType.Share.ToString(), Is.EqualTo("share"));
		}

		[Test]
        public void VideoCatalogItemTypeTest()
        {
			Assert.That(VideoCatalogItemType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(VideoCatalogItemType.Album.ToString(), Is.EqualTo("album"));
		}

		[Test]
        public void VideoCatalogTypeTest()
        {
			Assert.That(VideoCatalogType.Channel.ToString(), Is.EqualTo("channel"));
			Assert.That(VideoCatalogType.Category.ToString(), Is.EqualTo("category"));
		}

		[Test]
        public void PostTypeTest()
        {
			Assert.That(PostType.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostType.Copy.ToString(), Is.EqualTo("copy"));
			Assert.That(PostType.Reply.ToString(), Is.EqualTo("reply"));
			Assert.That(PostType.Postpone.ToString(), Is.EqualTo("postpone"));
			Assert.That(PostType.Suggest.ToString(), Is.EqualTo("suggest"));
		}

		[Test]
        public void FriendsFilterTest()
        {
			Assert.That(FriendsFilter.Mutual.ToString(), Is.EqualTo("mutual"));
			Assert.That(FriendsFilter.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(FriendsFilter.MutualContacts.ToString(), Is.EqualTo("mutual_contacts"));
		}

		[Test]
        public void DeactivatedTest()
        {
			Assert.That(Deactivated.Deleted.ToString(), Is.EqualTo("deleted"));
			Assert.That(Deactivated.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(Deactivated.Activated.ToString(), Is.EqualTo("activated"));
		}

		[Test]
        public void PlatformTest()
        {
			Assert.That(Platform.Android.ToString(), Is.EqualTo("android"));
			Assert.That(Platform.IPhone.ToString(), Is.EqualTo("iphone"));
			Assert.That(Platform.WindowsPhone.ToString(), Is.EqualTo("wphone"));
		}

		[Test]
        public void RelativeTypeTest()
        {
			Assert.That(RelativeType.Sibling.ToString(), Is.EqualTo("sibling"));
			Assert.That(RelativeType.Parent.ToString(), Is.EqualTo("parent"));
			Assert.That(RelativeType.Child.ToString(), Is.EqualTo("child"));
			Assert.That(RelativeType.Grandparent.ToString(), Is.EqualTo("grandparent"));
			Assert.That(RelativeType.Grandchild.ToString(), Is.EqualTo("grandchild"));
		}

		[Test]
        public void AppFilterTest()
        {
			Assert.That(AppFilter.Installed.ToString(), Is.EqualTo("installed"));
			Assert.That(AppFilter.Featured.ToString(), Is.EqualTo("featured"));
		}

		[Test]
        public void AppPlatformsTest()
        {
			Assert.That(AppPlatforms.Ios.ToString(), Is.EqualTo("ios"));
			Assert.That(AppPlatforms.Android.ToString(), Is.EqualTo("android"));
			Assert.That(AppPlatforms.WinPhone.ToString(), Is.EqualTo("winphone"));
			Assert.That(AppPlatforms.Web.ToString(), Is.EqualTo("web"));
		}

		[Test]
        public void AppRequestTypeTest()
        {
			Assert.That(AppRequestType.Invite.ToString(), Is.EqualTo("invite"));
			Assert.That(AppRequestType.Request.ToString(), Is.EqualTo("request"));
		}

		[Test]
        public void AppRatingTypeTest()
        {
			Assert.That(AppRatingType.Level.ToString(), Is.EqualTo("level"));
			Assert.That(AppRatingType.Points.ToString(), Is.EqualTo("points"));
		}

		[Test]
        public void CommentObjectTypeTest()
        {
			Assert.That(CommentObjectType.Post.ToString(), Is.EqualTo("post"));
			Assert.That(CommentObjectType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(CommentObjectType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(CommentObjectType.Topic.ToString(), Is.EqualTo("topic"));
			Assert.That(CommentObjectType.Note.ToString(), Is.EqualTo("note"));
		}

		[Test]
        public void PhotoSearchRadiusTest()
        {
			Assert.That(PhotoSearchRadius.Ten.ToString(), Is.EqualTo("10"));
			Assert.That(PhotoSearchRadius.OneHundred.ToString(), Is.EqualTo("100"));
			Assert.That(PhotoSearchRadius.Eighty.ToString(), Is.EqualTo("800"));
			Assert.That(PhotoSearchRadius.SixThousand.ToString(), Is.EqualTo("6000"));
			Assert.That(PhotoSearchRadius.FiftyThousand.ToString(), Is.EqualTo("50000"));
		}

		[Test]
        public void PhotoSizeTypeTest()
        {
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
		}

		[Test]
        public void NewsObjectTypesTest()
        {
			Assert.That(NewsObjectTypes.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(NewsObjectTypes.Tag.ToString(), Is.EqualTo("tag"));
			Assert.That(NewsObjectTypes.ProfilePhoto.ToString(), Is.EqualTo("profilephoto"));
			Assert.That(NewsObjectTypes.Video.ToString(), Is.EqualTo("video"));
			Assert.That(NewsObjectTypes.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(NewsObjectTypes.Audio.ToString(), Is.EqualTo("audio"));
		}

		[Test]
        public void LikesFilterTest()
        {
			Assert.That(LikesFilter.Likes.ToString(), Is.EqualTo("likes"));
			Assert.That(LikesFilter.Copies.ToString(), Is.EqualTo("copies"));
		}

		[Test]
        public void PostTypeOrderTest()
        {
			Assert.That(PostTypeOrder.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostTypeOrder.Copy.ToString(), Is.EqualTo("copy"));
		}

		[Test]
        public void AppSortTest()
        {
			Assert.That(AppSort.PopularToday.ToString(), Is.EqualTo("popular_today"));
			Assert.That(AppSort.Visitors.ToString(), Is.EqualTo("visitors"));
			Assert.That(AppSort.CreateDate.ToString(), Is.EqualTo("create_date"));
			Assert.That(AppSort.GrowthRate.ToString(), Is.EqualTo("growth_rate"));
			Assert.That(AppSort.PopularWeek.ToString(), Is.EqualTo("popular_week"));
		}

		[Test]
        public void PrivacyTest()
        {
			Assert.That(Privacy.All.ToString(), Is.EqualTo("all"));
			Assert.That(Privacy.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(Privacy.FriendsOfFriends.ToString(), Is.EqualTo("friends_of_friends"));
			Assert.That(Privacy.FriendsOfFriendsOnly.ToString(), Is.EqualTo("friends_of_friends_only"));
			Assert.That(Privacy.Nobody.ToString(), Is.EqualTo("nobody"));
			Assert.That(Privacy.OnlyMe.ToString(), Is.EqualTo("only_me"));
		}

		[Test]
        public void ChangeNameStatusTest()
        {
			Assert.That(ChangeNameStatus.Processing.ToString(), Is.EqualTo("processing"));
			Assert.That(ChangeNameStatus.Declined.ToString(), Is.EqualTo("declined"));
			Assert.That(ChangeNameStatus.Success.ToString(), Is.EqualTo("success"));
			Assert.That(ChangeNameStatus.WasAccepted.ToString(), Is.EqualTo("was_accepted"));
			Assert.That(ChangeNameStatus.WasDeclined.ToString(), Is.EqualTo("was_declined"));
		}

		[Test]
        public void ServicesTest()
        {
			Assert.That(Services.Email.ToString(), Is.EqualTo("email"));
			Assert.That(Services.Phone.ToString(), Is.EqualTo("phone"));
			Assert.That(Services.Twitter.ToString(), Is.EqualTo("twitter"));
			Assert.That(Services.Facebook.ToString(), Is.EqualTo("facebook"));
			Assert.That(Services.Odnoklassniki.ToString(), Is.EqualTo("odnoklassniki"));
			Assert.That(Services.Instagram.ToString(), Is.EqualTo("instagram"));
			Assert.That(Services.Google.ToString(), Is.EqualTo("google"));
		}

		[Test]
        public void UserSectionTest()
        {
			Assert.That(UserSection.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(UserSection.Subscriptions.ToString(), Is.EqualTo("subscriptions"));
		}

		[Test]
        public void NewsTypesTest()
        {
			Assert.That(NewsTypes.Post.ToString(), Is.EqualTo("post"));
			Assert.That(NewsTypes.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(NewsTypes.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			Assert.That(NewsTypes.WallPhoto.ToString(), Is.EqualTo("wall_photo"));
			Assert.That(NewsTypes.Friend.ToString(), Is.EqualTo("friend"));
			Assert.That(NewsTypes.Note.ToString(), Is.EqualTo("note"));
		}

		[Test]
        public void LikeObjectTypeTest()
        {
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
		}

		[Test]
        public void PhotoAlbumTypeTest()
        {
			Assert.That(PhotoAlbumType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(PhotoAlbumType.Profile.ToString(), Is.EqualTo("profile"));
			Assert.That(PhotoAlbumType.Saved.ToString(), Is.EqualTo("saved"));
		}

		[Test]
        public void PhotoFeedTypeTest()
        {
			Assert.That(PhotoFeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(PhotoFeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
		}

		[Test]
        public void WallFilterTest()
        {
			Assert.That(WallFilter.Owner.ToString(), Is.EqualTo("owner"));
			Assert.That(WallFilter.Others.ToString(), Is.EqualTo("others"));
			Assert.That(WallFilter.All.ToString(), Is.EqualTo("all"));
			Assert.That(WallFilter.Suggests.ToString(), Is.EqualTo("suggests"));
			Assert.That(WallFilter.Postponed.ToString(), Is.EqualTo("postponed"));
		}

		[Test]
        public void CommentsSortTest()
        {
			Assert.That(CommentsSort.Asc.ToString(), Is.EqualTo("asc"));
			Assert.That(CommentsSort.Desc.ToString(), Is.EqualTo("desc"));
		}

		[Test]
        public void DisplayTest()
        {
			Assert.That(Display.Page.ToString(), Is.EqualTo("page"));
			Assert.That(Display.Popup.ToString(), Is.EqualTo("popup"));
			Assert.That(Display.Wap.ToString(), Is.EqualTo("wap"));
		}

		[Test]
        public void GroupsSortTest()
        {
			Assert.That(GroupsSort.IdAsc.ToString(), Is.EqualTo("id_asc"));
			Assert.That(GroupsSort.IdDesc.ToString(), Is.EqualTo("id_desc"));
			Assert.That(GroupsSort.TimeAsc.ToString(), Is.EqualTo("time_asc"));
			Assert.That(GroupsSort.TimeDesc.ToString(), Is.EqualTo("time_desc"));
		}

		[Test]
        public void GroupTypeTest()
        {
			Assert.That(GroupType.Page.ToString(), Is.EqualTo("page"));
			Assert.That(GroupType.Group.ToString(), Is.EqualTo("group"));
			Assert.That(GroupType.Event.ToString(), Is.EqualTo("event"));
			Assert.That(GroupType.Undefined.ToString(), Is.EqualTo("undefined"));
		}

		[Test]
        public void LinkAccessTypeTest()
        {
			Assert.That(LinkAccessType.NotBanned.ToString(), Is.EqualTo("not_banned"));
			Assert.That(LinkAccessType.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(LinkAccessType.Processing.ToString(), Is.EqualTo("processing"));
		}

		[Test]
        public void FriendsOrderTest()
        {
			Assert.That(FriendsOrder.Name.ToString(), Is.EqualTo("name"));
			Assert.That(FriendsOrder.Hints.ToString(), Is.EqualTo("hints"));
			Assert.That(FriendsOrder.Random.ToString(), Is.EqualTo("random"));
		}

		[Test]
        public void NameCaseTest()
        {
			Assert.That(NameCase.Nom.ToString(), Is.EqualTo("nom"));
			Assert.That(NameCase.Gen.ToString(), Is.EqualTo("gen"));
			Assert.That(NameCase.Dat.ToString(), Is.EqualTo("dat"));
			Assert.That(NameCase.Acc.ToString(), Is.EqualTo("acc"));
			Assert.That(NameCase.Ins.ToString(), Is.EqualTo("ins"));
			Assert.That(NameCase.Abl.ToString(), Is.EqualTo("abl"));
		}

		[Test]
        public void ReportTypeTest()
        {
			Assert.That(ReportType.Porn.ToString(), Is.EqualTo("porn"));
			Assert.That(ReportType.Spam.ToString(), Is.EqualTo("spam"));
			Assert.That(ReportType.Insult.ToString(), Is.EqualTo("insult"));
			Assert.That(ReportType.Advertisment.ToString(), Is.EqualTo("advertisment"));
		}

		[Test]
        public void PostSourceTypeTest()
        {
			Assert.That(PostSourceType.Vk.ToString(), Is.EqualTo("vk"));
			Assert.That(PostSourceType.Widget.ToString(), Is.EqualTo("widget"));
			Assert.That(PostSourceType.Api.ToString(), Is.EqualTo("api"));
			Assert.That(PostSourceType.Rss.ToString(), Is.EqualTo("rss"));
			Assert.That(PostSourceType.Sms.ToString(), Is.EqualTo("sms"));
		}

		[Test]
        public void OccupationTypeTest()
        {
			Assert.That(OccupationType.Work.ToString(), Is.EqualTo("work"));
			Assert.That(OccupationType.School.ToString(), Is.EqualTo("school"));
			Assert.That(OccupationType.University.ToString(), Is.EqualTo("university"));
		}

	}
}

