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
		public Task<LinkAccessType> CheckLinkAsync(string url, bool skipAuthorization = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.CheckLink(url: url, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<LinkAccessType> CheckLinkAsync(Uri url, bool skipAuthorization = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.CheckLink(url: url, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkObject> ResolveScreenNameAsync(string screenName)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.ResolveScreenName(screenName: screenName));
		}

		/// <inheritdoc />
		public Task<DateTime> GetServerTimeAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetServerTime());
		}

		/// <inheritdoc />
		public Task<ShortLink> GetShortLinkAsync(Uri url, bool isPrivate)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetShortLink(url: url, isPrivate: isPrivate));
		}

		/// <inheritdoc />
		public Task<bool> DeleteFromLastShortenedAsync(string key)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.DeleteFromLastShortened(key: key));
		}

		/// <inheritdoc />
		public Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10, ulong offset = 0)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetLastShortenedLinks(count: count, offset: offset));
		}

		/// <inheritdoc />
		public Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetLinkStats(@params: @params));
		}
	}
}