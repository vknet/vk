using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PagesCategory
	{
		/// <inheritdoc />
		public async Task<Page> GetAsync(PagesGetParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Pages.Get(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> SaveAsync(string text, long? pageId, long groupId, long userId, string title)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Pages.Save(text: text, pageId: pageId, groupId: groupId, userId: userId, title: title));
		}

		/// <inheritdoc />
		public async Task<long> SaveAccessAsync(long pageId
												, long groupId
												, long? userId = null
												, AccessPages view = AccessPages.All
												, AccessPages edit = AccessPages.Leaders)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Pages.SaveAccess(pageId: pageId, groupId: groupId, userId: userId, view: view));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<PageVersion>> GetHistoryAsync(long pageId, long groupId, long? userId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Pages.GetHistory(pageId: pageId, groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Page>> GetTitlesAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Pages.GetTitles(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<Page> GetVersionAsync(long versionId, long groupId, bool needHtml = false, long? userId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Pages.GetVersion(versionId: versionId, groupId: groupId, needHtml: needHtml, userId: userId));
		}

		/// <inheritdoc />
		public async Task<string> ParseWikiAsync(string text, ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Pages.ParseWiki(text: text, groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> ClearCacheAsync(Uri url)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Pages.ClearCache(url: url));
		}
	}
}