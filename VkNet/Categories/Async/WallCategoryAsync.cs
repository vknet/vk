using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WallCategory
	{
		/// <inheritdoc />
		public Task<WallGetObject> GetAsync(WallGetParams @params,
											bool skipAuthorization = false,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<WallGetObject>("wall.get", @params, skipAuthorization, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<WallGetCommentsResult> GetCommentsAsync(WallGetCommentsParams @params,
															bool skipAuthorization = false,
															CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<WallGetCommentsResult>("wall.getComments",
				@params,
				skipAuthorization,
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts,
												bool? extended = null,
												long? copyHistoryDepth = null,
												ProfileFields fields = null,
												bool skipAuthorization = false,
												CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<WallGetObject>("wall.getById",
				new VkParameters
				{
					{ "posts", posts },
					{ "extended", extended },
					{ "copy_history_depth", copyHistoryDepth },
					{ "fields", fields }
				},
				skipAuthorization,
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<long> PostAsync(WallPostParams @params, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("wall.post", @params, cancellationToken: cancellationToken).ConfigureAwait(false);

			return response["post_id"];
		}

		/// <inheritdoc />
		public Task<RepostResult> RepostAsync(string @object,
											string message,
											long? groupId,
											bool markAsAds,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<RepostResult>("wall.repost",
				new VkParameters
				{
					{ "object", @object },
					{ "message", message },
					{ "group_id", groupId },
					{ "mark_as_ads", markAsAds }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(WallEditParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.edit", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long? ownerId = null, long? postId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.delete",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(long? ownerId = null, long? postId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.restore",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<long> CreateCommentAsync(WallCreateCommentParams @params, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("wall.createComment", @params, cancellationToken: cancellationToken).ConfigureAwait(false);

			return response["comment_id"];
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(long? ownerId, long commentId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.deleteComment",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(long commentId, long? ownerId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.restoreComment",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<WallGetObject> SearchAsync(WallSearchParams @params,
												bool skipAuthorization = false,
												CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<WallGetObject>("wall.search", @params, skipAuthorization, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<WallGetObject> GetRepostsAsync(long? ownerId,
													long? postId,
													long? offset,
													long? count,
													bool skipAuthorization = false,
													CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<WallGetObject>("wall.getReposts",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId },
					{ "offset", offset },
					{ "count", count }
				},
				skipAuthorization,
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> PinAsync(long postId, long? ownerId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.pin",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> UnpinAsync(long postId, long? ownerId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.unpin",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(long commentId,
											string message,
											long? ownerId = null,
											IEnumerable<MediaAttachment> attachments = null,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.editComment",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId },
					{ "message", message },
					{ "attachments", attachments }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> ReportPostAsync(long ownerId,
										long postId,
										ReportReason? reason = null,
										CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.reportPost",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId },
					{ "reason", reason }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> ReportCommentAsync(long ownerId,
											long commentId,
											ReportReason? reason,
											CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.reportComment",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "comment_id", commentId },
					{ "reason", reason }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.editAdsStealth", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<long> PostAdsStealthAsync(PostAdsStealthParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<long>("wall.postAdsStealth", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> OpenCommentsAsync(long ownerId, long postId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.openComments",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> CloseCommentsAsync(long ownerId, long postId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("wall.closeComments",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}
	}
}