using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GroupGetBannedTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void GetBanned_Profile()
	{
		Url = "https://api.vk.com/method/groups.getBanned";

		ReadCategoryJsonPath(nameof(GetBanned_Profile));

		var banned = Api.Groups.GetBanned(65968111, null, 3);

		banned.Should()
			.NotBeNull();

		banned.Should()
			.ContainSingle();

		var user = banned.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Type.Should()
			.Be(SearchResultType.Profile);

		user.Profile.Should()
			.NotBeNull();

		user.Group.Should()
			.BeNull();

		user.BanInfo.Should()
			.NotBeNull();

		user.BanInfo.AdminId.Should()
			.Be(32190123);

		user.BanInfo.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1516980336));

		user.BanInfo.Reason.Should()
			.Be(BanReason.Other);

		user.BanInfo.Comment.Should()
			.Be("для теста");

		user.BanInfo.EndDate.Should()
			.Be(DateHelper.TimeStampToDateTime(1517585141));
	}

	[Fact]
	public void GetBanned_Group()
	{
		Url = "https://api.vk.com/method/groups.getBanned";

		ReadCategoryJsonPath(nameof(GetBanned_Group));

		var banned = Api.Groups.GetBanned(65968111, null, 3);

		banned.Should()
			.NotBeNull();

		banned.Should()
			.ContainSingle();

		var user = banned.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Type.Should()
			.Be(SearchResultType.Group);

		user.Profile.Should()
			.BeNull();

		user.Group.Should()
			.NotBeNull();

		user.BanInfo.Should()
			.NotBeNull();

		user.BanInfo.AdminId.Should()
			.Be(32190123);

		user.BanInfo.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1516980336));

		user.BanInfo.Reason.Should()
			.Be(BanReason.Other);

		user.BanInfo.Comment.Should()
			.Be("для теста");

		user.BanInfo.EndDate.Should()
			.Be(DateHelper.TimeStampToDateTime(1517585141));
	}
}