using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Account;

public class AccountChangePasswordTests : CategoryBaseTest
{
	protected override string Folder => "Account";

	[Test]
	[DisplayName("Change password")]
	public void ChangePassword()
	{
		Url = "https://api.vk.ru/method/account.changePassword";

		ReadCategoryJsonPath(nameof(Api.Account.ChangePassword));

		var result = Api.Account.ChangePassword("old", "new");

		result.Token.Should()
			.Be("token");
	}
}