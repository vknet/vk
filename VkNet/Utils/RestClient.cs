using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;

namespace VkNet.Utils;

/// <inheritdoc />
[UsedImplicitly]
[Serializable]
public sealed class RestClient : IRestClient
{
	private readonly ILogger<RestClient> _logger;

	/// <inheritdoc cref="RestClient"/>
	public RestClient(HttpClient httpClient, ILogger<RestClient> logger)
	{
		HttpClient = httpClient;
		_logger = logger;
	}

	/// <summary>
	/// </summary>
	/// <param name="serializationInfo"></param>
	/// <param name="streamingContext"></param>
	private RestClient(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}

	/// <summary>
	/// Http client
	/// </summary>
	public HttpClient HttpClient { get; }



	/// <inheritdoc />
	public Task<HttpResponse<string>> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding, CancellationToken token = default)
	{
		var url = Url.Combine(uri.ToString(), Url.QueryFrom(parameters.ToArray()));

		_logger?.LogDebug("GET request: {Url}", url);

		return CallAsync(() => HttpClient.GetAsync(new Uri(url), token), encoding);
	}

	/// <inheritdoc />
	public Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding, IEnumerable<KeyValuePair<string, string>> headers = null, CancellationToken token = default)
	{
		if (_logger != null)
		{
			var json = JsonConvert.SerializeObject(parameters);
			_logger.LogDebug("POST request: {Uri}{NewLine}{PrettyJson}", uri, Environment.NewLine, Utilities.PrettyPrintJson(json));
		}

		if (headers != null && headers.Any())
		{
			headers.ToList().ForEach(header => {
				if (header.Key.ToLower() == "content-type")
				{
					HttpClient.DefaultRequestHeaders.Accept.Add(new(header.Value));
				} else
				{
					HttpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
				}
			});
		}

		var content = new FormUrlEncodedContent(parameters);

		return CallAsync(() => HttpClient.PostAsync(uri, content, token), encoding);
	}

	/// <inheritdoc />
	public void Dispose() => HttpClient?.Dispose();

	private async Task<HttpResponse<string>> CallAsync(Func<Task<HttpResponseMessage>> method, Encoding encoding)
	{
		var response = await method()
			.ConfigureAwait(false);

		var bytes = await response.Content.ReadAsByteArrayAsync()
			.ConfigureAwait(false);

		var content = encoding.GetString(bytes, 0, bytes.Length);
		_logger?.LogDebug("Response:{NewLine}{PrettyJson}", Environment.NewLine, Utilities.PrettyPrintJson(content));
		var requestUri = response.RequestMessage?.RequestUri;
		var responseUri = response.Headers.Location;

		return response.IsSuccessStatusCode
			? HttpResponse<string>.Success(response.StatusCode, content, requestUri, responseUri)
			: HttpResponse<string>.Fail(response.StatusCode, content, requestUri, responseUri);
	}
}