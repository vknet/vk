using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class VkAuthorizationTests
	{
		private const string Input =
				"http://oauth.vk.com/blank.html"
				+ "#access_token=token"
				+ "&expires_in=86400"
				+ "&user_id=32190123"
				+ "&email=inyutin_maxim@mail.ru"
				+ "&state=123456";

		[Test]
		public void Authorize_InvalidLoginOrPassword_NotAuthorizedAndAuthorizationNotRequired()
		{
			const string urlWithBadLoginOrPassword = "http://oauth.vk.com/oauth/authorize"
													+ "?client_id=1"
													+ "&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html"
													+ "&response_type=token"
													+ "&scope=2"
													+ "&v="
													+ "&state="
													+ "&display=wap"
													+ "&m=4"
													+ "&email=mail";

			var authorization = VkAuthorization.From(urlWithBadLoginOrPassword);

			Assert.IsFalse(authorization.IsAuthorized);
			Assert.IsFalse(authorization.IsAuthorizationRequired);
		}

		[Test]
		public void CorrectParseInputString()
		{
			var auth = VkAuthorization.From(Input);

			Assert.AreEqual("token"
					, auth.AccessToken);

			Assert.AreEqual(86400, auth.ExpiresIn);
			Assert.AreEqual(32190123L, auth.UserId);
		}

		[Test]
		public void GetExpiresIn_Exception()
		{
			var auth = VkAuthorization.From(Input.Replace("86400", "qwe"));

			var error = Assert.Throws<VkApiException>(() =>
			{
				var expiresIn = auth.ExpiresIn;
				Assert.NotZero(expiresIn);
			});

			Assert.AreEqual("ExpiresIn is not integer value.", error.Message);
		}

		[Test]
		public void GetUserId_Exception()
		{
			var auth = VkAuthorization.From(Input.Replace("32190123", "qwe"));

			var error = Assert.Throws<VkApiException>(() =>
			{
				var authUserId = auth.UserId;
				Assert.NotZero(authUserId);
			});

			Assert.AreEqual("UserId is not long value.", error.Message);
		}

		[Test]
		public void IsAuthorizationRequired_False()
		{
			var auth = VkAuthorization.From(Input);
			Assert.IsFalse(auth.IsAuthorizationRequired);
		}

		[Test]
		public void IsAuthorizationRequired_True()
		{
			const string uriQuery = "https://oauth.vk.com/authorize"
									+ "?client_id=4268118"
									+ "&redirect_uri=https:%2F%2Foauth.vk.com%2Fblank.html"
									+ "&response_type=token"
									+ "&scope=140426399"
									+ "&v="
									+ "&state="
									+ "&display=page"
									+ "&__q_hash=90f3ddf308ca69fca660e32b09e3617b";

			var auth = VkAuthorization.From(uriQuery);
			Assert.IsTrue(auth.IsAuthorizationRequired);
		}

		[Test]
		public void IsAuthorized_Failed()
		{
			var auth = VkAuthorization.From(Input.Replace("access_token", "qwe"));
			Assert.IsFalse(auth.IsAuthorized);
		}

		[Test]
		public void IsAuthorized_Success()
		{
			var auth = VkAuthorization.From(Input);
			Assert.IsTrue(auth.IsAuthorized);
		}
	}
}