using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Подсказки
/// </summary>
[Serializable]
public class Hint
{
	/// <summary>
	/// Коллекция строк, содержащих слова и (или) Emoji соответствующие стикерам из поля UserStickers
	/// </summary>
	[JsonProperty("words")]
	public List<string> Words { get; set; }

	/// <summary>
	/// Стикеры, которые установлены у пользователя
	/// </summary>
	[JsonProperty("user_stickers")]
	public List<Sticker> UserStickers { get; set; }

	/// <summary>
	/// Cтикеры, которым соответствуют ключевые слова words, но наборы с ними у пользователя не установлены
	/// </summary>
	[JsonProperty("promoted_stickers")]
	public List<Sticker> PromotedStickers { get; set; }
}