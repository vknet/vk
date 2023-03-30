using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
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
	public Task<bool> JoinAsync(long? groupId,
								bool? notSure = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Join(groupId, notSure));

	/// <inheritdoc />
	public Task<bool> LeaveAsync(long groupId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Leave(groupId));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetAsync(GroupsGetParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds,
														string groupId,
														GroupsFields fields,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(groupIds, groupId, fields, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMembers(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId,
																IEnumerable<long> userIds,
																bool? extended,
																bool skipAuthorization = false,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userIds, extended, skipAuthorization));

	/// <inheritdoc />
	public Task<GroupMember> IsMemberAsync(string groupId,
											long userId,
											bool? extended = true,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userId, extended, skipAuthorization));

	/// <inheritdoc />
	public Task<bool> IsMemberAsync(string groupId,
									long userId,
									bool skipAuthorization = false,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userId, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params,
												bool skipAuthorization = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetInvitesAsync(long? count,
													long? offset,
													bool? extended = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInvites(count, offset, extended));

	/// <inheritdoc />
	public Task<bool> BanUserAsync(GroupsBanUserParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			BanUser(@params));

	/// <inheritdoc />
	public Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId,
															long? offset = null,
															long? count = null,
															GroupsFields fields = null,
															long? ownerId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBanned(groupId, offset, count, fields, ownerId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUserAsync, true)]
	public Task<bool> UnbanUserAsync(long groupId,
									long userId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UnbanUser(groupId, userId));

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long groupId,
								long userId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unban(groupId, userId));

	/// <inheritdoc />
	public Task<bool> EditManagerAsync(GroupsEditManagerParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditManager(@params));

	/// <inheritdoc />
	public Task<GroupsEditParams> GetSettingsAsync(ulong groupId,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSettings(groupId));

	/// <inheritdoc />
	public Task<bool> EditAsync(GroupsEditParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> EditPlaceAsync(long groupId,
									Place place = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditPlace(groupId, place));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetInvitedUsersAsync(long groupId,
														long? offset = null,
														long? count = null,
														UsersFields fields = null,
														NameCase? nameCase = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInvitedUsers(groupId, offset, count, fields, nameCase));

	/// <inheritdoc />
	public Task<bool> InviteAsync(long groupId,
								long userId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Invite(groupId, userId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<bool> InviteAsync(long groupId,
								long userId,
								long? captchaSid,
								string captchaKey,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Invite(groupId, userId, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<ExternalLink> AddLinkAsync(long groupId,
											Uri link,
											string text,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddLink(groupId, link, text));

	/// <inheritdoc />
	public Task<bool> DeleteLinkAsync(long groupId,
									ulong linkId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteLink(groupId, linkId));

	/// <inheritdoc />
	public Task<bool> EditLinkAsync(long groupId,
									ulong linkId,
									string text,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditLink(groupId, linkId, text));

	/// <inheritdoc />
	public Task<bool> ReorderLinkAsync(long groupId,
										long linkId,
										long? after,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderLink(groupId, linkId, after));

	/// <inheritdoc />
	public Task<bool> RemoveUserAsync(long groupId,
									long userId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveUser(groupId, userId));

	/// <inheritdoc />
	public Task<bool> ApproveRequestAsync(long groupId,
										long userId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ApproveRequest(groupId, userId));

	/// <inheritdoc />
	public Task<Group> CreateAsync(string title,
									string description = null,
									GroupType? type = null,
									GroupSubType? subtype = null,
									uint? publicCategory = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(title, description, type, subtype, publicCategory));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetRequestsAsync(long groupId,
													long? offset = null,
													long? count = null,
													UsersFields fields = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequests(groupId, offset, count, fields));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null,
													ulong? subcategoryId = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(categoryId, subcategoryId));

	/// <inheritdoc />
	public Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null,
														bool? subcategories = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalogInfo(extended, subcategories));

	/// <inheritdoc />
	public Task<long> AddCallbackServerAsync(ulong groupId,
											string url,
											string title,
											string secretKey = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddCallbackServer(groupId, url, title, secretKey));

	/// <inheritdoc />
	public Task<bool> DeleteCallbackServerAsync(ulong groupId,
												ulong serverId,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteCallbackServer(groupId, serverId));

	/// <inheritdoc />
	public Task<bool> EditCallbackServerAsync(ulong groupId,
											ulong serverId,
											string url,
											string title,
											string secretKey,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditCallbackServer(groupId, serverId, url, title, secretKey));

	/// <inheritdoc />
	public Task<string> GetCallbackConfirmationCodeAsync(ulong groupId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackConfirmationCode(groupId));

	/// <inheritdoc />
	public Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId,
																		IEnumerable<ulong> serverIds = null,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackServers(groupId, serverIds));

	/// <inheritdoc />
	public Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId,
															ulong serverId,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackSettings(groupId, serverId));

	/// <inheritdoc />
	public Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetCallbackSettings(@params));

	/// <inheritdoc />
	public Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollServer(groupId));

	/// <inheritdoc />
	public Task<bool> DisableOnlineAsync(ulong groupId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DisableOnline(groupId));

	/// <inheritdoc />
	public Task<bool> EnableOnlineAsync(ulong groupId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EnableOnline(groupId));

	/// <inheritdoc />
	public Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params,
																		CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBotsLongPollHistory(@params));

	/// <inheritdoc />
	public Task<AddressResult> AddAddressAsync(AddAddressParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAddress(@params));

	/// <inheritdoc />
	public Task<AddressResult> EditAddressAsync(EditAddressParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAddress(@params));

	/// <inheritdoc />
	public Task<bool> DeleteAddressAsync(ulong groupId,
										ulong addressId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAddress(groupId, addressId));

	/// <inheritdoc />
	public Task<VkCollection<AddressResult>> GetAddressesAsync(GetAddressesParams @params,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAddresses(@params));

	/// <inheritdoc />
	public Task<OnlineStatus> GetOnlineStatusAsync(ulong groupId,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOnlineStatus(groupId));

	/// <inheritdoc />
	public Task<TokenPermissionsResult> GetTokenPermissionsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetTokenPermissions);

	/// <inheritdoc />
	public Task<bool> SetLongPollSettingsAsync(SetLongPollSettingsParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetLongPollSettings(@params));

	/// <inheritdoc />
	public Task<GetLongPollSettingsResult> GetLongPollSettingsAsync(ulong groupId,
																	CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollSettings(groupId));

	/// <inheritdoc />
	public Task<VkCollection<GroupTag>> GetTagListAsync(ulong groupId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTagList(groupId));

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(GroupsSetSettingsParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSettings(@params));

	/// <inheritdoc />
	public Task<bool> SetUserNoteAsync(GroupsSetUserNoteParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetUserNote(@params));

	/// <inheritdoc />
	public Task<bool> TagAddAsync(GroupsTagAddParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagAdd(@params));

	/// <inheritdoc />
	public Task<bool> TagBindAsync(ulong groupId,
									ulong tagId,
									ulong userId,
									GroupTagAct act,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagBind(groupId, tagId, userId, act));

	/// <inheritdoc />
	public Task<bool> TagDeleteAsync(ulong groupId,
									ulong tagId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagDelete(groupId, tagId));

	/// <inheritdoc />
	public Task<bool> TagUpdateAsync(ulong groupId,
									ulong tagId,
									string tagName,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagUpdate(groupId, tagId, tagName));

	/// <inheritdoc />
	public Task<bool> ToggleMarketAsync(GroupToggleMarketParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ToggleMarket(@params));
}