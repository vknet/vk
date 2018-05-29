using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	[Serializable]
	public class NewsFeedGetCommentsParams
	{
		/// <summary>
		/// Перечисленные через запятую названия списков новостей, которые необходимо
		/// получить. В данный момент поддерживаются
		/// следующие списки новостей: post — новые записи со стен photo — новые фотографии
		/// photo_tag — новые отметки на
		/// фотографиях wall_photo — новые фотографии на стенах friend — новые друзья note
		/// — новые заметки Если параметр не
		/// задан, то будут получены все возможные списки новостей.
		/// </summary>
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
		/// Количество комментариев к записям, которые нужно получить.
		/// </summary>
		public long? LastCommentsCount { get; set; }

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
		public static VkParameters ToVkParameters(NewsFeedGetCommentsParams p)
		{
			var parameters = new VkParameters
			{
					{ "count", p.Count }
					, { "filters", p.Filters }
					, { "reposts", p.Reposts }
					, { "start_time", p.StartTime }
					, { "end_time", p.EndTime }
					, { "last_comments_count", p.LastCommentsCount }
					, { "start_from", p.StartFrom }
					, { "fields", p.Fields }
			};

			return parameters;
		}
	}
}