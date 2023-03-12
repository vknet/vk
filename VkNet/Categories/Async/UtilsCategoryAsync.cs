using System;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class UtilsCategory
{
	/// <inheritdoc />
	public Task<CheckLinkResult> CheckLinkAsync(string url) => TypeHelper.TryInvokeMethodAsync(func: () => CheckLink(url: url));

	/// <inheritdoc />
	public Task<CheckLinkResult> CheckLinkAsync(Uri url) => TypeHelper.TryInvokeMethodAsync(func: () => CheckLink(url: url));

	/// <inheritdoc />
	public Task<VkObject> ResolveScreenNameAsync(string screenName) =>
		TypeHelper.TryInvokeMethodAsync(func: () => ResolveScreenName(screenName: screenName));

	/// <inheritdoc />
	public Task<DateTime> GetServerTimeAsync() => TypeHelper.TryInvokeMethodAsync(func: () => GetServerTime());

	/// <inheritdoc />
	public Task<ShortLink> GetShortLinkAsync(Uri url, bool isPrivate) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetShortLink(url, isPrivate));

	/// <inheritdoc />
	public Task<bool> DeleteFromLastShortenedAsync(string key) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteFromLastShortened(key: key));

	/// <inheritdoc />
	public Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10, ulong offset = 0) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetLastShortenedLinks(count, offset));

	/// <inheritdoc />
	public Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetLinkStats(@params: @params));
}