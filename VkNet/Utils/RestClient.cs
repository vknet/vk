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

		/// <inheritdoc />
		public RestClient(ILogger logger, IWebProxy proxy)
		{
			_logger = logger;
			Proxy = proxy;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		private TimeSpan _timeoutSeconds;

		/// <inheritdoc />
		public TimeSpan TimeoutSeconds
		{
			get => _timeoutSeconds == TimeSpan.MinValue ? TimeSpan.FromSeconds(300) : _timeoutSeconds;
			set => _timeoutSeconds = value;
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> GetAsync(Uri uri, VkParameters parameters)
		{
			var queries = parameters.Where(k => !string.IsNullOrWhiteSpace(k.Value))
				.Select(kvp => $"{kvp.Key.ToLowerInvariant()}={kvp.Value}");

			var url = new UriBuilder(uri)
			{
				Query = string.Join("&", queries)
			};

			_logger?.Debug($"GET request: {url.Uri}");
			return await Call(httpClient => httpClient.GetAsync(url.Uri));
		}

		/// <inheritdoc />
		public async Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var json = JsonConvert.SerializeObject(parameters);
			_logger?.Debug($"POST request: {uri}{Environment.NewLine}{Utilities.PreetyPrintJson(json)}");
			HttpContent content = new FormUrlEncodedContent(parameters);
			return await Call(httpClient => httpClient.PostAsync(uri, content));
		}

		private async Task<HttpResponse<string>> Call(
			Func<HttpClient, Task<HttpResponseMessage>> method)
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
					UseProxy = true,
				};

				_logger?.Debug($"Use Proxy: {Proxy}");
			}

			using (var client = new HttpClient(handler)
			{
				Timeout = TimeoutSeconds
			})
			{
				var response = await method(client);
				var requestUri = response.RequestMessage.RequestUri.ToString();

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					_logger?.Debug($"Response:{Environment.NewLine}{Utilities.PreetyPrintJson(json)}");

					return HttpResponse<string>.Success(response.StatusCode, json, requestUri);
				}

				var message = await response.Content.ReadAsStringAsync();
				return HttpResponse<string>.Fail(response.StatusCode, message, requestUri);
			}
		}
	}
}