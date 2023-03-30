using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AccountCategory
{
	/// <inheritdoc />
	public Task<Counters> GetCountersAsync(CountersFilter filter,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCounters(filter));

	/// <inheritdoc />
	public Task<bool> SetNameInMenuAsync(string name,
										long userId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SetNameInMenu(name, userId));

	/// <inheritdoc />
	public Task<bool> SetOnlineAsync(bool? voip = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => SetOnline(voip));

	/// <inheritdoc />
	public Task<bool> SetOfflineAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SetOffline());

	/// <inheritdoc />
	public Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params,
										 CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => RegisterDevice(@params));

	/// <inheritdoc />
	public Task<bool> UnregisterDeviceAsync(string deviceId,
											bool? sandbox = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => UnregisterDevice(deviceId, sandbox));

	/// <inheritdoc />
	public Task<bool> SetSilenceModeAsync(string deviceId,
										 int? time = null,
										 int? peerId = null,
										 bool? sound = null,
										 CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => SetSilenceMode(deviceId, time, peerId, sound));

	/// <inheritdoc />
	public Task<AccountPushSettings> GetPushSettingsAsync(string deviceId,
														 CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetPushSettings(deviceId));

	/// <inheritdoc />
	public Task<bool> SetPushSettingsAsync(string deviceId,
										  PushSettings settings,
										  string key,
										  List<string> value,
										  CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SetPushSettings(deviceId, settings, key, value));

	/// <inheritdoc />
	public Task<long> GetAppPermissionsAsync(long userId,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAppPermissions(userId));

	/// <inheritdoc />
	public Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null,
															ulong? count = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetActiveOffers(offset, count));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.BanUserAsync)]
	public Task<bool> BanUserAsync(long ownerId,
								  CancellationToken token) => BanAsync(ownerId, token);

	/// <inheritdoc />
	public Task<bool> BanAsync(long ownerId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => Ban(ownerId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUserAsync)]
	public Task<bool> UnbanUserAsync(long ownerId,
									CancellationToken token) => UnbanAsync(ownerId, token);

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long ownerId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => Unban(ownerId));

	/// <inheritdoc />
	public Task<AccountGetBannedResult> GetBannedAsync(int? offset = null,
														int? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetBanned(offset, count));

	/// <inheritdoc />
	public Task<AccountInfo> GetInfoAsync(AccountFields fields = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetInfo(fields));

	/// <inheritdoc />
	public Task<bool> SetInfoAsync(string name,
									string value,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SetInfo(name, value));

	/// <inheritdoc />
	public Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword,
																string newPassword,
																string restoreSid = null,
																string changePasswordHash = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
		ChangePassword(oldPassword,
			newPassword,
			restoreSid,
			changePasswordHash));

	/// <inheritdoc />
	public Task<AccountSaveProfileInfoParams> GetProfileInfoAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetProfileInfo());

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(int cancelRequestId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveProfileInfo(cancelRequestId));

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
		SaveProfileInfo(@params));

	/// <inheritdoc />
	public Task<PrivacySettings> GetPrivacySettingsAsync(CancellationToken token) => TypeHelper.TryInvokeMethodAsync(GetPrivacySettings);

	/// <inheritdoc />
	public Task<PrivacySettingsValue> SetPrivacyAsync(PrivacyKey key,
													string value,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SetPrivacy(key, value));
}