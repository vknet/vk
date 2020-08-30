using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WallCategory : IWallCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public WallCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public WallGetObject Get(WallGetParams @params, bool skipAuthorization = false)
		{
			if (@params.Filter != null && @params.Filter == WallFilter.Suggests && @params.OwnerId >= 0)
			{
				throw new ArgumentException("OwnerID must be negative in case filter equal to Suggests",
					nameof(@params));
			}

			return _vk.Call("wall.get",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "domain", @params.Domain },
					{ "offset", @params.Offset },
					{ "count", @params.Count },
					{ "filter", @params.Filter },
					{ "extended", @params.Extended },
					{ "fields", @params.Fields }
				}, skipAuthorization); //, @params.Filter != WallFilter.Suggests && @params.Filter != WallFilter.Postponed);
		}

		/// <inheritdoc />
		public WallGetCommentsResult GetComments(WallGetCommentsParams @params, bool skipAuthorization = false)
		{
			return _vk.Call<WallGetCommentsResult>("wall.getComments",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "post_id", @params.PostId },
					{ "need_likes", @params.NeedLikes },
					{ "start_comment_id", @params.StartCommentId },
					{ "offset", @params.Offset },
					{ "count", @params.Count },
					{ "sort", @params.Sort },
					{ "preview_length", @params.PreviewLength },
					{ "extended", @params.Extended },
					{ "fields", @params.Fields },
					{ "comment_id", @params.CommentId },
					{ "thread_items_count", @params.ThreadItemsCount }
				}, skipAuthorization);
		}

		/// <inheritdoc />
		public WallGetObject GetById(IEnumerable<string> posts
									, bool? extended = null
									, long? copyHistoryDepth = null
									, ProfileFields fields = null
									, bool skipAuthorization = false)
		{
			if (posts == null)
			{
				throw new ArgumentNullException(paramName: nameof(posts));
			}

			if (!posts.Any())
			{
				throw new ArgumentException("Posts collection was empty.", nameof(posts));
			}

			var parameters = new VkParameters
			{
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
			return _vk.Call("wall.post", new VkParameters
			{
				{ "owner_id", @params.OwnerId },
				{ "friends_only", @params.FriendsOnly },
				{ "from_group", @params.FromGroup },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments },
				{ "services", @params.Services },
				{ "signed", @params.Signed },
				{ "publish_date", @params.PublishDate },
				{ "lat", @params.Lat },
				{ "long", @params.Long },
				{ "place_id", @params.PlaceId },
				{ "post_id", @params.PostId },
				{ "guid", @params.Guid },
				{ "mark_as_ads", @params.MarkAsAds },
				{ "close_comments", @params.CloseComments },
				{ "mute_notifications", @params.MuteNotifications },
				{ "copyright", @params.Copyright },
			})[key: "post_id"];
		}

		/// <inheritdoc />
		public RepostResult Repost(string @object, string message, long? groupId, bool markAsAds)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @object);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "object", @object },
				{ "message", message },
				{ "group_id", groupId },
				{ "mark_as_ads", markAsAds }
			};

			return _vk.Call("wall.repost", parameters);
		}

		/// <inheritdoc />
		public RepostResult Repost(string @object, string message, long? groupId, bool markAsAds, long captchaSid,
									string captchaKey)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @object);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "object", @object },
				{ "message", message },
				{ "group_id", groupId },
				{ "mark_as_ads", markAsAds },
				{ "captcha_sid", captchaSid },
				{ "captcha_key", captchaKey }
			};

			return _vk.Call("wall.repost", parameters);
		}

		/// <inheritdoc />
		public long Edit(WallEditParams @params)
		{
			return _vk.Call("wall.edit", new VkParameters
			{
				{ "owner_id", @params.OwnerId },
				{ "post_id", @params.PostId },
				{ "friends_only", @params.FriendsOnly },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments },
				{ "services", @params.Services },
				{ "signed", @params.Signed },
				{ "publish_date", @params.PublishDate },
				{ "lat", @params.Lat },
				{ "long", @params.Long },
				{ "place_id", @params.PlaceId },
				{ "mark_as_ads", @params.MarkAsAds },
				{ "close_comments", @params.CloseComments },
				{ "poster_bkg_id", @params.PosterBackgroundId },
				{ "poster_bkg_owner_id", @params.PosterBackgroundOwnerId },
				{ "poster_bkg_access_hash", @params.PosterBackgroundAccessHash },
				{ "copyright", @params.Copyright },

			})[key: "post_id"];
		}

		/// <inheritdoc />
		public bool Delete(long? ownerId = null, long? postId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => postId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.delete", parameters);
		}

		/// <inheritdoc />
		public bool Restore(long? ownerId = null, long? postId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.restore", parameters);
		}

		/// <inheritdoc />
		public long CreateComment(WallCreateCommentParams @params)
		{
			return _vk.Call("wall.createComment", new VkParameters
			{
				{ "owner_id", @params.OwnerId },
				{ "post_id", @params.PostId },
				{ "from_group", @params.FromGroup },
				{ "message", @params.Message },
				{ "reply_to_comment", @params.ReplyToComment },
				{ "attachments", @params.Attachments },
				{ "sticker_id", @params.StickerId },
				{ "guid", @params.Guid }
			})[key: "comment_id"];
		}

		/// <inheritdoc />
		public bool DeleteComment(long? ownerId, long commentId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("wall.deleteComment", parameters);
		}

		/// <inheritdoc />
		public bool RestoreComment(long commentId, long? ownerId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("wall.restoreComment", parameters);
		}

		/// <inheritdoc />
		public WallGetObject Search(WallSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("wall.search", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "domain", @params.Domain }
				, { "query", @params.Query }
				, { "owners_only", @params.OwnersOnly }
				, { "count", @params.Count }
				, { "offset", @params.Offset }
				, { "extended", @params.Extended }
				, { "fields", @params.Fields }
			}, skipAuthorization);
		}

		/// <inheritdoc />
		public WallGetObject GetReposts(long? ownerId, long? postId, long? offset, long? count, bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call("wall.getReposts", parameters, skipAuthorization);
		}

		/// <inheritdoc />
		public bool Pin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.pin", parameters);
		}

		/// <inheritdoc />
		public bool Unpin(long postId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.unpin", parameters);
		}

		/// <inheritdoc />
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "message", message },
				{ "attachments", attachments }
			};

			return _vk.Call("wall.editComment", parameters);
		}

		/// <inheritdoc />
		public bool ReportPost(long ownerId, long postId, ReportReason? reason = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId },
				{ "reason", reason }
			};

			return _vk.Call("wall.reportPost", parameters);
		}

		/// <inheritdoc />
		public bool ReportComment(long ownerId, long commentId, ReportReason? reason)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "reason", reason }
			};

			return _vk.Call("wall.reportComment", parameters);
		}

		/// <inheritdoc />
		public bool EditAdsStealth(EditAdsStealthParams @params)
		{
			return _vk.Call("wall.editAdsStealth", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "post_id", @params.PostId }
				, { "message", @params.Message }
				, { "attachments", @params.Attachments }
				, { "signed", @params.Signed }
				, { "lat", @params.Lat }
				, { "long", @params.Long }
				, { "place_id", @params.PlaceId }
				, { "link_title", @params.LinkTitle }
				, { "link_image", @params.LinkImage }
			});
		}

		/// <inheritdoc />
		public long PostAdsStealth(PostAdsStealthParams @params)
		{
			return _vk.Call("wall.postAdsStealth", new VkParameters
			{
				{ "owner_id", @params.OwnerId }
				, { "message", @params.Message }
				, { "attachments", @params.Attachments }
				, { "signed", @params.Signed }
				, { "lat", @params.Lat }
				, { "long", @params.Long }
				, { "place_id", @params.PlaceId }
				, { "link_title", @params.LinkTitle }
				, { "link_image", @params.LinkImage }
				, { "guid", @params.Guid }
				, { "link_button", @params.LinkButton }
			});
		}

		/// <inheritdoc />
		public bool OpenComments(long ownerId, long postId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.openComments", parameters);
		}

		/// <inheritdoc />
		public bool CloseComments(long ownerId, long postId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call("wall.closeComments", parameters);
		}

		/// <inheritdoc />
		public bool CheckCopyrightLink(string link)
		{
			var parameters = new VkParameters
			{
				{ "link", link },
			};

			return _vk.Call("wall.checkCopyrightLink", parameters);
		}

		/// <inheritdoc />
		public WallGetCommentResult GetComment(int ownerId, int commentId, bool? extended = null, string fields = null, bool skipAuthorization = false)
		{
			var parameters = new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId },
					{ "extended", extended },
					{ "fields", fields }
				};
			return _vk.Call<WallGetCommentResult>("wall.getComment", parameters, skipAuthorization);

		}
	}
}