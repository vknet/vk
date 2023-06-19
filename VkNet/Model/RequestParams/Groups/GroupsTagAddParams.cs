using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Параметры метода groups.tagAdd
/// </summary>
[Serializable]
public class GroupsTagAddParams
{
	/// <summary>
	/// идентификатор сообщества.
	/// положительное число, обязательный параметр
	/// </summary>
	[JsonProperty("group_id")]
	public ulong GroupId { get; set; }

	/// <summary>
	/// Название тэга
	/// максимальная длина 20, обязательный параметр
	/// </summary>
	[JsonProperty("tag_name")]
	public string TagName { get; set; }

	/// <summary>
	/// Цвет тэга
	/// <remarks>
	/// <para>Должен быть одним из следующих значений: </para>
	/// 4bb34b,
	/// 5c9ce6,
	/// e64646,
	/// 792ec0,
	/// 63b9ba,
	/// ffa000,
	/// ffc107,
	/// 76787a,
	/// 9e8d6b,
	/// 45678f,
	/// 539b9c,
	/// 454647,
	/// 7a6c4f,
	/// 6bc76b,
	/// 5181b8,
	/// ff5c5c,
	/// a162de,
	/// 7ececf,
	/// aaaeb3,
	/// bbaa84
	/// </remarks>
	/// </summary>
	[JsonProperty("tag_color")]
	public string TagColor { get; set; }
}