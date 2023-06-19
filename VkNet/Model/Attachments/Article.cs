using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Статья
/// </summary>
[Serializable]
public class Article : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "article";

	/// <summary>
	/// Имя владельца
	/// </summary>
	[JsonProperty("owner_name")]
	public string OwnerName { get; set; }

	/// <summary>
	/// <c>Uri</c> к фотографии владельца
	/// </summary>
	[JsonProperty("owner_photo")]
	public Uri OwnerPhoto { get; set; }

	/// <summary>
	/// Состояние
	/// </summary>
	[JsonProperty("state")]
	public string State { get; set; }

	/// <summary>
	/// Можно ли пожаловаться на статью
	/// </summary>
	[JsonProperty("can_report")]
	public bool? CanReport { get; set; }

	/// <summary>
	/// Заголовок
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Подзаголовок
	/// </summary>
	[JsonProperty("subtitle")]
	public string Subtitle { get; set; }

	/// <summary>
	/// Количество показов
	/// </summary>
	[JsonProperty("views")]
	public int? Views { get; set; }

	/// <summary>
	/// Количество поделившихся
	/// </summary>
	[JsonProperty("shares")]
	public int? Shares { get; set; }

	/// <summary>
	/// Информация о том, есть ли статья в закладках у текущего пользователя
	/// </summary>
	[JsonProperty("is_favorite")]
	public bool? IsFavorite { get; set; }

	/// <summary>
	/// Ссылка на статью
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("view_url")]
	public Uri ViewUrl { get; set; }

	/// <summary>
	/// Дата публикации статьи
	/// </summary>
	[JsonProperty("published_date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? PublishedDate { get; set; }

	/// <summary>
	/// Обложка статьи
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }
}