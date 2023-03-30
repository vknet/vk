using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class LikesCategory
{
	/// <inheritdoc />
	public Task<VkCollection<long>> GetListAsync(LikesGetListParams @params,
												bool skipAuthorization = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetList(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<UserOrGroup> GetListExAsync(LikesGetListParams @params,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetListEx(@params), token);

	/// <inheritdoc />
	public Task<long> AddAsync(LikesAddParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(@params), token);

	/// <inheritdoc />
	public Task<long> DeleteAsync(LikeObjectType type,
								long itemId,
								long? ownerId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(type, itemId, ownerId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<long> DeleteAsync(LikeObjectType type,
								long itemId,
								long? ownerId = null,
								long? captchaSid = null,
								string captchaKey = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(type, itemId, ownerId, captchaSid, captchaKey), token);

	/// <inheritdoc />
	public Task<bool> IsLikedAsync(LikeObjectType type,
									long itemId,
									long? userId = null,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsLiked(out var _, type, itemId, userId, ownerId));
}