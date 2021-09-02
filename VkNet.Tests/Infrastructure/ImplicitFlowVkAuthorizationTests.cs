using System;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow;

namespace VkNet.Tests.Infrastructure
{
	[TestFixture]

	public class ImplicitFlowVkAuthorizationTests
	{
		[Test]
		public void GetAuthorizationResult()
		{
			var url = new Uri("https://oauth.vk.com/blank.html#access_token=access_token&expires_in=86400&user_id=32190123&state=123");

			var auth = new ImplicitFlowVkAuthorization();

			var authorizationResult = auth.GetAuthorizationResult(url);

			Assert.NotNull(authorizationResult);
			Assert.AreEqual("123", authorizationResult.State);
			Assert.AreEqual(32190123, authorizationResult.UserId);
			Assert.AreEqual(86400, authorizationResult.ExpiresIn);
			Assert.AreEqual("access_token", authorizationResult.AccessToken);
		}

		[Test]
		public void GetAuthorizationResult_VkAuthorizationException()
		{
			var url = new Uri("https://m.vk.com/login?act=authcheck&m=442");

			var auth = new ImplicitFlowVkAuthorization();

			Assert.Throws<VkAuthorizationException>(() => auth.GetAuthorizationResult(url));
		}

		[Test]
		public void GetPageType_Captcha()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&sid=644558728730&dif=1&email=inyutin_maxim%40mail.ru");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Captcha, result);
		}

		[Test]
		public void GetPageType_Captcha_AfterIncorrectEnter()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&sid=955166290951&dif=1&email=inyutin_maxim%40mail.ru&m=5");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Captcha, result);
		}

		[Test]
		public void GetPageType_Consent()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&scope=140492255&redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&token_type=0&state=123&display=mobile&__q_hash=d358748186f6c31d9f249769b7b4d619");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Consent, result);
		}

		[Test]
		public void GetPageType_Error()
		{
			var url = new Uri(
				"https://oauth.vk.com/blank.html#error=access_denied&error_reason=user_denied&error_description=User%20denied%20your%20request&state=123");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Error, result);
		}

		[Test]
		public void GetPageType_LoginPassword()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&redirect_uri=https://oauth.vk.com/blank.html&display=mobile&scope=140492255&response_type=token&v=5.92&state=123&revoke=1");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.LoginPassword, result);
		}

		[Test]
		public void GetPageType_LoginPassword_AfterIncorrectEnter()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&redirect_uri=https%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140492255&v=5.92&state=123&revoke=1&display=mobile&m=4&email=");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.LoginPassword, result);
		}

		[Test]
		public void GetPageType_Result()
		{
			var url = new Uri(
				"https://oauth.vk.com/blank.html#access_token=access_token&expires_in=0&user_id=32190123&email=inyutin_maxim@mail.ru&state=123");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Result, result);
		}

		[Test]
		[TestCase("https://m.vk.com/login?act=authcheck&api_hash=api_hash")]
		[TestCase("https://m.vk.com:443/login?act=authcheck&api_hash=api_hash")]
		public void GetPageType_TwoFactor(string uriString)
		{
			var url = new Uri(uriString);

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.TwoFactor, result);
		}

		[Test]
		[TestCase("https://m.vk.com/login?act=authcheck&m=442")]
		[TestCase("https://m.vk.com:443/login?act=authcheck&m=442")]
		public void GetPageType_TwoFactor_AfterIncorrectEnter(string uriString)
		{
			var url = new Uri(uriString);

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.TwoFactor, result);
		}
	}
}