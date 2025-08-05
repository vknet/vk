using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со стеной пользователя.
/// </summary>
public interface IWallCategory : IWallCategoryAsync
{
	/// <inheritdoc cref="IWallCategoryAsync.GetAsync"/>
	WallGetObject Get(WallGetParams @params, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.GetCommentsAsync"/>
	WallGetCommentsResult GetComments(WallGetCommentsParams @params, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.GetByIdAsync(IEnumerable{string}, bool, long?, ProfileFields, bool, System.Threading.CancellationToken)"/>
	WallGetObject GetById(IEnumerable<string> posts
						, bool extended
						, long? copyHistoryDepth = null
						, ProfileFields fields = null
						, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.GetByIdAsync(IEnumerable{string}, long?, ProfileFields, bool, System.Threading.CancellationToken)"/>
	ReadOnlyCollection<Post> GetById(IEnumerable<string> posts
									, long? copyHistoryDepth = null
									, ProfileFields fields = null
									, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.PostAsync"/>
	long Post(WallPostParams @params);

	/// <inheritdoc cref="IWallCategoryAsync.RepostAsync"/>
	RepostResult Repost(string @object, string message, long? groupId, bool markAsAds);

	/// <inheritdoc cref="IWallCategoryAsync.RepostAsync"/>
	[Obsolete("Use ICaptchaSolver to handle captcha. This method is obsolete and will be removed in future.")]
	RepostResult Repost(string @object, string message, long? groupId, bool markAsAds, long captchaSid,
						string captchaKey);

	/// <inheritdoc cref="IWallCategoryAsync.EditAsync"/>
	long Edit(WallEditParams @params);

	/// <inheritdoc cref="IWallCategoryAsync.DeleteAsync"/>
	bool Delete(long? ownerId = null, long? postId = null);

	/// <inheritdoc cref="IWallCategoryAsync.RestoreAsync"/>
	bool Restore(long? ownerId = null, long? postId = null);

	/// <inheritdoc cref="IWallCategoryAsync.CreateCommentAsync"/>
	long CreateComment(WallCreateCommentParams @params);

	/// <inheritdoc cref="IWallCategoryAsync.DeleteCommentAsync"/>
	bool DeleteComment(long? ownerId, long commentId);

	/// <inheritdoc cref="IWallCategoryAsync.RestoreCommentAsync"/>
	bool RestoreComment(long commentId, long? ownerId);

	/// <inheritdoc cref="IWallCategoryAsync.SearchAsync"/>
	WallGetObject Search(WallSearchParams @params, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.GetRepostsAsync"/>
	WallGetObject GetReposts(long? ownerId, long? postId, long? offset, long? count, bool skipAuthorization = false);

	/// <inheritdoc cref="IWallCategoryAsync.PinAsync"/>
	bool Pin(long postId, long? ownerId = null);

	/// <inheritdoc cref="IWallCategoryAsync.UnpinAsync"/>
	bool Unpin(long postId, long? ownerId = null);

	/// <inheritdoc cref="IWallCategoryAsync.EditCommentAsync"/>
	bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null);

	/// <inheritdoc cref="IWallCategoryAsync.ReportPostAsync"/>
	bool ReportPost(long ownerId, long postId, ReportReason? reason = null);

	/// <inheritdoc cref="IWallCategoryAsync.ReportCommentAsync"/>
	bool ReportComment(long ownerId, long commentId, ReportReason? reason);

	/// <inheritdoc cref="IWallCategoryAsync.EditAdsStealthAsync"/>
	bool EditAdsStealth(EditAdsStealthParams @params);

	/// <inheritdoc cref="IWallCategoryAsync.PostAdsStealthAsync"/>
	long PostAdsStealth(PostAdsStealthParams @params);

	/// <inheritdoc cref="IWallCategoryAsync.OpenCommentsAsync"/>
	bool OpenComments(long ownerId, long postId);

	/// <inheritdoc cref="IWallCategoryAsync.CloseCommentsAsync"/>
	bool CloseComments(long ownerId, long postId);

	/// <inheritdoc cref="IWallCategoryAsync.CheckCopyrightLinkAsync"/>
	bool CheckCopyrightLink(string link);

	/// <inheritdoc cref="IWallCategoryAsync.GetCommentAsync"/>
	WallGetCommentResult GetComment(int ownerId, int commentId, bool? extended = null, string fields = null,
									bool skipAuthorization = false);
}