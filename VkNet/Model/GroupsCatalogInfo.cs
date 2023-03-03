using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ответ на запрос метода groups.getCatalogInfo
/// </summary>
[Serializable]
public class GroupsCatalogInfo
{
	/// <summary>
	/// Список категорий.
	/// </summary>
	[JsonProperty("categories")]
	public IEnumerable<CategoryGroup> Categories { get; set; }

	/// <summary>
	/// Признак доступности каталога для пользователя.
	/// </summary>
	[JsonProperty("enabled")]
	public bool Enabled { get; set; }
}