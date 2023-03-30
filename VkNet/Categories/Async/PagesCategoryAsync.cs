using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PagesCategory
{
	/// <inheritdoc />
	public Task<Page> GetAsync(PagesGetParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params));

	/// <inheritdoc />
	public Task<long> SaveAsync(string text,
								long groupId,
								long userId,
								string title,
								long? pageId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(text, groupId, userId, title, pageId));

	/// <inheritdoc />
	public Task<long> SaveAccessAsync(long pageId,
									long groupId,
									long? userId = null,
									AccessPages view = AccessPages.All,
									AccessPages edit = AccessPages.Leaders,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveAccess(pageId, groupId, userId, view , edit));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PageVersion>> GetHistoryAsync(long pageId,
																long groupId,
																long? userId = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHistory(pageId, groupId, userId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Page>> GetTitlesAsync(long groupId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTitles(groupId));

	/// <inheritdoc />
	public Task<Page> GetVersionAsync(long versionId,
									long groupId,
									bool needHtml = false,
									long? userId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetVersion(versionId, groupId, needHtml, userId));

	/// <inheritdoc />
	public Task<string> ParseWikiAsync(string text,
										ulong groupId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ParseWiki(text, groupId));

	/// <inheritdoc />
	public Task<bool> ClearCacheAsync(Uri url,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ClearCache(url));
}