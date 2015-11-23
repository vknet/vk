namespace VkNet.Model.RequestParams.Messages
{
    using VkNet.Enums;

    /// <summary>
    /// Список параметров для метода Messages.Get
    /// </summary>
    public class MessagesGetParams
    {
        /// <summary>
        /// Количество сообщений, которое необходимо получить. 
        /// (по умолчанию 20, максимальное значение 200)
        /// </summary>
        public uint Count { get; set; } = 20;

        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества сообщений
        /// </summary>
        public ulong? Offset { get; set; } = 0;

        /// <summary>
        /// Тип сообщений которые необходимо получить.
        /// Необходимо передать <see cref="MessageType.Received"/> для полученных сообщений и <see cref="MessageType.Sended"/>
        /// для отправленных пользователем сообщений. 
        /// </summary>
        public MessageType? Out { get; set; } = null;

        /// <summary>
        /// Максимальное время, прошедшее с момента отправки сообщения до текущего момента в секундах. 
        /// 0, если Вы хотите получить сообщения любой давности. 
        /// </summary>
        public ulong? TimeOffset { get; set; } = null;

        /// <summary>
        /// Фильтр возвращаемых сообщений.
        /// </summary>
        public MessagesFilter? Filters { get; set; } = null;

        /// <summary>
        /// Количество символов, по которому нужно обрезать сообщение. 
        /// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).
        /// </summary>
        public uint? PreviewLength { get; set; } = null;

        /// <summary>
        /// Идентификатор сообщения, полученного перед тем, которое нужно вернуть последним 
        /// (при условии, что после него было получено не более count сообщений, иначе необходимо использовать с параметром offset)
        /// </summary>
        public ulong? LastMessageId { get; set; } = null;
    }
}
