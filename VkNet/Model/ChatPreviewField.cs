using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о чате.
/// </summary>
[Serializable]
public class ChatPreviewField
{
	/// <summary>
	/// Идентификатор создателя чата
	/// </summary>
	[JsonProperty(propertyName: "admin_id")]
	public long AdminId { get; set; }

	/// <summary>
	/// Массив идентификаторов участников чата
	/// </summary>
	[JsonProperty(propertyName: "members")]
	public IEnumerable<long> Members { get; set; }

	/// <summary>
	/// Название чата
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }

	/// <summary>
	/// Обложка чата
	/// </summary>
	[JsonProperty(propertyName: "photo")]
	public ChatPhoto Photo { get; set; }

	/// <summary>
	/// Идентификатор чата для текущего пользователя
	/// </summary>
	[JsonProperty(propertyName: "local_id")]
	public int LocalId { get; set; }
}