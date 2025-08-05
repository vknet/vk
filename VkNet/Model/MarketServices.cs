using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о продукте.
/// </summary>
[Serializable]
public class MarketServices
{
	/// <summary>
	/// Id
	/// </summary>
	[JsonProperty("contact_id")]
	public long ContactId { get; set; }

	/// <summary>
	/// Цена
	/// </summary>
	[JsonProperty("currency")]
	public Currency Price { get; set; }

	/// <summary>
	/// Признак активности
	/// </summary>
	[JsonProperty("enabled")]
	public bool? Enabled { get; set; }

	/// <summary>
	/// Признак возможности отправки сообщений
	/// </summary>
	[JsonProperty("can_message")]
	public bool? CanMessage { get; set; }

	/// <summary>
	/// Признак возможности комментировать
	/// </summary>
	[JsonProperty("comments_enabled")]
	public bool? CommentsEnabled { get; set; }
}