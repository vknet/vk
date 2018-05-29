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
		private readonly VkApi _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public GroupsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public bool Join(long? groupId, bool? notSure = null)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "not_sure", notSure }
			};

			return _vk.Call(methodName: "groups.join", parameters: parameters);
		}

		/// <inheritdoc />
		public bool Leave(long groupId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
			};

			return _vk.Call(methodName: "groups.leave", parameters: parameters);
		}

		/// <inheritdoc />
		public VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.UserId);
			var response = _vk.Call(methodName: "groups.get", parameters: @params, skipAuthorization: skipAuthorization);

			// в первой записи количество членов группы для (response["items"])
			if (@params.Extended == null || !@params.Extended.Value)
			{
				return response.ToVkCollectionOf(selector: id => new Group { Id = id });
			}

			return response.ToVkCollectionOf<Group>(selector: r => r);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds
												, string groupId
												, GroupsFields fields
												, bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
					{ "group_ids", groupIds }
					, { "group_id", groupId }
					, { "fields", fields }
			};

			return _vk.Call(methodName: "groups.getById", parameters: parameters, skipAuthorization: skipAuthorization)
					.ToReadOnlyCollectionOf<Group>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			return _vk.Call(methodName: "groups.getMembers", parameters: @params, skipAuthorization: skipAuthorization)
					.ToVkCollectionOf(selector: x => @params.Fields != null ? x : new User { Id = x });
		}

		/// <inheritdoc />
		public ReadOnlyCollection<GroupMember> IsMember(string groupId
														, long? userId
														, IEnumerable<long> userIds
														, bool? extended
														, bool skipAuthorization = false)
		{
			if (userId.HasValue)
			{
				if (userIds != null)
				{
					if (userIds.Any(predicate: id => id < 1))
					{
						throw new ArgumentException(message: "Идентификатор пользователя должен быть больше 0");
					}

					var tempList = userIds.ToList();
					tempList.Add(item: userId.Value);
					userIds = tempList;
				} else
				{
					if (userId.Value < 1)
					{
						throw new ArgumentException(message: "Идентификатор пользователя должен быть больше 0");
					}

					userIds = new List<long>
					{
							userId.Value
					};
				}
			}

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "user_ids", userIds }
					, { "extended", Convert.ToInt32(value: extended) }
			};

			var result = _vk.Call(methodName: "groups.isMember", parameters: parameters, skipAuthorization: skipAuthorization);

			return result.ToReadOnlyCollectionOf<GroupMember>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call(methodName: "groups.search", parameters: @params, skipAuthorization: skipAuthorization)
					.ToVkCollectionOf<Group>(selector: r => r);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null)
		{
			var parameters = new VkParameters
			{
					{ "offset", offset }
					, { "count", count }
					, { "extended", extended }
			};

			return _vk.Call(methodName: "groups.getInvites", parameters: parameters).ToVkCollectionOf<Group>(selector: x => x);
		}

		/// <inheritdoc />
		public bool BanUser(GroupsBanUserParams @params)
		{
			return _vk.Call(methodName: "groups.banUser", parameters: @params);
		}

		/// <inheritdoc />
		public VkCollection<GetBannedResult> GetBanned(long groupId
														, long? offset = null
														, long? count = null
														, GroupsFields fields = null
														, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
					, { "owner_id", ownerId }
			};

			return _vk.Call<VkCollection<GetBannedResult>>(methodName: "groups.getBanned", parameters: parameters);
		}

		/// <inheritdoc />
		public bool UnbanUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "user_id", userId }
			};

			return _vk.Call(methodName: "groups.unbanUser", parameters: parameters);
		}

		/// <inheritdoc />
		public bool EditManager(GroupsEditManagerParams @params)
		{
			return _vk.Call(methodName: "groups.editManager", parameters: @params);
		}

		/// <inheritdoc />
		public GroupsEditParams GetSettings(ulong groupId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
			};

			GroupsEditParams result = _vk.Call(methodName: "groups.getSettings", parameters: parameters);
			result.GroupId = groupId; // Требует метод edit но getSettings не возвращает

			return result;
		}

		/// <inheritdoc />
		public bool Edit(GroupsEditParams @params)
		{
			var parameters = @params;

			return _vk.Call(methodName: "groups.edit", parameters: parameters);
		}

		/// <inheritdoc />
		public bool EditPlace(long groupId, Place place = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			if (place == null)
			{
				place = new Place();
			}

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "title", place.Title }
					, { "address", place.Address }
					, { "country_id", place.CountryId }
					, { "city_id", place.CityId }
					, { "latitude", place.Latitude }
					, { "longitude", place.Longitude }
			};

			var result = _vk.Call(methodName: "groups.editPlace", parameters: parameters);

			return result[key: "success"];
		}

		/// <inheritdoc />
		public VkCollection<User> GetInvitedUsers(long groupId
												, long? offset = null
												, long? count = null
												, UsersFields fields = null
												, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			return _vk.Call(methodName: "groups.getInvitedUsers", parameters: parameters).ToVkCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		public bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "user_id", userId }
					, { "captcha_sid", captchaSid }
					, { "captcha_key", captchaKey }
			};

			return _vk.Call(methodName: "groups.invite", parameters: parameters);
		}

		/// <inheritdoc />
		public ExternalLink AddLink(long groupId, Uri link, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "link", link }
					, { "text", text }
			};

			return _vk.Call(methodName: "groups.addLink", parameters: parameters);
		}

		/// <inheritdoc />
		public bool DeleteLink(long groupId, ulong linkId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "link_id", linkId }
			};

			return _vk.Call(methodName: "groups.deleteLink", parameters: parameters);
		}

		/// <inheritdoc />
		public bool EditLink(long groupId, ulong linkId, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "link_id", linkId }
					, { "text", text }
			};

			return _vk.Call(methodName: "groups.editLink", parameters: parameters);
		}

		/// <inheritdoc />
		public bool ReorderLink(long groupId, long linkId, long? after)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "link_id", linkId }
					, { "after", after }
			};

			return _vk.Call(methodName: "groups.reorderLink", parameters: parameters);
		}

		/// <inheritdoc />
		public bool RemoveUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "user_id", userId }
			};

			return _vk.Call(methodName: "groups.removeUser", parameters: parameters);
		}

		/// <inheritdoc />
		public bool ApproveRequest(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "user_id", userId }
			};

			return _vk.Call(methodName: "groups.approveRequest", parameters: parameters);
		}

		/// <inheritdoc />
		public Group Create(string title, string description, GroupType type, GroupSubType? subtype, uint? publicCategory = null)
		{
			var parameters = new VkParameters
			{
					{ "title", title }
					, { "description", description }
					, { "type", type }
					, { "subtype", subtype }
			};

			return _vk.Call(methodName: "groups.create", parameters: parameters);
		}

		/// <inheritdoc />
		public VkCollection<User> GetRequests(long groupId, long? offset, long? count, UsersFields fields)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
			};

			return _vk.Call(methodName: "groups.getRequests", parameters: parameters).ToVkCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			var parameters = new VkParameters
			{
					{ "category_id", categoryId }
					, { "subcategory_id", subcategoryId }
			};

			return _vk.Call(methodName: "groups.getCatalog", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<Group>(selector: x => x);
		}

		/// <inheritdoc />
		public GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null)
		{
			var parameters = new VkParameters
			{
					{ "extended", extended }
					, { "subcategories", subcategories }
			};

			return _vk.Call(methodName: "groups.getCatalogInfo", parameters: parameters, skipAuthorization: true);
		}

		/// <inheritdoc />
		public long AddCallbackServer(ulong groupId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "url", url }
					, { "title", title }
					, { "secret_key", secretKey }
			};

			return _vk.Call(methodName: "groups.addCallbackServer", parameters: parameters)[key: "server_id"];
		}

		/// <inheritdoc />
		public bool DeleteCallbackServer(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "server_id", serverId }
			};

			return _vk.Call(methodName: "groups.deleteCallbackServer", parameters: parameters);
		}

		/// <inheritdoc />
		public bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "server_id", serverId }
					, { "url", url }
					, { "title", title }
					, { "secret_key", secretKey }
			};

			return _vk.Call(methodName: "groups.editCallbackServer", parameters: parameters);
		}

		/// <inheritdoc />
		public string GetCallbackConfirmationCode(ulong groupId)
		{
			var response = _vk.Call(methodName: "groups.getCallbackConfirmationCode"
					, parameters: new VkParameters { { "group_id", groupId } });

			return response[key: "code"];
		}

		/// <inheritdoc />
		public VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "server_ids", serverIds }
			};

			return _vk.Call(methodName: "groups.getCallbackServers", parameters: parameters)
					.ToVkCollectionOf<CallbackServerItem>(selector: x => x);
		}

		/// <inheritdoc />
		public CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
					{ "group_id", groupId }
					, { "server_id", serverId }
			};

			return _vk.Call(methodName: "groups.getCallbackSettings", parameters: parameters);
		}

		/// <inheritdoc />
		public bool SetCallbackSettings(CallbackServerParams @params)
		{
			return _vk.Call(methodName: "groups.setCallbackSettings", parameters: @params);
		}

		/// <inheritdoc />
		public LongPollServerResponse GetLongPollServer(ulong groupId)
		{
			return _vk.Call<LongPollServerResponse>(methodName: "groups.getLongPollServer"
					, parameters: new VkParameters { { "group_id", groupId } });
		}
	}
}