using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Utils;
using VkNet.Model;

namespace VkNet.Utils.AuthFlows
{
	/// <summary>
	/// Используйте Client credentials flow для обращения к методам API с префиксом
	/// secure. Эти методы позволяют работать с API от имени самого Вашего приложения.
	/// <remarks>
	/// https://vk.com/dev/client_cred_flow
	/// </remarks>
	/// </summary>
	public class ClientCredentialsFlow : IAuthorizationFlow
	{
		/// <summary>
		/// Логгер.
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
		/// Инициализирует новый экземпляр класса <see cref="ClientCredentialsFlow" /> с указаным
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
		public ClientCredentialsFlow([CanBeNull] ILogger<IAuthorizationFlow> logger, IRestClient restClient, IVkApiVersionManager versionManager)
		{
			_logger = logger;
			_restClient = restClient;
			_versionManager = versionManager;
		}

		/// <inheritdoc />
		public AuthorizationResult Authorize()
		{
			var response = _restClient.PostAsync(CreateAuthorizeUrl(), VkParameters.Empty)
				.ConfigureAwait(false)
				.GetAwaiter()
				.GetResult();

			var json = response.Value ?? response.Message;

			VkErrors.IfAuthErrorThrowException(json);

			var jObject = JObject.Parse(json);

			return new AuthorizationResult
			{
				AccessToken = jObject["access_token"].Value<string>()
			};
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

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");

			var parameters = new VkParameters
			{
				{ "client_id", _authParams.ClientId },
				{ "client_secret", _authParams.ClientSecret },
				{ "grant_type", "client_credentials" },
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
	}
}