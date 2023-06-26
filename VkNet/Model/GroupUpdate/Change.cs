using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Изменение настроек сообщества
/// </summary>
[Serializable]
[JsonConverter(typeof(ChangeJsonConverter))]
public class Change
{
	/// <summary>
	/// Название секции или раздела, который был изменён
	/// </summary>
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