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
			get => _timeoutSeconds == TimeSpan.Zero ? TimeSpan.FromSeconds(value: 300) : _timeoutSeconds;
			set => _timeoutSeconds = value;
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> GetAsync(Uri uri, VkParameters parameters)
		{
			var queries = parameters.Where(predicate: k => !string.IsNullOrWhiteSpace(value: k.Value))
				.Select(selector: kvp => $"{kvp.Key.ToLowerInvariant()}={kvp.Value}");

			var url = new UriBuilder(uri: uri)
			{
				Query = string.Join(separator: "&", values: queries)
			};

			_logger?.LogDebug(message: $"GET request: {url.Uri}");

			return Call(method: httpClient => httpClient.GetAsync(requestUri: url.Uri));
		}

		/// <inheritdoc />
		public Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var json = JsonConvert.SerializeObject(value: parameters);
			_logger?.LogDebug(message: $"POST request: {uri}{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");
			HttpContent content = new FormUrlEncodedContent(nameValueCollection: parameters);

			return Call(method: httpClient => httpClient.PostAsync(requestUri: uri, content: content));
		}

		private async Task<HttpResponse<string>> Call(Func<HttpClient, Task<HttpResponseMessage>> method)
		{
			var handler = new HttpClientHandler
			{
				UseProxy = false
			};

			if (Proxy != null)
			{
				handler = new HttpClientHandler
				{
					Proxy = Proxy,
					UseProxy = true
				};

				_logger?.LogDebug(message: $"Use Proxy: {Proxy}");
			}

			using (var client = new HttpClient(handler: handler))
			{
				if (Timeout != TimeSpan.Zero)
				{
					client.Timeout = Timeout;
				}

				var response = await method(arg: client).ConfigureAwait(false);
				var requestUri = response.RequestMessage.RequestUri.ToString();

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					_logger?.LogDebug(message: $"Response:{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");

					return HttpResponse<string>.Success(httpStatusCode: response.StatusCode, value: json, requestUri: requestUri);
				}

				var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				return HttpResponse<string>.Fail(httpStatusCode: response.StatusCode, message: message, requestUri: requestUri);
			}
		}
	}
}