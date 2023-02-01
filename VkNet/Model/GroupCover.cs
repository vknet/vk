using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Обложка сообщества.
/// </summary>
[Serializable]
public class GroupCover
{
	/// <summary>
	/// Информация о том, включена ли обложка (1 — да, 0 — нет);
	/// </summary>
	[JsonProperty("enabled")]
	public bool? Enabled { get; set; }

	/// <summary>
	/// Копии изображений обложки.
	/// </summary>
	[JsonProperty("images")]
	public IEnumerable<GroupCoverImage> Images { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static GroupCover FromJson(VkResponse response) => new()
	{
		Enabled = response[key: "enabled"],
		Images = response[key: "images"]
			.ToReadOnlyCollectionOf<GroupCoverImage>(selector: o => o)
	};
}