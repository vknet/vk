using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
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
		public uint TotalCount { get; set; }

		/// <summary>
		/// Количество непрочитанных диалогов.
		/// Если Вы используете при вызове unread=true, то это поле возвращено не будет
		/// </summary>
		public uint? Unread { get; set; }

		/// <summary>
		/// Если был передан параметр start_message_id, будет содержать итоговое смещение
		/// данного подмножества диалогов
		/// (оно может быть отрицательным, если был указан отрицательный offset).
		/// </summary>
		public uint? RealOffset { get; set; }

		/// <summary>
		/// Диалоги
		/// </summary>
		public ReadOnlyCollection<Message> Messages { get; set; }

		/// <summary>
		/// Идентификатор последнего сообщения, прочитанного текущим пользователем
		/// </summary>
		public uint? InRead { get; set; }

		/// <summary>
		/// Идентификатор последнего сообщения, прочитанного собеседником.
		/// </summary>
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
					TotalCount = response[key: "count"]
					, Unread = response[key: "unread"] ?? response[key: "unread_dialogs"]
					, RealOffset = response[key: "real_offset"]
					, Messages = response[key: "items"].ToReadOnlyCollectionOf<Message>(selector: m => m)
					, InRead = response[key: "in_read"]
					, OutRead = response[key: "out_read"]
			};

			return dialogsGetObject;
		}
	}
}