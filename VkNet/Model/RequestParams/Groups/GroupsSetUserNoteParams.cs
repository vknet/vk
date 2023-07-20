using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Параметры метода groups.setUserNote
/// </summary>
[Serializable]
public class GroupsSetUserNoteParams
{
	/// <summary>
	/// идентификатор сообщества.
	/// положительное число, обязательный параметр
	/// </summary>
	[JsonProperty("group_id")]
	public ulong GroupId { get; set; }

	/// <summary>
	/// идентификатор пользователя.
	/// положительное число, обязательный параметр
	/// </summary>
	[JsonProperty("user_id")]
	public ulong UserId { get; set; }

	/// <summary>
	/// содержимое заметки, максимальная длина - 96 символов
	/// </summary>
	[JsonProperty("note")]
	public string Note { get; set; }
}