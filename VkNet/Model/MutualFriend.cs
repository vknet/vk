using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Общий друг
/// </summary>
[Serializable]
public class MutualFriend
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("id")]
	public ulong Id { get; set; }

	/// <summary>
	/// Идентификаторы общих друзей
	/// </summary>
	[JsonProperty("common_friends")]
	public ReadOnlyCollection<ulong> CommonFriends { get; set; }

	/// <summary>
	/// Количество общих друзей
	/// </summary>
	[JsonProperty("common_count")]
	public ulong CommonCount { get; set; }
}