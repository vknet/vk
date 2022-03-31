using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class GetOnlineStatusTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void GetOnlineStatus()
		{
			Url = "https://api.vk.com/method/groups.getOnlineStatus";

			ReadCategoryJsonPath(nameof(GetOnlineStatus));

			var result = Api.Groups.GetOnlineStatus(123456);

			result.Status.Should().Be(OnlineStatusType.None);
		}
	}
}