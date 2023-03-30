using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AppsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<AppGetObject> GetAsync(AppGetParams @params,
										bool skipAuthorization = false,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<long> SendRequestAsync(AppSendRequestParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SendRequest(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteAppRequestsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(DeleteAppRequests);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type,
														bool? extended = true,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetFriendsList(type, extended, count, offset));

	/// <inheritdoc />
	public Task<VkCollection<long>> GetFriendsListAsync(AppRequestType type,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetFriendsList(type, count, offset));

	/// <inheritdoc />
	public Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type,
														bool? global = null,
														bool? extended = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLeaderboard(type, global, extended));

	/// <inheritdoc />
	public Task<long> GetScoreAsync(long userId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetScore(userId));

	/// <inheritdoc />
	public Task<MiniAppPolicies> GetMiniAppPoliciesAsync(ulong appId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMiniAppPolicies(appId));

	/// <inheritdoc />
	public Task<AppGetScopesResult> GetScopesAsync(string type = "user",
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetScopes(type));

	/// <inheritdoc />
	public Task<bool> PromoHasActiveGiftAsync(ulong promoId, ulong? userId = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => PromoHasActiveGift(promoId, userId));

	/// <inheritdoc />
	public Task<bool> PromoUseGiftAsync(ulong promoId, ulong? userId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => PromoUseGift(promoId, userId));

}