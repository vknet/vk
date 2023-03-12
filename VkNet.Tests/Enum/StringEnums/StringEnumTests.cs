using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Enum.StringEnums;

public class StringEnumTests
{
	[Fact]
	public void VideoCatalogTypeTest()
	{
		Utilities.Deserialize<VideoCatalogType>("channel")
			.Should()
			.Be(VideoCatalogType.Channel);

		Utilities.Deserialize<VideoCatalogType>("category")
			.Should()
			.Be(VideoCatalogType.Category);
	}

	[Fact]
	public void WallFilterTest()
	{
		Utilities.Deserialize<WallFilter>("owner")
			.Should()
			.Be(WallFilter.Owner);

		Utilities.Deserialize<WallFilter>("others")
			.Should()
			.Be(WallFilter.Others);

		Utilities.Deserialize<WallFilter>("all")
			.Should()
			.Be(WallFilter.All);

		Utilities.Deserialize<WallFilter>("suggests")
			.Should()
			.Be(WallFilter.Suggests);

		Utilities.Deserialize<WallFilter>("postponed")
			.Should()
			.Be(WallFilter.Postponed);
	}

	[Fact]
	public void AppRatingTypeTest()
	{
		Utilities.Deserialize<AppRatingType>("level")
			.Should()
			.Be(AppRatingType.Level);

		Utilities.Deserialize<AppRatingType>("points")
			.Should()
			.Be(AppRatingType.Points);
	}

	[Fact]
	public void GroupsSortTest()
	{
		Utilities.Deserialize<GroupsSort>("id_asc")
			.Should()
			.Be(GroupsSort.IdAsc);

		Utilities.Deserialize<GroupsSort>("id_desc")
			.Should()
			.Be(GroupsSort.IdDesc);

		Utilities.Deserialize<GroupsSort>("time_asc")
			.Should()
			.Be(GroupsSort.TimeAsc);

		Utilities.Deserialize<GroupsSort>("time_desc")
			.Should()
			.Be(GroupsSort.TimeDesc);
	}

	[Fact]
	public void LinkAccessTypeTest()
	{
		Utilities.Deserialize<LinkAccessType>("not_banned")
			.Should()
			.Be(LinkAccessType.NotBanned);

		Utilities.Deserialize<LinkAccessType>("banned")
			.Should()
			.Be(LinkAccessType.Banned);

		Utilities.Deserialize<LinkAccessType>("processing")
			.Should()
			.Be(LinkAccessType.Processing);
	}

	[Fact]
	public void VideoCatalogItemTypeTest()
	{
		Utilities.Deserialize<VideoCatalogItemType>("video")
			.Should()
			.Be(VideoCatalogItemType.Video);

		Utilities.Deserialize<VideoCatalogItemType>("album")
			.Should()
			.Be(VideoCatalogItemType.Album);
	}

	[Fact]
	public void GroupTypeTest()
	{
		// get test
		GroupType.Page.ToString().ToSnakeCase()
			.Should()
			.Be("page");

		GroupType.Group.ToString().ToSnakeCase()
			.Should()
			.Be("group");

		GroupType.Event.ToString().ToSnakeCase()
			.Should()
			.Be("event");

		GroupType.Undefined.ToString().ToSnakeCase()
			.Should()
			.Be("undefined");

		// parse test
		Utilities.Deserialize<GroupType>("page")
			.Should()
			.Be(GroupType.Page);

		Utilities.Deserialize<GroupType>("group")
			.Should()
			.Be(GroupType.Group);

		Utilities.Deserialize<GroupType>("event")
			.Should()
			.Be(GroupType.Event);

		Utilities.Deserialize<GroupType>("undefined")
			.Should()
			.Be(GroupType.Undefined);
	}

	[Fact]
	public void DeactivatedTest()
	{
		// get test
		Deactivated.Deleted.ToString().ToSnakeCase()
			.Should()
			.Be("deleted");

		Deactivated.Banned.ToString().ToSnakeCase()
			.Should()
			.Be("banned");

		Deactivated.Activated.ToString().ToSnakeCase()
			.Should()
			.Be("activated");

		// parse test
		Utilities.Deserialize<Deactivated>("deleted")
			.Should()
			.Be(Deactivated.Deleted);

		Utilities.Deserialize<Deactivated>("banned")
			.Should()
			.Be(Deactivated.Banned);

		Utilities.Deserialize<Deactivated>("activated")
			.Should()
			.Be(Deactivated.Activated);
	}

