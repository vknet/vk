using System;
using System.Net;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using NLog;
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
        /// Логгер
        /// </summary>
        [CanBeNull] private readonly ILogger _logger;

        /// <summary>
        /// WebProxy
        /// </summary>
        private readonly IWebProxy _proxy;

        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <inheritdoc />
        public ImplicitFlow([CanBeNull] ILogger logger, IWebProxy proxy, HttpClient httpClient)
        {
            _logger = logger;
            _proxy = proxy;
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public AuthorizationResult Aurhorize()
        {
            _logger?.Debug("Валидация данных.");
            ValidateAuthorizationParameters();

            _logger?.Debug("Шаг 1. Открытие диалога авторизации");
            var authorizeUrlResult = OpenAuthDialog();
            return null;
        }

        private Uri OpenAuthDialog()
        {
            var authUri = CreateAuthorizeUrl(
                AuthorizationParameters.ApplicationId,
                AuthorizationParameters.Settings.ToUInt64(),
                Display.Mobile,
                "123435"
            );

            return null;
        }

        /// <inheritdoc />
        public IApiAuthParams AuthorizationParameters { get; set; }

        /// <inheritdoc />
        public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
        {
            _logger?.Debug("Построение url для авторизации.");
            var builder = new StringBuilder("https://oauth.vk.com/authorize?");

            builder.Append($"client_id={clientId}&");
            builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
            builder.Append($"display={display}&");
            builder.Append($"scope={scope}&");
            builder.Append("response_type=token&");
            builder.Append($"v={VkApi.VkApiVersion}&");
            builder.Append($"state={state}&");
            builder.Append("revoke=1");

            return new Uri(builder.ToString());
        }

        /// <summary>
        /// Валидация параметров авторизации 
        /// </summary>
        /// <exception cref="VkApiException">Список неверно заданных параметров</exception>
        private void ValidateAuthorizationParameters()
        {
            var errorsBuilder = new StringBuilder();
            if (AuthorizationParameters.ApplicationId == 0)
            {
                errorsBuilder.AppendLine("ApplicationId обязательный параметр");
            }

            if (string.IsNullOrWhiteSpace(AuthorizationParameters.Login))
            {
                errorsBuilder.AppendLine("Login обязательный параметр");
            }

            if (string.IsNullOrWhiteSpace(AuthorizationParameters.Password))
            {
                errorsBuilder.AppendLine("Password обязательный параметр");
            }

            if (AuthorizationParameters.Settings == null)
            {
                errorsBuilder.AppendLine("Settings обязательный параметр");
            }

            var errors = errorsBuilder.ToString();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                throw new VkApiException(errors);
            }
        }
    }
}