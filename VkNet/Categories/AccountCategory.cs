using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AccountCategory : IAccountCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> API. </param>
	public AccountCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public Counters GetCounters(CountersFilter filter) => _vk.Call<Counters>("account.getCounters",
		new()
		{
			{
				"filter", filter
			}
		});

	/// <inheritdoc />
	public bool SetNameInMenu(string name, long userId)
	{
		VkErrors.ThrowIfNullOrEmpty(() => name);

		var parameters = new VkParameters
		{
			{
				"name", name
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call<bool>("account.setNameInMenu", parameters);
	}

	/// <inheritdoc />
	public bool SetOnline(bool? voip = null)
	{
		var parameters = new VkParameters
		{
			{
				"voip", voip
			}
		};

		return _vk.Call<bool>("account.setOnline", parameters);
	}

	/// <inheritdoc />
	public bool SetOffline() => _vk.Call<bool>("account.setOffline", VkParameters.Empty);

	/// <inheritdoc />
	public bool RegisterDevice(AccountRegisterDeviceParams @params)
	{
		VkErrors.ThrowIfNullOrEmpty(() => @params.Token);

		return _vk.Call<bool>("account.registerDevice",
			new()
			{
				{
					"token", @params.Token
				},
				{
					"device_model", @params.DeviceModel
				},
				{
					"device_year", @params.DeviceYear
				},
				{
					"device_id", @params.DeviceId
				},
				{
					"system_version", @params.SystemVersion
				},
				{
					"settings", JsonConvert.SerializeObject(@params.Settings)
				},
				{
					"sandbox", @params.Sandbox
				}
			});
	}

	/// <inheritdoc />
	public bool UnregisterDevice(string deviceId, bool? sandbox = null)
	{
		VkErrors.ThrowIfNullOrEmpty(() => deviceId);

		var parameters = new VkParameters
		{
			{
				"device_id", deviceId
			},
			{
				"sandbox", sandbox
			}
		};

		return _vk.Call<bool>("account.unregisterDevice", parameters);
	}

	/// <inheritdoc />
	public bool SetSilenceMode(string deviceId, int? time = null, int? peerId = null, bool? sound = null)
	{
		VkErrors.ThrowIfNullOrEmpty(() => deviceId);

		var parameters = new VkParameters
		{
			{
				"device_id", deviceId
			},
			{
				"time", time
			},
			{
				"peer_id", peerId
			},
			{
				"sound", sound
			}
		};

		return _vk.Call<bool>("account.setSilenceMode", parameters);
	}

	/// <inheritdoc />
	public AccountPushSettings GetPushSettings(string deviceId)
	{
		var parameters = new VkParameters
		{
			{
				"device_id", deviceId
			}
		};

		return _vk.Call<AccountPushSettings>("account.getPushSettings", parameters);

	}

	/// <inheritdoc />
	public bool SetPushSettings(string deviceId, PushSettings settings, string key, List<string> value)
	{
		var parameters = new VkParameters
		{
			{
				"device_id", deviceId
			},
			{
				"settings", settings
			},
			{
				"key", key
			},
			{
				"value", value
			}
		};

		return _vk.Call<bool>("account.setPushSettings", parameters);
	}

	/// <inheritdoc />
	public long GetAppPermissions(long userId)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		return _vk.Call<long>("account.getAppPermissions", parameters);
	}

	/// <inheritdoc />
	public InformationAboutOffers GetActiveOffers(ulong? offset = null, ulong? count = null)
	{
		var parameters = new VkParameters
		{
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<InformationAboutOffers>("account.getActiveOffers", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.BanUser)]
	public bool BanUser(long ownerId) => Ban(ownerId);

	/// <inheritdoc />
	public bool Ban(long ownerId)
	{
		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			}
		};

		return _vk.Call<bool>("account.ban", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.UnbanUser)]
	public bool UnbanUser(long ownerId) => Unban(ownerId);

	/// <inheritdoc />
	public bool Unban(long ownerId)
	{
		var parameters = new VkParameters
		{
			{
				"owner_id", ownerId
			}
		};

		return _vk.Call<bool>("account.unban", parameters);
	}

	/// <inheritdoc />
	public AccountGetBannedResult GetBanned(int? offset = null, int? count = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => offset);
		VkErrors.ThrowIfNumberIsNegative(() => count);

		var parameters = new VkParameters
		{
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<AccountGetBannedResult>("account.getBanned", parameters);
	}

	/// <inheritdoc />
	public AccountInfo GetInfo(AccountFields fields = null) => _vk.Call<AccountInfo>("account.getInfo",
		new()
		{
			{
				"fields", fields
			}
		});

	/// <inheritdoc />
	public bool SetInfo(string name, string value)
	{
		var parameters = new VkParameters
		{
			{
				"name", name
			},
			{
				"value", value
			}
		};

		return _vk.Call<bool>("account.setInfo", parameters);
	}

	/// <inheritdoc />
	public AccountChangePasswordResult ChangePassword(string oldPassword, string newPassword, string restoreSid = null,
													string changePasswordHash = null)
	{
		var parameters = new VkParameters
		{
			{
				"restore_sid", restoreSid
			},
			{
				"change_password_hash", changePasswordHash
			},
			{
				"old_password", oldPassword
			},
			{
				"new_password", newPassword
			}
		};

		return _vk.Call<AccountChangePasswordResult>("account.changePassword", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public AccountSaveProfileInfoParams GetProfileInfo()
	{
		var user = _vk.Call<AccountSaveProfileInfoParams>("account.getProfileInfo", VkParameters.Empty);

		return new()
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
			Phone = user.Phone
		};
	}

	/// <inheritdoc />
	public ChangeNameRequest SaveProfileInfo(int cancelRequestId)
	{
		VkErrors.ThrowIfNumberIsNegative(() => cancelRequestId);

		return _vk.Call<ChangeNameRequest>("account.saveProfileInfo",
			new()
			{
				{
					"cancel_request_id", cancelRequestId
				}
			});
	}

	/// <inheritdoc />
	public ChangeNameRequest SaveProfileInfo(AccountSaveProfileInfoParams @params)
	{
		if (@params.RelationPartner != null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.RelationPartner.Id);
		}

		if (@params.Country != null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Country.Id);
		}

		if (@params.City != null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.City.Id);
		}

		return _vk.Call<ChangeNameRequest>("account.saveProfileInfo", new()
		{
			{
				"first_name", @params.FirstName
			},
			{
				"last_name", @params.LastName
			},
			{
				"maiden_name", @params.MaidenName
			},
			{
				"screen_name", @params.ScreenName
			},
			{
				"sex", @params.Sex
			},
			{
				"relation", @params.Relation
			},
			{
				"relation_partner_id", @params.RelationPartner?.Id
			},
			{
				"bdate", @params.BirthDate
			},
			{
				"bdate_visibility", @params.BirthdayVisibility
			},
			{
				"home_town", @params.HomeTown
			},
			{
				"country_id", @params.Country?.Id
			},
			{
				"city_id", @params.City?.Id
			},
			{
				"status", @params.Status
			},
			{
				"phone", @params.Phone
			}
		});
	}

	/// <inheritdoc />
	public PrivacySettings GetPrivacySettings() => _vk.Call<PrivacySettings>("account.getPrivacySettings", VkParameters.Empty);

	/// <inheritdoc />
	public PrivacySettingsValue SetPrivacy(PrivacyKey key, string value) => _vk.Call<PrivacySettingsValue>("account.setPrivacy",
		new()
		{
			{
				"key", key
			},
			{
				"value", value
			}
		});
}