using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Flurl;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <inheritdoc />
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

		private readonly IVkAuthorization<ImplicitFlowPageType> _vkAuthorization;

		private IApiAuthParams _authParams;

		/// <inheritdoc />
		public Browser([CanBeNull] ILogger<Browser> logger,
						IVkApiVersionManager versionManager,
						IWebProxy proxy,
						IVkAuthorization<ImplicitFlowPageType> vkAuthorization,
						ICaptchaSolver captchaSolver)
		{
			_logger = logger;
			_versionManager = versionManager;
			Proxy = proxy;
			_vkAuthorization = vkAuthorization;
			_captchaSolver = captchaSolver;
		}

		private ushort LoginPasswordError { get; set; }

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return WebCall.PostCall(url, parameters, Proxy).Response;
		}

		/// <inheritdoc />
		public void SetAuthorizationParams(IApiAuthParams authorizationParams)
		{
			_authParams = authorizationParams;
		}

		/// <inheritdoc />
		[Obsolete(
			"Используйте перегрузку Url CreateAuthorizeUrl();\nПараметры авторизации должны быть уставленны вызовом void SetAuthorizationParams(IApiAuthParams authorizationParams);")]
		public Url CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_authParams.ApplicationId = clientId;
			_authParams.Display = display;
			_authParams.State = state;

			return CreateAuthorizeUrl();
		}

		/// <inheritdoc />
		public Url CreateAuthorizeUrl()
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
			return ValidateAsync(validateUrl).GetAwaiter().GetResult();
		}

		private bool HasСonfirmationRights(WebCallResult result)
		{
			var request = VkAuthorization2.From(result.RequestUrl.ToString());
			var response = VkAuthorization2.From(result.ResponseUrl.ToString());

			return request.IsAuthorizationRequired || response.IsAuthorizationRequired;
		}

		private long? HasCaptchaInput(WebCallResult result)
		{
			var request = VkAuthorization2.From(result.RequestUrl.ToString());
			var response = VkAuthorization2.From(result.ResponseUrl.ToString());

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
		private static bool IsAuthSuccessfull(WebCallResult webCallResult)
		{
			return UriHasAccessToken(webCallResult.RequestUrl) || UriHasAccessToken(webCallResult.ResponseUrl);
		}

		/// <summary>
		/// Проверка наличия токена в url
		/// </summary>
		/// <param name="uri"> </param>
		/// <returns> </returns>
		private static bool UriHasAccessToken(Uri uri)
		{
			return uri.Fragment
				.StartsWith("#access_token=", StringComparison.Ordinal);
		}

		/// <summary>
		/// Получить токен из uri
		/// </summary>
		/// <param name="webCallResult"> Результат запроса </param>
		/// <returns> Возвращает uri содержащий токен </returns>
		/// <exception cref="VkApiException"> URI должен содержать токен! </exception>
		private Uri GetTokenUri(WebCallResult webCallResult)
		{
			if (UriHasAccessToken(webCallResult.RequestUrl))
			{
				_logger?.LogDebug("Запрос: " + webCallResult.RequestUrl);

				return webCallResult.RequestUrl;
			}

			if (UriHasAccessToken(webCallResult.ResponseUrl))
			{
				_logger?.LogDebug("Ответ: " + webCallResult.ResponseUrl);

				return webCallResult.ResponseUrl;
			}

			return null;
		}

		private VkAuthorization2 OldValidate(string validateUrl, string phoneNumber)
		{
			return OldValidateAsync(validateUrl, phoneNumber).GetAwaiter().GetResult();
		}
	}
}