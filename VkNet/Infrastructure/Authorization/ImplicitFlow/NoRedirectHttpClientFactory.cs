using System.Net;
using System.Net.Http;
using Flurl.Http.Configuration;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	public class NoRedirectHttpClientFactory : DefaultHttpClientFactory
	{
		private readonly IWebProxy _proxy;

		private readonly CookieContainer _cookieContainer;

		public NoRedirectHttpClientFactory(CookieContainer cookieContainer, IWebProxy proxy)
		{
			_cookieContainer = cookieContainer;
			_proxy = proxy;
		}

		public override HttpMessageHandler CreateMessageHandler()
		{
			return new HttpClientHandler
			{
				Proxy = _proxy,
				UseProxy = true,
				AllowAutoRedirect = false,
				UseCookies = true,
				CookieContainer = _cookieContainer
			};
		}
	}
}