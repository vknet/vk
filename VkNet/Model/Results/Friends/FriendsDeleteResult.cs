using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат запроса Friends.Delete
/// </summary>
[Serializable]
public class FriendsDeleteResult
{
	/// <summary>
	/// Удалось успешно удалить друга
	/// </summary>
	[JsonProperty(propertyName: "success")]
	public bool? Success { get; set; }

	/// <summary>
	/// Был удален друг
	/// </summary>
	[JsonProperty(propertyName: "friend_deleted")]
	public bool? FriendDeleted { get; set; }

	/// <summary>
	/// Отменена исходящая заявка
	/// </summary>
	[JsonProperty(propertyName: "out_request_deleted")]
	public bool? OutRequestDeleted { get; set; }

	/// <summary>
	/// Отклонена входящая заявка
	/// </summary>
	[JsonProperty(propertyName: "in_request_deleted")]
	public bool? InRequestDeleted { get; set; }

	/// <summary>
	/// Отклонена рекомендация друга
	/// </summary>
	[JsonProperty(propertyName: "suggestion_deleted")]
	public bool? SuggestionDeleted { get; set; }
}