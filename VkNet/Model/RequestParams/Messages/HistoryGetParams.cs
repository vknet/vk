namespace VkNet.Model.RequestParams
{
    using Utils;

    /// <summary>
    /// Список параметров для метода Message.GetHistory
    /// <seealso cref="http://vk.com/dev/messages.getHistory"/>
    /// </summary>
    public struct HistoryGetParams
    {
        /// <summary>
        /// Идентификатор пользователя, историю переписки с которым необходимо вернуть.
        /// </summary>
        public long? UserID { get; set; }

        /// <summary>
        /// Идентификатор диалога, историю сообщений которого необходимо получить.
        /// </summary>
        public ulong? ChatID { get; set; }

        /// <summary>
        /// Идентификатор назначения.
        /// </summary>
        public long? PeerID { get; set; }

        /// <summary>
        /// Количество сообщений, которое необходимо получить (но не более 200)
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества сообщений,
        /// должен быть 0 или положительным, если не передан параметр start_message_id, и должен быть 0 или отрицательным, если передан.
        /// </summary>
        public long? Offset { get; set; }

        /// <summary>
        /// Если значение > 0, то это идентификатор сообщения, начиная с которого нужно вернуть историю переписки,
        /// если же передано значение -1, то к значению параметра offset прибавляется количество входящих непрочитанных сообщений в конце диалога
        /// </summary>
        public long? StartMessageID { get; set; }

        /// <summary>
        /// Возвращать сообщения в хронологическом порядке или обратном (по умолчанию в обратном). Недоступен при переданном start_message_id.
        /// </summary>
        public bool? Reversed { get; set; }

        internal static VkParameters ToVkParameters(HistoryGetParams p)
        {
            return new VkParameters
            {
                { "offset", p.Offset },
                { "count", p.Count },
                { "user_id", p.UserID },
                { "chat_id", p.ChatID },
                { "peer_id", p.PeerID },
                { "start_message_id", p.StartMessageID },
                { "rev", p.Reversed }
            };
        }
    }
}
