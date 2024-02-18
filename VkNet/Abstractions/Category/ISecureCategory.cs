using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Secure В этой секции представлены административные методы, предназначенные для вызова от имени приложения с использованием стороннего сервера. Для использования этих методов необходимо применять специальную схему авторизации. Помимо стандартных параметров, указанных в описании методов, к запросу необходимо добавлять параметр client_secret, содержащий значение из поля «Защищенный ключ» в настройках приложения. Обратите внимание, тестовый режим при работе с secure-методами не поддерживается!
/// </summary>
public interface ISecureCategory : ISecureCategoryAsync
{
	/// <inheritdoc cref="ISecureCategoryAsync.AddAppEventAsync" />
	bool AddAppEvent(ulong userId, ulong activityId, ulong? value = null);

	/// <inheritdoc cref="ISecureCategoryAsync.CheckTokenAsync" />
	CheckTokenResult CheckToken(string token, string ip = null);

	/// <inheritdoc cref="ISecureCategoryAsync.GetAppBalanceAsync" />
	ulong GetAppBalance();

	/// <inheritdoc cref="ISecureCategoryAsync.GetSmsHistoryAsync" />
	ReadOnlyCollection<SmsHistoryItem> GetSmsHistory(ulong? userId = null, DateTime? dateFrom = null, DateTime? dateTo = null,
													ulong? limit = null);

	/// <inheritdoc cref="ISecureCategoryAsync.GetTransactionsHistoryAsync" />
	ReadOnlyCollection<Transaction> GetTransactionsHistory();

	/// <inheritdoc cref="ISecureCategoryAsync.GetUserLevelAsync" />
	ReadOnlyCollection<SecureLevel> GetUserLevel(IEnumerable<long> userIds);

	/// <inheritdoc cref="ISecureCategoryAsync.GiveEventStickerAsync" />
	ReadOnlyCollection<EventSticker> GiveEventSticker(IEnumerable<ulong> userIds, ulong achievementId);

	/// <inheritdoc cref="ISecureCategoryAsync.SendNotificationAsync" />
	ReadOnlyCollection<ulong> SendNotification(string message, IEnumerable<ulong> userIds = null);

	/// <inheritdoc cref="ISecureCategoryAsync.SendSmsNotificationAsync" />
	bool SendSmsNotification(ulong userId, string message);

	/// <inheritdoc cref="ISecureCategoryAsync.SetCounterAsync" />
	bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null);
}