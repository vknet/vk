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
}