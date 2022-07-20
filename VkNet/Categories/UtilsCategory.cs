using System;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class UtilsCategory : IUtilsCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public UtilsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		[Pure]
		public LinkAccessType CheckLink(string url)
		{
			return CheckLink(new Uri(uriString: url));
		}

		/// <inheritdoc />
		[Pure]
		public LinkAccessType CheckLink(Uri url)
		{
			var parameters = new VkParameters
			{
				{ "url", url }
			};

			return _vk.Call("utils.checkLink", parameters);
		}

		/// <inheritdoc />
		[Pure]
		public VkObject ResolveScreenName(string screenName)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => screenName);

			var parameters = new VkParameters
			{
				{ "screen_name", screenName }
			};

			return _vk.Call("utils.resolveScreenName", parameters);
		}

		/// <inheritdoc />
		[Pure]
		public DateTime GetServerTime()
		{
			return _vk.Call<DateTime>("utils.getServerTime", VkParameters.Empty);
		}

		/// <inheritdoc />
		public ShortLink GetShortLink(Uri url, bool isPrivate)
		{
			var parameters = new VkParameters
			{
				{ "url", url },
				{ "private", isPrivate }
			};

			return _vk.Call<ShortLink>("utils.getShortLink", parameters);
		}

		/// <inheritdoc />
		public bool DeleteFromLastShortened(string key)
		{
			return _vk.Call<bool>("utils.deleteFromLastShortened",
				new VkParameters
				{
					{ "key", key }
				});
		}

		/// <inheritdoc />
		public VkCollection<ShortLink> GetLastShortenedLinks(ulong count = 10, ulong offset = 0)
		{
			return _vk.Call<VkCollection<ShortLink>>("utils.getLastShortenedLinks",
				new VkParameters
				{
					{ "count", count },
					{ "offset", offset }
				});
		}

		/// <inheritdoc />
		public LinkStatsResult GetLinkStats(LinkStatsParams @params)
		{
			return _vk.Call<LinkStatsResult>("utils.getLinkStats",
				new VkParameters
				{
					{ "key", @params.Key }
					, { "access_key", @params.AccessKey }
					, { "interval", @params.Interval }
					, { "intervals_count", @params.IntervalsCount }
					, { "extended", @params.Extended }
				});
		}
	}
}