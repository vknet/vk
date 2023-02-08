using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// История изменения объекта
/// </summary>
[Serializable]
public class History
{
	/// <summary>
	/// Идентификатор.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Длина символов.
	/// </summary>
	/// <remarks>
	/// При необходимости сделать nullable
	/// </remarks>
	[JsonProperty("length")]
	public int Length { get; set; }

	/// <summary>
	/// Дата изменения.
	/// </summary>
	[JsonProperty("date")]
	public string Date { get; set; }

	/// <summary>
	/// Идентификатор пользователя применившего изменения.
	/// </summary>
	[JsonProperty("editor_id")]
	public long EditorId { get; set; }

	/// <summary>
	/// Имя пользователя применившего изменения.
	/// </summary>
	[JsonProperty("editor_name")]
	public string EditorName { get; set; }
}