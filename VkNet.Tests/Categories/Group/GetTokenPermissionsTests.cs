using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class GetTokenPermissionsTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
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