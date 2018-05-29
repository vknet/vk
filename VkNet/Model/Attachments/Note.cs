using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Заметка пользователя.
	/// См. описание http://vk.com/dev/note
	/// </summary>
	[Serializable]
	public class Note : MediaAttachment
	{
		/// <summary>
		/// Заметка пользователя.
		/// </summary>
		static Note()
		{
			RegisterType(type: typeof(Note), match: "note");
		}

		/// <summary>
		/// Заголовок заметки.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст заметки.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Дата создания заметки.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Количество комментариев к заметке.
		/// </summary>
		public int? CommentsCount { get; set; }

		/// <summary>
		/// Количество прочитанных комментариев (только при запросе информации о заметке
		/// текущего пользователя).
		/// </summary>
		public int? ReadCommentsCount { get; set; }

		/// <summary>
		/// Адрес страницы для отображения заметки.
		/// </summary>
		public Uri ViewUrl { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Note FromJson(VkResponse response)
		{
			var note = new Note
			{
					Id = response[key: "id"]
					, OwnerId = response[key: "user_id"]
					, Title = response[key: "title"]
					, Text = response[key: "text"]
					, Date = response[key: "date"]
					, CommentsCount = response[key: "comments"]
					, ReadCommentsCount = response[key: "read_comments"]
					, ViewUrl = response[key: "view_url"]
			};

			return note;
		}

	#endregion
	}
}