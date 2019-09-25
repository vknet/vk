using System;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Fave;
using VkNet.Model.RequestParams.Fave;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class FaveCategory : IFaveCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с закладками.
		/// </summary>
		/// <param name="vk"> API. </param>
		public FaveCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public bool AddArticle(Uri url, string @ref = null, string trackCode = null, string source = null)
		{
			return _vk.Call<bool>("fave.addArticle", new VkParameters
			{
				{ "url", url },
				{ "ref", @ref },
				{ "track_code", trackCode },
				{ "source", source }
			});
		}

		/// <inheritdoc/>
		public bool AddLink(Uri link)
		{
			return _vk.Call<bool>("fave.addLink", new VkParameters { { "link", link } });
		}

		/// <inheritdoc/>
		public bool AddPage(ulong? userId = null, ulong? groupId = null)
		{
			return _vk.Call<bool>("fave.addPage", new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId }
			});
		}

		/// <inheritdoc/>
		public bool AddPost(FaveAddPostParams addPostParams)
		{
			return _vk.Call<bool>("fave.addPost", new VkParameters
			{
				{ "owner_id", addPostParams.OwnerId },
				{ "id", addPostParams.Id },
				{ "access_key", addPostParams.AccessKey },
				{ "ref", addPostParams.Ref },
				{ "track_code", addPostParams.TrackCode },
				{ "source", addPostParams.Source }
			});
		}

		/// <inheritdoc/>
		public bool AddProduct(long ownerId, long id, string accessKey = null, string @ref = null, string source = null)
		{
			return _vk.Call<bool>("fave.addProduct", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "id", id },
				{ "access_key", accessKey },
				{ "ref", @ref },
				{ "source", source }
			});
		}

		/// <inheritdoc/>
		public FaveTag AddTag(string name, string position)
		{
			return _vk.Call<FaveTag>("fave.addTag", new VkParameters
			{
				{ "name", name },
				{ "position", position }
			});
		}

		/// <inheritdoc/>
		public bool AddVideo(long ownerId, long id, string accessKey = null, string @ref = null)
		{
			return _vk.Call<bool>("fave.addVideo", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "id", id },
				{ "access_key", accessKey },
				{ "ref", @ref }
			});
		}

		/// <inheritdoc/>
		public bool EditTag(long id, string name)
		{
			return _vk.Call<bool>("fave.editTag", new VkParameters
			{
				{ "id", id },
				{ "name", name }
			});
		}

		/// <inheritdoc/>
		public VkCollection<FaveGetObject> Get(FaveGetParams getParams)
		{
			return _vk.Call<VkCollection<FaveGetObject>>("fave.get", new VkParameters
			{
				{ "item_type", getParams.ItemType },
				{ "fields", getParams.Fields },
				{ "extended", getParams.Extended },
				{ "tag_id", getParams.TagId },
				{ "offset", getParams.Offset },
				{ "count", getParams.Count },
				{ "is_from_snackbar", getParams.IsFromSnackbar }
			});
		}

		/// <inheritdoc/>
		public VkCollection<FaveGetPagesObject> GetPages(FavePageType type = null,
														 IEnumerable<string> fields = null,
														 ulong? offset = null,
														 ulong? count = null,
														 long? tagId = null)
		{
			return _vk.Call<VkCollection<FaveGetPagesObject>>("fave.getPages", new VkParameters
			{
				{ "type", type },
				{ "fields", fields },
				{ "offset", offset },
				{ "count", count },
				{ "tag_id", tagId }
			});
		}

		/// <inheritdoc/>
		public VkCollection<FaveTag> GetTags()
		{
			return _vk.Call<VkCollection<FaveTag>>("fave.getTags", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public bool MarkSeen()
		{
			return _vk.Call<bool>("fave.markSeen", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public bool RemoveArticle(long ownerId, ulong articleId, string @ref = null)
		{
			return _vk.Call<bool>("fave.removeArticle", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "article_id", articleId },
				{ "ref", @ref }
			});
		}

		/// <inheritdoc/>
		public bool RemoveLink(string linkId)
		{
			return _vk.Call<bool>("fave.removeLink", new VkParameters { { "link_id", linkId } });
		}

		/// <inheritdoc/>
		public bool RemovePage(long? userId = null, long? groupId = null)
		{
			return _vk.Call<bool>("fave.removePage", new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId }
			});
		}

		/// <inheritdoc/>
		public bool RemovePost(long ownerId, long id)
		{
			return _vk.Call<bool>("fave.removePost", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "id", id }
			});
		}

		/// <inheritdoc/>
		public bool RemoveProduct(long ownerId, long id)
		{
			return _vk.Call<bool>("fave.removeProduct", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "id", id }
			});
		}

		/// <inheritdoc/>
		public bool RemoveTag(long id)
		{
			return _vk.Call<bool>("fave.removeTag", new VkParameters { { "id", id } });
		}

		/// <inheritdoc/>
		public bool RemoveVideo(long ownerId, long id)
		{
			return _vk.Call<bool>("fave.removeVideo", new VkParameters
			{
				{ "owner_id", ownerId },
				{ "id", id }
			});
		}

		/// <inheritdoc/>
		public bool ReorderTags(IEnumerable<long> ids)
		{
			return _vk.Call<bool>("fave.reorderTags", new VkParameters { { "ids", ids } });
		}

		/// <inheritdoc/>
		public bool SetPageTags(ulong? userId = null, ulong? groupId = null, IEnumerable<long> tagIds = null)
		{
			return _vk.Call<bool>("fave.setPageTags", new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId },
				{ "tag_ids", tagIds }
			});
		}

		/// <inheritdoc/>
		public bool SetTags(FaveSetTagsParams setTagsParams)
		{
			return _vk.Call<bool>("fave.setTags", new VkParameters
			{
				{ "item_type", setTagsParams.ItemType },
				{ "link_id", setTagsParams.LinkId },
				{ "link_url", setTagsParams.LinkUrl },
				{ "item_owner_id", setTagsParams.ItemOwnerId },
				{ "item_id", setTagsParams.ItemId },
				{ "tag_ids", setTagsParams.TagIds }
			});
		}

		/// <inheritdoc/>
		public bool TrackPageInteraction(ulong? userId = null, ulong? groupId = null)
		{
			return _vk.Call<bool>("fave.trackPageInteraction", new VkParameters
			{
				{ "user_id", userId },
				{ "group_id", groupId }
			});
		}
	}
}