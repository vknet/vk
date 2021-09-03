using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class ImplicitFlowVkAuthorization : IVkAuthorization<ImplicitFlowPageType>
	{
		private const string AccessToken = "access_token";

		private const string State = "state";

		private const string ExpiresIn = "expires_in";

		private const string UserId = "user_id";

		/// <inheritdoc />
		[NotNull]
		public AuthorizationResult GetAuthorizationResult(Uri url)
		{
			var pageType = GetPageType(url);

			if (pageType != ImplicitFlowPageType.Result)
			{
				throw new VkAuthorizationException($"{ImplicitFlowPageType.Result} page expected, but was {pageType}.");
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
			var parameters = GetQueryParameters(url);

			if (parameters.ContainsKey("sid"))
			{
				return ImplicitFlowPageType.Captcha;
			}

			if (parameters.ContainsKey("__q_hash"))
			{
				return ImplicitFlowPageType.Consent;
			}

			var original = url.OriginalString;

			if (original.StartsWith("https://oauth.vk.com/blank.html#access_token"))
			{
				return ImplicitFlowPageType.Result;
			}

			if (original.StartsWith("https://oauth.vk.com/authorize"))
			{
				return ImplicitFlowPageType.LoginPassword;
			}

			if (original.StartsWith("https://oauth.vk.com/blank.html#error"))
			{
				return ImplicitFlowPageType.Error;
			}

			if (original.Contains("/login?act=authcheck"))
			{
				return ImplicitFlowPageType.TwoFactor;
			}

			throw new VkAuthorizationException($"Failed to determine page type from url: {original}");
		}

		private static string GetToken(Dictionary<string, string> parameters)
		{
			if (!parameters.TryGetValue(AccessToken, out var token))
			{
				throw new VkAuthorizationException($"Missing URL parameter: '{AccessToken}'");
			}

			return token;
		}

		private static string GetState(Dictionary<string, string> parameters)
		{
			parameters.TryGetValue(State, out var state);

			return state;
		}

		private static int GetExpiresIn(Dictionary<string, string> parameters)
		{
			return parameters.TryGetValue(ExpiresIn, out var expiresIn) ? int.Parse(expiresIn) : 0;
		}

		private static long GetUserId(Dictionary<string, string> parameters)
		{
			if (!parameters.TryGetValue(UserId, out var userId))
			{
				throw new VkAuthorizationException($"Missing URL parameter: '{UserId}'");
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
				.Select(q => q.Split('='))
				.ToDictionary(x => x.First(), x => x.Last());
		}
	}
}