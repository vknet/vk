using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Account;

public class AccountChangePasswordTests : CategoryBaseTest
{
	protected override string Folder => "Account";

	[Fact]
	public void ChangePassword()
	{
		Url = "https://api.vk.com/method/account.changePassword";

		ReadCategoryJsonPath(nameof(Api.Account.ChangePassword));

		var result = Api.Account.ChangePassword("old", "new");

		result.Token.Should()
			.Be("token");
	}
}