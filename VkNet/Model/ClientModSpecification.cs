using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Массив объектов ClientModSpecification
/// </summary>
[Serializable]
public class ClientModSpecification
{
	/// <summary>
	/// Идентификатор редактируемого клиента.
	/// </summary>
	[JsonProperty("client_id")]
	public long ClientId { get; set; }

	/// <summary>
	/// Общий лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("all_limit")]
	public long AllLimit { get; set; }

	/// <summary>
	/// Дневной лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("day_limit")]
	public long DayLimit { get; set; }

	/// <summary>
	/// Название объявления.
	/// </summary>
	[JsonProperty(propertyName: "name")]
	public string Name { get; set; }
}