using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IAccountCategoryAsync"/>
	public interface IAccountCategory : IAccountCategoryAsync
	{
		/// <inheritdoc cref="IAccountCategoryAsync.GetCountersAsync"/>
		Counters GetCounters(CountersFilter filter);

		/// <inheritdoc cref="IAccountCategoryAsync.SetNameInMenuAsync"/>
		bool SetNameInMenu([NotNull] string name, long userId);

		/// <inheritdoc cref="IAccountCategoryAsync.SetOnlineAsync"/>
		bool SetOnline(bool? voip = null);

		/// <inheritdoc cref="IAccountCategoryAsync.SetOfflineAsync"/>
		bool SetOffline();

		/// <inheritdoc cref="IAccountCategoryAsync.RegisterDeviceAsync"/>
		bool RegisterDevice(AccountRegisterDeviceParams @params);

		/// <inheritdoc cref="IAccountCategoryAsync.UnregisterDeviceAsync"/>
		bool UnregisterDevice(string deviceId, bool? sandbox = null);

		/// <inheritdoc cref="IAccountCategoryAsync.SetSilenceModeAsync"/>
		bool SetSilenceMode([NotNull] string deviceId
							, int? time = null
							, int? peerId = null
							, bool? sound = null);

		/// <inheritdoc cref="IAccountCategoryAsync.GetPushSettingsAsync"/>
		AccountPushSettings GetPushSettings(string deviceId);

		/// <inheritdoc cref="IAccountCategoryAsync.SetPushSettingsAsync"/>
		bool SetPushSettings(string deviceId, PushSettings settings, string key, List<string> value);

		/// <inheritdoc cref="IAccountCategoryAsync.GetAppPermissionsAsync"/>
		long GetAppPermissions(long userId);

		/// <inheritdoc cref="IAccountCategoryAsync.GetActiveOffersAsync"/>
		InformationAboutOffers GetActiveOffers(ulong? offset = null, ulong? count = null);

		/// <inheritdoc cref="IAccountCategoryAsync.BanUserAsync"/>
		bool BanUser(long ownerId);

		/// <inheritdoc cref="IAccountCategoryAsync.BanUserAsync"/>
		bool Ban(long ownerId);

		/// <inheritdoc cref="IAccountCategoryAsync.UnbanUserAsync"/>
		bool UnbanUser(long ownerId);

		/// <inheritdoc cref="IAccountCategoryAsync.UnbanUserAsync"/>
		bool Unban(long ownerId);

		/// <inheritdoc cref="IAccountCategoryAsync.GetBannedAsync"/>
		AccountGetBannedResult GetBanned(int? offset = null, int? count = null);

		/// <inheritdoc cref="IAccountCategoryAsync.GetInfoAsync"/>
		AccountInfo GetInfo(AccountFields fields = null);

		/// <inheritdoc cref="IAccountCategoryAsync.SetInfoAsync"/>
		bool SetInfo([NotNull] string name
					, [NotNull] string value);

		/// <inheritdoc cref="IAccountCategoryAsync.ChangePasswordAsync"/>
		AccountChangePasswordResult ChangePassword(string oldPassword
													, string newPassword
													, string restoreSid = null
													, string changePasswordHash = null);

		/// <inheritdoc cref="IAccountCategoryAsync.GetProfileInfoAsync"/>
		AccountSaveProfileInfoParams GetProfileInfo();

		/// <inheritdoc cref="IAccountCategoryAsync.SaveProfileInfoAsync(int)"/>
		bool SaveProfileInfo(int cancelRequestId);

		/// <inheritdoc cref="IAccountCategoryAsync.SaveProfileInfoAsync(AccountSaveProfileInfoParams)"/>
		bool SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveProfileInfoParams @params);

		/// <inheritdoc cref="IAccountCategoryAsync.GetPrivacySettingsAsync" />
		PrivacySettings GetPrivacySettings();

		/// <inheritdoc cref="IAccountCategoryAsync.SetPrivacyAsync" />
		PrivacySettingsValue SetPrivacy(string key, string value);
	}
}
