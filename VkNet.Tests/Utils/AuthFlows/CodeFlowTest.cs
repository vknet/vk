using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Utils;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils.AuthFlows;

namespace VkNet.Tests.Utils.AuthFlows
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class CodeFlowTest : BaseTest
	{
		[SetUp]
		public void InitFlow()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<IAuthorizationFlow, CodeFlow>();

			serviceCollection.AddSingleton(sp =>
			{
				var restClient = new Mock<IRestClient>();

				SetupIRestClient(restClient);

				return restClient.Object;
			});

			Api = new VkApi(serviceCollection);

			Api.AuthorizationFlow.SetAuthParams(new ApiAuthParams
			{
				ClientId = 12345,
				ClientSecret = "12345",
				RedirectUri = new Uri("https://oauth.vk.com/blank.html"),
				Display = Display.Mobile,
				State = "12345",
				Login = "12345",
				Password = "12345",
				Scope = Settings.All,
				TwoFactorSupported = true
			});
		}

		[Test]
		public void ShouldAuthorize()
		{
			Url = Api.AuthorizationFlow.CreateAuthorizeUrl().AbsoluteUri;

			Json = @"{
					  'access_token': 'token',
					  'expires_in': 0,
					  'user_id': 12345
					}";

			((CodeFlow) Api.AuthorizationFlow)
				.SetResponseUri(new Uri(
					$"{Api.AuthorizationFlow.GetAuthParams().RedirectUri}?code=7a6fa4dff77a228eeda56603b8f53806c883f011c40b72630bb50df056f6479e52a"));

			Assert.DoesNotThrow(() => Api.Authorize());
			Assert.That(Api.AccessToken.Token, Is.EqualTo("token"));
			Assert.That(Api.AccessToken.UserId, Is.EqualTo(12345));
			Assert.That(Api.AccessToken.ExpireTime, Is.EqualTo(0));
		}

		[Test]
		public void ShouldCreateAuthorizeUrl()
		{
			var uri = Api.AuthorizationFlow.CreateAuthorizeUrl();

			Assert.AreEqual(uri,
				new Uri(
					$"https://oauth.vk.com/authorize?client_id=12345&redirect_uri=https://oauth.vk.com/blank.html&display=mobile&response_type=code&scope=140426719&state=12345&v={Api.VkApiVersion.Version}"));
		}

		[Test]
		public void ShouldThrowExceptionOnAuthorization()
		{
			Url = Api.AuthorizationFlow.CreateAuthorizeUrl().AbsoluteUri;

			Json = @"{
					  'error': 'error',
					  'error_description': 'description',
					}";

			((CodeFlow) Api.AuthorizationFlow)
				.SetResponseUri(new Uri(
					$"{Api.AuthorizationFlow.GetAuthParams().RedirectUri}#error=access_denied&error_description=The+user+or+authorization+server+denied+the+request."));


			Assert.Throws<VkApiException>(() => Api.Authorize());
		}
	}
}