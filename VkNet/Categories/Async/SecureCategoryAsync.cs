using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class SecureCategory
{
	/// <inheritdoc />
	public Task<bool> AddAppEventAsync(ulong userId,
										ulong activityId,
										ulong? value = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAppEvent(userId, activityId, value));

	/// <inheritdoc />
	public Task<CheckTokenResult> CheckTokenAsync(string token, string ip = null,
										CancellationToken cancellationToken = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckToken(token, ip));

	/// <inheritdoc />
	public Task<ulong> GetAppBalanceAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetAppBalance);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<SmsHistoryItem>> GetSmsHistoryAsync(ulong? userId = null,
																		DateTime? dateFrom = null,
																		DateTime? dateTo = null,
																		ulong? limit = null,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSmsHistory(userId, dateFrom, dateTo, limit));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Transaction>> GetTransactionsHistoryAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetTransactionsHistory);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<SecureLevel>> GetUserLevelAsync(IEnumerable<long> userIds,
																	CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUserLevel(userIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<EventSticker>> GiveEventStickerAsync(IEnumerable<ulong> userIds,
																		ulong achievementId,
																		CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GiveEventSticker(userIds, achievementId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<ulong>> SendNotificationAsync(string message,
																IEnumerable<ulong> userIds = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendNotification(message, userIds));

	/// <inheritdoc />
	public Task<bool> SendSmsNotificationAsync(ulong userId,
												string message,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendSmsNotification(userId, message));

	/// <inheritdoc />
	public Task<bool> SetCounterAsync(IEnumerable<string> counters,
									ulong? userId = null,
									long? counter = null,
									bool? increment = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetCounter(counters, userId, counter, increment));
}