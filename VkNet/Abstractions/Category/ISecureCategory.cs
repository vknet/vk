using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category;

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

		/// <summary>
		/// Позволяет проверять валидность пользователя в IFrame, Flash  и Standalone-приложениях с помощью передаваемого в приложения параметра access_token.
		/// </summary>
		/// <param name = "token">
		/// Клиентский access_token строка
		/// </param>
		/// <param name = "ip">
		/// Ip адрес пользователя. Обратите внимание, что пользователь может обращаться через ipv6, в этом случае обязательно передавать ipv6 адрес пользователя.
		/// Если параметр не передан – ip адрес проверен не будет. строка
		/// </param>
		/// <returns>
		/// В случае успеха будет возвращен объект, содержащий следующие поля:
		/// success = 1
		/// user_id = идентификатор пользователя
		/// date = unixtime дата, когда access_token был сгенерирован
		/// expire = unixtime дата, когда access_token станет не валиден
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.checkToken
		/// </remarks>
		object CheckToken(string token, string ip);

		/// <summary>
		/// Возвращает платежный баланс (счет) приложения в сотых долях голоса.
		/// </summary>
		/// <returns>
		/// Возвращает количество голосов (в сотых долях), которые есть на счете приложения.
		/// Например, если метод возвращает 5000, это означает, что на балансе приложения 50 голосов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.getAppBalance
		/// </remarks>
		object GetAppBalance();

		/// <summary>
		/// Выводит список SMS-уведомлений, отосланных приложением с помощью метода secure.sendSMSNotification.
		/// </summary>
		/// <param name = "userId">
		/// Фильтр по id пользователя, которому высылалось уведомление. положительное число
		/// </param>
		/// <param name = "dateFrom">
		/// Фильтр по дате начала. Задается в виде UNIX-time. положительное число
		/// </param>
		/// <param name = "dateTo">
		/// Фильтр по дате окончания. Задается в виде UNIX-time. положительное число
		/// </param>
		/// <param name = "limit">
		/// Количество возвращаемых записей. По умолчанию 1000. положительное число, по умолчанию 1000, максимальное значение 1000
		/// </param>
		/// <returns>
		/// Возвращает список SMS-уведомлений, отосланных приложением, отсортированных по убыванию даты и отфильтрованных с помощью параметров uid, date_from, date_to, limit.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.getSMSHistory
		/// </remarks>
		IEnumerable<object> GetSmsHistory(ulong? userId = null, ulong? dateFrom = null, ulong? dateTo = null, ulong? limit = null);

		/// <summary>
		/// Выводит историю транзакций по переводу голосов между пользователями и приложением.
		/// </summary>
		/// <returns>
		/// Возвращает список транзакций, отсортированных по убыванию даты, и отфильтрованных с помощью параметров type, uid_from, uid_to, date_from, date_to, limit.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.getTransactionsHistory
		/// </remarks>
		IEnumerable<object> GetTransactionsHistory();

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
		object GetUserLevel(IEnumerable<long> userIds);

		/// <inheritdoc cref="ISecureCategoryAsync.SendNotificationAsync"/>
		ReadOnlyCollection<ulong> SendNotification(string message, IEnumerable<ulong> userIds = null);

		/// <inheritdoc cref="ISecureCategoryAsync.SendSmsNotificationAsync"/>
		bool SendSmsNotification(ulong userId, string message);

		/// <summary>
		/// Устанавливает счетчик, который выводится пользователю жирным шрифтом в левом меню.
		/// </summary>
		/// <param name = "counters">
		/// Позволяет устанавливать счетчики нескольким пользователям за один запрос. Значение следует указывать в следующем формате: user_id1:counter1[:increment],user_id2:counter2[:increment], пример: 66748:6:1,6492:2. В случае, если указан этот параметр, параметры counter, user_id и increment не учитываются. Можно передать не более 200 значений за один запрос. список слов, разделенных через запятую
		/// </param>
		/// <param name = "userId">
		/// Идентификатор пользователя. положительное число
		/// </param>
		/// <param name = "counter">
		/// Значение счетчика. целое число
		/// </param>
		/// <param name = "increment">
		/// Определяет, нужно ли заменить значение счетчика или прибавить новое значение к уже имеющемуся. 1 — прибавить counter к старому значению, 0 — заменить счетчик (по умолчанию). флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// Возвращает 1 в случае успешной установки счетчика.
		/// Если пользователь не установил приложение в левое меню, метод вернет ошибку 148 (Access to the menu of the user denied). Избежать этой ошибки можно с помощью метода account.getAppPermissions.
		/// Вы также можете обращаться к этому методу при стандартном взаимодействии с клиентской стороны, указывая setCounter вместо secure.setCounter в названии метода. В этом случае параметр uid передавать не нужно, счетчик установится для текущего пользователя.
		/// Метод setCounter при стандартном, а не защищенном взаимодействии можно использовать для того, чтобы, например, сбрасывать счетчик при заходе пользователя в приложение.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.setCounter
		/// </remarks>
		bool SetCounter(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null);

		/// <summary>
		/// Устанавливает игровой уровень пользователя в приложении, который смогут увидеть его друзья.
		/// </summary>
		/// <param name = "levels">
		/// Позволяет указывать уровни нескольким пользователям за один запрос. Значение следует указывать в следующем формате: user_id1:level1,user_id2:level2, пример: 66748:6,6492:2. В случае, если указан этот параметр, параметры level и user_id не учитываются. Метод принимает не более 200 значений за один запрос. список слов, разделенных через запятую
		/// </param>
		/// <param name = "userId">
		/// Идентификатор пользователя. положительное число
		/// </param>
		/// <param name = "level">
		/// Значение уровня. положительное число
		/// </param>
		/// <returns>
		/// Возвращает 1 в случае успешной установки уровня.
		/// Обратите внимание, при попытке установить уровень ниже текущего, ответ будет содержать сообщение об ошибке "Access denied: no activity from user for last 3 days", значение уровня изменено не будет.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/secure.setUserLevel
		/// </remarks>
		bool SetUserLevel(IEnumerable<string> levels, ulong? userId = null, ulong? level = null);
	}
}