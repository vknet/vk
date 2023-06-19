using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

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
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Текст заметки.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Дата создания заметки.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Количество комментариев к заметке.
	/// </summary>
	[JsonProperty("comments")]
	public int? CommentsCount { get; set; }

	/// <summary>
	/// Количество прочитанных комментариев (только при запросе информации о заметке
	/// текущего пользователя).
	/// </summary>
	[JsonProperty("read_comments")]
	public int? ReadCommentsCount { get; set; }

	/// <summary>
	/// Адрес страницы для отображения заметки.
	/// </summary>
	[JsonProperty("view_url")]
	public Uri ViewUrl { get; set; }
}