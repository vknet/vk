using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetOfficeUsersTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetOfficeUsers()
		{
			Url = "https://api.vk.com/method/ads.getOfficeUsers";

			ReadCategoryJsonPath(nameof(Api.Ads.GetOfficeUsers));

			var result = Api.Ads.GetOfficeUsers(123213);
			result[0].UserId.Should().Be(504736359);
			result[0].Accesses[0].Role.Should().Be(AccessRole.Admin);
		}
	}
}