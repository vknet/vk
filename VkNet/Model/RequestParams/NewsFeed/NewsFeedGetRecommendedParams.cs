using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.getRecommended
	/// </summary>
	[Serializable]
	public class NewsFeedGetRecommendedParams
	{
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
		/// Максимальное количество фотографий, информацию о которых необходимо вернуть. По
		/// умолчанию 5.
		/// </summary>
		public uint? MaxPhotos { get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов.
		/// Значение, необходимое для передачи в этом
		/// параметре, возвращается в поле ответа next_from.
		/// </summary>
		public long? StartFrom { get; set; }

		/// <summary>
		/// Указывает, какое максимальное число новостей следует возвращать, но не более
		/// 100. По умолчанию 50.
		/// </summary>
		public ushort? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей и сообществ, которые необходимо вернуть.
		/// </summary>
		public string Fields { get; set; }
	}
}