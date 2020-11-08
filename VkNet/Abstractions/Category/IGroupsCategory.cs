using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Groups;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IGroupsCategoryAsync" />
	public interface IGroupsCategory : IGroupsCategoryAsync
	{
		/// <inheritdoc cref="IGroupsCategoryAsync.AddAddressAsync" />
		AddressResult AddAddress(AddAddressParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditAddressAsync" />
		AddressResult EditAddress(EditAddressParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.DeleteAddressAsync" />
		bool DeleteAddress(ulong groupId, ulong addressId);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetAddressesAsync" />
		VkCollection<AddressResult> GetAddresses(GetAddressesParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.JoinAsync" />
		bool Join(long? groupId, bool? notSure = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.LeaveAsync" />
		bool Leave(long groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetAsync" />
		VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetByIdAsync" />
		ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
										bool skipAuthorization = false);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetMembersAsync" />
		VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IGroupsCategoryAsync.IsMemberAsync" />
		ReadOnlyCollection<GroupMember> IsMember(string groupId, long? userId, IEnumerable<long> userIds, bool? extended,
												bool skipAuthorization = false);

		/// <inheritdoc cref="IGroupsCategoryAsync.SearchAsync" />
		VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetInvitesAsync" />
		VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.BanUserAsync" />
		bool BanUser(GroupsBanUserParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetBannedAsync" />
		VkCollection<GetBannedResult> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null,
												long? ownerId = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.UnbanUserAsync" />
		[Obsolete(ObsoleteText.UnbanUser, true)]
		bool UnbanUser(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.UnbanAsync" />
		bool Unban(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditManagerAsync" />
		bool EditManager(GroupsEditManagerParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetSettingsAsync" />
		GroupsEditParams GetSettings(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditAsync" />
		bool Edit(GroupsEditParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditPlaceAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		bool EditPlace(long groupId, Place place = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetInvitedUsersAsync" />
		VkCollection<User> GetInvitedUsers(long groupId, long? offset = null, long? count = null, UsersFields fields = null,
											NameCase nameCase = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.InviteAsync(long,long)" />
		bool Invite(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.InviteAsync(long,long,long?,string)" />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.AddLinkAsync" />
		ExternalLink AddLink(long groupId, Uri link, string text);

		/// <inheritdoc cref="IGroupsCategoryAsync.DeleteLinkAsync" />
		bool DeleteLink(long groupId, ulong linkId);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditLinkAsync" />
		bool EditLink(long groupId, ulong linkId, string text);

		/// <inheritdoc cref="IGroupsCategoryAsync.ReorderLinkAsync" />
		bool ReorderLink(long groupId, long linkId, long? after);

		/// <inheritdoc cref="IGroupsCategoryAsync.RemoveUserAsync" />
		bool RemoveUser(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.ApproveRequestAsync" />
		bool ApproveRequest(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.CreateAsync" />
		Group Create(string title, string description = null, GroupType type = null, GroupSubType? subtype = null,
					uint? publicCategory = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetRequestsAsync" />
		VkCollection<User> GetRequests(long groupId, long? offset = null, long? count = null, UsersFields fields = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetCatalogAsync" />
		VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetCatalogInfoAsync" />
		GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.AddCallbackServerAsync" />
		long AddCallbackServer(ulong groupId, string url, string title, string secretKey);

		/// <inheritdoc cref="IGroupsCategoryAsync.DeleteCallbackServerAsync" />
		bool DeleteCallbackServer(ulong groupId, ulong serverId);

		/// <inheritdoc cref="IGroupsCategoryAsync.EditCallbackServerAsync" />
		bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetCallbackConfirmationCodeAsync" />
		string GetCallbackConfirmationCode(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetCallbackServersAsync" />
		VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds = null);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetCallbackSettingsAsync" />
		CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId);

		/// <inheritdoc cref="IGroupsCategoryAsync.SetCallbackSettingsAsync" />
		bool SetCallbackSettings(CallbackServerParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetLongPollServerAsync" />
		LongPollServerResponse GetLongPollServer(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.DisableOnlineAsync" />
		bool DisableOnline(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.EnableOnlineAsync" />
		bool EnableOnline(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetBotsLongPollHistoryAsync" />
		BotsLongPollHistoryResponse GetBotsLongPollHistory(BotsLongPollHistoryParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetOnlineStatusAsync" />
		OnlineStatus GetOnlineStatus(ulong groupId);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetTokenPermissionsAsync" />
		TokenPermissionsResult GetTokenPermissions();

		/// <inheritdoc cref="IGroupsCategoryAsync.SetLongPollSettingsAsync" />
		bool SetLongPollSettings(SetLongPollSettingsParams @params);

		/// <inheritdoc cref="IGroupsCategoryAsync.GetLongPollSettingsAsync" />
		GetLongPollSettingsResult GetLongPollSettings(ulong groupId);
	}
}