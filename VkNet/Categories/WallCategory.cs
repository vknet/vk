using System;
using System.Collections.Generic;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
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
			return GetAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public WallGetCommentsResult GetComments(WallGetCommentsParams @params, bool skipAuthorization = false)
		{
			return GetCommentsAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public WallGetObject GetById(IEnumerable<string> posts,
									bool? extended = null,
									long? copyHistoryDepth = null,
									ProfileFields fields = null,
									bool skipAuthorization = false)
		{
			return GetByIdAsync(posts, extended, copyHistoryDepth, fields, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long Post(WallPostParams @params)
		{
			return PostAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public RepostResult Repost(string @object, string message, long? groupId, bool markAsAds)
		{
			return RepostAsync(@object, message, groupId, markAsAds, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public RepostResult Repost(string @object, string message, long? groupId, bool markAsAds, long captchaSid,
									string captchaKey)
		{
			return RepostAsync(@object, message, groupId, markAsAds, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Edit(WallEditParams @params)
		{
			return EditAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Delete(long? ownerId = null, long? postId = null)
		{
			return DeleteAsync(ownerId, postId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Restore(long? ownerId = null, long? postId = null)
		{
			return RestoreAsync(ownerId, postId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long CreateComment(WallCreateCommentParams @params)
		{
			return CreateCommentAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool DeleteComment(long? ownerId, long commentId)
		{
			return DeleteCommentAsync(ownerId, commentId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool RestoreComment(long commentId, long? ownerId)
		{
			return RestoreCommentAsync(commentId, ownerId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public WallGetObject Search(WallSearchParams @params, bool skipAuthorization = false)
		{
			return SearchAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public WallGetObject GetReposts(long? ownerId, long? postId, long? offset, long? count, bool skipAuthorization = false)
		{
			return GetRepostsAsync(ownerId, postId, offset, count, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Pin(long postId, long? ownerId = null)
		{
			return PinAsync(postId, ownerId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Unpin(long postId, long? ownerId = null)
		{
			return UnpinAsync(postId, ownerId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
		{
			return EditCommentAsync(commentId, message, ownerId, attachments, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool ReportPost(long ownerId, long postId, ReportReason? reason = null)
		{
			return ReportPostAsync(ownerId, postId, reason, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool ReportComment(long ownerId, long commentId, ReportReason? reason)
		{
			return ReportCommentAsync(ownerId, commentId, reason, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool EditAdsStealth(EditAdsStealthParams @params)
		{
			return EditAdsStealthAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long PostAdsStealth(PostAdsStealthParams @params)
		{
			return PostAdsStealthAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool OpenComments(long ownerId, long postId)
		{
			return OpenCommentsAsync(ownerId, postId, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool CloseComments(long ownerId, long postId)
		{
			return CloseCommentsAsync(ownerId, postId, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}