	[Fact]
	public void UserSectionTest()
	{
		// get test
		UserSection.Friends.ToString().ToSnakeCase()
			.Should()
			.Be("friends");

		UserSection.Subscriptions.ToString().ToSnakeCase()
			.Should()
			.Be("subscriptions");

		// parse test
		Utilities.Deserialize<UserSection>("friends")
			.Should()
			.Be(UserSection.Friends);

		Utilities.Deserialize<UserSection>("subscriptions")
			.Should()
			.Be(UserSection.Subscriptions);
	}

	[Fact]
	public void TranscriptStatesTest()
	{
		// get test
		TranscriptStates.Done.ToString().ToSnakeCase()
			.Should()
			.Be("done");

		TranscriptStates.InProgress.ToString().ToSnakeCase()
			.Should()
			.Be("in_progress");

		// parse test
		Utilities.Deserialize<TranscriptStates>("done")
			.Should()
			.Be(TranscriptStates.Done);

		Utilities.Deserialize<TranscriptStates>("in_progress")
			.Should()
			.Be(TranscriptStates.InProgress);
	}

	[Fact]
	public void StoryObjectStateTest()
	{
		// get test
		StoryObjectState.Hidden.ToString().ToSnakeCase()
			.Should()
			.Be("hidden");

		StoryObjectState.On.ToString().ToSnakeCase()
			.Should()
			.Be("on");

		StoryObjectState.Off.ToString().ToSnakeCase()
			.Should()
			.Be("off");

		// parse test
		Utilities.Deserialize<StoryObjectState>("hidden")
			.Should()
			.Be(StoryObjectState.Hidden);

		Utilities.Deserialize<StoryObjectState>("on")
			.Should()
			.Be(StoryObjectState.On);

		Utilities.Deserialize<StoryObjectState>("off")
			.Should()
			.Be(StoryObjectState.Off);
	}

	[Fact]
	public void StoryLinkTextTest()
	{
		// get test
		StoryLinkText.Book.ToString().ToSnakeCase()
			.Should()
			.Be("book");

		StoryLinkText.Buy.ToString().ToSnakeCase()
			.Should()
			.Be("buy");

		StoryLinkText.Contact.ToString().ToSnakeCase()
			.Should()
			.Be("contact");

		StoryLinkText.Enroll.ToString().ToSnakeCase()
			.Should()
			.Be("enroll");

		StoryLinkText.Fill.ToString().ToSnakeCase()
			.Should()
			.Be("fill");

		StoryLinkText.GoTo.ToString().ToSnakeCase()
			.Should()
			.Be("go_to");

		StoryLinkText.Install.ToString().ToSnakeCase()
			.Should()
			.Be("install");

		StoryLinkText.LearnMore.ToString().ToSnakeCase()
			.Should()
			.Be("learn_more");

		StoryLinkText.More.ToString().ToSnakeCase()
			.Should()
			.Be("more");

		StoryLinkText.Open.ToString().ToSnakeCase()
			.Should()
			.Be("open");

		StoryLinkText.Order.ToString().ToSnakeCase()
			.Should()
			.Be("order");

		StoryLinkText.Play.ToString().ToSnakeCase()
			.Should()
			.Be("play");

		StoryLinkText.Read.ToString().ToSnakeCase()
			.Should()
			.Be("read");

		StoryLinkText.Signup.ToString().ToSnakeCase()
			.Should()
			.Be("signup");

		StoryLinkText.View.ToString().ToSnakeCase()
			.Should()
			.Be("view");

		StoryLinkText.Vote.ToString().ToSnakeCase()
			.Should()
			.Be("vote");

		StoryLinkText.Watch.ToString().ToSnakeCase()
			.Should()
			.Be("watch");

		StoryLinkText.Write.ToString().ToSnakeCase()
			.Should()
			.Be("write");

		// parse test
		Utilities.Deserialize<StoryLinkText>("book")
			.Should()
			.Be(StoryLinkText.Book);

		Utilities.Deserialize<StoryLinkText>("buy")
			.Should()
			.Be(StoryLinkText.Buy);

		Utilities.Deserialize<StoryLinkText>("contact")
			.Should()
			.Be(StoryLinkText.Contact);

		Utilities.Deserialize<StoryLinkText>("enroll")
			.Should()
			.Be(StoryLinkText.Enroll);

		Utilities.Deserialize<StoryLinkText>("fill")
			.Should()
			.Be(StoryLinkText.Fill);

		Utilities.Deserialize<StoryLinkText>("go_to")
			.Should()
			.Be(StoryLinkText.GoTo);

		Utilities.Deserialize<StoryLinkText>("install")
			.Should()
			.Be(StoryLinkText.Install);

		Utilities.Deserialize<StoryLinkText>("learn_more")
			.Should()
			.Be(StoryLinkText.LearnMore);

		Utilities.Deserialize<StoryLinkText>("more")
			.Should()
			.Be(StoryLinkText.More);

		Utilities.Deserialize<StoryLinkText>("open")
			.Should()
			.Be(StoryLinkText.Open);

		Utilities.Deserialize<StoryLinkText>("order")
			.Should()
			.Be(StoryLinkText.Order);

		Utilities.Deserialize<StoryLinkText>("play")
			.Should()
			.Be(StoryLinkText.Play);

		Utilities.Deserialize<StoryLinkText>("read")
			.Should()
			.Be(StoryLinkText.Read);

		Utilities.Deserialize<StoryLinkText>("signup")
			.Should()
			.Be(StoryLinkText.Signup);

		Utilities.Deserialize<StoryLinkText>("view")
			.Should()
			.Be(StoryLinkText.View);

		Utilities.Deserialize<StoryLinkText>("vote")
			.Should()
			.Be(StoryLinkText.Vote);

		Utilities.Deserialize<StoryLinkText>("watch")
			.Should()
			.Be(StoryLinkText.Watch);

		Utilities.Deserialize<StoryLinkText>("write")
			.Should()
			.Be(StoryLinkText.Write);
	}

