using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	/// <summary>
	/// Методы для работы с сообществами (группами).
	/// </summary>
	public partial class GroupsCategory : IGroupsCategory
	{
		private readonly IVkInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public GroupsCategory(IVkInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public bool Join(long? groupId, bool? notSure = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "not_sure", notSure }
			};

			return _vk.Call("groups.join", parameters);
		}

		/// <inheritdoc />
		public bool Leave(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("groups.leave", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.UserId);
			var response = _vk.Call("groups.get", @params, skipAuthorization);

			// в первой записи количество членов группы для (response["items"])
			if (@params.Extended == null || !@params.Extended.Value)
			{
				return response.ToVkCollectionOf(id => new Group
				{
					Id = id
				});
			}

			return response.ToVkCollectionOf<Group>(r => r);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
												bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
				{ "group_ids", groupIds },
				{ "group_id", groupId },
				{ "fields", fields }
			};

			return _vk.Call("groups.getById", parameters, skipAuthorization)
				.ToReadOnlyCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("groups.getMembers", @params, skipAuthorization)
				.ToVkCollectionOf(x => @params.Fields != null
					? x
					: new User
					{
						Id = x
					});
		}

		/// <inheritdoc />
		public ReadOnlyCollection<GroupMember> IsMember(string groupId, long? userId, IEnumerable<long> userIds, bool? extended,
														bool skipAuthorization = false)
		{
			if (userId.HasValue)
			{
				if (userIds != null)
				{
					if (userIds.Any(id => id < 1))
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}

					var tempList = userIds.ToList();
					tempList.Add(userId.Value);
					userIds = tempList;
				} else
				{
					if (userId.Value < 1)
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}

					userIds = new List<long>
					{
						userId.Value
					};
				}
			}

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_ids", userIds },
				{ "extended", Convert.ToInt32(extended) }
			};

			var result = _vk.Call("groups.isMember", parameters, skipAuthorization);

			return result.ToReadOnlyCollectionOf<GroupMember>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("groups.search", @params, skipAuthorization)
				.ToVkCollectionOf<Group>(r => r);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null)
		{
			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "count", count },
				{ "extended", extended }
			};

			return _vk.Call("groups.getInvites", parameters).ToVkCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public bool BanUser(GroupsBanUserParams @params)
		{
			return _vk.Call("groups.banUser", @params);
		}

		/// <inheritdoc />
		public VkCollection<GetBannedResult> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null,
														long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "owner_id", ownerId }
			};

			return _vk.Call<VkCollection<GetBannedResult>>("groups.getBanned", parameters);
		}

		/// <inheritdoc />
		public bool UnbanUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.unbanUser", parameters);
		}

		/// <inheritdoc />
		public bool EditManager(GroupsEditManagerParams @params)
		{
			return _vk.Call("groups.editManager", @params);
		}

		/// <inheritdoc />
		public GroupsEditParams GetSettings(ulong groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			GroupsEditParams result = _vk.Call("groups.getSettings", parameters);
			result.GroupId = groupId; // Требует метод edit но getSettings не возвращает

			return result;
		}

		/// <inheritdoc />
		public bool Edit(GroupsEditParams @params)
		{
			var parameters = @params;

			return _vk.Call("groups.edit", parameters);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public bool EditPlace(long groupId, Place place = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			if (place == null)
			{
				place = new Place();
			}

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "title", place.Title },
				{ "address", place.Address },
				{ "country_id", place.CountryId },
				{ "city_id", place.CityId },
				{ "latitude", place.Latitude },
				{ "longitude", place.Longitude }
			};

			var result = _vk.Call("groups.editPlace", parameters);

			return result["success"];
		}

		/// <inheritdoc />
		public VkCollection<User> GetInvitedUsers(long groupId, long? offset = null, long? count = null, UsersFields fields = null,
												NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call("groups.getInvitedUsers", parameters).ToVkCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId },
				{ "captcha_sid", captchaSid },
				{ "captcha_key", captchaKey }
			};

			return _vk.Call("groups.invite", parameters);
		}

		/// <inheritdoc />
		public ExternalLink AddLink(long groupId, Uri link, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link", link },
				{ "text", text }
			};

			return _vk.Call("groups.addLink", parameters);
		}

		/// <inheritdoc />
		public bool DeleteLink(long groupId, ulong linkId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId }
			};

			return _vk.Call("groups.deleteLink", parameters);
		}

		/// <inheritdoc />
		public bool EditLink(long groupId, ulong linkId, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "text", text }
			};

			return _vk.Call("groups.editLink", parameters);
		}

		/// <inheritdoc />
		public bool ReorderLink(long groupId, long linkId, long? after)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "after", after }
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
				{ "group_id", groupId },
				{ "user_id", userId }
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
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.approveRequest", parameters);
		}

		/// <inheritdoc />
		public Group Create(string title, string description, GroupType type, GroupSubType? subtype, uint? publicCategory = null)
		{
			var parameters = new VkParameters
			{
				{ "title", title },
				{ "description", description },
				{ "type", type },
				{ "subtype", subtype }
			};

			return _vk.Call("groups.create", parameters);
		}

		/// <inheritdoc />
		public VkCollection<User> GetRequests(long groupId, long? offset, long? count, UsersFields fields)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields }
			};

			return _vk.Call("groups.getRequests", parameters).ToVkCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			var parameters = new VkParameters
			{
				{ "category_id", categoryId },
				{ "subcategory_id", subcategoryId }
			};

			return _vk.Call("groups.getCatalog", parameters, true)
				.ToVkCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", extended },
				{ "subcategories", subcategories }
			};

			return _vk.Call("groups.getCatalogInfo", parameters, true);
		}

		/// <inheritdoc />
		public long AddCallbackServer(ulong groupId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "url", url },
				{ "title", title },
				{ "secret_key", secretKey }
			};

			return _vk.Call("groups.addCallbackServer", parameters)["server_id"];
		}

		/// <inheritdoc />
		public bool DeleteCallbackServer(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId }
			};

			return _vk.Call("groups.deleteCallbackServer", parameters);
		}

		/// <inheritdoc />
		public bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId },
				{ "url", url },
				{ "title", title },
				{ "secret_key", secretKey }
			};

			return _vk.Call("groups.editCallbackServer", parameters);
		}

		/// <inheritdoc />
		public string GetCallbackConfirmationCode(ulong groupId)
		{
			var response = _vk.Call("groups.getCallbackConfirmationCode",
				new VkParameters
				{
					{ "group_id", groupId }
				});

			return response["code"];
		}

		/// <inheritdoc />
		public VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_ids", serverIds }
			};

			return _vk.Call("groups.getCallbackServers", parameters)
				.ToVkCollectionOf<CallbackServerItem>(x => x);
		}

		/// <inheritdoc />
		public CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId }
			};

			return _vk.Call("groups.getCallbackSettings", parameters);
		}

		/// <inheritdoc />
		public bool SetCallbackSettings(CallbackServerParams @params)
		{
			return _vk.Call("groups.setCallbackSettings", @params);
		}

		/// <inheritdoc />
		public LongPollServerResponse GetLongPollServer(ulong groupId)
		{
			return _vk.Call<LongPollServerResponse>("groups.getLongPollServer",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc/>
		public bool DisableOnline(ulong groupId)
		{
			return _vk.Call<bool>("groups.disableOnline",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc/>
		public bool EnableOnline(ulong groupId)
		{
			return _vk.Call<bool>("groups.enableOnline",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public BotsLongPollHistoryResponse GetBotsLongPollHistory(BotsLongPollHistoryParams @params)
		{
			return _vk.CallLongPoll(@params.Server, @params);
		}
	}
}