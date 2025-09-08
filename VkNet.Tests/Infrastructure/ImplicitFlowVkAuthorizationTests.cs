using System;
using AwesomeAssertions;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using Xunit;

namespace VkNet.Tests.Infrastructure;

public class ImplicitFlowVkAuthorizationTests
{
	[Fact(DisplayName = "Get authorization result")]
	public void GetAuthorizationResult()
	{
		var url = new Uri("https://oauth.vk.ru/blank.html#access_token=access_token&expires_in=86400&user_id=32190123&state=123");

		var auth = new ImplicitFlowVkAuthorization();

		var authorizationResult = auth.GetAuthorizationResult(url);

		authorizationResult.Should()
			.NotBeNull();

		authorizationResult.State.Should()
			.Be("123");

		authorizationResult.UserId.Should()
			.Be(32190123);

		authorizationResult.ExpiresIn.Should()
			.Be(86400);

		authorizationResult.AccessToken.Should()
			.Be("access_token");
	}

	[Fact(DisplayName = "Get authorization result vk authorization exception")]
	public void GetAuthorizationResult_VkAuthorizationException()
	{
		var url = new Uri("https://m.vk.ru/login?act=authcheck&m=442");

		var auth = new ImplicitFlowVkAuthorization();

		FluentActions.Invoking(() => auth.GetAuthorizationResult(url))
			.Should()
			.ThrowExactly<VkAuthorizationException>();
	}

	[Fact(DisplayName = "Get page type captcha")]
	public void GetPageType_Captcha()
	{
		var url = new Uri(
			"https://oauth.vk.ru/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.ru%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&sid=644558728730&dif=1&email=inyutin_maxim%40mail.ru");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.Captcha);
	}

	[Fact(DisplayName = "Get page type captcha after incorrect enter")]
	public void GetPageType_Captcha_AfterIncorrectEnter()
	{
		var url = new Uri(
			"https://oauth.vk.ru/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.ru%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&sid=955166290951&dif=1&email=inyutin_maxim%40mail.ru&m=5");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.Captcha);
	}

	[Fact(DisplayName = "Get page type consent")]
	public void GetPageType_Consent()
	{
		var url = new Uri(
			"https://oauth.vk.ru/authorize?client_id=4268118&scope=140492255&redirect_uri=https%3A%2F%2Foauth.vk.ru%2Fblank.html&response_type=token&token_type=0&state=123&display=mobile&__q_hash=d358748186f6c31d9f249769b7b4d619");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.Consent);
	}

	[Fact(DisplayName = "Get page type error")]
	public void GetPageType_Error()
	{
		var url = new Uri(
			"https://oauth.vk.ru/blank.html#error=access_denied&error_reason=user_denied&error_description=User%20denied%20your%20request&state=123");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.Error);
	}

	[Fact(DisplayName = "Get page type login password")]
	public void GetPageType_LoginPassword()
	{
		var url = new Uri(
			"https://oauth.vk.ru/authorize?client_id=4268118&redirect_uri=https://oauth.vk.ru/blank.html&display=mobile&scope=140492255&response_type=token&v=5.92&state=123&revoke=1");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.LoginPassword);
	}

	[Fact(DisplayName = "Get page type login password after incorrect enter")]
	public void GetPageType_LoginPassword_AfterIncorrectEnter()
	{
		var url = new Uri(
			"https://oauth.vk.ru/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.ru%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&m=4&email=");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.LoginPassword);
	}

	[Fact(DisplayName = "Get page type result")]
	public void GetPageType_Result()
	{
		var url = new Uri(
			"https://oauth.vk.ru/blank.html#access_token=access_token&expires_in=0&user_id=32190123&email=inyutin_maxim@mail.ru&state=123");

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.Result);
	}

	[Theory(DisplayName = "Get page type two factor")]
	[InlineData("https://m.vk.ru/login?act=authcheck&api_hash=api_hash")]
	[InlineData("https://m.vk.ru:443/login?act=authcheck&api_hash=api_hash")]
	public void GetPageType_TwoFactor(string uriString)
	{
		var url = new Uri(uriString);

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.TwoFactor);
	}

	[Theory(DisplayName = "Get page type two factor after incorrect enter")]
	[InlineData("https://m.vk.ru/login?act=authcheck&m=442")]
	[InlineData("https://m.vk.ru:443/login?act=authcheck&m=442")]
	public void GetPageType_TwoFactor_AfterIncorrectEnter(string uriString)
	{
		var url = new Uri(uriString);

		var auth = new ImplicitFlowVkAuthorization();
		var result = auth.GetPageType(url);

		result.Should()
			.Be(ImplicitFlowPageType.TwoFactor);
	}
}