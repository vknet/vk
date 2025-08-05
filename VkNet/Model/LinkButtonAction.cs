using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Действие кнопки
/// </summary>
[Serializable]
public class LinkButtonAction
{
	/// <summary>
	/// Тип действия. Возможные значения.
	/// </summary>
	[JsonProperty(propertyName: "type")]
	public string Type { get; set; }

	/// <summary>
	/// Ссылка на которую ведет кнопка.
	/// </summary>
	[JsonProperty(propertyName: "url")]
	public Uri Uri { get; set; }

	/// <summary>
	/// Назначание действия
	/// </summary>
	[JsonProperty(propertyName: "target")]
	public string Target { get; set; }

	/// <summary>
	/// Идентификатор группы
	/// </summary>
	[JsonProperty(propertyName: "group_id")]
	public long? GroupId { get; set; }
}