	[Fact]
	public void ServicesTest()
	{
		// get test
		Services.Email.ToString().ToSnakeCase()
			.Should()
			.Be("email");

		Services.Phone.ToString().ToSnakeCase()
			.Should()
			.Be("phone");

		Services.Twitter.ToString().ToSnakeCase()
			.Should()
			.Be("twitter");

		Services.Facebook.ToString().ToSnakeCase()
			.Should()
			.Be("facebook");

		Services.Odnoklassniki.ToString().ToSnakeCase()
			.Should()
			.Be("odnoklassniki");

		Services.Instagram.ToString().ToSnakeCase()
			.Should()
			.Be("instagram");

		Services.Google.ToString().ToSnakeCase()
			.Should()
			.Be("google");

		// parse test
		Utilities.Deserialize<Services>("email")
			.Should()
			.Be(Services.Email);

		Utilities.Deserialize<Services>("phone")
			.Should()
			.Be(Services.Phone);

		Utilities.Deserialize<Services>("twitter")
			.Should()
			.Be(Services.Twitter);

		Utilities.Deserialize<Services>("facebook")
			.Should()
			.Be(Services.Facebook);

		Utilities.Deserialize<Services>("odnoklassniki")
			.Should()
			.Be(Services.Odnoklassniki);

		Utilities.Deserialize<Services>("instagram")
			.Should()
			.Be(Services.Instagram);

		Utilities.Deserialize<Services>("google")
			.Should()
			.Be(Services.Google);
	}

	[Fact]
	public void ReportTypeTest()
	{
		// get test
		ReportType.Porn.ToString().ToSnakeCase()
			.Should()
			.Be("porn");

		ReportType.Spam.ToString().ToSnakeCase()
			.Should()
			.Be("spam");

		ReportType.Insult.ToString().ToSnakeCase()
			.Should()
			.Be("insult");

		ReportType.Advertisment.ToString().ToSnakeCase()
			.Should()
			.Be("advertisment");

		// parse test
		Utilities.Deserialize<ReportType>("porn")
			.Should()
			.Be(ReportType.Porn);

		Utilities.Deserialize<ReportType>("spam")
			.Should()
			.Be(ReportType.Spam);

		Utilities.Deserialize<ReportType>("insult")
			.Should()
			.Be(ReportType.Insult);

		Utilities.Deserialize<ReportType>("advertisment")
			.Should()
			.Be(ReportType.Advertisment);
	}

