using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода board.getTopics
	/// </summary>
	[Serializable]
	public class BoardGetCommentsParams
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
		/// Идентификатор обсуждения.Положительное число, обязательный параметр.
		/// </summary>
		[JsonProperty(propertyName: "topic_id")]
		public long TopicId { get; set; }

		/// <summary>
		/// 1 — возвращать информацию о лайках. флаг, может принимать значения 1 или 0.
		/// </summary>
		[JsonProperty(propertyName: "need_likes")]
		public bool? NeedLikes { get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности
		/// см. ниже). положительное число,
		/// доступен начиная с версии 5.33.
		/// </summary>
		[JsonProperty(propertyName: "start_comment_id")]
		public long? StartCommentId { get; set; }

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
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к
		/// старым) строка.
		/// </summary>
		[JsonProperty(propertyName: "sort")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public CommentsSort Sort { get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать текст комментария. Укажите 0,
		/// если Вы не хотите обрезатьтекст.
		/// положительное число.
		/// </summary>
		[JsonProperty(propertyName: "preview_length")]
		public long? PreviewLength { get; set; }

		/// <summary>
		/// 1 — комментарии в ответе будут возвращены в виде пронумерованных объектов,
		/// дополнительно будут возвращены списки
		/// объектов profiles, groups. флаг, может принимать значения 1 или 0, доступен
		/// начиная с версии 5.0.
		/// </summary>
		[JsonProperty(propertyName: "extended")]
		public bool? Extended { get; set; }
	}
}