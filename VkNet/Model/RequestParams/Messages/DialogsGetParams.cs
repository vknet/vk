namespace VkNet.Model.RequestParams
{
    using Utils;

    /// <summary>
    /// Список параметров для метода Messages.GetDialogs
    /// </summary>
    public struct DialogsGetParams
    {
        /// <summary>
        /// Количество диалогов, которое необходимо получить (не более 200)
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества диалогов.
        /// Если указан <see cref="StartMessageID"/> то может быть отрицательным
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Значение <c>true</c> означает, что нужно вернуть только диалоги в которых есть непрочитанные входящие сообщения. По умолчанию false.
        /// </summary>
        public bool Unread { get; set; }

        /// <summary>
        /// Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).
        /// </summary>
        public uint? PreviewLength { get; set; }

        /// <summary>
        /// Идентификатор сообщения, начиная с которого нужно вернуть список диалогов (подробности см. ниже).
		///
		/// Если был передан параметр <c>start_message_id</c>, будет найдена позиция диалога в списке,
		/// идентификатор последнего сообщения которого равен <c>start_message_id</c> (или ближайший к нему более ранний).
		/// Начиная с этой позиции будет возвращено <c>count</c> диалогов.
		/// Смещение <c>offset</c> в этом случае будет отсчитываться от этой позиции (оно может быть отрицательным).
        /// </summary>
        public long? StartMessageID { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(DialogsGetParams p)
        {
            return new VkParameters
            {
                { "start_message_id", p.StartMessageID },
                { "offset", p.Offset },
                { "count", p.Count },
                { "unread", p.Unread },
                { "preview_length", p.PreviewLength }
            };
        }
    }
}
