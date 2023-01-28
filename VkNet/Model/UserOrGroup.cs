using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Расширенная информация о пользователях или сообществах.
/// </summary>
[Serializable]
[JsonConverter(typeof(UserOrGroupJsonConverter))]
public class UserOrGroup
{
	/// <summary>
	/// Общее количество элементов.
	/// </summary>
	[JsonProperty("count")]
	public ulong TotalCount { get; set; }

	/// <summary>
	/// Список пользователей.
	/// </summary>
	[JsonProperty("profile")]
	public List<User> Users { get; set; }

	/// <summary>
	/// Список групп.
	/// </summary>
	[JsonProperty("group")]
	public List<Group> Groups { get; set; }
}