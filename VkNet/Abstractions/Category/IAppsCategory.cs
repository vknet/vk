using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IAppsCategoryAsync"/>
	public interface IAppsCategory : IAppsCategoryAsync
	{
		/// <inheritdoc cref="IAppsCategoryAsync.GetCatalogAsync"/>
		VkCollection<App> GetCatalog(AppGetCatalogParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IAppsCategoryAsync.GetAsync"/>
		AppGetObject Get(AppGetParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IAppsCategoryAsync.SendRequestAsync"/>
		long SendRequest(AppSendRequestParams @params);

		/// <inheritdoc cref="IAppsCategoryAsync.DeleteAppRequestsAsync"/>
		bool DeleteAppRequests();

		/// <inheritdoc cref="IAppsCategoryAsync.GetFriendsListAsync"/>
		VkCollection<User> GetFriendsList(AppRequestType type
										, bool? extended = null
										, long? count = null
										, long? offset = null
										, UsersFields fields = null);

		/// <inheritdoc cref="IAppsCategoryAsync.GetLeaderboardAsync"/>
		LeaderboardResult GetLeaderboard(AppRatingType type, bool? global = null, bool? extended = null);

		/// <inheritdoc cref="IAppsCategoryAsync.GetScoreAsync"/>
		long GetScore(long userId);
	}
}