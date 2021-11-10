using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
		[Obsolete("Use HttpClient to configure proxy. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration", true)]
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		[Obsolete("Use HttpClient to configure timeout. Documentation reference https://github.com/vknet/vk/wiki/Proxy-Configuration",
			true)]
		public TimeSpan Timeout { get; set; }

		/// <inheritdoc />
		public Task<HttpResponse<string>> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding)
		{
			var url = Url.Combine(uri.ToString(), Url.QueryFrom(parameters.ToArray()));

			_logger?.LogDebug("GET request: {Url}", url);

			return CallAsync(() => HttpClient.GetAsync(new Uri(url)), encoding);
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding)
		{
			if (_logger != null)
			{
				var json = JsonConvert.SerializeObject(parameters);
				_logger.LogDebug("POST request: {Uri}{NewLine}{PrettyJson}", uri, Environment.NewLine, Utilities.PrettyPrintJson(json));
			}

			var content = new FormUrlEncodedContent(parameters);

			return CallAsync(() => HttpClient.PostAsync(uri, content), encoding);
		}

		/// <inheritdoc />
		public void Dispose()
		{
			HttpClient?.Dispose();
		}

		private async Task<HttpResponse<string>> CallAsync(Func<Task<HttpResponseMessage>> method, Encoding encoding)
		{
			var response = await method().ConfigureAwait(false);

			var bytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
			var content = encoding.GetString(bytes, 0, bytes.Length);
			_logger?.LogDebug("Response:{NewLine}{PrettyJson}", Environment.NewLine, Utilities.PrettyPrintJson(content));
			var requestUri = response.RequestMessage?.RequestUri;
			var responseUri = response.Headers.Location;

			return response.IsSuccessStatusCode
				? HttpResponse<string>.Success(response.StatusCode, content, requestUri, responseUri)
				: HttpResponse<string>.Fail(response.StatusCode, content, requestUri, responseUri);
		}
	}
}