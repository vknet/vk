using System.Net;
using System.Net.Http;
using Flurl.Http.Configuration;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	public class ProxyHttpClientFactory: DefaultHttpClientFactory
	{
		private readonly IWebProxy _proxy;

		/// <inheritdoc />
		public ProxyHttpClientFactory(IWebProxy proxy)
		{
			_proxy = proxy;
		}

		/// <inheritdoc />
		public override HttpMessageHandler CreateMessageHandler()
		{
			if (_proxy != null)
			{
				return new HttpClientHandler();
			}

			return new HttpClientHandler {
				Proxy = _proxy,
				UseProxy = true
			};
		}
	}
}