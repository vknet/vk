using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class SecureCategory
{
	/// <inheritdoc />
	public Task<bool> AddAppEventAsync(ulong userId, ulong activityId, ulong? value = null) =>
		TypeHelper.TryInvokeMethodAsync(() => AddAppEvent(userId, activityId, value));

	/// <inheritdoc />
	public Task<CheckTokenResult> CheckTokenAsync(string token, string ip = null) =>
		TypeHelper.TryInvokeMethodAsync(() => CheckToken(token, ip));

	/// <inheritdoc />
	public Task<ulong> GetAppBalanceAsync() => TypeHelper.TryInvokeMethodAsync(GetAppBalance);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<SmsHistoryItem>> GetSmsHistoryAsync(ulong? userId = null, DateTime? dateFrom = null,
																		DateTime? dateTo = null,
																		ulong? limit = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetSmsHistory(userId, dateFrom, dateTo, limit));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Transaction>> GetTransactionsHistoryAsync() => TypeHelper.TryInvokeMethodAsync(GetTransactionsHistory);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<SecureLevel>> GetUserLevelAsync(IEnumerable<long> userIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetUserLevel(userIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<EventSticker>> GiveEventStickerAsync(IEnumerable<ulong> userIds, ulong achievementId) =>
		TypeHelper.TryInvokeMethodAsync(() => GiveEventSticker(userIds, achievementId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<ulong>> SendNotificationAsync(string message, IEnumerable<ulong> userIds = null) =>
		TypeHelper.TryInvokeMethodAsync(() => SendNotification(message, userIds));

	/// <inheritdoc />
	public Task<bool> SendSmsNotificationAsync(ulong userId, string message) =>
		TypeHelper.TryInvokeMethodAsync(() => SendSmsNotification(userId, message));

	/// <inheritdoc />
	public Task<bool> SetCounterAsync(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null) =>
		TypeHelper.TryInvokeMethodAsync(() => SetCounter(counters, userId, counter, increment));
}