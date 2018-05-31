using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NLog;
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
		private readonly ILogger _logger;

		private TimeSpan _timeoutSeconds;

		/// <inheritdoc />
		public RestClient(ILogger logger, IWebProxy proxy)
		{
			_logger = logger;
			Proxy = proxy;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public TimeSpan Timeout
		{
			get => _timeoutSeconds == TimeSpan.MinValue ? TimeSpan.FromSeconds(value: 300) : _timeoutSeconds;
			set => _timeoutSeconds = value;
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> GetAsync(Uri uri, VkParameters parameters)
		{
			var queries = parameters.Where(predicate: k => !string.IsNullOrWhiteSpace(value: k.Value))
					.Select(selector: kvp => $"{kvp.Key.ToLowerInvariant()}={kvp.Value}");

			var url = new UriBuilder(uri: uri)
			{
					Query = string.Join(separator: "&", values: queries)
			};

			_logger?.Debug(message: $"GET request: {url.Uri}");

			return await Call(method: httpClient => httpClient.GetAsync(requestUri: url.Uri));
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var json = JsonConvert.SerializeObject(value: parameters);
			_logger?.Debug(message: $"POST request: {uri}{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");
			HttpContent content = new FormUrlEncodedContent(nameValueCollection: parameters);

			return await Call(method: httpClient => httpClient.PostAsync(requestUri: uri, content: content));
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
						Proxy = Proxy
						, UseProxy = true
				};

				_logger?.Debug(message: $"Use Proxy: {Proxy}");
			}

			using (var client = new HttpClient(handler: handler))
			{
				if (Timeout != TimeSpan.Zero)
				{
					client.Timeout = Timeout;
				}

				var response = await method(arg: client);
				var requestUri = response.RequestMessage.RequestUri.ToString();

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					_logger?.Debug(message: $"Response:{Environment.NewLine}{Utilities.PreetyPrintJson(json: json)}");

					return HttpResponse<string>.Success(httpStatusCode: response.StatusCode, value: json, requestUri: requestUri);
				}

				var message = await response.Content.ReadAsStringAsync();

				return HttpResponse<string>.Fail(httpStatusCode: response.StatusCode, message: message, requestUri: requestUri);
			}
		}
	}
}