using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	[Serializable]
	public class NewsFeedGetCommentsParams
	{
		/// <summary>
		/// Названия списков новостей, которые необходимо
		/// получить.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NewsTypes Filters { get; set; }

		/// <summary>
		/// Идентификатор объекта, комментарии к репостам которого необходимо вернуть,
		/// например wall1_45486.
		/// </summary>
		/// <remarks>
		/// Если указан данный параметр, параметр filters указывать необязательно.
		/// </remarks>
		public string Reposts { get; set; }

		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для
		/// текущего пользователя.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего
		/// пользователя. Если параметр не задан,
		/// то он считается равным текущему времени.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// Количество комментариев к записям, которые нужно получить.
		/// По умолчанию 0. Максимальное значение 10.
		/// </summary>
		public ushort? LastCommentsCount { get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов.
		/// Значение, необходимое для передачи в этом
		/// параметре, возвращается в поле ответа next_from.
		/// </summary>
		public long? StartFrom { get; set; }

		/// <summary>
		/// указывает, какое максимальное число новостей следует возвращать,
		/// но не более 100. По умолчанию 30.
		/// Для автоподгрузки Вы можете использовать возвращаемый данным методом параметр new_offset.
		/// </summary>
		public ushort? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей и сообществ, которые необходимо вернуть.
		/// </summary>
		public string Fields { get; set; }
	}
}