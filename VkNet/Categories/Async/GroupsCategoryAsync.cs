using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Groups;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class GroupsCategory
{
	/// <inheritdoc />
	public Task<bool> JoinAsync(long? groupId, bool? notSure = null) => TypeHelper.TryInvokeMethodAsync(() => Join(groupId, notSure));

	/// <inheritdoc />
	public Task<bool> LeaveAsync(long groupId) => TypeHelper.TryInvokeMethodAsync(() => Leave(groupId));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(() => Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
														bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(() =>
		GetById(groupIds, groupId, fields, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMembers(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId, IEnumerable<long> userIds, bool? extended,
																bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(() =>
		IsMember(groupId, userIds, extended, skipAuthorization));

	/// <inheritdoc />
	public Task<GroupMember> IsMemberAsync(string groupId, long userId, bool? extended = true,
																bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(() =>
		IsMember(groupId, userId, extended, skipAuthorization));

	/// <inheritdoc />
	public Task<bool> IsMemberAsync(string groupId, long userId, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(() =>
		IsMember(groupId, userId, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(() => Search(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetInvites(count, offset, extended));

	/// <inheritdoc />
	public Task<bool> BanUserAsync(GroupsBanUserParams @params) => TypeHelper.TryInvokeMethodAsync(() => BanUser(@params));

	/// <inheritdoc />
	public Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId, long? offset = null, long? count = null,
															GroupsFields fields = null, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetBanned(groupId, offset, count, fields, ownerId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUserAsync, true)]
	public Task<bool> UnbanUserAsync(long groupId, long userId) => TypeHelper.TryInvokeMethodAsync(() => UnbanUser(groupId, userId));

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long groupId, long userId) => TypeHelper.TryInvokeMethodAsync(() => Unban(groupId, userId));

	/// <inheritdoc />
	public Task<bool> EditManagerAsync(GroupsEditManagerParams @params) => TypeHelper.TryInvokeMethodAsync(() => EditManager(@params));

	/// <inheritdoc />
	public Task<GroupsEditParams> GetSettingsAsync(ulong groupId) => TypeHelper.TryInvokeMethodAsync(() => GetSettings(groupId: groupId));

	/// <inheritdoc />
	public Task<bool> EditAsync(GroupsEditParams @params) => TypeHelper.TryInvokeMethodAsync(() => Edit(@params));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> EditPlaceAsync(long groupId, Place place = null) => TypeHelper.TryInvokeMethodAsync(() => EditPlace(groupId, place));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetInvitedUsersAsync(long groupId, long? offset = null, long? count = null,
														UsersFields fields = null, NameCase? nameCase = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetInvitedUsers(groupId, offset, count, fields, nameCase));

	/// <inheritdoc />
	public Task<bool> InviteAsync(long groupId, long userId) => TypeHelper.TryInvokeMethodAsync(() => Invite(groupId, userId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey) =>
		TypeHelper.TryInvokeMethodAsync(() => Invite(groupId, userId, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text) =>
		TypeHelper.TryInvokeMethodAsync(() => AddLink(groupId, link, text));

	/// <inheritdoc />
	public Task<bool> DeleteLinkAsync(long groupId, ulong linkId) => TypeHelper.TryInvokeMethodAsync(() => DeleteLink(groupId, linkId));

	/// <inheritdoc />
	public Task<bool> EditLinkAsync(long groupId, ulong linkId, string text) =>
		TypeHelper.TryInvokeMethodAsync(() => EditLink(groupId, linkId, text));

	/// <inheritdoc />
	public Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after) =>
		TypeHelper.TryInvokeMethodAsync(() => ReorderLink(groupId, linkId, after));

	/// <inheritdoc />
	public Task<bool> RemoveUserAsync(long groupId, long userId) => TypeHelper.TryInvokeMethodAsync(() => RemoveUser(groupId, userId));

	/// <inheritdoc />
	public Task<bool> ApproveRequestAsync(long groupId, long userId) =>
		TypeHelper.TryInvokeMethodAsync(() => ApproveRequest(groupId, userId));

	/// <inheritdoc />
	public Task<Group> CreateAsync(string title, string description = null, GroupType? type = null, GroupSubType? subtype = null,
									uint? publicCategory = null) => TypeHelper.TryInvokeMethodAsync(() =>
		Create(title, description, type, subtype, publicCategory));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset = null, long? count = null, UsersFields fields = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetRequests(groupId, offset, count, fields));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCatalog(categoryId, subcategoryId));

	/// <inheritdoc />
	public Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCatalogInfo(extended, subcategories));

	/// <inheritdoc />
	public Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null) =>
		TypeHelper.TryInvokeMethodAsync(() => AddCallbackServer(groupId, url, title, secretKey));

	/// <inheritdoc />
	public Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteCallbackServer(groupId, serverId));

	/// <inheritdoc />
	public Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title, string secretKey) =>
		TypeHelper.TryInvokeMethodAsync(() => EditCallbackServer(groupId, serverId, url, title, secretKey));

	/// <inheritdoc />
	public Task<string> GetCallbackConfirmationCodeAsync(ulong groupId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCallbackConfirmationCode(groupId: groupId));

	/// <inheritdoc />
	public Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId, IEnumerable<ulong> serverIds = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCallbackServers(groupId, serverIds));

	/// <inheritdoc />
	public Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCallbackSettings(groupId, serverId));

	/// <inheritdoc />
	public Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => SetCallbackSettings(@params));

	/// <inheritdoc />
	public Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLongPollServer(groupId));

	/// <inheritdoc />
	public Task<bool> DisableOnlineAsync(ulong groupId) => TypeHelper.TryInvokeMethodAsync(() => DisableOnline(groupId));

	/// <inheritdoc />
	public Task<bool> EnableOnlineAsync(ulong groupId) => TypeHelper.TryInvokeMethodAsync(() => EnableOnline(groupId));

	/// <inheritdoc />
	public Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetBotsLongPollHistory(@params));

	/// <inheritdoc />
	public Task<AddressResult> AddAddressAsync(AddAddressParams @params) => TypeHelper.TryInvokeMethodAsync(() => AddAddress(@params));

	/// <inheritdoc />
	public Task<AddressResult> EditAddressAsync(EditAddressParams @params) => TypeHelper.TryInvokeMethodAsync(() => EditAddress(@params));

	/// <inheritdoc />
	public Task<bool> DeleteAddressAsync(ulong groupId, ulong addressId) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteAddress(groupId, addressId));

	/// <inheritdoc />
	public Task<VkCollection<AddressResult>> GetAddressesAsync(GetAddressesParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAddresses(@params));

	/// <inheritdoc />
	public Task<OnlineStatus> GetOnlineStatusAsync(ulong groupId) => TypeHelper.TryInvokeMethodAsync(() => GetOnlineStatus(groupId));

	/// <inheritdoc />
	public Task<TokenPermissionsResult> GetTokenPermissionsAsync() => TypeHelper.TryInvokeMethodAsync(GetTokenPermissions);

	/// <inheritdoc />
	public Task<bool> SetLongPollSettingsAsync(SetLongPollSettingsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => SetLongPollSettings(@params));

	/// <inheritdoc />
	public Task<GetLongPollSettingsResult> GetLongPollSettingsAsync(ulong groupId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLongPollSettings(groupId));

	/// <inheritdoc />
	public Task<VkCollection<GroupTag>> GetTagListAsync(ulong groupId)
	{
		return TypeHelper.TryInvokeMethodAsync(() => GetTagList(groupId));
	}

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(GroupsSetSettingsParams @params)
	{
		return TypeHelper.TryInvokeMethodAsync(() => SetSettings(@params));
	}

	/// <inheritdoc />
	public Task<bool> SetUserNoteAsync(GroupsSetUserNoteParams @params)
	{
		return TypeHelper.TryInvokeMethodAsync(() => SetUserNote(@params));
	}

	/// <inheritdoc />
	public Task<bool> TagAddAsync(GroupsTagAddParams @params)
	{
		return TypeHelper.TryInvokeMethodAsync(() => TagAdd(@params));
	}

	/// <inheritdoc />
	public Task<bool> TagBindAsync(ulong groupId, ulong tagId, ulong userId, GroupTagAct act) =>
		TypeHelper.TryInvokeMethodAsync(() => TagBind(groupId, tagId, userId, act));

	/// <inheritdoc />
	public Task<bool> TagDeleteAsync(ulong groupId, ulong tagId) =>
		TypeHelper.TryInvokeMethodAsync(() => TagDelete(groupId, tagId));

	/// <inheritdoc />
	public Task<bool> TagUpdateAsync(ulong groupId, ulong tagId, string tagName) =>
		TypeHelper.TryInvokeMethodAsync(() => TagUpdate(groupId, tagId, tagName));

	/// <inheritdoc />
	public Task<bool> ToggleMarketAsync(GroupToggleMarketParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => ToggleMarket(@params));
}