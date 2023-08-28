using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация о родственнике.
/// См. описание http://vk.com/dev/fields
/// </summary>
[Serializable]
public class Relative
{
	/// <summary>
	/// Идентификатор родственника.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Тип родственника (sibling и т.п.)
	/// </summary>
	[JsonProperty("type")]
	public RelativeType? Type { get; set; }

	/// <summary>
	/// Имя родственника, если он не является пользователем ВКонтакте.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("user_id")]
	private long UserId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("uid")]
	private long Uid
	{
		get => Id;
		set => Id = value;
	}
}