using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetOfficeUsersTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetOfficeUsers()
	{
		Url = "https://api.vk.com/method/ads.getOfficeUsers";

		ReadCategoryJsonPath(nameof(Api.Ads.GetOfficeUsers));

		var result = Api.Ads.GetOfficeUsers(123213);

		result[0]
			.UserId.Should()
			.Be(504736359);

		result[0]
			.Accesses[0]
			.Role.Should()
			.Be(AccessRole.Admin);
	}
}