using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Utils;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.AuthFlows
{
	/// <summary>
	/// Доверенные приложения могут получить неограниченный по времени access_token для
	/// доступа к API, передав логин и пароль пользователя.
	/// Обратите внимание, что приложение не должно хранить пароль пользователя.
	/// Выдаваемый access_token не привязан к IP-адресу пользователя, поэтому его
	/// достаточно для последующей работы с API без повторения процедуры авторизации.
	/// <remarks>
	/// https://vk.com/dev/auth_direct
	/// </remarks>
	/// </summary>
	public class DirectFlow : IAuthorizationFlow
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
		/// Обработчик двухфакторной авторизации.
		/// </summary>
		private Func<Task<string>> _callback;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DirectFlow" /> с указаным
		/// <see cref="ILogger" />, <see cref="IRestClient" /> и
		/// <see cref="IVkApiVersionManager" />.
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
		public DirectFlow([CanBeNull] ILogger<IAuthorizationFlow> logger, IRestClient restClient, IVkApiVersionManager versionManager)
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

			if (NeedValidation(json))
			{
				if (_callback == null)
				{
					throw new VkApiException("Требуется обработчик двухфакторной авторизации.");
				}

				var code = _callback
					.Invoke()
					.ConfigureAwait(false)
					.GetAwaiter()
					.GetResult();

				_authParams.Code = code;
				Authorize();
			}

			VkErrors.IfAuthErrorThrowException(json);

			var jObject = JObject.Parse(json);

			return new AuthorizationResult
			{
				AccessToken = jObject["access_token"].Value<string>(),
				ExpiresIn = jObject["expires_in"].Value<int>(),
				UserId = jObject["user_id"].Value<long>()
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
				{ "grant_type", "password" },
				{ "username", _authParams.Login },
				{ "password", _authParams.Password },
				{ "scope", _authParams.Scope?.ToUInt64() },
				{ "2fa_supported", _authParams.TwoFactorSupported },
				{ "code", _authParams.Code },
				{ "v", _versionManager.Version }
			};

			var queries = parameters
				.Select(parameter => $"{parameter.Key}={parameter.Value}");

			var url = new UriBuilder("https://oauth.vk.com/access_token")
			{
				Query = string.Join("&", queries)
			};

			return url.Uri;
		}

		/// <summary>
		/// Устанавливает обработчик двухфакторной авторизации.
		/// </summary>
		/// <param name="func">
		/// Функция, которая должна вернуть код.
		/// </param>
		public void SetTwoFactorCallback(Func<string> func)
		{
			_callback = Transform(func);
		}

		/// <summary>
		/// Устанавливает обработчик двухфакторной авторизации.
		/// </summary>
		/// <param name="func">
		/// Функция, которая должна вернуть код.
		/// </param>
		public void SetTwoFactorCallback(Func<Task<string>> func)
		{
			_callback = func;
		}

		private bool NeedValidation(string json)
		{
			JObject obj;

			try
			{
				obj = JObject.Parse(json);
			}
			catch (JsonReaderException ex)
			{
				throw new VkApiException("Wrong json data.", ex);
			}

			var error = obj["error"];

			return error != null && error.ToString() != "need_validation";
		}

		private static Func<Task<string>> Transform(Func<string> func)
		{
			return () =>
			{
			#if NET40
				return TaskEx.FromResult(func());
			#else
				return Task.FromResult(func());
			#endif
			};
		}
	}
}