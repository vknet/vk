using VkNet.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы со стеной пользователя.
	/// </summary>
	public partial class WallCategory : IWallCategory
	{
		private readonly VkApi _vk;

		/// <summary>
		///
		/// </summary>
		/// <param name="vk"></param>
		public WallCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public WallGetObject Get(WallGetParams @params, bool skipAuthorization = false)
		{
			if ( @params.Filter != null && @params.Filter == WallFilter.Suggests && @params.OwnerId >= 0 )
			{
				throw new ArgumentException("OwnerID must be negative in case filter equal to Suggests",
					nameof(@params));
			}

			return
				_vk.Call("wall.get", @params,
					skipAuthorization); //, @params.Filter != WallFilter.Suggests && @params.Filter != WallFilter.Postponed);
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(WallGetCommentsParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("wall.getComments", @params, skipAuthorization).ToVkCollectionOf<Comment>(x => x);
		}

		/// <inheritdoc />
    public WallGetObject GetById(IEnumerable<string> posts, bool? extended = null, long? copyHistoryDepth = null, ProfileFields fields = null, bool skipAuthorization = false)
    {
      if (posts == null)
      {
        throw new ArgumentNullException(nameof(posts));
      }

      if (!posts.Any())
      {
        throw new ArgumentException("Posts collection was empty.", nameof(posts));
      }

      var parameters = new VkParameters {
                { "posts", posts },
                { "extended", extended },
                { "copy_history_depth", copyHistoryDepth },
                { "fields", fields }
            };

      return _vk.Call("wall.getById", parameters, skipAuthorization);
    }

		/// <inheritdoc />
		public long Post(WallPostParams @params)
		{
			return _vk.Call("wall.post", @params)["post_id"];
		}

		/// <inheritdoc />
		public RepostResult Repost(string @object, string message, long? groupId, bool markAsAds)
		{
			VkErrors.ThrowIfNullOrEmpty(() => @object);
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{"object", @object},
				{"message", message},
				{"group_id", groupId},
				{"mark_as_ads", markAsAds}
			};

			return _vk.Call("wall.repost", parameters);
		}

		/// <inheritdoc />
		public bool Edit(WallEditParams @params)
		{
			return _vk.Call("wall.edit", @params);
		}

		/// <inheritdoc />
		public bool Delete(long? ownerId = null, long? postId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => postId);

			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId}
			};

			return _vk.Call("wall.delete", parameters);
		}

		/// <inheritdoc />
		public bool Restore(long? ownerId = null, long? postId = null)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId}
			};

			return _vk.Call("wall.restore", parameters);
		}

		/// <inheritdoc />
		public long CreateComment(WallCreateCommentParams @params)
		{
			return _vk.Call("wall.createComment", @params)["comment_id"];
		}

		/// <inheritdoc />
		public bool DeleteComment(long? ownerId, long commentId)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"comment_id", commentId}
			};

			return _vk.Call("wall.deleteComment", parameters);
		}

		/// <inheritdoc />
		public bool RestoreComment(long commentId, long? ownerId)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"comment_id", commentId}
			};

			return _vk.Call("wall.restoreComment", parameters);
		}

		/// <inheritdoc />
		public WallGetObject Search(WallSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("wall.search", @params, skipAuthorization);
		}

		/// <inheritdoc />
		public WallGetObject GetReposts(long? ownerId, long? postId, long? offset, long? count,
			bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId},
				{"offset", offset},
				{"count", count}
			};

			return _vk.Call("wall.getReposts", parameters, skipAuthorization);
		}

		/// <inheritdoc />
		public bool Pin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId}
			};

			return _vk.Call("wall.pin", parameters);
		}

		/// <inheritdoc />
		public bool Unpin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId}
			};

			return _vk.Call("wall.unpin", parameters);
		}

		/// <inheritdoc />
		public bool EditComment(long commentId, string message, long? ownerId = null,
			IEnumerable<MediaAttachment> attachments = null)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"comment_id", commentId},
				{"message", message},
				{"attachments", attachments}
			};

			return _vk.Call("wall.editComment", parameters);
		}

		/// <inheritdoc />
		public bool ReportPost(long ownerId, long postId, ReportReason? reason = null)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"post_id", postId},
				{"reason", reason}
			};

			return _vk.Call("wall.reportPost", parameters);
		}

		/// <inheritdoc />
		public bool ReportComment(long ownerId, long commentId, ReportReason? reason)
		{
			var parameters = new VkParameters
			{
				{"owner_id", ownerId},
				{"comment_id", commentId},
				{"reason", reason}
			};

			return _vk.Call("wall.reportComment", parameters);
		}

		/// <inheritdoc />
		public bool EditAdsStealth(EditAdsStealthParams @params)
		{
			return _vk.Call("wall.editAdsStealth", @params);
		}

		/// <inheritdoc />
		public long PostAdsStealth(PostAdsStealthParams @params)
		{
			return _vk.Call("wall.postAdsStealth", @params);
		}
	}
}