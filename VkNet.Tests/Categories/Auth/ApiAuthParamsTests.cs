using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Categories.Auth;

public class ApiAuthParamsTests
{
	[Fact]
	public void ApiAuthParams_Empty_IsValid_ReturnsFalse()
	{
		var apiAuthParams = new ApiAuthParams();

		apiAuthParams.IsValid.Should()
			.BeFalse();
	}

	[Fact]
	public void ApiAuthParams_AccessTokenOnly_IsValid_ReturnsTrue()
	{
		var apiAuthParams = new ApiAuthParams
		{
			AccessToken = "some_token"
		};

		apiAuthParams.IsValid.Should()
			.BeTrue();
	}

	[Fact]
	public void ApiAuthParams_LoginAndPassword_AllCorrect_IsValid_ReturnsTrue()
	{
		var apiAuthParams = new ApiAuthParams
		{
			ApplicationId = 111,
			Login = "some_login",
			Password = "some_password",
			Settings = Settings.All,
			TwoFactorAuthorization = () => ""
		};

		apiAuthParams.IsValid.Should()
			.BeTrue();
	}

	[Fact]
	public void ApiAuthParams_LoginAndPasswordWithoutTwoFactor_IsValid_ReturnsFalse()
	{
		var apiAuthParams = new ApiAuthParams
		{
			ApplicationId = 111,
			Login = "some_login",
			Password = "some_password",
			Settings = Settings.All
		};

		apiAuthParams.IsValid.Should()
			.BeFalse();
	}

	[Fact]
	public void ApiAuthParams_LoginAndPasswordWithoutSettings_IsValid_ReturnsFalse()
	{
		var apiAuthParams = new ApiAuthParams
		{
			ApplicationId = 111,
			Login = "some_login",
			Password = "some_password",
			TwoFactorAuthorization = () => ""
		};

		apiAuthParams.IsValid.Should()
			.BeFalse();
	}

	[Fact]
	public void ApiAuthParams_LoginAndPasswordWithEmptySettings_IsValid_ReturnsFalse()
	{
		var apiAuthParams = new ApiAuthParams
		{
			ApplicationId = 111,
			Login = "some_login",
			Password = "some_password",
			TwoFactorAuthorization = () => "",
			Settings = new()
		};

		apiAuthParams.IsValid.Should()
			.BeFalse();
	}
}