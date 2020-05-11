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
		///  api vk.com
		/// </summary>
		/// <param name="vk"> API. </param>
		public AppsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<App> GetCatalog(AppGetCatalogParams @params, bool skipAuthorization = false)
		{
			return _vk.Call(methodName: "apps.getCatalog", new VkParameters
				{
					{ "sort", @params.Sort }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
					, { "platform", @params.Platform }
					, { "extended", @params.Extended }
					, { "return_friends", @params.ReturnFriends }
					, { "fields", @params.Fields }
					, { "name_case", @params.NameCase }
					, { "q", @params.Query }
					, { "genre_id", @params.GenreId }
					, { "filter", @params.Filter }
				}, skipAuthorization: skipAuthorization)
					.ToVkCollectionOf<App>(selector: x => x);
		}

		/// <inheritdoc />
		public AppGetObject Get(AppGetParams @params, bool skipAuthorization = false)
		{
			return _vk.Call(methodName: "apps.get", new VkParameters
			{
				{ "app_ids", @params.AppIds }
				, { "platform", @params.Platform }
				, { "extended", @params.Extended }
				, { "return_friends", @params.ReturnFriends }
				, { "fields", @params.Fields }
				, { "name_case", @params.NameCase }
			}, skipAuthorization: skipAuthorization);
		}

		/// <inheritdoc />
		public long SendRequest(AppSendRequestParams @params)
		{
			return _vk.Call(methodName: "apps.sendRequest", new VkParameters
			{
				{ "user_id", @params.UserId }
				, { "text", @params.Text }
				, { "type", @params.Type }
				, { "name", @params.Name }
				, { "key", @params.Key }
				, { "separate", @params.Separate }
			});
		}

		/// <inheritdoc />
		public bool DeleteAppRequests()
		{
			return _vk.Call(methodName: "apps.deleteAppRequests", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public VkCollection<User> GetFriendsList(AppRequestType type
												, bool? extended = null
												, long? count = null
												, long? offset = null
												, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
					{ "extended", extended }
					, { "offset", offset }
					, { "type", type }
					, { "fields", fields }
			};

			if (count <= 5000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "apps.getFriendsList", parameters: parameters).ToVkCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		public LeaderboardResult GetLeaderboard(AppRatingType type, bool? global = null, bool? extended = null)
		{
			var parameters = new VkParameters
			{
					{ "type", type }
					, { "global", global }
					, { "extended", extended }
			};

			return _vk.Call<LeaderboardResult>(methodName: "apps.getLeaderboard", parameters: parameters, skipAuthorization: true);
		}

		/// <inheritdoc />
		public long GetScore(long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
			};

			return _vk.Call(methodName: "apps.getScore", parameters: parameters);
		}
	}
}