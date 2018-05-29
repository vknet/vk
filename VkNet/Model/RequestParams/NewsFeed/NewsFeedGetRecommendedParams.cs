using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	[Serializable]
	public class NewsFeedGetRecommendedParams
	{
		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для
		/// текущего пользователя.
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
		public long? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// </summary>
		public UsersFields Fields { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(NewsFeedGetRecommendedParams p)
		{
			var parameters = new VkParameters
			{
					{ "start_time", p.StartTime }
					, { "end_time", p.EndTime }
					, { "max_photos", p.MaxPhotos }
					, { "start_from", p.StartFrom }
					, { "count", p.Count }
					, { "fields", p.Fields }
			};

			return parameters;
		}
	}
}