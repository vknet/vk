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
	public Task<Counters> GetCountersAsync(CountersFilter filter) => TypeHelper.TryInvokeMethodAsync(() => GetCounters(filter));

	/// <inheritdoc />
	public Task<bool> SetNameInMenuAsync(string name, long userId) => TypeHelper.TryInvokeMethodAsync(() => SetNameInMenu(name, userId));

	/// <inheritdoc />
	public Task<bool> SetOnlineAsync(bool? voip = null) => TypeHelper.TryInvokeMethodAsync(() => SetOnline(voip));

	/// <inheritdoc />
	public Task<bool> SetOfflineAsync() => TypeHelper.TryInvokeMethodAsync(() => SetOffline());

	/// <inheritdoc />
	public Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => RegisterDevice(@params));

	/// <inheritdoc />
	public Task<bool> UnregisterDeviceAsync(string deviceId, bool? sandbox = null) =>
		TypeHelper.TryInvokeMethodAsync(() => UnregisterDevice(deviceId, sandbox));

	/// <inheritdoc />
	public Task<bool> SetSilenceModeAsync(string deviceId, int? time = null, int? peerId = null, bool? sound = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSilenceMode(deviceId, time, peerId, sound));

	/// <inheritdoc />
	public Task<AccountPushSettings> GetPushSettingsAsync(string deviceId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetPushSettings(deviceId));

	/// <inheritdoc />
	public Task<bool> SetPushSettingsAsync(string deviceId, PushSettings settings, string key, List<string> value) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetPushSettings(deviceId, settings, key, value));

	/// <inheritdoc />
	public Task<long> GetAppPermissionsAsync(long userId) => TypeHelper.TryInvokeMethodAsync(() => GetAppPermissions(userId));

	/// <inheritdoc />
	public Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null, ulong? count = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetActiveOffers(offset, count));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.BanUserAsync)]
	public Task<bool> BanUserAsync(long ownerId) => BanAsync(ownerId);

	/// <inheritdoc />
	public Task<bool> BanAsync(long ownerId) => TypeHelper.TryInvokeMethodAsync(() => Ban(ownerId));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUserAsync)]
	public Task<bool> UnbanUserAsync(long ownerId) => UnbanAsync(ownerId);

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long ownerId) => TypeHelper.TryInvokeMethodAsync(() => Unban(ownerId));

	/// <inheritdoc />
	public Task<AccountGetBannedResult> GetBannedAsync(int? offset = null, int? count = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetBanned(offset, count));

	/// <inheritdoc />
	public Task<AccountInfo> GetInfoAsync(AccountFields fields = null) => TypeHelper.TryInvokeMethodAsync(() => GetInfo(fields));

	/// <inheritdoc />
	public Task<bool> SetInfoAsync(string name, string value) => TypeHelper.TryInvokeMethodAsync(() => SetInfo(name, value));

	/// <inheritdoc />
	public Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword, string newPassword, string restoreSid = null,
																string changePasswordHash = null) => TypeHelper.TryInvokeMethodAsync(() =>
		ChangePassword(oldPassword,
			newPassword,
			restoreSid,
			changePasswordHash));

	/// <inheritdoc />
	public Task<AccountSaveProfileInfoParams> GetProfileInfoAsync() => TypeHelper.TryInvokeMethodAsync(() => GetProfileInfo());

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(int cancelRequestId) => TypeHelper.TryInvokeMethodAsync(() => SaveProfileInfo(cancelRequestId));

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params) => TypeHelper.TryInvokeMethodAsync(() =>
		SaveProfileInfo(@params));

	/// <inheritdoc />
	public Task<PrivacySettings> GetPrivacySettingsAsync(CancellationToken token) => TypeHelper.TryInvokeMethodAsync(GetPrivacySettings);

	/// <inheritdoc />
	public Task<PrivacySettingsValue> SetPrivacyAsync(PrivacyKey key, string value) =>
		TypeHelper.TryInvokeMethodAsync(() => SetPrivacy(key, value));
}