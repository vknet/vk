using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения запроса получения диалогов
/// </summary>
[Serializable]
public class MessagesGetObject
{
	/// <summary>
	/// Общее число диалогов.
	/// Если Вы используете при вызове unread=true, то здесь будет содержаться
	/// количество непрочитанных диалогов
	/// </summary>
	[JsonProperty("count")]
	public uint TotalCount { get; set; }

	/// <summary>
	/// Количество непрочитанных диалогов.
	/// Если Вы используете при вызове unread=true, то это поле возвращено не будет
	/// </summary>
	[JsonProperty("unread")]
	public uint? Unread { get; set; }

	[JsonProperty("unread_dialogs")]
	private uint? UnreadDialogs
	{
		get => Unread;
		set => Unread = value;
	}

	/// <summary>
	/// Если был передан параметр start_message_id, будет содержать итоговое смещение
	/// данного подмножества диалогов
	/// (оно может быть отрицательным, если был указан отрицательный offset).
	/// </summary>
	[JsonProperty("real_offset")]
	public uint? RealOffset { get; set; }

	/// <summary>
	/// Диалоги
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<MessagesGetObjectItems> Messages { get; set; }

	/// <summary>
	/// Идентификатор последнего сообщения, прочитанного текущим пользователем
	/// </summary>
	[JsonProperty("in_read")]
	public uint? InRead { get; set; }

	/// <summary>
	/// Идентификатор последнего сообщения, прочитанного собеседником.
	/// </summary>
	[JsonProperty("out_read")]
	public uint? OutRead { get; set; }
}

/// <summary>
/// MessagesGetObject`s Items
/// </summary>
[Serializable]
public class MessagesGetObjectItems : Message
{
	/// <summary>
	/// Сообщение
	/// </summary>
	[JsonProperty("message")]
	public Message Message { get; set; }
}