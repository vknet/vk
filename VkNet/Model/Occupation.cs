using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[Serializable]
public class Occupation
{
	/// <summary>
	/// Название школы, вуза или места работы
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Идентификатор школы, вуза, группы компании (в которой пользователь работает).
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Информация о текущем роде занятия пользователя.
	/// </summary>
	[JsonProperty("type")]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public OccupationType Type { get; set; }
}