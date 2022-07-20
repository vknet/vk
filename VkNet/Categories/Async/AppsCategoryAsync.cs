using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AppsCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetCatalog(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<AppGetObject> GetAsync(AppGetParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<long> SendRequestAsync(AppSendRequestParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SendRequest(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAppRequestsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteAppRequests());
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type
															, bool? extended = null
															, long? count = null
															, long? offset = null
															, UsersFields fields = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetFriendsList(type: type, extended: extended, count: count, offset: offset));
		}

		/// <inheritdoc />
		public Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type, bool? global = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetLeaderboard(type: type, global: global, extended: extended));
		}

		/// <inheritdoc />
		public Task<long> GetScoreAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetScore(userId: userId));
		}
	}
}