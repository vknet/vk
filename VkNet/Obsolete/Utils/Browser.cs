using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <inheritdoc />
	[Obsolete(ObsoleteText.ObsoleteClass + " Используйте ImplicitFlow вместо него.")]
	public partial class Browser : IBrowser
	{
		private const ushort MaxLoginPasswordError = 2;

		private readonly ICaptchaSolver _captchaSolver;

		/// <summary>
		/// Логгер
		/// </summary>
		[CanBeNull]
		private readonly ILogger<Browser> _logger;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		private readonly IRestClient _restClient;

		private readonly IVkAuthorization<ImplicitFlowPageType> _vkAuthorization;

		private IApiAuthParams _authParams;

		/// <inheritdoc cref="Browser"/>
		public Browser([CanBeNull] ILogger<Browser> logger,
					   IVkApiVersionManager versionManager,
					   IRestClient restClient,
					   IVkAuthorization<ImplicitFlowPageType> vkAuthorization,
					   ICaptchaSolver captchaSolver)
		{
			_logger = logger;
			_versionManager = versionManager;
			_restClient = restClient;
			_vkAuthorization = vkAuthorization;
			_captchaSolver = captchaSolver;
		}

		private ushort LoginPasswordError { get; set; }

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return GetJsonAsync(url, parameters).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public void SetAuthorizationParams(IApiAuthParams authorizationParams)
		{
			_authParams = authorizationParams;
		}

		/// <inheritdoc />
		[Obsolete("Используйте перегрузку Url CreateAuthorizeUrl();\nПараметры авторизации должны быть уставленны вызовом void SetAuthorizationParams(IApiAuthParams authorizationParams);")]
		public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_authParams.ApplicationId = clientId;
			_authParams.Display = display;
			_authParams.State = state;

			return CreateAuthorizeUrl();
		}

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.Append($"client_id={_authParams.ApplicationId}&");
			builder.Append($"redirect_uri={Constants.DefaultRedirectUri}&");
			builder.Append($"display={Display.Mobile}&");
			builder.Append($"scope={_authParams.Settings}&");
			builder.Append($"response_type={ResponseType.Token}&");
			builder.Append($"v={_versionManager.Version}&");
			builder.Append("state=123456&");
			builder.Append("revoke=1");

			return new Uri(builder.ToString());
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl, string phoneNumber)
		{
			var result = OldValidate(validateUrl, phoneNumber);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.ExpiresIn,
				State = result.State
			};
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl)
		{
			return ValidateAsync(validateUrl).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		private bool HasConfirmationRights(HttpResponse<string> result)
		{
			var request = VkAuthorization2.From(result.RequestUri?.ToString());
			var response = VkAuthorization2.From(result.ResponseUri?.ToString());

			return request.IsAuthorizationRequired || response.IsAuthorizationRequired;
		}

		private long? HasCaptchaInput(HttpResponse<string> result)
		{
			var request = VkAuthorization2.From(result.RequestUri?.ToString());
			var response = VkAuthorization2.From(result.ResponseUri?.ToString());

			if (request.IsCaptchaNeeded)
			{
				return request.CaptchaSid;
			}

			if (response.IsCaptchaNeeded)
			{
				return response.CaptchaSid;
			}

			return null;
		}

		/// <summary>
		/// Авторизация прошла успешно
		/// </summary>
		/// <param name="webCallResult"> </param>
		/// <returns> true, если авторизация прошла успешно </returns>
		private static bool IsAuthSuccessful(HttpResponse<string> webCallResult)
		{
			return UriHasAccessToken(webCallResult.RequestUri) || UriHasAccessToken(webCallResult.ResponseUri);
		}

		/// <summary>
		/// Проверка наличия токена в url
		/// </summary>
		/// <param name="uri"> </param>
		/// <returns> </returns>
		private static bool UriHasAccessToken(Uri uri)
		{
			var result = uri?.Fragment.StartsWith("#access_token=", StringComparison.Ordinal);

			return result.GetValueOrDefault();
		}

		/// <summary>
		/// Получить токен из uri
		/// </summary>
		/// <param name="webCallResult"> Результат запроса </param>
		/// <returns> Возвращает uri содержащий токен </returns>
		/// <exception cref="VkApiException"> URI должен содержать токен! </exception>
		private Uri GetTokenUri(HttpResponse<string> webCallResult)
		{
			if (UriHasAccessToken(webCallResult.RequestUri))
			{
				_logger?.LogDebug("Запрос: " + webCallResult.RequestUri);

				return webCallResult.RequestUri;
			}

			if (UriHasAccessToken(webCallResult.RequestUri))
			{
				_logger?.LogDebug("Ответ: " + webCallResult.RequestUri);

				return webCallResult.RequestUri;
			}

			return null;
		}

		private VkAuthorization2 OldValidate(string validateUrl, string phoneNumber)
		{
			return OldValidateAsync(validateUrl, phoneNumber).ConfigureAwait(false).GetAwaiter().GetResult();
		}
	}
}