using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories {
	/// <inheritdoc />
	public partial class GroupsCategory {
		/// <inheritdoc />
		public async Task<bool> JoinAsync(long? groupId, bool? notSure = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.Join(groupId, notSure));
		}

		/// <inheritdoc />
		public async Task<bool> LeaveAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.Leave(groupId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.Get(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds, string groupId,
			GroupsFields fields, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.GetById(groupIds, groupId, fields, skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params,
			bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetMembers(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId, long? userId,
			IEnumerable<long> userIds, bool? extended, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.IsMember(groupId, userId, userIds, extended, skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.Search(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetInvites(count, offset, extended));
		}

		/// <inheritdoc />
		public async Task<bool> BanUserAsync(GroupsBanUserParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.BanUser(@params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId, long? offset = null,
			long? count = null,
			GroupsFields fields = null,
			long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.GetBanned(groupId, offset, count, fields, ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> UnbanUserAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.UnbanUser(groupId, userId));
		}

		/// <inheritdoc />
		public async Task<bool> EditManagerAsync(GroupsEditManagerParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.EditManager(@params));
		}

		/// <inheritdoc />
		public async Task<GroupsEditParams> GetSettingsAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetSettings(groupId));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(GroupsEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.Edit(@params));
		}

		/// <inheritdoc />
		public async Task<bool> EditPlaceAsync(long groupId, Place place = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.EditPlace(groupId, place));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetInvitedUsersAsync(long groupId, long? offset = null,
			long? count = null, UsersFields fields = null,
			NameCase nameCase = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.GetInvitedUsers(groupId, offset, count, fields, nameCase));
		}

		/// <inheritdoc />
		public async Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.Invite(groupId, userId, captchaSid, captchaKey));
		}

		/// <inheritdoc />
		public async Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.AddLink(groupId, link, text));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteLinkAsync(long groupId, ulong linkId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.DeleteLink(groupId, linkId));
		}

		/// <inheritdoc />
		public async Task<bool> EditLinkAsync(long groupId, ulong linkId, string text)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.EditLink(groupId, linkId, text));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.ReorderLink(groupId, linkId, after));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveUserAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.RemoveUser(groupId, userId));
		}

		/// <inheritdoc />
		public async Task<bool> ApproveRequestAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.ApproveRequest(groupId, userId));
		}

		/// <inheritdoc />
		public async Task<Group> CreateAsync(string title, string description, GroupType type, GroupSubType? subtype,
			uint? publicCategory = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.Create(title, description, type, subtype, publicCategory));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset, long? count,
			UsersFields fields)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetRequests(groupId, offset, count, fields));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetCatalog(categoryId, subcategoryId));
		}

		/// <inheritdoc />
		public async Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetCatalogInfo(extended, subcategories));
		}

		/// <inheritdoc />
		public async Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.AddCallbackServer(groupId, url, title, secretKey));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.DeleteCallbackServer(groupId, serverId));
		}

		/// <inheritdoc />
		public async Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title,
			string secretKey)
		{
			return await TypeHelper.TryInvokeMethodAsync(() =>
				_vk.Groups.EditCallbackServer(groupId, serverId, url, title, secretKey));
		}

		/// <inheritdoc />
		public async Task<string> GetCallbackConfirmationCodeAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetCallbackConfirmationCode(groupId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId,
			IEnumerable<ulong> serverIds = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetCallbackServers(groupId, serverIds));
		}

		/// <inheritdoc />
		public async Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetCallbackSettings(groupId, serverId));
		}

		/// <inheritdoc />
		public async Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.SetCallbackSettings(@params));
		}

		/// <inheritdoc/>
		public async Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Groups.GetLongPollServer(groupId));
		}
	}
}