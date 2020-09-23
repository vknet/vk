using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Список методов секции Streaming
	/// </summary>
	public interface IStreamingCategoryAsync
	{
		/// <summary>
		/// Позволяет получить данные для подключения к Streaming API.
		/// </summary>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// endpoint (string) — хост для подключения к серверу;
		/// key (string) — ключ доступа. Ключ бессрочный и прекращает действовать только
		/// после получения нового ключа.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/streaming.getServerUrl
		/// </remarks>
		Task<StreamingServerUrl> GetServerUrlAsync();

		/// <summary>
		/// Позволяет получить значение порога для Streaming API.
		/// </summary>
		/// <returns>
		/// Возвращает объект с единственным полем monthly_limit (string), которое содержит
		/// значение tier_1-tier_6 или
		/// unlimited и соответствует установленному порогу для приложения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/streaming.getSettings
		/// </remarks>
		Task<StreamingSettings> GetSettingsAsync();

		/// <summary>
		/// Позволяет получить статистику для подготовленных и доставленных событий
		/// Streaming API.
		/// </summary>
		/// <param name="type">
		/// Тип статистики. Возможные значения:
		/// received — события, полученные приложением;
		/// prepared — события, сгенерированные со стороны ВКонтакте.
		/// строка
		/// </param>
		/// <param name="interval">
		/// Интервалы статистики. Возможные значения:
		/// 5m — пять минут. Максимальный период — 3 дня между start_time и end_time;
		/// 1h — один час. Максимальный период — 7 дней между start_time и end_time;
		/// 24h — сутки. Максимальный период — 31 день между start_time и end_time.
		/// строка, по умолчанию 5m
		/// </param>
		/// <param name="startTime">
		/// Время начала отсчёта в Unixtime. По умолчанию: end_time минус сутки.
		/// положительное число
		/// </param>
		/// <param name="endTime">
		/// Время окончания отсчёта в Unixtime. По умолчанию: текущее время. положительное
		/// число
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, каждый из которых содержит поля:
		/// event_type (string) — тип событий. Возможные значения:
		/// post — записи на стене;
		/// comment — комментарии;
		/// share — репосты.
		/// stats (array) — значения статистики. Массив объектов, каждый из которых
		/// содержит оля:
		/// timestamp (integer) — время, соответствующее значению;
		/// value (integer) — значение.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/streaming.getStats
		/// </remarks>
		Task<ReadOnlyCollection<StreamingStats>> GetStatsAsync(string type
																, string interval
																, DateTime? startTime = null
																, DateTime? endTime = null);

		/// <summary>
		/// Позволяет задать значение порога для Streaming API.
		/// </summary>
		/// <param name="monthlyTier">
		/// Значение порога в месяц. Возможные значения:
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/streaming.setSettings
		/// </remarks>
		Task<bool> SetSettingsAsync(MonthlyLimit monthlyTier);

		/// <summary>
		/// Позволяет получить основу слова.
		/// </summary>
		/// <param name="word">слово, основу которого нужно получить</param>
		/// <returns>Основа слова</returns>
		Task<string> GetStemAsync(string word);
	}
}