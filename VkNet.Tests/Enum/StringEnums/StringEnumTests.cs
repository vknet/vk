using FluentAssertions;
using VkNet.Enums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Enum.StringEnums;

public class StringEnumTests
{
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
	public void UserSectionTest()
	{
		Utilities.Deserialize<UserSection>("friends")
			.Should()
			.Be(UserSection.Friends);

		Utilities.Deserialize<UserSection>("subscriptions")
			.Should()
			.Be(UserSection.Subscriptions);
	}

	[Fact]
	public void AppPlatformsTest()
	{
		Utilities.Deserialize<AppPlatforms>("ios")
			.Should()
			.Be(AppPlatforms.Ios);

		Utilities.Deserialize<AppPlatforms>("android")
			.Should()
			.Be(AppPlatforms.Android);

		Utilities.Deserialize<AppPlatforms>("winphone")
			.Should()
			.Be(AppPlatforms.WinPhone);

		Utilities.Deserialize<AppPlatforms>("web")
			.Should()
			.Be(AppPlatforms.Web);
	}

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
	public void VideoCatalogFiltersTest()
	{
		Utilities.Deserialize<VideoCatalogFilters>("ugc")
			.Should()
			.Be(VideoCatalogFilters.Ugc);

		Utilities.Deserialize<VideoCatalogFilters>("top")
			.Should()
			.Be(VideoCatalogFilters.Top);

		Utilities.Deserialize<VideoCatalogFilters>("feed")
			.Should()
			.Be(VideoCatalogFilters.Feed);

		Utilities.Deserialize<VideoCatalogFilters>("series")
			.Should()
			.Be(VideoCatalogFilters.Series);

		Utilities.Deserialize<VideoCatalogFilters>("other")
			.Should()
			.Be(VideoCatalogFilters.Other);
	}

	[Fact]
	public void VideoAdsSectionTest()
	{
		Utilities.Deserialize<VideoAdsSection>("preroll")
			.Should()
			.Be(VideoAdsSection.Preroll);

		Utilities.Deserialize<VideoAdsSection>("midroll")
			.Should()
			.Be(VideoAdsSection.Midroll);

		Utilities.Deserialize<VideoAdsSection>("postroll")
			.Should()
			.Be(VideoAdsSection.Postroll);
	}

