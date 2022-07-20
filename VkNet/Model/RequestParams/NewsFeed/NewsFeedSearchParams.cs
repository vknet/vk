using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.search
	/// </summary>
	[Serializable]
	public class NewsFeedSearchParams
	{
		/// <summary>
		/// Поисковой запрос.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Указывается 1, если необходимо получить информацию о пользователе или группе,
		/// разместившей запись.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Указывает, какое максимальное число записей следует возвращать.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Географическая широта точки, в радиусе от которой необходимо производить поиск,
		/// заданная в градусах (от -90 до 90).
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота точки, в радиусе от которой необходимо производить
		/// поиск, заданная в градусах (от -180 до
		/// 180).
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для
		/// текущего пользователя. Если параметр не
		/// задан, то он считается равным значению времени, которое было сутки назад.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего
		/// пользователя. Если параметр не задан,
		/// то он считается равным текущему времени.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов.
		/// Значение, необходимое для передачи в этом
		/// параметре, возвращается в поле ответа next_from.
		/// </summary>
		public string StartFrom { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. Игнорируется
		/// при отсутствии параметра extended=1.
		/// </summary>
		public UsersFields Fields { get; set; }
	}
}