using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group
{


	public class GetTokenPermissionsTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Fact]
		public void GetTokenPermissions()
		{
			Url = "https://api.vk.com/method/groups.getTokenPermissions";

			ReadCategoryJsonPath(nameof(GetTokenPermissions));

			var result = Api.Groups.GetTokenPermissions();

			result.Mask.Should().Be(274432);
			result.Permissions.Should().NotBeEmpty();
		}
	}
}