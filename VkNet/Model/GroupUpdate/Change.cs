using System;
using Newtonsoft.Json;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Изменение настроек сообщества
/// </summary>
[Serializable]
public class Change
{
	/// <summary>
	/// Название секции или раздела, который был изменён
	/// </summary>
	[JsonProperty("{FIELD}")]
	public string Field { get; set; }

	/// <summary>
	/// Новое значение
	/// </summary>
	[JsonProperty("new_value")]
	public string NewValue { get; set; }

	/// <summary>
	/// Старое значение
	/// </summary>
	[JsonProperty("old_value")]
	public string OldValue { get; set; }
}