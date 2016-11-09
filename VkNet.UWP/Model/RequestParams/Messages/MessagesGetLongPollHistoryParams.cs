using VkNet.Enums.Filters;

namespace VkNet.Model.RequestParams
{
    using Utils;

	/// <summary>
	/// Параметры метода messages.getLongPollHistoryParams
	/// </summary>
	public struct MessagesGetLongPollHistoryParams
	{
		/// <summary>
		/// Последнее значение параметра ts, полученное от Long Poll сервера или с помощью метода messages.getLongPollServer
		/// </summary>
		public ulong Ts
		{ get; set; }

		/// <summary>
		/// Последнее значение параметра new_pts, полученное от Long Poll сервера, используется для получения действий, которые хранятся всегда.
		/// </summary>
		public ulong? Pts
		{ get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать сообщение. Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).
		/// </summary>
		public long? PreviewLength
		{ get; set; }

		/// <summary>
		/// При передаче в этот параметра значения 1 будет возвращена история только от тех пользователей, которые сейчас online. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Onlines
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

		/// <summary>
		/// Если количество событий в истории превысит это значение, будет возвращена ошибка.
		/// </summary>
		public long? EventsLimit
		{ get; set; }

		/// <summary>
		/// Количество сообщений, которое нужно вернуть.
		/// </summary>
		public long? MsgsLimit
		{ get; set; }

		/// <summary>
		/// Максимальный идентификатор сообщения среди уже имеющихся в локальной копии. Необходимо учитывать как сообщения, полученные через методы API (например messages.getDialogs, messages.getHistory), так и данные, полученные из Long Poll сервера (события с кодом 4).
		/// </summary>
		public long? MaxMsgId
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		public static VkParameters ToVkParameters(MessagesGetLongPollHistoryParams p)
        {
            return new VkParameters
            {
                { "ts", p.Ts },
                { "pts", p.Pts },
                { "preview_length", p.PreviewLength },
                { "onlines", p.Onlines },
                { "fields", p.Fields },
                { "events_limit", p.EventsLimit },
                { "msgs_limit", p.MsgsLimit },
                { "max_msg_id", p.MaxMsgId }
            };
        }
    }
}