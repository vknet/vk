﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Кафедра
/// </summary>
[Serializable]
public class Chair
{
	/// <summary>
	/// Идентификатор факультета
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Название факультета
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	#region public Methods

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Chair FromJson(VkResponse response)
	{
		var result = new Chair
		{
			Id = response[key: "id"],
			Title = response[key: "title"]
		};

		return result;
	}

	#endregion
}