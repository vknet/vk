using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.AuthFlows
{
	/// <inheritdoc />
	public class CodeFlow : IAuthorizationFlow
	{
		/// <summary>
		/// Логгер
		/// </summary>
		[CanBeNull]
		private readonly ILogger<IAuthorizationFlow> _logger;

		/// <summary>
		/// Rest Client.
		/// </summary>
		private readonly IRestClient _restClient;

		/// <summary>
		/// Менеджер версий VkApi.
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		/// <summary>
		/// Параметры авторизации.
		/// </summary>
		private IApiAuthParams _authParams;

		/// <summary>
		/// Url полученный после авторизации.
		/// </summary>
		private Uri _responseUri;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CodeFlow" /> с указаным
		/// <see cref="ILogger" />, <see cref="IRestClient" /> и <see cref="IVkApiVersionManager" />.
		/// </summary>
		/// <param name="logger">
		/// Экземпляр класса <see cref="ILogger" />.
		/// </param>
		/// <param name="restClient">
		/// Экземпляр класса <see cref="IRestClient" />.
		/// </param>
		/// <param name="versionManager">
		/// Экземпляр класса <see cref="IVkApiVersionManager" />.
		/// </param>
		public CodeFlow([CanBeNull] ILogger<IAuthorizationFlow> logger, IRestClient restClient, IVkApiVersionManager versionManager)
		{
			_logger = logger;
			_restClient = restClient;
			_versionManager = versionManager;
		}

		/// <inheritdoc />
		public AuthorizationResult Authorize()
		{
			var result = VkAuthorization.From(_responseUri.AbsoluteUri);

			if (result.HasError)
			{
				throw new VkApiException($"{result.Error}{Environment.NewLine}{result.ErrorDescription}");
			}

			var response = _restClient.PostAsync(new Uri("https://oauth.vk.com/access_token"),
					new VkParameters
					{
						{ "client_id", _authParams.ClientId },
						{ "client_secret", _authParams.ClientSecret },
						{ "redirect_uri", _authParams.RedirectUri },
						{ "code", result.Code }
					})
				.ConfigureAwait(false)
				.GetAwaiter()
				.GetResult();

			var json = response.Value ?? response.Message;

			VkErrors.IfAuthErrorThrowException(json);

			var jObject = JObject.Parse(json);

			return new AuthorizationResult
			{
				AccessToken = jObject["access_token"].Value<string>(),
				ExpiresIn = jObject["expires_in"].Value<int>(),
				UserId = jObject["user_id"].Value<long>()
			};
		}

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");

			var parameters = new VkParameters
			{
				{ "client_id", _authParams.ClientId },
				{ "redirect_uri", _authParams.RedirectUri },
				{ "display", _authParams.Display },
				{ "response_type", "code" },
				{ "scope", _authParams.Scope?.ToUInt64() },
				{ "state", _authParams.State },
				{ "v", _versionManager.Version }
			};

			var queries = parameters
				.Select(parameter => $"{parameter.Key}={parameter.Value}");

			var url = new UriBuilder("https://oauth.vk.com/authorize")
			{
				Query = string.Join("&", queries)
			};

			return url.Uri;
		}

		/// <inheritdoc />
		public void SetResponseUri(Uri uri)
		{
			_responseUri = uri;
		}

		/// <inheritdoc />
		public void SetAuthParams(IApiAuthParams authParams)
		{
			_authParams = authParams;
		}

		/// <inheritdoc />
		public IApiAuthParams GetAuthParams()
		{
			return _authParams;
		}
	}
}