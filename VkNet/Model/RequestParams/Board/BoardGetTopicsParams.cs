using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода board.getTopics
	/// </summary>
	[Serializable]
	public class BoardGetTopicsParams
	{
		/// <summary>
		/// Идентификатор владельца страницы (пользователь или сообщество). Обратите
		/// внимание, идентификатор сообщества в
		/// параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору
		/// сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор
		/// текущего пользователя.
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public long? GroupId { get; set; }

		/// <summary>
		/// Cписок идентификаторов тем, которые необходимо получить (не более 100).
		/// </summary>
		[JsonProperty(propertyName: "topic_ids")]
		public IEnumerable<long> TopicIds { get; set; }

		/// <summary>
		/// Порядок, в котором необходимо вернуть список тем.
		/// </summary>
		[JsonProperty(propertyName: "order")]
		public int? Order { get; set; }

		/// <summary>
		/// Сдвиг, необходимый для получения конкретной выборки результатов. целое число.
		/// </summary>
		[JsonProperty(propertyName: "offset")]
		public long? Offset { get; set; }

		/// <summary>
		/// Число комментариев, которые необходимо получить. По умолчанию — 10,
		/// максимальное значение — 100. положительное
		/// число.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public long? Count { get; set; }

		/// <summary>
		/// Если указать в качестве этого параметра 1, то будет возвращена информация о
		/// пользователях, являющихся создателями
		/// тем или оставившими в них последнее сообщение. По умолчанию 0.
		/// </summary>
		[JsonProperty(propertyName: "extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Набор флагов, определяющий, необходимо ли вернуть вместе с информацией о темах
		/// текст первых и последних сообщений в
		/// них..
		/// </summary>
		[JsonProperty(propertyName: "preview")]
		public int? Preview { get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать первое и последнее сообщение.
		/// Укажите 0, если Вы не хотите обрезать
		/// сообщение. (по умолчанию — 90).
		/// </summary>
		[JsonProperty(propertyName: "preview_length")]
		public int? PreviewLength { get; set; }
	}
}