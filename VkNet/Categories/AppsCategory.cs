using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AppsCategory : IAppsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с приложениями.
		/// </summary>
		/// <param name="vk"> API. </param>
		public AppsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<App> GetCatalog(AppGetCatalogParams @params, bool skipAuthorization = false)
		{
			return GetCatalogAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public AppGetObject Get(AppGetParams @params, bool skipAuthorization = false)
		{
			return GetAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long SendRequest(AppSendRequestParams @params)
		{
			return SendRequestAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool DeleteAppRequests()
		{
			return DeleteAppRequestsAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public VkCollection<User> GetFriendsList(AppRequestType type,
												bool? extended = null,
												long? count = null,
												long? offset = null,
												UsersFields fields = null)
		{
			return GetFriendsListAsync(type, extended, count, offset, fields, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public LeaderboardResult GetLeaderboard(AppRatingType type, bool? global = null, bool? extended = null)
		{
			return GetLeaderboardAsync(type, global, extended, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long GetScore(long userId)
		{
			return GetScoreAsync(userId, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}