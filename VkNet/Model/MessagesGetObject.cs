﻿namespace VkNet.Model
{
	using System.Collections.ObjectModel;

	using Utils;

	/// <summary>
	/// Результат выполнения запроса получения диалогов
	/// </summary>
	public class MessagesGetObject
	{
		/// <summary>
		/// Общее число диалогов.
		/// Если Вы используете при вызове unread=true, то здесь будет содержаться количество непрочитанных диалогов
		/// </summary>
		public uint TotalCount { get; set; }

		/// <summary>
		/// Количество непрочитанных диалогов.
		/// Если Вы используете при вызове unread=true, то это поле возвращено не будет
		/// </summary>
		public uint? Unread { get; set; }

		/// <summary>
		/// Если был передан параметр start_message_id, будет содержать итоговое смещение данного подмножества диалогов
		/// (оно может быть отрицательным, если был указан отрицательный offset).
		/// </summary>
		public uint? RealOffset { get; set; }

		/// <summary>
		/// Диалоги
		/// </summary>
		public ReadOnlyCollection<Message> Messages { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Объект типа <see cref="MessagesGetObject"/></returns>
		internal static MessagesGetObject FromJson(VkResponse response)
		{
			var dialogsGetObject = new MessagesGetObject
			{
				TotalCount = response["count"],
				Unread = response["unread_dialogs"],
				RealOffset = response["real_offset"],
				Messages = response["items"].ToReadOnlyCollectionOf<Message>(m => m)
			};

			return dialogsGetObject;
		}
	}
}
