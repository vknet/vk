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
		public async Task<LinkAccessType> CheckLinkAsync(string url, bool skipAuthorization = true)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.CheckLink(url: url, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<LinkAccessType> CheckLinkAsync(Uri url, bool skipAuthorization = true)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.CheckLink(url: url, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkObject> ResolveScreenNameAsync(string screenName)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.ResolveScreenName(screenName: screenName));
		}

		/// <inheritdoc />
		public async Task<DateTime> GetServerTimeAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetServerTime());
		}

		/// <inheritdoc />
		public async Task<ShortLink> GetShortLinkAsync(Uri url, bool isPrivate)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetShortLink(url: url, isPrivate: isPrivate));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteFromLastShortenedAsync(string key)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.DeleteFromLastShortened(key: key));
		}

		/// <inheritdoc />
		public async Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10, ulong offset = 0)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetLastShortenedLinks(count: count, offset: offset));
		}

		/// <inheritdoc />
		public async Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Utils.GetLinkStats(@params: @params));
		}
	}
}