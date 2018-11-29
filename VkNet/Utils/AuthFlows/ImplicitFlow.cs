using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.AuthFlows
{
	/// <inheritdoc />
	public class ImplicitFlow : IImplicitFlow
	{
		/// <summary>
		/// Логгер.
		/// </summary>
		[CanBeNull]
		private readonly ILogger<ImplicitFlow> _logger;

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
		/// Инициализирует новый экземпляр класса <see cref="ImplicitFlow" /> с указаным
		/// <see cref="ILogger" />и <see cref="IVkApiVersionManager" />.
		/// </summary>
		/// <param name="logger">
		/// Экземпляр класса <see cref="ILogger" />.
		/// </param>
		/// <param name="versionManager">
		/// Экземпляр класса <see cref="IVkApiVersionManager" />.
		/// </param>
		public ImplicitFlow([CanBeNull] ILogger<ImplicitFlow> logger, IVkApiVersionManager versionManager)
		{
			_logger = logger;
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

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.UserId
			};
		}

		/// <inheritdoc />
		public void SetResponseUri([NotNull] Uri uri)
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

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");

			var parameters = new VkParameters
			{
				{ "client_id", _authParams.ClientId },
				{ "redirect_uri", _authParams.RedirectUri },
				{ "display", _authParams.Display },
				{ "response_type", "token" },
				{ "scope", _authParams.Scope?.ToUInt64() },
				{ "state", _authParams.State },
				{ "v", _versionManager.Version },
				{ "revoke", 1 }
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