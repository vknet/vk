using System;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Служебные методы.
	/// </summary>
	public partial class UtilsCategory : IUtilsCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public UtilsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		[Pure]
		public LinkAccessType CheckLink(string url, bool skipAuthorization = true)
		{
			return CheckLink(url: new Uri(uriString: url), skipAuthorization: skipAuthorization);
		}

		/// <inheritdoc />
		[Pure]
		public LinkAccessType CheckLink(Uri url, bool skipAuthorization = true)
		{
			var parameters = new VkParameters { { "url", url } };

			return _vk.Call(methodName: "utils.checkLink", parameters: parameters, skipAuthorization: skipAuthorization);
		}

		/// <inheritdoc />
		[Pure]
		public VkObject ResolveScreenName(string screenName)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => screenName);

			var parameters = new VkParameters { { "screen_name", screenName } };

			return _vk.Call(methodName: "utils.resolveScreenName", parameters: parameters, skipAuthorization: true);
		}

		/// <inheritdoc />
		[Pure]
		public DateTime GetServerTime()
		{
			return _vk.Call<DateTime>(methodName: "utils.getServerTime", parameters: VkParameters.Empty, skipAuthorization: true);
		}

		/// <inheritdoc />
		public ShortLink GetShortLink(Uri url, bool isPrivate)
		{
			var parameters = new VkParameters
			{
					{ "url", url }
					, { "private", isPrivate }
			};

			return _vk.Call<ShortLink>(methodName: "utils.getShortLink", parameters: parameters);
		}

		/// <inheritdoc />
		public bool DeleteFromLastShortened(string key)
		{
			return _vk.Call<bool>(methodName: "utils.deleteFromLastShortened", parameters: new VkParameters { { "key", key } });
		}

		/// <inheritdoc />
		public VkCollection<ShortLink> GetLastShortenedLinks(ulong count = 10, ulong offset = 0)
		{
			return _vk.Call<VkCollection<ShortLink>>(methodName: "utils.getLastShortenedLinks"
					, parameters: new VkParameters
					{
							{ "count", count }
							, { "offset", offset }
					});
		}

		/// <inheritdoc />
		public LinkStatsResult GetLinkStats(LinkStatsParams @params)
		{
			return _vk.Call<LinkStatsResult>(methodName: "utils.getLinkStats", parameters: @params);
		}
	}
}