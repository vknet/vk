using NUnit.Framework;
using VkNet.Enums.Filters;
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
			Assert.That(actual: AppFilter.Installed.ToString(), expression: Is.EqualTo(expected: "installed"));
			Assert.That(actual: AppFilter.Featured.ToString(), expression: Is.EqualTo(expected: "featured"));

			// parse test
			Assert.That(actual: AppFilter.FromJsonString(response: "installed"), expression: Is.EqualTo(expected: AppFilter.Installed));
			Assert.That(actual: AppFilter.FromJsonString(response: "featured"), expression: Is.EqualTo(expected: AppFilter.Featured));
		}

		[Test]
		public void AppPlatformsTest()
		{
			// get test
			Assert.That(actual: AppPlatforms.Ios.ToString(), expression: Is.EqualTo(expected: "ios"));
			Assert.That(actual: AppPlatforms.Android.ToString(), expression: Is.EqualTo(expected: "android"));
			Assert.That(actual: AppPlatforms.WinPhone.ToString(), expression: Is.EqualTo(expected: "winphone"));
			Assert.That(actual: AppPlatforms.Web.ToString(), expression: Is.EqualTo(expected: "web"));

			// parse test
			Assert.That(actual: AppPlatforms.FromJsonString(response: "ios"), expression: Is.EqualTo(expected: AppPlatforms.Ios));
			Assert.That(actual: AppPlatforms.FromJsonString(response: "android"), expression: Is.EqualTo(expected: AppPlatforms.Android));
			Assert.That(actual: AppPlatforms.FromJsonString(response: "winphone"), expression: Is.EqualTo(expected: AppPlatforms.WinPhone));
			Assert.That(actual: AppPlatforms.FromJsonString(response: "web"), expression: Is.EqualTo(expected: AppPlatforms.Web));
		}

		[Test]
		public void AppRatingTypeTest()
		{
			// get test
			Assert.That(actual: AppRatingType.Level.ToString(), expression: Is.EqualTo(expected: "level"));
			Assert.That(actual: AppRatingType.Points.ToString(), expression: Is.EqualTo(expected: "points"));

			// parse test
			Assert.That(actual: AppRatingType.FromJsonString(response: "level"), expression: Is.EqualTo(expected: AppRatingType.Level));
			Assert.That(actual: AppRatingType.FromJsonString(response: "points"), expression: Is.EqualTo(expected: AppRatingType.Points));
		}

		[Test]
		public void AppRequestTypeTest()
		{
			// get test
			Assert.That(actual: AppRequestType.Invite.ToString(), expression: Is.EqualTo(expected: "invite"));
			Assert.That(actual: AppRequestType.Request.ToString(), expression: Is.EqualTo(expected: "request"));

			// parse test
			Assert.That(actual: AppRequestType.FromJsonString(response: "invite"), expression: Is.EqualTo(expected: AppRequestType.Invite));

			Assert.That(actual: AppRequestType.FromJsonString(response: "request")
					, expression: Is.EqualTo(expected: AppRequestType.Request));
		}

		[Test]
		public void AppSortTest()
		{
			// get test
			Assert.That(actual: AppSort.PopularToday.ToString(), expression: Is.EqualTo(expected: "popular_today"));
			Assert.That(actual: AppSort.Visitors.ToString(), expression: Is.EqualTo(expected: "visitors"));
			Assert.That(actual: AppSort.CreateDate.ToString(), expression: Is.EqualTo(expected: "create_date"));
			Assert.That(actual: AppSort.GrowthRate.ToString(), expression: Is.EqualTo(expected: "growth_rate"));
			Assert.That(actual: AppSort.PopularWeek.ToString(), expression: Is.EqualTo(expected: "popular_week"));

			// parse test
			Assert.That(actual: AppSort.FromJsonString(response: "popular_today"), expression: Is.EqualTo(expected: AppSort.PopularToday));
			Assert.That(actual: AppSort.FromJsonString(response: "visitors"), expression: Is.EqualTo(expected: AppSort.Visitors));
			Assert.That(actual: AppSort.FromJsonString(response: "create_date"), expression: Is.EqualTo(expected: AppSort.CreateDate));
			Assert.That(actual: AppSort.FromJsonString(response: "growth_rate"), expression: Is.EqualTo(expected: AppSort.GrowthRate));
			Assert.That(actual: AppSort.FromJsonString(response: "popular_week"), expression: Is.EqualTo(expected: AppSort.PopularWeek));
		}

		[Test]
		public void ChangeNameStatusTest()
		{
			// get test
			Assert.That(actual: ChangeNameStatus.Processing.ToString(), expression: Is.EqualTo(expected: "processing"));
			Assert.That(actual: ChangeNameStatus.Declined.ToString(), expression: Is.EqualTo(expected: "declined"));
			Assert.That(actual: ChangeNameStatus.Success.ToString(), expression: Is.EqualTo(expected: "success"));
			Assert.That(actual: ChangeNameStatus.WasAccepted.ToString(), expression: Is.EqualTo(expected: "was_accepted"));
			Assert.That(actual: ChangeNameStatus.WasDeclined.ToString(), expression: Is.EqualTo(expected: "was_declined"));

			// parse test
			Assert.That(actual: ChangeNameStatus.FromJsonString(response: "processing")
					, expression: Is.EqualTo(expected: ChangeNameStatus.Processing));

			Assert.That(actual: ChangeNameStatus.FromJsonString(response: "declined")
					, expression: Is.EqualTo(expected: ChangeNameStatus.Declined));

			Assert.That(actual: ChangeNameStatus.FromJsonString(response: "success")
					, expression: Is.EqualTo(expected: ChangeNameStatus.Success));

			Assert.That(actual: ChangeNameStatus.FromJsonString(response: "was_accepted")
					, expression: Is.EqualTo(expected: ChangeNameStatus.WasAccepted));

			Assert.That(actual: ChangeNameStatus.FromJsonString(response: "was_declined")
					, expression: Is.EqualTo(expected: ChangeNameStatus.WasDeclined));
		}

		[Test]
		public void CommentObjectTypeTest()
		{
			// get test
			Assert.That(actual: CommentObjectType.Post.ToString(), expression: Is.EqualTo(expected: "post"));
			Assert.That(actual: CommentObjectType.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: CommentObjectType.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: CommentObjectType.Topic.ToString(), expression: Is.EqualTo(expected: "topic"));
			Assert.That(actual: CommentObjectType.Note.ToString(), expression: Is.EqualTo(expected: "note"));

			// parse test
			Assert.That(actual: CommentObjectType.FromJsonString(response: "post")
					, expression: Is.EqualTo(expected: CommentObjectType.Post));

			Assert.That(actual: CommentObjectType.FromJsonString(response: "photo")
					, expression: Is.EqualTo(expected: CommentObjectType.Photo));

			Assert.That(actual: CommentObjectType.FromJsonString(response: "video")
					, expression: Is.EqualTo(expected: CommentObjectType.Video));

			Assert.That(actual: CommentObjectType.FromJsonString(response: "topic")
					, expression: Is.EqualTo(expected: CommentObjectType.Topic));

			Assert.That(actual: CommentObjectType.FromJsonString(response: "note")
					, expression: Is.EqualTo(expected: CommentObjectType.Note));
		}

		[Test]
		public void CommentsSortTest()
		{
			// get test
			Assert.That(actual: CommentsSort.Asc.ToString(), expression: Is.EqualTo(expected: "asc"));
			Assert.That(actual: CommentsSort.Desc.ToString(), expression: Is.EqualTo(expected: "desc"));

			// parse test
			Assert.That(actual: CommentsSort.FromJsonString(response: "asc"), expression: Is.EqualTo(expected: CommentsSort.Asc));
			Assert.That(actual: CommentsSort.FromJsonString(response: "desc"), expression: Is.EqualTo(expected: CommentsSort.Desc));
		}

		[Test]
		public void DeactivatedTest()
		{
			// get test
			Assert.That(actual: Deactivated.Deleted.ToString(), expression: Is.EqualTo(expected: "deleted"));
			Assert.That(actual: Deactivated.Banned.ToString(), expression: Is.EqualTo(expected: "banned"));
			Assert.That(actual: Deactivated.Activated.ToString(), expression: Is.EqualTo(expected: "activated"));

			// parse test
			Assert.That(actual: Deactivated.FromJsonString(response: "deleted"), expression: Is.EqualTo(expected: Deactivated.Deleted));
			Assert.That(actual: Deactivated.FromJsonString(response: "banned"), expression: Is.EqualTo(expected: Deactivated.Banned));
			Assert.That(actual: Deactivated.FromJsonString(response: "activated"), expression: Is.EqualTo(expected: Deactivated.Activated));
		}

		[Test]
		public void DisplayTest()
		{
			// get test
			Assert.That(actual: Display.Page.ToString(), expression: Is.EqualTo(expected: "page"));
			Assert.That(actual: Display.Popup.ToString(), expression: Is.EqualTo(expected: "popup"));
			Assert.That(actual: Display.Mobile.ToString(), expression: Is.EqualTo(expected: "mobile"));

			// parse test
			Assert.That(actual: Display.FromJsonString(response: "page"), expression: Is.EqualTo(expected: Display.Page));
			Assert.That(actual: Display.FromJsonString(response: "popup"), expression: Is.EqualTo(expected: Display.Popup));
			Assert.That(actual: Display.FromJsonString(response: "mobile"), expression: Is.EqualTo(expected: Display.Mobile));
		}

		[Test]
		public void FeedTypeTest()
		{
			// get test
			Assert.That(actual: FeedType.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: FeedType.PhotoTag.ToString(), expression: Is.EqualTo(expected: "photo_tag"));

			// parse test
			Assert.That(actual: FeedType.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: FeedType.Photo));
			Assert.That(actual: FeedType.FromJsonString(response: "photo_tag"), expression: Is.EqualTo(expected: FeedType.PhotoTag));
		}

		[Test]
		public void FriendsFilterTest()
		{
			// get test
			Assert.That(actual: FriendsFilter.Mutual.ToString(), expression: Is.EqualTo(expected: "mutual"));
			Assert.That(actual: FriendsFilter.Contacts.ToString(), expression: Is.EqualTo(expected: "contacts"));
			Assert.That(actual: FriendsFilter.MutualContacts.ToString(), expression: Is.EqualTo(expected: "mutual_contacts"));

			// parse test
			Assert.That(actual: FriendsFilter.FromJsonString(response: "mutual"), expression: Is.EqualTo(expected: FriendsFilter.Mutual));

			Assert.That(actual: FriendsFilter.FromJsonString(response: "contacts")
					, expression: Is.EqualTo(expected: FriendsFilter.Contacts));

			Assert.That(actual: FriendsFilter.FromJsonString(response: "mutual_contacts")
					, expression: Is.EqualTo(expected: FriendsFilter.MutualContacts));
		}

		[Test]
		public void FriendsOrderTest()
		{
			// get test
			Assert.That(actual: FriendsOrder.Name.ToString(), expression: Is.EqualTo(expected: "name"));
			Assert.That(actual: FriendsOrder.Hints.ToString(), expression: Is.EqualTo(expected: "hints"));
			Assert.That(actual: FriendsOrder.Random.ToString(), expression: Is.EqualTo(expected: "random"));

			// parse test
			Assert.That(actual: FriendsOrder.FromJsonString(response: "name"), expression: Is.EqualTo(expected: FriendsOrder.Name));
			Assert.That(actual: FriendsOrder.FromJsonString(response: "hints"), expression: Is.EqualTo(expected: FriendsOrder.Hints));
			Assert.That(actual: FriendsOrder.FromJsonString(response: "random"), expression: Is.EqualTo(expected: FriendsOrder.Random));
		}

		[Test]
		public void GroupsSortTest()
		{
			// get test
			Assert.That(actual: GroupsSort.IdAsc.ToString(), expression: Is.EqualTo(expected: "id_asc"));
			Assert.That(actual: GroupsSort.IdDesc.ToString(), expression: Is.EqualTo(expected: "id_desc"));
			Assert.That(actual: GroupsSort.TimeAsc.ToString(), expression: Is.EqualTo(expected: "time_asc"));
			Assert.That(actual: GroupsSort.TimeDesc.ToString(), expression: Is.EqualTo(expected: "time_desc"));

			// parse test
			Assert.That(actual: GroupsSort.FromJsonString(response: "id_asc"), expression: Is.EqualTo(expected: GroupsSort.IdAsc));
			Assert.That(actual: GroupsSort.FromJsonString(response: "id_desc"), expression: Is.EqualTo(expected: GroupsSort.IdDesc));
			Assert.That(actual: GroupsSort.FromJsonString(response: "time_asc"), expression: Is.EqualTo(expected: GroupsSort.TimeAsc));
			Assert.That(actual: GroupsSort.FromJsonString(response: "time_desc"), expression: Is.EqualTo(expected: GroupsSort.TimeDesc));
		}

		[Test]
		public void GroupTypeTest()
		{
			// get test
			Assert.That(actual: GroupType.Page.ToString(), expression: Is.EqualTo(expected: "page"));
			Assert.That(actual: GroupType.Group.ToString(), expression: Is.EqualTo(expected: "group"));
			Assert.That(actual: GroupType.Event.ToString(), expression: Is.EqualTo(expected: "event"));
			Assert.That(actual: GroupType.Undefined.ToString(), expression: Is.EqualTo(expected: "undefined"));

			// parse test
			Assert.That(actual: GroupType.FromJsonString(response: "page"), expression: Is.EqualTo(expected: GroupType.Page));
			Assert.That(actual: GroupType.FromJsonString(response: "group"), expression: Is.EqualTo(expected: GroupType.Group));
			Assert.That(actual: GroupType.FromJsonString(response: "event"), expression: Is.EqualTo(expected: GroupType.Event));
			Assert.That(actual: GroupType.FromJsonString(response: "undefined"), expression: Is.EqualTo(expected: GroupType.Undefined));
		}

		[Test]
		public void LikeObjectTypeTest()
		{
			// get test
			Assert.That(actual: LikeObjectType.Post.ToString(), expression: Is.EqualTo(expected: "post"));
			Assert.That(actual: LikeObjectType.Comment.ToString(), expression: Is.EqualTo(expected: "comment"));
			Assert.That(actual: LikeObjectType.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: LikeObjectType.Audio.ToString(), expression: Is.EqualTo(expected: "audio"));
			Assert.That(actual: LikeObjectType.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: LikeObjectType.Note.ToString(), expression: Is.EqualTo(expected: "note"));
			Assert.That(actual: LikeObjectType.PhotoComment.ToString(), expression: Is.EqualTo(expected: "photo_comment"));
			Assert.That(actual: LikeObjectType.VideoComment.ToString(), expression: Is.EqualTo(expected: "video_comment"));
			Assert.That(actual: LikeObjectType.TopicComment.ToString(), expression: Is.EqualTo(expected: "topic_comment"));
			Assert.That(actual: LikeObjectType.SitePage.ToString(), expression: Is.EqualTo(expected: "sitepage"));
			Assert.That(actual: LikeObjectType.Market.ToString(), expression: Is.EqualTo(expected: "market"));
			Assert.That(actual: LikeObjectType.MarketComment.ToString(), expression: Is.EqualTo(expected: "market_comment"));

			// parse test
			Assert.That(actual: LikeObjectType.FromJsonString(response: "post"), expression: Is.EqualTo(expected: LikeObjectType.Post));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "comment")
					, expression: Is.EqualTo(expected: LikeObjectType.Comment));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: LikeObjectType.Photo));
			Assert.That(actual: LikeObjectType.FromJsonString(response: "audio"), expression: Is.EqualTo(expected: LikeObjectType.Audio));
			Assert.That(actual: LikeObjectType.FromJsonString(response: "video"), expression: Is.EqualTo(expected: LikeObjectType.Video));
			Assert.That(actual: LikeObjectType.FromJsonString(response: "note"), expression: Is.EqualTo(expected: LikeObjectType.Note));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "photo_comment")
					, expression: Is.EqualTo(expected: LikeObjectType.PhotoComment));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "video_comment")
					, expression: Is.EqualTo(expected: LikeObjectType.VideoComment));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "topic_comment")
					, expression: Is.EqualTo(expected: LikeObjectType.TopicComment));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "sitepage")
					, expression: Is.EqualTo(expected: LikeObjectType.SitePage));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "market"), expression: Is.EqualTo(expected: LikeObjectType.Market));

			Assert.That(actual: LikeObjectType.FromJsonString(response: "market_comment")
					, expression: Is.EqualTo(expected: LikeObjectType.MarketComment));
		}

		[Test]
		public void LikesFilterTest()
		{
			// get test
			Assert.That(actual: LikesFilter.Likes.ToString(), expression: Is.EqualTo(expected: "likes"));
			Assert.That(actual: LikesFilter.Copies.ToString(), expression: Is.EqualTo(expected: "copies"));

			// parse test
			Assert.That(actual: LikesFilter.FromJsonString(response: "likes"), expression: Is.EqualTo(expected: LikesFilter.Likes));
			Assert.That(actual: LikesFilter.FromJsonString(response: "copies"), expression: Is.EqualTo(expected: LikesFilter.Copies));
		}

		[Test]
		public void LinkAccessTypeTest()
		{
			// get test
			Assert.That(actual: LinkAccessType.NotBanned.ToString(), expression: Is.EqualTo(expected: "not_banned"));
			Assert.That(actual: LinkAccessType.Banned.ToString(), expression: Is.EqualTo(expected: "banned"));
			Assert.That(actual: LinkAccessType.Processing.ToString(), expression: Is.EqualTo(expected: "processing"));

			// parse test
			Assert.That(actual: LinkAccessType.FromJsonString(response: "not_banned")
					, expression: Is.EqualTo(expected: LinkAccessType.NotBanned));

			Assert.That(actual: LinkAccessType.FromJsonString(response: "banned"), expression: Is.EqualTo(expected: LinkAccessType.Banned));

			Assert.That(actual: LinkAccessType.FromJsonString(response: "processing")
					, expression: Is.EqualTo(expected: LinkAccessType.Processing));
		}

		[Test]
		public void MediaTypeTest()
		{
			// get test
			Assert.That(actual: MediaType.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: MediaType.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: MediaType.Audio.ToString(), expression: Is.EqualTo(expected: "audio"));
			Assert.That(actual: MediaType.Doc.ToString(), expression: Is.EqualTo(expected: "doc"));
			Assert.That(actual: MediaType.Link.ToString(), expression: Is.EqualTo(expected: "link"));
			Assert.That(actual: MediaType.Market.ToString(), expression: Is.EqualTo(expected: "market"));
			Assert.That(actual: MediaType.Wall.ToString(), expression: Is.EqualTo(expected: "wall"));
			Assert.That(actual: MediaType.Share.ToString(), expression: Is.EqualTo(expected: "share"));

			// parse test
			Assert.That(actual: MediaType.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: MediaType.Photo));
			Assert.That(actual: MediaType.FromJsonString(response: "video"), expression: Is.EqualTo(expected: MediaType.Video));
			Assert.That(actual: MediaType.FromJsonString(response: "audio"), expression: Is.EqualTo(expected: MediaType.Audio));
			Assert.That(actual: MediaType.FromJsonString(response: "doc"), expression: Is.EqualTo(expected: MediaType.Doc));
			Assert.That(actual: MediaType.FromJsonString(response: "link"), expression: Is.EqualTo(expected: MediaType.Link));
			Assert.That(actual: MediaType.FromJsonString(response: "market"), expression: Is.EqualTo(expected: MediaType.Market));
			Assert.That(actual: MediaType.FromJsonString(response: "wall"), expression: Is.EqualTo(expected: MediaType.Wall));
			Assert.That(actual: MediaType.FromJsonString(response: "share"), expression: Is.EqualTo(expected: MediaType.Share));
		}

		[Test]
		public void NameCaseTest()
		{
			// get test
			Assert.That(actual: NameCase.Nom.ToString(), expression: Is.EqualTo(expected: "nom"));
			Assert.That(actual: NameCase.Gen.ToString(), expression: Is.EqualTo(expected: "gen"));
			Assert.That(actual: NameCase.Dat.ToString(), expression: Is.EqualTo(expected: "dat"));
			Assert.That(actual: NameCase.Acc.ToString(), expression: Is.EqualTo(expected: "acc"));
			Assert.That(actual: NameCase.Ins.ToString(), expression: Is.EqualTo(expected: "ins"));
			Assert.That(actual: NameCase.Abl.ToString(), expression: Is.EqualTo(expected: "abl"));

			// parse test
			Assert.That(actual: NameCase.FromJsonString(response: "nom"), expression: Is.EqualTo(expected: NameCase.Nom));
			Assert.That(actual: NameCase.FromJsonString(response: "gen"), expression: Is.EqualTo(expected: NameCase.Gen));
			Assert.That(actual: NameCase.FromJsonString(response: "dat"), expression: Is.EqualTo(expected: NameCase.Dat));
			Assert.That(actual: NameCase.FromJsonString(response: "acc"), expression: Is.EqualTo(expected: NameCase.Acc));
			Assert.That(actual: NameCase.FromJsonString(response: "ins"), expression: Is.EqualTo(expected: NameCase.Ins));
			Assert.That(actual: NameCase.FromJsonString(response: "abl"), expression: Is.EqualTo(expected: NameCase.Abl));
		}

		[Test]
		public void NewsObjectTypesTest()
		{
			// get test
			Assert.That(actual: NewsObjectTypes.Wall.ToString(), expression: Is.EqualTo(expected: "wall"));
			Assert.That(actual: NewsObjectTypes.Tag.ToString(), expression: Is.EqualTo(expected: "tag"));
			Assert.That(actual: NewsObjectTypes.ProfilePhoto.ToString(), expression: Is.EqualTo(expected: "profilephoto"));
			Assert.That(actual: NewsObjectTypes.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: NewsObjectTypes.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: NewsObjectTypes.Audio.ToString(), expression: Is.EqualTo(expected: "audio"));

			// parse test
			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "wall"), expression: Is.EqualTo(expected: NewsObjectTypes.Wall));
			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "tag"), expression: Is.EqualTo(expected: NewsObjectTypes.Tag));

			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "profilephoto")
					, expression: Is.EqualTo(expected: NewsObjectTypes.ProfilePhoto));

			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "video"), expression: Is.EqualTo(expected: NewsObjectTypes.Video));
			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: NewsObjectTypes.Photo));
			Assert.That(actual: NewsObjectTypes.FromJsonString(response: "audio"), expression: Is.EqualTo(expected: NewsObjectTypes.Audio));
		}

		[Test]
		public void NewsTypesTest()
		{
			// get test
			Assert.That(actual: NewsTypes.Post.ToString(), expression: Is.EqualTo(expected: "post"));
			Assert.That(actual: NewsTypes.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: NewsTypes.PhotoTag.ToString(), expression: Is.EqualTo(expected: "photo_tag"));
			Assert.That(actual: NewsTypes.WallPhoto.ToString(), expression: Is.EqualTo(expected: "wall_photo"));
			Assert.That(actual: NewsTypes.Friend.ToString(), expression: Is.EqualTo(expected: "friend"));
			Assert.That(actual: NewsTypes.Note.ToString(), expression: Is.EqualTo(expected: "note"));

			// parse test
			Assert.That(actual: NewsTypes.FromJsonString(response: "post"), expression: Is.EqualTo(expected: NewsTypes.Post));
			Assert.That(actual: NewsTypes.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: NewsTypes.Photo));
			Assert.That(actual: NewsTypes.FromJsonString(response: "photo_tag"), expression: Is.EqualTo(expected: NewsTypes.PhotoTag));
			Assert.That(actual: NewsTypes.FromJsonString(response: "wall_photo"), expression: Is.EqualTo(expected: NewsTypes.WallPhoto));
			Assert.That(actual: NewsTypes.FromJsonString(response: "friend"), expression: Is.EqualTo(expected: NewsTypes.Friend));
			Assert.That(actual: NewsTypes.FromJsonString(response: "note"), expression: Is.EqualTo(expected: NewsTypes.Note));
		}

		[Test]
		public void OccupationTypeTest()
		{
			// get test
			Assert.That(actual: OccupationType.Work.ToString(), expression: Is.EqualTo(expected: "work"));
			Assert.That(actual: OccupationType.School.ToString(), expression: Is.EqualTo(expected: "school"));
			Assert.That(actual: OccupationType.University.ToString(), expression: Is.EqualTo(expected: "university"));

			// parse test
			Assert.That(actual: OccupationType.FromJsonString(response: "work"), expression: Is.EqualTo(expected: OccupationType.Work));
			Assert.That(actual: OccupationType.FromJsonString(response: "school"), expression: Is.EqualTo(expected: OccupationType.School));

			Assert.That(actual: OccupationType.FromJsonString(response: "university")
					, expression: Is.EqualTo(expected: OccupationType.University));
		}

		[Test]
		public void PhotoAlbumTypeTest()
		{
			// get test
			Assert.That(actual: PhotoAlbumType.Wall.ToString(), expression: Is.EqualTo(expected: "wall"));
			Assert.That(actual: PhotoAlbumType.Profile.ToString(), expression: Is.EqualTo(expected: "profile"));
			Assert.That(actual: PhotoAlbumType.Saved.ToString(), expression: Is.EqualTo(expected: "saved"));

			// parse test
			Assert.That(actual: PhotoAlbumType.FromJsonString(response: "wall"), expression: Is.EqualTo(expected: PhotoAlbumType.Wall));

			Assert.That(actual: PhotoAlbumType.FromJsonString(response: "profile")
					, expression: Is.EqualTo(expected: PhotoAlbumType.Profile));

			Assert.That(actual: PhotoAlbumType.FromJsonString(response: "saved"), expression: Is.EqualTo(expected: PhotoAlbumType.Saved));
		}

		[Test]
		public void PhotoFeedTypeTest()
		{
			// get test
			Assert.That(actual: PhotoFeedType.Photo.ToString(), expression: Is.EqualTo(expected: "photo"));
			Assert.That(actual: PhotoFeedType.PhotoTag.ToString(), expression: Is.EqualTo(expected: "photo_tag"));

			// parse test
			Assert.That(actual: PhotoFeedType.FromJsonString(response: "photo"), expression: Is.EqualTo(expected: PhotoFeedType.Photo));

			Assert.That(actual: PhotoFeedType.FromJsonString(response: "photo_tag")
					, expression: Is.EqualTo(expected: PhotoFeedType.PhotoTag));
		}

		[Test]
		public void PhotoSearchRadiusTest()
		{
			// get test
			Assert.That(actual: PhotoSearchRadius.Ten.ToString(), expression: Is.EqualTo(expected: "10"));
			Assert.That(actual: PhotoSearchRadius.OneHundred.ToString(), expression: Is.EqualTo(expected: "100"));
			Assert.That(actual: PhotoSearchRadius.Eighty.ToString(), expression: Is.EqualTo(expected: "800"));
			Assert.That(actual: PhotoSearchRadius.SixThousand.ToString(), expression: Is.EqualTo(expected: "6000"));
			Assert.That(actual: PhotoSearchRadius.FiftyThousand.ToString(), expression: Is.EqualTo(expected: "50000"));

			// parse test
			Assert.That(actual: PhotoSearchRadius.FromJsonString(response: "10"), expression: Is.EqualTo(expected: PhotoSearchRadius.Ten));

			Assert.That(actual: PhotoSearchRadius.FromJsonString(response: "100")
					, expression: Is.EqualTo(expected: PhotoSearchRadius.OneHundred));

			Assert.That(actual: PhotoSearchRadius.FromJsonString(response: "800")
					, expression: Is.EqualTo(expected: PhotoSearchRadius.Eighty));

			Assert.That(actual: PhotoSearchRadius.FromJsonString(response: "6000")
					, expression: Is.EqualTo(expected: PhotoSearchRadius.SixThousand));

			Assert.That(actual: PhotoSearchRadius.FromJsonString(response: "50000")
					, expression: Is.EqualTo(expected: PhotoSearchRadius.FiftyThousand));
		}

		[Test]
		public void PhotoSizeTypeTest()
		{
			// get test
			Assert.That(actual: PhotoSizeType.S.ToString(), expression: Is.EqualTo(expected: "s"));
			Assert.That(actual: PhotoSizeType.M.ToString(), expression: Is.EqualTo(expected: "m"));
			Assert.That(actual: PhotoSizeType.X.ToString(), expression: Is.EqualTo(expected: "x"));
			Assert.That(actual: PhotoSizeType.O.ToString(), expression: Is.EqualTo(expected: "o"));
			Assert.That(actual: PhotoSizeType.P.ToString(), expression: Is.EqualTo(expected: "p"));
			Assert.That(actual: PhotoSizeType.Q.ToString(), expression: Is.EqualTo(expected: "q"));
			Assert.That(actual: PhotoSizeType.R.ToString(), expression: Is.EqualTo(expected: "r"));
			Assert.That(actual: PhotoSizeType.Y.ToString(), expression: Is.EqualTo(expected: "y"));
			Assert.That(actual: PhotoSizeType.Z.ToString(), expression: Is.EqualTo(expected: "z"));
			Assert.That(actual: PhotoSizeType.W.ToString(), expression: Is.EqualTo(expected: "w"));

			// parse test
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "s"), expression: Is.EqualTo(expected: PhotoSizeType.S));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "m"), expression: Is.EqualTo(expected: PhotoSizeType.M));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "x"), expression: Is.EqualTo(expected: PhotoSizeType.X));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "o"), expression: Is.EqualTo(expected: PhotoSizeType.O));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "p"), expression: Is.EqualTo(expected: PhotoSizeType.P));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "q"), expression: Is.EqualTo(expected: PhotoSizeType.Q));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "r"), expression: Is.EqualTo(expected: PhotoSizeType.R));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "y"), expression: Is.EqualTo(expected: PhotoSizeType.Y));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "z"), expression: Is.EqualTo(expected: PhotoSizeType.Z));
			Assert.That(actual: PhotoSizeType.FromJsonString(response: "w"), expression: Is.EqualTo(expected: PhotoSizeType.W));
		}

		[Test]
		public void PlatformTest()
		{
			// get test
			Assert.That(actual: Platform.Android.ToString(), expression: Is.EqualTo(expected: "android"));
			Assert.That(actual: Platform.IPhone.ToString(), expression: Is.EqualTo(expected: "iphone"));
			Assert.That(actual: Platform.WindowsPhone.ToString(), expression: Is.EqualTo(expected: "wphone"));

			// parse test
			Assert.That(actual: Platform.FromJsonString(response: "android"), expression: Is.EqualTo(expected: Platform.Android));
			Assert.That(actual: Platform.FromJsonString(response: "iphone"), expression: Is.EqualTo(expected: Platform.IPhone));
			Assert.That(actual: Platform.FromJsonString(response: "wphone"), expression: Is.EqualTo(expected: Platform.WindowsPhone));
		}

		[Test]
		public void PostSourceTypeTest()
		{
			// get test
			Assert.That(actual: PostSourceType.Vk.ToString(), expression: Is.EqualTo(expected: "vk"));
			Assert.That(actual: PostSourceType.Widget.ToString(), expression: Is.EqualTo(expected: "widget"));
			Assert.That(actual: PostSourceType.Api.ToString(), expression: Is.EqualTo(expected: "api"));
			Assert.That(actual: PostSourceType.Rss.ToString(), expression: Is.EqualTo(expected: "rss"));
			Assert.That(actual: PostSourceType.Sms.ToString(), expression: Is.EqualTo(expected: "sms"));

			// parse test
			Assert.That(actual: PostSourceType.FromJsonString(response: "vk"), expression: Is.EqualTo(expected: PostSourceType.Vk));
			Assert.That(actual: PostSourceType.FromJsonString(response: "widget"), expression: Is.EqualTo(expected: PostSourceType.Widget));
			Assert.That(actual: PostSourceType.FromJsonString(response: "api"), expression: Is.EqualTo(expected: PostSourceType.Api));
			Assert.That(actual: PostSourceType.FromJsonString(response: "rss"), expression: Is.EqualTo(expected: PostSourceType.Rss));
			Assert.That(actual: PostSourceType.FromJsonString(response: "sms"), expression: Is.EqualTo(expected: PostSourceType.Sms));
		}

		[Test]
		public void PostTypeOrderTest()
		{
			// get test
			Assert.That(actual: PostTypeOrder.Post.ToString(), expression: Is.EqualTo(expected: "post"));
			Assert.That(actual: PostTypeOrder.Copy.ToString(), expression: Is.EqualTo(expected: "copy"));

			// parse test
			Assert.That(actual: PostTypeOrder.FromJsonString(response: "post"), expression: Is.EqualTo(expected: PostTypeOrder.Post));
			Assert.That(actual: PostTypeOrder.FromJsonString(response: "copy"), expression: Is.EqualTo(expected: PostTypeOrder.Copy));
		}

		[Test]
		public void PostTypeTest()
		{
			// get test
			Assert.That(actual: PostType.Post.ToString(), expression: Is.EqualTo(expected: "post"));
			Assert.That(actual: PostType.Copy.ToString(), expression: Is.EqualTo(expected: "copy"));
			Assert.That(actual: PostType.Reply.ToString(), expression: Is.EqualTo(expected: "reply"));
			Assert.That(actual: PostType.Postpone.ToString(), expression: Is.EqualTo(expected: "postpone"));
			Assert.That(actual: PostType.Suggest.ToString(), expression: Is.EqualTo(expected: "suggest"));

			// parse test
			Assert.That(actual: PostType.FromJsonString(response: "post"), expression: Is.EqualTo(expected: PostType.Post));
			Assert.That(actual: PostType.FromJsonString(response: "copy"), expression: Is.EqualTo(expected: PostType.Copy));
			Assert.That(actual: PostType.FromJsonString(response: "reply"), expression: Is.EqualTo(expected: PostType.Reply));
			Assert.That(actual: PostType.FromJsonString(response: "postpone"), expression: Is.EqualTo(expected: PostType.Postpone));
			Assert.That(actual: PostType.FromJsonString(response: "suggest"), expression: Is.EqualTo(expected: PostType.Suggest));
		}

		[Test]
		public void PrivacyTest()
		{
			// get test
			Assert.That(actual: Privacy.All.ToString(), expression: Is.EqualTo(expected: "all"));
			Assert.That(actual: Privacy.Friends.ToString(), expression: Is.EqualTo(expected: "friends"));
			Assert.That(actual: Privacy.FriendsOfFriends.ToString(), expression: Is.EqualTo(expected: "friends_of_friends"));
			Assert.That(actual: Privacy.FriendsOfFriendsOnly.ToString(), expression: Is.EqualTo(expected: "friends_of_friends_only"));
			Assert.That(actual: Privacy.Nobody.ToString(), expression: Is.EqualTo(expected: "nobody"));
			Assert.That(actual: Privacy.OnlyMe.ToString(), expression: Is.EqualTo(expected: "only_me"));

			// parse test
			Assert.That(actual: Privacy.FromJsonString(response: "all"), expression: Is.EqualTo(expected: Privacy.All));
			Assert.That(actual: Privacy.FromJsonString(response: "friends"), expression: Is.EqualTo(expected: Privacy.Friends));

			Assert.That(actual: Privacy.FromJsonString(response: "friends_of_friends")
					, expression: Is.EqualTo(expected: Privacy.FriendsOfFriends));

			Assert.That(actual: Privacy.FromJsonString(response: "friends_of_friends_only")
					, expression: Is.EqualTo(expected: Privacy.FriendsOfFriendsOnly));

			Assert.That(actual: Privacy.FromJsonString(response: "nobody"), expression: Is.EqualTo(expected: Privacy.Nobody));
			Assert.That(actual: Privacy.FromJsonString(response: "only_me"), expression: Is.EqualTo(expected: Privacy.OnlyMe));
		}

		[Test]
		public void RelativeTypeTest()
		{
			// get test
			Assert.That(actual: RelativeType.Sibling.ToString(), expression: Is.EqualTo(expected: "sibling"));
			Assert.That(actual: RelativeType.Parent.ToString(), expression: Is.EqualTo(expected: "parent"));
			Assert.That(actual: RelativeType.Child.ToString(), expression: Is.EqualTo(expected: "child"));
			Assert.That(actual: RelativeType.Grandparent.ToString(), expression: Is.EqualTo(expected: "grandparent"));
			Assert.That(actual: RelativeType.Grandchild.ToString(), expression: Is.EqualTo(expected: "grandchild"));

			// parse test
			Assert.That(actual: RelativeType.FromJsonString(response: "sibling"), expression: Is.EqualTo(expected: RelativeType.Sibling));
			Assert.That(actual: RelativeType.FromJsonString(response: "parent"), expression: Is.EqualTo(expected: RelativeType.Parent));
			Assert.That(actual: RelativeType.FromJsonString(response: "child"), expression: Is.EqualTo(expected: RelativeType.Child));

			Assert.That(actual: RelativeType.FromJsonString(response: "grandparent")
					, expression: Is.EqualTo(expected: RelativeType.Grandparent));

			Assert.That(actual: RelativeType.FromJsonString(response: "grandchild")
					, expression: Is.EqualTo(expected: RelativeType.Grandchild));
		}

		[Test]
		public void ReportTypeTest()
		{
			// get test
			Assert.That(actual: ReportType.Porn.ToString(), expression: Is.EqualTo(expected: "porn"));
			Assert.That(actual: ReportType.Spam.ToString(), expression: Is.EqualTo(expected: "spam"));
			Assert.That(actual: ReportType.Insult.ToString(), expression: Is.EqualTo(expected: "insult"));
			Assert.That(actual: ReportType.Advertisment.ToString(), expression: Is.EqualTo(expected: "advertisment"));

			// parse test
			Assert.That(actual: ReportType.FromJsonString(response: "porn"), expression: Is.EqualTo(expected: ReportType.Porn));
			Assert.That(actual: ReportType.FromJsonString(response: "spam"), expression: Is.EqualTo(expected: ReportType.Spam));
			Assert.That(actual: ReportType.FromJsonString(response: "insult"), expression: Is.EqualTo(expected: ReportType.Insult));

			Assert.That(actual: ReportType.FromJsonString(response: "advertisment")
					, expression: Is.EqualTo(expected: ReportType.Advertisment));
		}

		[Test]
		public void ServicesTest()
		{
			// get test
			Assert.That(actual: Services.Email.ToString(), expression: Is.EqualTo(expected: "email"));
			Assert.That(actual: Services.Phone.ToString(), expression: Is.EqualTo(expected: "phone"));
			Assert.That(actual: Services.Twitter.ToString(), expression: Is.EqualTo(expected: "twitter"));
			Assert.That(actual: Services.Facebook.ToString(), expression: Is.EqualTo(expected: "facebook"));
			Assert.That(actual: Services.Odnoklassniki.ToString(), expression: Is.EqualTo(expected: "odnoklassniki"));
			Assert.That(actual: Services.Instagram.ToString(), expression: Is.EqualTo(expected: "instagram"));
			Assert.That(actual: Services.Google.ToString(), expression: Is.EqualTo(expected: "google"));

			// parse test
			Assert.That(actual: Services.FromJsonString(response: "email"), expression: Is.EqualTo(expected: Services.Email));
			Assert.That(actual: Services.FromJsonString(response: "phone"), expression: Is.EqualTo(expected: Services.Phone));
			Assert.That(actual: Services.FromJsonString(response: "twitter"), expression: Is.EqualTo(expected: Services.Twitter));
			Assert.That(actual: Services.FromJsonString(response: "facebook"), expression: Is.EqualTo(expected: Services.Facebook));

			Assert.That(actual: Services.FromJsonString(response: "odnoklassniki")
					, expression: Is.EqualTo(expected: Services.Odnoklassniki));

			Assert.That(actual: Services.FromJsonString(response: "instagram"), expression: Is.EqualTo(expected: Services.Instagram));
			Assert.That(actual: Services.FromJsonString(response: "google"), expression: Is.EqualTo(expected: Services.Google));
		}

		[Test]
		public void UserSectionTest()
		{
			// get test
			Assert.That(actual: UserSection.Friends.ToString(), expression: Is.EqualTo(expected: "friends"));
			Assert.That(actual: UserSection.Subscriptions.ToString(), expression: Is.EqualTo(expected: "subscriptions"));

			// parse test
			Assert.That(actual: UserSection.FromJsonString(response: "friends"), expression: Is.EqualTo(expected: UserSection.Friends));

			Assert.That(actual: UserSection.FromJsonString(response: "subscriptions")
					, expression: Is.EqualTo(expected: UserSection.Subscriptions));
		}

		[Test]
		public void VideoCatalogItemTypeTest()
		{
			// get test
			Assert.That(actual: VideoCatalogItemType.Video.ToString(), expression: Is.EqualTo(expected: "video"));
			Assert.That(actual: VideoCatalogItemType.Album.ToString(), expression: Is.EqualTo(expected: "album"));

			// parse test
			Assert.That(actual: VideoCatalogItemType.FromJsonString(response: "video")
					, expression: Is.EqualTo(expected: VideoCatalogItemType.Video));

			Assert.That(actual: VideoCatalogItemType.FromJsonString(response: "album")
					, expression: Is.EqualTo(expected: VideoCatalogItemType.Album));
		}

		[Test]
		public void VideoCatalogTypeTest()
		{
			// get test
			Assert.That(actual: VideoCatalogType.Channel.ToString(), expression: Is.EqualTo(expected: "channel"));
			Assert.That(actual: VideoCatalogType.Category.ToString(), expression: Is.EqualTo(expected: "category"));

			// parse test
			Assert.That(actual: VideoCatalogType.FromJsonString(response: "channel")
					, expression: Is.EqualTo(expected: VideoCatalogType.Channel));

			Assert.That(actual: VideoCatalogType.FromJsonString(response: "category")
					, expression: Is.EqualTo(expected: VideoCatalogType.Category));
		}

		[Test]
		public void WallFilterTest()
		{
			// get test
			Assert.That(actual: WallFilter.Owner.ToString(), expression: Is.EqualTo(expected: "owner"));
			Assert.That(actual: WallFilter.Others.ToString(), expression: Is.EqualTo(expected: "others"));
			Assert.That(actual: WallFilter.All.ToString(), expression: Is.EqualTo(expected: "all"));
			Assert.That(actual: WallFilter.Suggests.ToString(), expression: Is.EqualTo(expected: "suggests"));
			Assert.That(actual: WallFilter.Postponed.ToString(), expression: Is.EqualTo(expected: "postponed"));

			// parse test
			Assert.That(actual: WallFilter.FromJsonString(response: "owner"), expression: Is.EqualTo(expected: WallFilter.Owner));
			Assert.That(actual: WallFilter.FromJsonString(response: "others"), expression: Is.EqualTo(expected: WallFilter.Others));
			Assert.That(actual: WallFilter.FromJsonString(response: "all"), expression: Is.EqualTo(expected: WallFilter.All));
			Assert.That(actual: WallFilter.FromJsonString(response: "suggests"), expression: Is.EqualTo(expected: WallFilter.Suggests));
			Assert.That(actual: WallFilter.FromJsonString(response: "postponed"), expression: Is.EqualTo(expected: WallFilter.Postponed));
		}

		[Test]
		public void KeyboardButtonColorTest()
		{
			// get test
			Assert.That(actual: KeyboardButtonColor.Default.ToString(), expression: Is.EqualTo(expected: "default"));
			Assert.That(actual: KeyboardButtonColor.Negative.ToString(), expression: Is.EqualTo(expected: "negative"));
			Assert.That(actual: KeyboardButtonColor.Positive.ToString(), expression: Is.EqualTo(expected: "positive"));
			Assert.That(actual: KeyboardButtonColor.Primary.ToString(), expression: Is.EqualTo(expected: "primary"));

			// parse test
			Assert.That(actual: KeyboardButtonColor.FromJsonString(response: "default"), expression: Is.EqualTo(expected: KeyboardButtonColor.Default));
			Assert.That(actual: KeyboardButtonColor.FromJsonString(response: "negative"), expression: Is.EqualTo(expected: KeyboardButtonColor.Negative));
			Assert.That(actual: KeyboardButtonColor.FromJsonString(response: "positive"), expression: Is.EqualTo(expected: KeyboardButtonColor.Positive));
			Assert.That(actual: KeyboardButtonColor.FromJsonString(response: "primary"), expression: Is.EqualTo(expected: KeyboardButtonColor.Primary));
		}

		[Test]
		public void KeyboardButtonActionTypeTest()
		{
			// get test
			Assert.That(actual: KeyboardButtonActionType.Text.ToString(), expression: Is.EqualTo(expected: "text"));

			// parse test
			Assert.That(actual: KeyboardButtonActionType.FromJsonString(response: "text"), expression: Is.EqualTo(expected: KeyboardButtonActionType.Text));
		}

		[Test]
		public void StoryObjectStateTest()
		{
			// get test
			Assert.That(actual: StoryObjectState.Hidden.ToString(), expression: Is.EqualTo(expected: "hidden"));
			Assert.That(actual: StoryObjectState.On.ToString(), expression: Is.EqualTo(expected: "on"));
			Assert.That(actual: StoryObjectState.Off.ToString(), expression: Is.EqualTo(expected: "off"));

			// parse test
			Assert.That(actual: StoryObjectState.FromJsonString(response: "hidden"), expression: Is.EqualTo(expected: StoryObjectState.Hidden));
			Assert.That(actual: StoryObjectState.FromJsonString(response: "on"), expression: Is.EqualTo(expected: StoryObjectState.On));
			Assert.That(actual: StoryObjectState.FromJsonString(response: "off"), expression: Is.EqualTo(expected: StoryObjectState.Off));
		}

		[Test]
		public void StoryLinkTextTest()
		{
			// get test
			Assert.That(actual: StoryLinkText.Book.ToString(), expression: Is.EqualTo(expected: "book"));
			Assert.That(actual: StoryLinkText.Buy.ToString(), expression: Is.EqualTo(expected: "buy"));
			Assert.That(actual: StoryLinkText.Contact.ToString(), expression: Is.EqualTo(expected: "contact"));
			Assert.That(actual: StoryLinkText.Enroll.ToString(), expression: Is.EqualTo(expected: "enroll"));
			Assert.That(actual: StoryLinkText.Fill.ToString(), expression: Is.EqualTo(expected: "fill"));
			Assert.That(actual: StoryLinkText.GoTo.ToString(), expression: Is.EqualTo(expected: "go_to"));
			Assert.That(actual: StoryLinkText.Install.ToString(), expression: Is.EqualTo(expected: "install"));
			Assert.That(actual: StoryLinkText.LearnMore.ToString(), expression: Is.EqualTo(expected: "learn_more"));
			Assert.That(actual: StoryLinkText.More.ToString(), expression: Is.EqualTo(expected: "more"));
			Assert.That(actual: StoryLinkText.Open.ToString(), expression: Is.EqualTo(expected: "open"));
			Assert.That(actual: StoryLinkText.Order.ToString(), expression: Is.EqualTo(expected: "order"));
			Assert.That(actual: StoryLinkText.Play.ToString(), expression: Is.EqualTo(expected: "play"));
			Assert.That(actual: StoryLinkText.Read.ToString(), expression: Is.EqualTo(expected: "read"));
			Assert.That(actual: StoryLinkText.Signup.ToString(), expression: Is.EqualTo(expected: "signup"));
			Assert.That(actual: StoryLinkText.View.ToString(), expression: Is.EqualTo(expected: "view"));
			Assert.That(actual: StoryLinkText.Vote.ToString(), expression: Is.EqualTo(expected: "vote"));
			Assert.That(actual: StoryLinkText.Watch.ToString(), expression: Is.EqualTo(expected: "watch"));
			Assert.That(actual: StoryLinkText.Write.ToString(), expression: Is.EqualTo(expected: "write"));

			// parse test
			Assert.That(actual: StoryLinkText.FromJsonString(response: "book"), expression: Is.EqualTo(expected: StoryLinkText.Book));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "buy"), expression: Is.EqualTo(expected: StoryLinkText.Buy));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "contact"), expression: Is.EqualTo(expected: StoryLinkText.Contact));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "enroll"), expression: Is.EqualTo(expected: StoryLinkText.Enroll));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "fill"), expression: Is.EqualTo(expected: StoryLinkText.Fill));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "go_to"), expression: Is.EqualTo(expected: StoryLinkText.GoTo));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "install"), expression: Is.EqualTo(expected: StoryLinkText.Install));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "learn_more"), expression: Is.EqualTo(expected: StoryLinkText.LearnMore));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "more"), expression: Is.EqualTo(expected: StoryLinkText.More));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "open"), expression: Is.EqualTo(expected: StoryLinkText.Open));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "order"), expression: Is.EqualTo(expected: StoryLinkText.Order));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "play"), expression: Is.EqualTo(expected: StoryLinkText.Play));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "read"), expression: Is.EqualTo(expected: StoryLinkText.Read));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "signup"), expression: Is.EqualTo(expected: StoryLinkText.Signup));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "view"), expression: Is.EqualTo(expected: StoryLinkText.View));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "vote"), expression: Is.EqualTo(expected: StoryLinkText.Vote));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "watch"), expression: Is.EqualTo(expected: StoryLinkText.Watch));
			Assert.That(actual: StoryLinkText.FromJsonString(response: "write"), expression: Is.EqualTo(expected: StoryLinkText.Write));
		}
	}
}