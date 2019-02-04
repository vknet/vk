using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <inheritdoc />
	[UsedImplicitly]
	[SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
	public class ImplicitFlowVkAuthorization : IVkAuthorization<ImplicitFlowPageType>
	{
		private const string AccessToken = "access_token";

		private const string State = "state";

		private const string ExpiresIn = "expires_in";

		private const string UserId = "user_id";

		/// <inheritdoc />
		[NotNull]
		[UsedImplicitly]
		public AuthorizationResult GetAuthorizationResult(Uri url)
		{
			var pageType = GetPageType(url);

			if (pageType != ImplicitFlowPageType.Result)
			{
				throw new ArgumentException("URL должен начинаться со строки 'https://oauth.vk.com/blank.html'", nameof(url));
			}

			var parameters = GetFragmentParameters(url);

			var token = GetToken(parameters);
			var state = GetState(parameters);
			var expireIn = GetExpiresIn(parameters);
			var userId = GetUserId(parameters);

			return new AuthorizationResult
			{
				UserId = userId,
				ExpiresIn = expireIn,
				AccessToken = token,
				State = state
			};
		}

		/// <inheritdoc />
		public ImplicitFlowPageType GetPageType(Uri url)
		{
			var original = url.OriginalString;

			if (original.StartsWith("https://oauth.vk.com/blank.html#access_token"))
			{
				return ImplicitFlowPageType.Result;
			}

			if (original.StartsWith("https://oauth.vk.com/blank.html#error"))
			{
				return ImplicitFlowPageType.Error;
			}

			if (original.StartsWith("https://m.vk.com/login?act=authcheck"))
			{
				return ImplicitFlowPageType.TwoFactor;
			}

			var parameters = GetQueryParameters(url);

			if (parameters.ContainsKey("sid"))
			{
				return ImplicitFlowPageType.Captcha;
			}

			return parameters.ContainsKey("__q_hash")
				? ImplicitFlowPageType.Consent
				: ImplicitFlowPageType.LoginPassword;
		}

		private static string GetToken(Dictionary<string, string> parameters)
		{
			if (!parameters.TryGetValue(AccessToken, out var token))
			{
				throw new VkApiException($"Параметр {AccessToken} не найден");
			}

			return token;
		}

		private static string GetState(Dictionary<string, string> parameters)
		{
			if (!parameters.TryGetValue(State, out var state))
			{
				throw new VkApiException($"Параметр {State} не найден");
			}

			return state;
		}

		private static int GetExpiresIn(Dictionary<string, string> parameters)
		{
			if (!parameters.TryGetValue(ExpiresIn, out var expiresIn))
			{
				throw new VkApiException($"Параметр {ExpiresIn} не найден");
			}

			return int.Parse(expiresIn);
		}

		private static long GetUserId(Dictionary<string, string> parameters)
		{
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

		private static Dictionary<string, string> GetQueryParameters(Uri url)
		{
			var cleanFragment = url.Query.Replace("?", string.Empty);

			return GetParams(cleanFragment);
		}

		private static Dictionary<string, string> GetParams(string query)
		{
			return query.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries)
				.ToDictionary(x => x.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[0],
					ParseDictionaryValue);
		}

		private static string ParseDictionaryValue(string x)
		{
			var parametersPair = x.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

			return parametersPair.Length > 1 ? parametersPair[1] : string.Empty;
		}
	}
}