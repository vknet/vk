using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Stories
{
	[Serializable]
	public class StoriesSearchParams
	{
		/// <summary>
		/// Поисковый запрос. строка, максимальная длина 255
		/// </summary>
		[JsonProperty("q")]
		public string Query { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("fields")]
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Идентификатор места. положительное число
		/// </summary>
		[JsonProperty("place_id")]
		public ulong PlaceId { get; set; }

		/// <summary>
		/// Географическая широта точки, в радиусе которой необходимо производить поиск, заданная в градусах (от -90 до 90). дробное число
		/// </summary>
		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота точки, в радиусе которой необходимо производить поиск, заданная в градусах (от -180 до 180). дробное число
		/// </summary>
		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		/// <summary>
		/// Радиус зоны поиска в метрах. положительное число
		/// </summary>
		[JsonProperty("radius")]
		public ulong Radius { get; set; }

		/// <summary>
		/// Идентификатор упомянутого в истории пользователя или сообщества. целое число
		/// </summary>
		[JsonProperty("mentioned_id")]
		public long MentionedId { get; set; }

		/// <summary>
		/// Количество историй, информацию о которых необходимо вернуть. целое число, по умолчанию 20, минимальное значение 1, максимальное значение 1000
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Параметр, определяющий необходимость возвращать расширенную информацию о владельце истории. Возможные значения:
		/// 0 — возвращаются только идентификаторы;
		/// 1 — будут дополнительно возвращены имя и фамилия.
		/// По умолчанию: 0. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("extended")]
		public bool Extended { get; set; }
	}
}