	[Fact]
	public void VideoViewTest()
	{
		Utilities.Deserialize<VideoView>("horizontal")
			.Should()
			.Be(VideoView.Horizontal);

		Utilities.Deserialize<VideoView>("horizontal_compact")
			.Should()
			.Be(VideoView.HorizontalCompact);

		Utilities.Deserialize<VideoView>("vertical")
			.Should()
			.Be(VideoView.Vertical);

		Utilities.Deserialize<VideoView>("vertical_compact")
			.Should()
			.Be(VideoView.VerticalCompact);
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
	public void AppWidgetImageTypeTest()
	{
		Utilities.Deserialize<AppWidgetImageType>("24x24")
			.Should()
			.Be(AppWidgetImageType.TwentyFourOnTwentyFour);

		Utilities.Deserialize<AppWidgetImageType>("24x24").Should()
			.Be(AppWidgetImageType.TwentyFourOnTwentyFour);

		Utilities.Deserialize<AppWidgetImageType>("50x50").Should()
			.Be(AppWidgetImageType.FiftyOnFifty);

		Utilities.Deserialize<AppWidgetImageType>("160x160").Should()
			.Be(AppWidgetImageType.OneHundredAndSixtyOnOneHundredAndSixty);

		Utilities.Deserialize<AppWidgetImageType>("160x240").Should()
			.Be(AppWidgetImageType.OneHundredAndSixtyOnTwoHundredAndForty);

		Utilities.Deserialize<AppWidgetImageType>("510x128").Should()
			.Be(AppWidgetImageType.FiveHundredAndTenOnOneHundredAndTwentyEight);
	}

	[Fact]
	public void AdsLinkTypeTest()
	{
		Utilities.Deserialize<AdsLinkType>("application").Should()
			.Be(AdsLinkType.Application);

		Utilities.Deserialize<AdsLinkType>("community").Should()
			.Be(AdsLinkType.Community);

		Utilities.Deserialize<AdsLinkType>("post").Should()
			.Be(AdsLinkType.Post);

		Utilities.Deserialize<AdsLinkType>("video").Should()
			.Be(AdsLinkType.Video);

		Utilities.Deserialize<AdsLinkType>("site").Should()
			.Be(AdsLinkType.Site);
	}

	[Fact]
	public void AdPlatformTest()
	{
		Utilities.Deserialize<AdPlatform>("0").Should()
			.Be(AdPlatform.VkAndPartners);

		Utilities.Deserialize<AdPlatform>("1").Should()
			.Be(AdPlatform.VkOnly);

		Utilities.Deserialize<AdPlatform>("all").Should()
			.Be(AdPlatform.All);

		Utilities.Deserialize<AdPlatform>("desktop").Should()
			.Be(AdPlatform.Desktop);

		Utilities.Deserialize<AdPlatform>("mobile").Should()
			.Be(AdPlatform.Mobile);
	}

	[Fact]
	public void AccountTypeTest()
	{
		Utilities.Deserialize<AccountType>("agency").Should()
			.Be(AccountType.Agency);

		Utilities.Deserialize<AccountType>("general").Should()
			.Be(AccountType.General);
	}

	[Fact]
	public void AdRequestStatusTest()
	{
		Utilities.Deserialize<AdRequestStatus>("search_done").Should()
			.Be(AdRequestStatus.SearchDone);

		Utilities.Deserialize<AdRequestStatus>("search_in_progress").Should()
			.Be(AdRequestStatus.SearchInProgress);

		Utilities.Deserialize<AdRequestStatus>("search_failed").Should()
			.Be(AdRequestStatus.SearchFailed);

		Utilities.Deserialize<AdRequestStatus>("save_done").Should()
			.Be(AdRequestStatus.SaveDone);

		Utilities.Deserialize<AdRequestStatus>("save_in_progress").Should()
			.Be(AdRequestStatus.SaveInProgress);

		Utilities.Deserialize<AdRequestStatus>("save_failed").Should()
			.Be(AdRequestStatus.SaveFailed);
	}

	[Fact]
	public void AccessRoleTest()
	{
		Utilities.Deserialize<AccessRole>("admin").Should()
			.Be(AccessRole.Admin);

		Utilities.Deserialize<AccessRole>("manager").Should()
			.Be(AccessRole.Manager);

		Utilities.Deserialize<AccessRole>("reports").Should()
			.Be(AccessRole.Reports);
	}

	[Fact]
	public void AppWidgetTypeTest()
	{
		Utilities.Deserialize<AppWidgetType>("donation").Should()
			.Be(AppWidgetType.Donation);

		Utilities.Deserialize<AppWidgetType>("list").Should()
			.Be(AppWidgetType.List);

		Utilities.Deserialize<AppWidgetType>("match").Should()
			.Be(AppWidgetType.Match);

		Utilities.Deserialize<AppWidgetType>("matches").Should()
			.Be(AppWidgetType.Matches);

		Utilities.Deserialize<AppWidgetType>("table").Should()
			.Be(AppWidgetType.Table);

		Utilities.Deserialize<AppWidgetType>("text").Should()
			.Be(AppWidgetType.Text);

		Utilities.Deserialize<AppWidgetType>("tiles").Should()
			.Be(AppWidgetType.Tiles);

		Utilities.Deserialize<AppWidgetType>("compact_list").Should()
			.Be(AppWidgetType.CompactList);

		Utilities.Deserialize<AppWidgetType>("cover_list").Should()
			.Be(AppWidgetType.CoverList);
	}
}