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
		public async Task<bool> JoinAsync(long? groupId, bool? notSure = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.Join(groupId: groupId, notSure: notSure));
		}

		/// <inheritdoc />
		public async Task<bool> LeaveAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.Leave(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds
																, string groupId
																, GroupsFields fields
																, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetById(groupIds: groupIds, groupId: groupId, fields: fields, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetMembers(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId
																		, long? userId
																		, IEnumerable<long> userIds
																		, bool? extended
																		, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.IsMember(groupId: groupId
							, userId: userId
							, userIds: userIds
							, extended: extended
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.Search(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetInvites(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public async Task<bool> BanUserAsync(GroupsBanUserParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.BanUser(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId
																		, long? offset = null
																		, long? count = null
																		, GroupsFields fields = null
																		, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetBanned(groupId: groupId, offset: offset, count: count, fields: fields, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> UnbanUserAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.UnbanUser(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<bool> EditManagerAsync(GroupsEditManagerParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.EditManager(@params: @params));
		}

		/// <inheritdoc />
		public async Task<GroupsEditParams> GetSettingsAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.GetSettings(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(GroupsEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.Edit(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> EditPlaceAsync(long groupId, Place place = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.EditPlace(groupId: groupId, place: place));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetInvitedUsersAsync(long groupId
																	, long? offset = null
																	, long? count = null
																	, UsersFields fields = null
																	, NameCase nameCase = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetInvitedUsers(groupId: groupId, offset: offset, count: count, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public async Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.Invite(groupId: groupId, userId: userId, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public async Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.AddLink(groupId: groupId, link: link, text: text));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteLinkAsync(long groupId, ulong linkId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.DeleteLink(groupId: groupId, linkId: linkId));
		}

		/// <inheritdoc />
		public async Task<bool> EditLinkAsync(long groupId, ulong linkId, string text)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.EditLink(groupId: groupId, linkId: linkId, text: text));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.ReorderLink(groupId: groupId, linkId: linkId, after: after));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveUserAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.RemoveUser(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<bool> ApproveRequestAsync(long groupId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.ApproveRequest(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<Group> CreateAsync(string title
											, string description
											, GroupType type
											, GroupSubType? subtype
											, uint? publicCategory = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.Create(title: title
							, description: description
							, type: type
							, subtype: subtype
							, publicCategory: publicCategory));
		}

		/// <inheritdoc />
		public async Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset, long? count, UsersFields fields)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetRequests(groupId: groupId, offset: offset, count: count, fields: fields));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetCatalog(categoryId: categoryId, subcategoryId: subcategoryId));
		}

		/// <inheritdoc />
		public async Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.GetCatalogInfo(extended: extended, subcategories: subcategories));
		}

		/// <inheritdoc />
		public async Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.AddCallbackServer(groupId: groupId, url: url, title: title, secretKey: secretKey));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.DeleteCallbackServer(groupId: groupId, serverId: serverId));
		}

		/// <inheritdoc />
		public async Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Groups.EditCallbackServer(groupId: groupId, serverId: serverId, url: url, title: title, secretKey: secretKey));
		}

		/// <inheritdoc />
		public async Task<string> GetCallbackConfirmationCodeAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.GetCallbackConfirmationCode(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId, IEnumerable<ulong> serverIds = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.GetCallbackServers(groupId: groupId, serverIds: serverIds));
		}

		/// <inheritdoc />
		public async Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.GetCallbackSettings(groupId: groupId, serverId: serverId));
		}

		/// <inheritdoc />
		public async Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.SetCallbackSettings(@params: @params));
		}

		/// <inheritdoc />
		public async Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Groups.GetLongPollServer(groupId: groupId));
		}
	}
}