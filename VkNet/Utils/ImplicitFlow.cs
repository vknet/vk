using System;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Flurl;
using Flurl.Http;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
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

		/// <inheritdoc />
		public ImplicitFlow([CanBeNull] ILogger<ImplicitFlow> logger,
							IVkApiVersionManager versionManager, IApiAuthParams apiAuthParams)
		{
			_logger = logger;
			_versionManager = versionManager;
			_authorizationParameters = apiAuthParams;
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

			var httpResponseMessage = await authorizeUrlResult.GetAsync().ConfigureAwait(false);

			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				throw new VkAuthorizationException(httpResponseMessage.ReasonPhrase);
			}

			return new AuthorizationResult();
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