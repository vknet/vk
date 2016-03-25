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
			// get test
			Assert.That(FeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(FeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			// parse test
			var varPhoto = FeedType.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(FeedType.Photo));
			var varPhotoTag = FeedType.FromJson("photo_tag");
			Assert.That(varPhotoTag, Is.EqualTo(FeedType.PhotoTag));
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
			var varPhoto = MediaType.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(MediaType.Photo));
			var varVideo = MediaType.FromJson("video");
			Assert.That(varVideo, Is.EqualTo(MediaType.Video));
			var varAudio = MediaType.FromJson("audio");
			Assert.That(varAudio, Is.EqualTo(MediaType.Audio));
			var varDoc = MediaType.FromJson("doc");
			Assert.That(varDoc, Is.EqualTo(MediaType.Doc));
			var varLink = MediaType.FromJson("link");
			Assert.That(varLink, Is.EqualTo(MediaType.Link));
			var varMarket = MediaType.FromJson("market");
			Assert.That(varMarket, Is.EqualTo(MediaType.Market));
			var varWall = MediaType.FromJson("wall");
			Assert.That(varWall, Is.EqualTo(MediaType.Wall));
			var varShare = MediaType.FromJson("share");
			Assert.That(varShare, Is.EqualTo(MediaType.Share));
		}

		[Test]
        public void VideoCatalogItemTypeTest()
        {
			// get test
			Assert.That(VideoCatalogItemType.Video.ToString(), Is.EqualTo("video"));
			Assert.That(VideoCatalogItemType.Album.ToString(), Is.EqualTo("album"));
			// parse test
			var varVideo = VideoCatalogItemType.FromJson("video");
			Assert.That(varVideo, Is.EqualTo(VideoCatalogItemType.Video));
			var varAlbum = VideoCatalogItemType.FromJson("album");
			Assert.That(varAlbum, Is.EqualTo(VideoCatalogItemType.Album));
		}

		[Test]
        public void VideoCatalogTypeTest()
        {
			// get test
			Assert.That(VideoCatalogType.Channel.ToString(), Is.EqualTo("channel"));
			Assert.That(VideoCatalogType.Category.ToString(), Is.EqualTo("category"));
			// parse test
			var varChannel = VideoCatalogType.FromJson("channel");
			Assert.That(varChannel, Is.EqualTo(VideoCatalogType.Channel));
			var varCategory = VideoCatalogType.FromJson("category");
			Assert.That(varCategory, Is.EqualTo(VideoCatalogType.Category));
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
			var varPost = PostType.FromJson("post");
			Assert.That(varPost, Is.EqualTo(PostType.Post));
			var varCopy = PostType.FromJson("copy");
			Assert.That(varCopy, Is.EqualTo(PostType.Copy));
			var varReply = PostType.FromJson("reply");
			Assert.That(varReply, Is.EqualTo(PostType.Reply));
			var varPostpone = PostType.FromJson("postpone");
			Assert.That(varPostpone, Is.EqualTo(PostType.Postpone));
			var varSuggest = PostType.FromJson("suggest");
			Assert.That(varSuggest, Is.EqualTo(PostType.Suggest));
		}

		[Test]
        public void FriendsFilterTest()
        {
			// get test
			Assert.That(FriendsFilter.Mutual.ToString(), Is.EqualTo("mutual"));
			Assert.That(FriendsFilter.Contacts.ToString(), Is.EqualTo("contacts"));
			Assert.That(FriendsFilter.MutualContacts.ToString(), Is.EqualTo("mutual_contacts"));
			// parse test
			var varMutual = FriendsFilter.FromJson("mutual");
			Assert.That(varMutual, Is.EqualTo(FriendsFilter.Mutual));
			var varContacts = FriendsFilter.FromJson("contacts");
			Assert.That(varContacts, Is.EqualTo(FriendsFilter.Contacts));
			var varMutualContacts = FriendsFilter.FromJson("mutual_contacts");
			Assert.That(varMutualContacts, Is.EqualTo(FriendsFilter.MutualContacts));
		}

		[Test]
        public void DeactivatedTest()
        {
			// get test
			Assert.That(Deactivated.Deleted.ToString(), Is.EqualTo("deleted"));
			Assert.That(Deactivated.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(Deactivated.Activated.ToString(), Is.EqualTo("activated"));
			// parse test
			var varDeleted = Deactivated.FromJson("deleted");
			Assert.That(varDeleted, Is.EqualTo(Deactivated.Deleted));
			var varBanned = Deactivated.FromJson("banned");
			Assert.That(varBanned, Is.EqualTo(Deactivated.Banned));
			var varActivated = Deactivated.FromJson("activated");
			Assert.That(varActivated, Is.EqualTo(Deactivated.Activated));
		}

		[Test]
        public void PlatformTest()
        {
			// get test
			Assert.That(Platform.Android.ToString(), Is.EqualTo("android"));
			Assert.That(Platform.IPhone.ToString(), Is.EqualTo("iphone"));
			Assert.That(Platform.WindowsPhone.ToString(), Is.EqualTo("wphone"));
			// parse test
			var varAndroid = Platform.FromJson("android");
			Assert.That(varAndroid, Is.EqualTo(Platform.Android));
			var varIPhone = Platform.FromJson("iphone");
			Assert.That(varIPhone, Is.EqualTo(Platform.IPhone));
			var varWindowsPhone = Platform.FromJson("wphone");
			Assert.That(varWindowsPhone, Is.EqualTo(Platform.WindowsPhone));
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
			var varSibling = RelativeType.FromJson("sibling");
			Assert.That(varSibling, Is.EqualTo(RelativeType.Sibling));
			var varParent = RelativeType.FromJson("parent");
			Assert.That(varParent, Is.EqualTo(RelativeType.Parent));
			var varChild = RelativeType.FromJson("child");
			Assert.That(varChild, Is.EqualTo(RelativeType.Child));
			var varGrandparent = RelativeType.FromJson("grandparent");
			Assert.That(varGrandparent, Is.EqualTo(RelativeType.Grandparent));
			var varGrandchild = RelativeType.FromJson("grandchild");
			Assert.That(varGrandchild, Is.EqualTo(RelativeType.Grandchild));
		}

		[Test]
        public void AppFilterTest()
        {
			// get test
			Assert.That(AppFilter.Installed.ToString(), Is.EqualTo("installed"));
			Assert.That(AppFilter.Featured.ToString(), Is.EqualTo("featured"));
			// parse test
			var varInstalled = AppFilter.FromJson("installed");
			Assert.That(varInstalled, Is.EqualTo(AppFilter.Installed));
			var varFeatured = AppFilter.FromJson("featured");
			Assert.That(varFeatured, Is.EqualTo(AppFilter.Featured));
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
			var varIos = AppPlatforms.FromJson("ios");
			Assert.That(varIos, Is.EqualTo(AppPlatforms.Ios));
			var varAndroid = AppPlatforms.FromJson("android");
			Assert.That(varAndroid, Is.EqualTo(AppPlatforms.Android));
			var varWinPhone = AppPlatforms.FromJson("winphone");
			Assert.That(varWinPhone, Is.EqualTo(AppPlatforms.WinPhone));
			var varWeb = AppPlatforms.FromJson("web");
			Assert.That(varWeb, Is.EqualTo(AppPlatforms.Web));
		}

		[Test]
        public void AppRequestTypeTest()
        {
			// get test
			Assert.That(AppRequestType.Invite.ToString(), Is.EqualTo("invite"));
			Assert.That(AppRequestType.Request.ToString(), Is.EqualTo("request"));
			// parse test
			var varInvite = AppRequestType.FromJson("invite");
			Assert.That(varInvite, Is.EqualTo(AppRequestType.Invite));
			var varRequest = AppRequestType.FromJson("request");
			Assert.That(varRequest, Is.EqualTo(AppRequestType.Request));
		}

		[Test]
        public void AppRatingTypeTest()
        {
			// get test
			Assert.That(AppRatingType.Level.ToString(), Is.EqualTo("level"));
			Assert.That(AppRatingType.Points.ToString(), Is.EqualTo("points"));
			// parse test
			var varLevel = AppRatingType.FromJson("level");
			Assert.That(varLevel, Is.EqualTo(AppRatingType.Level));
			var varPoints = AppRatingType.FromJson("points");
			Assert.That(varPoints, Is.EqualTo(AppRatingType.Points));
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
			var varPost = CommentObjectType.FromJson("post");
			Assert.That(varPost, Is.EqualTo(CommentObjectType.Post));
			var varPhoto = CommentObjectType.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(CommentObjectType.Photo));
			var varVideo = CommentObjectType.FromJson("video");
			Assert.That(varVideo, Is.EqualTo(CommentObjectType.Video));
			var varTopic = CommentObjectType.FromJson("topic");
			Assert.That(varTopic, Is.EqualTo(CommentObjectType.Topic));
			var varNote = CommentObjectType.FromJson("note");
			Assert.That(varNote, Is.EqualTo(CommentObjectType.Note));
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
			var varTen = PhotoSearchRadius.FromJson("10");
			Assert.That(varTen, Is.EqualTo(PhotoSearchRadius.Ten));
			var varOneHundred = PhotoSearchRadius.FromJson("100");
			Assert.That(varOneHundred, Is.EqualTo(PhotoSearchRadius.OneHundred));
			var varEighty = PhotoSearchRadius.FromJson("800");
			Assert.That(varEighty, Is.EqualTo(PhotoSearchRadius.Eighty));
			var varSixThousand = PhotoSearchRadius.FromJson("6000");
			Assert.That(varSixThousand, Is.EqualTo(PhotoSearchRadius.SixThousand));
			var varFiftyThousand = PhotoSearchRadius.FromJson("50000");
			Assert.That(varFiftyThousand, Is.EqualTo(PhotoSearchRadius.FiftyThousand));
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
			var varS = PhotoSizeType.FromJson("s");
			Assert.That(varS, Is.EqualTo(PhotoSizeType.S));
			var varM = PhotoSizeType.FromJson("m");
			Assert.That(varM, Is.EqualTo(PhotoSizeType.M));
			var varX = PhotoSizeType.FromJson("x");
			Assert.That(varX, Is.EqualTo(PhotoSizeType.X));
			var varO = PhotoSizeType.FromJson("o");
			Assert.That(varO, Is.EqualTo(PhotoSizeType.O));
			var varP = PhotoSizeType.FromJson("p");
			Assert.That(varP, Is.EqualTo(PhotoSizeType.P));
			var varQ = PhotoSizeType.FromJson("q");
			Assert.That(varQ, Is.EqualTo(PhotoSizeType.Q));
			var varR = PhotoSizeType.FromJson("r");
			Assert.That(varR, Is.EqualTo(PhotoSizeType.R));
			var varY = PhotoSizeType.FromJson("y");
			Assert.That(varY, Is.EqualTo(PhotoSizeType.Y));
			var varZ = PhotoSizeType.FromJson("z");
			Assert.That(varZ, Is.EqualTo(PhotoSizeType.Z));
			var varW = PhotoSizeType.FromJson("w");
			Assert.That(varW, Is.EqualTo(PhotoSizeType.W));
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
			var varWall = NewsObjectTypes.FromJson("wall");
			Assert.That(varWall, Is.EqualTo(NewsObjectTypes.Wall));
			var varTag = NewsObjectTypes.FromJson("tag");
			Assert.That(varTag, Is.EqualTo(NewsObjectTypes.Tag));
			var varProfilePhoto = NewsObjectTypes.FromJson("profilephoto");
			Assert.That(varProfilePhoto, Is.EqualTo(NewsObjectTypes.ProfilePhoto));
			var varVideo = NewsObjectTypes.FromJson("video");
			Assert.That(varVideo, Is.EqualTo(NewsObjectTypes.Video));
			var varPhoto = NewsObjectTypes.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(NewsObjectTypes.Photo));
			var varAudio = NewsObjectTypes.FromJson("audio");
			Assert.That(varAudio, Is.EqualTo(NewsObjectTypes.Audio));
		}

		[Test]
        public void LikesFilterTest()
        {
			// get test
			Assert.That(LikesFilter.Likes.ToString(), Is.EqualTo("likes"));
			Assert.That(LikesFilter.Copies.ToString(), Is.EqualTo("copies"));
			// parse test
			var varLikes = LikesFilter.FromJson("likes");
			Assert.That(varLikes, Is.EqualTo(LikesFilter.Likes));
			var varCopies = LikesFilter.FromJson("copies");
			Assert.That(varCopies, Is.EqualTo(LikesFilter.Copies));
		}

		[Test]
        public void PostTypeOrderTest()
        {
			// get test
			Assert.That(PostTypeOrder.Post.ToString(), Is.EqualTo("post"));
			Assert.That(PostTypeOrder.Copy.ToString(), Is.EqualTo("copy"));
			// parse test
			var varPost = PostTypeOrder.FromJson("post");
			Assert.That(varPost, Is.EqualTo(PostTypeOrder.Post));
			var varCopy = PostTypeOrder.FromJson("copy");
			Assert.That(varCopy, Is.EqualTo(PostTypeOrder.Copy));
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
			var varPopularToday = AppSort.FromJson("popular_today");
			Assert.That(varPopularToday, Is.EqualTo(AppSort.PopularToday));
			var varVisitors = AppSort.FromJson("visitors");
			Assert.That(varVisitors, Is.EqualTo(AppSort.Visitors));
			var varCreateDate = AppSort.FromJson("create_date");
			Assert.That(varCreateDate, Is.EqualTo(AppSort.CreateDate));
			var varGrowthRate = AppSort.FromJson("growth_rate");
			Assert.That(varGrowthRate, Is.EqualTo(AppSort.GrowthRate));
			var varPopularWeek = AppSort.FromJson("popular_week");
			Assert.That(varPopularWeek, Is.EqualTo(AppSort.PopularWeek));
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
			var varAll = Privacy.FromJson("all");
			Assert.That(varAll, Is.EqualTo(Privacy.All));
			var varFriends = Privacy.FromJson("friends");
			Assert.That(varFriends, Is.EqualTo(Privacy.Friends));
			var varFriendsOfFriends = Privacy.FromJson("friends_of_friends");
			Assert.That(varFriendsOfFriends, Is.EqualTo(Privacy.FriendsOfFriends));
			var varFriendsOfFriendsOnly = Privacy.FromJson("friends_of_friends_only");
			Assert.That(varFriendsOfFriendsOnly, Is.EqualTo(Privacy.FriendsOfFriendsOnly));
			var varNobody = Privacy.FromJson("nobody");
			Assert.That(varNobody, Is.EqualTo(Privacy.Nobody));
			var varOnlyMe = Privacy.FromJson("only_me");
			Assert.That(varOnlyMe, Is.EqualTo(Privacy.OnlyMe));
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
			var varProcessing = ChangeNameStatus.FromJson("processing");
			Assert.That(varProcessing, Is.EqualTo(ChangeNameStatus.Processing));
			var varDeclined = ChangeNameStatus.FromJson("declined");
			Assert.That(varDeclined, Is.EqualTo(ChangeNameStatus.Declined));
			var varSuccess = ChangeNameStatus.FromJson("success");
			Assert.That(varSuccess, Is.EqualTo(ChangeNameStatus.Success));
			var varWasAccepted = ChangeNameStatus.FromJson("was_accepted");
			Assert.That(varWasAccepted, Is.EqualTo(ChangeNameStatus.WasAccepted));
			var varWasDeclined = ChangeNameStatus.FromJson("was_declined");
			Assert.That(varWasDeclined, Is.EqualTo(ChangeNameStatus.WasDeclined));
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
			var varEmail = Services.FromJson("email");
			Assert.That(varEmail, Is.EqualTo(Services.Email));
			var varPhone = Services.FromJson("phone");
			Assert.That(varPhone, Is.EqualTo(Services.Phone));
			var varTwitter = Services.FromJson("twitter");
			Assert.That(varTwitter, Is.EqualTo(Services.Twitter));
			var varFacebook = Services.FromJson("facebook");
			Assert.That(varFacebook, Is.EqualTo(Services.Facebook));
			var varOdnoklassniki = Services.FromJson("odnoklassniki");
			Assert.That(varOdnoklassniki, Is.EqualTo(Services.Odnoklassniki));
			var varInstagram = Services.FromJson("instagram");
			Assert.That(varInstagram, Is.EqualTo(Services.Instagram));
			var varGoogle = Services.FromJson("google");
			Assert.That(varGoogle, Is.EqualTo(Services.Google));
		}

		[Test]
        public void UserSectionTest()
        {
			// get test
			Assert.That(UserSection.Friends.ToString(), Is.EqualTo("friends"));
			Assert.That(UserSection.Subscriptions.ToString(), Is.EqualTo("subscriptions"));
			// parse test
			var varFriends = UserSection.FromJson("friends");
			Assert.That(varFriends, Is.EqualTo(UserSection.Friends));
			var varSubscriptions = UserSection.FromJson("subscriptions");
			Assert.That(varSubscriptions, Is.EqualTo(UserSection.Subscriptions));
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
			var varPost = NewsTypes.FromJson("post");
			Assert.That(varPost, Is.EqualTo(NewsTypes.Post));
			var varPhoto = NewsTypes.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(NewsTypes.Photo));
			var varPhotoTag = NewsTypes.FromJson("photo_tag");
			Assert.That(varPhotoTag, Is.EqualTo(NewsTypes.PhotoTag));
			var varWallPhoto = NewsTypes.FromJson("wall_photo");
			Assert.That(varWallPhoto, Is.EqualTo(NewsTypes.WallPhoto));
			var varFriend = NewsTypes.FromJson("friend");
			Assert.That(varFriend, Is.EqualTo(NewsTypes.Friend));
			var varNote = NewsTypes.FromJson("note");
			Assert.That(varNote, Is.EqualTo(NewsTypes.Note));
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
			var varPost = LikeObjectType.FromJson("post");
			Assert.That(varPost, Is.EqualTo(LikeObjectType.Post));
			var varComment = LikeObjectType.FromJson("comment");
			Assert.That(varComment, Is.EqualTo(LikeObjectType.Comment));
			var varPhoto = LikeObjectType.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(LikeObjectType.Photo));
			var varAudio = LikeObjectType.FromJson("audio");
			Assert.That(varAudio, Is.EqualTo(LikeObjectType.Audio));
			var varVideo = LikeObjectType.FromJson("video");
			Assert.That(varVideo, Is.EqualTo(LikeObjectType.Video));
			var varNote = LikeObjectType.FromJson("note");
			Assert.That(varNote, Is.EqualTo(LikeObjectType.Note));
			var varPhotoComment = LikeObjectType.FromJson("photo_comment");
			Assert.That(varPhotoComment, Is.EqualTo(LikeObjectType.PhotoComment));
			var varVideoComment = LikeObjectType.FromJson("video_comment");
			Assert.That(varVideoComment, Is.EqualTo(LikeObjectType.VideoComment));
			var varTopicComment = LikeObjectType.FromJson("topic_comment");
			Assert.That(varTopicComment, Is.EqualTo(LikeObjectType.TopicComment));
			var varSitePage = LikeObjectType.FromJson("sitepage");
			Assert.That(varSitePage, Is.EqualTo(LikeObjectType.SitePage));
			var varMarket = LikeObjectType.FromJson("market");
			Assert.That(varMarket, Is.EqualTo(LikeObjectType.Market));
			var varMarketComment = LikeObjectType.FromJson("market_comment");
			Assert.That(varMarketComment, Is.EqualTo(LikeObjectType.MarketComment));
		}

		[Test]
        public void PhotoAlbumTypeTest()
        {
			// get test
			Assert.That(PhotoAlbumType.Wall.ToString(), Is.EqualTo("wall"));
			Assert.That(PhotoAlbumType.Profile.ToString(), Is.EqualTo("profile"));
			Assert.That(PhotoAlbumType.Saved.ToString(), Is.EqualTo("saved"));
			// parse test
			var varWall = PhotoAlbumType.FromJson("wall");
			Assert.That(varWall, Is.EqualTo(PhotoAlbumType.Wall));
			var varProfile = PhotoAlbumType.FromJson("profile");
			Assert.That(varProfile, Is.EqualTo(PhotoAlbumType.Profile));
			var varSaved = PhotoAlbumType.FromJson("saved");
			Assert.That(varSaved, Is.EqualTo(PhotoAlbumType.Saved));
		}

		[Test]
        public void PhotoFeedTypeTest()
        {
			// get test
			Assert.That(PhotoFeedType.Photo.ToString(), Is.EqualTo("photo"));
			Assert.That(PhotoFeedType.PhotoTag.ToString(), Is.EqualTo("photo_tag"));
			// parse test
			var varPhoto = PhotoFeedType.FromJson("photo");
			Assert.That(varPhoto, Is.EqualTo(PhotoFeedType.Photo));
			var varPhotoTag = PhotoFeedType.FromJson("photo_tag");
			Assert.That(varPhotoTag, Is.EqualTo(PhotoFeedType.PhotoTag));
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
			var varOwner = WallFilter.FromJson("owner");
			Assert.That(varOwner, Is.EqualTo(WallFilter.Owner));
			var varOthers = WallFilter.FromJson("others");
			Assert.That(varOthers, Is.EqualTo(WallFilter.Others));
			var varAll = WallFilter.FromJson("all");
			Assert.That(varAll, Is.EqualTo(WallFilter.All));
			var varSuggests = WallFilter.FromJson("suggests");
			Assert.That(varSuggests, Is.EqualTo(WallFilter.Suggests));
			var varPostponed = WallFilter.FromJson("postponed");
			Assert.That(varPostponed, Is.EqualTo(WallFilter.Postponed));
		}

		[Test]
        public void CommentsSortTest()
        {
			// get test
			Assert.That(CommentsSort.Asc.ToString(), Is.EqualTo("asc"));
			Assert.That(CommentsSort.Desc.ToString(), Is.EqualTo("desc"));
			// parse test
			var varAsc = CommentsSort.FromJson("asc");
			Assert.That(varAsc, Is.EqualTo(CommentsSort.Asc));
			var varDesc = CommentsSort.FromJson("desc");
			Assert.That(varDesc, Is.EqualTo(CommentsSort.Desc));
		}

		[Test]
        public void DisplayTest()
        {
			// get test
			Assert.That(Display.Page.ToString(), Is.EqualTo("page"));
			Assert.That(Display.Popup.ToString(), Is.EqualTo("popup"));
			Assert.That(Display.Wap.ToString(), Is.EqualTo("wap"));
			// parse test
			var varPage = Display.FromJson("page");
			Assert.That(varPage, Is.EqualTo(Display.Page));
			var varPopup = Display.FromJson("popup");
			Assert.That(varPopup, Is.EqualTo(Display.Popup));
			var varWap = Display.FromJson("wap");
			Assert.That(varWap, Is.EqualTo(Display.Wap));
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
			var varIdAsc = GroupsSort.FromJson("id_asc");
			Assert.That(varIdAsc, Is.EqualTo(GroupsSort.IdAsc));
			var varIdDesc = GroupsSort.FromJson("id_desc");
			Assert.That(varIdDesc, Is.EqualTo(GroupsSort.IdDesc));
			var varTimeAsc = GroupsSort.FromJson("time_asc");
			Assert.That(varTimeAsc, Is.EqualTo(GroupsSort.TimeAsc));
			var varTimeDesc = GroupsSort.FromJson("time_desc");
			Assert.That(varTimeDesc, Is.EqualTo(GroupsSort.TimeDesc));
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
			var varPage = GroupType.FromJson("page");
			Assert.That(varPage, Is.EqualTo(GroupType.Page));
			var varGroup = GroupType.FromJson("group");
			Assert.That(varGroup, Is.EqualTo(GroupType.Group));
			var varEvent = GroupType.FromJson("event");
			Assert.That(varEvent, Is.EqualTo(GroupType.Event));
			var varUndefined = GroupType.FromJson("undefined");
			Assert.That(varUndefined, Is.EqualTo(GroupType.Undefined));
		}

		[Test]
        public void LinkAccessTypeTest()
        {
			// get test
			Assert.That(LinkAccessType.NotBanned.ToString(), Is.EqualTo("not_banned"));
			Assert.That(LinkAccessType.Banned.ToString(), Is.EqualTo("banned"));
			Assert.That(LinkAccessType.Processing.ToString(), Is.EqualTo("processing"));
			// parse test
			var varNotBanned = LinkAccessType.FromJson("not_banned");
			Assert.That(varNotBanned, Is.EqualTo(LinkAccessType.NotBanned));
			var varBanned = LinkAccessType.FromJson("banned");
			Assert.That(varBanned, Is.EqualTo(LinkAccessType.Banned));
			var varProcessing = LinkAccessType.FromJson("processing");
			Assert.That(varProcessing, Is.EqualTo(LinkAccessType.Processing));
		}

		[Test]
        public void FriendsOrderTest()
        {
			// get test
			Assert.That(FriendsOrder.Name.ToString(), Is.EqualTo("name"));
			Assert.That(FriendsOrder.Hints.ToString(), Is.EqualTo("hints"));
			Assert.That(FriendsOrder.Random.ToString(), Is.EqualTo("random"));
			// parse test
			var varName = FriendsOrder.FromJson("name");
			Assert.That(varName, Is.EqualTo(FriendsOrder.Name));
			var varHints = FriendsOrder.FromJson("hints");
			Assert.That(varHints, Is.EqualTo(FriendsOrder.Hints));
			var varRandom = FriendsOrder.FromJson("random");
			Assert.That(varRandom, Is.EqualTo(FriendsOrder.Random));
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
			var varNom = NameCase.FromJson("nom");
			Assert.That(varNom, Is.EqualTo(NameCase.Nom));
			var varGen = NameCase.FromJson("gen");
			Assert.That(varGen, Is.EqualTo(NameCase.Gen));
			var varDat = NameCase.FromJson("dat");
			Assert.That(varDat, Is.EqualTo(NameCase.Dat));
			var varAcc = NameCase.FromJson("acc");
			Assert.That(varAcc, Is.EqualTo(NameCase.Acc));
			var varIns = NameCase.FromJson("ins");
			Assert.That(varIns, Is.EqualTo(NameCase.Ins));
			var varAbl = NameCase.FromJson("abl");
			Assert.That(varAbl, Is.EqualTo(NameCase.Abl));
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
			var varPorn = ReportType.FromJson("porn");
			Assert.That(varPorn, Is.EqualTo(ReportType.Porn));
			var varSpam = ReportType.FromJson("spam");
			Assert.That(varSpam, Is.EqualTo(ReportType.Spam));
			var varInsult = ReportType.FromJson("insult");
			Assert.That(varInsult, Is.EqualTo(ReportType.Insult));
			var varAdvertisment = ReportType.FromJson("advertisment");
			Assert.That(varAdvertisment, Is.EqualTo(ReportType.Advertisment));
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
			var varVk = PostSourceType.FromJson("vk");
			Assert.That(varVk, Is.EqualTo(PostSourceType.Vk));
			var varWidget = PostSourceType.FromJson("widget");
			Assert.That(varWidget, Is.EqualTo(PostSourceType.Widget));
			var varApi = PostSourceType.FromJson("api");
			Assert.That(varApi, Is.EqualTo(PostSourceType.Api));
			var varRss = PostSourceType.FromJson("rss");
			Assert.That(varRss, Is.EqualTo(PostSourceType.Rss));
			var varSms = PostSourceType.FromJson("sms");
			Assert.That(varSms, Is.EqualTo(PostSourceType.Sms));
		}

		[Test]
        public void OccupationTypeTest()
        {
			// get test
			Assert.That(OccupationType.Work.ToString(), Is.EqualTo("work"));
			Assert.That(OccupationType.School.ToString(), Is.EqualTo("school"));
			Assert.That(OccupationType.University.ToString(), Is.EqualTo("university"));
			// parse test
			var varWork = OccupationType.FromJson("work");
			Assert.That(varWork, Is.EqualTo(OccupationType.Work));
			var varSchool = OccupationType.FromJson("school");
			Assert.That(varSchool, Is.EqualTo(OccupationType.School));
			var varUniversity = OccupationType.FromJson("university");
			Assert.That(varUniversity, Is.EqualTo(OccupationType.University));
		}

	}
}

