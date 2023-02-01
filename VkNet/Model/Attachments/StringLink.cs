﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

/// <summary>
/// Строковая ссылка
/// </summary>
[Serializable]
public class StringLink : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "string";

	/// <summary>
	/// Ссылка
	/// </summary>
	[JsonProperty("link")]
	public string Link { get; set; }

	/// <inheritdoc />
	public override string ToString() => Link;

	/// <summary>
	/// Преобразование класса <see cref="StringLink" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="StringLink" /></returns>
	public static implicit operator StringLink(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}

	private static StringLink FromJson(VkResponse response) => new()
	{
		Link = response["link"]
	};
}