	[Fact]
	public void RelativeTypeTest()
	{
		Utilities.Deserialize<RelativeType>("sibling")
			.Should()
			.Be(RelativeType.Sibling);

		Utilities.Deserialize<RelativeType>("parent")
			.Should()
			.Be(RelativeType.Parent);

		Utilities.Deserialize<RelativeType>("child")
			.Should()
			.Be(RelativeType.Child);

		Utilities.Deserialize<RelativeType>("grandparent")
			.Should()
			.Be(RelativeType.Grandparent);

		Utilities.Deserialize<RelativeType>("grandchild")
			.Should()
			.Be(RelativeType.Grandchild);
	}

	[Fact]
	public void PostTypeOrderTest()
	{
		Utilities.Deserialize<PostTypeOrder>("post")
			.Should()
			.Be(PostTypeOrder.Post);

		Utilities.Deserialize<PostTypeOrder>("copy")
			.Should()
			.Be(PostTypeOrder.Copy);
	}

	[Fact]
	public void PostTypeTest()
	{
		Utilities.Deserialize<PostType>("post")
			.Should()
			.Be(PostType.Post);

		Utilities.Deserialize<PostType>("copy")
			.Should()
			.Be(PostType.Copy);

		Utilities.Deserialize<PostType>("reply")
			.Should()
			.Be(PostType.Reply);

		Utilities.Deserialize<PostType>("postpone")
			.Should()
			.Be(PostType.Postpone);

		Utilities.Deserialize<PostType>("suggest")
			.Should()
			.Be(PostType.Suggest);
	}

	[Fact]
	public void PostSourceTypeTest()
	{
		Utilities.Deserialize<PostSourceType>("vk")
			.Should()
			.Be(PostSourceType.Vk);

		Utilities.Deserialize<PostSourceType>("widget")
			.Should()
			.Be(PostSourceType.Widget);

		Utilities.Deserialize<PostSourceType>("api")
			.Should()
			.Be(PostSourceType.Api);

		Utilities.Deserialize<PostSourceType>("rss")
			.Should()
			.Be(PostSourceType.Rss);

		Utilities.Deserialize<PostSourceType>("sms")
			.Should()
			.Be(PostSourceType.Sms);
	}

	[Fact]
	public void PlatformTest()
	{
		// get test
		Platform.Android.ToString().ToSnakeCase()
			.Should()
			.Be("android");

		Platform.Iphone.ToString().ToSnakeCase()
			.Should()
			.Be("iphone");

		Platform.Wphone.ToString().ToSnakeCase()
			.Should()
			.Be("wphone");

		// parse test
		Utilities.Deserialize<Platform>("android")
			.Should()
			.Be(Platform.Android);

		Utilities.Deserialize<Platform>("iphone")
			.Should()
			.Be(Platform.Iphone);

		Utilities.Deserialize<Platform>("wphone")
			.Should()
			.Be(Platform.Wphone);
	}

	[Fact]
	public void PhotoSizeTypeTest()
	{
		Utilities.Deserialize<PhotoSizeType>("s")
			.Should()
			.Be(PhotoSizeType.S);

		Utilities.Deserialize<PhotoSizeType>("m")
			.Should()
			.Be(PhotoSizeType.M);

		Utilities.Deserialize<PhotoSizeType>("x")
			.Should()
			.Be(PhotoSizeType.X);

		Utilities.Deserialize<PhotoSizeType>("o")
			.Should()
			.Be(PhotoSizeType.O);

		Utilities.Deserialize<PhotoSizeType>("p")
			.Should()
			.Be(PhotoSizeType.P);

		Utilities.Deserialize<PhotoSizeType>("q")
			.Should()
			.Be(PhotoSizeType.Q);

		Utilities.Deserialize<PhotoSizeType>("r")
			.Should()
			.Be(PhotoSizeType.R);

		Utilities.Deserialize<PhotoSizeType>("y")
			.Should()
			.Be(PhotoSizeType.Y);

		Utilities.Deserialize<PhotoSizeType>("z")
			.Should()
			.Be(PhotoSizeType.Z);

		Utilities.Deserialize<PhotoSizeType>("w")
			.Should()
			.Be(PhotoSizeType.W);
	}

	[Fact]
	public void PhotoFeedTypeTest()
	{
		Utilities.Deserialize<PhotoFeedType>("photo")
			.Should()
			.Be(PhotoFeedType.Photo);

		Utilities.Deserialize<PhotoFeedType>("photo_tag")
			.Should()
			.Be(PhotoFeedType.PhotoTag);
	}
}