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
			return TypeHelper.TryInvokeMethodAsync(() => Join(groupId, notSure));
		}

		/// <inheritdoc />
		public Task<bool> LeaveAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Leave(groupId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
															bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetById(groupIds, groupId, fields, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMembers(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId, long? userId, IEnumerable<long> userIds, bool? extended,
																	bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => IsMember(groupId, userId, userIds, extended, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Search(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetInvites(count, offset, extended));
		}

		/// <inheritdoc />
		public Task<bool> BanUserAsync(GroupsBanUserParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => BanUser(@params));
		}

		/// <inheritdoc />
		public Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId, long? offset = null, long? count = null,
																GroupsFields fields = null, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBanned(groupId, offset, count, fields, ownerId));
		}

		/// <inheritdoc />
		public Task<bool> UnbanUserAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UnbanUser(groupId, userId));
		}

		/// <inheritdoc />
		public Task<bool> EditManagerAsync(GroupsEditManagerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditManager(@params));
		}

		/// <inheritdoc />
		public Task<GroupsEditParams> GetSettingsAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetSettings(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(GroupsEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Edit(@params));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<bool> EditPlaceAsync(long groupId, Place place = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditPlace(groupId, place));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetInvitedUsersAsync(long groupId, long? offset = null, long? count = null,
															UsersFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetInvitedUsers(groupId, offset, count, fields, nameCase));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Invite(groupId, userId, captchaSid, captchaKey));
		}

		/// <inheritdoc />
		public Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddLink(groupId, link, text));
		}

		/// <inheritdoc />
		public Task<bool> DeleteLinkAsync(long groupId, ulong linkId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteLink(groupId, linkId));
		}

		/// <inheritdoc />
		public Task<bool> EditLinkAsync(long groupId, ulong linkId, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditLink(groupId, linkId, text));
		}

		/// <inheritdoc />
		public Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ReorderLink(groupId, linkId, after));
		}

		/// <inheritdoc />
		public Task<bool> RemoveUserAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveUser(groupId, userId));
		}

		/// <inheritdoc />
		public Task<bool> ApproveRequestAsync(long groupId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ApproveRequest(groupId, userId));
		}

		/// <inheritdoc />
		public Task<Group> CreateAsync(string title, string description, GroupType type, GroupSubType? subtype, uint? publicCategory = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Create(title, description, type, subtype, publicCategory));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset, long? count, UsersFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRequests(groupId, offset, count, fields));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCatalog(categoryId, subcategoryId));
		}

		/// <inheritdoc />
		public Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCatalogInfo(extended, subcategories));
		}

		/// <inheritdoc />
		public Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddCallbackServer(groupId, url, title, secretKey));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteCallbackServer(groupId, serverId));
		}

		/// <inheritdoc />
		public Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditCallbackServer(groupId, serverId, url, title, secretKey));
		}

		/// <inheritdoc />
		public Task<string> GetCallbackConfirmationCodeAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCallbackConfirmationCode(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId, IEnumerable<ulong> serverIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCallbackServers(groupId, serverIds));
		}

		/// <inheritdoc />
		public Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCallbackSettings(groupId, serverId));
		}

		/// <inheritdoc />
		public Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetCallbackSettings(@params));
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLongPollServer(groupId));
		}

		/// <inheritdoc/>
		public Task<bool> DisableOnlineAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DisableOnline(groupId));
		}

		/// <inheritdoc/>
		public Task<bool> EnableOnlineAsync(ulong groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EnableOnline(groupId));
		}

		/// <inheritdoc />
		public Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBotsLongPollHistory(@params));
		}
	}
}