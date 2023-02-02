using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ссылки в группе
/// </summary>
[Serializable]
public class ExternalLink
{
	/// <summary>
	/// Идентификатор ссылки.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public string Id { get; set; }

	/// <summary>
	/// Адрес ссылки.
	/// </summary>
	[JsonProperty(propertyName: "url")]
	public string Uri { get; set; }

	/// <summary>
	/// Название страницы, на которую ведет ссылка.
	/// </summary>
	[JsonProperty(propertyName: "name")]
	public string Name { get; set; }

	/// <summary>
	/// Описание.
	/// </summary>
	[JsonProperty(propertyName: "description")]
	public string Description { get; set; }

	/// <summary>
	/// Фото 50px.
	/// </summary>
	[JsonProperty(propertyName: "photo_50")]
	public string Photo50 { get; set; }

	/// <summary>
	/// Фото 100px.
	/// </summary>
	[JsonProperty(propertyName: "photo_100")]
	public string Photo100 { get; set; }

	/// <summary>
	/// Возвращается 1, если можно редактировать название ссылки (для внешних ссылок)
	/// </summary>
	[JsonProperty(propertyName: "edit_title")]
	public bool? EditTitle { get; set; }

	/// <summary>
	/// Возвращается 1, если превью находится в процессе обработки.
	/// </summary>
	[JsonProperty(propertyName: "image_processing")]
	public bool? ImageProcessing { get; set; }

	[JsonProperty("desc")]
	private string Desc
	{
		get => Description;
		set => Description = value;
	}

	[JsonProperty("title")]
	private string Title
	{
		get => Name;
		set => Name = value;
	}
}