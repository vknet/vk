using System;
using System.Collections.Generic;
using VkNet.Model.RequestParams.Fave;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с закладками.
	/// </summary>
	public partial interface IFaveCategory : IFaveCategoryAsync
	{
		/// <inheritdoc cref = "IFaveCategoryAsync.AddArticleAsync"/>
		bool AddArticle(string url, string @ref, string trackCode, string source);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddLinkAsync(Uri)"/>
		bool AddLink(Uri link);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddPageAsync"/>
		bool AddPage(ulong? userId = null, ulong? groupId = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddPostAsync"/>
		bool AddPost(FaveAddPostParams addPostParams);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddProductAsync"/>
		bool AddProduct(long ownerId, long id, string accessKey, string @ref, string source);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddTagAsync"/>
		object AddTag(string name, string position);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddVideoAsync"/>
		bool AddVideo(long ownerId, long id, string accessKey, string @ref);

		/// <inheritdoc cref = "IFaveCategoryAsync.EditTagAsync"/>
		bool EditTag(long id, string name);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetAsync"/>
		IEnumerable<object> Get(FaveGetParams faveGetParams);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetPagesAsync"/>
		object GetPages(string type, IEnumerable<string> fields, ulong? offset = null, ulong? count = null, long? tagId = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetTagsAsync"/>
		IEnumerable<object> GetTags();

		/// <inheritdoc cref = "IFaveCategoryAsync.MarkSeenAsync"/>
		bool MarkSeen();

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveArticleAsync"/>
		bool RemoveArticle(long ownerId, ulong articleId, string @ref);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveLinkAsync" />
		bool RemoveLink(string linkId);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemovePageAsync"/>
		bool RemovePage(long? userId = null, long? groupId = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemovePostAsync"/>
		bool RemovePost(long ownerId, long id);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveProductAsync"/>
		bool RemoveProduct(long ownerId, long id);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveTagAsync"/>
		bool RemoveTag(long id);

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveVideoAsync"/>
		bool RemoveVideo(long ownerId, long id);

		/// <inheritdoc cref = "IFaveCategoryAsync.ReorderTagsAsync"/>
		bool ReorderTags(IEnumerable<long> ids);

		/// <inheritdoc cref = "IFaveCategoryAsync.SetPageTagsAsync"/>
		bool SetPageTags(ulong? userId = null, ulong? groupId = null, IEnumerable<long> tagIds = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.SetTagsAsync"/>
		bool SetTags(FaveSetTagsParams faveSetTagsParams);

		/// <inheritdoc cref = "IFaveCategoryAsync.TrackPageInteractionAsync"/>
		bool TrackPageInteraction(ulong? userId = null, ulong? groupId = null);
	}
}