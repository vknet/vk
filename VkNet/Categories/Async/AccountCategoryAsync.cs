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
		public async Task<Counters> GetCountersAsync(CountersFilter filter, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.getCounters",
					new VkParameters
					{
						{ "filter", filter }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetNameInMenuAsync(string name, long? userId = null, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setNameInMenu",
					new VkParameters
					{
						{ "name", name },
						{ "user_id", userId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetOnlineAsync(bool? voip = null, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setOnline",
					new VkParameters
					{
						{ "voip", voip }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetOfflineAsync(CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setOffline",
					VkParameters.Empty,
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> RegisterDeviceAsync(AccountRegisterDeviceParams @params, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.registerDevice",
					@params,
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> UnregisterDeviceAsync(string deviceId, bool? sandbox = null, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.unregisterDevice",
					new VkParameters
					{
						{ "device_id", deviceId },
						{ "sandbox", sandbox }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetSilenceModeAsync(string deviceId,
													int? time = null,
													int? peerId = null,
													bool? sound = null,
													CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setSilenceMode",
					new VkParameters
					{
						{ "device_id", deviceId },
						{ "time", time },
						{ "peer_id", peerId },
						{ "sound", sound }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<AccountPushSettings> GetPushSettingsAsync(string deviceId, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.getPushSettings",
					new VkParameters
					{
						{ "device_id", deviceId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetPushSettingsAsync(string deviceId,
													PushSettings settings,
													string key,
													IEnumerable<string> value,
													CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setPushSettings",
					new VkParameters
					{
						{ "device_id", deviceId },
						{ "settings", settings },
						{ "key", key },
						{ "value", value }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<long> GetAppPermissionsAsync(long userId, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.getAppPermissions",
					new VkParameters
					{
						{ "user_id", userId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<InformationAboutOffers> GetActiveOffersAsync(ulong? offset = null,
																		ulong? count = null,
																		CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.getActiveOffers",
					new VkParameters
					{
						{ "offset", offset },
						{ "count", count }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> BanUserAsync(long userId, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.banUser",
					new VkParameters
					{
						{ "user_id", userId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> UnbanUserAsync(long userId, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.unbanUser",
					new VkParameters
					{
						{ "user_id", userId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public Task<AccountGetBannedResult> GetBannedAsync(int? offset = null,
															int? count = null,
															CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<AccountGetBannedResult>("account.getBanned",
				new VkParameters
				{
					{ "offset", offset },
					{ "count", count }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<AccountInfo> GetInfoAsync(AccountFields fields = null, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.getInfo",
					new VkParameters
					{
						{ "fields", fields }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<bool> SetInfoAsync(string name, string value, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("account.setInfo",
					new VkParameters
					{
						{ "name", name },
						{ "value", value }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public Task<AccountChangePasswordResult> ChangePasswordAsync(string oldPassword,
																	string newPassword,
																	string restoreSid = null,
																	string changePasswordHash = null,
																	CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<AccountChangePasswordResult>("account.changePassword",
				new VkParameters
				{
					{ "restore_sid", restoreSid },
					{ "change_password_hash", changePasswordHash },
					{ "old_password", oldPassword },
					{ "new_password", newPassword }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<AccountSaveProfileInfoParams> GetProfileInfoAsync(CancellationToken cancellationToken = default)
		{
			User user = await _vk.CallAsync("account.getProfileInfo",
					VkParameters.Empty,
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);

			return new AccountSaveProfileInfoParams
			{
				City = user.City,
				Country = user.Country,
				BirthDate = user.BirthDate,
				BirthdayVisibility = user.BirthdayVisibility,
				FirstName = user.FirstName,
				LastName = user.LastName,
				HomeTown = user.HomeTown,
				MaidenName = user.MaidenName,
				Relation = user.Relation,
				Sex = user.Sex,
				RelationPartner = user.RelationPartner,
				ScreenName = user.ScreenName,
				Status = user.Status,
				Phone = user.MobilePhone
			};
		}

		/// <inheritdoc />
		public async Task<bool> SaveProfileInfoAsync(int cancelRequestId, CancellationToken cancellationToken = default)
		{
			var result = await _vk.CallAsync("account.saveProfileInfo",
					new VkParameters
					{
						{ "cancel_request_id", cancelRequestId }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);

			return result["changed"];
		}

		/// <inheritdoc />
		public async Task<bool> SaveProfileInfoAsync(AccountSaveProfileInfoParams @params, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("account.saveProfileInfo",
					@params,
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);

			return response["changed"];
		}
	}
}