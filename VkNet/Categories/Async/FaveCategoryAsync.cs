using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Fave;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class FaveCategory
	{
		/// <inheritdoc/>
		public Task<bool> AddArticleAsync(Uri url, string @ref = null, string trackCode = null, string source = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddArticle(url, @ref, trackCode, source));
		}

		/// <inheritdoc/>
		public Task<bool> AddLinkAsync(Uri link)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddLink(link));
		}

		/// <inheritdoc/>
		public Task<bool> AddPageAsync(ulong? userId = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddPage(userId, groupId));
		}

		/// <inheritdoc/>
		public Task<bool> AddPostAsync(FaveAddPostParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddPost(@params));
		}

		/// <inheritdoc/>
		public Task<bool> AddProductAsync(long ownerId, long id, string accessKey = null, string @ref = null, string source = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddProduct(ownerId, id, accessKey, @ref, source));
		}

		/// <inheritdoc/>
		public Task<FaveTag> AddTagAsync(string name, string position)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddTag(name, position));
		}

		/// <inheritdoc/>
		public Task<bool> AddVideoAsync(long ownerId, long id, string accessKey = null, string @ref = null)

		{
			return TypeHelper.TryInvokeMethodAsync(() => AddVideo(ownerId, id, accessKey, @ref));
		}

		/// <inheritdoc/>
		public Task<bool> EditTagAsync(long id, string name)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditTag(id, name));
		}

		/// <inheritdoc/>
		public Task<VkCollection<FaveGetObject>> GetAsync(FaveGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(@params));
		}

		/// <inheritdoc/>
		public Task<VkCollection<FaveGetPagesObject>> GetPagesAsync(FavePageType type = null,
																	IEnumerable<string> fields = null,
																	ulong? offset = null,
																	ulong? count = null,
																	long? tagId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPages(type, fields, offset, count, tagId));
		}

		/// <inheritdoc/>
		public Task<VkCollection<FaveTag>> GetTagsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTags());
		}

		/// <inheritdoc/>
		public Task<bool> MarkSeenAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => MarkSeen());
		}

		/// <inheritdoc/>
		public Task<bool> RemoveArticleAsync(long ownerId, ulong articleId, string @ref = null)

		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveArticle(ownerId, articleId, @ref));
		}

		/// <inheritdoc/>
		public Task<bool> RemoveLinkAsync(string linkId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveLink(linkId));
		}

		/// <inheritdoc/>
		public Task<bool> RemovePageAsync(long? userId = null, long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemovePage(userId, groupId));
		}

		/// <inheritdoc/>
		public Task<bool> RemovePostAsync(long ownerId, long id)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemovePost(ownerId, id));
		}

		/// <inheritdoc/>
		public Task<bool> RemoveProductAsync(long ownerId, long id)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveProduct(ownerId, id));
		}

		/// <inheritdoc/>
		public Task<bool> RemoveTagAsync(long id)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveTag(id));
		}

		/// <inheritdoc/>
		public Task<bool> RemoveVideoAsync(long ownerId, long id)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveVideo(ownerId, id));
		}

		/// <inheritdoc/>
		public Task<bool> ReorderTagsAsync(IEnumerable<long> ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ReorderTags(ids));
		}

		/// <inheritdoc/>
		public Task<bool> SetPageTagsAsync(ulong? userId = null, ulong? groupId = null, IEnumerable<long> tagIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetPageTags(userId, groupId, tagIds));
		}

		/// <inheritdoc/>
		public Task<bool> SetTagsAsync(FaveSetTagsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetTags(@params));
		}

		/// <inheritdoc/>
		public Task<bool> TrackPageInteractionAsync(ulong? userId = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => TrackPageInteraction(userId, groupId));
		}
	}
}