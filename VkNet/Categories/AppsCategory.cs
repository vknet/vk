using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

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
	public AppsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public VkCollection<App> GetCatalog(AppGetCatalogParams @params, bool skipAuthorization = false) => _vk.Call<VkCollection<App>>(
		"apps.getCatalog", new()
		{
			{
				"sort", @params.Sort
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"platform", @params.Platform
			},
			{
				"extended", @params.Extended
			},
			{
				"return_friends", @params.ReturnFriends
			},
			{
				"fields", @params.Fields
			},
			{
				"name_case", @params.NameCase
			},
			{
				"q", @params.Query
			},
			{
				"genre_id", @params.GenreId
			},
			{
				"filter", @params.Filter
			}
		}, skipAuthorization);

	/// <inheritdoc />
	public AppGetObject Get(AppGetParams @params, bool skipAuthorization = false)
	{
		return _vk.Call<AppGetObject>("apps.get", new()
		{
			{
				"app_ids", @params.AppIds
			},
			{
				"platform", @params.Platform
			},
			{
				"extended", @params.Extended
			},
			{
				"return_friends", @params.ReturnFriends
			},
			{
				"fields", @params.Fields
			},
			{
				"name_case", @params.NameCase
			}
		}, skipAuthorization);
	}

	/// <inheritdoc />
	public long SendRequest(AppSendRequestParams @params) => _vk.Call("apps.sendRequest", new()
	{
		{
			"user_id", @params.UserId
		},
		{
			"text", @params.Text
		},
		{
			"type", @params.Type
		},
		{
			"name", @params.Name
		},
		{
			"key", @params.Key
		},
		{
			"separate", @params.Separate
		}
	});

	/// <inheritdoc />
	public bool DeleteAppRequests() => _vk.Call("apps.deleteAppRequests", VkParameters.Empty);

	/// <inheritdoc />
	public VkCollection<User> GetFriendsList(AppRequestType type
											, bool? extended = null
											, long? count = null
											, long? offset = null
											, UsersFields fields = null)
	{
		var parameters = new VkParameters
		{
			{
				"extended", extended
			},
			{
				"offset", offset
			},
			{
				"type", type
			},
			{
				"fields", fields
			}
		};

		if (count <= 5000)
		{
			parameters.Add("count", count);
		}

		return _vk.Call("apps.getFriendsList", parameters)
			.ToVkCollectionOf<User>(selector: x => x);
	}

	/// <inheritdoc />
	public LeaderboardResult GetLeaderboard(AppRatingType type, bool? global = null, bool? extended = null)
	{
		var parameters = new VkParameters
		{
			{
				"type", type
			},
			{
				"global", global
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<LeaderboardResult>("apps.getLeaderboard", parameters, true);
	}

	/// <inheritdoc />
	public long GetScore(long userId)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		return _vk.Call("apps.getScore", parameters);
	}

	/// <inheritdoc />
	public MiniAppPolicies GetMiniAppPolicies(ulong appId) => _vk.Call<MiniAppPolicies>("apps.getMiniAppPolicies",
		new()
		{
			{
				"app_id", appId
			}
		});

	/// <inheritdoc />
	public AppGetScopesResult GetScopes(string type = "user") => _vk.Call<AppGetScopesResult>("apps.getScopes",
		new()
		{
			{
				"type", type
			}
		});

	/// <inheritdoc />
	public bool PromoHasActiveGift(ulong promoId, ulong? userId = null) => _vk.Call("apps.promoHasActiveGift",
		new()
		{
			{
				"promo_id", promoId
			},
			{
				"user_id", userId
			}
		});

	/// <inheritdoc />
	public bool PromoUseGift(ulong promoId, ulong? userId = null) => _vk.Call("apps.promoUseGift",
		new()
		{
			{
				"promo_id", promoId
			},
			{
				"user_id", userId
			}
		});
}