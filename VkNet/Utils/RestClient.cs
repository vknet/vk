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
		private readonly ILogger<RestClient> _logger;

		/// <inheritdoc cref="RestClient"/>
		public RestClient(HttpClient httpClient, ILogger<RestClient> logger)
		{
			HttpClient = httpClient;
			_logger = logger;
		}

		/// <summary>
		/// Http client
		/// </summary>
		public HttpClient HttpClient { get; }

		/// <inheritdoc />
		[Obsolete("Use HttpClientFactory to configure proxy.")]
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		[Obsolete("Use HttpClientFactory to configure timeout.")]
		public TimeSpan Timeout { get; set; }

		/// <inheritdoc />
		public Task<HttpResponse<string>> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var uriBuilder = new UriBuilder(uri)
			{
				Query = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"))
			};

			_logger?.LogDebug($"GET request: {uriBuilder.Uri}");

			return CallAsync(() => HttpClient.GetAsync(uriBuilder.Uri));
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			if (_logger != null)
			{
				var json = JsonConvert.SerializeObject(parameters);
				_logger.LogDebug($"POST request: {uri}{Environment.NewLine}{Utilities.PrettyPrintJson(json)}");
			}

			var content = new FormUrlEncodedContent(parameters);

			return CallAsync(() => HttpClient.PostAsync(uri, content));
		}

		/// <inheritdoc />
		public void Dispose()
		{
			HttpClient?.Dispose();
		}

		private async Task<HttpResponse<string>> CallAsync(Func<Task<HttpResponseMessage>> method)
		{
			var response = await method().ConfigureAwait(false);

			var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			_logger?.LogDebug($"Response:{Environment.NewLine}{Utilities.PrettyPrintJson(content)}");
			var url = response.RequestMessage.RequestUri.ToString();

			return response.IsSuccessStatusCode
				? HttpResponse<string>.Success(response.StatusCode, content, url)
				: HttpResponse<string>.Fail(response.StatusCode, content, url);
		}
	}
}