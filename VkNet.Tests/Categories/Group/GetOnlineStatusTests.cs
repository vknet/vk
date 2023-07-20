using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group;

public class GetOnlineStatusTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Fact]
	public void GetOnlineStatus()
	{
		Url = "https://api.vk.com/method/groups.getOnlineStatus";

		ReadCategoryJsonPath(nameof(GetOnlineStatus));

		var result = Api.Groups.GetOnlineStatus(123456);

		result.Status.Should()
			.Be(OnlineStatusType.None);
	}
}