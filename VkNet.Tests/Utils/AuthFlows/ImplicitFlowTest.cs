using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using VkNet.Abstractions.Authorization;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils.AuthFlows;

namespace VkNet.Tests.Utils.AuthFlows
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class ImplicitFlowTest
	{
		[SetUp]
		public void InitFlow()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<IAuthorizationFlow, ImplicitFlow>();

			_api = new VkApi(serviceCollection);

			_api.AuthorizationFlow.SetAuthParams(new ApiAuthParams
			{
				ClientId = 12345,
				RedirectUri = new Uri("https://oauth.vk.com/blank.html"),
				Display = Display.Mobile,
				State = "12345",
				Scope = Settings.All
			});
		}

		private VkApi _api;

		[Test]
		public void ShouldAuthorize()
		{
			((ImplicitFlow) _api.AuthorizationFlow)
				.SetResponseUri(new Uri(
				$"{_api.AuthorizationFlow.GetAuthParams().RedirectUri}#access_token=token&expires_in=0&user_id=12345&state=12345"));

			Assert.DoesNotThrow(() => _api.Authorize());
			Assert.That(_api.AccessToken.Token, Is.EqualTo("token"));
			Assert.That(_api.AccessToken.UserId, Is.EqualTo(12345));
			Assert.That(_api.AccessToken.ExpireTime, Is.EqualTo(0));
		}

		[Test]
		public void ShouldCreateAuthorizeUrl()
		{
			var uri = _api.AuthorizationFlow.CreateAuthorizeUrl();

			Assert.AreEqual(uri,
				new Uri(
					$"https://oauth.vk.com/authorize?client_id=12345&redirect_uri=https://oauth.vk.com/blank.html&display=mobile&response_type=token&scope=140426719&state=12345&v={_api.VkApiVersion.Version}&revoke=1"));
		}

		[Test]
		public void ShouldThrowExceptionOnAuthorization()
		{
			((ImplicitFlow) _api.AuthorizationFlow)
				.SetResponseUri(new Uri(
				$"{_api.AuthorizationFlow.GetAuthParams().RedirectUri}#error=access_denied&error_description=The+user+or+authorization+server+denied+the+request."));

			Assert.Throws<VkApiException>(() => _api.Authorize());
		}
	}
}