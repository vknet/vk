using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IWallCategory" />
public partial class WallCategory
{
	/// <inheritdoc />
	public Task<WallGetObject> GetAsync(WallGetParams @params,
										bool skipAuthorization = false,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<WallGetCommentsResult> GetCommentsAsync(WallGetCommentsParams @params,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts,
											bool extended,
											long? copyHistoryDepth = null,
											ProfileFields fields = null,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetById(posts, extended, copyHistoryDepth, fields, skipAuthorization), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Post>> GetByIdAsync(IEnumerable<string> posts,
														long? copyHistoryDepth = null,
														ProfileFields fields = null,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(posts, copyHistoryDepth, fields, skipAuthorization), token);

	/// <inheritdoc />
	public Task<long> PostAsync(WallPostParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Post(@params), token);

	/// <inheritdoc />
	public Task<RepostResult> RepostAsync(string @object,
										string message,
										long? groupId,
										bool markAsAds,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Repost(@object, message, groupId, markAsAds), token);

	/// <inheritdoc />
	public Task<long> EditAsync(WallEditParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long? ownerId = null,
								long? postId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(ownerId, postId), token);

	/// <inheritdoc />
	public Task<bool> RestoreAsync(long? ownerId = null,
									long? postId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(ownerId, postId), token);

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(WallCreateCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(long? ownerId,
										long commentId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(ownerId, commentId), token);

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(long commentId,
										long? ownerId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(commentId, ownerId), token);

	/// <inheritdoc />
	public Task<WallGetObject> SearchAsync(WallSearchParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<WallGetObject> GetRepostsAsync(long? ownerId,
												long? postId,
												long? offset,
												long? count,
												bool skipAuthorization = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetReposts(ownerId, postId, offset, count, skipAuthorization), token);

	/// <inheritdoc />
	public Task<bool> PinAsync(long postId,
								long? ownerId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Pin(postId, ownerId), token);

	/// <inheritdoc />
	public Task<bool> UnpinAsync(long postId,
								long? ownerId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unpin(postId, ownerId), token);

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(long commentId,
										string message,
										long? ownerId = null,
										IEnumerable<MediaAttachment> attachments = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(commentId, message, ownerId, attachments), token);

	/// <inheritdoc />
	public Task<bool> ReportPostAsync(long ownerId,
									long postId,
									ReportReason? reason = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReportPost(ownerId, postId, reason), token);

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId,
										long commentId,
										ReportReason? reason,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReportComment(ownerId, commentId, reason), token);

	/// <inheritdoc />
	public Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAdsStealth(@params), token);

	/// <inheritdoc />
	public Task<long> PostAdsStealthAsync(PostAdsStealthParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			PostAdsStealth(@params), token);

	/// <inheritdoc />
	public Task<bool> OpenCommentsAsync(long ownerId,
										long postId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			OpenComments(ownerId, postId), token);

	/// <inheritdoc />
	public Task<bool> CloseCommentsAsync(long ownerId,
										long postId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CloseComments(ownerId, postId), token);

	/// <inheritdoc />
	public Task<bool> CheckCopyrightLinkAsync(string link,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckCopyrightLink(link), token);

	/// <inheritdoc />
	public Task<WallGetCommentResult> GetCommentAsync(int ownerId,
													int commentId,
													bool? extended = null,
													string fields = null,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComment(ownerId, commentId, extended, fields, skipAuthorization), token);
}