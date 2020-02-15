using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Enum.SafetyEnums
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class SafetyEnumsTest
	{
		[Test]
		public void NullTest()
		{
			var result = AppFilter.FromJsonString("");

			Assert.That(result == null);
		}

		[Test]
		public void AppFilterTest()
		{
			// get test
			Assert.That(AppFilter.Installed.ToString(), Is.EqualTo("installed"));
			Assert.That(AppFilter.Featured.ToString(), Is.EqualTo("featured"));

			// parse test
			Assert.That(AppFilter.FromJsonString("installed"), Is.EqualTo(AppFilter.Installed));
			Assert.That(AppFilter.FromJsonString("featured"), Is.EqualTo(AppFilter.Featured));
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
			Assert.That(AppPlatforms.FromJsonString("ios"), Is.EqualTo(AppPlatforms.Ios));
			Assert.That(AppPlatforms.FromJsonString("android"), Is.EqualTo(AppPlatforms.Android));
			Assert.That(AppPlatforms.FromJsonString("winphone"), Is.EqualTo(AppPlatforms.WinPhone));
			Assert.That(AppPlatforms.FromJsonString("web"), Is.EqualTo(AppPlatforms.Web));
		}

		[Test]
		public void AppRatingTypeTest()
		{
			// get test
			Assert.That(AppRatingType.Level.ToString(), Is.EqualTo("level"));
			Assert.That(AppRatingType.Points.ToString(), Is.EqualTo("points"));

			// parse test
			Assert.That(AppRatingType.FromJsonString("level"), Is.EqualTo(AppRatingType.Level));
			Assert.That(AppRatingType.FromJsonString("points"), Is.EqualTo(AppRatingType.Points));
		}

		[Test]
		public void AppRequestTypeTest()
		{
			// get test
			Assert.That(AppRequestType.Invite.ToString(), Is.EqualTo("invite"));
			Assert.That(AppRequestType.Request.ToString(), Is.EqualTo("request"));

			// parse test
			Assert.That(AppRequestType.FromJsonString("invite"), Is.EqualTo(AppRequestType.Invite));

			Assert.That(AppRequestType.FromJsonString("request")
					, Is.EqualTo(AppRequestType.Request));
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
			Assert.That(AppSort.FromJsonString("popular_today"), Is.EqualTo(AppSort.PopularToday));
			Assert.That(AppSort.FromJsonString("visitors"), Is.EqualTo(AppSort.Visitors));
			Assert.That(AppSort.FromJsonString("create_date"), Is.EqualTo(AppSort.CreateDate));
			Assert.That(AppSort.FromJsonString("growth_rate"), Is.EqualTo(AppSort.GrowthRate));
			Assert.That(AppSort.FromJsonString("popular_week"), Is.EqualTo(AppSort.PopularWeek));
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
			Assert.That(ChangeNameStatus.FromJsonString("processing")
					, Is.EqualTo(ChangeNameStatus.Processing));

			Assert.That(ChangeNameStatus.FromJsonString("declined")
					, Is.EqualTo(ChangeNameStatus.Declined));

			Assert.That(ChangeNameStatus.FromJsonString("success")
					, Is.EqualTo(ChangeNameStatus.Success));

			Assert.That(ChangeNameStatus.FromJsonString("was_accepted")
					, Is.EqualTo(ChangeNameStatus.WasAccepted));

			Assert.That(ChangeNameStatus.FromJsonString("was_declined")
					, Is.EqualTo(ChangeNameStatus.WasDeclined));
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
			Assert.That(CommentObjectType.FromJsonString("post")
					, Is.EqualTo(CommentObjectType.Post));

			Assert.That(CommentObjectType.FromJsonString("photo")
					, Is.EqualTo(CommentObjectType.Photo));

			Assert.That(CommentObjectType.FromJsonString("video")
					, Is.EqualTo(CommentObjectType.Video));

			Assert.That(CommentObjectType.FromJsonString("topic")
					, Is.EqualTo(CommentObjectType.Topic));

			Assert.That(CommentObjectType.FromJsonString("note")
					, Is.EqualTo(CommentObjectType.Note));
		}

		[Test]
		public void CommentsSortTest()
		{
			// get test
			Assert.That(CommentsSort.Asc.ToString(), Is.EqualTo("asc"));
			Assert.That(CommentsSort.Desc.ToString(), Is.EqualTo("desc"));

			// parse test
			Assert.That(CommentsSort.FromJsonString("asc"), Is.EqualTo(CommentsSort.Asc));
			Assert.That(CommentsSort.FromJsonString("desc"), Is.EqualTo(CommentsSort.Desc));
		}

		[Test]
		public void DeactivatedTest()
		{
			// get test
			Assert.That(Deactivated.Deleted.ToString(), Is.EqualTo("deleted"));
			Assert.That(Deactivated.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(Deactivated.Activated.ToString(), Is.EqualTo("activated"));

			// parse test
			Assert.That(Deactivated.FromJsonString("deleted"), Is.EqualTo(Deactivated.Deleted));
			Assert.That(Deactivated.FromJsonString("banned"), Is.EqualTo(Deactivated.Banned));
			Assert.That(Deactivated.FromJsonString("activated"), Is.EqualTo(Deactivated.Activated));
		}

		[Test]
		public void DisplayTest()
		{
			// get test
			Assert.That(Display.Page.ToString(), Is.EqualTo("page"));
			Assert.That(Display.Popup.ToString(), Is.EqualTo("popup"));
			Assert.That(Display.Mobile.ToString(), Is.EqualTo("mobile"));

			// parse test
			Assert.That(Display.FromJsonString("page"), Is.EqualTo(Display.Page));
			Assert.That(Display.FromJsonString("popup"), Is.EqualTo(Display.Popup));
			Assert.That(Display.FromJsonString("mobile"), Is.EqualTo(Display.Mobile));
		}

		[Test]
		public void FeedTypeTest()
		{
			// get test
			Assert.That(FeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(FeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));

			// parse test
			Assert.That(FeedType.FromJsonString("photo"), Is.EqualTo(FeedType.Photo));
			Assert.That(FeedType.FromJsonString("photo_tag"), Is.EqualTo(FeedType.PhotoTag));
		}

		[Test]
		public void FriendsFilterTest()
		{
			// get test
			Assert.That(FriendsFilter.Mutual.ToString(), Is.EqualTo("mutual"));
			Assert.That(FriendsFilter.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(FriendsFilter.MutualContacts.ToString(), Is.EqualTo("mutual_contacts"));

			// parse test
			Assert.That(FriendsFilter.FromJsonString("mutual"), Is.EqualTo(FriendsFilter.Mutual));

			Assert.That(FriendsFilter.FromJsonString("contacts")
					, Is.EqualTo(FriendsFilter.Contacts));

			Assert.That(FriendsFilter.FromJsonString("mutual_contacts")
					, Is.EqualTo(FriendsFilter.MutualContacts));
		}

		[Test]
		public void FriendsOrderTest()
		{
			// get test
			Assert.That(FriendsOrder.Name.ToString(), Is.EqualTo("name"));
			Assert.That(FriendsOrder.Hints.ToString(), Is.EqualTo("hints"));
			Assert.That(FriendsOrder.Random.ToString(), Is.EqualTo("random"));

			// parse test
			Assert.That(FriendsOrder.FromJsonString("name"), Is.EqualTo(FriendsOrder.Name));
			Assert.That(FriendsOrder.FromJsonString("hints"), Is.EqualTo(FriendsOrder.Hints));
			Assert.That(FriendsOrder.FromJsonString("random"), Is.EqualTo(FriendsOrder.Random));
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
			Assert.That(GroupsSort.FromJsonString("id_asc"), Is.EqualTo(GroupsSort.IdAsc));
			Assert.That(GroupsSort.FromJsonString("id_desc"), Is.EqualTo(GroupsSort.IdDesc));
			Assert.That(GroupsSort.FromJsonString("time_asc"), Is.EqualTo(GroupsSort.TimeAsc));
			Assert.That(GroupsSort.FromJsonString("time_desc"), Is.EqualTo(GroupsSort.TimeDesc));
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
			Assert.That(GroupType.FromJsonString("page"), Is.EqualTo(GroupType.Page));
			Assert.That(GroupType.FromJsonString("group"), Is.EqualTo(GroupType.Group));
			Assert.That(GroupType.FromJsonString("event"), Is.EqualTo(GroupType.Event));
			Assert.That(GroupType.FromJsonString("undefined"), Is.EqualTo(GroupType.Undefined));
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
			Assert.That(LikeObjectType.FromJsonString("post"), Is.EqualTo(LikeObjectType.Post));

			Assert.That(LikeObjectType.FromJsonString("comment")
					, Is.EqualTo(LikeObjectType.Comment));

			Assert.That(LikeObjectType.FromJsonString("photo"), Is.EqualTo(LikeObjectType.Photo));
			Assert.That(LikeObjectType.FromJsonString("audio"), Is.EqualTo(LikeObjectType.Audio));
			Assert.That(LikeObjectType.FromJsonString("video"), Is.EqualTo(LikeObjectType.Video));
			Assert.That(LikeObjectType.FromJsonString("note"), Is.EqualTo(LikeObjectType.Note));

			Assert.That(LikeObjectType.FromJsonString("photo_comment")
					, Is.EqualTo(LikeObjectType.PhotoComment));

			Assert.That(LikeObjectType.FromJsonString("video_comment")
					, Is.EqualTo(LikeObjectType.VideoComment));

			Assert.That(LikeObjectType.FromJsonString("topic_comment")
					, Is.EqualTo(LikeObjectType.TopicComment));

			Assert.That(LikeObjectType.FromJsonString("sitepage")
					, Is.EqualTo(LikeObjectType.SitePage));

			Assert.That(LikeObjectType.FromJsonString("market"), Is.EqualTo(LikeObjectType.Market));

			Assert.That(LikeObjectType.FromJsonString("market_comment")
					, Is.EqualTo(LikeObjectType.MarketComment));
		}

		[Test]
		public void LikesFilterTest()
		{
			// get test
			Assert.That(LikesFilter.Likes.ToString(), Is.EqualTo("likes"));
			Assert.That(LikesFilter.Copies.ToString(), Is.EqualTo("copies"));

			// parse test
			Assert.That(LikesFilter.FromJsonString("likes"), Is.EqualTo(LikesFilter.Likes));
			Assert.That(LikesFilter.FromJsonString("copies"), Is.EqualTo(LikesFilter.Copies));
		}

		[Test]
		public void LinkAccessTypeTest()
		{
			// get test
			Assert.That(LinkAccessType.NotBanned.ToString(), Is.EqualTo("not_banned"));
			Assert.That(LinkAccessType.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(LinkAccessType.Processing.ToString(), Is.EqualTo("processing"));

			// parse test
			Assert.That(LinkAccessType.FromJsonString("not_banned")
					, Is.EqualTo(LinkAccessType.NotBanned));

			Assert.That(LinkAccessType.FromJsonString("banned"), Is.EqualTo(LinkAccessType.Banned));

			Assert.That(LinkAccessType.FromJsonString("processing")
					, Is.EqualTo(LinkAccessType.Processing));
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
			Assert.That(MediaType.Graffiti.ToString(), Is.EqualTo("graffiti"));

			// parse test
			Assert.That(MediaType.FromJsonString("photo"), Is.EqualTo(MediaType.Photo));
			Assert.That(MediaType.FromJsonString("video"), Is.EqualTo(MediaType.Video));
			Assert.That(MediaType.FromJsonString("audio"), Is.EqualTo(MediaType.Audio));
			Assert.That(MediaType.FromJsonString("doc"), Is.EqualTo(MediaType.Doc));
			Assert.That(MediaType.FromJsonString("link"), Is.EqualTo(MediaType.Link));
			Assert.That(MediaType.FromJsonString("market"), Is.EqualTo(MediaType.Market));
			Assert.That(MediaType.FromJsonString("wall"), Is.EqualTo(MediaType.Wall));
			Assert.That(MediaType.FromJsonString("share"), Is.EqualTo(MediaType.Share));
			Assert.That(MediaType.FromJsonString("graffiti"), Is.EqualTo(MediaType.Graffiti));
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
			Assert.That(NameCase.FromJsonString("nom"), Is.EqualTo(NameCase.Nom));
			Assert.That(NameCase.FromJsonString("gen"), Is.EqualTo(NameCase.Gen));
			Assert.That(NameCase.FromJsonString("dat"), Is.EqualTo(NameCase.Dat));
			Assert.That(NameCase.FromJsonString("acc"), Is.EqualTo(NameCase.Acc));
			Assert.That(NameCase.FromJsonString("ins"), Is.EqualTo(NameCase.Ins));
			Assert.That(NameCase.FromJsonString("abl"), Is.EqualTo(NameCase.Abl));
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
			Assert.That(NewsObjectTypes.FromJsonString("wall"), Is.EqualTo(NewsObjectTypes.Wall));
			Assert.That(NewsObjectTypes.FromJsonString("tag"), Is.EqualTo(NewsObjectTypes.Tag));

			Assert.That(NewsObjectTypes.FromJsonString("profilephoto")
					, Is.EqualTo(NewsObjectTypes.ProfilePhoto));

			Assert.That(NewsObjectTypes.FromJsonString("video"), Is.EqualTo(NewsObjectTypes.Video));
			Assert.That(NewsObjectTypes.FromJsonString("photo"), Is.EqualTo(NewsObjectTypes.Photo));
			Assert.That(NewsObjectTypes.FromJsonString("audio"), Is.EqualTo(NewsObjectTypes.Audio));
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
			Assert.That(NewsTypes.FromJsonString("post"), Is.EqualTo(NewsTypes.Post));
			Assert.That(NewsTypes.FromJsonString("photo"), Is.EqualTo(NewsTypes.Photo));
			Assert.That(NewsTypes.FromJsonString("photo_tag"), Is.EqualTo(NewsTypes.PhotoTag));
			Assert.That(NewsTypes.FromJsonString("wall_photo"), Is.EqualTo(NewsTypes.WallPhoto));
			Assert.That(NewsTypes.FromJsonString("friend"), Is.EqualTo(NewsTypes.Friend));
			Assert.That(NewsTypes.FromJsonString("note"), Is.EqualTo(NewsTypes.Note));
		}

		[Test]
		public void OccupationTypeTest()
		{
			// get test
			Assert.That(OccupationType.Work.ToString(), Is.EqualTo("work"));
			Assert.That(OccupationType.School.ToString(), Is.EqualTo("school"));
			Assert.That(OccupationType.University.ToString(), Is.EqualTo("university"));

			// parse test
			Assert.That(OccupationType.FromJsonString("work"), Is.EqualTo(OccupationType.Work));
			Assert.That(OccupationType.FromJsonString("school"), Is.EqualTo(OccupationType.School));

			Assert.That(OccupationType.FromJsonString("university")
					, Is.EqualTo(OccupationType.University));
		}

		[Test]
		public void PhotoAlbumTypeTest()
		{
			// get test
			Assert.That(PhotoAlbumType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(PhotoAlbumType.Profile.ToString(), Is.EqualTo("profile"));
			Assert.That(PhotoAlbumType.Saved.ToString(), Is.EqualTo("saved"));

			// parse test
			Assert.That(PhotoAlbumType.FromJsonString("wall"), Is.EqualTo(PhotoAlbumType.Wall));

			Assert.That(PhotoAlbumType.FromJsonString("profile")
					, Is.EqualTo(PhotoAlbumType.Profile));

			Assert.That(PhotoAlbumType.FromJsonString("saved"), Is.EqualTo(PhotoAlbumType.Saved));
		}

		[Test]
		public void PhotoFeedTypeTest()
		{
			// get test
			Assert.That(PhotoFeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(PhotoFeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));

			// parse test
			Assert.That(PhotoFeedType.FromJsonString("photo"), Is.EqualTo(PhotoFeedType.Photo));

			Assert.That(PhotoFeedType.FromJsonString("photo_tag")
					, Is.EqualTo(PhotoFeedType.PhotoTag));
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
			Assert.That(PhotoSearchRadius.FromJsonString("10"), Is.EqualTo(PhotoSearchRadius.Ten));

			Assert.That(PhotoSearchRadius.FromJsonString("100")
					, Is.EqualTo(PhotoSearchRadius.OneHundred));

			Assert.That(PhotoSearchRadius.FromJsonString("800")
					, Is.EqualTo(PhotoSearchRadius.Eighty));

			Assert.That(PhotoSearchRadius.FromJsonString("6000")
					, Is.EqualTo(PhotoSearchRadius.SixThousand));

			Assert.That(PhotoSearchRadius.FromJsonString("50000")
					, Is.EqualTo(PhotoSearchRadius.FiftyThousand));
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
			Assert.That(PhotoSizeType.FromJsonString("s"), Is.EqualTo(PhotoSizeType.S));
			Assert.That(PhotoSizeType.FromJsonString("m"), Is.EqualTo(PhotoSizeType.M));
			Assert.That(PhotoSizeType.FromJsonString("x"), Is.EqualTo(PhotoSizeType.X));
			Assert.That(PhotoSizeType.FromJsonString("o"), Is.EqualTo(PhotoSizeType.O));
			Assert.That(PhotoSizeType.FromJsonString("p"), Is.EqualTo(PhotoSizeType.P));
			Assert.That(PhotoSizeType.FromJsonString("q"), Is.EqualTo(PhotoSizeType.Q));
			Assert.That(PhotoSizeType.FromJsonString("r"), Is.EqualTo(PhotoSizeType.R));
			Assert.That(PhotoSizeType.FromJsonString("y"), Is.EqualTo(PhotoSizeType.Y));
			Assert.That(PhotoSizeType.FromJsonString("z"), Is.EqualTo(PhotoSizeType.Z));
			Assert.That(PhotoSizeType.FromJsonString("w"), Is.EqualTo(PhotoSizeType.W));
		}

		[Test]
		public void PlatformTest()
		{
			// get test
			Assert.That(Platform.Android.ToString(), Is.EqualTo("android"));
			Assert.That(Platform.IPhone.ToString(), Is.EqualTo("iphone"));
			Assert.That(Platform.WindowsPhone.ToString(), Is.EqualTo("wphone"));

			// parse test
			Assert.That(Platform.FromJsonString("android"), Is.EqualTo(Platform.Android));
			Assert.That(Platform.FromJsonString("iphone"), Is.EqualTo(Platform.IPhone));
			Assert.That(Platform.FromJsonString("wphone"), Is.EqualTo(Platform.WindowsPhone));
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
			Assert.That(PostSourceType.FromJsonString("vk"), Is.EqualTo(PostSourceType.Vk));
			Assert.That(PostSourceType.FromJsonString("widget"), Is.EqualTo(PostSourceType.Widget));
			Assert.That(PostSourceType.FromJsonString("api"), Is.EqualTo(PostSourceType.Api));
			Assert.That(PostSourceType.FromJsonString("rss"), Is.EqualTo(PostSourceType.Rss));
			Assert.That(PostSourceType.FromJsonString("sms"), Is.EqualTo(PostSourceType.Sms));
		}

		[Test]
		public void PostTypeOrderTest()
		{
			// get test
			Assert.That(PostTypeOrder.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostTypeOrder.Copy.ToString(), Is.EqualTo("copy"));

			// parse test
			Assert.That(PostTypeOrder.FromJsonString("post"), Is.EqualTo(PostTypeOrder.Post));
			Assert.That(PostTypeOrder.FromJsonString("copy"), Is.EqualTo(PostTypeOrder.Copy));
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
			Assert.That(PostType.FromJsonString("post"), Is.EqualTo(PostType.Post));
			Assert.That(PostType.FromJsonString("copy"), Is.EqualTo(PostType.Copy));
			Assert.That(PostType.FromJsonString("reply"), Is.EqualTo(PostType.Reply));
			Assert.That(PostType.FromJsonString("postpone"), Is.EqualTo(PostType.Postpone));
			Assert.That(PostType.FromJsonString("suggest"), Is.EqualTo(PostType.Suggest));
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
			Assert.That(Privacy.FromJsonString("all"), Is.EqualTo(Privacy.All));
			Assert.That(Privacy.FromJsonString("friends"), Is.EqualTo(Privacy.Friends));

			Assert.That(Privacy.FromJsonString("friends_of_friends")
					, Is.EqualTo(Privacy.FriendsOfFriends));

			Assert.That(Privacy.FromJsonString("friends_of_friends_only")
					, Is.EqualTo(Privacy.FriendsOfFriendsOnly));

			Assert.That(Privacy.FromJsonString("nobody"), Is.EqualTo(Privacy.Nobody));
			Assert.That(Privacy.FromJsonString("only_me"), Is.EqualTo(Privacy.OnlyMe));
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
			Assert.That(RelativeType.FromJsonString("sibling"), Is.EqualTo(RelativeType.Sibling));
			Assert.That(RelativeType.FromJsonString("parent"), Is.EqualTo(RelativeType.Parent));
			Assert.That(RelativeType.FromJsonString("child"), Is.EqualTo(RelativeType.Child));

			Assert.That(RelativeType.FromJsonString("grandparent")
					, Is.EqualTo(RelativeType.Grandparent));

			Assert.That(RelativeType.FromJsonString("grandchild")
					, Is.EqualTo(RelativeType.Grandchild));
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
			Assert.That(ReportType.FromJsonString("porn"), Is.EqualTo(ReportType.Porn));
			Assert.That(ReportType.FromJsonString("spam"), Is.EqualTo(ReportType.Spam));
			Assert.That(ReportType.FromJsonString("insult"), Is.EqualTo(ReportType.Insult));

			Assert.That(ReportType.FromJsonString("advertisment")
					, Is.EqualTo(ReportType.Advertisment));
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
			Assert.That(Services.FromJsonString("email"), Is.EqualTo(Services.Email));
			Assert.That(Services.FromJsonString("phone"), Is.EqualTo(Services.Phone));
			Assert.That(Services.FromJsonString("twitter"), Is.EqualTo(Services.Twitter));
			Assert.That(Services.FromJsonString("facebook"), Is.EqualTo(Services.Facebook));

			Assert.That(Services.FromJsonString("odnoklassniki")
					, Is.EqualTo(Services.Odnoklassniki));

			Assert.That(Services.FromJsonString("instagram"), Is.EqualTo(Services.Instagram));
			Assert.That(Services.FromJsonString("google"), Is.EqualTo(Services.Google));
		}

		[Test]
		public void UserSectionTest()
		{
			// get test
			Assert.That(UserSection.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(UserSection.Subscriptions.ToString(), Is.EqualTo("subscriptions"));

			// parse test
			Assert.That(UserSection.FromJsonString("friends"), Is.EqualTo(UserSection.Friends));

			Assert.That(UserSection.FromJsonString("subscriptions")
					, Is.EqualTo(UserSection.Subscriptions));
		}

		[Test]
		public void VideoCatalogItemTypeTest()
		{
			// get test
			Assert.That(VideoCatalogItemType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(VideoCatalogItemType.Album.ToString(), Is.EqualTo("album"));

			// parse test
			Assert.That(VideoCatalogItemType.FromJsonString("video")
					, Is.EqualTo(VideoCatalogItemType.Video));

			Assert.That(VideoCatalogItemType.FromJsonString("album")
					, Is.EqualTo(VideoCatalogItemType.Album));
		}

		[Test]
		public void VideoCatalogTypeTest()
		{
			// get test
			Assert.That(VideoCatalogType.Channel.ToString(), Is.EqualTo("channel"));
			Assert.That(VideoCatalogType.Category.ToString(), Is.EqualTo("category"));

			// parse test
			Assert.That(VideoCatalogType.FromJsonString("channel")
					, Is.EqualTo(VideoCatalogType.Channel));

			Assert.That(VideoCatalogType.FromJsonString("category")
					, Is.EqualTo(VideoCatalogType.Category));
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
			Assert.That(WallFilter.FromJsonString("owner"), Is.EqualTo(WallFilter.Owner));
			Assert.That(WallFilter.FromJsonString("others"), Is.EqualTo(WallFilter.Others));
			Assert.That(WallFilter.FromJsonString("all"), Is.EqualTo(WallFilter.All));
			Assert.That(WallFilter.FromJsonString("suggests"), Is.EqualTo(WallFilter.Suggests));
			Assert.That(WallFilter.FromJsonString("postponed"), Is.EqualTo(WallFilter.Postponed));
		}

		[Test]
		public void KeyboardButtonColorTest()
		{
			// get test
			Assert.That(KeyboardButtonColor.Default.ToString(), Is.EqualTo("default"));
			Assert.That(KeyboardButtonColor.Negative.ToString(), Is.EqualTo("negative"));
			Assert.That(KeyboardButtonColor.Positive.ToString(), Is.EqualTo("positive"));
			Assert.That(KeyboardButtonColor.Primary.ToString(), Is.EqualTo("primary"));

			// parse test
			Assert.That(KeyboardButtonColor.FromJsonString("default"), Is.EqualTo(KeyboardButtonColor.Default));
			Assert.That(KeyboardButtonColor.FromJsonString("negative"), Is.EqualTo(KeyboardButtonColor.Negative));
			Assert.That(KeyboardButtonColor.FromJsonString("positive"), Is.EqualTo(KeyboardButtonColor.Positive));
			Assert.That(KeyboardButtonColor.FromJsonString("primary"), Is.EqualTo(KeyboardButtonColor.Primary));
		}

		[Test]
		public void KeyboardButtonActionTypeTest()
		{
			// get test
			Assert.That(KeyboardButtonActionType.Text.ToString(), Is.EqualTo("text"));

			// parse test
			Assert.That(KeyboardButtonActionType.FromJsonString("text"), Is.EqualTo(KeyboardButtonActionType.Text));
		}

		[Test]
		public void StoryObjectStateTest()
		{
			// get test
			Assert.That(StoryObjectState.Hidden.ToString(), Is.EqualTo("hidden"));
			Assert.That(StoryObjectState.On.ToString(), Is.EqualTo("on"));
			Assert.That(StoryObjectState.Off.ToString(), Is.EqualTo("off"));

			// parse test
			Assert.That(StoryObjectState.FromJsonString("hidden"), Is.EqualTo(StoryObjectState.Hidden));
			Assert.That(StoryObjectState.FromJsonString("on"), Is.EqualTo(StoryObjectState.On));
			Assert.That(StoryObjectState.FromJsonString("off"), Is.EqualTo(StoryObjectState.Off));
		}

		[Test]
		public void StoryLinkTextTest()
		{
			// get test
			Assert.That(StoryLinkText.Book.ToString(), Is.EqualTo("book"));
			Assert.That(StoryLinkText.Buy.ToString(), Is.EqualTo("buy"));
			Assert.That(StoryLinkText.Contact.ToString(), Is.EqualTo("contact"));
			Assert.That(StoryLinkText.Enroll.ToString(), Is.EqualTo("enroll"));
			Assert.That(StoryLinkText.Fill.ToString(), Is.EqualTo("fill"));
			Assert.That(StoryLinkText.GoTo.ToString(), Is.EqualTo("go_to"));
			Assert.That(StoryLinkText.Install.ToString(), Is.EqualTo("install"));
			Assert.That(StoryLinkText.LearnMore.ToString(), Is.EqualTo("learn_more"));
			Assert.That(StoryLinkText.More.ToString(), Is.EqualTo("more"));
			Assert.That(StoryLinkText.Open.ToString(), Is.EqualTo("open"));
			Assert.That(StoryLinkText.Order.ToString(), Is.EqualTo("order"));
			Assert.That(StoryLinkText.Play.ToString(), Is.EqualTo("play"));
			Assert.That(StoryLinkText.Read.ToString(), Is.EqualTo("read"));
			Assert.That(StoryLinkText.Signup.ToString(), Is.EqualTo("signup"));
			Assert.That(StoryLinkText.View.ToString(), Is.EqualTo("view"));
			Assert.That(StoryLinkText.Vote.ToString(), Is.EqualTo("vote"));
			Assert.That(StoryLinkText.Watch.ToString(), Is.EqualTo("watch"));
			Assert.That(StoryLinkText.Write.ToString(), Is.EqualTo("write"));

			// parse test
			Assert.That(StoryLinkText.FromJsonString("book"), Is.EqualTo(StoryLinkText.Book));
			Assert.That(StoryLinkText.FromJsonString("buy"), Is.EqualTo(StoryLinkText.Buy));
			Assert.That(StoryLinkText.FromJsonString("contact"), Is.EqualTo(StoryLinkText.Contact));
			Assert.That(StoryLinkText.FromJsonString("enroll"), Is.EqualTo(StoryLinkText.Enroll));
			Assert.That(StoryLinkText.FromJsonString("fill"), Is.EqualTo(StoryLinkText.Fill));
			Assert.That(StoryLinkText.FromJsonString("go_to"), Is.EqualTo(StoryLinkText.GoTo));
			Assert.That(StoryLinkText.FromJsonString("install"), Is.EqualTo(StoryLinkText.Install));
			Assert.That(StoryLinkText.FromJsonString("learn_more"), Is.EqualTo(StoryLinkText.LearnMore));
			Assert.That(StoryLinkText.FromJsonString("more"), Is.EqualTo(StoryLinkText.More));
			Assert.That(StoryLinkText.FromJsonString("open"), Is.EqualTo(StoryLinkText.Open));
			Assert.That(StoryLinkText.FromJsonString("order"), Is.EqualTo(StoryLinkText.Order));
			Assert.That(StoryLinkText.FromJsonString("play"), Is.EqualTo(StoryLinkText.Play));
			Assert.That(StoryLinkText.FromJsonString("read"), Is.EqualTo(StoryLinkText.Read));
			Assert.That(StoryLinkText.FromJsonString("signup"), Is.EqualTo(StoryLinkText.Signup));
			Assert.That(StoryLinkText.FromJsonString("view"), Is.EqualTo(StoryLinkText.View));
			Assert.That(StoryLinkText.FromJsonString("vote"), Is.EqualTo(StoryLinkText.Vote));
			Assert.That(StoryLinkText.FromJsonString("watch"), Is.EqualTo(StoryLinkText.Watch));
			Assert.That(StoryLinkText.FromJsonString("write"), Is.EqualTo(StoryLinkText.Write));
		}

		[Test]
		public void MarketItemButtonTitleTest()
		{
			// get test
			Assert.That(MarketItemButtonTitle.Buy.ToString(), Is.EqualTo("Купить"));
			Assert.That(MarketItemButtonTitle.BuyATicket.ToString(), Is.EqualTo("Купить билет"));
			Assert.That(MarketItemButtonTitle.GoToTheStore.ToString(), Is.EqualTo("Перейти в магазин"));

			// parse test
			Assert.That(MarketItemButtonTitle.FromJsonString("Купить"), Is.EqualTo(MarketItemButtonTitle.Buy));
			Assert.That(MarketItemButtonTitle.FromJsonString("Купить билет"), Is.EqualTo(MarketItemButtonTitle.BuyATicket));
			Assert.That(MarketItemButtonTitle.FromJsonString("Перейти в магазин"), Is.EqualTo(MarketItemButtonTitle.GoToTheStore));
		}

		[Test]
		public void AppWidgetTypeTest()
		{
			// get test
			Assert.That(AppWidgetType.Donation.ToString(), Is.EqualTo("donation"));
			Assert.That(AppWidgetType.List.ToString(), Is.EqualTo("list"));
			Assert.That(AppWidgetType.Match.ToString(), Is.EqualTo("match"));
			Assert.That(AppWidgetType.Matches.ToString(), Is.EqualTo("matches"));
			Assert.That(AppWidgetType.Table.ToString(), Is.EqualTo("table"));
			Assert.That(AppWidgetType.Text.ToString(), Is.EqualTo("text"));
			Assert.That(AppWidgetType.Tiles.ToString(), Is.EqualTo("tiles"));
			Assert.That(AppWidgetType.CompactList.ToString(), Is.EqualTo("compact_list"));
			Assert.That(AppWidgetType.CoverList.ToString(), Is.EqualTo("cover_list"));
			// parse test
			Assert.That(AppWidgetType.FromJsonString("donation"), Is.EqualTo(AppWidgetType.Donation));
			Assert.That(AppWidgetType.FromJsonString("list"), Is.EqualTo(AppWidgetType.List));
			Assert.That(AppWidgetType.FromJsonString("match"), Is.EqualTo(AppWidgetType.Match));
			Assert.That(AppWidgetType.FromJsonString("matches"), Is.EqualTo(AppWidgetType.Matches));
			Assert.That(AppWidgetType.FromJsonString("table"), Is.EqualTo(AppWidgetType.Table));
			Assert.That(AppWidgetType.FromJsonString("text"), Is.EqualTo(AppWidgetType.Text));
			Assert.That(AppWidgetType.FromJsonString("tiles"), Is.EqualTo(AppWidgetType.Tiles));
			Assert.That(AppWidgetType.FromJsonString("compact_list"), Is.EqualTo(AppWidgetType.CompactList));
			Assert.That(AppWidgetType.FromJsonString("cover_list"), Is.EqualTo(AppWidgetType.CoverList));
		}
	}
}