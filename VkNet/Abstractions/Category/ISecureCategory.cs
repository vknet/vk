using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
	public interface ISecureCategory : ISecureCategoryAsync
	{
		/// <summary>
		/// Добавляет информацию о достижениях пользователя в приложении.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя, для которого нужно записать данные. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр
		/// </param>
		/// <param name = "activityId">
		/// Идентификатор достижения. Доступные значения:
		/// 1 — достигнут новый уровень, работает аналогично secure.setUserLevel;
		/// 2 — заработано новое число очков;
		/// положительное число, отличное от 1 и 2 — выполнена миссия с идентификатором activity_id.
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name = "value">
		/// Номер уровня или заработанное количество очков (соответственно, для activity_id=1 и activity_id=2).
		/// Параметр игнорируется при значении activity_id, отличном от 1 и 2. положительное число, максимальное значение 10000
		/// </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.addAppEvent
		/// </remarks>
		object AddAppEvent(ulong userId, ulong activityId, ulong? value = null);

		/// <inheritdoc cref="ISecureCategoryAsync.CheckTokenAsync"/>
		CheckTokenResult CheckToken(string token, string ip = null);

		/// <inheritdoc cref="ISecureCategoryAsync.GetAppBalanceAsync"/>
		ulong GetAppBalance();

		/// <inheritdoc cref="ISecureCategoryAsync.GetSmsHistoryAsync"/>
		ReadOnlyCollection<SmsHistoryItem> GetSmsHistory(ulong? userId = null, DateTime? dateFrom = null, DateTime? dateTo = null,
														ulong? limit = null);

		/// <inheritdoc cref="ISecureCategoryAsync.GetTransactionsHistoryAsync"/>
		ReadOnlyCollection<Transaction> GetTransactionsHistory();

		/// <summary>
		/// Возвращает ранее выставленный игровой уровень одного или нескольких пользователей в приложении.
		/// </summary>
		/// <param name = "userIds">
		/// Идентификаторы пользователей, информацию об уровнях которых требуется получить. список целых чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает значения игровых уровней пользователей в приложении.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.getUserLevel
		/// </remarks>
		ReadOnlyCollection<SecureLevel> GetUserLevel(IEnumerable<long> userIds);

		/// <inheritdoc cref="ISecureCategoryAsync.SendNotificationAsync"/>
		ReadOnlyCollection<ulong> SendNotification(string message, IEnumerable<ulong> userIds = null);

		/// <inheritdoc cref="ISecureCategoryAsync.SendSmsNotificationAsync"/>
		bool SendSmsNotification(ulong userId, string message);

		/// <inheritdoc cref="ISecureCategoryAsync.SetCounterAsync"/>
		bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null);
	}
}