using System.Threading;
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
		public async Task<VkCollection<App>> GetCatalogAsync(AppGetCatalogParams @params, bool skipAuthorization = false,
															CancellationToken cancellationToken = default)
		{
			return (await _vk.CallAsync("apps.getCatalog", @params, skipAuthorization, cancellationToken).ConfigureAwait(false))
				.ToVkCollectionOf<App>(selector: x => x);
		}

		/// <inheritdoc />
		public async Task<AppGetObject> GetAsync(AppGetParams @params, bool skipAuthorization = false,
												CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("apps.get", @params, skipAuthorization, cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<long> SendRequestAsync(AppSendRequestParams @params, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("apps.sendRequest", @params, cancellationToken: cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAppRequestsAsync(CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("apps.deleteAppRequests", VkParameters.Empty, cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetFriendsListAsync(AppRequestType type,
																bool? extended = null,
																long? count = null,
																long? offset = null,
																UsersFields fields = null,
																CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "extended", extended },
				{ "offset", offset },
				{ "type", type },
				{ "fields", fields }
			};

			return (await _vk.CallAsync("apps.getFriendsList", parameters, cancellationToken: cancellationToken).ConfigureAwait(false))
				.ToVkCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		public Task<LeaderboardResult> GetLeaderboardAsync(AppRatingType type,
															bool? global = null,
															bool? extended = null,
															CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "global", global },
				{ "extended", extended }
			};

			return _vk.CallAsync<LeaderboardResult>("apps.getLeaderboard", parameters, true, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<long> GetScoreAsync(long userId, CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};

			return await _vk.CallAsync("apps.getScore", parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
		}
	}
}