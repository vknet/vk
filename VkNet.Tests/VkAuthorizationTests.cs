using NUnit.Framework;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Tests
{
	[TestFixture]
	public class VkAuthorizationTests
	{
		private const string Input =
				"http://oauth.vk.com/blank.html"
				+ "#access_token=bf81b33c4f88f45c5e2fa3874054c3c7ae1cb0c632583ca3d9d0d949d4123d8c2c4d7069d9066eceaf815"
				+ "&expires_in=86400"
				+ "&user_id=32190123"
				+ "&email=inyutin_maxim@mail.ru";

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

			var authorization = VkAuthorization.From(uriFragment: urlWithBadLoginOrPassword);

			Assert.IsFalse(condition: authorization.IsAuthorized);
			Assert.IsFalse(condition: authorization.IsAuthorizationRequired);
		}

		[Test]
		public void CorrectParseInputString()
		{
			var auth = VkAuthorization.From(uriFragment: Input);

			Assert.AreEqual(expected: "bf81b33c4f88f45c5e2fa3874054c3c7ae1cb0c632583ca3d9d0d949d4123d8c2c4d7069d9066eceaf815"
					, actual: auth.AccessToken);

			Assert.AreEqual(expected: 86400, actual: auth.ExpiresIn);
			Assert.AreEqual(expected: 32190123L, actual: auth.UserId);
			Assert.AreEqual(expected: "inyutin_maxim@mail.ru", actual: auth.Email);
		}

		[Test]
		public void GetExpiresIn_Exception()
		{
			var auth = VkAuthorization.From(uriFragment: Input.Replace(oldValue: "86400", newValue: "qwe"));

			var error = Assert.Throws<VkApiException>(code: () =>
			{
				var expiresIn = auth.ExpiresIn;
				Assert.NotZero(actual: expiresIn);
			});

			Assert.AreEqual(expected: "ExpiresIn is not integer value.", actual: error.Message);
		}

		[Test]
		public void GetUserId_Exception()
		{
			var auth = VkAuthorization.From(uriFragment: Input.Replace(oldValue: "32190123", newValue: "qwe"));

			var error = Assert.Throws<VkApiException>(code: () =>
			{
				var authUserId = auth.UserId;
				Assert.NotZero(actual: authUserId);
			});

			Assert.AreEqual(expected: "UserId is not long value.", actual: error.Message);
		}

		[Test]
		public void IsAuthorizationRequired_False()
		{
			var auth = VkAuthorization.From(uriFragment: Input);
			Assert.IsFalse(condition: auth.IsAuthorizationRequired);
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

			var auth = VkAuthorization.From(uriFragment: uriQuery);
			Assert.IsTrue(condition: auth.IsAuthorizationRequired);
		}

		[Test]
		public void IsAuthorized_Failed()
		{
			var auth = VkAuthorization.From(uriFragment: Input.Replace(oldValue: "access_token", newValue: "qwe"));
			Assert.IsFalse(condition: auth.IsAuthorized);
		}

		[Test]
		public void IsAuthorized_Success()
		{
			var auth = VkAuthorization.From(uriFragment: Input);
			Assert.IsTrue(condition: auth.IsAuthorized);
		}
	}
}