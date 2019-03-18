using System.Net;
using System.Net.Http;
using Flurl.Http.Configuration;
using JetBrains.Annotations;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class ProxyHttpClientFactory : DefaultHttpClientFactory
	{
		private readonly IWebProxy _proxy;

		private readonly CookieContainer _cookieContainer;

		/// <inheritdoc />
		public ProxyHttpClientFactory(IWebProxy proxy, CookieContainer cookieContainer)
		{
			_proxy = proxy;
			_cookieContainer = cookieContainer;
		}

		/// <inheritdoc />
		public override HttpMessageHandler CreateMessageHandler()
		{
			if (_proxy == null)
			{
				return new HttpClientHandler();
			}

			return new HttpClientHandler
			{
				Proxy = _proxy,
				UseProxy = true,
				AllowAutoRedirect = true,
				UseCookies = true,
				CookieContainer = _cookieContainer
			};
		}
	}
}