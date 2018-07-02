using System;
using System.Net;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using NLog;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <inheritdoc />
	public class ImplicitFlow : IImplicitFlow
	{
		/// <summary>
		/// HttpClient
		/// </summary>
		private readonly HttpClient _httpClient;

		/// <summary>
		/// Логгер
		/// </summary>
		[CanBeNull]
		private readonly ILogger _logger;

		/// <summary>
		/// WebProxy
		/// </summary>
		private readonly IWebProxy _proxy;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		/// <inheritdoc />
		public ImplicitFlow([CanBeNull]
							ILogger logger, IWebProxy proxy, HttpClient httpClient, IVkApiVersionManager versionManager)
		{
			_logger = logger;
			_proxy = proxy;
			_httpClient = httpClient;
			_versionManager = versionManager;
		}

		/// <inheritdoc />
		public AuthorizationResult Authorize()
		{
			_logger?.Debug(message: "Валидация данных.");
			ValidateAuthorizationParameters();

			_logger?.Debug(message: "Шаг 1. Открытие диалога авторизации");
			var authorizeUrlResult = OpenAuthDialog();

			return null;
		}

		/// <inheritdoc />
		public IApiAuthParams AuthorizationParameters { get; set; }

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			_logger?.Debug(message: "Построение url для авторизации.");
			var builder = new StringBuilder(value: "https://oauth.vk.com/authorize?");

			builder.Append(value: $"client_id={clientId}&");
			builder.Append(value: "redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append(value: $"display={display}&");
			builder.Append(value: $"scope={scope}&");
			builder.Append(value: "response_type=token&");
			builder.Append(value: $"v={_versionManager.Version}&");
			builder.Append(value: $"state={state}&");
			builder.Append(value: "revoke=1");

			return new Uri(uriString: builder.ToString());
		}

		private Uri OpenAuthDialog()
		{
			var authUri = CreateAuthorizeUrl(clientId: AuthorizationParameters.ApplicationId,
				scope: AuthorizationParameters.Settings.ToUInt64(),
				display: Display.Mobile,
				state: "123435");

			return null;
		}

		/// <summary>
		/// Валидация параметров авторизации
		/// </summary>
		/// <exception cref="VkApiException"> Список неверно заданных параметров </exception>
		private void ValidateAuthorizationParameters()
		{
			var errorsBuilder = new StringBuilder();

			if (AuthorizationParameters.ApplicationId == 0)
			{
				errorsBuilder.AppendLine(value: "ApplicationId обязательный параметр");
			}

			if (string.IsNullOrWhiteSpace(value: AuthorizationParameters.Login))
			{
				errorsBuilder.AppendLine(value: "Login обязательный параметр");
			}

			if (string.IsNullOrWhiteSpace(value: AuthorizationParameters.Password))
			{
				errorsBuilder.AppendLine(value: "Password обязательный параметр");
			}

			if (AuthorizationParameters.Settings == null)
			{
				errorsBuilder.AppendLine(value: "Settings обязательный параметр");
			}

			var errors = errorsBuilder.ToString();

			if (!string.IsNullOrWhiteSpace(value: errors))
			{
				throw new VkApiException(message: errors);
			}
		}
	}
}