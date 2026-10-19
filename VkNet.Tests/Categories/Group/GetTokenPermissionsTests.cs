using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group;

public class GetTokenPermissionsTests : CategoryBaseTest
{
	protected override string Folder => "Groups";

	[Test]
	[DisplayName("Get token permissions")]
	public void GetTokenPermissions()
	{
		Url = "https://api.vk.ru/method/groups.getTokenPermissions";

		ReadCategoryJsonPath(nameof(GetTokenPermissions));

		var result = Api.Groups.GetTokenPermissions();

		result.Mask.Should()
			.Be(274432);

		result.Permissions.Should()
			.NotBeEmpty();
	}
}