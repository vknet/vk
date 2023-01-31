using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о заявке на смену имени.
/// </summary>
[Serializable]
public class ChangeNameRequest
{
	/// <summary>
	/// Результат изменений
	/// </summary>
	[JsonProperty("changed")]
	public bool Changed { get; set; }

	/// <summary>
	/// Информация о заявке на смену имени
	/// </summary>
	[JsonProperty("name_request")]
	public NameRequest NameRequest { get; set; }
}