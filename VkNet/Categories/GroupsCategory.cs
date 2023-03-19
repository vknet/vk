using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Groups;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class GroupsCategory : IGroupsCategory
{
	private readonly IVkInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> </param>
	public GroupsCategory(IVkInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public AddressResult AddAddress(AddAddressParams @params) => _vk.Call<AddressResult>("groups.addAddress",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"title", @params.Title
			},
			{
				"address", @params.Address
			},
			{
				"additional_address", @params.AdditionalAddress
			},
			{
				"country_id", @params.CountryId
			},
			{
				"city_id", @params.CityId
			},
			{
				"latitude", @params.Latitude
			},
			{
				"longitude", @params.Longitude
			},
			{
				"phone", @params.Phone
			},
			{
				"work_info_status", @params.WorkInfoStatus
			},
			{
				"metro_id", @params.MetroId
			},
			{
				"timetable", @params.Timetable
			},
			{
				"is_main_address", @params.IsMainAddress
			}
		});

	/// <inheritdoc />
	public AddressResult EditAddress(EditAddressParams @params) => _vk.Call<AddressResult>("groups.editAddress",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"address_id", @params.AddressId
			},
			{
				"title", @params.Title
			},
			{
				"address", @params.Address
			},
			{
				"additional_address", @params.AdditionalAddress
			},
			{
				"phone", @params.Phone
			},
			{
				"work_info_status", @params.WorkInfoStatus
			},
			{
				"country_id", @params.CountryId
			},
			{
				"city_id", @params.CityId
			},
			{
				"metro_id", @params.MetroId
			},
			{
				"latitude", @params.Latitude
			},
			{
				"longitude", @params.Longitude
			},
			{
				"timetable", @params.Timetable
			},
			{
				"is_main_address", @params.IsMainAddress
			}
		});

	/// <inheritdoc />
	public bool DeleteAddress(ulong groupId, ulong addressId) => _vk.Call<bool>("groups.deleteAddress",
		new()
		{
			{
				"group_id", groupId
			},
			{
				"address_id", addressId
			}
		});

	/// <inheritdoc />
	public VkCollection<AddressResult> GetAddresses(GetAddressesParams @params) => _vk.Call<VkCollection<AddressResult>>(
		"groups.getAddresses",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"fields", @params.Fields
			},
			{
				"address_ids", @params.AddressIds
			},
			{
				"latitude", @params.Latitude
			},
			{
				"longitude", @params.Longitude
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			}
		});

	/// <inheritdoc />
	public bool Join(long? groupId, bool? notSure = null)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"not_sure", notSure
			}
		};

		return _vk.Call("groups.join", parameters);
	}

	/// <inheritdoc />
	public bool Leave(long groupId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		return _vk.Call("groups.leave", parameters);
	}

	/// <inheritdoc />
	public VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false)
	{
		VkErrors.ThrowIfNumberIsNegative(() => @params.UserId);

		var parameters =
			new VkParameters()
			{
				{
					"user_id", @params.UserId
				},
				{
					"extended", @params.Extended
				},
				{
					"filter", @params.Filter
				},
				{
					"fields", @params.Fields
				},
				{
					"offset", @params.Offset
				},
				{
					"count", @params.Count
				}
			};

		// в первой записи количество членов группы для (response["items"])
		if (@params.Extended == null || !@params.Extended.Value)
		{
			var response = _vk.Call("groups.get", parameters,
				skipAuthorization);
			return response.ToVkCollectionOf<Group>(id => new()
			{
				Id = id
			});
		}
		return _vk.Call<VkCollection<Group>>("groups.get", parameters,
			skipAuthorization);
	}

	/// <inheritdoc />
	public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
											bool skipAuthorization = false)
	{
		var parameters = new VkParameters
		{
			{
				"group_ids", groupIds
			},
			{
				"group_id", groupId
			},
			{
				"fields", fields
			}
		};

		return _vk.Call<ReadOnlyCollection<Group>>("groups.getById", parameters, skipAuthorization);
	}

	/// <inheritdoc />
	public VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false)
	{
		if (@params.Fields != null || @params.Filter != null)
		{
			return _vk.Call<VkCollection<User>>("groups.getMembers",
					new()
					{
						{
							"group_id", @params.GroupId
						},
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
							"fields", @params.Fields
						},
						{
							"filter", @params.Filter
						}
					},
					skipAuthorization);
		}

		return _vk.Call("groups.getMembers",
				new()
				{
					{
						"group_id", @params.GroupId
					},
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
						"fields", @params.Fields
					},
					{
						"filter", @params.Filter
					}
				},
				skipAuthorization)
			.ToVkCollectionOf(x => new User
			{
				Id = x
			});
	}

	/// <inheritdoc />
	public ReadOnlyCollection<GroupMember> IsMember(string groupId, IEnumerable<long> userIds, bool? extended,
													bool skipAuthorization = false)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_ids", userIds
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<ReadOnlyCollection<GroupMember>>("groups.isMember", parameters, skipAuthorization);
	}

	/// <inheritdoc />
	public GroupMember IsMember(string groupId, long userId, bool? extended = true,
													bool skipAuthorization = false)
	{
		if (extended is false or null)
		{
			throw new VkApiException("Параметр extended должен либо быть true, либо отсутствовать");
		}

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<GroupMember>("groups.isMember", parameters, skipAuthorization);
	}

	/// <inheritdoc />
	public bool IsMember(string groupId, long userId, bool skipAuthorization = false)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call<bool>("groups.isMember", parameters, skipAuthorization);
	}

	/// <inheritdoc />
	public VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false) => _vk.Call<VkCollection<Group>>("groups.search",
			new()
			{
				{
					"q", @params.Query
				},
				{
					"type", @params.Type
				},
				{
					"country_id", @params.CountryId
				},
				{
					"city_id", @params.CityId
				},
				{
					"future", @params.Future
				},
				{
					"market", @params.Market
				},
				{
					"sort", @params.Sort
				},
				{
					"offset", @params.Offset
				},
				{
					"count", @params.Count
				}
			},
			skipAuthorization);

	/// <inheritdoc />
	public VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null)
	{
		var parameters = new VkParameters
		{
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<VkCollection<Group>>("groups.getInvites", parameters);
	}

	/// <inheritdoc />
	public bool BanUser(GroupsBanUserParams @params) => _vk.Call("groups.banUser",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"user_id", @params.UserId
			},
			{
				"owner_id", @params.OwnerId
			},
			{
				"end_date", @params.EndDate
			},
			{
				"reason", @params.Reason
			},
			{
				"comment", @params.Comment
			},
			{
				"comment_visible", @params.CommentVisible
			}
		});

	/// <inheritdoc />
	public VkCollection<GetBannedResult> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null,
													long? ownerId = null)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"fields", fields
			},
			{
				"owner_id", ownerId
			}
		};

		return _vk.Call<VkCollection<GetBannedResult>>("groups.getBanned", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUser, true)]
	public bool UnbanUser(long groupId, long userId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);
		VkErrors.ThrowIfNumberIsNegative(() => userId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("groups.unbanUser", parameters);
	}

	/// <inheritdoc />
	public bool Unban(long groupId, long userId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("groups.unban", parameters);
	}

	/// <inheritdoc />
	public bool EditManager(GroupsEditManagerParams @params) => _vk.Call("groups.editManager",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"user_id", @params.UserId
			},
			{
				"role", @params.Role
			},
			{
				"is_contact", @params.IsContact
			},
			{
				"contact_position", @params.ContactPosition
			},
			{
				"contact_phone", @params.ContactPhone
			},
			{
				"contact_email", @params.ContactEmail
			}
		});

	/// <inheritdoc />
	public GroupsEditParams GetSettings(ulong groupId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		var result = _vk.Call<GroupsEditParams>("groups.getSettings", parameters);
		result.GroupId = groupId; // Требует метод edit но getSettings не возвращает

		return result;
	}

	/// <inheritdoc />
	public bool Edit(GroupsEditParams @params)
	{
		var market = new Dictionary<string, object>()
		{
			{
				"enabled", @params.MarketEnabled
			}
		};

		if (@params.MarketCommentsEnabled.HasValue)
		{
			market.Add("comments_enabled", @params.MarketCommentsEnabled);
		}

		if (@params.MarketCountry != null)
		{
			market.Add("country_ids", @params.MarketCountry);
		}

		if (@params.MarketCity != null)
		{
			market.Add("city_ids", @params.MarketCity);
		}

		if (@params.MarketContact.HasValue)
		{
			market.Add("contact_id", @params.MarketContact);
		}

		if (@params.MarketCurrency.HasValue)
		{
			market.Add("currency", @params.MarketCurrency);
		}

		var parameters = new VkParameters
		{
			{
				"group_id", @params.GroupId
			},
			{
				"title", @params.Title
			},
			{
				"description", @params.Description
			},
			{
				"screen_name", @params.ScreenName
			},
			{
				"access", @params.Access
			},
			{
				"website", @params.Website
			},
			{
				"subject", @params.Subject
			},
			{
				"email", @params.Email
			},
			{
				"phone", @params.Phone
			},
			{
				"rss", @params.Rss
			},
			{
				"event_start_date", @params.EventStartDate
			},
			{
				"event_finish_date", @params.EventFinishDate
			},
			{
				"event_group_id", @params.EventGroupId
			},
			{
				"public_category", @params.PublicCategory
			},
			{
				"public_subcategory", @params.PublicSubcategory
			},
			{
				"public_date", @params.PublicDate
			},
			{
				"wall", @params.Wall
			},
			{
				"topics", @params.Topics
			},
			{
				"photos", @params.Photos
			},
			{
				"video", @params.Video
			},
			{
				"audio", @params.Audio
			},
			{
				"links", @params.Links
			},
			{
				"events", @params.Events
			},
			{
				"places", @params.Places
			},
			{
				"contacts", @params.Contacts
			},
			{
				"docs", @params.Docs
			},
			{
				"wiki", @params.Wiki
			},
			{
				"messages", @params.Messages
			},
			{
				"age_limits", @params.AgeLimits
			},
			{
				"market", market
			},
			{
				"market_wiki", @params.MarketWiki
			},
			{
				"obscene_filter", @params.ObsceneFilter
			},
			{
				"obscene_stopwords", @params.ObsceneStopwords
			},
			{
				"obscene_words", @params.ObsceneWords
			},
			{
				"articles", @params.Articles
			},
			{
				"addresses", @params.Addresses
			},
			{
				"main_section", @params.MainSection
			},
			{
				"secondary_section", @params.SecondarySection
			},
			{
				"country", @params.Country
			},
			{
				"city", @params.City
			}
		};

		return _vk.Call("groups.edit", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public bool EditPlace(long groupId, Place place = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);

		if (place == null)
		{
			place = new();
		}

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"title", place.Title
			},
			{
				"address", place.Address
			},
			{
				"country_id", place.CountryId
			},
			{
				"city_id", place.CityId
			},
			{
				"latitude", place.Latitude
			},
			{
				"longitude", place.Longitude
			}
		};

		var result = _vk.Call("groups.editPlace", parameters);

		return result["success"];
	}

	/// <inheritdoc />
	public VkCollection<User> GetInvitedUsers(long groupId, long? offset = null, long? count = null, UsersFields fields = null,
											NameCase? nameCase = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		return _vk.Call<VkCollection<User>>("groups.getInvitedUsers", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null) => Invite(groupId, userId);

	/// <inheritdoc />
	public bool Invite(long groupId, long userId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);
		VkErrors.ThrowIfNumberIsNegative(() => userId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("groups.invite", parameters);
	}

	/// <inheritdoc />
	public ExternalLink AddLink(long groupId, Uri link, string text)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"link", link
			},
			{
				"text", text
			}
		};

		return _vk.Call<ExternalLink>("groups.addLink", parameters);
	}

	/// <inheritdoc />
	public bool DeleteLink(long groupId, ulong linkId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"link_id", linkId
			}
		};

		return _vk.Call("groups.deleteLink", parameters);
	}

	/// <inheritdoc />
	public bool EditLink(long groupId, ulong linkId, string text)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"link_id", linkId
			},
			{
				"text", text
			}
		};

		return _vk.Call("groups.editLink", parameters);
	}

	/// <inheritdoc />
	public bool ReorderLink(long groupId, long linkId, long? after)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"link_id", linkId
			},
			{
				"after", after
			}
		};

		return _vk.Call("groups.reorderLink", parameters);
	}

	/// <inheritdoc />
	public bool RemoveUser(long groupId, long userId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);
		VkErrors.ThrowIfNumberIsNegative(() => userId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("groups.removeUser", parameters);
	}

	/// <inheritdoc />
	public bool ApproveRequest(long groupId, long userId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => groupId);
		VkErrors.ThrowIfNumberIsNegative(() => userId);

		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("groups.approveRequest", parameters);
	}

	/// <inheritdoc />
	public Group Create(string title, string description = null, GroupType? type = null, GroupSubType? subtype = null,
						uint? publicCategory = null)
	{
		var parameters = new VkParameters
		{
			{
				"title", title
			},
			{
				"description", description
			},
			{
				"type", type
			},
			{
				"subtype", subtype
			}
		};

		return _vk.Call<Group>("groups.create", parameters);
	}

	/// <inheritdoc />
	public VkCollection<User> GetRequests(long groupId, long? offset = null, long? count = null, UsersFields fields = null)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"fields", fields
			}
		};

		var response = _vk.Call("groups.getRequests", parameters);

		if (fields != null)
		{
			return _vk.Call<VkCollection<User>>("groups.getRequests", parameters);
		}

		return response.ToVkCollectionOf<User>(r => new()
		{
			Id = r
		});
	}

	/// <inheritdoc />
	public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
	{
		var parameters = new VkParameters
		{
			{
				"category_id", categoryId
			},
			{
				"subcategory_id", subcategoryId
			}
		};

		return _vk.Call<VkCollection<Group>>("groups.getCatalog", parameters, true);
	}

	/// <inheritdoc />
	public GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null)
	{
		var parameters = new VkParameters
		{
			{
				"extended", extended
			},
			{
				"subcategories", subcategories
			}
		};

		return _vk.Call<GroupsCatalogInfo>("groups.getCatalogInfo", parameters, true);
	}

	/// <inheritdoc />
	public long AddCallbackServer(ulong groupId, string url, string title, string secretKey)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"url", url
			},
			{
				"title", title
			},
			{
				"secret_key", secretKey
			}
		};

		return _vk.Call("groups.addCallbackServer", parameters)["server_id"];
	}

	/// <inheritdoc />
	public bool DeleteCallbackServer(ulong groupId, ulong serverId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"server_id", serverId
			}
		};

		return _vk.Call("groups.deleteCallbackServer", parameters);
	}

	/// <inheritdoc />
	public bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"server_id", serverId
			},
			{
				"url", url
			},
			{
				"title", title
			},
			{
				"secret_key", secretKey
			}
		};

		return _vk.Call("groups.editCallbackServer", parameters);
	}

	/// <inheritdoc />
	public string GetCallbackConfirmationCode(ulong groupId)
	{
		var response = _vk.Call("groups.getCallbackConfirmationCode",
			new()
			{
				{
					"group_id", groupId
				}
			});

		return response["code"];
	}

	/// <inheritdoc />
	public VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds = null)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"server_ids", serverIds
			}
		};

		return _vk.Call<VkCollection<CallbackServerItem>>("groups.getCallbackServers", parameters);
	}

	/// <inheritdoc />
	public CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"server_id", serverId
			}
		};

		return _vk.Call<CallbackSettings>("groups.getCallbackSettings", parameters);
	}

	/// <inheritdoc />
	public bool SetCallbackSettings(CallbackServerParams @params)
	{
		var res = new VkParameters
		{
			{
				"group_id", @params.GroupId
			},
			{
				"server_id", @params.ServerId
			}
		};

		if (@params.CallbackSettings != null)
		{
			var props = @params.CallbackSettings.GetType()
				.GetProperties();

			foreach (var t in props)
			{
				if (!(t.GetCustomAttributes(typeof(JsonPropertyAttribute), true)
						.FirstOrDefault() is JsonPropertyAttribute jsonAttr))
				{
					continue;
				}

				if (t.GetValue(@params.CallbackSettings, null) is bool propVal)
				{
					res.Add(jsonAttr.PropertyName, propVal);
				}
			}
		}

		if (@params.ApiVersion != null)
		{
			res["api_version"] = @params.ApiVersion.Version;
		}

		return _vk.Call("groups.setCallbackSettings", res);
	}

	/// <inheritdoc />
	public LongPollServerResponse GetLongPollServer(ulong groupId) => _vk.Call<LongPollServerResponse>("groups.getLongPollServer",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public bool DisableOnline(ulong groupId) => _vk.Call<bool>("groups.disableOnline",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public bool EnableOnline(ulong groupId) => _vk.Call<bool>("groups.enableOnline",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public BotsLongPollHistoryResponse GetBotsLongPollHistory(BotsLongPollHistoryParams @params)
	{
		var parameters = new VkParameters
		{
			{
				"ts", @params.Ts
			},
			{
				"key", @params.Key
			},
			{
				"wait", @params.Wait
			},
			{
				"act", "a_check"
			}
		};
		var response = _vk.CallLongPoll(@params.Server, parameters);

		if (response.ContainsKey("failed"))
		{
			int code = response["failed"];

			if (code == LongPollException.OutdateException)
			{
				throw new LongPollOutdateException(response["ts"]);
			}

			if (code == LongPollException.KeyExpiredException)
			{
				throw new LongPollKeyExpiredException();
			}

			if (code == LongPollException.InfoLostException)
			{
				throw new LongPollInfoLostException();
			}
		}

		return _vk.CallLongPoll<BotsLongPollHistoryResponse>(@params.Server, parameters);
	}

	/// <inheritdoc />
	public OnlineStatus GetOnlineStatus(ulong groupId) => _vk.Call<OnlineStatus>("groups.getOnlineStatus",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public TokenPermissionsResult GetTokenPermissions() =>
		_vk.Call<TokenPermissionsResult>("groups.getTokenPermissions", VkParameters.Empty);

	/// <inheritdoc />
	public bool SetLongPollSettings(SetLongPollSettingsParams @params) => _vk.Call<bool>("groups.setLongPollSettings",
		new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"api_version", @params.ApiVersion
			},
			{
				"enabled", @params.Enabled
			},
			{
				"message_new", @params.MessageNew
			},
			{
				"message_reply", @params.MessageReply
			},
			{
				"message_allow", @params.MessageAllow
			},
			{
				"message_deny", @params.MessageDeny
			},
			{
				"message_edit", @params.MessageEdit
			},
			{
				"message_typing_state", @params.MessageTypingState
			},
			{
				"photo_new", @params.PhotoNew
			},
			{
				"audio_new", @params.AudioNew
			},
			{
				"video_new", @params.VideoNew
			},
			{
				"wall_reply_new", @params.WallReplyNew
			},
			{
				"wall_reply_edit", @params.WallReplyEdit
			},
			{
				"wall_reply_delete", @params.WallReplyDelete
			},
			{
				"wall_reply_restore", @params.WallReplyRestore
			},
			{
				"wall_post_new", @params.WallPostNew
			},
			{
				"wall_repost", @params.WallRepost
			},
			{
				"board_post_new", @params.BoardPostNew
			},
			{
				"board_post_edit", @params.BoardPostEdit
			},
			{
				"board_post_restore", @params.BoardPostRestore
			},
			{
				"board_post_delete", @params.BoardPostDelete
			},
			{
				"photo_comment_new", @params.PhotoCommentNew
			},
			{
				"photo_comment_edit", @params.PhotoCommentEdit
			},
			{
				"photo_comment_delete", @params.PhotoCommentDelete
			},
			{
				"photo_comment_restore", @params.PhotoCommentRestore
			},
			{
				"video_comment_new", @params.VideoCommentNew
			},
			{
				"video_comment_edit", @params.VideoCommentEdit
			},
			{
				"video_comment_delete", @params.VideoCommentDelete
			},
			{
				"video_comment_restore", @params.VideoCommentRestore
			},
			{
				"market_comment_new", @params.MarketCommentNew
			},
			{
				"market_comment_edit", @params.MarketCommentEdit
			},
			{
				"market_comment_delete", @params.MarketCommentDelete
			},
			{
				"market_comment_restore", @params.MarketCommentRestore
			},
			{
				"poll_vote_new", @params.PollVoteNew
			},
			{
				"group_join", @params.GroupJoin
			},
			{
				"group_leave", @params.GroupLeave
			},
			{
				"group_change_settings", @params.GroupChangeSettings
			},
			{
				"group_change_photo", @params.GroupChangePhoto
			},
			{
				"group_officers_edit", @params.GroupOfficersEdit
			},
			{
				"user_block", @params.UserBlock
			},
			{
				"user_unblock", @params.UserUnblock
			}
		});

	/// <inheritdoc />
	public GetLongPollSettingsResult GetLongPollSettings(ulong groupId) => _vk.Call<GetLongPollSettingsResult>("groups.getLongPollSettings",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public VkCollection<GroupTag> GetTagList(ulong groupId)
	{
		return _vk.Call("groups.getTagList",
				new VkParameters
				{
					{ "group_id", groupId }
				})
			.ToVkCollectionOf<GroupTag>(x => x);
	}

	/// <inheritdoc />
	public bool SetSettings(GroupsSetSettingsParams @params)
	{
		return _vk.Call<bool>("groups.setSettings",
			new()
			{
				{ "group_id", @params.GroupId },
				{ "messages", @params.Messages },
				{ "bots_capabilities", @params.BotsCapabilities },
				{ "bots_start_button", @params.BotsStartButton },
				{ "bots_add_to_chat", @params.BotsAddToChats }
			});
	}

	/// <inheritdoc />
	public bool SetUserNote(GroupsSetUserNoteParams @params)
	{
		if (@params.Note is
		{
			Length: > 96
		})
		{
			throw new VkApiException("Поле Note не может быть длиннее 96 символов");

		}

		return _vk.Call<bool>("groups.setUserNote",
			new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "user_id", @params.UserId },
				{ "note", @params.Note }
			});
		}

	private static readonly string[] ValidTagColors =
	{
		"4bb34b",
		"5c9ce6",
		"e64646",
		"792ec0",
		"63b9ba",
		"ffa000",
		"ffc107",
		"76787a",
		"9e8d6b",
		"45678f",
		"539b9c",
		"454647",
		"7a6c4f",
		"6bc76b",
		"5181b8",
		"ff5c5c",
		"a162de",
		"7ececf",
		"aaaeb3",
		"bbaa84"
	};

	/// <inheritdoc />
	public bool TagAdd(GroupsTagAddParams @params)
	{
		if (@params.TagName is { Length: > 20 })
		{
			throw new VkApiException("Поле TagName не может быть длиннее 20 символов");
		}

		string lowerTagColor = @params.TagColor?.ToLower() ?? throw new VkApiException("Параметр TagColor обязательный.");

		if (!ValidTagColors.Contains(lowerTagColor))
		{
			throw new VkApiException($"Параметр TagColor должен быть одним из следующих: {string.Join(",", ValidTagColors)}. Передан: {lowerTagColor}");
		}

		return _vk.Call<bool>("groups.tagAdd",
			new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "tag_name", @params.TagName },
				{ "tag_color", lowerTagColor }
			});
	}

	/// <inheritdoc />
	public bool TagBind(ulong groupId, ulong tagId, ulong userId, GroupTagAct act)
	{
		return _vk.Call<bool>("groups.tagBind",
			new()
			{
				{ "group_id", groupId },
				{ "tag_id", tagId },
				{ "user_id", userId },
				{ "act", act }
			});
	}

	/// <inheritdoc />
	public bool TagDelete(ulong groupId, ulong tagId)
	{
		return _vk.Call<bool>("groups.tagDelete",
			new()
			{
				{ "group_id", groupId },
				{ "tag_id", tagId }
			});
	}

	/// <inheritdoc />
	public bool TagUpdate(ulong groupId, ulong tagId, string tagName)
	{
		return _vk.Call<bool>("groups.tagUpdate",
			new()
			{
				{ "group_id", groupId },
				{ "tag_id", tagId },
				{ "tag_name", tagName }
			});
	}

	/// <inheritdoc />
	public bool ToggleMarket(GroupToggleMarketParams @params)
	{
		return _vk.Call<bool>("groups.toggleMarket",
			new()
			{
				{ "group_id", @params.GroupId },
				{ "state", @params.State },
				{ "ref", @params.Ref },
				{ "utm_source", @params.UtmSource },
				{ "utm_medium", @params.UtmMedium },
				{ "utm_campaign", @params.UtmCampaign },
				{ "utm_content", @params.UtmContent },
				{ "utm_term", @params.UtmTerm },
				{ "promocode", @params.Promocode }
			});
	}
}