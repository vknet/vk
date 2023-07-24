using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
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
			Join(groupId, notSure), token);

	/// <inheritdoc />
	public Task<bool> LeaveAsync(long groupId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Leave(groupId), token);

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetAsync(GroupsGetParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds,
														string groupId,
														GroupsFields fields,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(groupIds, groupId, fields, skipAuthorization), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMembers(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId,
																IEnumerable<long> userIds,
																bool? extended,
																bool skipAuthorization = false,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userIds, extended, skipAuthorization), token);

	/// <inheritdoc />
	public Task<GroupMember> IsMemberAsync(string groupId,
											long userId,
											bool? extended = true,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userId, extended, skipAuthorization), token);

	/// <inheritdoc />
	public Task<bool> IsMemberAsync(string groupId,
									long userId,
									bool skipAuthorization = false,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMember(groupId, userId, skipAuthorization), token);

	/// <inheritdoc />
	public Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params,
												bool skipAuthorization = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetInvitesAsync(long? count,
													long? offset,
													bool? extended = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInvites(count, offset, extended), token);

	/// <inheritdoc />
	public Task<bool> BanUserAsync(GroupsBanUserParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			BanUser(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId,
															long? offset = null,
															long? count = null,
															GroupsFields fields = null,
															long? ownerId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBanned(groupId, offset, count, fields, ownerId), token);

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long groupId,
								long userId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unban(groupId, userId), token);

	/// <inheritdoc />
	public Task<bool> EditManagerAsync(GroupsEditManagerParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditManager(@params), token);

	/// <inheritdoc />
	public Task<GroupsEditParams> GetSettingsAsync(ulong groupId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSettings(groupId), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(GroupsEditParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> EditPlaceAsync(long groupId,
									Place place = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditPlace(groupId, place), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetInvitedUsersAsync(long groupId,
														long? offset = null,
														long? count = null,
														UsersFields fields = null,
														NameCase? nameCase = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInvitedUsers(groupId, offset, count, fields, nameCase), token);

	/// <inheritdoc />
	public Task<bool> InviteAsync(long groupId,
								long userId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Invite(groupId, userId), token);


	/// <inheritdoc />
	public Task<ExternalLink> AddLinkAsync(long groupId,
											Uri link,
											string text,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddLink(groupId, link, text), token);

	/// <inheritdoc />
	public Task<bool> DeleteLinkAsync(long groupId,
									ulong linkId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteLink(groupId, linkId), token);

	/// <inheritdoc />
	public Task<bool> EditLinkAsync(long groupId,
									ulong linkId,
									string text,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditLink(groupId, linkId, text), token);

	/// <inheritdoc />
	public Task<bool> ReorderLinkAsync(long groupId,
										long linkId,
										long? after,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderLink(groupId, linkId, after), token);

	/// <inheritdoc />
	public Task<bool> RemoveUserAsync(long groupId,
									long userId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveUser(groupId, userId), token);

	/// <inheritdoc />
	public Task<bool> ApproveRequestAsync(long groupId,
										long userId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ApproveRequest(groupId, userId), token);

	/// <inheritdoc />
	public Task<Group> CreateAsync(string title,
									string description = null,
									GroupType? type = null,
									GroupSubType? subtype = null,
									uint? publicCategory = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(title, description, type, subtype, publicCategory), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetRequestsAsync(long groupId,
													long? offset = null,
													long? count = null,
													UsersFields fields = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequests(groupId, offset, count, fields), token);

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null,
													ulong? subcategoryId = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(categoryId, subcategoryId), token);

	/// <inheritdoc />
	public Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null,
														bool? subcategories = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalogInfo(extended, subcategories), token);

	/// <inheritdoc />
	public Task<long> AddCallbackServerAsync(ulong groupId,
											string url,
											string title,
											string secretKey = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddCallbackServer(groupId, url, title, secretKey), token);

	/// <inheritdoc />
	public Task<bool> DeleteCallbackServerAsync(ulong groupId,
												ulong serverId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteCallbackServer(groupId, serverId), token);

	/// <inheritdoc />
	public Task<bool> EditCallbackServerAsync(ulong groupId,
											ulong serverId,
											string url,
											string title,
											string secretKey,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditCallbackServer(groupId, serverId, url, title, secretKey), token);

	/// <inheritdoc />
	public Task<string> GetCallbackConfirmationCodeAsync(ulong groupId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackConfirmationCode(groupId), token);

	/// <inheritdoc />
	public Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId,
																		IEnumerable<ulong> serverIds = null,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackServers(groupId, serverIds), token);

	/// <inheritdoc />
	public Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId,
															ulong serverId,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCallbackSettings(groupId, serverId), token);

	/// <inheritdoc />
	public Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetCallbackSettings(@params), token);

	/// <inheritdoc />
	public Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollServer(groupId), token);

	/// <inheritdoc />
	public Task<bool> DisableOnlineAsync(ulong groupId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DisableOnline(groupId), token);

	/// <inheritdoc />
	public Task<bool> EnableOnlineAsync(ulong groupId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EnableOnline(groupId), token);

	/// <inheritdoc />
	public Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params,
																		CancellationToken token = default) =>
		GetBotsLongPollHistoryAsync<BotsLongPollHistoryResponse>(@params, token);

	/// <inheritdoc />
	public Task<T> GetBotsLongPollHistoryAsync<T>(BotsLongPollHistoryParams @params,
												CancellationToken token = default) => TypeHelper.TryInvokeMethodAsync(() =>
		GetBotsLongPollHistory<T>(@params), token);

	/// <inheritdoc />
	public Task<AddressResult> AddAddressAsync(AddAddressParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAddress(@params), token);

	/// <inheritdoc />
	public Task<AddressResult> EditAddressAsync(EditAddressParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAddress(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteAddressAsync(ulong groupId,
										ulong addressId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAddress(groupId, addressId), token);

	/// <inheritdoc />
	public Task<VkCollection<AddressResult>> GetAddressesAsync(GetAddressesParams @params,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAddresses(@params), token);

	/// <inheritdoc />
	public Task<OnlineStatus> GetOnlineStatusAsync(ulong groupId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOnlineStatus(groupId), token);

	/// <inheritdoc />
	public Task<TokenPermissionsResult> GetTokenPermissionsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetTokenPermissions, token);

	/// <inheritdoc />
	public Task<bool> SetLongPollSettingsAsync(SetLongPollSettingsParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetLongPollSettings(@params), token);

	/// <inheritdoc />
	public Task<GetLongPollSettingsResult> GetLongPollSettingsAsync(ulong groupId,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollSettings(groupId), token);

	/// <inheritdoc />
	public Task<VkCollection<GroupTag>> GetTagListAsync(ulong groupId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTagList(groupId), token);

	/// <inheritdoc />
	public Task<bool> SetSettingsAsync(GroupsSetSettingsParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSettings(@params), token);

	/// <inheritdoc />
	public Task<bool> SetUserNoteAsync(GroupsSetUserNoteParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetUserNote(@params), token);

	/// <inheritdoc />
	public Task<bool> TagAddAsync(GroupsTagAddParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagAdd(@params), token);

	/// <inheritdoc />
	public Task<bool> TagBindAsync(ulong groupId,
									ulong tagId,
									ulong userId,
									GroupTagAct act,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagBind(groupId, tagId, userId, act), token);

	/// <inheritdoc />
	public Task<bool> TagDeleteAsync(ulong groupId,
									ulong tagId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagDelete(groupId, tagId), token);

	/// <inheritdoc />
	public Task<bool> TagUpdateAsync(ulong groupId,
									ulong tagId,
									string tagName,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			TagUpdate(groupId, tagId, tagName), token);

	/// <inheritdoc />
	public Task<bool> ToggleMarketAsync(GroupToggleMarketParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ToggleMarket(@params), token);
}