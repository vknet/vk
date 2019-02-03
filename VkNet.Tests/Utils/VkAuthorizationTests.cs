using System;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	/// <summary>
	///
	/// </summary>
	/// <remarks>
	/// http://oauth.vk.com/oauth/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail
	/// https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&m=4&email=mail
	/// https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&sid=462572155651&dif=1&email=inyutin_maxim%40mail.ru
	/// https://oauth.vk.com/authorize?client_id=1&redirect_uri=http%3A%2F%2Foauth.vk.com%2Fblank.html&response_type=token&scope=2&v=&state=&display=wap&sid=856703151954&dif=1&email=inyutin_maxim%40mail.ru&m=5
	/// https://m.vk.com/login?act=authcheck&api_hash=0608a20b145b57db88
	/// https://m.vk.com/login?act=authcheck&m=442
	/// https://oauth.vk.com/blank.html#access_token=e5f68123794895441053633707c5f1b57194a2a72291a4c985eb114d1b15d78553389003f0561126acbf4&expires_in=86400&user_id=32190123
	/// </remarks>
	[TestFixture]
	public class VkAuthorizationTests
	{
		[Test]
		public void GetAuthorizationResult()
		{
			var url = new Uri("https://oauth.vk.com/blank.html#access_token=access_token&expires_in=86400&user_id=32190123&state=123");

			var auth = new VkAuthorization();

			var authorizationResult = auth.GetAuthorizationResult(url);

			Assert.NotNull(authorizationResult);
			Assert.AreEqual("123", authorizationResult.State);
			Assert.AreEqual(32190123, authorizationResult.UserId);
			Assert.AreEqual(86400, authorizationResult.ExpiresIn);
			Assert.AreEqual("access_token", authorizationResult.AccessToken);
		}

		[Test]
		public void GetAuthorizationResult_ArgumentException()
		{
			var url = new Uri("https://m.vk.com/login?act=authcheck&m=442");

			var auth = new VkAuthorization();

			Assert.Throws<ArgumentException>(() => auth.GetAuthorizationResult(url));
		}
	}
}