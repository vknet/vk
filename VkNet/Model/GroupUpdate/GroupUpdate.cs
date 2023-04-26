using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

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
	[JsonConverter(typeof(UpdateTypeConverter))]
	public UpdateType Type { get; set; }

	/// <summary>
	/// ID группы
	/// </summary>
	[JsonProperty("group_id")]
	[JsonConverter(typeof(GroupIdConverter))]
	public GroupId GroupId { get; set; }

	/// <summary>
	/// <c>Secret Key</c> для Callback
	/// </summary>
	[JsonConverter(typeof(SecretConverter))]
	public Secret Secret { get; set; }

	/// <summary>
	/// Необработанные данные
	/// </summary>
	public VkResponse Raw { get; set; }
}