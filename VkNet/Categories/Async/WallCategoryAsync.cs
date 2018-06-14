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
		public async Task<WallGetObject> GetAsync(WallGetParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Comment>> GetCommentsAsync(WallGetCommentsParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.GetComments(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts
													, bool? extended = null
													, long? copyHistoryDepth = null
													, ProfileFields fields = null
													, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.GetById(posts: posts
							, extended: extended
							, copyHistoryDepth: copyHistoryDepth
							, fields: fields
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<long> PostAsync(WallPostParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Post(@params: @params));
		}

		/// <inheritdoc />
		public async Task<RepostResult> RepostAsync(string @object, string message, long? groupId, bool markAsAds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.Repost(@object: @object, message: message, groupId: groupId, markAsAds: markAsAds));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(WallEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Edit(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAsync(long? ownerId = null, long? postId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Delete(ownerId: ownerId, postId: postId));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreAsync(long? ownerId = null, long? postId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Restore(ownerId: ownerId, postId: postId));
		}

		/// <inheritdoc />
		public async Task<long> CreateCommentAsync(WallCreateCommentParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteCommentAsync(long? ownerId, long commentId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.DeleteComment(ownerId: ownerId, commentId: commentId));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.RestoreComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<WallGetObject> SearchAsync(WallSearchParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.Search(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<WallGetObject> GetRepostsAsync(long? ownerId
														, long? postId
														, long? offset
														, long? count
														, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.GetReposts(ownerId: ownerId
							, postId: postId
							, offset: offset
							, count: count
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<bool> PinAsync(long postId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Pin(postId: postId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> UnpinAsync(long postId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.Unpin(postId: postId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> EditCommentAsync(long commentId
												, string message
												, long? ownerId = null
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.EditComment(commentId: commentId, message: message, ownerId: ownerId, attachments: attachments));
		}

		/// <inheritdoc />
		public async Task<bool> ReportPostAsync(long ownerId, long postId, ReportReason? reason = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.ReportPost(ownerId: ownerId, postId: postId, reason: reason));
		}

		/// <inheritdoc />
		public async Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason? reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Wall.ReportComment(ownerId: ownerId, commentId: commentId, reason: reason));
		}

		/// <inheritdoc />
		public async Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.EditAdsStealth(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> PostAdsStealthAsync(PostAdsStealthParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Wall.PostAdsStealth(@params: @params));
		}
	}
}