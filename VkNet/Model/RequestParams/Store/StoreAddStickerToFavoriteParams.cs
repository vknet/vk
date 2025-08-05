using System;
using System.Collections.Generic;

namespace VkNet.Model;

/// <summary>
/// Список параметров для метода store.addStickersToFavorite
/// </summary>
[Serializable]
public class StoreAddStickerToFavoriteParams
{
	/// <summary>
	/// Идентификаторы стикеров
	/// </summary>
	public List<string> StickerIds { get; set; }
}