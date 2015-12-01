using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkNet.Model.RequestParams.Messages
{
    /// <summary>
    /// Список параметров для метода Message.GetHistory
    /// <seealso cref="http://vk.com/dev/messages.getHistory"/>
    /// </summary>
    public class HistoryGetParams
    {
        /// <summary>
        /// Идентификатор пользователя, историю переписки с которым необходимо вернуть.
        /// </summary>
        public long? UserID { get; set; }

        /// <summary>
        /// Идентификатор диалога, историю сообщений которого необходимо получить.
        /// </summary>
        public ulong? ChatID { get; set; } = null;

        /// <summary>
        /// Идентификатор назначения.
        /// </summary>
        public long? PeerID { get; set; } = null;

        /// <summary>
        /// Количество сообщений, которое необходимо получить (но не более 200)
        /// </summary>
        public uint Count { get; set; } = 20;

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества сообщений,
        /// должен быть 0 или положительным, если не передан параметр start_message_id, и должен быть 0 или отрицательным, если передан.
        /// </summary>
        public long? Offset { get; set; } = 0;

        /// <summary>
        /// Если значение > 0, то это идентификатор сообщения, начиная с которого нужно вернуть историю переписки,
        /// если же передано значение -1, то к значению параметра offset прибавляется количество входящих непрочитанных сообщений в конце диалога
        /// </summary>
        public long? StartMessageID { get; set; } = null;

        /// <summary>
        /// Возвращать сообщения в хронологическом порядке или обратном (по умолчанию в обратном). Недоступен при переданном start_message_id.
        /// </summary>
        public bool? Reversed { get; set; } = null;
    }
}
