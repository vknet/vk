using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.getComments
	/// </summary>
	[Serializable]
	public class VideoGetCommentsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание, идентификатор
		/// сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию
		/// идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи. положительное число, обязательный параметр.
		/// </summary>
		public long VideoId { get; set; }

		/// <summary>
		/// 1 — будет возвращено дополнительное поле likes. По умолчанию поле likes не
		/// возвращается. флаг, может принимать
		/// значения 1 или 0.
		/// </summary>
		public bool? NeedLikes { get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности
		/// см. ниже). положительное число,
		/// доступен начиная с версии 5.33.
		/// </summary>
		public long? StartCommentId { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. По
		/// умолчанию — 0. целое число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество комментариев, информацию о которых необходимо вернуть. положительное
		/// число, по умолчанию 20,
		/// максимальное значение 100.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc — от новых к
		/// старым) строка.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public CommentsSort Sort { get; set; }

		/// <summary>
		/// 1 — комментарии в ответе будут возвращены в виде пронумерованных объектов,
		/// дополнительно будут возвращены списки
		/// объектов profiles, groups. флаг, может принимать значения 1 или 0, доступен
		/// начиная с версии 5.0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Дополнительные поля для пользователя
		/// </summary>
		public ProfileFields Fields { get; set; }
	}
}