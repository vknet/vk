using System;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class UtilsCategory
	{
		/// <inheritdoc />
		public Task<LinkAccessType> CheckLinkAsync(string url)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CheckLink(url: url));
		}

		/// <inheritdoc />
		public Task<LinkAccessType> CheckLinkAsync(Uri url)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CheckLink(url: url));
		}

		/// <inheritdoc />
		public Task<VkObject> ResolveScreenNameAsync(string screenName)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>ResolveScreenName(screenName: screenName));
		}

		/// <inheritdoc />
		public Task<DateTime> GetServerTimeAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetServerTime());
		}

		/// <inheritdoc />
		public Task<ShortLink> GetShortLinkAsync(Uri url, bool isPrivate)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetShortLink(url: url, isPrivate: isPrivate));
		}

		/// <inheritdoc />
		public Task<bool> DeleteFromLastShortenedAsync(string key)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteFromLastShortened(key: key));
		}

		/// <inheritdoc />
		public Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10, ulong offset = 0)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetLastShortenedLinks(count: count, offset: offset));
		}

		/// <inheritdoc />
		public Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetLinkStats(@params: @params));
		}
	}
}