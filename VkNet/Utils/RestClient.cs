using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;

namespace VkNet.Utils
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class RestClient : IRestClient
	{
		/// <summary>
		/// The log
		/// </summary>
		private readonly ILogger<RestClient> _logger;

		private TimeSpan _timeoutSeconds;

		/// <inheritdoc />
		public RestClient(ILogger<RestClient> logger, IWebProxy proxy)
		{
			_logger = logger;
			Proxy = proxy;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public TimeSpan Timeout
		{
			get => _timeoutSeconds == TimeSpan.Zero ? TimeSpan.FromSeconds(300) : _timeoutSeconds;
			set => _timeoutSeconds = value;
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var queries = parameters
				.Where(parameter => !string.IsNullOrWhiteSpace(parameter.Value))
				.Select(parameter => $"{parameter.Key.ToLowerInvariant()}={parameter.Value}");

			var url = new UriBuilder(uri)
			{
				Query = string.Join("&", queries)
			};

			_logger?.LogDebug($"GET request: {url.Uri}");

			var request = new HttpRequestMessage(HttpMethod.Get, uri);

			return Call(httpClient => httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead));
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			if (_logger != null)
			{
				var json = JsonConvert.SerializeObject(parameters);
				_logger.LogDebug($"POST request: {uri}{Environment.NewLine}{Utilities.PreetyPrintJson(json)}");
			}

			var content = new FormUrlEncodedContent(parameters);

			var request = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

			return Call(httpClient => httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead));
		}

		private async Task<HttpResponse<string>> Call(Func<HttpClient, Task<HttpResponseMessage>> method)
		{
			var useProxyCondition = Proxy != null;

			if (useProxyCondition)
				_logger?.LogDebug($"Use Proxy: {Proxy}");

			var handler = new HttpClientHandler
			{
				Proxy = Proxy,
				UseProxy = useProxyCondition
			};

			using (var client = new HttpClient(handler) { Timeout = Timeout })
			{
				var response = await method(client).ConfigureAwait(false);

				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				_logger?.LogDebug($"Response:{Environment.NewLine}{Utilities.PreetyPrintJson(content)}");
				var url = response.RequestMessage.RequestUri.ToString();

				return response.IsSuccessStatusCode
					? HttpResponse<string>.Success(response.StatusCode, content, url)
					: HttpResponse<string>.Fail(response.StatusCode, content, url);
			}
		}
	}
}