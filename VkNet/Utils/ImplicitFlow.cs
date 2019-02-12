using System;
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

		private readonly IApiAuthParams _authorizationParameters;

		private readonly IImplicitFlowLoginForm _loginForm;

		private readonly ImplicitFlowVkAuthorization _vkAuthorization;

		/// <inheritdoc />
		public ImplicitFlow([CanBeNull] ILogger<ImplicitFlow> logger,
							IVkApiVersionManager versionManager, IApiAuthParams apiAuthParams, IImplicitFlowLoginForm loginForm,
							ImplicitFlowVkAuthorization vkAuthorization)
		{
			_logger = logger;
			_versionManager = versionManager;
			_authorizationParameters = apiAuthParams;
			_loginForm = loginForm;
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

			var loginFormResult = await _loginForm.ExecuteAsync(authorizeUrlResult).ConfigureAwait(false);

			return await NextStepAsync(loginFormResult).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public Url CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_logger?.LogDebug("Построение url для авторизации.");
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.Append($"client_id={clientId}&");
			builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append($"display={display}&");
			builder.Append($"scope={scope}&");
			builder.Append("response_type=token&");
			builder.Append($"v={_versionManager.Version}&");
			builder.Append($"state={state}&");
			builder.Append("revoke=1");

			return new Uri(builder.ToString());
		}

		private Task<AuthorizationResult> NextStepAsync(AuthorizationFormResult formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUrl.ToUri());

			switch (pageType)
			{
				case ImplicitFlowPageType.Error:

				{
					_logger?.LogDebug("При авторизации произошла ошибка.");
					throw new VkAuthorizationException("При авторизации произошла ошибка.");
				}
				case ImplicitFlowPageType.LoginPassword:

				{
					_logger?.LogDebug("Неверный логин или пароль.");
					throw new VkAuthorizationException("Неверный логин или пароль.");
				}
				case ImplicitFlowPageType.Captcha:

					break;
				case ImplicitFlowPageType.TwoFactor:

					break;
				case ImplicitFlowPageType.Consent:

					break;
				case ImplicitFlowPageType.Result:

				{
					return Task.FromResult(_vkAuthorization.GetAuthorizationResult(formResult.ResponseUrl.ToUri()));
				}

				default:

					throw new ArgumentOutOfRangeException();
			}

			return null;
		}

		/// <summary>
		/// Валидация параметров авторизации
		/// </summary>
		/// <exception cref="VkApiException"> Список неверно заданных параметров </exception>
		private void ValidateAuthorizationParameters()
		{
			var errorsBuilder = new StringBuilder();

			if (_authorizationParameters.ApplicationId == 0)
			{
				errorsBuilder.AppendLine("ApplicationId обязательный параметр");
			}

			if (string.IsNullOrWhiteSpace(_authorizationParameters.Login))
			{
				errorsBuilder.AppendLine("Login обязательный параметр");
			}

			if (string.IsNullOrWhiteSpace(_authorizationParameters.Password))
			{
				errorsBuilder.AppendLine("Password обязательный параметр");
			}

			if (_authorizationParameters.Settings == null)
			{
				errorsBuilder.AppendLine("Settings обязательный параметр");
			}

			var errors = errorsBuilder.ToString();

			if (!string.IsNullOrWhiteSpace(errors))
			{
				throw new VkAuthorizationException(errors);
			}
		}
	}
}