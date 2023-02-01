using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Версия страницы
/// </summary>
[Serializable]
public class PageVersion
{
	/// <summary>
	/// идентификатор версии страницы;
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public string Id { get; set; }

	/// <summary>
	/// длина версии страницы в байтах;
	/// </summary>
	[JsonProperty(propertyName: "length")]
	public string Length { get; set; }

	/// <summary>
	/// дата редактирования страницы;
	/// </summary>
	[JsonProperty(propertyName: "edited")]
	public string Edited { get; set; }

	/// <summary>
	/// идентификатор редактора;
	/// </summary>
	[JsonProperty(propertyName: "editor_id")]
	public string EditorId { get; set; }

	/// <summary>
	/// имя редактора.
	/// </summary>
	[JsonProperty(propertyName: "editor_name")]
	public string EditorName { get; set; }
}