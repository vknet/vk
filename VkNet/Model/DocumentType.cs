﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Тип документа.
/// </summary>
[Serializable]
public class DocumentType
{
	/// <summary>
	/// Идентификатор полученного подарка.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Текст сообщения, приложенного к подарку.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Количество документов данного типа.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> Тип документа. </returns>
	public static DocumentType FromJson(VkResponse response)
	{
		var result = new DocumentType
		{
			Id = response[key: "id"],
			Name = response[key: "name"],
			Count = response[key: "count"]
		};

		return result;
	}
}