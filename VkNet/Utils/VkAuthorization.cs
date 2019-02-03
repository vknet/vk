using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Информация об авторизации приложения на действия.
	/// </summary>
	[UsedImplicitly]
	public class VkAuthorization : IVkAuthorization
	{
		private const string AccessToken = "access_token";

		private const string State = "state";

		private const string ExpiresIn = "expires_in";

		private const string UserId = "user_id";

		/// <summary>
		/// Получить результат авторизации
		/// </summary>
		/// <param name="url">URL в котором содержатся параметры о авторизации</param>
		/// <returns>Результат авторизации <see cref="AuthorizationResult"/></returns>
		/// <exception cref="ArgumentException">URL должен начинаться со строки 'https://oauth.vk.com/blank.html'</exception>
		[NotNull]
		[UsedImplicitly]
		public AuthorizationResult GetAuthorizationResult(Uri url)
		{
			if (!url.OriginalString.StartsWith("https://oauth.vk.com/blank.html"))
			{
				throw new ArgumentException("URL должен начинаться со строки 'https://oauth.vk.com/blank.html'", nameof(url));
			}

			var token = GetToken(url);
			var state = GetState(url);
			var expireIn = GetExpiresIn(url);
			var userId = GetUserId(url);

			return new AuthorizationResult
			{
				UserId = userId,
				ExpiresIn = expireIn,
				AccessToken = token,
				State = state
			};
		}

		private static string GetToken(Uri url)
		{
			var parameters = GetFragmentParameters(url);

			if (!parameters.TryGetValue(AccessToken, out var token))
			{
				throw new VkApiException($"Параметр {AccessToken} не найден");
			}

			return token;
		}

		private static string GetState(Uri url)
		{
			var parameters = GetFragmentParameters(url);

			if (!parameters.TryGetValue(State, out var state))
			{
				throw new VkApiException($"Параметр {State} не найден");
			}

			return state;
		}

		private static int GetExpiresIn(Uri url)
		{
			var parameters = GetFragmentParameters(url);

			if (!parameters.TryGetValue(ExpiresIn, out var expiresIn))
			{
				throw new VkApiException($"Параметр {ExpiresIn} не найден");
			}

			return int.Parse(expiresIn);
		}

		private static long GetUserId(Uri url)
		{
			var parameters = GetFragmentParameters(url);

			if (!parameters.TryGetValue(UserId, out var userId))
			{
				throw new VkApiException($"Параметр {UserId} не найден");
			}

			return long.Parse(userId);
		}

		private static Dictionary<string, string> GetFragmentParameters(Uri url)
		{
			var cleanFragment = url.Fragment.Replace("#", string.Empty);

			return GetParams(cleanFragment);
		}

		private static Dictionary<string, string> GetParams(string query)
		{
			return query.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries)
				.ToDictionary(x => x.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[0],
					x => x.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
		}
	}
}