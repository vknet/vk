using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ISecureCategory" />
public partial class SecureCategory : ISecureCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public SecureCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public bool AddAppEvent(ulong userId, ulong activityId, ulong? value = null) => _vk.Call<bool>("secure.addAppEvent",
		new()
		{
			{
				"user_id", userId
			},
			{
				"activity_id", activityId
			},
			{
				"value", value
			}
		});

	/// <inheritdoc />
	public CheckTokenResult CheckToken(string token, string ip = null) => _vk.Call<CheckTokenResult>("secure.checkToken",
		new()
		{
			{
				"token", token
			},
			{
				"ip", ip
			}
		});

	/// <inheritdoc />
	public ulong GetAppBalance() => _vk.Call<ulong>("secure.getAppBalance", VkParameters.Empty);

	/// <inheritdoc />
	public ReadOnlyCollection<SmsHistoryItem> GetSmsHistory(ulong? userId = null, DateTime? dateFrom = null, DateTime? dateTo = null,
															ulong? limit = null) => _vk.Call<ReadOnlyCollection<SmsHistoryItem>>(
		"secure.getSMSHistory",
		new()
		{
			{
				"user_id", userId
			},
			{
				"date_from", dateFrom
			},
			{
				"date_to", dateTo
			},
			{
				"limit", limit
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<Transaction> GetTransactionsHistory() =>
		_vk.Call<ReadOnlyCollection<Transaction>>("secure.getTransactionsHistory", VkParameters.Empty);

	/// <inheritdoc />
	public ReadOnlyCollection<SecureLevel> GetUserLevel(IEnumerable<long> userIds) => _vk.Call<ReadOnlyCollection<SecureLevel>>(
		"secure.getUserLevel",
		new()
		{
			{
				"user_ids", userIds
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<EventSticker> GiveEventSticker(IEnumerable<ulong> userIds, ulong achievementId) =>
		_vk.Call<ReadOnlyCollection<EventSticker>>("secure.giveEventSticker",
			new()
			{
				{
					"user_ids", userIds
				},
				{
					"achievement_id", achievementId
				}
			});

	/// <inheritdoc />
	public ReadOnlyCollection<ulong> SendNotification(string message, IEnumerable<ulong> userIds = null) =>
		_vk.Call<ReadOnlyCollection<ulong>>("secure.sendNotification",
			new()
			{
				{
					"message", message
				},
				{
					"user_ids", userIds
				}
			});

	/// <inheritdoc />
	public bool SendSmsNotification(ulong userId, string message) => _vk.Call<bool>("secure.sendSMSNotification",
		new()
		{
			{
				"user_id", userId
			},
			{
				"message", message
			}
		});

	/// <inheritdoc />
	public bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null) =>
		_vk.Call<bool>("secure.setCounter",
			new()
			{
				{
					"counters", counters
				},
				{
					"user_id", userId
				},
				{
					"counter", counter
				},
				{
					"increment", increment
				}
			});
}