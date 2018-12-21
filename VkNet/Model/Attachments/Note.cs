using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Заметка пользователя.
	/// </summary>
	/// <remarks>
	/// <a href="http://vk.com/dev/note">См. описание</a>
	/// </remarks>
	[Serializable]
	public class Note : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "note";

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
		[JsonConverter(typeof(UnixDateTimeConverter))]
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
			return new Note
			{
				Id = response["id"],
				OwnerId = response["user_id"],
				Title = response["title"],
				Text = response["text"],
				Date = response["date"],
				CommentsCount = response["comments"],
				ReadCommentsCount = response["read_comments"],
				ViewUrl = response["view_url"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Note" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Note" /></returns>
		public static implicit operator Note(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}