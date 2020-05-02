using System;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPagesCategoryAsync"/>
	public interface IPagesCategory : IPagesCategoryAsync
	{
		/// <inheritdoc cref="IPagesCategoryAsync.GetAsync"/>
		Page Get(PagesGetParams @params);

		/// <inheritdoc cref="IPagesCategoryAsync.SaveAsync"/>
		long Save(string text, long groupId, long userId, string title, long? pageId);

		/// <inheritdoc cref="IPagesCategoryAsync.SaveAccessAsync"/>
		long SaveAccess(long pageId
						, long groupId
						, long? userId = null
						, AccessPages view = AccessPages.All
						, AccessPages edit = AccessPages.Leaders);

		/// <inheritdoc cref="IPagesCategoryAsync.GetHistoryAsync"/>
		ReadOnlyCollection<PageVersion> GetHistory(long pageId, long groupId, long? userId = null);

		/// <inheritdoc cref="IPagesCategoryAsync.GetTitlesAsync"/>
		ReadOnlyCollection<Page> GetTitles(long groupId);

		/// <inheritdoc cref="IPagesCategoryAsync.GetVersionAsync"/>
		Page GetVersion(long versionId, long groupId, bool needHtml = false, long? userId = null);

		/// <inheritdoc cref="IPagesCategoryAsync.ParseWikiAsync"/>
		string ParseWiki(string text, ulong groupId);

		/// <inheritdoc cref="IPagesCategoryAsync.ClearCacheAsync"/>
		bool ClearCache(Uri url);
	}
}