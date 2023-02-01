﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Информация о просмотрах записи.
/// </summary>
[Serializable]
public class PostView
{
	/// <summary>
	/// Число просмотров записи.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static PostView FromJson(VkResponse response) => new()
	{
		Count = response[key: "count"]
	};
}