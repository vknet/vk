using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model;

/// <summary>
/// Friends Get Requests Result
/// </summary>
[Serializable]
public class FriendsGetRequestsResult
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty(propertyName: "user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty(propertyName: "mutual")]
	[JsonConverter(typeof(VkCollectionJsonConverter), "users")]
	public VkCollection<long> Mutual { get; set; }

	/// <summary>
	/// Текст сообщения
	/// </summary>
	[JsonProperty("message")]
	public string Message { get; set; }
}