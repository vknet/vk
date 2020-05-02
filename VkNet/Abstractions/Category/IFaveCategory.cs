using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Fave;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IFaveCategoryAsync" />
	public partial interface IFaveCategory : IFaveCategoryAsync
	{
		/// <inheritdoc cref = "IFaveCategoryAsync.AddArticleAsync"/>
		bool AddArticle(Uri url, string @ref = null, string trackCode = null, string source = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddLinkAsync(Uri)"/>
		bool AddLink(Uri link);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddPageAsync"/>
		bool AddPage(ulong? userId = null, ulong? groupId = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddPostAsync"/>
		bool AddPost(FaveAddPostParams addPostParams);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddProductAsync"/>
		bool AddProduct(long ownerId, long id, string accessKey = null, string @ref = null, string source = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddTagAsync"/>
		FaveTag AddTag(string name, string position);

		/// <inheritdoc cref = "IFaveCategoryAsync.AddVideoAsync"/>
		bool AddVideo(long ownerId, long id, string accessKey = null, string @ref = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.EditTagAsync"/>
		bool EditTag(long id, string name);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetAsync"/>
		VkCollection<FaveGetObject> Get(FaveGetParams @params);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetPagesAsync"/>
		VkCollection<FaveGetPagesObject> GetPages(FavePageType type = null,
												  IEnumerable<string> fields = null,
												  ulong? offset = null,
												  ulong? count = null,
												  long? tagId = null);

		/// <inheritdoc cref = "IFaveCategoryAsync.GetTagsAsync"/>
		VkCollection<FaveTag> GetTags();

		/// <inheritdoc cref = "IFaveCategoryAsync.MarkSeenAsync"/>
		bool MarkSeen();

		/// <inheritdoc cref = "IFaveCategoryAsync.RemoveArticleAsync"/>
		bool RemoveArticle(long ownerId, ulong articleId, string @ref = null);

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
		bool SetTags(FaveSetTagsParams @params);

		/// <inheritdoc cref = "IFaveCategoryAsync.TrackPageInteractionAsync"/>
		bool TrackPageInteraction(ulong? userId = null, ulong? groupId = null);
	}
}