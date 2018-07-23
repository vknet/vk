using System.Collections.Generic;
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
		public Task<WallGetObject> GetAsync(WallGetParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Comment>> GetCommentsAsync(WallGetCommentsParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetComments(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts
													, bool? extended = null
													, long? copyHistoryDepth = null
													, ProfileFields fields = null
													, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetById(posts: posts
							, extended: extended
							, copyHistoryDepth: copyHistoryDepth
							, fields: fields
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<long> PostAsync(WallPostParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Post(@params: @params));
		}

		/// <inheritdoc />
		public Task<RepostResult> RepostAsync(string @object, string message, long? groupId, bool markAsAds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Repost(@object: @object, message: message, groupId: groupId, markAsAds: markAsAds));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(WallEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long? ownerId = null, long? postId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Delete(ownerId: ownerId, postId: postId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(long? ownerId = null, long? postId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Restore(ownerId: ownerId, postId: postId));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(WallCreateCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(long? ownerId, long commentId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteComment(ownerId: ownerId, commentId: commentId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RestoreComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<WallGetObject> SearchAsync(WallSearchParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Search(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<WallGetObject> GetRepostsAsync(long? ownerId
														, long? postId
														, long? offset
														, long? count
														, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetReposts(ownerId: ownerId
							, postId: postId
							, offset: offset
							, count: count
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<bool> PinAsync(long postId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Pin(postId: postId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> UnpinAsync(long postId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Unpin(postId: postId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(long commentId
												, string message
												, long? ownerId = null
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					EditComment(commentId: commentId, message: message, ownerId: ownerId, attachments: attachments));
		}

		/// <inheritdoc />
		public Task<bool> ReportPostAsync(long ownerId, long postId, ReportReason? reason = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>ReportPost(ownerId: ownerId, postId: postId, reason: reason));
		}

		/// <inheritdoc />
		public Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason? reason)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					ReportComment(ownerId: ownerId, commentId: commentId, reason: reason));
		}

		/// <inheritdoc />
		public Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditAdsStealth(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> PostAdsStealthAsync(PostAdsStealthParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>PostAdsStealth(@params: @params));
		}
	}
}