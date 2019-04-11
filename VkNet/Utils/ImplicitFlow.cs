using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Flurl;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Model;

namespace VkNet.Utils
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

		/// <inheritdoc />
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

			var authorizeUrlResult = CreateAuthorizeUrl(_authorizationParameters.ApplicationId,
				_authorizationParameters.Settings.ToUInt64(),
				Display.Mobile,
				"123435");

			var loginFormResult = await _authorizationFormsFactory.Create(ImplicitFlowPageType.LoginPassword)
				.ExecuteAsync(authorizeUrlResult)
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
		public Url CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_authorizationParameters.ApplicationId = clientId;
			_authorizationParameters.Display = display;
			_authorizationParameters.State = state;

			return CreateAuthorizeUrl();
		}

		/// <inheritdoc />
		public Url CreateAuthorizeUrl()
		{
			_logger?.LogDebug("Построение url для авторизации.");

			const string url = "https://oauth.vk.com/authorize?";

			var vkAuthParams = new VkParameters
			{
				{ "client_id", _authorizationParameters.ApplicationId },
				{ "redirect_uri", _authorizationParameters.RedirectUri },
				{ "display", _authorizationParameters.Display },
				{ "scope", _authorizationParameters.Settings },
				{ "response_type", ResponseType.Token },
				{ "v", _versionManager.Version },
				{ "state", _authorizationParameters.State },
				{ "revoke", _authorizationParameters.Revoke }
			};

			var query = vkAuthParams.Select(x => $"{x.Key}={x.Value}");
			var stringQuery = string.Join("&",query);
			var result = $"{url}{stringQuery}";

			return new Uri(result);
		}

		private async Task<AuthorizationResult> NextStepAsync(AuthorizationFormResult formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUrl.ToUri());

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

					break;
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
					return _vkAuthorization.GetAuthorizationResult(formResult.ResponseUrl.ToUri());
				}
			}

			var resultForm = await _authorizationFormsFactory.Create(pageType)
				.ExecuteAsync(formResult.ResponseUrl)
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

				if (_authorizationParameters.RedirectUri == null)
				{
					errorsBuilder.AppendLine($"{nameof(_authorizationParameters.RedirectUri)} обязательный параметр");
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