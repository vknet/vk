using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkNet.Tests.Categories.Auth
{
	[TestFixture]
	public class ApiAuthParamsTests
	{
		[Test]
		public void ApiAuthParams_Empty_IsValid_ReturnsFalse()
		{
			var apiAuthParams = new ApiAuthParams();

			Assert.IsFalse(apiAuthParams.IsValid);
		}

		[Test]
		public void ApiAuthParams_AccessTokenOnly_IsValid_ReturnsTrue()
		{
			var apiAuthParams = new ApiAuthParams()
			{
				AccessToken = "some_token"
			};

			Assert.IsTrue(apiAuthParams.IsValid);
		}

		[Test]
		public void ApiAuthParams_LoginAndPassword_AllCorrect_IsValid_ReturnsTrue()
		{
			var apiAuthParams = new ApiAuthParams()
			{
				ApplicationId = 111,
				Login = "some_login",
				Password = "some_password",
				Settings = Settings.All,
				TwoFactorAuthorization = () => ""
			};

			Assert.IsTrue(apiAuthParams.IsValid);
		}

		[Test]
		public void ApiAuthParams_LoginAndPasswordWithoutTwoFactor_IsValid_ReturnsFalse()
		{
			var apiAuthParams = new ApiAuthParams()
			{
				ApplicationId = 111,
				Login = "some_login",
				Password = "some_password",
				Settings = Settings.All
			};

			Assert.IsFalse(apiAuthParams.IsValid);
		}

		[Test]
		public void ApiAuthParams_LoginAndPasswordWithoutSettings_IsValid_ReturnsFalse()
		{
			var apiAuthParams = new ApiAuthParams()
			{
				ApplicationId = 111,
				Login = "some_login",
				Password = "some_password",
				TwoFactorAuthorization = () => ""
			};

			Assert.IsFalse(apiAuthParams.IsValid);
		}

		[Test]
		public void ApiAuthParams_LoginAndPasswordWithEmptySettings_IsValid_ReturnsFalse()
		{
			var apiAuthParams = new ApiAuthParams()
			{
				ApplicationId = 111,
				Login = "some_login",
				Password = "some_password",
				TwoFactorAuthorization = () => "",
				Settings = new Settings()
			};

			Assert.IsFalse(apiAuthParams.IsValid);
		}
	}
}