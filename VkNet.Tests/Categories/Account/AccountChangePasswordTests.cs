using NUnit.Framework;

namespace VkNet.Tests.Categories
{
	public class AccountChangePasswordTests : BaseTest
	{
		[Test]
		public void ChangePassword()
		{
			Url = "https://api.vk.com/method/account.changePassword";
			Json = @"{
				'response': {
					'token': 'token',
					'secret': 'secret'
				}
			}";
			var result = Api.Account.ChangePassword("old", "new");
			Assert.That(result.Token, Is.EqualTo("token"));
		}
	}
}