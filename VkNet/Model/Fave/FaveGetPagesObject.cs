using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Ответ метода fave.getPages
/// </summary>
[Serializable]
public class FaveGetPagesObject
{
	/// <summary>
	/// Описание страницы.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Тип страницы.
	/// </summary>
	[JsonProperty("type")]
	public UserOrGroupType? Type { get; set; }

	/// <summary>
	/// Метки страницы.
	/// </summary>
	[JsonProperty("tags")]
	public IEnumerable<FaveTag> Tags { get; set; }

	/// <summary>
	/// Дата обновления.
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("updated_date")]
	public DateTime UpdatedDate { get; set; }

	/// <summary>
	/// Информация о пользователе.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/objects/user
	/// </remarks>
	[JsonProperty("user")]
	public User User { get; set; }

	/// <summary>
	/// Информация о сообществе (группе).
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/fields_groups
	/// </remarks>
	[JsonProperty("group")]
	public Group Group { get; set; }
}