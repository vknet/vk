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
}