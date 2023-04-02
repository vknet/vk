using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Обновление группы
/// </summary>
[Serializable]
public class GroupUpdate
{
	/// <summary>
	/// Экземпляр самого обновления группы.
	/// </summary>
	public IGroupUpdate Instance { get; set; }

	/// <summary>
	/// Тип обновления
	/// </summary>
	public UpdateType Type { get; set; }

	/// <summary>
	/// ID группы
	/// </summary>
	[JsonProperty("group_id")]
	public GroupId GroupId { get; set; }

	/// <summary>
	/// <c>Secret Key</c> для Callback
	/// </summary>
	[JsonProperty("secret")]
	public Secret Secret { get; set; }

	/// <summary>
	/// Необработанные данные
	/// </summary>
	public VkResponse Raw { get; set; }
}