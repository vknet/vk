using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Информация о документе.
/// См. описание http://vk.com/dev/doc
/// </summary>
[Serializable]
public class Document : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "doc";

	/// <summary>
	/// Название документа.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Размер документа в байтах.
	/// </summary>
	[JsonProperty("size")]
	public long? Size { get; set; }

	/// <summary>
	/// Расширение документа.
	/// </summary>
	[JsonProperty("ext")]
	public string Ext { get; set; }

	/// <summary>
	/// Адрес документа, по которому его можно загрузить.
	/// </summary>
	[JsonProperty("url")]
	public string Uri { get; set; }

	/// <summary>
	/// Дата добавления в формате unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Тип документа
	/// </summary>
	[JsonProperty("type")]
	public DocumentTypeEnum Type { get; set; }

	/// <summary>
	/// Информация для предварительного просмотра документа
	/// </summary>
	[JsonProperty("preview")]
	public DocumentPreview Preview { get; set; }

	/// <summary>
	/// Адрес изображения с размером 100x75px (если файл графический).
	/// </summary>
	[JsonProperty("photo_100")]
	public string Photo100 { get; set; }

	/// <summary>
	/// Адрес изображения с размером 130x100px (если файл графический).
	/// </summary>
	[JsonProperty("photo_130")]
	public string Photo130 { get; set; }

	[JsonProperty("did")]
	private long? Did
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("doc_id")]
	private long? DocId
	{
		get => Id;
		set => Id = value;
	}
}