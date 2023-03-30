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
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckLink(url), token);

	/// <inheritdoc />
	public Task<CheckLinkResult> CheckLinkAsync(Uri url,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckLink(url), token);

	/// <inheritdoc />
	public Task<VkObject> ResolveScreenNameAsync(string screenName,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ResolveScreenName(screenName), token);

	/// <inheritdoc />
	public Task<DateTime> GetServerTimeAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetServerTime, token);

	/// <inheritdoc />
	public Task<ShortLink> GetShortLinkAsync(Uri url,
											bool isPrivate,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetShortLink(url, isPrivate), token);

	/// <inheritdoc />
	public Task<bool> DeleteFromLastShortenedAsync(string key,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteFromLastShortened(key), token);

	/// <inheritdoc />
	public Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10,
																	ulong offset = 0,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLastShortenedLinks(count, offset), token);

	/// <inheritdoc />
	public Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLinkStats(@params));
}