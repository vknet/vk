using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ссылка на Web-страницу.
/// См. описание http://vk.com/dev/attachments_w
/// </summary>
[DebuggerDisplay("[{Title}] {Uri}")]
[Serializable]
public class Link : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "link";

	private long? _id;
	/// <summary>
	/// Возвращает идентификатор Link в числовом значении
	/// </summary>
	public new long? Id
	{
		get {
			if (long.TryParse(LinkId, out var temporaryId))
			{
				_id = temporaryId;
			}
			return _id;
		}
		set => _id = value;
	}

	/// <summary>
	/// Идентификатор ссылки
	/// </summary>
	[JsonProperty("id")]
	public string LinkId { get; set; }

	/// <summary>
	/// Адрес ссылки.
	/// </summary>
	[JsonProperty("url")]
	public Uri Uri { get; set; }

	/// <summary>
	/// Заголовок ссылки.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Подпись ссылки (если имеется).
	/// </summary>
	[JsonProperty("caption")]
	public string Caption { get; set; }

	/// <summary>
	/// Описание ссылки.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("desc")]
	private string Desc
	{
		get => Description;
		set => Description = value;
	}

	/// <summary>
	/// Фото (если имеется).
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Продукт.
	/// </summary>
	[JsonProperty("product")]
	public Market Product { get; set; }

	/// <summary>
	/// Кнопка.
	/// </summary>
	[JsonProperty("button")]
	public LinkButton Button { get; set; }

	/// <summary>
	/// Идентификатр wiki страницы с контентом для предпросмотра содержимого страницы.
	/// Идентификатор возвращается в формате
	/// <c>"owner_id_page_id"</c>.
	/// </summary>
	[JsonProperty("preview_page")]
	public string PreviewPage { get; set; }

	/// <summary>
	/// Адрес страницы для предпросмотра содержимого страницы.
	/// </summary>
	[JsonProperty("preview_url")]
	public Uri PreviewUrl { get; set; }

	/// <summary>
	/// Адрес превью изображения к ссылке (если имеется).
	/// </summary>
	[JsonProperty("image_src")]
	public string Image { get; set; }

	/// <summary>
	/// Является ли ссылкой на внешний ресурс (если имеется).
	/// </summary>
	[JsonProperty("is_external")]
	public bool? IsExternal { get; set; }

	/// <summary>
	/// Рейтинг.
	/// </summary>
	[JsonProperty("rating")]
	public Rating Rating { get; set; }

	/// <summary>
	/// Приложение.
	/// </summary>
	[JsonProperty("application")]
	public Application Application { get; set; }

	/// <summary>
	/// Преобразовать к строке.
	/// </summary>
	/// <returns>
	/// Адрес ссылки.
	/// </returns>
	public override string ToString() => Uri.ToString();
}