using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PagesCategory : IPagesCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с wiki.
		/// </summary>
		/// <param name="vk"> API. </param>
		public PagesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public Page Get(PagesGetParams @params)
		{
			return _vk.Call(methodName: "pages.get", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "page_id", @params.PageId }
				, { "global", @params.Global }
				, { "site_preview", @params.SitePreview }
				, { "title", @params.Title }
				, { "need_source", @params.NeedSource }
				, { "need_html", @params.NeedHtml }
			});
		}

		/// <inheritdoc />
		public long Save(string text, long groupId, long userId, string title, long? pageId)
		{
			var parameters = new VkParameters
			{
				{ "text", text },
				{ "group_id", groupId },
				{ "user_id", userId },
				{ "title", title },
				{ "page_id", pageId }
			};

			return _vk.Call(methodName: "pages.save", parameters: parameters);
		}

		/// <inheritdoc />
		public long SaveAccess(long pageId
								, long groupId
								, long? userId = null
								, AccessPages view = AccessPages.All
								, AccessPages edit = AccessPages.Leaders)
		{
			var parameters = new VkParameters
			{
				{ "page_id", pageId }, { "group_id", groupId }, { "user_id", userId }, { "view", view }, { "edit", edit }
			};

			return _vk.Call(methodName: "pages.saveAccess", parameters: parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<PageVersion> GetHistory(long pageId, long groupId, long? userId = null)
		{
			var parameters = new VkParameters
			{
				{ "page_id", pageId }, { "group_id", groupId }, { "user_id", userId }
			};

			VkResponseArray result = _vk.Call(methodName: "pages.getHistory", parameters: parameters);

			return result.ToReadOnlyCollectionOf<PageVersion>(selector: x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Page> GetTitles(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			VkResponseArray result = _vk.Call(methodName: "pages.getTitles", parameters: parameters);

			return result.ToReadOnlyCollectionOf<Page>(selector: x => x);
		}

		/// <inheritdoc />
		public Page GetVersion(long versionId, long groupId, bool needHtml = false, long? userId = null)
		{
			var parameters = new VkParameters
			{
				{ "version_id", versionId }, { "group_id", groupId }, { "user_id", userId }, { "need_html", needHtml }
			};

			return _vk.Call(methodName: "pages.getVersion", parameters: parameters);
		}

		/// <inheritdoc />
		public string ParseWiki(string text, ulong groupId)
		{
			var parameters = new VkParameters
			{
				{ "text", text }, { "group_id", groupId }
			};

			return _vk.Call(methodName: "pages.parseWiki", parameters: parameters);
		}

		/// <inheritdoc />
		public bool ClearCache(Uri url)
		{
			var parameters = new VkParameters
			{
				{ "url", url }
			};

			return _vk.Call(methodName: "pages.clearCache", parameters: parameters);
		}
	}
}