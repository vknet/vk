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
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCounters(filter), token);

	/// <inheritdoc />
	public Task<bool> SetNameInMenuAsync(string name,
										long userId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetNameInMenu(name, userId), token);

	/// <inheritdoc />
	public Task<bool> SetOnlineAsync(bool? voip = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetOnline(voip), token);

	/// <inheritdoc />
	public Task<bool> SetOfflineAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(SetOffline, token);

	/// <inheritdoc />
	public Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params,
										 CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RegisterDevice(@params), token);

	/// <inheritdoc />
	public Task<bool> UnregisterDeviceAsync(string deviceId,
											bool? sandbox = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UnregisterDevice(deviceId, sandbox), token);

	/// <inheritdoc />
	public Task<bool> SetSilenceModeAsync(string deviceId,
										 int? time = null,
										 int? peerId = null,
										 bool? sound = null,
										 CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetSilenceMode(deviceId, time, peerId, sound), token);

	/// <inheritdoc />
	public Task<AccountPushSettings> GetPushSettingsAsync(string deviceId,
														 CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPushSettings(deviceId), token);

	/// <inheritdoc />
	public Task<bool> SetPushSettingsAsync(string deviceId,
										  PushSettings settings,
										  string key,
										  List<string> value,
										  CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetPushSettings(deviceId, settings, key, value), token);

	/// <inheritdoc />
	public Task<long> GetAppPermissionsAsync(long userId,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAppPermissions(userId), token);

	/// <inheritdoc />
	public Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null,
															ulong? count = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetActiveOffers(offset, count), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.BanUserAsync)]
	public Task<bool> BanUserAsync(long ownerId,
								  CancellationToken token = default) =>
		BanAsync(ownerId, token);

	/// <inheritdoc />
	public Task<bool> BanAsync(long ownerId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Ban(ownerId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUserAsync)]
	public Task<bool> UnbanUserAsync(long ownerId,
									CancellationToken token = default) =>
		UnbanAsync(ownerId, token);

	/// <inheritdoc />
	public Task<bool> UnbanAsync(long ownerId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unban(ownerId), token);

	/// <inheritdoc />
	public Task<AccountGetBannedResult> GetBannedAsync(int? offset = null,
														int? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBanned(offset, count), token);

	/// <inheritdoc />
	public Task<AccountInfo> GetInfoAsync(AccountFields fields = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInfo(fields), token);

	/// <inheritdoc />
	public Task<bool> SetInfoAsync(string name,
									string value,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetInfo(name, value), token);

	/// <inheritdoc />
	public Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword,
																string newPassword,
																string restoreSid = null,
																string changePasswordHash = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ChangePassword(oldPassword, newPassword, restoreSid, changePasswordHash), token);

	/// <inheritdoc />
	public Task<AccountSaveProfileInfoParams> GetProfileInfoAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetProfileInfo, token);

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(int cancelRequestId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveProfileInfo(cancelRequestId), token);

	/// <inheritdoc />
	public Task<ChangeNameRequest> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveProfileInfo(@params), token);

	/// <inheritdoc />
	public Task<PrivacySettings> GetPrivacySettingsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetPrivacySettings, token);

	/// <inheritdoc />
	public Task<PrivacySettingsValue> SetPrivacyAsync(PrivacyKey key,
													string value,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetPrivacy(key, value));
}