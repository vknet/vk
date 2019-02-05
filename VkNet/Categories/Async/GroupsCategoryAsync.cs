using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class GroupsCategory
	{
		/// <inheritdoc />
		public Task<bool> JoinAsync(long? groupId, bool? notSure = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Join(groupId: groupId, notSure: notSure));
		}

		/// <inheritdoc />
		public Task<bool> LeaveAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Leave(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds
																, string groupId
																, GroupsFields fields
																, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetById(groupIds: groupIds, groupId: groupId, fields: fields, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetMembers(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId
																		, long? userId
																		, IEnumerable<long> userIds
																		, bool? extended
																		, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					IsMember(groupId: groupId
							, userId: userId
							, userIds: userIds
							, extended: extended
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Search(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetInvites(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public Task<bool> BanUserAsync(GroupsBanUserParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>BanUser(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId
																		, long? offset = null
																		, long? count = null
																		, GroupsFields fields = null
																		, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetBanned(groupId: groupId, offset: offset, count: count, fields: fields, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> UnbanUserAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>UnbanUser(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> EditManagerAsync(GroupsEditManagerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditManager(@params: @params));
		}

		/// <inheritdoc />
		public Task<GroupsEditParams> GetSettingsAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetSettings(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(GroupsEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditPlaceAsync(long groupId, Place place = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditPlace(groupId: groupId, place: place));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetInvitedUsersAsync(long groupId
																	, long? offset = null
																	, long? count = null
																	, UsersFields fields = null
																	, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetInvitedUsers(groupId: groupId, offset: offset, count: count, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Invite(groupId: groupId, userId: userId, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddLink(groupId: groupId, link: link, text: text));
		}

		/// <inheritdoc />
		public Task<bool> DeleteLinkAsync(long groupId, ulong linkId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteLink(groupId: groupId, linkId: linkId));
		}

		/// <inheritdoc />
		public Task<bool> EditLinkAsync(long groupId, ulong linkId, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditLink(groupId: groupId, linkId: linkId, text: text));
		}

		/// <inheritdoc />
		public Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					ReorderLink(groupId: groupId, linkId: linkId, after: after));
		}

		/// <inheritdoc />
		public Task<bool> RemoveUserAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RemoveUser(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> ApproveRequestAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>ApproveRequest(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public Task<Group> CreateAsync(string title
											, string description
											, GroupType type
											, GroupSubType? subtype
											, uint? publicCategory = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Create(title: title
							, description: description
							, type: type
							, subtype: subtype
							, publicCategory: publicCategory));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset, long? count, UsersFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetRequests(groupId: groupId, offset: offset, count: count, fields: fields));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetCatalog(categoryId: categoryId, subcategoryId: subcategoryId));
		}

		/// <inheritdoc />
		public Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetCatalogInfo(extended: extended, subcategories: subcategories));
		}

		/// <inheritdoc />
		public Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					AddCallbackServer(groupId: groupId, url: url, title: title, secretKey: secretKey));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteCallbackServer(groupId: groupId, serverId: serverId));
		}

		/// <inheritdoc />
		public Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					EditCallbackServer(groupId: groupId, serverId: serverId, url: url, title: title, secretKey: secretKey));
		}

		/// <inheritdoc />
		public Task<string> GetCallbackConfirmationCodeAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetCallbackConfirmationCode(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId, IEnumerable<ulong> serverIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetCallbackServers(groupId: groupId, serverIds: serverIds));
		}

		/// <inheritdoc />
		public Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetCallbackSettings(groupId: groupId, serverId: serverId));
		}

		/// <inheritdoc />
		public Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>SetCallbackSettings(@params: @params));
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetLongPollServer(groupId: groupId));
		}

		/// <inheritdoc/>
		public Task<bool> DisableOnlineAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DisableOnline(groupId));
		}

		/// <inheritdoc/>
		public Task<bool> EnableOnlineAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => EnableOnline(groupId));
		}

		/// <inheritdoc />
		public Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetBotsLongPollHistory(@params: @params));
		}
	}
}