using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

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
	public OccupationType? Type { get; set; }
}