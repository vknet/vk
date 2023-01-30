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
	public Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetCatalog(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<AppGetObject> GetAsync(AppGetParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<long> SendRequestAsync(AppSendRequestParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SendRequest(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteAppRequestsAsync() => TypeHelper.TryInvokeMethodAsync(func: () => DeleteAppRequests());

	/// <inheritdoc />
	public Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type
														, bool? extended = true
														, long? count = null
														, long? offset = null
														, UsersFields fields = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetFriendsList(type, extended, count, offset));

	/// <inheritdoc />
	public Task<VkCollection<long>> GetFriendsListAsync(AppRequestType type
														, long? count = null
														, long? offset = null
														, UsersFields fields = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetFriendsList(type, count, offset));

	/// <inheritdoc />
	public Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type, bool? global = null, bool? extended = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetLeaderboard(type, global, extended));

	/// <inheritdoc />
	public Task<long> GetScoreAsync(long userId) => TypeHelper.TryInvokeMethodAsync(func: () => GetScore(userId: userId));

	/// <inheritdoc />
	public Task<MiniAppPolicies> GetMiniAppPoliciesAsync(ulong appId) => TypeHelper.TryInvokeMethodAsync(func: () => GetMiniAppPolicies(appId: appId));

	/// <inheritdoc />
	public Task<AppGetScopesResult> GetScopesAsync(string type = "user") => TypeHelper.TryInvokeMethodAsync(func: () => GetScopes(type: type));

	/// <inheritdoc />
	public Task<bool> PromoHasActiveGiftAsync(ulong promoId, ulong? userId = null) => TypeHelper.TryInvokeMethodAsync(func: () => PromoHasActiveGift(promoId, userId));

	/// <inheritdoc />
	public Task<bool> PromoUseGiftAsync(ulong promoId, ulong? userId = null) => TypeHelper.TryInvokeMethodAsync(func: () => PromoUseGift(promoId, userId));

}