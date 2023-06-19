using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Response Message.GetChatUsers
/// </summary>
[Serializable]
[JsonConverter(typeof(GetChatUsersJsonConverter))]
public class GetChatUsers
{
	/// <summary>
	/// Список участников бесед
	/// </summary>
	public ReadOnlyCollection<User> Users { get; set; }
}