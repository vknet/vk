using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IAppsCategory" />
public partial class AppsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<AppGetObject> GetAsync(AppGetParams @params,
										bool skipAuthorization = false,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<long> SendRequestAsync(AppSendRequestParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendRequest(@params: @params), token);

	/// <inheritdoc />
	public Task<bool> DeleteAppRequestsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(DeleteAppRequests, token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type,
														bool? extended = true,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFriendsList(type, extended, count, offset), token);

	/// <inheritdoc />
	public Task<VkCollection<long>> GetFriendsListAsync(AppRequestType type,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFriendsList(type, count, offset), token);

	/// <inheritdoc />
	public Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type,
														bool? global = null,
														bool? extended = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLeaderboard(type, global, extended), token);

	/// <inheritdoc />
	public Task<long> GetScoreAsync(long userId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetScore(userId), token);

	/// <inheritdoc />
	public Task<MiniAppPolicies> GetMiniAppPoliciesAsync(ulong appId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMiniAppPolicies(appId), token);

	/// <inheritdoc />
	public Task<AppGetScopesResult> GetScopesAsync(string type = "user",
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetScopes(type), token);

	/// <inheritdoc />
	public Task<bool> PromoHasActiveGiftAsync(ulong promoId, ulong? userId = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			PromoHasActiveGift(promoId, userId), token);

	/// <inheritdoc />
	public Task<bool> PromoUseGiftAsync(ulong promoId, ulong? userId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			PromoUseGift(promoId, userId), token);

}