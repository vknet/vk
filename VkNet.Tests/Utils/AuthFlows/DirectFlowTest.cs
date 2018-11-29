using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Utils;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils.AuthFlows;

namespace VkNet.Tests.Utils.AuthFlows
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class DirectFlowTest : BaseTest
	{
		[SetUp]
		public void InitFlow()
		{
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<IAuthorizationFlow, DirectFlow>();

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
				Login = "12345",
				Password = "12345",
				Scope = Settings.All,
				TwoFactorSupported = true
			});
		}

		[Test]
		public void ShouldCreateAuthorizeUrl()
		{
			var uri = Api.AuthorizationFlow.CreateAuthorizeUrl();

			Assert.AreEqual(uri,
				new Uri(
					$"https://oauth.vk.com/access_token?client_id=12345&client_secret=12345&grant_type=password&username=12345&password=12345&scope=140426719&2fa_supported=1&v={Api.VkApiVersion.Version}"));
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

			Assert.DoesNotThrow(() => Api.Authorize());
			Assert.That(Api.AccessToken.Token, Is.EqualTo("token"));
			Assert.That(Api.AccessToken.UserId, Is.EqualTo(12345));
			Assert.That(Api.AccessToken.ExpireTime, Is.EqualTo(0));
		}

		[Test]
		public void ShouldThrowExceptionOnAuthorization()
		{
			Url = Api.AuthorizationFlow.CreateAuthorizeUrl().AbsoluteUri;

			Json = @"{
					  'error': 'error',
					  'error_description': 'description',
					}";

			Assert.Throws<VkApiException>(() => Api.Authorize());
		}
	}
}