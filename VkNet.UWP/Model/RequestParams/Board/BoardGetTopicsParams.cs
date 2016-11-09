using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// Параметры метода board.getTopics
    /// </summary>
    public struct BoardGetTopicsParams
    {
		/// <summary>
		/// Параметры метода wall.getComments
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public BoardGetTopicsParams(bool gag = true)
		{
            GroupId = null;
            TopicIds = null;
            Order = 1;
			Offset = null;
			Count = null;
            Extended = false;
            Preview = null;
            PreviewLength = 90;
        }

		/// <summary>
		/// Идентификатор владельца страницы (пользователь или сообщество). Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? GroupId { get; set; }

        /// <summary>
        /// Cписок идентификаторов тем, которые необходимо получить (не более 100).
        /// </summary>
        public IEnumerable<long> TopicIds
        { get; set; }

        /// <summary>
        /// Порядок, в котором необходимо вернуть список тем.
        /// </summary>
        public int? Order { get; set; }

		/// <summary>
		/// Сдвиг, необходимый для получения конкретной выборки результатов. целое число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Число комментариев, которые необходимо получить. По умолчанию — 10, максимальное значение — 100. положительное число.
		/// </summary>
		public long? Count { get; set; }

        /// <summary>
        /// Если указать в качестве этого параметра 1, то будет возвращена информация о пользователях, являющихся создателями тем или оставившими в них последнее сообщение. По умолчанию 0.
        /// </summary>
        public bool? Extended { get; set; }

        /// <summary>
        /// Набор флагов, определяющий, необходимо ли вернуть вместе с информацией о темах текст первых и последних сообщений в них..
        /// </summary>
        public int? Preview { get; set; }

        /// <summary>
        /// Количество символов, по которому нужно обрезать первое и последнее сообщение. Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию — 90).
        /// </summary>
        public int? PreviewLength { get; set; }


        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>
        public static VkParameters ToVkParameters(BoardGetTopicsParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "topic_ids", p.TopicIds },
				{ "order", p.Order },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "extended", p.Extended },
                { "preview", p.Preview },
                { "preview_length", p.PreviewLength }
            };

			return parameters;
		}
	}
}