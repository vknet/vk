using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Account
{
	[TestFixture]

	public class AccountChangePasswordTests : CategoryBaseTest
	{
		protected override string Folder => "Account";

		[Test]
		public void ChangePassword()
		{
			Url = "https://api.vk.com/method/account.changePassword";

			ReadCategoryJsonPath(nameof(Api.Account.ChangePassword));

			var result = Api.Account.ChangePassword("old", "new");
			result.Token.Should().Be("token");
		}
	}
}