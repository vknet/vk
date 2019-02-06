using System;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests.Utils
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
		public void GetPageType_LoginPassword()
		{
			var url = new Uri(
				"http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140488159&v=&state=&display=wap&m=4&email=mail");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.LoginPassword, result);
		}

		[Test]
		public void GetPageType_LoginPassword_AfterIncorrectEnter()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140488159&v=&state=&display=wap&m=4&email=mail");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.LoginPassword, result);
		}

		[Test]
		public void GetPageType_Captcha()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140488159&v=&state=&display=wap&sid=462572155651&dif=1&email=inyutin_maxim%40mail.ru");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Captcha, result);
		}

		[Test]
		public void GetPageType_Captcha_AfterIncorrectEnter()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140488159&v=&state=&display=wap&sid=856703151954&dif=1&email=inyutin_maxim%40mail.ru&m=5");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Captcha, result);
		}

		[Test]
		public void GetPageType_TwoFactor()
		{
			var url = new Uri("https://m.vk.com/login?act=authcheck&api_hash=api_hash");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.TwoFactor, result);
		}

		[Test]
		public void GetPageType_TwoFactor_AfterIncorrectEnter()
		{
			var url = new Uri("https://m.vk.com/login?act=authcheck&m=442");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.TwoFactor, result);
		}

		[Test]
		public void GetPageType_Result()
		{
			var url = new Uri("https://oauth.vk.com/blank.html#access_token=access_token&expires_in=86400&user_id=32190123");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Result, result);
		}

		[Test]
		public void GetPageType_Consent()
		{
			var url = new Uri(
				"https://oauth.vk.com/authorize?client_id=4268118&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=140426399&v=&state=&display=wap&__q_hash=30b8b543bbe64e35a9f740ca24f57f12");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Consent, result);
		}

		[Test]
		public void GetPageType_Error()
		{
			var url = new Uri(
				"https://oauth.vk.com/blank.html#error=access_denied&error_reason=user_denied&error_description=User%20denied%20your%20request");

			var auth = new ImplicitFlowVkAuthorization();
			var result = auth.GetPageType(url);

			Assert.AreEqual(ImplicitFlowPageType.Error, result);
		}
	}
}