using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

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
	public ReadOnlyCollection<Message> Messages { get; set; }

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Объект типа MessagesGetObject </returns>
	public static MessagesGetObject FromJson(VkResponse response)
	{
		var dialogsGetObject = new MessagesGetObject
		{
			TotalCount = response[key: "count"],
			Unread = response[key: "unread"] ?? response[key: "unread_dialogs"],
			RealOffset = response[key: "real_offset"],
			Messages = response[key: "items"]
				.ToReadOnlyCollectionOf<Message>(selector: m => m),
			InRead = response[key: "in_read"],
			OutRead = response[key: "out_read"]
		};

		return dialogsGetObject;
	}
}