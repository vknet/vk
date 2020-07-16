using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AccountCategory
	{
		/// <inheritdoc />
		public Task<Counters> GetCountersAsync(CountersFilter filter)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCounters(filter));
		}

		/// <inheritdoc />
		public Task<bool> SetNameInMenuAsync(string name, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetNameInMenu(name, userId));
		}

		/// <inheritdoc />
		public Task<bool> SetOnlineAsync(bool? voip = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetOnline(voip));
		}

		/// <inheritdoc />
		public Task<bool> SetOfflineAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetOffline());
		}

		/// <inheritdoc />
		public Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RegisterDevice(@params));
		}

		/// <inheritdoc />
		public Task<bool> UnregisterDeviceAsync(string deviceId, bool? sandbox = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UnregisterDevice(deviceId, sandbox));
		}

		/// <inheritdoc />
		public Task<bool> SetSilenceModeAsync(string deviceId, int? time = null, int? peerId = null, bool? sound = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				SetSilenceMode(deviceId, time, peerId, sound));
		}

		/// <inheritdoc />
		public Task<AccountPushSettings> GetPushSettingsAsync(string deviceId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPushSettings(deviceId));
		}

		/// <inheritdoc />
		public Task<bool> SetPushSettingsAsync(string deviceId, PushSettings settings, string key, List<string> value)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				SetPushSettings(deviceId, settings, key, value));
		}

		/// <inheritdoc />
		public Task<long> GetAppPermissionsAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAppPermissions(userId));
		}

		/// <inheritdoc />
		public Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null, ulong? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetActiveOffers(offset, count));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.BanUserAsync)]
		public Task<bool> BanUserAsync(long ownerId)
		{
			return BanAsync(ownerId);
		}

		/// <inheritdoc />
		public Task<bool> BanAsync(long ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Ban(ownerId));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.UnbanUserAsync)]
		public Task<bool> UnbanUserAsync(long ownerId)
		{
			return UnbanAsync(ownerId);
		}

		/// <inheritdoc />
		public Task<bool> UnbanAsync(long ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Unban(ownerId));
		}

		/// <inheritdoc />
		public Task<AccountGetBannedResult> GetBannedAsync(int? offset = null, int? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBanned(offset, count));
		}

		/// <inheritdoc />
		public Task<AccountInfo> GetInfoAsync(AccountFields fields = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetInfo(fields));
		}

		/// <inheritdoc />
		public Task<bool> SetInfoAsync(string name, string value)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetInfo(name, value));
		}

		/// <inheritdoc />
		public Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword, string newPassword, string restoreSid = null,
																	string changePasswordHash = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ChangePassword(oldPassword,
				newPassword,
				restoreSid,
				changePasswordHash));
		}

		/// <inheritdoc />
		public Task<AccountSaveProfileInfoParams> GetProfileInfoAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetProfileInfo());
		}

		/// <inheritdoc />
		public Task<bool> SaveProfileInfoAsync(int cancelRequestId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveProfileInfo(cancelRequestId));
		}

		/// <inheritdoc />
		public Task<bool> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				SaveProfileInfo(out var _, @params));
		}

		/// <inheritdoc />
		public Task<PrivacySettings> GetPrivacySettingsAsync(CancellationToken token)
		{
			return TypeHelper.TryInvokeMethodAsync(GetPrivacySettings);
		}

		/// <inheritdoc />
		public Task<PrivacySettingsValue> SetPrivacyAsync(string key, string value)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetPrivacy(key, value));
		}
	}
}