using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class ImplicitFlow : IImplicitFlow
	{
		/// <summary>
		/// Логгер
		/// </summary>
		[CanBeNull]
		private readonly ILogger<ImplicitFlow> _logger;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		private IApiAuthParams _authorizationParameters;

		[NotNull]
		private readonly IAuthorizationFormFactory _authorizationFormsFactory;

		private readonly IVkAuthorization<ImplicitFlowPageType> _vkAuthorization;

		/// <inheritdoc cref="ImplicitFlow"/>
		public ImplicitFlow([CanBeNull] ILogger<ImplicitFlow> logger,
							IVkApiVersionManager versionManager,
							IAuthorizationFormFactory authorizationFormsFactory,
							IVkAuthorization<ImplicitFlowPageType> vkAuthorization)
		{
			_logger = logger;
			_versionManager = versionManager;
			_authorizationFormsFactory = authorizationFormsFactory;
			_vkAuthorization = vkAuthorization;
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> AuthorizeAsync()
		{
			_logger?.LogDebug("Валидация данных.");
			ValidateAuthorizationParameters();

			_logger?.LogDebug("Шаг 1. Открытие диалога авторизации");

			var authorizeUrlResult = CreateAuthorizeUrl();

			var loginFormResult = await _authorizationFormsFactory.Create(ImplicitFlowPageType.LoginPassword)
				.ExecuteAsync(authorizeUrlResult, _authorizationParameters)
				.ConfigureAwait(false);

			return await NextStepAsync(loginFormResult).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public void SetAuthorizationParams(IApiAuthParams authorizationParams)
		{
			_authorizationParameters = authorizationParams;
		}

		/// <inheritdoc />
		[Obsolete("Используйте перегрузку Url CreateAuthorizeUrl();\nПараметры авторизации должны быть уставленны вызовом void SetAuthorizationParams(IApiAuthParams authorizationParams);")]
		public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_authorizationParameters.ApplicationId = clientId;
			_authorizationParameters.Display = display;
			_authorizationParameters.State = state;

			return CreateAuthorizeUrl();
		}

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");

			const string url = "https://oauth.vk.com/authorize?";

			var vkAuthParams = new VkParameters
			{
				{ "client_id", _authorizationParameters.ApplicationId },
				{ "redirect_uri", _authorizationParameters.RedirectUri != null ? _authorizationParameters.RedirectUri.ToString() : Constants.DefaultRedirectUri },
				{ "display", Display.Mobile },
				{ "scope", _authorizationParameters.Settings?.ToUInt64() },
				{ "response_type", ResponseType.Token },
				{ "v", _versionManager.Version },
				{ "state", _authorizationParameters.State },
				{ "revoke", _authorizationParameters.Revoke }
			};

			var resultUrl = Url.Combine(url, Url.QueryFrom(vkAuthParams.ToArray()));

			return new Uri(resultUrl);
		}

		private async Task<AuthorizationResult> NextStepAsync(AuthorizationFormResult formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUrl);

			switch (pageType)
			{
				case ImplicitFlowPageType.Error:

				{
					_logger?.LogError("При авторизации произошла ошибка.");

					throw new VkAuthorizationException("При авторизации произошла ошибка.");
				}

				case ImplicitFlowPageType.LoginPassword:

				{
					_logger?.LogDebug("Неверный логин или пароль.");

					throw new VkAuthorizationException("Неверный логин или пароль.");
				}

				case ImplicitFlowPageType.Captcha:

				{
					_logger?.LogDebug("Капча.");

					break;
				}

				case ImplicitFlowPageType.TwoFactor:

				{
					_logger?.LogDebug("Двухфакторная авторизация.");

					break;
				}

				case ImplicitFlowPageType.Consent:

				{
					_logger?.LogDebug("Страница подтверждения доступа к скоупам.");

					break;
				}

				case ImplicitFlowPageType.Result:

				{
					return _vkAuthorization.GetAuthorizationResult(formResult.ResponseUrl);
				}
			}

			var resultForm = await _authorizationFormsFactory.Create(pageType)
				.ExecuteAsync(formResult.ResponseUrl, _authorizationParameters)
				.ConfigureAwait(false);

			return await NextStepAsync(resultForm).ConfigureAwait(false);
		}

		/// <summary>
		/// Валидация параметров авторизации
		/// </summary>
		/// <exception cref="VkApiException"> Список неверно заданных параметров </exception>
		private void ValidateAuthorizationParameters()
		{
			var errorsBuilder = new StringBuilder();

			if (_authorizationParameters == null)
			{
				errorsBuilder.AppendLine("Параметры авторизации не установленны");
			} else
			{
				if (_authorizationParameters.ApplicationId == 0)
				{
					errorsBuilder.AppendLine($"{nameof(_authorizationParameters.ApplicationId)} обязательный параметр");
				}

				if (string.IsNullOrWhiteSpace(_authorizationParameters.Login))
				{
					errorsBuilder.AppendLine($"{nameof(_authorizationParameters.Login)} обязательный параметр");
				}

				if (string.IsNullOrWhiteSpace(_authorizationParameters.Password))
				{
					errorsBuilder.AppendLine($"{nameof(_authorizationParameters.Password)} обязательный параметр");
				}
			}

			var errors = errorsBuilder.ToString();

			if (!string.IsNullOrWhiteSpace(errors))
			{
				throw new VkAuthorizationException(errors);
			}
		}
	}
}