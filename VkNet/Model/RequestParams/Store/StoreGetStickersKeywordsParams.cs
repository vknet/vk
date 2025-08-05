using System;
using System.Collections.Generic;

namespace VkNet.Model;

/// <summary>
/// Список параметров для метода store.getStickersKeywords
/// </summary>
[Serializable]
public class StoreGetStickersKeywordsParams
{
	/// <summary>
	/// Идентификаторы стикеров
	/// </summary>
	public List<string> StickerIds { get; set; }

	/// <summary>
	/// Идентификаторы продуктов
	/// </summary>
	public List<string> ProductIds { get; set; }

	/// <summary>
	/// Если true, то будет возвращены синонимы для каждого из ключевых слов
	/// </summary>
	public bool Aliases { get; set; }

	/// <summary>
	/// Если true, то будет возвращена информация о всех активных продуктах на сайтах с учётом страны
	/// </summary>
	public bool AllProducts { get; set; }

	/// <summary>
	/// Если true, то будут возвращены стикеры вместе с подсказками.
	/// </summary>
	public bool NeedStickers { get; set; }
}