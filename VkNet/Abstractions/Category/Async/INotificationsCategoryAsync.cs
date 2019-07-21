using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с Уведомлениями.
	/// </summary>
	public interface INotificationsCategoryAsync
	{
		/// <summary>
		/// Возвращает список оповещений об ответах других пользователей на записи текущего
		/// пользователя.
		/// </summary>
		/// <param name="count">
		/// Указывает, какое максимальное число оповещений следует возвращать.
		/// положительное число, по умолчанию 30,
		/// максимальное значение 100
		/// </param>
		/// <param name="startFrom">
		/// Строковый идентификатор оповещения, полученного последним в предыдущем вызове
		/// (см. описание поля next_from в
		/// результате). строка, доступен начиная с версии 5.27
		/// </param>
		/// <param name="filters">
		/// Перечисленные через запятую типы оповещений, которые необходимо получить.
		/// Возможные значения:
		/// wall — записи на стене пользователя;
		/// mentions — упоминания в записях на стене, в комментариях или в обсуждениях;
		/// comments — комментарии к записям на стене, фотографиям и видеозаписям;
		/// likes — отметки «Мне нравится»;
		/// reposts — скопированные у текущего пользователя записи на стене, фотографии и
		/// видеозаписи;
		/// followers — новые подписчики;
		/// friends — принятые заявки в друзья.
		/// Если параметр не задан, то будут получены все возможные типы оповещений. список
		/// слов, разделенных через запятую
		/// </param>
		/// <param name="startTime">
		/// Время в формате Unixtime, начиная с которого следует получить оповещения для
		/// текущего пользователя. Если параметр
		/// не задан, то он считается равным значению времени, которое было сутки назад.
		/// целое число
		/// </param>
		/// <param name="endTime">
		/// Время в формате Unixtime, до которого следует получить оповещения для текущего
		/// пользователя. Если параметр не
		/// задан, то он считается равным текущему времени. целое число
		/// </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Массив объектов <see cref="NotificationGetResult"/>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
		/// </remarks>
		Task<IEnumerable<NotificationGetResult>> GetAsync(ulong? count = null,
														string startFrom = null,
														IEnumerable<string> filters = null,
														long? startTime = null,
														long? endTime = null,
														CancellationToken cancellationToken = default);

		/// <summary>
		/// Сбрасывает счетчик непросмотренных оповещений об ответах других пользователей
		/// на записи текущего пользователя.
		/// </summary>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Если у пользователя присутствовали непросмотренные ответы, возвращает 1 в
		/// случае успешного завершения. В противном
		/// случае возвращает 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.markAsViewed
		/// </remarks>
		Task<bool> MarkAsViewedAsync(CancellationToken cancellationToken = default);
	}
}