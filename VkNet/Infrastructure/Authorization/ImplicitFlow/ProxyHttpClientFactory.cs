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

			return new HttpClientHandler
			{
				Proxy = _proxy,
				UseProxy = true
			};
		}
	}
}