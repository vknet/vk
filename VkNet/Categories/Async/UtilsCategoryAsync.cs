using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class UtilsCategory
{
	/// <inheritdoc />
	public Task<CheckLinkResult> CheckLinkAsync(string url,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckLink(url));

	/// <inheritdoc />
	public Task<CheckLinkResult> CheckLinkAsync(Uri url,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckLink(url));

	/// <inheritdoc />
	public Task<VkObject> ResolveScreenNameAsync(string screenName,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ResolveScreenName(screenName));

	/// <inheritdoc />
	public Task<DateTime> GetServerTimeAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetServerTime);

	/// <inheritdoc />
	public Task<ShortLink> GetShortLinkAsync(Uri url,
											bool isPrivate,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetShortLink(url, isPrivate));

	/// <inheritdoc />
	public Task<bool> DeleteFromLastShortenedAsync(string key,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteFromLastShortened(key));

	/// <inheritdoc />
	public Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10,
																	ulong offset = 0,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLastShortenedLinks(count, offset));

	/// <inheritdoc />
	public Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLinkStats(@params));
}